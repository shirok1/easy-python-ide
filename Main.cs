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

namespace EasyPythonIde
{
    public partial class Main : Form
    {
        public bool CurrentFileChanged = true;
        public string CurrentFileName = "未命名.py";
        public string CurrentFilePath = "未命名.py";
        public string PythonPath = "";
        public int TabSpaceCount = 2;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            string tmpPyPath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "\\python\\python.exe";
            if (File.Exists(tmpPyPath))
            {
                MessageBox.Show("已成功检测到目录下同捆Python解释器");
                PythonPath = tmpPyPath;
            }
            else
            {
                MessageBox.Show("未检测到同捆Python解释器，将会尝试使用系统自带版本");
                PythonPath = "python.exe";
            }
        }

        private void updateCaption()
        {
            this.Text = CurrentFileName + (CurrentFileChanged ? "(已修改) - " : " - ") + "EasyPython";
        }
        
        private void updateStat()
        {
            int line,column;
            cursorPosition(out line,out column);
            labelCount.Text=$"第{line}行，第{column}列";
        }

        private void cursorPosition(out int line, out int column)
        {
            /*  得到光标行第一个字符的索引，
             *  即从第1个字符开始到光标行的第1个字符索引*/
            int index = richCodeBox.GetFirstCharIndexOfCurrentLine();
            /*得到光标行的行号,第1行从0开始计算，习惯上我们是从1开始计算，所以+1。 */
            line = richCodeBox.GetLineFromCharIndex(index) + 1;
            /*  SelectionStart得到光标所在位置的索引
             *  再减去
             *  当前行第一个字符的索引
             *  = 光标所在的列数(从0开始)  */
            column = richCodeBox.SelectionStart - index + 1;
            // MessageBox.Show(string.Format("第：{0}行 {1}列", line.ToString(), column.ToString()));
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
            // this.cursorPosition();
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
                MessageBox.Show("请先保存脚本文件");
                return;
            }

            // MessageBox.Show(richCodeBox.Font.ToString());
            // richCodeBox.Font=new Font("Consolas",14);
            // MessageBox.Show(richCodeBox.Font.ToString());
            string programPath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            Program.Execute(PythonPath + " " + CurrentFilePath);
            // Program.Execute("echo ass");
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            var pyReader = new StreamReader(openFileDialog.FileName, Encoding.UTF8);
            richCodeBox.Text = pyReader.ReadToEnd();
            pyReader.Close();
            richCodeBox.Font = new Font("Consolas", 12);
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
                    // MessageBox.Show("按下了tab");
                    richCodeBox.SelectedText = new StringBuilder().Append(' ',TabSpaceCount).ToString();
                    // MessageBox.Show(key.IsInputKey.ToString());
                    // key.
                    break;
                case Keys.Enter: //Enter
                    key.SuppressKeyPress = true;
                    key.Handled = true;
                    // MessageBox.Show("按下了回车");
                    // richCodeBox.SelectedText="\n";
                    // MessageBox.Show();
                    string lastLine = richCodeBox.Text.Substring(richCodeBox.GetFirstCharIndexOfCurrentLine(),
                        richCodeBox.SelectionStart - richCodeBox.GetFirstCharIndexOfCurrentLine());
                    StringBuilder spaceBuilder = new StringBuilder();
                    spaceBuilder.Append('\n');
                    spaceBuilder.Append(' ', (lastLine.Length - lastLine.TrimStart().Length));
                    if (lastLine.Trim().EndsWith(":"))
                    {
                        spaceBuilder.Append(' ',TabSpaceCount);
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