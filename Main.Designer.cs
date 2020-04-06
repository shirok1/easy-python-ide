using System.Drawing;

namespace EasyPythonIde
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonRun = new System.Windows.Forms.Button();
            this.menuRunOption = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuRunTempRun = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRunSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.richCodeBox = new System.Windows.Forms.RichTextBox();
            this.labelCount = new System.Windows.Forms.Label();
            this.menuRunOption.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOpen
            // 
            resources.ApplyResources(this.buttonOpen, "buttonOpen");
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonSave
            // 
            resources.ApplyResources(this.buttonSave, "buttonSave");
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonRun
            // 
            this.buttonRun.ContextMenuStrip = this.menuRunOption;
            resources.ApplyResources(this.buttonRun, "buttonRun");
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // menuRunOption
            // 
            this.menuRunOption.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuRunTempRun,
            this.menuRunSettings});
            this.menuRunOption.Name = "menuRunOption";
            resources.ApplyResources(this.menuRunOption, "menuRunOption");
            // 
            // menuRunTempRun
            // 
            this.menuRunTempRun.CheckOnClick = true;
            this.menuRunTempRun.Name = "menuRunTempRun";
            resources.ApplyResources(this.menuRunTempRun, "menuRunTempRun");
            this.menuRunTempRun.CheckedChanged += new System.EventHandler(this.menuRunTempRun_CheckedChanged);
            // 
            // menuRunSettings
            // 
            this.menuRunSettings.Name = "menuRunSettings";
            resources.ApplyResources(this.menuRunSettings, "menuRunSettings");
            this.menuRunSettings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "py";
            resources.ApplyResources(this.openFileDialog, "openFileDialog");
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "py";
            resources.ApplyResources(this.saveFileDialog, "saveFileDialog");
            this.saveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog_FileOk);
            // 
            // richCodeBox
            // 
            this.richCodeBox.AcceptsTab = true;
            this.richCodeBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.richCodeBox, "richCodeBox");
            this.richCodeBox.EnableAutoDragDrop = true;
            this.richCodeBox.Name = "richCodeBox";
            this.richCodeBox.Click += new System.EventHandler(this.richCodeBox_Click);
            this.richCodeBox.TextChanged += new System.EventHandler(this.richCodeBox_TextChanged);
            this.richCodeBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richCodeBox_KeyDown);
            this.richCodeBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.richCodeBox_KeyUp);
            // 
            // labelCount
            // 
            resources.ApplyResources(this.labelCount, "labelCount");
            this.labelCount.Name = "labelCount";
            // 
            // Main
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.richCodeBox);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonOpen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuRunOption.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.RichTextBox richCodeBox;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.ContextMenuStrip menuRunOption;
        private System.Windows.Forms.ToolStripMenuItem menuRunTempRun;
        private System.Windows.Forms.ToolStripMenuItem menuRunSettings;
    }
}

