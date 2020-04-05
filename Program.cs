using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        internal static void Execute(string command, bool pause=true)
        {
            if (command is null)
            {
                MessageBox.Show("无法执行空命令");
                return;
            }

            var process = new Process();
            var startInfo = new ProcessStartInfo();
            // string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            // startInfo.CurrentFileName=path+"\\python\\python.exe";
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C \""+command+"\""+(pause?"&&pause":"");
            process.StartInfo = startInfo;
            try
            {
                if (process.Start()) //开始进程 
                {
                    process.WaitForExit(); //这里无限等待进程结束 

                    // MessageBox.Show(process.StandardOutput.ReadToEnd());
                    // output = process.StandardOutput.ReadToEnd(); //读取进程的输出 
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