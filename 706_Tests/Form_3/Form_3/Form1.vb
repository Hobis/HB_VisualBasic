Public Class Form1



    Private Const _TITLE_NAME = "HobisWin Ver 1.0"

    ' # 처음 한번 초기화
    Private Sub p_InitOnce()
        Me.AutoSizeMode = AutoSizeMode.GrowAndShrink
        Me.MaximizeBox = False
        Me.Width = 700
        Me.Height = 600
        Me.Text = _TITLE_NAME

    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
