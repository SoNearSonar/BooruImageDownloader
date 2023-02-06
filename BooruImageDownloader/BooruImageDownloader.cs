using BooruImageDownloader.Utilities;
using BooruSharp.Booru;
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

        Queue<SearchResult> _results = new Queue<SearchResult>();
        int _downloadCount = 0;
        int _totalCount = 0;

        Image img;
        byte[] responseContents;

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
                    }
                }
                else
                {
                    if (uint.TryParse(TXT_DownloadLimit.Text, out uint limit))
                    {
                        SearchResult[] results = await GetResults((int)limit, tags);
                        foreach (SearchResult result in results)
                        {
                            _results.Enqueue(result);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter in a proper limit number", "Incorrect limit number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                _totalCount = _results.Count;
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
            SearchResult _downloadResult = _results.Dequeue();
            if (_downloadResult.FileUrl != null)
            {
                using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, _downloadResult.FileUrl.OriginalString);
                request.Headers.Add("User-Agent", "Other");
                using HttpResponseMessage response = await _client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                responseContents = await response.Content.ReadAsByteArrayAsync();

                using MemoryStream memStr = new MemoryStream(responseContents);
                if (img != null)
                {
                    img.Dispose();
                }
                if (PBX_Preview.Image != null)
                {
                    PBX_Preview.Image.Dispose();
                }

                img = Image.FromStream(memStr);
                PBX_Preview.Image = img;
                img.Save(Path.Combine(TXT_OutputFolder.Text, $"Image_{_downloadResult.ID}"), ImageFormat.Jpeg);

                LBL_ImageCount.Text = $"Image: {++_downloadCount} out of {_totalCount} processed";
                LBL_ImageURL.Text = $"Image URL: {_downloadResult.PostUrl.OriginalString}";
                LBL_Size.Text = $"Size: {SizeFormatter.GetBytesReadable(ulong.Parse(response.Content.Headers.ContentLength.ToString()))}";
                PBR_DownloadedImages.Value = (int)((_downloadCount / _totalCount) * 100);
            }

            if (_results.Count > 0)
            {
                DownloadContents();
            }
            else
            {
                LBL_ImageCount.Text = "Image: ";
                LBL_ImageURL.Text = "Image URL: ";
                LBL_Size.Text = "Size: ";
                PBR_DownloadedImages.Value = 0;
                _downloadCount = 0;
                _totalCount = 0;
            }
        }

        private async Task<SearchResult> GetResult(int ID)
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

        private async Task<SearchResult[]> GetResults(int limit, string[] tags)
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
    }
}