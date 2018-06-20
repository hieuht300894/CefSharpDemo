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
        int id = 0;

        public frmInsertData()
        {
            InitializeComponent();
        }

        protected override void FrmBase_Load(object sender, EventArgs e)
        {
            LoadData();
            InitEvent();
        }
        protected override void FrmBase_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void BtnDone_Click(object sender, EventArgs e)
        {
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

            //DialogResult = DialogResult.OK;
            List<ActionData> lstSteps = new List<ActionData>();
            lstSteps.Add(new ActionData()
            {
                Action = new Action<ChromiumWebBrowser>((_browser) => { })
            });

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
                                    var result1 = _browser.SendMouseHandle(Define.Click, iX, iY);
                                    var result2 = _browser.SendMouseHandle(Define.Click, iX, iY);
                                })
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
                                    var result = _browser.SendMouseHandle(strHandle, iX, iY);
                                })
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
                                    var result1 = _browser.SendMouseHandle(Define.Click, strQuery);
                                    var result2 = _browser.SendMouseHandle(Define.Click, strQuery);
                                })
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
                                    var result = _browser.SendMouseHandle(strHandle, strQuery);
                                })
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
                            var result = _browser.SendText(strQuery, strValue);
                        })
                    });
                }
            }

            ResendData?.Invoke(lstSteps);
        }
        private void BtnInput_Click(object sender, EventArgs e)
        {
            frmInputHandle frm = new frmInputHandle();
            frm.Name = $"{id}";
            frm.Text = $"Input {id}";
            frm.Show();

            fpBody.Controls.Add(frm);
            id++;
        }
        private void BtnMouse_Click(object sender, EventArgs e)
        {
            frmMouseHandle frm = new frmMouseHandle();
            frm.Name = $"{id}";
            frm.Text = $"Mouse {id}";
            frm.Show();

            fpBody.Controls.Add(frm);
            id++;
        }
        private void BtnLoad_Click(object sender, EventArgs e)
        {
            if (fpBody.Controls.Count > 0 && this.showConfirm(Caption: "Data is edited. Do you save it?"))
                SaveData();
            LoadFile();
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        void InitEvent()
        {
            btnMouse.Click -= BtnMouse_Click;
            btnInput.Click -= BtnInput_Click;
            btnDone.Click -= BtnDone_Click;
            btnLoad.Click -= BtnLoad_Click;
            btnSave.Click -= BtnSave_Click;

            btnMouse.Click += BtnMouse_Click;
            btnInput.Click += BtnInput_Click;
            btnDone.Click += BtnDone_Click;
            btnLoad.Click += BtnLoad_Click;
            btnSave.Click += BtnSave_Click;
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
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = ".xml|*.xml";
            dialog.FileName = $"{DateTime.Now.ToString("yyyyMMdd-hhmmss")}";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SaveData(dialog.FileName);
            }
        }
        void LoadData(string fileName = "")
        {
            id = 0;
            fpBody.Controls.Clear();

            if (!System.IO.File.Exists(fileName))
                return;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);
            XmlNode xmlRoot = xmlDoc.SelectSingleNode($"/{Define.Root}");
            XmlNodeList xmlSteps = xmlDoc.SelectNodes($"/{Define.Root}/{Define.Step}");
            foreach (XmlNode xmlStep in xmlSteps)
            {
                string type = string.Empty;

                if (xmlStep.Attributes[Define.Type] != null)
                    type = xmlStep.Attributes[Define.Type].Value;

                if (type.ToLower().Equals(Define.Input.ToLower()))
                {
                    string query = string.Empty;
                    string value = string.Empty;

                    if (xmlStep.Attributes[Define.Query] != null)
                        query = xmlStep.Attributes[Define.Query].Value;
                    if (xmlStep.Attributes[Define.Value] != null)
                        value = xmlStep.Attributes[Define.Value].Value;

                    frmInputHandle frm = new frmInputHandle(query, value);
                    frm.Name = $"{id}";
                    frm.Text = $"Input {id}";
                    frm.Show();

                    fpBody.Controls.Add(frm);
                    id++;
                }
                else if (type.ToLower().Equals(Define.Mouse.ToLower()))
                {
                    string handle = string.Empty;
                    string query = string.Empty;
                    bool isPosition = false;
                    int posX = 0;
                    int posY = 0;

                    if (xmlStep.Attributes[Define.Handle] != null)
                        handle = xmlStep.Attributes[Define.Handle].Value;
                    if (xmlStep.Attributes[Define.Query] != null)
                        query = xmlStep.Attributes[Define.Query].Value;
                    if (xmlStep.Attributes[Define.IsPosition] != null)
                        bool.TryParse(xmlStep.Attributes[Define.IsPosition].Value, out isPosition);
                    if (xmlStep.Attributes[Define.PositionX] != null)
                        int.TryParse(xmlStep.Attributes[Define.PositionX].Value, out posX);
                    if (xmlStep.Attributes[Define.PositionY] != null)
                        int.TryParse(xmlStep.Attributes[Define.PositionY].Value, out posY);

                    frmMouseHandle frm = new frmMouseHandle(handle, query, isPosition, posX, posY);
                    frm.Name = $"{id}";
                    frm.Text = $"Mouse {id}";
                    frm.Show();

                    fpBody.Controls.Add(frm);
                    id++;
                }
            }
        }
        void SaveData(string fileName = "")
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();

                if (System.IO.File.Exists(fileName))
                    xmlDoc.Load(fileName);
                else
                    xmlDoc.InitDocument();

                XmlNode xmlRoot = xmlDoc.SelectSingleNode($"/{Define.Root}");
                xmlRoot.RemoveAll();

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
                            XmlElement xmlStep = xmlDoc.CreateElement(Define.Step);
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
                                xmlStep.Attributes.Append(xmlAttr);
                            });
                            xmlRoot.AppendChild(xmlStep);
                        }
                        else
                        {
                            XmlElement xmlStep = xmlDoc.CreateElement(Define.Step);
                            Dictionary<string, string> attrs = new Dictionary<string, string>();
                            attrs.Add(Define.Type, Define.Mouse);
                            attrs.Add(Define.Handle, strHandle.ToLower());
                            attrs.Add(Define.Query, strQuery);
                            attrs.ToList().ForEach(x =>
                            {
                                XmlAttribute xmlAttr = xmlDoc.CreateAttribute(x.Key);
                                xmlAttr.Value = x.Value;
                                xmlStep.Attributes.Append(xmlAttr);
                            });
                            xmlRoot.AppendChild(xmlStep);
                        }
                    }
                    else if (ctr is frmInputHandle)
                    {
                        frmInputHandle frm = ctr as frmInputHandle;
                        string strValue;
                        string strQuery;
                        frm.GetData(out strQuery, out strValue);

                        XmlElement xmlStep = xmlDoc.CreateElement(Define.Step);
                        Dictionary<string, string> attrs = new Dictionary<string, string>();
                        attrs.Add(Define.Type, Define.Input);
                        attrs.Add(Define.Query, strQuery);
                        attrs.Add(Define.Value, strValue);
                        attrs.ToList().ForEach(x =>
                        {
                            XmlAttribute xmlAttr = xmlDoc.CreateAttribute(x.Key);
                            xmlAttr.Value = x.Value;
                            xmlStep.Attributes.Append(xmlAttr);
                        });
                        xmlRoot.AppendChild(xmlStep);
                    }
                }

                xmlDoc.Save(fileName);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
