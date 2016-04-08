Imports System.IO

Public Class FormRoot

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        p_InitOnce()

    End Sub

    Private _wbRoot As WebBrowser = Nothing
    Private Sub p_InitOnce()
        Me._wbRoot = New WebBrowser()
        Me._wbRoot.Size = New Size(30, 30)
        Me._wbRoot.ObjectForScripting = Me
        Me._wbRoot.IsWebBrowserContextMenuEnabled = False
        Me._wbRoot.AllowWebBrowserDrop = False
        Me._wbRoot.ScrollBarsEnabled = False
        Me._wbRoot.WebBrowserShortcutsEnabled = False
        Me._wbRoot.TabStop = False
        Me._wbRoot.Dock = DockStyle.Fill
        Me.Controls.Add(Me._wbRoot)

        Dim t_swfp As String = Path.Combine(Application.StartupPath, "Root/Root.html")
        Me._wbRoot.Navigate(t_swfp)
    End Sub

    Private Sub p_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        'Me._wbRoot.Document.InvokeScript("p_fl_SetText")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me._wbRoot.Document.InvokeScript("p_flas3_Call", New Object() {"flas3", "~~"})
        'Me._wbRoot.Document.InvokeScript("alert", New Object() {"~~~~~~"})
    End Sub
End Class
