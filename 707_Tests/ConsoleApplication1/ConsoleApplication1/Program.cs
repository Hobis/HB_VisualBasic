using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApplication1
{
    class Program
    {
        private delegate void _GotoMam();

        static void Main(string[] args)
        {
            _GotoMam t_gm = new _GotoMam(p_Lotemer);
            Console.WriteLine("1");
            //t_gm.BeginInvoke(null, null);
            t_gm.Invoke();
            t_gm.BeginInvoke(new AsyncCallback(delegate(IAsyncResult ar)
            {
                t_gm.EndInvoke(ar);
            }), null);
            Console.WriteLine("2");
            Console.WriteLine("3");
            Console.WriteLine("4");

            Thread.Sleep(1000);
            Console.WriteLine("5");
        }

        private static void p_Lotemer()
        {
            Console.WriteLine("p_Lotemer");
        }
    }
}
