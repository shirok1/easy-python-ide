using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using EasyPythonIde.Properties;

namespace EasyPythonIde
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }


        private void Settings_Load(object sender, EventArgs e)
        {
            numericUpDownSettingsEditorTabWidth.Value = Program.Profile.TabSpaceCount;
            if (!File.Exists(Program.Profile.BundlePythonPath)) radioButtonSettingsInterpreterBundled.Enabled = false;
            switch (Program.Profile.InterpreterType)
            {
                case Program.Profile.PythonInterpreterType.Bundled:
                    radioButtonSettingsInterpreterBundled.Checked = true;
                    break;
                case Program.Profile.PythonInterpreterType.System:
                    radioButtonSettingsInterpreterSystem.Checked = true;
                    break;
                case Program.Profile.PythonInterpreterType.Customized:
                    radioButtonSettingsInterpreterCustomized.Checked = true;
                    break;
            }
            //我不知道还能怎么写……
            textBoxSettingsInterpreterCustomPath.Text = Program.Profile.PythonPath;
            textBoxSettingsInterpreterCustomPath.Enabled = radioButtonSettingsInterpreterCustomized.Checked;
            buttonSettingsInterpreterBrowser.Enabled = radioButtonSettingsInterpreterCustomized.Checked;
        }

        private void numericUpDownSettingsEditorTabWidth_ValueChanged(object sender, EventArgs e)
        {
            Program.Profile.TabSpaceCount = (short) numericUpDownSettingsEditorTabWidth.Value;//实时更新配置
        }

        private void linkLabelGithubRepo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabelSettingsAboutGithubRepo.Links[0].LinkData = Resources.UrlGithubRepo;
            Process.Start(e.Link.LinkData.ToString());//打开本项目的Github仓库
        }

        private void buttonSettingsEditorFont_Click(object sender, EventArgs e)
        {
            fontDialogEditor.Font = Program.Profile.EditorFont;//将当前字体设置设为字体设置窗体的默认
            if (fontDialogEditor.ShowDialog() == DialogResult.OK) Program.Profile.EditorFont = fontDialogEditor.Font;
        }

        private void buttonSettingsInterpreterBrowser_Click(object sender, EventArgs e)
        {
            openPythonInterpreterBrowser.FileName = textBoxSettingsInterpreterCustomPath.Text;
            if (openPythonInterpreterBrowser.ShowDialog() == DialogResult.OK)
            {
                Program.Profile.CustomPythonPath = openPythonInterpreterBrowser.FileName;
                textBoxSettingsInterpreterCustomPath.Text = openPythonInterpreterBrowser.FileName;
            }//更新当前配置与路径框
        }

        private void radioButtonSettingsInterpreterBundled_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSettingsInterpreterBundled.Enabled)
                Program.Profile.InterpreterType = Program.Profile.PythonInterpreterType.Bundled;
        }

        private void radioButtonSettingsInterpreterSystem_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSettingsInterpreterSystem.Enabled)
                Program.Profile.InterpreterType = Program.Profile.PythonInterpreterType.System;
        }

        private void radioButtonSettingsInterpreterCustomized_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSettingsInterpreterCustomized.Enabled)
                Program.Profile.InterpreterType = Program.Profile.PythonInterpreterType.Customized;
            //下面同步更新解释器路径框与浏览器的启用禁用状态
            textBoxSettingsInterpreterCustomPath.Enabled = radioButtonSettingsInterpreterCustomized.Checked;
            buttonSettingsInterpreterBrowser.Enabled = radioButtonSettingsInterpreterCustomized.Checked;
        }

        private void buttonSettingsCleanProfile_Click(object sender, EventArgs e)
        {
            if (File.Exists(Resources.ProfilePath))
                File.Delete(Resources.ProfilePath);
            else//暂时硬编码,这是一个未来可能被删掉的功能
                buttonSettingsCleanProfile.Text = "配置文件不存在……";
        }

        private void buttonSettingsSavingEditor_Click(object sender, EventArgs e)
        {
            Program.Profile.ProfileWrite();//写入配置文件
        }

        private void buttonSettingsSavingInterpreter_Click(object sender, EventArgs e)
        {
            Program.Profile.ProfileWrite();//写入配置文件
        }
    }
}