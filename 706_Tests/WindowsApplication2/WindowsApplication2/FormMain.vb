Imports System.Threading

Public Class FormMain

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub



    Private Const _AppName As String = "종근당 의약품 일련번호 시스템"
    Private Const _VerStr As String = "1.00b"
    Private Const _TitleName As String = _AppName & " " & _VerStr

    ' ::
    Private Sub p_MeLoad( _
                    ByVal sender As Object, _
                    ByVal e As EventArgs) Handles MyBase.Load
        '
        '
        '
        Me.Text = _TitleName



        Dim t_cl As _Coller = _
            Sub()
                Dim i As Integer = 0
                While (i < 2)
                    Thread.Sleep(1000)
                    i += 1
                End While
                Me.Invoke( _
                    Sub()
                        MessageBox.Show(1004.ToString())
                    End Sub)
            End Sub

        t_cl.BeginInvoke(Nothing, Nothing)
    End Sub


    Private Sub Button1_Click( _
                    ByVal sender As Object, _
                    ByVal e As EventArgs) Handles Button1.Click

    End Sub



    Private Delegate Sub _Coller()






End Class
