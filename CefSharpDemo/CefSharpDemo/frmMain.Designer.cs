namespace CefSharpDemo
{
    partial class frmMain
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
            this.btnDevTools = new System.Windows.Forms.Button();
            this.tpBrowser = new System.Windows.Forms.TableLayoutPanel();
            this.tpMain = new System.Windows.Forms.TableLayoutPanel();
            this.btnGetHTML = new System.Windows.Forms.Button();
            this.barPercent = new System.Windows.Forms.ProgressBar();
            this.tpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDevTools
            // 
            this.btnDevTools.Location = new System.Drawing.Point(781, 3);
            this.btnDevTools.Name = "btnDevTools";
            this.btnDevTools.Size = new System.Drawing.Size(100, 25);
            this.btnDevTools.TabIndex = 0;
            this.btnDevTools.Text = "DevTools";
            this.btnDevTools.UseVisualStyleBackColor = true;
            // 
            // tpBrowser
            // 
            this.tpBrowser.ColumnCount = 1;
            this.tpBrowser.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tpBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpBrowser.Location = new System.Drawing.Point(3, 3);
            this.tpBrowser.Name = "tpBrowser";
            this.tpBrowser.RowCount = 1;
            this.tpMain.SetRowSpan(this.tpBrowser, 3);
            this.tpBrowser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tpBrowser.Size = new System.Drawing.Size(772, 376);
            this.tpBrowser.TabIndex = 1;
            // 
            // tpMain
            // 
            this.tpMain.ColumnCount = 2;
            this.tpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpMain.Controls.Add(this.tpBrowser, 0, 0);
            this.tpMain.Controls.Add(this.btnDevTools, 1, 0);
            this.tpMain.Controls.Add(this.btnGetHTML, 1, 1);
            this.tpMain.Controls.Add(this.barPercent, 0, 3);
            this.tpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpMain.Location = new System.Drawing.Point(0, 0);
            this.tpMain.Name = "tpMain";
            this.tpMain.RowCount = 4;
            this.tpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpMain.Size = new System.Drawing.Size(884, 411);
            this.tpMain.TabIndex = 0;
            // 
            // btnGetHTML
            // 
            this.btnGetHTML.Location = new System.Drawing.Point(781, 34);
            this.btnGetHTML.Name = "btnGetHTML";
            this.btnGetHTML.Size = new System.Drawing.Size(100, 25);
            this.btnGetHTML.TabIndex = 2;
            this.btnGetHTML.Text = "Get HTML";
            this.btnGetHTML.UseVisualStyleBackColor = true;
            // 
            // barPercent
            // 
            this.tpMain.SetColumnSpan(this.barPercent, 2);
            this.barPercent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.barPercent.Location = new System.Drawing.Point(3, 385);
            this.barPercent.Name = "barPercent";
            this.barPercent.Size = new System.Drawing.Size(878, 23);
            this.barPercent.Step = 1;
            this.barPercent.TabIndex = 3;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 411);
            this.Controls.Add(this.tpMain);
            this.Name = "frmMain";
            this.Text = "CefSharp Demo Application";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tpMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnDevTools;
        private System.Windows.Forms.TableLayoutPanel tpBrowser;
        private System.Windows.Forms.TableLayoutPanel tpMain;
        private System.Windows.Forms.Button btnGetHTML;
        private System.Windows.Forms.ProgressBar barPercent;
    }
}

