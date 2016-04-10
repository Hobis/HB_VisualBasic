Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public NotInheritable Class HB_Form

    ' :: 생성자
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.p_InitOnce()
    End Sub

    ' :: 초기화
    Private Sub p_InitOnce()
        '
        Me.Text = "Caffe Mind - Ver 1.24"

        Me.AxShockwaveFlash1.LoadMovie(0, "ust.swf")
        'Me.AxShockwaveFlash1.Play()
    End Sub

    Private _tempSize As Size
    ' :: 풀스크린 설정
    Private Sub p_SetFullScreen(ByVal b As Boolean)
        If b Then
            If (Me.TopMost.Equals(False)) Then
                Me._tempSize = Me.Size
                Me.FormBorderStyle = FormBorderStyle.None
                Me.WindowState = FormWindowState.Maximized
                Me.TopMost = True
            End If
        Else
            If (Me.TopMost.Equals(True)) Then
                Me.WindowState = FormWindowState.Normal
                Me.FormBorderStyle = FormBorderStyle.Sizable
                Me.Size = Me._tempSize
                Me._tempSize = Nothing
                Me.TopMost = False
            End If
        End If
    End Sub

    ' ::
    Protected Overrides Sub OnResize(ByVal ea As EventArgs)
        MyBase.OnResize(ea)

        Dim t_p As Point = Me.Button_Full.Location
        t_p.X = Me.ClientSize.Width - (30 + 10)
        Me.Button_Full.Location = t_p

        Me.AxShockwaveFlash1.Size = Me.Size
    End Sub

    ' :: 로드
    Private Sub p_Me_Load(ByVal sender As Object, ByVal ea As EventArgs) Handles MyBase.Load
        '
    End Sub

    ' ::
    Private _isFull As Boolean = False
    Private Sub p_Button_Full_Click(sender As Object, e As EventArgs) Handles Button_Full.Click
        If (Me._isFull) Then
            Me.p_SetFullScreen(False)
            Me.Button_Full.Text = "F"
            Me._isFull = False
        Else
            Me.p_SetFullScreen(True)
            Me.Button_Full.Text = "N"
            Me._isFull = True
        End If
    End Sub

    ' ::
    Private Sub AxShockwaveFlash1_Enter(ByVal sender As Object, ByVal ea As EventArgs) Handles AxShockwaveFlash1.Enter
        'Me.AxShockwaveFlash1.W
        'Me.AxShockwaveFlash1.LoadMovie(1, "./ust.swf")
        'Me.AxShockwaveFlash1.Movie = "ust.swf"
        'Me.AxShockwaveFlash1.Play()
        'MessageBox.Show("~~~")

    End Sub

    '' ::
    'Protected Overloads Sub OnSizeChanged()
    '    Me.AxShockwaveFlash1.Size = Me.Size
    '    MessageBox.Show("~~")
    'End Sub
End Class