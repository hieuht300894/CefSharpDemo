using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CefSharpDemo
{
    public partial class frmHTMLSource : frmBase
    {
        public frmHTMLSource()
        {
            InitializeComponent();
        }

        protected override void FrmBase_Load(object sender, EventArgs e)
        {
        }
        protected override void FrmBase_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        public void SetData(string text)
        {
            txtCode.AppendText(text ?? string.Empty);
        }
        public void ResetData()
        {
            txtCode.ResetText();
        }
    }
}
