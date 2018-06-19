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
    public partial class frmMouseHandle : frmBase
    {
        public frmMouseHandle()
        {
            InitializeComponent();
            TopLevel = false;
        }

        protected override void FrmBase_Load(object sender, EventArgs e)
        {
            cbbHandle.Items.AddRange(new string[] { "Click", "MouseDown", "MouseUp", "MouseOver", "MouseMove", "MouseOut" });
            chkIsPosition.Checked = true;

            chkIsPosition.CheckedChanged -= ChkIsPosition_CheckedChanged;
            chkIsPosition.CheckedChanged += ChkIsPosition_CheckedChanged;
        }
        private void ChkIsPosition_CheckedChanged(object sender, EventArgs e)
        {
            numX.Enabled = chkIsPosition.Checked;
            numY.Enabled = chkIsPosition.Checked;
        }

        public void GetData(out string strHandle, out string strQuery, out bool isPosition, out int iX, out int iY)
        {
            strHandle = cbbHandle.Text.Trim();
            strQuery = txtQuery.Text.Trim();
            isPosition = chkIsPosition.Checked;
            iX = Convert.ToInt32(numX.Value);
            iY = Convert.ToInt32(numY.Value);
        }
    }
}
