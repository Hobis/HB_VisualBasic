Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Threading


Public Class MainForm
    ' ::
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.p_InitOnce()
    End Sub

    Private Shared _b As Boolean = True

    ' ::
    Private Sub p_InitOnce()
        Me.Text = "TestOver Ver 1.00"
        Me.ClientSize = New Size(800, 600)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.AutoSizeMode = AutoSizeMode.GrowAndShrink
        Me.MaximizeBox = False
        Me.WebBrowser1.Navigate("Main.html")

        'If (_b) Then
        '    Me.Timer1.Site = Me
        '    Me.Timer1.Interval = 3000
        '    Me.Timer1.Start()
        '    _b = False
        'End If



    End Sub

    ' ::
    Private Sub p_Me_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'Me.FolderBrowserDialog1.ShowDialog(Me)
        '//Thread.Sleep(10000)
    End Sub

    ' ::
    Private Sub p_Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Timer1.Stop()
        'MessageBox.Show(Me, "내용", "타이틀")
        Dim t_ As New MainForm()
        't_.ShowDialog(Me)
        't_.Show()
        'Me.FolderBrowserDialog1.ShowDialog(Me)
        p_Me_Load(Me, Nothing)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.FolderBrowserDialog1.ShowDialog(Me)
    End Sub
End Class