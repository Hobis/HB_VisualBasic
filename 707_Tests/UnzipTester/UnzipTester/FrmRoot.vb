Imports System.ComponentModel
Imports Ionic.Zip
Imports System.IO
Imports System.Threading
Imports System.Text

Public NotInheritable Class FrmRoot

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub


    Private Sub p_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "UnzipTester~~~~"

        Dim t_sr As Rectangle = Screen.PrimaryScreen.Bounds
        Dim t_s As Size = New Size(t_sr.Width - (500 + 100), t_sr.Height - (600 + 100))
        Me.Location = t_s

        MUpdater.fInit(CType(AddressOf p_MUpdater_CallBack, Action(Of Object())), _
                        "http://amanta.iptime.org/update/update.zip", _
                            Path.Combine(Environment.CurrentDirectory, "_Test"), "Root")
    End Sub

    Private Sub p_MUpdater_CallBack(args() As Object)
        If args.Length > 0 Then
            Dim t_ct As String = DirectCast(args(0), String)
            If Not t_ct Is Nothing Then
                Select Case t_ct
                    Case MUpdater.CallBackType_AppendText
                        Dim t_v As String = DirectCast(args(1), String)
                        If Not t_v Is Nothing Then
                            p_TxtRoot_Append(t_v)
                        End If
                End Select
            End If
        End If
    End Sub

    Private Sub p_TxtRoot_Clear()
        If Me.InvokeRequired Then
            Me.Invoke(CType(AddressOf p_TxtRoot_Clear, MethodInvoker))
        Else
            _TxbRoot.Clear()
        End If
    End Sub

    Private Sub p_TxtRoot_Append(v As String)
        If Me.InvokeRequired Then
            Me.Invoke(CType(AddressOf p_TxtRoot_Append, Action(Of String)), New Object() {v})
        Else
            _TxbRoot.AppendText(v & vbNewLine)
        End If
    End Sub


    ' ::
    Private Sub p_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        MUpdater.fClear()
    End Sub

    ' :: 작업 시작
    Private Sub p_BtnStart_Click(sender As Object, ea As EventArgs) Handles _BtnStart.Click
        MUpdater.fStart()
    End Sub

    ' :: 작업 취소
    Private Sub p_BtnStop_Click(sender As Object, ea As EventArgs) Handles _BtnStop.Click
        MUpdater.fStop()
    End Sub

    ' :: 클리어
    Private Sub p_BtnClear_Click(sender As Object, ea As EventArgs) Handles _BtnClear.Click
        p_TxtRoot_Clear()
    End Sub

End Class
