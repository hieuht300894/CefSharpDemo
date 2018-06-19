namespace CefSharpDemo.UserControl
{
    partial class frmMouseHandle
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
            this.label3 = new System.Windows.Forms.Label();
            this.chkIsPosition = new System.Windows.Forms.CheckBox();
            this.numX = new System.Windows.Forms.NumericUpDown();
            this.numY = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.txtQuery = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbHandle = new System.Windows.Forms.ComboBox();
            this.tpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).BeginInit();
            this.SuspendLayout();
            // 
            // tpMain
            // 
            this.tpMain.ColumnCount = 6;
            this.tpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tpMain.Controls.Add(this.label3, 1, 3);
            this.tpMain.Controls.Add(this.chkIsPosition, 2, 3);
            this.tpMain.Controls.Add(this.numX, 3, 3);
            this.tpMain.Controls.Add(this.numY, 4, 3);
            this.tpMain.Controls.Add(this.label2, 1, 2);
            this.tpMain.Controls.Add(this.txtQuery, 2, 2);
            this.tpMain.Controls.Add(this.label1, 1, 1);
            this.tpMain.Controls.Add(this.cbbHandle, 2, 1);
            this.tpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpMain.Location = new System.Drawing.Point(0, 0);
            this.tpMain.Name = "tpMain";
            this.tpMain.RowCount = 5;
            this.tpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tpMain.Size = new System.Drawing.Size(304, 141);
            this.tpMain.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(23, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "Position";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkIsPosition
            // 
            this.chkIsPosition.AutoSize = true;
            this.chkIsPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkIsPosition.Location = new System.Drawing.Point(73, 99);
            this.chkIsPosition.Name = "chkIsPosition";
            this.chkIsPosition.Size = new System.Drawing.Size(15, 20);
            this.chkIsPosition.TabIndex = 3;
            this.chkIsPosition.UseVisualStyleBackColor = true;
            // 
            // numX
            // 
            this.numX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numX.Location = new System.Drawing.Point(94, 99);
            this.numX.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numX.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.numX.Name = "numX";
            this.numX.Size = new System.Drawing.Size(90, 20);
            this.numX.TabIndex = 6;
            this.numX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numY
            // 
            this.numY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numY.Location = new System.Drawing.Point(190, 99);
            this.numY.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numY.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.numY.Name = "numY";
            this.numY.Size = new System.Drawing.Size(90, 20);
            this.numY.TabIndex = 7;
            this.numY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(23, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 49);
            this.label2.TabIndex = 1;
            this.label2.Text = "Query";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtQuery
            // 
            this.tpMain.SetColumnSpan(this.txtQuery, 3);
            this.txtQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQuery.Location = new System.Drawing.Point(73, 50);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(207, 43);
            this.txtQuery.TabIndex = 5;
            this.txtQuery.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(23, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Handle";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbbHandle
            // 
            this.tpMain.SetColumnSpan(this.cbbHandle, 3);
            this.cbbHandle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbbHandle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbHandle.FormattingEnabled = true;
            this.cbbHandle.Location = new System.Drawing.Point(73, 23);
            this.cbbHandle.Name = "cbbHandle";
            this.cbbHandle.Size = new System.Drawing.Size(207, 21);
            this.cbbHandle.TabIndex = 4;
            // 
            // frmMouseHandle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 141);
            this.Controls.Add(this.tpMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMouseHandle";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.tpMain.ResumeLayout(false);
            this.tpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tpMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkIsPosition;
        private System.Windows.Forms.NumericUpDown numX;
        private System.Windows.Forms.NumericUpDown numY;
        private System.Windows.Forms.RichTextBox txtQuery;
        private System.Windows.Forms.ComboBox cbbHandle;
    }
}