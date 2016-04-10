Imports System
Imports System.Diagnostics
Imports System.IO
Imports System.Windows

Public NotInheritable Class MainWindow

    Public Sub New()
        p_CheckOutter()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub p_CheckOutter()
        Dim t_np As Process = Process.GetCurrentProcess()
        Dim t_npn As String = t_np.ProcessName
        Dim t_dps As Process() = Process.GetProcessesByName(t_npn)
        For Each t_dp As Process In t_dps

            If p_CheckEqual(t_np, t_dp) Then
                Application.Current.Shutdown()
                Exit For
            End If

            'MessageBox.Show(t_NowProcess.MainModule.ToString)
            'MessageBox.Show(t_Process.MainModule.ToString)
            'MessageBox.Show(t_NowProcess.MainModule.GetHashCode)
            'MessageBox.Show(t_Process.MainModule.GetHashCode)
            'MessageBox.Show(t_NowProcess.MainModule.GetHashCode)
            'MessageBox.Show(t_Process.StartInfo.)
            'MessageBox.Show(t_Process.MainModule.FileName)
            'MessageBox.Show("2: " & t_NowProcess.MainModule.FileVersionInfo.GetHashCode)
        Next
    End Sub

    Private Function p_CheckEqual(ByVal np As Process, ByVal dp As Process) As Boolean
        If (np.Id.Equals(dp.Id)) Then
            Return False
        End If

        If (np.ProcessName.Equals(dp.ProcessName)) Then
            Return True
        End If

        Return False
    End Function


    Private Sub p_Me_Loaded(ByVal sender As Object, ByVal rea As RoutedEventArgs)
        Me.Title = "CaseByWorker Ver 1.00b"
    End Sub


    Private Sub p_Clear_Click(ByVal sender As Object, ByVal rea As RoutedEventArgs)
        Me.TextBox1.Clear()
    End Sub

    Private Sub p_Start_Click(ByVal sender As Object, ByVal rea As RoutedEventArgs)

    End Sub
End Class
