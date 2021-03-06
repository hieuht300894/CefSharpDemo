﻿namespace CefSharpDemo.GUI
{
    partial class frmInsertData
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
            this.tpHeader = new System.Windows.Forms.TableLayoutPanel();
            this.btnInput = new System.Windows.Forms.Button();
            this.btnMouse = new System.Windows.Forms.Button();
            this.btnGroup = new System.Windows.Forms.Button();
            this.txtUrl = new System.Windows.Forms.RichTextBox();
            this.tpFooter = new System.Windows.Forms.TableLayoutPanel();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.fpBody = new System.Windows.Forms.FlowLayoutPanel();
            this.tpMain.SuspendLayout();
            this.tpHeader.SuspendLayout();
            this.tpFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // tpMain
            // 
            this.tpMain.ColumnCount = 1;
            this.tpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpMain.Controls.Add(this.tpHeader, 0, 0);
            this.tpMain.Controls.Add(this.tpFooter, 0, 2);
            this.tpMain.Controls.Add(this.fpBody, 0, 1);
            this.tpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpMain.Location = new System.Drawing.Point(0, 0);
            this.tpMain.Name = "tpMain";
            this.tpMain.RowCount = 3;
            this.tpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpMain.Size = new System.Drawing.Size(884, 411);
            this.tpMain.TabIndex = 0;
            // 
            // tpHeader
            // 
            this.tpHeader.ColumnCount = 4;
            this.tpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpHeader.Controls.Add(this.btnInput, 1, 0);
            this.tpHeader.Controls.Add(this.btnMouse, 0, 0);
            this.tpHeader.Controls.Add(this.btnGroup, 2, 0);
            this.tpHeader.Controls.Add(this.txtUrl, 3, 0);
            this.tpHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpHeader.Location = new System.Drawing.Point(3, 3);
            this.tpHeader.Name = "tpHeader";
            this.tpHeader.RowCount = 1;
            this.tpHeader.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpHeader.Size = new System.Drawing.Size(878, 31);
            this.tpHeader.TabIndex = 0;
            // 
            // btnInput
            // 
            this.btnInput.Location = new System.Drawing.Point(109, 3);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(100, 25);
            this.btnInput.TabIndex = 1;
            this.btnInput.Text = "Input";
            this.btnInput.UseVisualStyleBackColor = true;
            // 
            // btnMouse
            // 
            this.btnMouse.Location = new System.Drawing.Point(3, 3);
            this.btnMouse.Name = "btnMouse";
            this.btnMouse.Size = new System.Drawing.Size(100, 25);
            this.btnMouse.TabIndex = 0;
            this.btnMouse.Text = "Mouse";
            this.btnMouse.UseVisualStyleBackColor = true;
            // 
            // btnGroup
            // 
            this.btnGroup.Location = new System.Drawing.Point(215, 3);
            this.btnGroup.Name = "btnGroup";
            this.btnGroup.Size = new System.Drawing.Size(100, 25);
            this.btnGroup.TabIndex = 2;
            this.btnGroup.Text = "Group";
            this.btnGroup.UseVisualStyleBackColor = true;
            // 
            // txtUrl
            // 
            this.txtUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUrl.Location = new System.Drawing.Point(321, 3);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(554, 25);
            this.txtUrl.TabIndex = 3;
            this.txtUrl.Text = "";
            // 
            // tpFooter
            // 
            this.tpFooter.ColumnCount = 4;
            this.tpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpFooter.Controls.Add(this.btnLoad, 1, 0);
            this.tpFooter.Controls.Add(this.btnDone, 3, 0);
            this.tpFooter.Controls.Add(this.btnSave, 2, 0);
            this.tpFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpFooter.Location = new System.Drawing.Point(3, 377);
            this.tpFooter.Name = "tpFooter";
            this.tpFooter.RowCount = 1;
            this.tpFooter.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpFooter.Size = new System.Drawing.Size(878, 31);
            this.tpFooter.TabIndex = 2;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(563, 3);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(100, 25);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(775, 3);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(100, 25);
            this.btnDone.TabIndex = 5;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(669, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 25);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // fpBody
            // 
            this.fpBody.AutoScroll = true;
            this.fpBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpBody.Location = new System.Drawing.Point(3, 40);
            this.fpBody.Name = "fpBody";
            this.fpBody.Size = new System.Drawing.Size(878, 331);
            this.fpBody.TabIndex = 3;
            // 
            // frmInsertData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 411);
            this.Controls.Add(this.tpMain);
            this.Name = "frmInsertData";
            this.Text = "Insert Data";
            this.tpMain.ResumeLayout(false);
            this.tpHeader.ResumeLayout(false);
            this.tpFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tpMain;
        private System.Windows.Forms.TableLayoutPanel tpHeader;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.Button btnMouse;
        private System.Windows.Forms.TableLayoutPanel tpFooter;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.FlowLayoutPanel fpBody;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnGroup;
        private System.Windows.Forms.RichTextBox txtUrl;
    }
}