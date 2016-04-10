using System;
using System.IO;
using System.Text;

namespace FileStream_Test_001
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            string t_targetFile = "Test_.png";
            string t_outFile = "Test.png.base64str";

            if (File.Exists(t_targetFile))
            {
                // 읽기전용 스트림
                FileStream t_rfs = new FileStream(t_targetFile, FileMode.Open, FileAccess.Read, FileShare.Read);
                // 쓰기전용 스트림
                FileStream t_wfs = new FileStream(t_outFile, FileMode.Truncate);
                //
                StreamWriter t_sw = new StreamWriter(t_wfs);

                //
                const int t_BUFF_SIZE = 3 * (1024 * 1);

                //
                byte[] t_buff = new byte[t_BUFF_SIZE];
                //
                long t_totalCount = t_rfs.Length;
                long t_rpos = 0;
                long t_rest = 0;
                //
                int t_offset = 0;
                int t_count = t_buff.Length;
                //
                while (true)
                {
                    if (t_rpos < t_totalCount)
                    {
                        t_rest = t_totalCount - t_rpos;
                        if (t_rest < t_BUFF_SIZE)
                        {
                            t_count = (int)t_rest;
                        }

                        t_rpos += t_rfs.Read(t_buff, t_offset, t_count);
                        t_sw.Write(Convert.ToBase64String(t_buff, t_offset, t_count));

                        //Console.WriteLine("t_totalCount: " + t_totalCount);
                        //Console.WriteLine("t_readPos: " + t_rpos);
                        //Console.WriteLine("t_rest: " + t_rest);
                        //Console.WriteLine("t_count: " + t_count);
                    }
                    else
                    {
                        break;
                    }
                }

                p_StreamDispose(t_sw);
                p_StreamDispose(t_wfs);
                p_StreamDispose(t_rfs);
            }
        }

        // ::
        public static void p_StreamDispose(IDisposable ido)
        {
            if (ido != null)
            {
                ido.Dispose();
            }
        }
    }
}
