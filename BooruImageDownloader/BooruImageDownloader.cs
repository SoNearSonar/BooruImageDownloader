using BooruImageDownloader.Utilities;
using BooruSharp.Booru;
using BooruSharp.Search;
using BooruSharp.Search.Post;
using System.Configuration.Internal;

namespace BooruImageDownloader
{
    public partial class BooruImageDownloader : Form
    {
        static readonly HttpClient _client = new HttpClient();
        readonly DanbooruDonmai _danbooruClient = new DanbooruDonmai();
        readonly Gelbooru _gelbooruClient = new Gelbooru();
        readonly Konachan _konaClient = new Konachan();
        readonly Sakugabooru _sakugaClient = new Sakugabooru();
        readonly Yandere _yandClient = new Yandere();

        readonly Queue<SearchResult> _results = new Queue<SearchResult>();
        int _downloadCount = 0;
        int _totalCount = 0;

        Image img;

        public BooruImageDownloader()
        {
            InitializeComponent();
            CBX_Website.SelectedIndex = 0;
        }

        private void BooruImageDownloader_Load(object sender, EventArgs e)
        {
            UpdateTextBoxVisibility();
        }

        private void CHK_IndividualDownload_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBoxVisibility();
        }

        private void UpdateTextBoxVisibility()
        {
            TXT_ID.Enabled = CHK_IndividualDownload.Checked;
            TXT_DownloadLimit.Enabled = !CHK_IndividualDownload.Checked;
        }

        private async void BTN_Download_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TXT_Tags.Text))
            {
                string[] tags = TXT_Tags.Text.Split(',');
                for (int i = 0; i < tags.Length; i++)
                {
                    tags[i] = tags[i].Trim().Replace(" ", "_");
                }

                if (CHK_IndividualDownload.Checked)
                {
                    if (uint.TryParse(TXT_ID.Text, out uint ID))
                    {
                        SearchResult result = await GetResult((int)ID);
                        _results.Enqueue(result);
                    }
                    else
                    {
                        MessageBox.Show("Please enter in a proper ID number", "Incorrect ID number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    if (uint.TryParse(TXT_DownloadLimit.Text, out uint limit))
                    {
                        SearchResult[] results = await GetResults((int)limit, tags);
                        if (results != null)
                        {
                            foreach (SearchResult result in results)
                            {
                                _results.Enqueue(result);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter in a proper limit number", "Incorrect limit number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                _totalCount = _results.Count;
                _downloadCount = 0;
                if (_results.Count > 0)
                {
                    DownloadContents();
                }
                else
                {
                    MessageBox.Show("There are no results for that tag or ID", "No results found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void DownloadContents()
        {
            BTN_Download.Enabled = false;
            SearchResult _downloadResult = _results.Dequeue();
            if (_downloadResult.FileUrl != null)
            {
                Stream responseImage = await GetImageFromReasult(_downloadResult.FileUrl);
                Stream responseThumbnail = await GetImageFromReasult(_downloadResult.PreviewUrl);
                ulong size = (ulong)responseImage.Length;

                img?.Dispose();
                PBX_Preview.Image?.Dispose();

                if (responseImage != null && responseThumbnail != null)
                {
                    try
                    {
                        img = Image.FromStream(responseImage);
                        img = ImageResizer.ResizeImage(
                            img, 
                            DataFormatter.GetScaledDimension(img.Width, TBR_ImageScale.Value * 0.01),
                            DataFormatter.GetScaledDimension(img.Height, TBR_ImageScale.Value * 0.01)
                        );
                        img.Save(Path.Combine(TXT_OutputFolder.Text, $"Image_{_downloadResult.ID}.png"));
                        PBX_Preview.Image = Image.FromStream(responseThumbnail);
                    }
                    catch
                    {
                        img?.Dispose();
                        PBX_Preview.Image?.Dispose();
                    }
                    responseImage.Dispose();
                    responseThumbnail.Dispose();
                }


                LBL_ImageCount.Text = $"Image: {++_downloadCount} out of {_totalCount} processed";
                LBL_ImageURL.Text = $"Image URL: {_downloadResult.PostUrl.OriginalString}";
                LBL_Size.Text = $"Size: {DataFormatter.GetBytesReadable(size)}";
                PBR_DownloadedImages.Value = DataFormatter.GetPrecentage(_downloadCount, _totalCount);
            }

            if (_results.Count > 0)
            {
                DownloadContents();
            }
            else
            {
                BTN_Download.Enabled = true;
            }
        }

        private async Task<SearchResult> GetResult(int ID)
        {
            try
            {
                switch (CBX_Website.SelectedIndex)
                {
                    case 0:
                        return await _danbooruClient.GetPostByIdAsync(ID);
                    case 1:
                        return await _gelbooruClient.GetPostByIdAsync(ID);
                    case 2:
                        return await _konaClient.GetPostByIdAsync(ID);
                    case 3:
                        return await _sakugaClient.GetPostByIdAsync(ID);
                    case 4:
                        return await _yandClient.GetPostByIdAsync(ID);
                    default:
                        return default;
                }
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("There are no results for that ID", "No results found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }
        }

        private async Task<SearchResult[]> GetResults(int limit, string[] tags)
        {
            try
            {
                switch (CBX_Website.SelectedIndex)
                {
                    case 0:
                        return await _danbooruClient.GetRandomPostsAsync(limit, tags);
                    case 1:
                        return await _gelbooruClient.GetRandomPostsAsync(limit, tags);
                    case 2:
                        return await _konaClient.GetRandomPostsAsync(limit, tags);
                    case 3:
                        return await _sakugaClient.GetRandomPostsAsync(limit, tags);
                    case 4:
                        return await _yandClient.GetRandomPostsAsync(limit, tags);
                    default:
                        return default;
                }
            }
            catch (TooManyTags)
            {
                MessageBox.Show($"You cannot search 2 or more tags with {CBX_Website.SelectedItem}", "Too many tags error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }
        }

        private async Task<Stream> GetImageFromReasult(Uri uri)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.OriginalString);
            request.Headers.Add("User-Agent", "Other");
            HttpResponseMessage response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStreamAsync();
        }
    }
}