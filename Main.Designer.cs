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
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonRun = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.richCodeBox = new System.Windows.Forms.RichTextBox();
            this.labelCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(-1, -1);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(75, 23);
            this.buttonOpen.TabIndex = 1;
            this.buttonOpen.Text = "打开";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(80, -1);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "保存";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(310, -1);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(75, 23);
            this.buttonRun.TabIndex = 3;
            this.buttonRun.Text = "运行";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "py";
            this.openFileDialog.Filter = "Python 脚本|*.py|所有文件|*.*";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "py";
            this.saveFileDialog.Filter = "Python 脚本|*.py|所有文件|*.*";
            this.saveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog_FileOk);
            // 
            // richCodeBox
            // 
            this.richCodeBox.AcceptsTab = true;
            this.richCodeBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richCodeBox.BulletIndent = 2;
            this.richCodeBox.EnableAutoDragDrop = true;
            this.richCodeBox.Font = new System.Drawing.Font("Consolas", 12F);
            this.richCodeBox.Location = new System.Drawing.Point(-1, 20);
            this.richCodeBox.Name = "richCodeBox";
            this.richCodeBox.Size = new System.Drawing.Size(386, 381);
            this.richCodeBox.TabIndex = 4;
            this.richCodeBox.Text = "";
            this.richCodeBox.WordWrap = false;
            this.richCodeBox.TextChanged += new System.EventHandler(this.richCodeBox_TextChanged);
            this.richCodeBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richCodeBox_KeyDown);
            this.richCodeBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.richCodeBox_MouseDown);
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(161, 4);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(0, 12);
            this.labelCount.TabIndex = 5;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 401);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.richCodeBox);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonOpen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Name = "Main";
            this.Text = "EasyPython";
            this.Load += new System.EventHandler(this.Main_Load);
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
    }
}

