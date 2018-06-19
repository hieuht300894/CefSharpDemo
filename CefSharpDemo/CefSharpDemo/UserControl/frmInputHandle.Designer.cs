namespace CefSharpDemo.UserControl
{
    partial class frmInputHandle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tpMain = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtQuery = new System.Windows.Forms.RichTextBox();
            this.txtValue = new System.Windows.Forms.RichTextBox();
            this.tpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tpMain
            // 
            this.tpMain.ColumnCount = 4;
            this.tpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tpMain.Controls.Add(this.label1, 1, 1);
            this.tpMain.Controls.Add(this.label2, 1, 2);
            this.tpMain.Controls.Add(this.txtQuery, 2, 1);
            this.tpMain.Controls.Add(this.txtValue, 2, 2);
            this.tpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpMain.Location = new System.Drawing.Point(0, 0);
            this.tpMain.Name = "tpMain";
            this.tpMain.RowCount = 4;
            this.tpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tpMain.Size = new System.Drawing.Size(304, 141);
            this.tpMain.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(23, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 56);
            this.label1.TabIndex = 0;
            this.label1.Text = "Query";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(23, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 56);
            this.label2.TabIndex = 1;
            this.label2.Text = "Value";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtQuery
            // 
            this.txtQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQuery.Location = new System.Drawing.Point(64, 18);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(217, 50);
            this.txtQuery.TabIndex = 2;
            this.txtQuery.Text = "";
            // 
            // txtValue
            // 
            this.txtValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtValue.Location = new System.Drawing.Point(64, 74);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(217, 50);
            this.txtValue.TabIndex = 3;
            this.txtValue.Text = "";
            // 
            // frmInputHandle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 141);
            this.Controls.Add(this.tpMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmInputHandle";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.tpMain.ResumeLayout(false);
            this.tpMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tpMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txtQuery;
        private System.Windows.Forms.RichTextBox txtValue;
    }
}