using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CefSharpDemo.UserControl
{
    public partial class frmGroupHandle : frmBase
    {
        public delegate void LoadData(frmGroupHandle frm);
        public LoadData ReloadData;
        const int WM_NCRBUTTONDOWN = 0x00A4;
        const int WM_NCRBUTTONUP = 0x00A5;
        const int WM_NCRBUTTONDBLCLK = 0x00A6;

        public frmGroupHandle()
        {
            InitializeComponent();
            TopLevel = false;
        }

        protected override void FrmBase_Load(object sender, EventArgs e)
        {
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg.Equals(WM_NCRBUTTONDOWN))
            {
                ReloadData?.Invoke(this);
            }
        }

        public void InsertControl(Control ctr)
        {
            fpMain.Controls.Add(ctr);
        }
        public int GetCountChildControl()
        {
            return fpMain.Controls.Count;
        }
        public List<Control> GetChildControl()
        {
            List<Control> lstControls = new List<Control>();
            foreach (Control ctr in fpMain.Controls)
            {
                lstControls.Add(ctr);
            }
            return lstControls;
        }
    }
}
