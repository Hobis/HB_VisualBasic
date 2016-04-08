Public Class Form1

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    ' ::
    Private Sub p_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Dim t_n As Integer = 100
        MessageBox.Show(t_n.ToString("d6"))
        'MessageBox.Show(Hex())
    End Sub

End Class
