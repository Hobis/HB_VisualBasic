Imports System
Imports System.Configuration
Imports System.Drawing
Imports System.Diagnostics
Imports System.IO
Imports System.Windows.Forms
Imports System.Threading
Imports IWshRuntimeLibrary

Public NotInheritable Class MainWin
    ' #
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.p_InitOnce()
    End Sub

    ' -
    Private Const _TakeOver As String = "?type=!__%40%23%24takeOver"
    ' #
    Private Sub p_InitOnce()
        Dim tRootPath As String = Path.Combine(Environment.CurrentDirectory, "root")
        Environment.CurrentDirectory = tRootPath

        'Me.AutoSizeMode = AutoSizeMode.GrowAndShrink
        'Me.MaximizeBox = False
        Me.ClientSize = New Size(800, 600)
        Me.Text = "Untitle"
        Me.StartPosition = FormStartPosition.CenterScreen

        ' 
        Try
            Dim t_v As String = ConfigurationManager.AppSettings("Title")
            If (String.IsNullOrEmpty(t_v)) Then
            Else
                Me.Text = t_v
            End If
        Catch ex As Exception
        End Try

        ' 
        Try
            Dim t_v As String = ConfigurationManager.AppSettings("MaximumSize")
            If (String.IsNullOrEmpty(t_v)) Then
            Else
                Dim t_vs As String() = t_v.Split(","c)
                Dim t_s As Size = New Size(Integer.Parse(t_vs(0)), Integer.Parse(t_vs(1)))
                Me.MaximumSize = t_s
            End If
        Catch ex As Exception
        End Try

        ' 
        Try
            Dim t_v As String = ConfigurationManager.AppSettings("MinimumSize")
            If (String.IsNullOrEmpty(t_v)) Then
            Else
                Dim t_vs As String() = t_v.Split(","c)
                Dim t_s As Size = New Size(Integer.Parse(t_vs(0)), Integer.Parse(t_vs(1)))
                Me.MinimumSize = t_s
            End If
        Catch ex As Exception
        End Try

        ' 
        Try
            Dim t_v As String = ConfigurationManager.AppSettings("Size")
            If (String.IsNullOrEmpty(t_v)) Then
            Else
                Dim t_vs As String() = t_v.Split(","c)
                Dim t_s As Size = New Size(Integer.Parse(t_vs(0)), Integer.Parse(t_vs(1)))
                Me.Size = t_s
            End If
        Catch ex As Exception
        End Try

        ' 
        Try
            Dim t_v As String = ConfigurationManager.AppSettings("ClientSize")
            If (String.IsNullOrEmpty(t_v)) Then
            Else
                Dim t_vs As String() = t_v.Split(","c)
                Dim t_s As Size = New Size(Integer.Parse(t_vs(0)), Integer.Parse(t_vs(1)))
                Me.ClientSize = t_s
            End If
        Catch ex As Exception
        End Try

        ' 
        Try
            Dim t_v As String = ConfigurationManager.AppSettings("Location")
            If (String.IsNullOrEmpty(t_v)) Then
            Else
                Dim t_vs As String() = t_v.Split(","c)
                Dim t_p As Point = New Point(Integer.Parse(t_vs(0)), Integer.Parse(t_vs(1)))
                Me.StartPosition = FormStartPosition.Manual
                Me.Location = t_p
            End If
        Catch ex As Exception
        End Try

        ' 
        Try
            Dim t_v As String = ConfigurationManager.AppSettings("WindowState")
            If (String.IsNullOrEmpty(t_v)) Then
            Else
                Dim t_ev As FormWindowState = CType([Enum].Parse(GetType(FormWindowState), t_v), FormWindowState)
                Me.WindowState = t_ev
            End If
        Catch ex As Exception
        End Try


        Me.WebBrowser1.ObjectForScripting = Me
        Me.WebBrowser1.IsWebBrowserContextMenuEnabled = False
        Me.WebBrowser1.AllowWebBrowserDrop = False
        Me.WebBrowser1.ScrollBarsEnabled = False
        Me.WebBrowser1.ScriptErrorsSuppressed = False
        Me.WebBrowser1.WebBrowserShortcutsEnabled = False

        Dim t_name As String = Path.GetFileNameWithoutExtension(Application.ExecutablePath)
        Dim t_src As String = Path.Combine(Environment.CurrentDirectory, t_name + ".html" + _TakeOver)
        'Debug.Log(t_src)
        Me.WebBrowser1.Navigate(t_src)


        '
        Me.Button_Test.Visible = False
    End Sub

    ' ::
    Private Sub p_Me_Load(ByVal sender As Object, ByVal ea As EventArgs) Handles Me.Load
    End Sub

    ' ::
    Private Sub p_WebBrowser1_DocumentCompleted(ByVal sender As Object, ByVal wdcea As WebBrowserDocumentCompletedEventArgs) _
        Handles WebBrowser1.DocumentCompleted
    End Sub

    ' :: 웹브라우저 키다운 핸들러
    Private Sub p_webBrowser1_PreviewKeyDown(ByVal sender As Object, ByVal pkdea As PreviewKeyDownEventArgs) Handles WebBrowser1.PreviewKeyDown
        Select Case pkdea.KeyCode
            Case Keys.Escape
                Me.p_SetFullScreen(False)

            Case Keys.F5
                Me.p_Js_Call("p_reload", Nothing)

        End Select
    End Sub

    ' -
    Private Const WM_SYSCOMMAND As Integer = &H112
    ' -
    Private Const SC_MAXIMIZE As Integer = &HF030
    ' ::
    Protected Overrides Sub WndProc(ByRef m As Message)
        If (m.Msg.Equals(WM_SYSCOMMAND)) Then
            If (m.WParam.ToInt32().Equals(SC_MAXIMIZE)) Then
                Me.p_FullScreen_Toggle()
                Return
            End If
        End If
        MyBase.WndProc(m)
    End Sub


    ' :: 풀스크린 토글
    Private Sub p_FullScreen_Toggle()
        If (Me.TopMost) Then
            Me.p_SetFullScreen(False)
        Else
            Me.p_SetFullScreen(True)
        End If
    End Sub

    ' -
    Private _TempSize As Size = Nothing
    ' :: 풀스크린 설정
    Private Sub p_SetFullScreen(ByVal b As Boolean)
        If (b) Then
            If (Me.TopMost) Then
            Else
                Me.TopMost = True
                Me._TempSize = Me.Size
                Me.FormBorderStyle = FormBorderStyle.None
                Me.WindowState = FormWindowState.Maximized
                Me.WebBrowser1.Focus()
            End If
        Else
            If (Me.TopMost) Then
                Me.TopMost = False
                Me.WindowState = FormWindowState.Normal
                Me.FormBorderStyle = FormBorderStyle.Sizable
                Me.Size = Me._TempSize
                Me._TempSize = Nothing
            End If
        End If
    End Sub

    ' :: Js 호출 보냄
    Private Sub p_Js_Call(ByVal funcName As String, ByVal args As Object())
        Try
            Me.WebBrowser1.Document.InvokeScript(funcName, args)
        Catch e As Exception
        End Try
    End Sub

    ' :: Js 호출 받음 노멀
    Public Sub Js_CallBack_n(ByVal type As String)
        Dim t_wmt As Win_Message_Types = CType([Enum].Parse(GetType(Win_Message_Types), type), Win_Message_Types)
        Me.p_Js_CallBack_Core(t_wmt, Nothing)
    End Sub

    ' :: Js 호출 받음 노멀
    Public Sub Js_CallBack(ByVal type As String, ByVal args As Object())
        Dim t_wmt As Win_Message_Types = CType([Enum].Parse(GetType(Win_Message_Types), type), Win_Message_Types)
        Me.p_Js_CallBack_Core(t_wmt, args)
    End Sub

    ' :: Js 호출 받음 핵심
    Private Sub p_Js_CallBack_Core(ByVal wmt As Win_Message_Types, ByVal args As Object())
        Select Case wmt
            Case Win_Message_Types.Win_Init
                '

            Case Win_Message_Types.Win_Set_Title
                Dim t_name As String = CType(args(0), String)
                Me.Text = t_name

            Case Win_Message_Types.Win_Set_Visible
                Dim t_b As Boolean = CType(args(0), Boolean)
                Me.Visible = t_b

            Case Win_Message_Types.Win_Set_MinSize
                Me.WindowState = FormWindowState.Normal
                Dim t_s As Size = New Size(CType(args(0), Integer), CType(args(1), Integer))
                Me.MinimumSize = Me.DefaultMaximumSize
                Me.ClientSize = t_s
                Me.MinimumSize = Me.Size


            Case Win_Message_Types.Win_Set_Location
                Me.WindowState = FormWindowState.Normal
                Me.Location = New Point(CType(args(0), Integer), CType(args(1), Integer))

            Case Win_Message_Types.Win_Resize_Max
                Me.WindowState = FormWindowState.Maximized

            Case Win_Message_Types.Win_Resize_Min
                Me.WindowState = FormWindowState.Minimized

            Case Win_Message_Types.Win_Resize_Normal
                Me.WindowState = FormWindowState.Normal

            Case Win_Message_Types.Win_Resize_FullScreen
                Dim t_b As Boolean = CType(args(0), Boolean)
                Me.p_SetFullScreen(t_b)

            Case Win_Message_Types.Win_Resize
                Me.WindowState = FormWindowState.Normal
                Me.ClientSize = New Size(CType(args(0), Integer), CType(args(1), Integer))

            Case Win_Message_Types.Win_Open
                Dim t_bastPath As String = Environment.CurrentDirectory
                Dim t_filePath As String = CType(args(0), String)
                Dim t_path As String = Path.Combine(t_bastPath, t_filePath)
                'Debug.Log("t_basePath: " & t_bastPath)
                'Debug.Log("t_filePath: " & t_filePath)
                'Debug.Log("t_path: " & t_path)

                Dim t_psi As ProcessStartInfo = New ProcessStartInfo()
                t_psi.WorkingDirectory = Path.GetDirectoryName(t_path)
                'Debug.Log("t_psi.WorkingDirectory: " & t_psi.WorkingDirectory)
                t_psi.FileName = Path.GetFileName(t_path)
                'Debug.Log("t_psi.FileName: " & t_psi.FileName)
                Process.Start(t_psi)

            Case Win_Message_Types.Win_Center_Location
                Me.CenterToScreen()

            Case Win_Message_Types.Win_Copy_Folder
                Dim t_dr As DialogResult = Me.FolderBrowserDialog1.ShowDialog(Me)
                If (t_dr.Equals(DialogResult.OK)) Then
                    Dim t_targetPath As String = Environment.CurrentDirectory
                    Dim t_meText As String = Me.Text
                    Dim t_purposePath As String = Path.Combine(Me.FolderBrowserDialog1.SelectedPath, t_meText)
                    Try
                        FIO_Util.DirectoryCopy(t_targetPath, t_purposePath, True, t_meText)
                    Catch ex As Exception
                    End Try
                End If

            Case Win_Message_Types.Win_Close
                Me.Close()

        End Select

    End Sub

    '
    Private Sub p_Button_Test_Click(ByVal sender As Object, ByVal ea As EventArgs) Handles Button_Test.Click
        Me.p_Js_CallBack_Core(Win_Message_Types.Win_Copy_Folder, Nothing)
    End Sub
