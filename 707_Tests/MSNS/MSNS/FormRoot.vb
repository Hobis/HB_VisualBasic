Imports System.IO
Imports System.Runtime.InteropServices

Public NotInheritable Class FormRoot

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        p_Init()
    End Sub


    Private Sub p_Init()
        AddHandler Me.Load, AddressOf p_Load
        AddHandler Me.Shown, AddressOf p_Shown
    End Sub



    Private Const _CompanyStr As String = "종근당"
    Private Const _ProgramStr As String = "의약품 일련번호 시스템"
    Private Const _VersionStr As String = "Ver 1.02b"
    Private Const _TitleStr As String = _
        _CompanyStr & " " & _ProgramStr & " " & _VersionStr

    Private _DefaultSize As Size = System.Drawing.Size.Empty

    Private Sub p_Load(ByVal sender As Object, ByVal e As EventArgs)
        Me._DefaultSize = Me.Size

        Me.Text = _TitleStr

        Me.wbRoot.ObjectForScripting = Me
        'Me.wbRoot.
        'Me.wbRoot.
        'Me.wbRoot.IsWebBrowserContextMenuEnabled = False
        'Me.wbRoot.AllowWebBrowserDrop = False
        'Me.wbRoot.ScrollBarsEnabled = False
        'Me.wbRoot.ScriptErrorsSuppressed = True
        'Me.wbRoot.WebBrowserShortcutsEnabled = False
        Me.wbRoot.Dock = DockStyle.Fill
        Dim t_swfp As String = Path.Combine(Application.StartupPath, "Swfs/Root.swf")
        Me.wbRoot.Navigate(t_swfp)
        AddHandler Me.wbRoot.DocumentCompleted, AddressOf p_wbRoot_DocumentCompleted

        'Me.Visible = False
        'Me.ShowInTaskbar = False
        'MessageBox.Show("여기 1")

    End Sub

    Private Sub p_Shown(ByVal sender As Object, ByVal e As EventArgs)
        'Me.Visible = True
        'MessageBox.Show("여기 2")
    End Sub


    Private Sub p_wbRoot_DocumentCompleted(ByVal sender As Object, ByVal e As WebBrowserDocumentCompletedEventArgs)
        'Me.Visible = True
        'MessageBox.Show("value.ToString()")
        ''MyBase.SetVisibleCore(True)
        'Me.Visible = True
        'Me.ShowInTaskbar = True
        'MyBase.SetVisibleCore(True)
        'MessageBox.Show("여기")
        'Me.Show()
        'MessageBox.Show("여기 3")


        'Me.wbRoot.Document.
        'MessageBox.Show(": " & Me.wbRoot.Document)
        'Me.tmRoot.Start()
    End Sub


    'Protected Overrides Sub SetVisibleCore(ByVal value As Boolean)
    '    MessageBox.Show("여기 4")
    '    MyBase.SetVisibleCore(False)
    'End Sub
    'Protected Overrides Sub SetVisibleCore(ByVal value As Boolean)
    '    If (Not Me.IsHandleCreated) Then
    '        value = False
    '        Me.CreateHandle()

    '    End If
    '    MyBase.SetVisibleCore(value)
    'End Sub

    Private Sub tmRoot_Tick(sender As Object, e As EventArgs) Handles tmRoot.Tick
        'Me.wbRoot.Document.InvokeScript("alert", New Object() {"Hello"})
        'Me.wbRoot.Document.InvokeScript("p_fl_SetText", New Object() {"Hello"})
        'Me.wbRoot.Document.InvokeScript("p_fl_SetText")
        'MessageBox.Show("1004")
        'Me.wbRoot.Document.InvokeScript("p_fl_SetText", New Object() {"pppp"})


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Me.wbRoot.Document.InvokeScript("p_fl_SetText", New Object() {"pppp"})
        'Me.wbRoot.Document.InvokeScript("alert", New Object() {"pppp"})
        ''Me.wbRoot.Document.InvokeScript("p_fl_SetText", New Object() {"pppp"})
        Me.wbRoot.Document.InvokeScript("p_fl_SetText")
    End Sub
End Class
