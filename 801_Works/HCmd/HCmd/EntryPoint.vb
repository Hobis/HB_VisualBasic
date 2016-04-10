Imports System
Imports System.IO
Imports System.IO.Compression
Imports Microsoft.VisualBasic


Public Module EntryPoint

    Public Sub Main()
        'Dim t_args() As String = Environment.GetCommandLineArgs()
        'If ((t_args IsNot Nothing) AndAlso (t_args.Length > 1)) Then
        '    Dim t_la As Integer = UBound(t_args, 1) + 1
        '    Dim i As Integer = 1
        '    While (i < t_la)
        '        Dim t_arg As String = t_args(i)
        '        Console.WriteLine(t_arg)
        '        i += 1
        '    End While
        'End If
        _Args = Environment.GetCommandLineArgs()
        p_Task_Check()
    End Sub

    Private _Args() As String = Nothing

    Private _WorkPath As String = Environment.CurrentDirectory

    Private Const _TaskName_Copy As String = "-Copy"
    Private Const _TaskName_UnZip As String = "-UnZip"


    Private Sub p_Task_Check()
        If (_Args Is Nothing) Then Exit Sub
        If (_Args.Length < 2) Then Exit Sub


        Dim t_TaskName As String = _Args(1)

        Select Case t_TaskName
            Case _TaskName_Copy
                p_Task_Copy()

            Case _TaskName_UnZip
                p_Task_Unzip()
        End Select

        'Console.WriteLine("t_TaskName: " & t_TaskName)
    End Sub

    Private Sub p_Trace(ByVal msg As String)
        Console.WriteLine("HCmd Msg: " & msg)
    End Sub

    Private Sub p_Task_Copy()
        Try
            Dim t_p1 As String = Path.Combine(_WorkPath, _Args(2))
            Dim t_p2 As String = Path.Combine(_WorkPath, _Args(3))
            Dim t_p2p As String = Path.GetDirectoryName(t_p2)

            If (Directory.Exists(t_p2p)) Then
            Else
                Directory.CreateDirectory(t_p2p)
            End If

            'p_Trace("t_path1: " & t_p1)
            'p_Trace("t_path2: " & t_p2)
            'p_Trace(Path.GetDirectoryName(t_path2))
            'p_Trace(Directory.Exists(Path.GetDirectoryName(t_p2)).ToString())
            'File.Copy(t_path1, t_path2, True)
            FileSystem.FileCopy(t_p1, t_p2)
            p_Trace("Task" & _TaskName_Copy & " Successful")
        Catch ex As Exception
            p_Trace("Task" & _TaskName_Copy & " Failed")
            'p_Trace(ex.ToString)
        End Try
    End Sub

    'http://stackoverflow.com/questions/12889044/unzip-file-in-vb-net
    'https://msdn.microsoft.com/library/windows/desktop/bb787866(v=vs.85).aspx/
    Private Sub p_Task_Unzip()
        Try
            Dim t_p1 As String = Path.Combine(_WorkPath, _Args(2))
            Dim t_p2 As String = Path.Combine(_WorkPath, _Args(3))

            If (Directory.Exists(t_p2)) Then
            Else
                Directory.CreateDirectory(t_p2)
            End If

            'p_Trace(t_p1)
            'p_Trace(t_p2)
            Dim t_Shell As Shell32.Shell = New Shell32.Shell()
            Dim t_s1 As Shell32.Folder = t_Shell.NameSpace(t_p1)
            Dim t_s2 As Shell32.Folder = t_Shell.NameSpace(t_p2)
            't_s2.CopyHere(t_s1.Items, 4)
            t_s2.CopyHere(t_s1.Items, 16)

            p_Trace("Task" & _TaskName_UnZip & " Successful")
        Catch ex As Exception
            p_Trace("Task" & _TaskName_UnZip & " Failed")
            p_Trace(ex.ToString)
        End Try
    End Sub

End Module
