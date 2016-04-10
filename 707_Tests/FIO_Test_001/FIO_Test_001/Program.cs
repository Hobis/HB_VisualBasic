using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace FIO_Test_001
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            HB_Folder.Start
            (
                null,
                @"D:\01_Flash",
                @"C:\Users\Hobis-PC\Desktop\_Test4\02_PurposePath",
                true, true
            );
        }


    }


    public static class HB_Folder
    {
        // ::
        public static void Start(ProgressBar progressBar, string targetPath, string purposePath, bool bSub, bool bShortcut)
        {
            if (_th == null)
            {
                _progressBar = progressBar;
                _targetPath = targetPath;
                _purposePath = purposePath;
                _bSub = bSub;
                _bShortcut = bShortcut;

                _th = new Thread(new ThreadStart(p_Start));
                _th.Start();
            }
        }

        private static Thread _th = null;

        private static ProgressBar _progressBar = null;
        private static string _targetPath = null;
        private static string _purposePath = null;
        private static bool _bSub = false;
        private static bool _bShortcut = false;
        private static List<string> _fps = null;



        // ::
        private static void p_Start()
        {
            p_AddFilePaths(_targetPath);
            if (_fps != null)
            {
                if (_progressBar != null)
                {
                    _progressBar.Minimum = 0;
                    _progressBar.Maximum = _fps.Count;
                    _progressBar.Step = 1;
                    _progressBar.Value = 0;
                }                

                p_CopyFiles();
            }
        }

        // ::
        public static void Stop()
        {
            _th = null;
        }

        // ::
        private static void p_WorkClear()
        {
            if (_th != null)
            {
                _progressBar = null;
                _targetPath = null;
                _purposePath = null;
                _bSub = false;
                _bShortcut = false;
                if (_fps != null)
                {
                    _fps.Clear();
                    _fps = null;
                }

                _th = null;
            }
        }

        // ::
        private static void p_AddFilePaths(string path)
        {
            string[] t_fps = Directory.GetFiles(path);

            foreach (string t_fp in t_fps)
            {
                if (_fps == null)
                {
                    _fps = new List<string>();
                }

                _fps.Add(t_fp);
            }

            if (_bSub)
            {
                string[] t_paths = Directory.GetDirectories(path);

                foreach (string t_path in t_paths)
                {
                    p_AddFilePaths(t_path);
                }
            }
        }

        // ::
        private static void p_CopyFiles()
        {
            foreach (string t_fp in _fps)
            {
                if (_th == null)
                {
                    break;
                }
                else
                {
                    string t_tp = t_fp.Replace(_targetPath, _purposePath);
                    //Console.WriteLine("t_fp: " + t_fp);
                    //Console.WriteLine("t_tp: " + t_tp);
                    p_CopyFile(t_fp, t_tp);

                    if (_progressBar != null)
                    {
                        _progressBar.PerformStep();
                    } 
                }
            }

            p_WorkClear();
        }

        // ::
        private static void p_CopyFile(string tp, string pp)
        {
            // PurposePath
            string t_pp = Path.GetDirectoryName(pp);

            if (!Directory.Exists(t_pp))
            {
                Directory.CreateDirectory(t_pp);
            }

            try
            {
                File.Copy(tp, pp, true);
            }
            catch (Exception)
            {
                //Console.WriteLine("e: " + e);
            }
        }
    }
}
