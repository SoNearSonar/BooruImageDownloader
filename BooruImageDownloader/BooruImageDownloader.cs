using BooruImageDownloader.Utilities;
using BooruSharp.Booru;
using BooruSharp.Search;
using BooruSharp.Search.Post;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Net;
using System.Windows.Forms;

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

        Image? img;

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

        private void BTN_Set_Click(object sender, EventArgs e)
        {
            BooruAuth auth = new BooruAuth(TXT_Username.Text, TXT_APIKey.Text);
            switch (CBX_Website.SelectedIndex)
            {
                case 0:
                    _danbooruClient.Auth = auth;
                    break;
                case 1:
                    _gelbooruClient.Auth = auth;
                    break;
                case 2:
                    _konaClient.Auth = auth;
                    break;
                case 3:
                    _sakugaClient.Auth = auth;
                    break;
                case 4:
                    _yandClient.Auth = auth;
                    break;
            }
            MessageBox.Show($"Credentials for {CBX_Website.SelectedItem} have been set", "Set credentials", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void DownloadContents()
        {
            BTN_Download.Enabled = false;
            SearchResult _downloadResult = _results.Dequeue();
            if (_downloadResult.FileUrl != null)
            {
                using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, _downloadResult.FileUrl.OriginalString);
                request.Headers.Add("User-Agent", "Other");
                using HttpResponseMessage response = await _client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                using Stream responseContents = await response.Content.ReadAsStreamAsync();

                img?.Dispose();
                PBX_Preview.Image?.Dispose();

                img = Image.FromStream(responseContents);
                PBX_Preview.Image = img;
                img.Save(Path.Combine(TXT_OutputFolder.Text, $"Image_{_downloadResult.ID}.png"));

                LBL_ImageCount.Text = $"Image: {++_downloadCount} out of {_totalCount} processed";
                LBL_ImageURL.Text = $"Image URL: {_downloadResult.PostUrl.OriginalString}";
                LBL_Size.Text = $"Size: {DataFormatter.GetBytesReadable(ulong.Parse(response.Content.Headers.ContentLength.ToString()))}";
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
            MessageBox.Show(tags.Length.ToString());
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
                MessageBox.Show($"You cannot search 2 or more tags with {CBX_Website.SelectedItem} unless you have an account", "Too many tags error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }
        }
    }
}