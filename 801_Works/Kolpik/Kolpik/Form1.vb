Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports WndForms = System.Windows.Forms

' # Form Code
Public NotInheritable Class Form1

    ' :: 초기화
    Private Sub p_Me_Load( _
                    ByVal sender As Object, _
                    ByVal ea As EventArgs) Handles MyBase.Load

        Me.Text = "Kolpik Ver 1.02b"
        'Me.ClientSize = New Size(300, 360)
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New Point(100, 100)
        'Me.AutoSizeMode = AutoSizeMode.GrowAndShrink
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False

        '
        Me.PictureBox2.Image = Nothing

        '
        AddHandler Me.PictureBox2.MouseUp, AddressOf Me.p_PictureBox2_MouseUp
        AddHandler Me.PictureBox2.MouseMove, AddressOf Me.p_PictureBox2_MouseMove
        AddHandler Me.PictureBox2.MouseDown, AddressOf Me.p_PictureBox2_MouseDown
    End Sub

    ' ::
    Private Sub p_Pic2Setting()

    End Sub

    ' ::
    Private Sub p_Me_Shown( _
                    ByVal sender As Object, _
                    ByVal ea As EventArgs) Handles MyBase.Shown

        Me.TopMost = True
    End Sub

    ' ::
    Private Sub p_Me_Deactivate( _
                    ByVal sender As Object, _
                    ByVal ea As EventArgs) Handles MyBase.Deactivate

        If (Me._isDown) Then
            Me.PictureBox2.Image = Nothing
            Me._isDown = False
        End If
    End Sub

    ' ::
    Private Sub p_ColorUpdate()
        Dim t_mcp As Point = WndForms.Cursor.Position
        Dim t_col As Color = p_Win32_GetPixelColor(t_mcp.X, t_mcp.Y)
        Me.Label1.Text = p_HexConverter(t_col)
        Me.PictureBox2.BackColor = t_col
    End Sub

    ' ::
    Private Sub p_PictureBox2_MouseUp( _
                    ByVal sender As Object, _
                    ByVal mea As MouseEventArgs)

        If (Me._isDown) Then
            Me.p_ColorUpdate()
            Me.p_Me_Deactivate(Nothing, Nothing)
        End If
    End Sub

    ' ::
    Private Sub p_PictureBox2_MouseMove( _
                    ByVal sender As Object, _
                    ByVal mea As MouseEventArgs)
    End Sub


    Private _isDown As Boolean = False
    ' ::
    Private Sub p_PictureBox2_MouseDown( _
                    ByVal sender As Object, _
                    ByVal mea As MouseEventArgs)

        If (mea.Button.Equals(MouseButtons.Left)) Then
            Me._isDown = True
            Me.PictureBox2.Image = My.Resources.MIcon01
        End If
    End Sub






#Region "Win32Functions"

    '//apis
    <DllImportAttribute("user32.dll", _
        EntryPoint:="GetDC", _
        CharSet:=CharSet.Auto, _
        SetLastError:=True)> _
    Private Shared Function p_Win32_GetDC(ByVal hwnd As IntPtr) As IntPtr
    End Function

    <DllImportAttribute("user32.dll", _
        EntryPoint:="ReleaseDC", _
        CharSet:=CharSet.Auto, _
        SetLastError:=True)> _
    Private Shared Function p_Win32_ReleaseDC( _
                                ByVal hwnd As IntPtr, _
                                ByVal hdc As IntPtr) As Int32
    End Function

    <DllImportAttribute("gdi32.dll", _
        EntryPoint:="GetPixel", _
        CharSet:=CharSet.Auto, _
        SetLastError:=True)> _
    Private Shared Function p_Win32_GetPixel( _
                                ByVal hdc As IntPtr, _
                                ByVal nXPos As Integer, _
                                ByVal nYPos As Integer) As UInteger
    End Function

    '//methods
    Private Shared Function p_Win32_GetPixelColor( _
                                ByVal x As Integer, _
                                ByVal y As Integer) As System.Drawing.Color

        Dim t_hdc As IntPtr = p_Win32_GetDC(IntPtr.Zero)
        Dim t_pixel As UInteger = p_Win32_GetPixel(t_hdc, x, y)
        p_Win32_ReleaseDC(IntPtr.Zero, t_hdc)
        Return Color.FromArgb(CInt(t_pixel And &HFF), _
                              CInt(t_pixel And &HFF00) >> 8, _
                              CInt(t_pixel And &HFF0000) >> 16)
    End Function

    '
    Private Shared Function p_HexConverter(ByVal c As Color) As String
        Return "#" & c.R.ToString("x2") & c.G.ToString("x2") & c.B.ToString("x2")
    End Function

#End Region





    Private _aboutBox As Dialog1 = New Dialog1()
    ' :: About
    Private Sub p_Button1_Click( _
                    ByVal sender As Object, _
                    ByVal ea As EventArgs) Handles Button1.Click

        Me._aboutBox.ShowDialog(Me)
    End Sub

    ' :: Copy
    Private Sub p_Button2_Click( _
                    ByVal sender As Object, _
                    ByVal ea As EventArgs) Handles Button2.Click

        Clipboard.SetText(Me.Label1.Text)
    End Sub
End Class
