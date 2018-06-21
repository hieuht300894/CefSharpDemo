using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CefSharpDemo.UserControl
{
    public partial class frmGroupHandle : frmBase
    {
        public frmGroupHandle()
        {
            InitializeComponent();
            TopLevel = false;
        }

        protected override void FrmBase_Load(object sender, EventArgs e)
        {
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
            foreach(Control ctr in fpMain.Controls)
            {
                lstControls.Add(ctr);
            }
            return lstControls;
        }
    }
}
