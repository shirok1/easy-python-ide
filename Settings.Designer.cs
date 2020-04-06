namespace EasyPythonIde
{
    partial class Settings
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
            this.tabControlSettings = new System.Windows.Forms.TabControl();
            this.settingPageEditor = new System.Windows.Forms.TabPage();
            this.buttonSettingsCleanProfile = new System.Windows.Forms.Button();
            this.buttonSettingsEditorFont = new System.Windows.Forms.Button();
            this.numericUpDownSettingsEditorTabWidth = new System.Windows.Forms.NumericUpDown();
            this.labelSettingsSavingTipsEditor = new System.Windows.Forms.Label();
            this.buttonSettingsSavingEditor = new System.Windows.Forms.Button();
            this.labelSettingsEditorTabWidth = new System.Windows.Forms.Label();
            this.settingsPageInterpreter = new System.Windows.Forms.TabPage();
            this.labelSettingsSavingTipsInterpreter = new System.Windows.Forms.Label();
            this.buttonSettingsSavingInterpreter = new System.Windows.Forms.Button();
            this.buttonSettingsInterpreterBrowser = new System.Windows.Forms.Button();
            this.textBoxSettingsInterpreterCustomPath = new System.Windows.Forms.TextBox();
            this.radioButtonSettingsInterpreterCustomized = new System.Windows.Forms.RadioButton();
            this.radioButtonSettingsInterpreterSystem = new System.Windows.Forms.RadioButton();
            this.radioButtonSettingsInterpreterBundled = new System.Windows.Forms.RadioButton();
            this.settingsPageAbout = new System.Windows.Forms.TabPage();
            this.linkLabelSettingsAboutGithubRepo = new System.Windows.Forms.LinkLabel();
            this.labelSettingsAbout2 = new System.Windows.Forms.Label();
            this.labelSettingsAbout1 = new System.Windows.Forms.Label();
            this.pictureBoxSettingsAboutAvatar = new System.Windows.Forms.PictureBox();
            this.fontDialogEditor = new System.Windows.Forms.FontDialog();
            this.openPythonInterpreterBrowser = new System.Windows.Forms.OpenFileDialog();
            this.tabControlSettings.SuspendLayout();
            this.settingPageEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSettingsEditorTabWidth)).BeginInit();
            this.settingsPageInterpreter.SuspendLayout();
            this.settingsPageAbout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSettingsAboutAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlSettings
            // 
            this.tabControlSettings.Controls.Add(this.settingPageEditor);
            this.tabControlSettings.Controls.Add(this.settingsPageInterpreter);
            this.tabControlSettings.Controls.Add(this.settingsPageAbout);
            this.tabControlSettings.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControlSettings.Location = new System.Drawing.Point(0, 0);
            this.tabControlSettings.Name = "tabControlSettings";
            this.tabControlSettings.SelectedIndex = 0;
            this.tabControlSettings.Size = new System.Drawing.Size(485, 190);
            this.tabControlSettings.TabIndex = 0;
            // 
            // settingPageEditor
            // 
            this.settingPageEditor.Controls.Add(this.buttonSettingsCleanProfile);
            this.settingPageEditor.Controls.Add(this.buttonSettingsEditorFont);
            this.settingPageEditor.Controls.Add(this.numericUpDownSettingsEditorTabWidth);
            this.settingPageEditor.Controls.Add(this.labelSettingsSavingTipsEditor);
            this.settingPageEditor.Controls.Add(this.buttonSettingsSavingEditor);
            this.settingPageEditor.Controls.Add(this.labelSettingsEditorTabWidth);
            this.settingPageEditor.Location = new System.Drawing.Point(4, 26);
            this.settingPageEditor.Name = "settingPageEditor";
            this.settingPageEditor.Size = new System.Drawing.Size(477, 160);
            this.settingPageEditor.TabIndex = 2;
            this.settingPageEditor.Text = "编辑器";
            this.settingPageEditor.UseVisualStyleBackColor = true;
            // 
            // buttonSettingsCleanProfile
            // 
            this.buttonSettingsCleanProfile.Location = new System.Drawing.Point(24, 96);
            this.buttonSettingsCleanProfile.Name = "buttonSettingsCleanProfile";
            this.buttonSettingsCleanProfile.Size = new System.Drawing.Size(427, 23);
            this.buttonSettingsCleanProfile.TabIndex = 11;
            this.buttonSettingsCleanProfile.Text = "清除配置文件";
            this.buttonSettingsCleanProfile.UseVisualStyleBackColor = true;
            this.buttonSettingsCleanProfile.Click += new System.EventHandler(this.buttonSettingsCleanProfile_Click);
            // 
            // buttonSettingsEditorFont
            // 
            this.buttonSettingsEditorFont.Location = new System.Drawing.Point(313, 7);
            this.buttonSettingsEditorFont.Name = "buttonSettingsEditorFont";
            this.buttonSettingsEditorFont.Size = new System.Drawing.Size(138, 23);
            this.buttonSettingsEditorFont.TabIndex = 10;
            this.buttonSettingsEditorFont.Text = "自定义字体...";
            this.buttonSettingsEditorFont.UseVisualStyleBackColor = true;
            this.buttonSettingsEditorFont.Click += new System.EventHandler(this.buttonSettingsEditorFont_Click);
            // 
            // numericUpDownSettingsEditorTabWidth
            // 
            this.numericUpDownSettingsEditorTabWidth.Location = new System.Drawing.Point(167, 7);
            this.numericUpDownSettingsEditorTabWidth.Name = "numericUpDownSettingsEditorTabWidth";
            this.numericUpDownSettingsEditorTabWidth.Size = new System.Drawing.Size(120, 23);
            this.numericUpDownSettingsEditorTabWidth.TabIndex = 9;
            this.numericUpDownSettingsEditorTabWidth.ValueChanged += new System.EventHandler(this.numericUpDownSettingsEditorTabWidth_ValueChanged);
            // 
            // labelSettingsSavingTipsEditor
            // 
            this.labelSettingsSavingTipsEditor.AutoSize = true;
            this.labelSettingsSavingTipsEditor.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSettingsSavingTipsEditor.Location = new System.Drawing.Point(8, 128);
            this.labelSettingsSavingTipsEditor.Name = "labelSettingsSavingTipsEditor";
            this.labelSettingsSavingTipsEditor.Size = new System.Drawing.Size(332, 17);
            this.labelSettingsSavingTipsEditor.TabIndex = 8;
            this.labelSettingsSavingTipsEditor.Text = "这里的设置会即时生效，但在按下保存前不会写入配置文件。";
            // 
            // buttonSettingsSavingEditor
            // 
            this.buttonSettingsSavingEditor.Location = new System.Drawing.Point(376, 125);
            this.buttonSettingsSavingEditor.Name = "buttonSettingsSavingEditor";
            this.buttonSettingsSavingEditor.Size = new System.Drawing.Size(75, 23);
            this.buttonSettingsSavingEditor.TabIndex = 7;
            this.buttonSettingsSavingEditor.Text = "保存";
            this.buttonSettingsSavingEditor.UseVisualStyleBackColor = true;
            this.buttonSettingsSavingEditor.Click += new System.EventHandler(this.buttonSettingsSavingEditor_Click);
            // 
            // labelSettingsEditorTabWidth
            // 
            this.labelSettingsEditorTabWidth.AutoSize = true;
            this.labelSettingsEditorTabWidth.Location = new System.Drawing.Point(8, 9);
            this.labelSettingsEditorTabWidth.Name = "labelSettingsEditorTabWidth";
            this.labelSettingsEditorTabWidth.Size = new System.Drawing.Size(153, 17);
            this.labelSettingsEditorTabWidth.TabIndex = 0;
            this.labelSettingsEditorTabWidth.Text = "按下Tab键时输入的空格数:";
            // 
            // settingsPageInterpreter
            // 
            this.settingsPageInterpreter.Controls.Add(this.labelSettingsSavingTipsInterpreter);
            this.settingsPageInterpreter.Controls.Add(this.buttonSettingsSavingInterpreter);
            this.settingsPageInterpreter.Controls.Add(this.buttonSettingsInterpreterBrowser);
            this.settingsPageInterpreter.Controls.Add(this.textBoxSettingsInterpreterCustomPath);
            this.settingsPageInterpreter.Controls.Add(this.radioButtonSettingsInterpreterCustomized);
            this.settingsPageInterpreter.Controls.Add(this.radioButtonSettingsInterpreterSystem);
            this.settingsPageInterpreter.Controls.Add(this.radioButtonSettingsInterpreterBundled);
            this.settingsPageInterpreter.Location = new System.Drawing.Point(4, 26);
            this.settingsPageInterpreter.Name = "settingsPageInterpreter";
            this.settingsPageInterpreter.Padding = new System.Windows.Forms.Padding(3);
            this.settingsPageInterpreter.Size = new System.Drawing.Size(477, 160);
            this.settingsPageInterpreter.TabIndex = 0;
            this.settingsPageInterpreter.Text = "Python解释器";
            this.settingsPageInterpreter.UseVisualStyleBackColor = true;
            // 
            // labelSettingsSavingTipsInterpreter
            // 
            this.labelSettingsSavingTipsInterpreter.AutoSize = true;
            this.labelSettingsSavingTipsInterpreter.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSettingsSavingTipsInterpreter.Location = new System.Drawing.Point(8, 128);
            this.labelSettingsSavingTipsInterpreter.Name = "labelSettingsSavingTipsInterpreter";
            this.labelSettingsSavingTipsInterpreter.Size = new System.Drawing.Size(332, 17);
            this.labelSettingsSavingTipsInterpreter.TabIndex = 6;
            this.labelSettingsSavingTipsInterpreter.Text = "这里的设置会即时生效，但在按下保存前不会写入配置文件。";
            // 
            // buttonSettingsSavingInterpreter
            // 
            this.buttonSettingsSavingInterpreter.Location = new System.Drawing.Point(376, 125);
            this.buttonSettingsSavingInterpreter.Name = "buttonSettingsSavingInterpreter";
            this.buttonSettingsSavingInterpreter.Size = new System.Drawing.Size(75, 23);
            this.buttonSettingsSavingInterpreter.TabIndex = 5;
            this.buttonSettingsSavingInterpreter.Text = "保存";
            this.buttonSettingsSavingInterpreter.UseVisualStyleBackColor = true;
            this.buttonSettingsSavingInterpreter.Click += new System.EventHandler(this.buttonSettingsSavingInterpreter_Click);
            // 
            // buttonSettingsInterpreterBrowser
            // 
            this.buttonSettingsInterpreterBrowser.Location = new System.Drawing.Point(376, 90);
            this.buttonSettingsInterpreterBrowser.Name = "buttonSettingsInterpreterBrowser";
            this.buttonSettingsInterpreterBrowser.Size = new System.Drawing.Size(75, 23);
            this.buttonSettingsInterpreterBrowser.TabIndex = 4;
            this.buttonSettingsInterpreterBrowser.Text = "浏览...";
            this.buttonSettingsInterpreterBrowser.UseVisualStyleBackColor = true;
            this.buttonSettingsInterpreterBrowser.Click += new System.EventHandler(this.buttonSettingsInterpreterBrowser_Click);
            // 
            // textBoxSettingsInterpreterCustomPath
            // 
            this.textBoxSettingsInterpreterCustomPath.Location = new System.Drawing.Point(26, 90);
            this.textBoxSettingsInterpreterCustomPath.Name = "textBoxSettingsInterpreterCustomPath";
            this.textBoxSettingsInterpreterCustomPath.Size = new System.Drawing.Size(344, 23);
            this.textBoxSettingsInterpreterCustomPath.TabIndex = 3;
            // 
            // radioButtonSettingsInterpreterCustomized
            // 
            this.radioButtonSettingsInterpreterCustomized.AutoSize = true;
            this.radioButtonSettingsInterpreterCustomized.Location = new System.Drawing.Point(9, 63);
            this.radioButtonSettingsInterpreterCustomized.Name = "radioButtonSettingsInterpreterCustomized";
            this.radioButtonSettingsInterpreterCustomized.Size = new System.Drawing.Size(173, 21);
            this.radioButtonSettingsInterpreterCustomized.TabIndex = 2;
            this.radioButtonSettingsInterpreterCustomized.Text = "使用自定义的Python解释器";
            this.radioButtonSettingsInterpreterCustomized.UseVisualStyleBackColor = true;
            this.radioButtonSettingsInterpreterCustomized.CheckedChanged += new System.EventHandler(this.radioButtonSettingsInterpreterCustomized_CheckedChanged);
            // 
            // radioButtonSettingsInterpreterSystem
            // 
            this.radioButtonSettingsInterpreterSystem.AutoSize = true;
            this.radioButtonSettingsInterpreterSystem.Location = new System.Drawing.Point(9, 35);
            this.radioButtonSettingsInterpreterSystem.Name = "radioButtonSettingsInterpreterSystem";
            this.radioButtonSettingsInterpreterSystem.Size = new System.Drawing.Size(209, 21);
            this.radioButtonSettingsInterpreterSystem.TabIndex = 1;
            this.radioButtonSettingsInterpreterSystem.Text = "使用系统中已安装的Python解释器";
            this.radioButtonSettingsInterpreterSystem.UseVisualStyleBackColor = true;
            this.radioButtonSettingsInterpreterSystem.CheckedChanged += new System.EventHandler(this.radioButtonSettingsInterpreterSystem_CheckedChanged);
            // 
            // radioButtonSettingsInterpreterBundled
            // 
            this.radioButtonSettingsInterpreterBundled.AutoSize = true;
            this.radioButtonSettingsInterpreterBundled.Checked = true;
            this.radioButtonSettingsInterpreterBundled.Location = new System.Drawing.Point(9, 7);
            this.radioButtonSettingsInterpreterBundled.Name = "radioButtonSettingsInterpreterBundled";
            this.radioButtonSettingsInterpreterBundled.Size = new System.Drawing.Size(149, 21);
            this.radioButtonSettingsInterpreterBundled.TabIndex = 0;
            this.radioButtonSettingsInterpreterBundled.TabStop = true;
            this.radioButtonSettingsInterpreterBundled.Text = "使用同捆Python解释器";
            this.radioButtonSettingsInterpreterBundled.UseVisualStyleBackColor = true;
            this.radioButtonSettingsInterpreterBundled.CheckedChanged += new System.EventHandler(this.radioButtonSettingsInterpreterBundled_CheckedChanged);
            // 
            // settingsPageAbout
            // 
            this.settingsPageAbout.Controls.Add(this.linkLabelSettingsAboutGithubRepo);
            this.settingsPageAbout.Controls.Add(this.labelSettingsAbout2);
            this.settingsPageAbout.Controls.Add(this.labelSettingsAbout1);
            this.settingsPageAbout.Controls.Add(this.pictureBoxSettingsAboutAvatar);
            this.settingsPageAbout.Location = new System.Drawing.Point(4, 26);
            this.settingsPageAbout.Name = "settingsPageAbout";
            this.settingsPageAbout.Padding = new System.Windows.Forms.Padding(3);
            this.settingsPageAbout.Size = new System.Drawing.Size(477, 160);
            this.settingsPageAbout.TabIndex = 1;
            this.settingsPageAbout.Text = "关于";
            this.settingsPageAbout.UseVisualStyleBackColor = true;
            // 
            // linkLabelSettingsAboutGithubRepo
            // 
            this.linkLabelSettingsAboutGithubRepo.AutoSize = true;
            this.linkLabelSettingsAboutGithubRepo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabelSettingsAboutGithubRepo.Location = new System.Drawing.Point(166, 139);
            this.linkLabelSettingsAboutGithubRepo.Name = "linkLabelSettingsAboutGithubRepo";
            this.linkLabelSettingsAboutGithubRepo.Size = new System.Drawing.Size(164, 17);
            this.linkLabelSettingsAboutGithubRepo.TabIndex = 3;
            this.linkLabelSettingsAboutGithubRepo.TabStop = true;
            this.linkLabelSettingsAboutGithubRepo.Text = "这是一个开放源代码的项目。";
            this.linkLabelSettingsAboutGithubRepo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelGithubRepo_LinkClicked);
            // 
            // labelSettingsAbout2
            // 
            this.labelSettingsAbout2.AutoSize = true;
            this.labelSettingsAbout2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSettingsAbout2.Location = new System.Drawing.Point(165, 38);
            this.labelSettingsAbout2.Name = "labelSettingsAbout2";
            this.labelSettingsAbout2.Size = new System.Drawing.Size(130, 21);
            this.labelSettingsAbout2.TabIndex = 2;
            this.labelSettingsAbout2.Text = "©白木重工 2020";
            // 
            // labelSettingsAbout1
            // 
            this.labelSettingsAbout1.AutoSize = true;
            this.labelSettingsAbout1.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSettingsAbout1.Location = new System.Drawing.Point(163, 7);
            this.labelSettingsAbout1.Name = "labelSettingsAbout1";
            this.labelSettingsAbout1.Size = new System.Drawing.Size(294, 31);
            this.labelSettingsAbout1.TabIndex = 1;
            this.labelSettingsAbout1.Text = "EasyPython 0.0.1 (测试版";
            // 
            // pictureBoxSettingsAboutAvatar
            // 
            this.pictureBoxSettingsAboutAvatar.Image = global::EasyPythonIde.Properties.Resources.Avatar150;
            this.pictureBoxSettingsAboutAvatar.Location = new System.Drawing.Point(6, 6);
            this.pictureBoxSettingsAboutAvatar.Name = "pictureBoxSettingsAboutAvatar";
            this.pictureBoxSettingsAboutAvatar.Size = new System.Drawing.Size(150, 150);
            this.pictureBoxSettingsAboutAvatar.TabIndex = 0;
            this.pictureBoxSettingsAboutAvatar.TabStop = false;
            // 
            // openPythonInterpreterBrowser
            // 
            this.openPythonInterpreterBrowser.FileName = "openFileDialog1";
            this.openPythonInterpreterBrowser.Filter = "Python解释器|*.exe|所有文件|*.*";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 186);
            this.Controls.Add(this.tabControlSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Settings";
            this.Text = "设置";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.tabControlSettings.ResumeLayout(false);
            this.settingPageEditor.ResumeLayout(false);
            this.settingPageEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSettingsEditorTabWidth)).EndInit();
            this.settingsPageInterpreter.ResumeLayout(false);
            this.settingsPageInterpreter.PerformLayout();
            this.settingsPageAbout.ResumeLayout(false);
            this.settingsPageAbout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSettingsAboutAvatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlSettings;
        private System.Windows.Forms.TabPage settingsPageInterpreter;
        private System.Windows.Forms.TabPage settingsPageAbout;
        private System.Windows.Forms.PictureBox pictureBoxSettingsAboutAvatar;
        private System.Windows.Forms.Label labelSettingsAbout1;
        private System.Windows.Forms.LinkLabel linkLabelSettingsAboutGithubRepo;
        private System.Windows.Forms.Label labelSettingsAbout2;
        private System.Windows.Forms.RadioButton radioButtonSettingsInterpreterCustomized;
        private System.Windows.Forms.RadioButton radioButtonSettingsInterpreterSystem;
        private System.Windows.Forms.RadioButton radioButtonSettingsInterpreterBundled;
        private System.Windows.Forms.TabPage settingPageEditor;
        private System.Windows.Forms.Button buttonSettingsInterpreterBrowser;
        private System.Windows.Forms.TextBox textBoxSettingsInterpreterCustomPath;
        private System.Windows.Forms.FontDialog fontDialogEditor;
        private System.Windows.Forms.OpenFileDialog openPythonInterpreterBrowser;
        private System.Windows.Forms.Label labelSettingsEditorTabWidth;
        private System.Windows.Forms.Label labelSettingsSavingTipsInterpreter;
        private System.Windows.Forms.Button buttonSettingsSavingInterpreter;
        private System.Windows.Forms.Label labelSettingsSavingTipsEditor;
        private System.Windows.Forms.Button buttonSettingsSavingEditor;
        private System.Windows.Forms.NumericUpDown numericUpDownSettingsEditorTabWidth;
        private System.Windows.Forms.Button buttonSettingsEditorFont;
        private System.Windows.Forms.Button buttonSettingsCleanProfile;
    }
}