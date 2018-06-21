using CefSharp.WinForms;
using CefSharpDemo.BLL;
using CefSharpDemo.General;
using CefSharpDemo.Model;
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
using System.Xml;

namespace CefSharpDemo.GUI
{
    public partial class frmInsertData : frmBase
    {
        public delegate void SendData(List<ActionData> lstSteps);
        public SendData ResendData;

        frmGroupHandle frmGroup;
        ChromiumWebBrowser Browser;
        int id = 0;
        string fileName = string.Empty;

        public frmInsertData()
        {
            InitializeComponent();
        }
        public frmInsertData(ChromiumWebBrowser Browser)
        {
            InitializeComponent();
            this.Browser = Browser;
        }

        protected override void FrmBase_Load(object sender, EventArgs e)
        {
            LoadData(string.Empty);
            InitEvent();
        }
        protected override void FrmBase_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void BtnDone_Click(object sender, EventArgs e)
        {
            #region Code 1
            //DialogResult = DialogResult.OK;

            //List<Action<ChromiumWebBrowser>> lstSteps = new List<Action<ChromiumWebBrowser>>();
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
            //ResendData?.Invoke(lstSteps);
            #endregion

            List<ActionData> lstSteps = new List<ActionData>();

            foreach (Control ctr in fpBody.Controls)
            {
                if (ctr is frmMouseHandle)
                {
                    frmMouseHandle frm = ctr as frmMouseHandle;
                    string strHandle;
                    string strQuery;
                    bool isPosition;
                    int iX;
                    int iY;
                    frm.GetData(out strHandle, out strQuery, out isPosition, out iX, out iY);

                    if (isPosition)
                    {
                        if (strHandle.Equals(Define.DblClick))
                        {
                            lstSteps.Add(new ActionData()
                            {
                                Control = frm,
                                Action = new Action<ChromiumWebBrowser>((_browser) =>
                               {
                                   _browser.InitMouseHandlePoint();
                                   _browser.SendMouseHandle(Define.Click, iX, iY);
                                   _browser.SendMouseHandle(Define.Click, iX, iY);
                               }),
                            });
                        }
                        else
                        {
                            lstSteps.Add(new ActionData()
                            {
                                Control = frm,
                                Action = new Action<ChromiumWebBrowser>((_browser) =>
                                {
                                    _browser.InitMouseHandlePoint();
                                    _browser.SendMouseHandle(strHandle, iX, iY);
                                }),
                            });
                        }
                    }
                    else
                    {
                        if (strHandle.Equals(Define.DblClick))
                        {
                            lstSteps.Add(new ActionData()
                            {
                                Control = frm,
                                Action = new Action<ChromiumWebBrowser>((_browser) =>
                               {
                                   _browser.InitMouseHandle();
                                   _browser.SendMouseHandle(Define.Click, strQuery);
                                   _browser.SendMouseHandle(Define.Click, strQuery);
                               }),
                            });
                        }
                        else
                        {
                            lstSteps.Add(new ActionData()
                            {
                                Control = frm,
                                Action = new Action<ChromiumWebBrowser>((_browser) =>
                               {
                                   _browser.InitMouseHandle();
                                   _browser.SendMouseHandle(strHandle, strQuery);
                               }),
                            });
                        }
                    }
                }
                else if (ctr is frmInputHandle)
                {
                    frmInputHandle frm = ctr as frmInputHandle;
                    string strValue;
                    string strQuery;
                    frm.GetData(out strQuery, out strValue);

                    lstSteps.Add(new ActionData()
                    {
                        Control = frm,
                        Action = new Action<ChromiumWebBrowser>((_browser) =>
                       {
                           _browser.SendText(strQuery, strValue);
                       })
                    });
                }
            }

            ResendData?.Invoke(lstSteps);
        }
        private void BtnInput_Click(object sender, EventArgs e)
        {
            InsertInputControl();
        }
        private void BtnMouse_Click(object sender, EventArgs e)
        {
            InsertMouseControl();
        }
        private void BtnLoad_Click(object sender, EventArgs e)
        {
            if (fpBody.Controls.Count > 0 && this.showConfirm(Caption: "Data is edited. Do you save it?"))
                SaveData(fileName);
            LoadFile();
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveFile();
        }
        private void BtnGroup_Click(object sender, EventArgs e)
        {
            InsertGroupControl();
        }
        private void CMenuStripItem_Mouse_Click(object sender, EventArgs e)
        {
            InsertMouseControl();
        }
        private void CMenuStripItem_Input_Click(object sender, EventArgs e)
        {
            InsertInputControl();
        }
        private void CMenuStripItem_Group_Click(object sender, EventArgs e)
        {
            GroupControl();
        }