End Class



' #
Public Enum Win_Message_Types
    Win_Init
    Win_Set_Title
    Win_Set_Visible
    Win_Set_MinSize
    Win_Set_Location
    Win_Resize_Max
    Win_Resize_Min
    Win_Resize_Normal
    Win_Resize_FullScreen
    Win_Resize
    Win_Open
    Win_Center_Location
    Win_Copy_Folder
    Win_Close
End Enum

' #
Public Module Debug
    '
    Private Const _frontMsg As String = "# [hb] "
    '
    Public Sub Log(ByVal msg As String)
        MessageBox.Show(_frontMsg + msg)
    End Sub
End Module

' #
Public Module FIO_Util
    ' -
    Private _th As Thread = Nothing

    ' ::
    Public Sub DirectoryCopy(ByVal targetPath As String, _
                             ByVal purposePath As String, _
                             ByVal bSub As Boolean, _
                             ByVal shortcutName As String)
        If (_th Is Nothing) Then
            _th = New Thread(New ThreadStart(
                Sub()
                    p_DirectoryCopy_Core(targetPath, purposePath, bSub, shortcutName)
                End Sub))
            _th.Start()
        Else
        End If
    End Sub

    ' ::
    Private Sub p_DirectoryCopy_Core(ByVal targetPath As String, _
                                     ByVal purposePath As String, _
                                     ByVal bSub As Boolean, _
                                     ByVal shortcutName As String)
        ' Get the subdirectories for the specified directory.
        Dim t_dir As DirectoryInfo = New DirectoryInfo(targetPath)
        Dim t_dirs As DirectoryInfo() = t_dir.GetDirectories()

        If (t_dir.Exists) Then
        Else
            Throw New DirectoryNotFoundException( _
                "Source directory does not exist or could not be found: " _
                & targetPath)
            Return
        End If

        ' If the destination directory doesn't exist, create it. 
        If (Directory.Exists(purposePath)) Then
        Else
            Try
                Directory.CreateDirectory(purposePath)
            Catch ex As Exception
            End Try
        End If

        ' Get the files in the directory and copy them to the new location.
        Dim t_files As FileInfo() = t_dir.GetFiles()
        For Each t_file As FileInfo In t_files
            Dim t_path As String = Path.Combine(purposePath, t_file.Name)
            Try
                t_file.CopyTo(t_path, True)
            Catch ex As Exception
            End Try
        Next

        ' If copying subdirectories, copy them and their contents to new location. 
        If (bSub) Then
            For Each t_subDir As DirectoryInfo In t_dirs
                Dim t_path As String = Path.Combine(purposePath, t_subDir.Name)
                p_DirectoryCopy_Core(t_subDir.FullName, t_path, bSub, Nothing)
            Next
        End If

        If (shortcutName Is Nothing) Then
        Else
            Dim t_name As String = Path.GetFileName(Application.ExecutablePath)
            Dim t_targetPath As String = Path.Combine(purposePath, t_name)
            Try
                p_CreateShortcut(t_targetPath, shortcutName)
            Catch ex As Exception
            End Try
        End If

        _th = Nothing
    End Sub

    ' ::
    Private Sub p_CreateShortcut(ByVal targetPath As String, ByVal shortcutName As String)
        Dim t_dto As Object = CType("Desktop", Object)
        Dim t_ws As WshShell = New WshShell()
        Dim t_sca As String = t_ws.SpecialFolders.Item(t_dto) & "\\" & shortcutName & ".lnk"
        Dim t_wsc As IWshShortcut = CType(t_ws.CreateShortcut(t_sca), IWshShortcut)
        't_wsc.Description = shortcutName
        't_wsc.Hotkey = "Ctrl+Shift+N"
        t_wsc.TargetPath = targetPath
        t_wsc.WorkingDirectory = Path.GetDirectoryName(targetPath)
        t_wsc.Save()
    End Sub
End Module

