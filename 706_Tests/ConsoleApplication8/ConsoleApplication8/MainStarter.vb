Imports System
Imports System.Windows.Forms


Public Module MainStarter

    Public Sub Main()
        'Dim t_os As OperatingSystem = Environment.OSVersion
        'Dim t_osn As String = t_os.VersionString
        'Dim t_osp As String = t_os.Platform.ToString()
        'Dim t_clrv As String = Environment.Version.ToString()

        'Console.WriteLine("OS_Name: " & t_osn)
        'Console.WriteLine("OS_Platform: " & t_osp)
        'Console.WriteLine("CLR_VERSION: " & t_clrv)


        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Dim t_f As New MainForm()
        Application.Run(t_f)
    End Sub

End Module