        void InitEvent()
        {
            btnMouse.Click -= BtnMouse_Click;
            btnInput.Click -= BtnInput_Click;
            btnDone.Click -= BtnDone_Click;
            btnLoad.Click -= BtnLoad_Click;
            btnSave.Click -= BtnSave_Click;
            btnGroup.Click -= BtnGroup_Click;
            cMenuStripItem_Group.Click -= CMenuStripItem_Group_Click;
            cMenuStripItem_Input.Click -= CMenuStripItem_Input_Click;
            cMenuStripItem_Mouse.Click -= CMenuStripItem_Mouse_Click;

            btnMouse.Click += BtnMouse_Click;
            btnInput.Click += BtnInput_Click;
            btnDone.Click += BtnDone_Click;
            btnLoad.Click += BtnLoad_Click;
            btnSave.Click += BtnSave_Click;
            btnGroup.Click += BtnGroup_Click;
            cMenuStripItem_Group.Click += CMenuStripItem_Group_Click;
            cMenuStripItem_Input.Click += CMenuStripItem_Input_Click;
            cMenuStripItem_Mouse.Click += CMenuStripItem_Mouse_Click;
        }
        void LoadFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = ".xml|*.xml";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                LoadData(dialog.FileName);
            }
        }
        void SaveFile()
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = ".xml|*.xml";
                dialog.FileName = $"{DateTime.Now.ToString("yyyyMMdd-hhmmss")}";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    SaveData(dialog.FileName);
                }
            }
            else
            {
                SaveData(fileName);
            }

        }
        void LoadData(string fileName)
        {
            id = 0;
            this.fileName = fileName;
            fpBody.Controls.Clear();

            if (!System.IO.File.Exists(fileName))
                return;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);
            XmlNode xmlPage = xmlDoc.SelectSingleNode($"/{Define.Page}");
            XmlNodeList xmlGroups = xmlDoc.SelectNodes($"/{Define.Page}/{Define.Group}");
            foreach (XmlNode xmlGroup in xmlGroups)
            {
                XmlNodeList xmlControls = xmlDoc.SelectNodes($"/{Define.Page}/{Define.Group}/{Define.Control}");
                InsertGroupControl();

                foreach (XmlNode xmlControl in xmlControls)
                {
                    string type = string.Empty;

                    if (xmlControl.Attributes[Define.Type] != null)
                        type = xmlControl.Attributes[Define.Type].Value;

                    if (type.ToLower().Equals(Define.Input.ToLower()))
                    {
                        string query = string.Empty;
                        string value = string.Empty;

                        if (xmlControl.Attributes[Define.Query] != null)
                            query = xmlControl.Attributes[Define.Query].Value;
                        if (xmlControl.Attributes[Define.Value] != null)
                            value = xmlControl.Attributes[Define.Value].Value;

                        frmInputHandle frm = new frmInputHandle(query, value);
                        frm.Name = $"{id}";
                        frm.Text = $"Input {id}";
                        frm.Show();

                        frmGroup.Controls.Add(frm);
                        id++;
                    }
                    else if (type.ToLower().Equals(Define.Mouse.ToLower()))
                    {
                        string handle = string.Empty;
                        string query = string.Empty;
                        bool isPosition = false;
                        int posX = 0;
                        int posY = 0;

                        if (xmlControl.Attributes[Define.Handle] != null)
                            handle = xmlControl.Attributes[Define.Handle].Value;
                        if (xmlControl.Attributes[Define.Query] != null)
                            query = xmlControl.Attributes[Define.Query].Value;
                        if (xmlControl.Attributes[Define.IsPosition] != null)
                            bool.TryParse(xmlControl.Attributes[Define.IsPosition].Value, out isPosition);
                        if (xmlControl.Attributes[Define.PositionX] != null)
                            int.TryParse(xmlControl.Attributes[Define.PositionX].Value, out posX);
                        if (xmlControl.Attributes[Define.PositionY] != null)
                            int.TryParse(xmlControl.Attributes[Define.PositionY].Value, out posY);

                        frmMouseHandle frm = new frmMouseHandle(handle, query, isPosition, posX, posY);
                        frm.Name = $"{id}";
                        frm.Text = $"Mouse {id}";
                        frm.Show();

                        frmGroup.Controls.Add(frm);
                        id++;
                    }
                }
            }
        }
        void SaveData(string fileName)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();

                this.fileName = fileName;
                if (System.IO.File.Exists(fileName))
                    xmlDoc.Load(fileName);
                else
                    xmlDoc.InitDocument();

                XmlNode xmlPage = xmlDoc.SelectSingleNode($"/{Define.Page}");
                xmlPage.RemoveAll();

                foreach (Control ctr in fpBody.Controls)
                {
                    #region Group
                    if (ctr is frmGroupHandle)
                    {
                        XmlElement xmlGroup = xmlDoc.CreateElement(Define.Group);

                        foreach (Control ctrGroup in ctr.Controls)
                        {
                            if (ctrGroup is frmMouseHandle)
                            {
                                frmMouseHandle frm = ctrGroup as frmMouseHandle;
                                string strHandle;
                                string strQuery;
                                bool isPosition;
                                int iX;
                                int iY;
                                frm.GetData(out strHandle, out strQuery, out isPosition, out iX, out iY);

                                if (isPosition)
                                {
                                    XmlElement xmlControl = xmlDoc.CreateElement(Define.Control);
                                    Dictionary<string, string> attrs = new Dictionary<string, string>();
                                    attrs.Add(Define.Type, Define.Mouse);
                                    attrs.Add(Define.Handle, strHandle.ToLower());
                                    attrs.Add(Define.Query, strQuery);
                                    attrs.Add(Define.IsPosition, isPosition.ToString());
                                    attrs.Add(Define.PositionX, iX.ToString());
                                    attrs.Add(Define.PositionY, iY.ToString());
                                    attrs.ToList().ForEach(x =>
                                    {
                                        XmlAttribute xmlAttr = xmlDoc.CreateAttribute(x.Key);
                                        xmlAttr.Value = x.Value;
                                        xmlControl.Attributes.Append(xmlAttr);
                                    });
                                    xmlGroup.AppendChild(xmlControl);
                                }
                                else
                                {
                                    XmlElement xmlControl = xmlDoc.CreateElement(Define.Control);
                                    Dictionary<string, string> attrs = new Dictionary<string, string>();
                                    attrs.Add(Define.Type, Define.Mouse);
                                    attrs.Add(Define.Handle, strHandle.ToLower());
                                    attrs.Add(Define.Query, strQuery);
                                    attrs.ToList().ForEach(x =>
                                    {
                                        XmlAttribute xmlAttr = xmlDoc.CreateAttribute(x.Key);
                                        xmlAttr.Value = x.Value;
                                        xmlControl.Attributes.Append(xmlAttr);
                                    });
                                    xmlGroup.AppendChild(xmlControl);
                                }
                            }
                            else if (ctrGroup is frmInputHandle)
                            {
                                frmInputHandle frm = ctrGroup as frmInputHandle;
                                string strValue;
                                string strQuery;
                                frm.GetData(out strQuery, out strValue);

                                XmlElement xmlControl = xmlDoc.CreateElement(Define.Control);
                                Dictionary<string, string> attrs = new Dictionary<string, string>();
                                attrs.Add(Define.Type, Define.Input);
                                attrs.Add(Define.Query, strQuery);
                                attrs.Add(Define.Value, strValue);
                                attrs.ToList().ForEach(x =>
                                {
                                    XmlAttribute xmlAttr = xmlDoc.CreateAttribute(x.Key);
                                    xmlAttr.Value = x.Value;
                                    xmlControl.Attributes.Append(xmlAttr);
                                });
                                xmlGroup.AppendChild(xmlControl);
                            }
                        }

                        xmlPage.AppendChild(xmlGroup);
                    }
                    #endregion   
                }

                xmlDoc.Save(fileName);
            }
            catch (Exception ex)
            {
                this.showError(Caption: ex.Message);
            }
        }
        void InsertMouseControl()
        {
            if (frmGroup == null || fpBody.Controls[frmGroup.Name] == null)
                InsertGroupControl();

            frmMouseHandle frm = new frmMouseHandle();
            frm.Name = $"{id}";
            frm.Text = $"Mouse {id}";
            frm.ContextMenuStrip = cMenuStripGroup;
            frm.Show();

            frmGroup.InsertControl(frm);
            id++;
        }
        void InsertInputControl()
        {
            if (frmGroup == null || fpBody.Controls[frmGroup.Name] == null)
                InsertGroupControl();

            frmInputHandle frm = new frmInputHandle();
            frm.Name = $"{id}";
            frm.Text = $"Input {id}";
            frm.ContextMenuStrip = cMenuStripGroup;
            frm.Show();

            frmGroup.InsertControl(frm);
            id++;
        }
        void InsertGroupControl()
        {
            frmGroup = new frmGroupHandle();
            frmGroup.Name = $"{id}";
            frmGroup.Text = $"Group {id}";
            frmGroup.Show();

            fpBody.Controls.Add(frmGroup);
            id++;
        }
        void GroupControl()
        {

        }
    }
}
