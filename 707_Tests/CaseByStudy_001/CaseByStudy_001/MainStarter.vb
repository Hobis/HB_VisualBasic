Imports System
Imports System.Windows.Forms

Public Module MainStarter
    Public Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Dim t_mw As New MainWin()
        Application.Run(t_mw)
    End Sub
End Module
