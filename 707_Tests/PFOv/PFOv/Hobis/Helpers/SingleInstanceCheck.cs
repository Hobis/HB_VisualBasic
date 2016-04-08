using System;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace Hobis.Helpers
{
    public static class SingleInstanceCheck
    {
        [DllImportAttribute("user32.dll", EntryPoint = "ShowWindow", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int p_ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImportAttribute("user32.dll", EntryPoint = "SetForegroundWindow", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int p_SetForegroundWindow(IntPtr hWnd);

        [DllImportAttribute("user32.dll", EntryPoint = "IsIconic", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int p_IsIconic(IntPtr hWnd);

        private const int _SW_RESTORE = 9;

        /// <summary>
        /// SwitchToCurrentInstance
        /// </summary>
        private static void p_SwitchToCurrentInstance(IntPtr hWnd)
        {
            if (!hWnd.Equals(IntPtr.Zero))
            {
                // Restore window if minimised. Do not restore if already in
                // normal or maximised window state, since we don't want to
                // change the current state of the window.
                if (p_IsIconic(hWnd) != 0)
                {
                    p_ShowWindow(hWnd, _SW_RESTORE);
                }

                // Set foreground window.
                p_SetForegroundWindow(hWnd);
            }
        }

        // ::
        public static bool IsTest()
        {
            Process t_np = Process.GetCurrentProcess();
            string t_nplt = t_np.MainModule.FileVersionInfo.LegalTrademarks;

            Process[] t_aps = Process.GetProcessesByName(t_np.ProcessName);
            if ((t_aps != null) && (t_aps.Length > 1))
            {
                foreach (Process t_ap in t_aps)
                {
                    string t_aplt = t_ap.MainModule.FileVersionInfo.LegalTrademarks;

                    if (!t_ap.Id.Equals(t_np.Id))
                    {
                        if (t_ap.ProcessName.Equals(t_np.ProcessName) && t_aplt.Equals(t_nplt))
                        {
                            //Console.WriteLine("ProcessName={0}, ProcessId{1}", t_ap.Id, t_np.Id);
                            //Console.WriteLine("열려있음");
                            p_SwitchToCurrentInstance(t_ap.MainWindowHandle);
                            return false;
                        }
                    }
                }
            }

            return true;
        }
    }
}
