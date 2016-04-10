using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace FIO_Test_001
{
    public static class Program
    {
        public static void Main(string[] args)
        {/*
            string[] t_fs = Directory.GetFiles(@"C:\Users\Hobis-PC\Desktop\_Test");

            foreach (string t_f in t_fs)
            {
                Console.WriteLine("file: " + t_f);
            }
            //
            //
            //
            string[] t_ds = Directory.GetDirectories(@"C:\Users\Hobis-PC\Desktop\_Test");

            foreach (string t_f in t_ds)
            {
                Console.WriteLine("dir: " + t_f);
            }*/


/*
            string t_targetPath = @"C:\Users\Hobis-PC\Desktop\_Test\01_TargetPath";
            string t_purposePath = @"C:\Users\Hobis-PC\Desktop\_Test\02_PurposePath";
            List<string> t_fps = null;
            p_AddFilePaths(ref t_fps, t_targetPath, true);
            if (t_fps != null)
            {
                p_CopyFilePaths(t_fps, t_targetPath, t_purposePath);
            }*/

/*
            string t_targetPath = @"C:\Users\Hobis-PC\Desktop\_Test\01_TargetPath\File_001.as";
            string t_purposePath = @"C:\Users\Hobis-PC\Desktop\_Test3\DDD\LLL\AAA\BBB\CCC\DDD\1111\File_001222.as";
            p_CopyFile(t_targetPath, t_purposePath);*/



            HB_CopyDirectory.Start(
                @"D:\01_Flash\000_Libs",
                @"C:\Users\Hobis-PC\Desktop\_Test\02_PurposePath",
                true
            );
        }


    }


    public static class HB_CopyDirectory
    {
        // ::
        public static void Start(string targetPath, string purposePath, bool bSub, bool bShortcut)
        {
            if (_targetPath == null)
            {
                _targetPath = targetPath;
                _purposePath = purposePath;
                _bSub = bSub;
                _bShortcut = bShortcut;

                p_AddFilePaths(_targetPath);
                /*
                            if (_fps != null)
                            {
                                p_CopyFilePaths(t_fps, targetPath, purposePath);
                            }*/
            }
        }

        private static string _targetPath = null;
        private static string _purposePath = null;
        private static bool _bSub = false;
        private static bool _bShortcut = false;
        private static List<string> _fps = null;

        private static Thread _th = null;
        private static bool _bLoop = false;



        // ::
        private static void p_AddFilePaths(string path)
        {
            string[] t_fs = Directory.GetFiles(path);

            foreach (string t_f in t_fs)
            {
                if (_fps == null)
                {
                    _fps = new List<string>();
                }

                _fps.Add(t_f);
            }

            if (_bSub)
            {
                string[] t_paths = Directory.GetDirectories(_targetPath);

                foreach (string t_path in t_paths)
                {
                    p_AddFilePaths(t_path);
                }
            }
        }

        // ::
        private static void p_CopyFilePaths(List<string> fps, string targetPath, string purposePath)
        {
            foreach (string t_fp in fps)
            {
                string t_tp = t_fp.Replace(targetPath, purposePath);

                //Console.WriteLine("t_fp: " + t_fp);
                //Console.WriteLine("t_tp: " + t_tp);
                p_CopyFile(t_fp, t_tp);
            }
        }

        // ::
        private static void p_CopyFile(string targetPath, string purposePath)
        {
            string t_purposeDir = Path.GetDirectoryName(purposePath);

            if (!Directory.Exists(t_purposeDir))
            {
                Directory.CreateDirectory(t_purposeDir);
            }

            try
            {
                File.Copy(targetPath, purposePath, true);
            }
            catch (Exception) { }
        }
    }
}
