using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyPythonIde.Properties;

namespace EasyPythonIde
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }

        internal static void Execute(string command, string title = null, bool pause = true)
        {
            if (command is null)
            {
                MessageBox.Show(Resources.CannotExecuteNull,
                    Resources.CannotExecuteNull_Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (title is null)
            {
                title = Resources.RunCmd_Title;
            }

            //以下代码来自互联网
            var process = new Process();
            var startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/C title " + title + "\"" + command + "\"" + (pause ? "&pause" : "")
            };
            process.StartInfo = startInfo;
            try
            {
                if (process.Start()) //开始进程 
                {
                    process.WaitForExit(); //这里无限等待进程结束 
                }
            }
            catch
            {
            }
            finally
            {
                process.Close();
            }
        }
    }
}