using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;
using EasyPythonIde.Properties;

namespace EasyPythonIde
{
    public partial class Main : Form
    {
        private readonly StringBuilder _statLabelBuilder = new StringBuilder();//仅供行数统计使用
        private int _statLine, _statColumn, _statTotalLine;//仅供行数统计使用
        public bool CurrentFileChanged = true;//当前文件是否已被更改
        public string CurrentFileName = Resources.DefaultFileName;//当前操作的文件的名称
        public string CurrentFilePath = Resources.DefaultFileName;//当前操作的文件的路径

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            richCodeBox.Font = Program.Profile.EditorFont;
            updateCaption();
            updateMenuRunTempRun();
            Program.Profile.ChangeCaption += updateCaption;
            Program.Profile.ChangeFont += updateFont; //注册字体更新事件
            Program.Profile.ChangeTempRun += updateMenuRunTempRun; //注册菜单上的“临时运行”的更新事件
        }

        private void updateCaption()
        {
            Text = CurrentFileName +
                   (CurrentFileChanged ? Resources.CaptionJoin_Edited : Resources.CaptionJoin_Unedited) +
                   Resources.ProgramName;
            if (Program.Profile.TempRun) Text = Resources.CaptionJoin_TempRun + Resources.ProgramName;
        }

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
            var index = richCodeBox.GetFirstCharIndexOfCurrentLine();
            line = richCodeBox.GetLineFromCharIndex(index) + 1;
            column = richCodeBox.SelectionStart - index + 1;
            totalLine = richCodeBox.GetLineFromCharIndex(richCodeBox.TextLength) + 1;
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
            if (Program.Profile.TempRun) //开启了不保存运行的功能
            {
                var tempFilePath = Path.GetTempFileName();
                var pyWriter = new StreamWriter(tempFilePath, false);
                pyWriter.Write(richCodeBox.Text);
                pyWriter.Close();
                Program.Execute("\"" + Program.Profile.PythonPath + "\"", "\"" + tempFilePath + "\"",
                    Resources.RunCmdPython_Title);
                return;
            }

            if (CurrentFileChanged) //当前文件未保存
            {
                var result = MessageBox.Show(Resources.SaveBeforeRun,
                    Resources.SaveBeforeRun_Caption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (result)
                {
                    case DialogResult.Yes:
                        saveFileDialog.FileName = CurrentFileName;
                        var saveResult = saveFileDialog.ShowDialog();
                        if (saveResult != DialogResult.OK) return;
                        break;
                    case DialogResult.No: //实际上也不需要做什么
                        break;
                    case DialogResult.Cancel:
                        return;
                }
            }

            // MessageBox.Show(Program.Profile.PythonPath);
            Program.Execute("\"" + Program.Profile.PythonPath + "\"", "\"" + CurrentFilePath + "\"",
                Resources.RunCmdPython_Title);
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            var pyReader = new StreamReader(openFileDialog.FileName, Encoding.UTF8);
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
            var pyWriter = new StreamWriter(saveFileDialog.FileName, false);
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
                var result = MessageBox.Show(Resources.SaveBeforeExit,
                    Resources.SaveBeforeExit_Caption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (result)
                {
                    case DialogResult.Yes:
                        saveFileDialog.FileName = CurrentFileName;
                        var saveResult = saveFileDialog.ShowDialog();
                        if (saveResult != DialogResult.OK) closingEvent.Cancel = true;

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

        private void richCodeBox_KeyDown(object sender, KeyEventArgs key) //处理各种按键逻辑
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
                    var lastLine = richCodeBox.Text.Substring(richCodeBox.GetFirstCharIndexOfCurrentLine(),
                        richCodeBox.SelectionStart - richCodeBox.GetFirstCharIndexOfCurrentLine());
                    var spaceBuilder = new StringBuilder();
                    spaceBuilder.Append('\n');
                    spaceBuilder.Append(' ', lastLine.Length - lastLine.TrimStart().Length);
                    if (lastLine.Trim().EndsWith(":")) spaceBuilder.Append(' ', Program.Profile.TabSpaceCount);

                    richCodeBox.SelectedText = spaceBuilder.ToString();
                    break;
            }
        }
    }
}