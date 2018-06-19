using CefSharp.WinForms;
using CefSharpDemo.BLL;
using CefSharpDemo.General;
using CefSharpDemo.UserControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CefSharpDemo.GUI
{
    public partial class frmInsertData : frmBase
    {
        public delegate void SendData(List<Action<ChromiumWebBrowser>> lstSteps);
        public SendData ResendData;

        public frmInsertData()
        {
            InitializeComponent();
        }

        protected override void FrmBase_Load(object sender, EventArgs e)
        {
            fpBody.Controls.Clear();

            InitEvent();
        }
        protected override void FrmBase_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void BtnDone_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            List<Action<ChromiumWebBrowser>> lstSteps = new List<Action<ChromiumWebBrowser>>();
            lstSteps.Clear();
            lstSteps.Add(new Action<ChromiumWebBrowser>((_browser) =>
            {
            }));
            lstSteps.Add(new Action<ChromiumWebBrowser>((_browser) =>
            {
                _browser.InitMouseHandle();
                _browser.SendTextById("email-input-login", "hieu");
                _browser.SendTextById("passw-input-login", "1");
                _browser.SendMouseHandleById(Define.MOUSE_HANDLE.click, "btnLogin");
            }));
            lstSteps.Add(new Action<ChromiumWebBrowser>((_browser) =>
            {
                _browser.InitMouseHandle();
                _browser.SendMouseHandleByClassName(Define.MOUSE_HANDLE.click, "option-site");
            }));
            lstSteps.Add(new Action<ChromiumWebBrowser>((_browser) =>
            {
                _browser.InitMouseHandle();
                _browser.SendMouseHandle(Define.MOUSE_HANDLE.click, "li[id=a3846f09-54c6-47ba-b64f-415e243f322a] img");
            }));
            lstSteps.Add(new Action<ChromiumWebBrowser>((_browser) =>
            {
                _browser.InitMouseHandle();
                _browser.SendMouseHandleById(Define.MOUSE_HANDLE.mousemove, "new_obj_control");
                _browser.SendMouseHandleById(Define.MOUSE_HANDLE.mouseover, "new_obj_control");
                _browser.SendMouseHandleById(Define.MOUSE_HANDLE.click, "create_new_obj_addressbox");
            }));
            lstSteps.Add(new Action<ChromiumWebBrowser>((_browser) =>
            {
                _browser.InitMouseHandlePoint();
                _browser.SendMouseHandle(Define.MOUSE_HANDLE.mousedown, 300, 300);
                _browser.SendMouseHandle(Define.MOUSE_HANDLE.mousemove, 600, 600);
                _browser.SendMouseHandle(Define.MOUSE_HANDLE.mouseup, 600, 600);
            }));
            lstSteps.Add(new Action<ChromiumWebBrowser>((_browser) =>
            {
                _browser.InitMouseHandlePoint();
                _browser.SendMouseHandle(Define.MOUSE_HANDLE.click, 450, 450);
                _browser.SendMouseHandle(Define.MOUSE_HANDLE.click, 450, 450);
            }));
            lstSteps.Add(new Action<ChromiumWebBrowser>((_browser) =>
            {
                _browser.InitMouseHandle();
                _browser.SendMouseHandleById(Define.MOUSE_HANDLE.click, "rBtnDirection_horizontal_addressbox");
            }));
            ResendData?.Invoke(lstSteps);
        }
        private void BtnInput_Click(object sender, EventArgs e)
        {
        }
        private void BtnMouse_Click(object sender, EventArgs e)
        {
            frmMouseHandle frm = new frmMouseHandle();
            frm.Text = (fpBody.Controls.Count + 1).ToString();
            frm.Show();

            fpBody.Controls.Add(frm);
        }

        void InitEvent()
        {
            btnMouse.Click -= BtnMouse_Click;
            btnInput.Click -= BtnInput_Click;
            btnDone.Click -= BtnDone_Click;

            btnMouse.Click += BtnMouse_Click;
            btnInput.Click += BtnInput_Click;
            btnDone.Click += BtnDone_Click;
        }
    }
}
