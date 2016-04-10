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
        Me.Text = "WndTool_x86 Ver 1.23"
        Me.ClientSize = New Size(400, 400)
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New Point(100, 100)
        'Me.AutoSizeMode = AutoSizeMode.GrowAndShrink
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False

        AddHandler Me.PictureBox1.MouseUp, AddressOf Me.p_PictureBox1_MouseUp
        AddHandler Me.PictureBox1.MouseMove, AddressOf Me.p_PictureBox1_MouseMove
        AddHandler Me.PictureBox1.MouseDown, AddressOf Me.p_PictureBox1_MouseDown
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

        If (Not Me.Cursor.Equals(Cursors.Default)) Then
            Try
                Me.Cursor = Cursors.Default
            Catch ex As Exception
            End Try
        End If
    End Sub


    ' - 현재 선택된 타겟의 핸들값(포인터)
    Private _thd As IntPtr

    ' ::
    Private Sub p_PictureBox1_MouseUp( _
                    ByVal sender As Object, _
                    ByVal mea As MouseEventArgs)

        Me.p_Me_Deactivate(Nothing, Nothing)

        If (mea.Button.Equals(MouseButtons.Left)) Then
            Dim t_oh As IntPtr = _
                HB_Win32.Get_OwnerHwnd(HB_Win32.WindowFromPoint(Cursor.Position))
            'If (Not t_oh.Equals(IntPtr.Zero)) Then
            If ((Not t_oh.Equals(IntPtr.Zero)) AndAlso _
                (Not t_oh.Equals(Me.Handle))) Then

                Me._thd = t_oh

                Try
                    Me.TextBox_Handle.Text = Me._thd.ToString()
                    Me.TextBox_Class.Text = HB_Win32.GetClassName_r(Me._thd)
                    Me.TextBox_Process.Text = HB_Win32.Get_ProcessName(Me._thd)
                Catch ex As Exception
                End Try

                Try
                    Me.TextBox_Caption.Text = HB_Win32.GetWindowText_r(Me._thd)
                    Me.TextBox_Opacity.Text = HB_Win32.Get_WinOpacity(Me._thd)
                Catch ex As Exception
                End Try

                Try
                    Dim t_rect As HB_Win32.Rect
                    t_rect = HB_Win32.GetWindowRect_r(Me._thd)
                    Me.TextBox_Bound_X.Text = t_rect.Left
                    Me.TextBox_Bound_Y.Text = t_rect.Top
                    Me.TextBox_Bound_W.Text = t_rect.Right - t_rect.Left
                    Me.TextBox_Bound_H.Text = t_rect.Bottom - t_rect.Top
                Catch ex As Exception
                End Try

                Try
                    Me.CheckBox_MaxBox.Checked = HB_Win32.Get_MaximizeBox(Me._thd)
                    Me.CheckBox_Resize.Checked = HB_Win32.Get_ThickFrame(Me._thd)
                Catch ex As Exception
                End Try
            End If
        End If
    End Sub

    ' ::
    Private Sub p_PictureBox1_MouseMove( _
                    ByVal sender As Object, _
                    ByVal mea As MouseEventArgs)
    End Sub

    ' ::
    Private Sub p_PictureBox1_MouseDown( _
                    ByVal sender As Object, _
                    ByVal mea As MouseEventArgs)
        If (mea.Button.Equals(MouseButtons.Left)) Then
            Try
                Me.Cursor = Cursors.Cross
            Catch ex As Exception
            End Try
        End If
    End Sub

    ' :: 초기화
    Private Sub p_Button_Clear_Click( _
                    ByVal sender As Object, _
                    ByVal ea As EventArgs) Handles Button_Clear.Click
        Me._thd = IntPtr.Zero
        Me.TextBox_Handle.Clear()
        Me.TextBox_Class.Clear()
        Me.TextBox_Process.Clear()

        '
        Me.TextBox_Caption.Clear()
        Me.TextBox_Opacity.Clear()
        Me.TextBox_Bound_X.Clear()
        Me.TextBox_Bound_Y.Clear()
        Me.TextBox_Bound_W.Clear()
        Me.TextBox_Bound_H.Clear()

        '
        Me.CheckBox_MaxBox.Checked = False
        Me.CheckBox_Resize.Checked = False
    End Sub

    ' :: 적용
    Private Sub p_Button_Apply_Click( _
                    ByVal sender As Object, _
                    ByVal ea As EventArgs) Handles Button_Apply.Click
        TaskGoing.Go(AddressOf Me.p_Apply_Go)
    End Sub


    Private Sub p_Apply_Go()
        If (Not Me._thd.Equals(IntPtr.Zero)) Then
            Try
                Dim t_caption As String = Me.TextBox_Caption.Text
                If (Not String.IsNullOrEmpty(t_caption)) Then
                    HB_Win32.SetWindowText(Me._thd, Me.TextBox_Caption.Text)
                End If
            Catch
            End Try

            Try
                Dim t_opacity As Byte = _
                    Convert.ToByte(Me.TextBox_Opacity.Text)
                HB_Win32.Set_WinOpacity(Me._thd, t_opacity)
            Catch
            End Try

            Try
                HB_Win32.MoveWindow(Me._thd, _
                    Convert.ToInt32(Me.TextBox_Bound_X.Text), _
                    Convert.ToInt32(Me.TextBox_Bound_Y.Text), _
                    Convert.ToInt32(Me.TextBox_Bound_W.Text), _
                    Convert.ToInt32(Me.TextBox_Bound_H.Text), _
                    True)
            Catch
            End Try

            Try
                HB_Win32.Set_MaximizeBox(Me._thd, Me.CheckBox_MaxBox.Checked)
            Catch
            End Try

            Try
                HB_Win32.Set_ThickFrame(Me._thd, Me.CheckBox_Resize.Checked)
            Catch
            End Try

            Try
                HB_Win32.SetWindowPos(Me._thd, HB_Win32.HWND_BOTTOM, _
                    0, _
                    0, _
                    0, _
                    0, _
                    HB_Win32.SWP_NOMOVE Or HB_Win32.SWP_NOSIZE Or HB_Win32.SWP_NOZORDER Or _
                    HB_Win32.SWP_DRAWFRAME Or HB_Win32.SWP_NOACTIVATE)
            Catch
            End Try
        End If

        TaskGoing.Kill()
    End Sub


    Private _aboutBox As Dialog1 = New Dialog1()

    ' :: 설명
    Private Sub p_Button_About_Click( _
                    ByVal sender As Object, _
                    ByVal ea As EventArgs) Handles Button_About.Click
        Me._aboutBox.ShowDialog(Me)
    End Sub

End Class



Public Module TaskGoing
    Private _th As Thread = Nothing

    Public ReadOnly Property IsAlive As Boolean
        Get
            Return (_th IsNot Nothing)
        End Get
    End Property

    Public Sub Kill()
        _th = Nothing
    End Sub

    Public Sub Go(ByVal ths As ThreadStart)
        If (_th Is Nothing) Then
            _th = New Thread(ths)
            _th.IsBackground = True
            _th.Start()
        Else
        End If
    End Sub
End Module
