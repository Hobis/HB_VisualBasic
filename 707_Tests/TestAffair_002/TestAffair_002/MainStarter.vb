Imports System.Windows.Forms

Public Module MainStarter

    Public Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Dim t_hbf As New HB_Form()
        Application.Run(t_hbf)
    End Sub

End Module
