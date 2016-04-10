Imports System.IO

Public NotInheritable Class Form1
    ' 시작~~
    Private Sub p_Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.p_InitOnce()
    End Sub


    ' 이름
    Private Const _Name As String = "두산동아"

    ' 타이틀
    Private Const _Title As String = _Name & " 중학교 한문"


    ' # 처음 한번 초기화
    Private Sub p_InitOnce()
        'Me.AutoSizeMode = AutoSizeMode.GrowAndShrink
        'Me.MaximizeBox = False
        Me.Width = 800
        Me.Height = 600
        Me.MinimumSize = Me.Size
        Me.Text = _Title

        Dim t_str As String
        MessageBox.Show(String.IsNullOrEmpty(t_str))




        Dim t_i As Integer

        If t_i = Nothing Then
            MessageBox.Show("올로케이션 더블케이")
        End If


        Dim t_src As String = Path.Combine(Environment.CurrentDirectory, "Main.html")
        Me.WebBrowser1.Navigate(t_src)
        Me.WebBrowser1.ObjectForScripting = Me
        Me.WebBrowser1.IsWebBrowserContextMenuEnabled = False
        Me.WebBrowser1.AllowWebBrowserDrop = False
        Me.WebBrowser1.WebBrowserShortcutsEnabled = False


        AddHandler Me.WebBrowser1.DocumentCompleted, _
            New WebBrowserDocumentCompletedEventHandler(AddressOf Me.p_WebBrowser1_DocumentCompleted_Once)

    End Sub

    ' # 
    Private Sub p_WebBrowser1_DocumentCompleted_Once( _
                    ByVal sender As Object, ByVal wbdcea As WebBrowserDocumentCompletedEventArgs)
        RemoveHandler Me.WebBrowser1.DocumentCompleted, _
            New WebBrowserDocumentCompletedEventHandler(AddressOf Me.p_WebBrowser1_DocumentCompleted_Once)

    End Sub



    Private Const _Js_Init As String = "Js_Init"

    Private Const _Win_Rename As String = "Win_Rename"
    Private Const _Win_Visible As String = "Win_Visible"
    Private Const _Win_Resize_Max As String = "Win_Resize_Max"
    Private Const _Win_Resize_Min As String = "Win_Resize_Min"
    Private Const _Win_Resize_Normal As String = "Win_Resize_Normal"
    Private Const _Win_Resize As String = "Win_Resize"
    Private Const _Win_Location As String = "Win_Location"

    ' # 
    Public Sub Js_CallBack_n(ByVal type As String)
        Me.Js_CallBack(type, Nothing)
    End Sub

    ' #
    Public Sub Js_CallBack(ByVal type As String, ByVal args As Object())
        MessageBox.Show("~~~~~~~~~~~")


        'Select Case type
        '    Case _Js_Init

        '    Case _Win_Rename
        '        Dim t_name As String = CType(args(0), String)

        '    Case _Win_Visible

        '    Case _Win_Resize_Max

        '    Case _Win_Resize_Min

        '    Case _Win_Resize_Normal

        'End Select
    End Sub
End Class
