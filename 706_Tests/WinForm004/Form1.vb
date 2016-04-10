Imports System
Imports System.Drawing
Imports System.Diagnostics
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports System.Text
Imports System.Threading


' # Form Code
Public NotInheritable Class Form1

    ' :: 초기화
    Private Sub p_Me_Load( _
                    ByVal sender As Object, _
                    ByVal ea As EventArgs) Handles MyBase.Load

        Me.Text = "WinForm004 Ver 1.00"
        Me.ClientSize = New Size(400, 400)
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New Point(100, 100)
        'Me.AutoSizeMode = AutoSizeMode.GrowAndShrink
        'Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        'Me.DoubleBuffered = True

        'Me.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, True)
        'Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint Or _
        '            ControlStyles.UserPaint Or ControlStyles.ResizeRedraw, True)
        'Me.UpdateStyles()

        'Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
        Me.UpdateStyles()


    End Sub


    Private _count As Integer = 0
    'Protected Overrides Sub OnPaint(ByVal pea As PaintEventArgs)


    '    pea.Graphics.Clear(Color.Red)

    '    ' Create string to draw.
    '    Dim drawString As String = "Sample Text " & _count
    '    _count += 1

    '    ' Create font and brush.
    '    Dim drawFont As New Font("Arial", 16)
    '    Dim drawBrush As New SolidBrush(Color.Black)

    '    ' Create rectangle for drawing.
    '    Dim x As Single = 150.0F
    '    Dim y As Single = 150.0F
    '    Dim width As Single = 200.0F
    '    Dim height As Single = 50.0F
    '    Dim drawRect As New RectangleF(x, y, width, height)


    '    ' Draw rectangle to screen.
    '    Dim blackPen As New Pen(Color.Black)
    '    pea.Graphics.DrawRectangle(blackPen, x, y, width, height)
    '    pea.Graphics.FillRectangle(New SolidBrush(Color.Gold), x, y, width, height)

    '    ' Set format of string.
    '    Dim drawFormat As New StringFormat
    '    drawFormat.Alignment = StringAlignment.Center

    '    ' Draw string to screen.
    '    pea.Graphics.DrawString(drawString, drawFont, drawBrush, _
    '                            drawRect, drawFormat)

    '    MyBase.OnPaint(pea)
    'End Sub

    Public Sub DrawString(ByVal g As Graphics, ByVal txt As String)
        'Dim g As Graphics = Me.CreateGraphics()
        'g.Clear(Me.BackColor)
        g.Clear(Color.Red)

        Dim drawFont As New Font("Arial", 16)
        Dim drawBrush As SolidBrush = New SolidBrush(Color.Black)
        Dim x As Single = 150.0
        Dim y As Single = 150.0
        Dim drawFormat As StringFormat = New StringFormat()
        g.DrawString(txt, drawFont, drawBrush, _
                                    x, y, drawFormat)
        drawFont.Dispose()
        drawBrush.Dispose()
        g.Dispose()
    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        'Me.DrawString()
    End Sub

    Protected Overrides Sub OnPaint(ByVal pea As PaintEventArgs)
        'MyBase.OnPaint(pea)
        'Me.DrawString(pea.Graphics, "쉐리 포레버" & _count)
        Me.DrawString(Me.CreateGraphics(), "쉐리 포레버" & _count)
        _count += 10000
        MyBase.OnPaint(pea)
    End Sub

End Class
