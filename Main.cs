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
    public partial class Main : Form
    {
        public bool CurrentFileChanged = true;
        public string CurrentFileName = Resources.DefaultFileName;
        public string CurrentFilePath = Resources.DefaultFileName;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            richCodeBox.Font = Program.Profile.EditorFont;
            updateCaption();
            updateMenuRunTempRun();
            Program.Profile.ChangeCaption += this.updateCaption;
            Program.Profile.ChangeFont += this.updateFont;//注册字体更新事件
            Program.Profile.ChangeTempRun += this.updateMenuRunTempRun;//注册菜单上的“临时运行”的更新事件
        }

        private void updateCaption()
        {
            this.Text = CurrentFileName +
                        (CurrentFileChanged ? Resources.CaptionJoin_Edited : Resources.CaptionJoin_Unedited) +
                        Resources.ProgramName;
            if (Program.Profile.TempRun)
            {
                this.Text = Resources.CaptionJoin_TempRun + Resources.ProgramName;
            }
        }

        StringBuilder _statLabelBuilder = new StringBuilder();
        int _statLine, _statColumn, _statTotalLine;

        private void updateStat()
        {
            cursorPosition(out _statLine, out _statColumn, out _statTotalLine);
            _statLabelBuilder.Append(Resources.StatisticLabel_pt1);
            _statLabelBuilder.Append(_statLine);
            _statLabelBuilder.Append(Resources.StatisticLabel_pt2);
            _statLabelBuilder.Append(_statColumn);
            _statLabelBuilder.Append(Resources.StatisticLabel_pt3);
            _statLabelBuilder.Append(_statTotalLine);
            _statLabelBuilder.Append(Resources.StatisticLabel_pt4);
            labelCount.Text = _statLabelBuilder.ToString();
            _statLabelBuilder.Clear();
        }

        private void updateFont()
        {
            richCodeBox.Font = Program.Profile.EditorFont;
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
            if (Program.Profile.TempRun)//开启了不保存运行的功能
            {
                string tempFilePath = System.IO.Path.GetTempFileName();
                var pyWriter = new System.IO.StreamWriter(tempFilePath, false);
                pyWriter.Write(richCodeBox.Text);
                pyWriter.Close();
                Program.Execute("\""+Program.Profile.PythonPath+"\"", "\""+tempFilePath+"\"", Resources.RunCmdPython_Title);
                return;
            }
            if (CurrentFileChanged)//当前文件未保存
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
            // MessageBox.Show(Program.Profile.PythonPath);
            Program.Execute("\""+Program.Profile.PythonPath+"\"", "\""+CurrentFilePath+"\"", Resources.RunCmdPython_Title);
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            var pyReader = new System.IO.StreamReader(openFileDialog.FileName, Encoding.UTF8);
            richCodeBox.Text = pyReader.ReadToEnd();
            pyReader.Close();
            richCodeBox.Font = Program.Profile.EditorFont;
            CurrentFileChanged = false;
            CurrentFileName = openFileDialog.SafeFileName;
            CurrentFilePath = openFileDialog.FileName;
            updateCaption();
        }

        private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            var pyWriter = new System.IO.StreamWriter(saveFileDialog.FileName, false);
            pyWriter.Write(richCodeBox.Text);
            pyWriter.Close();
            CurrentFileChanged = false;
            CurrentFileName = saveFileDialog.FileName.Split('\\')[saveFileDialog.FileName.Split('\\').Length - 1];
            CurrentFilePath = saveFileDialog.FileName;
            updateCaption();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs closingEvent)
        {
            if (CurrentFileChanged)
            {
                DialogResult result = MessageBox.Show(Resources.SaveBeforeExit,
                    Resources.SaveBeforeExit_Caption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (result)
                {
                    case DialogResult.Yes:
                        saveFileDialog.FileName = CurrentFileName;
                        DialogResult saveResult = saveFileDialog.ShowDialog();
                        if (saveResult != DialogResult.OK)
                        {
                            closingEvent.Cancel = true;
                            return;
                        }

                        break;
                    case DialogResult.No:
                        break;
                    case DialogResult.Cancel:
                        closingEvent.Cancel = true;
                        return;
                }
            }
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            new Settings().Show();
        }

        private void richCodeBox_Click(object sender, EventArgs e)
        {
            updateStat();
        }

        private void menuRunTempRun_CheckedChanged(object sender, EventArgs e)
        {
            Program.Profile.TempRun = menuRunTempRun.Checked;
        }

        private void updateMenuRunTempRun()
        {
            menuRunTempRun.Checked = Program.Profile.TempRun;
        }

        private void richCodeBox_KeyUp(object sender, KeyEventArgs e)
        {
            updateStat();
        }

        private void richCodeBox_KeyDown(object sender, KeyEventArgs key)//处理各种按键逻辑
        {
            switch (key.KeyCode)
            {
                case Keys.Tab: //Tab
                    key.SuppressKeyPress = true;
                    key.Handled = true;
                    richCodeBox.SelectedText =
                        new StringBuilder().Append(' ', Program.Profile.TabSpaceCount).ToString();
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
                        spaceBuilder.Append(' ', Program.Profile.TabSpaceCount);
                    }

                    richCodeBox.SelectedText = spaceBuilder.ToString();
                    break;
            }
        }
    }
}