Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public NotInheritable Class Dialog1

    Private Sub p_Button_Close_Click( _
                    ByVal sender As Object, _
                    ByVal ea As EventArgs) Handles Button_Close.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    ' ::
    Private Sub p_Dialog1_Load( _
                    ByVal sender As Object, _
                    ByVal ea As EventArgs) Handles MyBase.Load
        Me.Text = "About"
        Me.StartPosition = FormStartPosition.CenterParent
    End Sub
End Class
