using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            if (!System.IO.File.Exists(Program.Profile.BundlePythonPath)) radioButtonSettingsInterpreterBundled.Enabled = false;
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

            textBoxSettingsInterpreterCustomPath.Text = Program.Profile.PythonPath;
            textBoxSettingsInterpreterCustomPath.Enabled = radioButtonSettingsInterpreterCustomized.Checked;
            buttonSettingsInterpreterBrowser.Enabled = radioButtonSettingsInterpreterCustomized.Checked;
        }

        private void numericUpDownSettingsEditorTabWidth_ValueChanged(object sender, EventArgs e)
        {
            Program.Profile.TabSpaceCount = (short) numericUpDownSettingsEditorTabWidth.Value;
        }

        private void linkLabelGithubRepo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabelSettingsAboutGithubRepo.Links[0].LinkData = Resources.UrlGithubRepo;
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

        private void buttonSettingsEditorFont_Click(object sender, EventArgs e)
        {
            fontDialogEditor.Font = (Font) Program.Profile.EditorFont;
            if (fontDialogEditor.ShowDialog() == DialogResult.OK)
            {
                Program.Profile.EditorFont = fontDialogEditor.Font;
            }
        }

        private void buttonSettingsInterpreterBrowser_Click(object sender, EventArgs e)
        {
            openPythonInterpreterBrowser.FileName = textBoxSettingsInterpreterCustomPath.Text;
            if (openPythonInterpreterBrowser.ShowDialog() == DialogResult.OK)
            {
                Program.Profile.CustomPythonPath = openPythonInterpreterBrowser.FileName;
                textBoxSettingsInterpreterCustomPath.Text = openPythonInterpreterBrowser.FileName;
            }
        }

        private void radioButtonSettingsInterpreterBundled_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSettingsInterpreterBundled.Enabled)
            {
                Program.Profile.InterpreterType=Program.Profile.PythonInterpreterType.Bundled;
            }
        }

        private void radioButtonSettingsInterpreterSystem_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSettingsInterpreterSystem.Enabled)
            {
                Program.Profile.InterpreterType=Program.Profile.PythonInterpreterType.System;
            }
        }

        private void radioButtonSettingsInterpreterCustomized_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSettingsInterpreterCustomized.Enabled)
            {
                Program.Profile.InterpreterType=Program.Profile.PythonInterpreterType.Customized;
            }
            textBoxSettingsInterpreterCustomPath.Enabled = radioButtonSettingsInterpreterCustomized.Checked;
            buttonSettingsInterpreterBrowser.Enabled = radioButtonSettingsInterpreterCustomized.Checked;
        }

        private void buttonSettingsCleanProfile_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(Resources.ProfilePath))
            {
                System.IO.File.Delete(Resources.ProfilePath);
            }else
            {
                buttonSettingsCleanProfile.Text = "配置文件不存在……";
            }
        }

        private void buttonSettingsSavingEditor_Click(object sender, EventArgs e)
        {
            Program.Profile.ProfileWrite();
        }

        private void buttonSettingsSavingInterpreter_Click(object sender, EventArgs e)
        {
                        Program.Profile.ProfileWrite();

        }
    }
}