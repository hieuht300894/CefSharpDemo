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
    public partial class frmInputHandle : frmBase
    {
        public frmInputHandle()
        {
            InitializeComponent();
            TopLevel = false;
        }

        protected override void FrmBase_Load(object sender, EventArgs e)
        {
        }

        public void GetData(out string strQuery, out string strValue)
        {
            strQuery = txtQuery.Text.Trim();
            strValue = txtValue.Text.Trim();
        }
    }
}
