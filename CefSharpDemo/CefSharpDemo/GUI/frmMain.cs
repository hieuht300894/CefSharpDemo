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

namespace CefSharpDemo
{
    public partial class frmMain : frmBase
    {
        //string Url = "www.clker.com/inc/svgedit/svg-editor.html";
        //string Url = "http://localhost/test/";
        string Url = "http://localhost:2695/";
        StringBuilder strSource = new StringBuilder();
        List<Action<ChromiumWebBrowser>> lstSteps = new List<Action<ChromiumWebBrowser>>();
        /// <summary>
        /// -1: Wait
        /// </summary>
        int curStep = 0;
        int numStep = 0;

        public frmMain()
        {
            InitializeComponent();
        }

        protected override void FrmBase_Load(object sender, EventArgs e)
        {
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

            if (curStep < numStep)
            {
                Action<ChromiumWebBrowser> action = lstSteps[curStep];
                action(browser);
            }
            curStep++;
        }
        private void BtnClick_Click(object sender, EventArgs e)
        {
            ChromiumWebBrowser browser = tpBrowser.Controls["ChromiumWebBrowser"] as ChromiumWebBrowser;
            //StringBuilder strScript = new StringBuilder();

            //strScript.Append("function triggerMouseEvent (node, eventType) {");
            //strScript.Append("    var clickEvent = document.createEvent ('MouseEvents');");
            //strScript.Append("    clickEvent.initEvent (eventType, true, true);");
            //strScript.Append("    node.dispatchEvent (clickEvent);");
            //strScript.Append("}");

            //strScript.Append("function ShowMessage(){alert($('#txtInput').val());}");
            //strScript.Append("$('#txtInput').val('Hello World !!!');");
            ////strScript.Append("$('#btnClick').click();");

            //strScript.Append("var targetNode = document.getElementById('btnClick');");
            //strScript.Append("triggerMouseEvent (targetNode, 'mouseover');");
            //strScript.Append("triggerMouseEvent (targetNode, 'mousedown');");
            //strScript.Append("triggerMouseEvent (targetNode, 'mouseup');");
            //strScript.Append("triggerMouseEvent (targetNode, 'click');");

            //browser.ExecuteScriptAsync(strScript.ToString());

            //var a = browser.SendTextById("email-input-login", "hieu");
            //var b = browser.SendTextById("passw-input-login", "1");
            //var c = browser.InitEventClick();
            //var d = browser.SendClickById("btnLogin");
            //var f = browser.SendClickByClassName("option-site");

            if (curStep < numStep)
            {
                Action<ChromiumWebBrowser> action = lstSteps[curStep];
                action(browser);
            }
            curStep++;
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

            browser.FrameLoadStart -= Browser_FrameLoadStart;
            browser.FrameLoadEnd -= Browser_FrameLoadEnd;
         
            browser.FrameLoadStart += Browser_FrameLoadStart;
            browser.FrameLoadEnd += Browser_FrameLoadEnd;

            //lstSteps.Clear();
            //lstSteps.Add(new Action<ChromiumWebBrowser>((_browser) =>
            //{
            //}));
            //lstSteps.Add(new Action<ChromiumWebBrowser>((_browser) =>
            //{
            //    _browser.InitMouseHandle();
            //    _browser.SendTextById("email-input-login", "hieu");
            //    _browser.SendTextById("passw-input-login", "1");
            //    _browser.SendMouseHandleById(Define.MOUSE_HANDLE.click, "btnLogin");
            //}));
            //lstSteps.Add(new Action<ChromiumWebBrowser>((_browser) =>
            //{
            //    _browser.InitMouseHandle();
            //    _browser.SendMouseHandleByClassName(Define.MOUSE_HANDLE.click, "option-site");
            //}));
            //lstSteps.Add(new Action<ChromiumWebBrowser>((_browser) =>
            //{
            //    _browser.InitMouseHandle();
            //    _browser.SendMouseHandle(Define.MOUSE_HANDLE.click, "li[id=a3846f09-54c6-47ba-b64f-415e243f322a] img");
            //}));
            //lstSteps.Add(new Action<ChromiumWebBrowser>((_browser) =>
            //{
            //    _browser.InitMouseHandle();
            //    _browser.SendMouseHandleById(Define.MOUSE_HANDLE.mousemove, "new_obj_control");
            //    _browser.SendMouseHandleById(Define.MOUSE_HANDLE.mouseover, "new_obj_control");
            //    _browser.SendMouseHandleById(Define.MOUSE_HANDLE.click, "create_new_obj_addressbox");
            //}));
            //lstSteps.Add(new Action<ChromiumWebBrowser>((_browser) =>
            //{
            //    _browser.InitMouseHandlePoint();
            //    _browser.SendMouseHandle(Define.MOUSE_HANDLE.mousedown, 300, 300);
            //    _browser.SendMouseHandle(Define.MOUSE_HANDLE.mousemove, 600, 600);
            //    _browser.SendMouseHandle(Define.MOUSE_HANDLE.mouseup, 600, 600);
            //}));
            //lstSteps.Add(new Action<ChromiumWebBrowser>((_browser) =>
            //{
            //    _browser.InitMouseHandlePoint();
            //    _browser.SendMouseHandle(Define.MOUSE_HANDLE.click, 450, 450);
            //    _browser.SendMouseHandle(Define.MOUSE_HANDLE.click, 450, 450);
            //}));
            //lstSteps.Add(new Action<ChromiumWebBrowser>((_browser) =>
            //{
            //    _browser.InitMouseHandle();
            //    _browser.SendMouseHandleById(Define.MOUSE_HANDLE.click, "rBtnDirection_horizontal_addressbox");
            //}));

            //curStep = 0;
            //numStep = lstSteps.Count;
        }

        private void BtnInsertData_Click(object sender, EventArgs e)
        {
            frmInsertData frm = new frmInsertData();
            frm.ResendData = new frmInsertData.SendData(new Action<List<Action<ChromiumWebBrowser>>>((_lstSteps) =>
            {
                curStep = 0;
                numStep = _lstSteps.Count;
                lstSteps = _lstSteps;
                InitBrowser();
            }));
            frm.ShowDialog(this);
        }
    }
}
