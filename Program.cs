using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using EasyPythonIde.Properties;

namespace EasyPythonIde
{
    internal static class Program
    {
        /// <summary>
        ///     应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Profile.ProfileRead();
            Application.Run(new Main());
        }


        internal static void Execute(string command, string arg = "", string title = null, bool pause = true)
        {
            if (command is null)
            {
                MessageBox.Show(Resources.CannotExecuteNull,
                    Resources.CannotExecuteNull_Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (title is null) title = Resources.RunCmd_Title;

            //以下代码来自互联网
            var process = new Process();
            var startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/C (title " + title + ")&(" + command + " " + arg + (pause ? ")&pause" : ")")
            };
            process.StartInfo = startInfo;
            try
            {
                if (process.Start()) //开始进程 
                    process.WaitForExit(); //这里无限等待进程结束 
            }
            catch
            {
            }
            finally
            {
                process.Close();
            }
        }

        internal static class Profile
        {
            public delegate void EditorUpdateHandler();

            public enum PythonInterpreterType
            {
                Bundled = 0,
                System = 1,
                Customized = 2
            }

            public static PythonInterpreterType InterpreterType = PythonInterpreterType.Bundled;
            public static readonly string ProgramPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;

            public static readonly string BundlePythonPath = PythonPath + "python\\python.exe";
            public static string CustomPythonPath = "";
            public static short TabSpaceCount = 2;
            private static Font _editorFont = new Font("Consolas", 12f);
            private static bool _tempRun;

            public static string PythonPath
            {
                get
                {
                    switch (InterpreterType)
                    {
                        case PythonInterpreterType.Bundled:
                            return BundlePythonPath;
                        case PythonInterpreterType.System:
                            return "python.exe";
                        case PythonInterpreterType.Customized:
                            return CustomPythonPath;
                        default:
                            return "python.exe";
                    }
                }
            }

            public static bool TempRun
            {
                get => _tempRun;
                set
                {
                    if (value == _tempRun) return;
                    if (value)
                    {
                        var confirmResult = MessageBox.Show(Resources.TempRunConfirm,
                            Resources.TempRunConfirm_Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        switch (confirmResult)
                        {
                            case DialogResult.Yes:
                                _tempRun = true;
                                break;
                            case DialogResult.No:
                                _tempRun = false;
                                break;
                        }
                    }
                    else
                    {
                        _tempRun = false;
                    }

                    ChangeCaption?.Invoke(); //刷新标题
                    ChangeTempRun?.Invoke(); //刷新菜单
                }
            }

            public static Font EditorFont
            {
                get => _editorFont;
                set
                {
                    _editorFont = value;
                    ChangeFont?.Invoke();
                }
            }

            public static event EditorUpdateHandler ChangeCaption;

            public static event EditorUpdateHandler ChangeTempRun;

            internal static void DetectPythonInterpreter()
            {
                if (File.Exists(BundlePythonPath))
                {
                    MessageBox.Show(Resources.BundlePython_Found,
                        Resources.BundlePython_MessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    InterpreterType = PythonInterpreterType.Bundled;
                }
                else
                {
                    MessageBox.Show(Resources.BundlePyhton_NotFound,
                        Resources.BundlePython_MessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    InterpreterType = PythonInterpreterType.System;
                }
            }

            public static event EditorUpdateHandler ChangeFont;


            internal static void ProfileRead()
            {
                if (File.Exists(Resources.ProfilePath))
                {
                    //从配置文件读取设置
                    var xmlSerializer = new XmlSerializer(typeof(ProfileData));
                    var xmlReader = new FileStream(Resources.ProfilePath, FileMode.Open, FileAccess.Read);
                    try
                    {
                        var tmpData = (ProfileData) xmlSerializer.Deserialize(xmlReader);
                        CustomPythonPath = tmpData.CustomPythonPath;
                        EditorFont = new Font(tmpData.EditorFontName, tmpData.EditorFontSize,
                            tmpData.EditorFontStyle, tmpData.EditorFontUnit);
                        InterpreterType = (PythonInterpreterType) tmpData.InterpreterType;
                        TabSpaceCount = tmpData.TabSpaceCount;
                        TempRun = tmpData.TempRun;
                    }
                    catch (InvalidOperationException e)
                    {
                        var profileDeleteConfirm = MessageBox.Show(Resources.ProfileReadError,
                            Resources.ProfileReadError_Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        switch (profileDeleteConfirm)
                        {
                            case DialogResult.Yes:
                                xmlReader.Close();
                                File.Delete(Resources.ProfilePath);
                                break;
                            case DialogResult.No:
                                Environment.Exit(0);
                                return;
                        }

                        DetectPythonInterpreter();
                    }
                    finally
                    {
                        xmlReader.Close();
                    }
                }
                else
                {
                    DetectPythonInterpreter();
                }
            }

            internal static void ProfileWrite()
            {
                var xmlSerializer = new XmlSerializer(typeof(ProfileData));
                var xmlWriter = new FileStream(Resources.ProfilePath, FileMode.Create, FileAccess.Write);
                try
                {
                    xmlSerializer.Serialize(xmlWriter, new ProfileData
                    {
                        CustomPythonPath = CustomPythonPath,
                        EditorFontName = EditorFont.FontFamily.Name,
                        EditorFontSize = EditorFont.Size,
                        EditorFontStyle = EditorFont.Style,
                        EditorFontUnit = EditorFont.Unit,
                        InterpreterType = (int) InterpreterType,
                        TabSpaceCount = TabSpaceCount,
                        TempRun = TempRun
                    });
                }
                catch (InvalidOperationException e)
                {
                    xmlWriter.Close();
                    MessageBox.Show(Resources.ProfileWriteError, Resources.ProfileWriteError_Caption +
                                                                 Resources.ProfilePath, MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                finally
                {
                    xmlWriter.Close();
                }
            }
        }
    }
}