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
        //string Url = "www.clker.com/inc/svgedit/svg-editor.html";
        string Url = "http://localhost/test/";
        StringBuilder strSource = new StringBuilder();

        public frmMain()
        {
            InitializeComponent();
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
            frmHTMLSource _frm = new frmHTMLSource();
            _frm.ResetText();
            _frm.SetData(strSource.ToString());
            _frm.Show();

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
        private async void Browser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            ChromiumWebBrowser browser = sender as ChromiumWebBrowser;
            strSource.Append(await browser.GetSourceAsync());
        }
        private void BtnClick_Click(object sender, EventArgs e)
        {
            ChromiumWebBrowser browser = tpBrowser.Controls["ChromiumWebBrowser"] as ChromiumWebBrowser;
            StringBuilder strScript = new StringBuilder();

            strScript.Append("function triggerMouseEvent (node, eventType) {");
            strScript.Append("    var clickEvent = document.createEvent ('MouseEvents');");
            strScript.Append("    clickEvent.initEvent (eventType, true, true);");
            strScript.Append("    node.dispatchEvent (clickEvent);");
            strScript.Append("}");

            strScript.Append("function ShowMessage(){alert($('#txtInput').val());}");
            strScript.Append("$('#txtInput').val('Hello World !!!');");
            //strScript.Append("$('#btnClick').click();");

            strScript.Append("var targetNode = document.getElementById('btnClick');");
            strScript.Append("triggerMouseEvent (targetNode, 'mouseover');");
            strScript.Append("triggerMouseEvent (targetNode, 'mousedown');");
            strScript.Append("triggerMouseEvent (targetNode, 'mouseup');");
            strScript.Append("triggerMouseEvent (targetNode, 'click');");

            browser.ExecuteScriptAsync(strScript.ToString());
        }

        public void InitBrowser()
        {
            CefSettings cefSettings = new CefSettings();
            Cef.Initialize(cefSettings);

            BrowserSettings browserSettings = new BrowserSettings();
            browserSettings.FileAccessFromFileUrls = CefState.Enabled;
            browserSettings.UniversalAccessFromFileUrls = CefState.Enabled;

            ChromiumWebBrowser browser = new ChromiumWebBrowser(Url);
            browser.Name = "ChromiumWebBrowser";
            browser.Dock = DockStyle.Fill;
            browser.BrowserSettings = browserSettings;

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
            btnClick.Click -= BtnClick_Click;
            btnClick.Click += BtnClick_Click;
        }
    }
}
