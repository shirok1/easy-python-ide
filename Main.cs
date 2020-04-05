using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyPythonIde.Properties;

namespace EasyPythonIde
{
    public partial class Main : Form
    {
        public bool CurrentFileChanged = true;
        public string CurrentFileName = Resources.DefaultFileName;
        public string CurrentFilePath = Resources.DefaultFileName;
        public string programPath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
        public string PythonPath = "";
        public int TabSpaceCount = 2;
        public Font EditorFont = new Font("Consolas", 12f);

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            string tmpPyPath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\python\\python.exe";
            if (File.Exists(tmpPyPath))
            {
                MessageBox.Show(Resources.BundlePython_Found,
                    Resources.BundlePython_MessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                PythonPath = tmpPyPath;
            }
            else
            {
                MessageBox.Show(Resources.BundlePyhton_NotFound,
                    Resources.BundlePython_MessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                PythonPath = "python.exe";
            }

            richCodeBox.Font = EditorFont;
        }

        private void updateCaption()
        {
            this.Text = CurrentFileName +
                        (CurrentFileChanged ? Resources.CaptionJoin_Edited : Resources.CaptionJoin_Unedited) +
                        Resources.ProgramName;
        }
        
        StringBuilder _stat_labelBuilder = new StringBuilder();
        int _stat_line, _stat_column, _stat_totalLine;
        private void updateStat()
        {
            cursorPosition(out _stat_line, out _stat_column, out _stat_totalLine);
            _stat_labelBuilder.Append(Resources.StatisticLabel_pt1);
            _stat_labelBuilder.Append(_stat_line);
            _stat_labelBuilder.Append(Resources.StatisticLabel_pt2);
            _stat_labelBuilder.Append(_stat_column);
            _stat_labelBuilder.Append(Resources.StatisticLabel_pt3);
            _stat_labelBuilder.Append(_stat_totalLine);
            _stat_labelBuilder.Append(Resources.StatisticLabel_pt4);
            labelCount.Text = _stat_labelBuilder.ToString();
        }

        private void cursorPosition(out int line, out int column, out int totalLine)
        {
            // 以下代码来自互联网
            int index = richCodeBox.GetFirstCharIndexOfCurrentLine();
            line = richCodeBox.GetLineFromCharIndex(index) + 1;
            column = richCodeBox.SelectionStart - index + 1;
            totalLine = this.richCodeBox.GetLineFromCharIndex(this.richCodeBox.TextLength) + 1;
        }


        private void richCodeBox_TextChanged(object sender, EventArgs e)
        {
            if (CurrentFileChanged == false)
            {
                CurrentFileChanged = true;
                updateCaption();
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = CurrentFileName;
            saveFileDialog.ShowDialog();
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            if (CurrentFileChanged)
            {
                DialogResult result = MessageBox.Show(Resources.SaveBeforeRun,
                    Resources.SaveBeforeRun_Caption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (result)
                {
                    case DialogResult.Yes:
                        saveFileDialog.FileName = CurrentFileName;
                        DialogResult saveResult = saveFileDialog.ShowDialog();
                        if (saveResult != DialogResult.OK) return;
                        break;
                    case DialogResult.No: //实际上也不需要做什么
                        break;
                    case DialogResult.Cancel:
                        return;
                }
            }

            Program.Execute(PythonPath + " " + CurrentFilePath, Resources.RunCmdPython_Title);
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            var pyReader = new StreamReader(openFileDialog.FileName, Encoding.UTF8);
            richCodeBox.Text = pyReader.ReadToEnd();
            pyReader.Close();
            richCodeBox.Font = EditorFont;
            CurrentFileChanged = false;
            CurrentFileName = openFileDialog.SafeFileName;
            CurrentFilePath = openFileDialog.FileName;
            updateCaption();
        }

        private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            var pyWriter = new StreamWriter(saveFileDialog.FileName, false);
            pyWriter.Write(richCodeBox.Text);
            pyWriter.Close();
            CurrentFileChanged = false;
            CurrentFileName = saveFileDialog.FileName.Split('\\')[saveFileDialog.FileName.Split('\\').Length - 1];
            CurrentFilePath = saveFileDialog.FileName;
            updateCaption();
        }


        private void richCodeBox_KeyDown(object sender, KeyEventArgs key)
        {
            switch (key.KeyCode)
            {
                case Keys.Tab: //Tab
                    key.SuppressKeyPress = true;
                    key.Handled = true;
                    richCodeBox.SelectedText = new StringBuilder().Append(' ', TabSpaceCount).ToString();
                    break;
                case Keys.Enter: //Enter
                    key.SuppressKeyPress = true;
                    key.Handled = true;
                    string lastLine = richCodeBox.Text.Substring(richCodeBox.GetFirstCharIndexOfCurrentLine(),
                        richCodeBox.SelectionStart - richCodeBox.GetFirstCharIndexOfCurrentLine());
                    StringBuilder spaceBuilder = new StringBuilder();
                    spaceBuilder.Append('\n');
                    spaceBuilder.Append(' ', (lastLine.Length - lastLine.TrimStart().Length));
                    if (lastLine.Trim().EndsWith(":"))
                    {
                        spaceBuilder.Append(' ', TabSpaceCount);
                    }

                    richCodeBox.SelectedText = spaceBuilder.ToString();
                    // richCodeBox.SelectedText+="\n";
                    break;
                // case (char)
            }

            updateStat();
        }

        private void richCodeBox_MouseDown(object sender, MouseEventArgs e)
        {
            updateStat();
        }
    }
}