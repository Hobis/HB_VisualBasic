Imports System.Runtime.InteropServices
Imports System.Text


Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim t_sb As StringBuilder = New StringBuilder(Byte.MaxValue)
        p_GetClassName_Core(Me.Handle, t_sb, Byte.MaxValue)
        MessageBox.Show(t_sb.ToString())
    End Sub


    ' -
    Private Const _user32_dll As String = "user32.dll"
    <DllImportAttribute(_user32_dll, EntryPoint:="GetClassName", CharSet:=CharSet.Auto, SetLastError:=True)> _
    Private Shared Function p_GetClassName_Core( _
                                ByVal hWnd As IntPtr, _
                                ByVal lpClassName As StringBuilder, _
                                ByVal nMaxCount As Integer) As Integer
    End Function

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub
End Class
