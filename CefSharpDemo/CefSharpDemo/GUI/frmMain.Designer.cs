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
            this.tpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnGetHTML = new System.Windows.Forms.Button();
            this.btnClick = new System.Windows.Forms.Button();
            this.tpBrowser = new System.Windows.Forms.TableLayoutPanel();
            this.btnInsertData = new System.Windows.Forms.Button();
            this.tpMain.SuspendLayout();
            this.tpButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDevTools
            // 
            this.btnDevTools.Location = new System.Drawing.Point(3, 3);
            this.btnDevTools.Name = "btnDevTools";
            this.btnDevTools.Size = new System.Drawing.Size(100, 25);
            this.btnDevTools.TabIndex = 0;
            this.btnDevTools.Text = "DevTools";
            this.btnDevTools.UseVisualStyleBackColor = true;
            // 
            // tpMain
            // 
            this.tpMain.ColumnCount = 1;
            this.tpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpMain.Controls.Add(this.tpButtons, 0, 0);
            this.tpMain.Controls.Add(this.tpBrowser, 0, 1);
            this.tpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpMain.Location = new System.Drawing.Point(0, 0);
            this.tpMain.Name = "tpMain";
            this.tpMain.RowCount = 2;
            this.tpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpMain.Size = new System.Drawing.Size(884, 411);
            this.tpMain.TabIndex = 0;
            // 
            // tpButtons
            // 
            this.tpButtons.AutoScroll = true;
            this.tpButtons.ColumnCount = 5;
            this.tpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 357F));
            this.tpButtons.Controls.Add(this.btnGetHTML, 1, 0);
            this.tpButtons.Controls.Add(this.btnDevTools, 0, 0);
            this.tpButtons.Controls.Add(this.btnClick, 2, 0);
            this.tpButtons.Controls.Add(this.btnInsertData, 3, 0);
            this.tpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpButtons.Location = new System.Drawing.Point(3, 3);
            this.tpButtons.Name = "tpButtons";
            this.tpButtons.RowCount = 1;
            this.tpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpButtons.Size = new System.Drawing.Size(878, 33);
            this.tpButtons.TabIndex = 3;
            // 
            // btnGetHTML
            // 
            this.btnGetHTML.Location = new System.Drawing.Point(109, 3);
            this.btnGetHTML.Name = "btnGetHTML";
            this.btnGetHTML.Size = new System.Drawing.Size(100, 25);
            this.btnGetHTML.TabIndex = 2;
            this.btnGetHTML.Text = "Get HTML";
            this.btnGetHTML.UseVisualStyleBackColor = true;
            // 
            // btnClick
            // 
            this.btnClick.Location = new System.Drawing.Point(215, 3);
            this.btnClick.Name = "btnClick";
            this.btnClick.Size = new System.Drawing.Size(100, 25);
            this.btnClick.TabIndex = 3;
            this.btnClick.Text = "Click";
            this.btnClick.UseVisualStyleBackColor = true;
            // 
            // tpBrowser
            // 
            this.tpBrowser.ColumnCount = 1;
            this.tpBrowser.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tpBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpBrowser.Location = new System.Drawing.Point(3, 42);
            this.tpBrowser.Name = "tpBrowser";
            this.tpBrowser.RowCount = 1;
            this.tpBrowser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tpBrowser.Size = new System.Drawing.Size(878, 366);
            this.tpBrowser.TabIndex = 4;
            // 
            // btnInsertData
            // 
            this.btnInsertData.Location = new System.Drawing.Point(321, 3);
            this.btnInsertData.Name = "btnInsertData";
            this.btnInsertData.Size = new System.Drawing.Size(100, 25);
            this.btnInsertData.TabIndex = 4;
            this.btnInsertData.Text = "Insert Data";
            this.btnInsertData.UseVisualStyleBackColor = true;
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
            this.tpButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnDevTools;
        private System.Windows.Forms.TableLayoutPanel tpMain;
        private System.Windows.Forms.Button btnGetHTML;
        private System.Windows.Forms.TableLayoutPanel tpButtons;
        private System.Windows.Forms.TableLayoutPanel tpBrowser;
        private System.Windows.Forms.Button btnClick;
        private System.Windows.Forms.Button btnInsertData;
    }
}

