using System;
using System.Collections.Specialized;
using System.Web;

namespace ConsoleApplication9
{
    public static class MainProgram
    {
        public static void Main(string[] args)
        {
            //string t_queryStr = "?Base64String=POPOPOPOPOPOPO!@!@!@!@!@POPOPO&MappingData=011234";
            string t_queryStr = "?newwindow=1&q=c%23+urlencode&oq=c%23+url&gs_l=serp.3.0.0l10.946791.947282.0.948704.3.3.0.0.0.0.119.216.1j1.2.0....0...1c.1.52.serp..1.2.213.OQyLFJ52qm0";            
            //t_queryStr = HttpUtility.UrlEncode(t_queryStr);
            t_queryStr = HttpUtility.UrlDecode(t_queryStr);
            //Console.WriteLine("t_queryStr: " + t_queryStr);
            NameValueCollection t_nvc = HttpUtility.ParseQueryString(t_queryStr);
            Console.WriteLine(": " + t_nvc["gs_l"]);
            t_nvc.Clear();
            /*
            foreach (string t_pk in t_nvc.AllKeys)
            {
                //Console.WriteLine(": " + t_nvc[t_pk]);
                Console.WriteLine(": " + t_pk);
            }
            */
        }
    }
}
