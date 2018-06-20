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
using CefSharpDemo.BLL;
using CefSharpDemo.General;
using CefSharpDemo.GUI;
using CefSharpDemo.Model;

namespace CefSharpDemo
{
    public partial class frmMain : frmBase
    {
        //string Url = "www.clker.com/inc/svgedit/svg-editor.html";
        //string Url = "http://localhost/test/";
        string Url = "http://localhost:2695/";
        StringBuilder strSource = new StringBuilder();
        List<ActionData> lstSteps = new List<ActionData>();
        int curStep = 0;
        int numStep = 0;
        public frmMain()
        {
            InitializeComponent();
        }

        protected override void FrmBase_Load(object sender, EventArgs e)
        {
            CefSettings cefSettings = new CefSettings();
            Cef.Initialize(cefSettings);

            btnClick.Click -= BtnClick_Click;
            btnGetHTML.Click -= BtnGetHTML_Click;
            btnDevTools.Click -= BtnDevTools_Click;
            btnInsertData.Click -= BtnInsertData_Click;

            btnClick.Click += BtnClick_Click;
            btnGetHTML.Click += BtnGetHTML_Click;
            btnDevTools.Click += BtnDevTools_Click;
            btnInsertData.Click += BtnInsertData_Click;
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

            //if (curStep < numStep)
            //{
            //    lstSteps[curStep].Action(browser);
            //}
            //curStep++;
        }
        private void BtnClick_Click(object sender, EventArgs e)
        {
            ChromiumWebBrowser browser = tpBrowser.Controls["ChromiumWebBrowser"] as ChromiumWebBrowser;
            if (curStep < numStep)
            {
                lstSteps[curStep].Action(browser);
            }
            curStep++;
        }
        private void BtnInsertData_Click(object sender, EventArgs e)
        {
            frmInsertData frm = new frmInsertData();
            frm.ResendData = new frmInsertData.SendData(new Action<List<ActionData>>((_lstSteps) =>
            {
                curStep = 0;
                numStep = _lstSteps.Count;
                lstSteps = _lstSteps;

                InitBrowser();
            }));
            frm.Show();
        }

        public void InitBrowser()
        {
            BrowserSettings browserSettings = new BrowserSettings();
            browserSettings.FileAccessFromFileUrls = CefState.Enabled;
            browserSettings.UniversalAccessFromFileUrls = CefState.Enabled;

            ChromiumWebBrowser browser = new ChromiumWebBrowser(Url);
            browser.Name = "ChromiumWebBrowser";
            browser.Dock = DockStyle.Fill;
            browser.BrowserSettings = browserSettings;

            tpBrowser.Controls.Clear();
            tpBrowser.Controls.Add(browser);

            browser.FrameLoadStart -= Browser_FrameLoadStart;
            browser.FrameLoadEnd -= Browser_FrameLoadEnd;

            browser.FrameLoadStart += Browser_FrameLoadStart;
            browser.FrameLoadEnd += Browser_FrameLoadEnd;
        }
    }
}
