using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace CefSharpDemo
{
    public partial class frmMain : frmBase
    {
        string Url = "http://localhost:5002/pages/index.html";
        StringBuilder strSource = new StringBuilder();

        public frmMain()
        {
            InitializeComponent();
        }

        public void InitBrowser()
        {
            CefSettings cefSettings = new CefSettings();
            Cef.Initialize(cefSettings);

            BrowserSettings browserSettings = new BrowserSettings();
            browserSettings.FileAccessFromFileUrls = CefState.Enabled;
            browserSettings.UniversalAccessFromFileUrls = CefState.Enabled;

            DownloadHandler download = new DownloadHandler(this, barPercent);

            ChromiumWebBrowser browser = new ChromiumWebBrowser(Url);
            browser.Name = "ChromiumWebBrowser";
            browser.Dock = DockStyle.Fill;
            browser.BrowserSettings = browserSettings;
            browser.DownloadHandler = download;

            tpBrowser.Controls.Clear();
            tpBrowser.Controls.Add(browser);

            btnDevTools.Click -= BtnDevTools_Click;
            btnDevTools.Click += BtnDevTools_Click;
            btnGetHTML.Click -= BtnGetHTML_Click;
            btnGetHTML.Click += BtnGetHTML_Click;
            browser.FrameLoadStart -= Browser_FrameLoadStart;
            browser.FrameLoadStart += Browser_FrameLoadStart;
            browser.FrameLoadEnd -= Browser_FrameLoadEnd;
            browser.FrameLoadEnd += Browser_FrameLoadEnd;
            download.OnBeforeDownloadFired -= Download_OnBeforeDownloadFired;
            download.OnBeforeDownloadFired += Download_OnBeforeDownloadFired;
            download.OnDownloadUpdatedFired -= Download_OnDownloadUpdatedFired;
            download.OnDownloadUpdatedFired += Download_OnDownloadUpdatedFired;
        }

        protected override void FrmBase_Load(object sender, EventArgs e)
        {
            InitBrowser();
        }
        protected override void FrmBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }
        private void BtnGetHTML_Click(object sender, EventArgs e)
        {
            ChromiumWebBrowser browser = tpBrowser.Controls["ChromiumWebBrowser"] as ChromiumWebBrowser;
            frmHTMLSource _frm = new frmHTMLSource();
            _frm.ResetText();
            _frm.SetData(strSource.ToString());
            _frm.ShowDialog(this);
        }
        private void BtnDevTools_Click(object sender, EventArgs e)
        {
            ChromiumWebBrowser browser = tpBrowser.Controls["ChromiumWebBrowser"] as ChromiumWebBrowser;
            browser.ShowDevTools();
        }
        private void Browser_FrameLoadStart(object sender, FrameLoadStartEventArgs e)
        {
            ChromiumWebBrowser browser = sender as ChromiumWebBrowser;
            strSource.Clear();
        }
        private void Download_OnBeforeDownloadFired(object sender, DownloadItem e)
        {
        }
        private void Download_OnDownloadUpdatedFired(object sender, DownloadItem e)
        {
        }
        private async void Browser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            ChromiumWebBrowser browser = sender as ChromiumWebBrowser;
            strSource.Append(await browser.GetSourceAsync());
        }
    }

    public class DownloadHandler : IDownloadHandler
    {
        public event EventHandler<DownloadItem> OnBeforeDownloadFired;
        public event EventHandler<DownloadItem> OnDownloadUpdatedFired;
        Form frmMain;
        ProgressBar progressBar;

        public DownloadHandler(Form frmMain, ProgressBar progressBar)
        {
            this.frmMain = frmMain;
            this.progressBar = progressBar;
        }

        public void OnBeforeDownload(IBrowser browser, DownloadItem downloadItem, IBeforeDownloadCallback callback)
        {
            OnBeforeDownloadFired?.Invoke(this, downloadItem);

            if (!callback.IsDisposed)
            {
                using (callback)
                {
                    callback.Continue(downloadItem.SuggestedFileName, showDialog: true);
                }
            }
        }
        public void OnDownloadUpdated(IBrowser browser, DownloadItem downloadItem, IDownloadItemCallback callback)
        {
            OnDownloadUpdatedFired?.Invoke(this, downloadItem);
        }
    }
}
