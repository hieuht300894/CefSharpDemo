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
        public delegate void SendData(string Url, List<ActionData> lstSteps);
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
            List<ActionData> lstSteps = new List<ActionData>();

            foreach (Control ctrGroup in fpBody.Controls)
            {
                if (ctrGroup is frmGroupHandle)
                {
                    List<Control> lstControls = ((frmGroupHandle)ctrGroup).GetChildControl();
                    ActionData action = new ActionData();
                    action.Actions = new List<Action<ChromiumWebBrowser>>();

                    foreach (Control ctrControl in lstControls)
                    {
                        if (!(ctrControl is frmMouseHandle) && !(ctrControl is frmInputHandle)) continue;

                        if (ctrControl is frmMouseHandle)
                        {
                            frmMouseHandle frm = ctrControl as frmMouseHandle;
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
                                    action.Actions.Add(new Action<ChromiumWebBrowser>((_browser) =>
                                    {
                                        _browser.InitMouseHandlePoint();
                                        _browser.SendMouseHandle(Define.Click, iX, iY);
                                        _browser.SendMouseHandle(Define.Click, iX, iY);
                                    }));
                                }
                                else
                                {
                                    action.Actions.Add(new Action<ChromiumWebBrowser>((_browser) =>
                                    {
                                        _browser.InitMouseHandlePoint();
                                        _browser.SendMouseHandle(strHandle, iX, iY);
                                    }));
                                }
                            }
                            else
                            {
                                if (strHandle.Equals(Define.DblClick))
                                {
                                    action.Actions.Add(new Action<ChromiumWebBrowser>((_browser) =>
                                    {
                                        _browser.InitMouseHandle();
                                        _browser.SendMouseHandle(Define.Click, strQuery);
                                        _browser.SendMouseHandle(Define.Click, strQuery);
                                    }));
                                }
                                else
                                {
                                    action.Actions.Add(new Action<ChromiumWebBrowser>((_browser) =>
                                    {
                                        _browser.InitMouseHandle();
                                        _browser.SendMouseHandle(strHandle, strQuery);
                                    }));
                                }
                            }
                        }
                        else if (ctrControl is frmInputHandle)
                        {
                            frmInputHandle frm = ctrControl as frmInputHandle;
                            string strValue;
                            string strQuery;
                            frm.GetData(out strQuery, out strValue);

                            action.Actions.Add(new Action<ChromiumWebBrowser>((_browser) =>
                            {
                                _browser.SendText(strQuery, strValue);
                            }));
                        }
                    }

                    if (action.Actions.Count > 0)
                        lstSteps.Add(action);
                }
            }

            ResendData?.Invoke(txtUrl.Text.Trim(), lstSteps);
        }
        private void BtnInput_Click(object sender, EventArgs e)
        {
            InsertInputControl(new frmInputHandle());
        }
        private void BtnMouse_Click(object sender, EventArgs e)
        {
            InsertMouseControl(new frmMouseHandle());
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

        void InitEvent()
        {
            btnMouse.Click -= BtnMouse_Click;
            btnInput.Click -= BtnInput_Click;
            btnDone.Click -= BtnDone_Click;
            btnLoad.Click -= BtnLoad_Click;
            btnSave.Click -= BtnSave_Click;
            btnGroup.Click -= BtnGroup_Click;

            btnMouse.Click += BtnMouse_Click;
            btnInput.Click += BtnInput_Click;
            btnDone.Click += BtnDone_Click;
            btnLoad.Click += BtnLoad_Click;
            btnSave.Click += BtnSave_Click;
            btnGroup.Click += BtnGroup_Click;
        }
        void LoadFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = ".xml|*.xml";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                LoadData(dialog.FileName);
                btnDone.Select();
            }
        }
        void SaveFile()
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = ".xml|*.xml";
                dialog.FileName = $"{DateTime.Now.ToString("yyyyMMdd-hhmmss-ttt")}";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    SaveData(dialog.FileName);
                    btnDone.Select();
                }
            }
            else
            {
                SaveData(fileName);
                btnDone.Select();
            }
        }
        void LoadData(string fileName)
        {
            id = 0;
            this.fileName = fileName;
            txtUrl.ResetText();
            fpBody.Controls.Clear();

            if (!System.IO.File.Exists(fileName))
                return;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);
            XmlNode xmlPage = xmlDoc.SelectSingleNode($"/{Define.Page}");

            /*Load Url*/
            if (xmlPage.Attributes[Define.Url] != null)
                txtUrl.Text = xmlPage.Attributes[Define.Url].Value;

            /*Load XML*/
            XmlNodeList xmlGroups = xmlPage.SelectNodes($"{Define.Group}");
            foreach (XmlNode xmlGroup in xmlGroups)
            {
                XmlNodeList xmlControls = xmlGroup.SelectNodes($"{Define.Control}");
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

                        InsertInputControl(new frmInputHandle(query, value));
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

                        InsertMouseControl(new frmMouseHandle(handle, query, isPosition, posX, posY));
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

                /*Save Url*/
                if (xmlPage.Attributes[Define.Url] == null)
                    xmlPage.Attributes.Append(xmlDoc.CreateAttribute(Define.Url));

                xmlPage.Attributes[Define.Url].Value = txtUrl.Text.Trim();

                /*Save XML*/
                foreach (Control ctrGroup in fpBody.Controls)
                {
                    #region Group
                    if (ctrGroup is frmGroupHandle)
                    {
                        XmlElement xmlGroup = xmlDoc.CreateElement(Define.Group);
                        List<Control> lstControls = ((frmGroupHandle)ctrGroup).GetChildControl();

                        foreach (Control ctrControl in lstControls)
                        {
                            if (ctrControl is frmMouseHandle)
                            {
                                frmMouseHandle frm = ctrControl as frmMouseHandle;
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
                            else if (ctrControl is frmInputHandle)
                            {
                                frmInputHandle frm = ctrControl as frmInputHandle;
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
        void InsertMouseControl(frmMouseHandle frm)
        {
            if (frmGroup == null || fpBody.Controls[frmGroup.Name] == null)
                InsertGroupControl();

            frm.Name = $"{id}";
            frm.Text = $"Mouse {id}";
            frm.Show();

            frmGroup.InsertControl(frm);
            id++;
        }
        void InsertInputControl(frmInputHandle frm)
        {
            if (frmGroup == null || fpBody.Controls[frmGroup.Name] == null)
                InsertGroupControl();

            frm.Name = $"{id}";
            frm.Text = $"Input {id}";
            frm.Show();

            frmGroup.InsertControl(frm);
            id++;
        }
        void InsertGroupControl()
        {
            frmGroup = new frmGroupHandle();
            frmGroup.Name = $"{id}";
            frmGroup.Text = $"Group {id}";
            frmGroup.ReloadData = new frmGroupHandle.LoadData((_frm) => { frmGroup = _frm; });
            frmGroup.Show();

            fpBody.Controls.Add(frmGroup);
            id++;
        }
        void GroupControl()
        {

        }
    }
}
