Imports System
Imports System.Drawing
Imports System.Windows.Forms


Public NotInheritable Class MainForm
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.p_InitOnce()
    End Sub

    ' ::
    Private Sub p_InitOnce()
        Dim t_s As Size = Me.ClientSize
        t_s.Width = 800
        t_s.Height = 600
        Me.ClientSize = t_s
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Text = "BJ용연향 멘트 관리툴 Ver 1.21"

    End Sub

    ' ::
    Private Sub p_This_Load(ByVal sender As Object, ByVal ea As EventArgs) Handles MyBase.Load

    End Sub

End Class