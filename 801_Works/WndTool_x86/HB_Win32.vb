Imports System
Imports System.Drawing
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.Diagnostics
Imports System.Windows.Forms
Imports System.Text.RegularExpressions


' # Win32 Util
Public Module HB_Win32

    Public Const GWL_EXSTYLE As Integer = -20
    Public Const GWL_STYLE As Integer = -16
    Public Const WS_EX_LAYERED As Integer = &H80000
    Public Const LWA_ALPHA As Integer = &H2

    'Public Const WM_PAINT As Integer = &HF
    Public Const WS_MAXIMIZEBOX As Integer = &H10000
    'Public Const WS_SIZEBOX As Integer = &H40000
    Public Const WS_THICKFRAME As Integer = &H40000
    'Public Const WS_BORDER As Integer = &H800000


    ' ::
    <DllImport("user32.dll", _
        EntryPoint:="WindowFromPoint", _
        CharSet:=CharSet.Auto, _
        SetLastError:=True)> _
    Public Function WindowFromPoint(ByVal p As Point) As IntPtr
    End Function

    ' ::
    <DllImport("user32.dll", _
        EntryPoint:="GetParent", _
        CharSet:=CharSet.Auto, _
        SetLastError:=True)> _
    Public Function GetParent(ByVal hWnd As IntPtr) As IntPtr
    End Function

    ' ::
    <DllImport("user32.dll", _
        EntryPoint:="GetWindow", _
        CharSet:=CharSet.Auto, _
        SetLastError:=True)> _
    Public Function GetWindow( _
                        ByVal hWnd As IntPtr, _
                        ByVal uCmd As UInteger) As IntPtr
    End Function

    ' ::
    <DllImport("user32.dll", _
        EntryPoint:="GetWindowTextLength", _
        CharSet:=CharSet.Auto, _
        SetLastError:=True)> _
    Public Function GetWindowTextLength( _
                        ByVal hWnd As IntPtr) As Integer
    End Function

    ' ::
    <DllImport("user32.dll", _
        EntryPoint:="GetWindowText", _
        CharSet:=CharSet.Auto, _
        SetLastError:=True)> _
    Public Function GetWindowText( _
                        ByVal hWnd As IntPtr, _
                        ByVal lpString As StringBuilder, _
                        ByVal nMaxCount As Integer) As Integer
    End Function

    ' ::
    <DllImport("user32.dll", _
        EntryPoint:="SetWindowText", _
        CharSet:=CharSet.Auto, _
        SetLastError:=True)> _
    Public Function SetWindowText( _
                        ByVal hWnd As IntPtr, _
                        ByVal captio As String) As Boolean
    End Function

    ' ::
    Public Function GetWindowText_r(ByVal hWnd As IntPtr) As String
        'Dim t_l As Integer = GetWindowTextLengthW(hWnd)
        Dim t_l As Integer = 256
        Dim t_sb As StringBuilder = New StringBuilder(t_l + 1)
        GetWindowText(hWnd, t_sb, t_sb.Capacity)
        Return t_sb.ToString()
    End Function

    ' ::
    <DllImport("user32.dll", _
        EntryPoint:="GetClassName", _
        CharSet:=CharSet.Auto, _
        SetLastError:=True)> _
    Public Function GetClassName( _
                        ByVal hWnd As IntPtr, _
                        ByVal lpClassName As StringBuilder, _
                        ByVal nMaxCount As Integer) As Integer
    End Function
    Public Function GetClassName_r(ByVal hWnd As IntPtr) As String
        Dim t_l As Integer = 256
        Dim t_sb As StringBuilder = New StringBuilder(t_l + 1)
        GetClassName(hWnd, t_sb, t_sb.Capacity)
        Return t_sb.ToString()
    End Function


    ' ::
    <DllImport("user32.dll", _
        EntryPoint:="GetWindowLong", _
        CharSet:=CharSet.Auto, _
        SetLastError:=True)> _
    Public Function GetWindowLong( _
                        ByVal hWnd As IntPtr, _
                        ByVal nIndex As Integer) As Long
    End Function
    ' ::
    <DllImport("user32.dll", _
        EntryPoint:="SetWindowLong", _
        CharSet:=CharSet.Auto, _
        SetLastError:=True)> _
    Public Function SetWindowLong( _
                        ByVal hWnd As IntPtr, _
                        ByVal nIndex As Integer, _
                        ByVal dwNewLong As Long) As Long
    End Function

    ' ::
    <DllImport("user32.dll", _
        EntryPoint:="GetLayeredWindowAttributes", _
        CharSet:=CharSet.Auto, _
        SetLastError:=True)> _
    Public Function GetLayeredWindowAttributes( _
                        ByVal hWnd As IntPtr, _
                        ByRef crKey As UInteger, _
                        ByRef bAlpha As Byte, _
                        ByRef dwFlags As UInteger) As Boolean
    End Function

    ' ::
    <DllImport("user32.dll", _
        EntryPoint:="SetLayeredWindowAttributes", _
        CharSet:=CharSet.Auto, _
        SetLastError:=True)> _
    Public Function SetLayeredWindowAttributes( _
                        ByVal hWnd As IntPtr, _
                        ByVal crKey As UInteger, _
                        ByVal bAlpha As Byte, _
                        ByVal dwFlags As UInteger) As Boolean
    End Function


    ' ::
    <DllImport("user32.dll", _
        EntryPoint:="SendMessage", _
        CharSet:=CharSet.Auto, _
        SetLastError:=True)> _
    Public Function SendMessage( _
                        ByVal hWnd As IntPtr, _
                        ByVal msg As UInteger, _
                        ByVal wParam As IntPtr, _
                        ByVal lParam As IntPtr) As IntPtr
    End Function



    ' ::
    <DllImport("user32.dll", _
        EntryPoint:="GetWindowThreadProcessId", _
        CharSet:=CharSet.Auto, _
        SetLastError:=True)> _
    Public Function GetWindowThreadProcessId( _
                        ByVal hWnd As IntPtr, _
                        ByRef lpdwProcessId As UInteger) As UInteger
    End Function


    <StructLayout(LayoutKind.Sequential)> _
    Public Structure Rect
        Public Left As Integer
        Public Top As Integer
        Public Right As Integer
        Public Bottom As Integer
        '
        Public Overrides Function ToString() As String
            Dim t_rv As String = _
                "Left=" & Me.Left & ", " &
                "Top=" & Me.Top & ", " &
                "Right=" & Me.Right & ", " &
                "Bottom=" & Me.Bottom
            Return t_rv
        End Function

        'Public Shared Function ToRect(ByVal str As String) As Rect
        '    Dim t_rv As Rect = New Rect()
        '    Dim t_mat As Match = Regex.Match(str, _
        '        "Left=(\d+), Top=(\d+), Right=(\d+), Bottom=(\d+)")
        '    t_rv.Left = t_mat.Groups(1).Value
        '    t_rv.Top = t_mat.Groups(2).Value
        '    t_rv.Right = t_mat.Groups(3).Value
        '    t_rv.Bottom = t_mat.Groups(4).Value
        '    Return t_rv
        'End Function
    End Structure

    ' ::
    <DllImport("user32.dll", _
        EntryPoint:="GetWindowRect", _
        CharSet:=CharSet.Auto, _
        SetLastError:=True)> _
    Public Function GetWindowRect( _
                        ByVal hWnd As IntPtr, _
                        ByRef lpRect As Rect) As Boolean
    End Function

    ' ::
    <DllImport("user32.dll", _
        EntryPoint:="MoveWindow", _
        CharSet:=CharSet.Auto, _
        SetLastError:=True)> _
    Public Function MoveWindow( _
                        ByVal hWnd As IntPtr, _
                        ByVal x As Integer, _
                        ByVal y As Integer, _
                        ByVal w As Integer, _
                        ByVal h As Integer, _
                        ByVal bRepaint As Boolean) As Boolean
    End Function




    ' 1 
    Public Const HWND_BOTTOM As Integer = 1
    ' 2 
    Public Const HWND_NOTOPMOST As Integer = -2
    ' 3 
    Public Const HWND_TOP As Integer = 0
    ' 4 
    Public Const HWND_TOPMOST As Integer = -1

    ' 1 
    Public Const SWP_ASYNCWINDOWPOS As Integer = &H4000
    ' 2
    Public Const SWP_DEFERERASE As Integer = &H2000
    ' 3 
    Public Const SWP_DRAWFRAME As Integer = &H20
    ' 4 
    Public Const SWP_FRAMECHANGED As Integer = &H20
    ' 5 
    Public Const SWP_HIDEWINDOW As Integer = &H80
    ' 6 
    Public Const SWP_NOACTIVATE As Integer = &H10
    ' 7 
    Public Const SWP_NOCOPYBITS As Integer = &H100
    ' 8 
    Public Const SWP_NOMOVE As Integer = &H2
    ' 9 
    Public Const SWP_NOOWNERZORDER As Integer = &H200
    ' 10 
    Public Const SWP_NOREDRAW As Integer = &H8
    ' 11 
    Public Const SWP_NOREPOSITION As Integer = &H200
    ' 12 
    Public Const SWP_NOSENDCHANGING As Integer = &H400
    ' 13 
    Public Const SWP_NOSIZE As Integer = &H1
    ' 14 
    Public Const SWP_NOZORDER As Integer = &H4
    ' 15 
    Public Const SWP_SHOWWINDOW As Integer = &H40



    ' ::
    <DllImport("user32.dll", _
        EntryPoint:="SetWindowPos", _
        CharSet:=CharSet.Auto, _
        SetLastError:=True)> _
    Public Function SetWindowPos( _
                        ByVal hWnd As IntPtr, _
                        ByVal hWndInsertAfter As IntPtr, _
                        ByVal x As Integer, _
                        ByVal y As Integer, _
                        ByVal cx As Integer, _
                        ByVal cy As Integer, _
                        ByVal uFlags As UInteger) As Boolean
    End Function

    ' ::
    <DllImport("user32.dll", _
        EntryPoint:="InvalidateRect", _
        CharSet:=CharSet.Auto, _
        SetLastError:=True)> _
    Public Function InvalidateRect( _
                        ByVal hWnd As IntPtr, _
                        ByVal lpRect As IntPtr, _
                        ByVal bErase As Boolean) As Boolean
    End Function


    ' ::
    Public Function GetWindowRect_r(ByVal hWnd As IntPtr) As Rect
        Dim t_r As Rect = New Rect()
        GetWindowRect(hWnd, t_r)
        Return t_r
    End Function




    ' :: 최상위 오너핸들 가져오기
    Public Function Get_OwnerHwnd(ByVal hWnd As IntPtr) As IntPtr
        Dim t_th As IntPtr = hWnd
        Dim t_oh As IntPtr = t_th
        If (Not t_th.Equals(IntPtr.Zero)) Then
            While (True)
                t_th = HB_Win32.GetParent(t_th)
                If (t_th.Equals(IntPtr.Zero)) Then
                    Exit While
                Else
                    t_oh = t_th
                End If
            End While
        End If
        Return t_oh
    End Function


    ' :: HWnd에서 프로세스 이름 가져오기
    Public Function Get_ProcessName( _
                        ByVal hWnd As IntPtr) As String
        Dim t_rv As String = Nothing
        Try
            Dim t_pid As UInteger = 0
            Dim t_r As UInteger = GetWindowThreadProcessId(hWnd, t_pid)
            Dim t_p As Process = Process.GetProcessById(CType(t_pid, Integer), Environment.MachineName)
            'MessageBox.Show("t_pid: " & t_pid)
            'MessageBox.Show("t_r: " & t_r)
            'MessageBox.Show("t_p: " & t_p.ToString())
            t_rv = t_p.ProcessName
        Catch ex As Exception
        End Try
        Return t_rv
    End Function


    ' ::
    Public Function Get_WinOpacity(ByVal hWnd As IntPtr) As Byte
        Dim t_rv As Byte
        Dim t_r As Boolean = _
            GetLayeredWindowAttributes(hWnd, 0, t_rv, LWA_ALPHA)

        If (Not t_r) Then
            t_rv = Byte.MaxValue
        End If
        Return t_rv
    End Function

    ' ::
    Public Sub Set_WinOpacity(ByVal hWnd As IntPtr, ByVal b As Byte)
        SetWindowLong(hWnd, GWL_EXSTYLE, _
            GetWindowLong(hWnd, GWL_EXSTYLE) Or WS_EX_LAYERED)
        SetLayeredWindowAttributes(hWnd, 0, b, LWA_ALPHA)
    End Sub


    ' ::
    Public Function Get_MaximizeBox(ByVal hWnd As IntPtr) As Boolean
        Dim t_sv As Integer = GetWindowLong(hWnd, GWL_STYLE)
        Return ((t_sv And WS_MAXIMIZEBOX) > 0)
    End Function

    ' ::
    Public Sub Set_MaximizeBox(ByVal hWnd As IntPtr, ByVal b As Boolean)
        Dim t_sv As Integer = GetWindowLong(hWnd, GWL_STYLE)
        If (b) Then
            t_sv = t_sv Or WS_MAXIMIZEBOX
        Else
            t_sv = t_sv And (Not WS_MAXIMIZEBOX)
        End If
        SetWindowLong(hWnd, GWL_STYLE, t_sv)
    End Sub


    ' ::
    Public Function Get_ThickFrame(ByVal hWnd As IntPtr) As Boolean
        Dim t_sv As Integer = GetWindowLong(hWnd, GWL_STYLE)
        Return ((t_sv And WS_THICKFRAME) > 0)
    End Function

    ' ::
    Public Sub Set_ThickFrame(ByVal hWnd As IntPtr, ByVal b As Boolean)
        Dim t_sv As Integer = GetWindowLong(hWnd, GWL_STYLE)
        If (b) Then
            t_sv = t_sv Or WS_THICKFRAME
        Else
            t_sv = t_sv And (Not WS_THICKFRAME)
        End If
        SetWindowLong(hWnd, GWL_STYLE, t_sv)
    End Sub





















    ' ::
    'Public Sub HTest(ByVal f As Form1)
    '    'Dim t_pid As UInteger = 0
    '    'Dim t_rv As UInteger = GetWindowThreadProcessId(f.Handle, t_pid)
    '    'Dim t_p As Process = Process.GetProcessById(CType(t_pid, Integer))
    '    'MessageBox.Show("t_pid: " & t_pid)
    '    'MessageBox.Show("t_p: " & t_p.ToString())

    '    'Dim t_r As Long = GetWindowLong(f.Handle, GWL_STYLE)
    '    'SetWindowLong(f.Handle, GWL_STYLE, t_r And WS_BORDER)
    '    'MessageBox.Show(f.Opacity.ToString())
    '    'f.Opacity = 0.5

    '    'Dim t_a As Long = 100
    '    'Dim t_b As Long = 200
    '    'Dim t_c As Long = 300
    '    'Dim t_d As Long = 400
    '    'Dim t_all As Long = t_a Or t_b Or t_c Or t_d
    '    'MessageBox.Show("t_a: " & (t_all And t_a))
    '    'MessageBox.Show("t_a: " & (t_all And t_b))
    '    'MessageBox.Show("t_a: " & (t_all And t_c))
    '    'MessageBox.Show("t_a: " & (t_all And t_d))

    'End Sub




    'Public Const WS_BORDER As Integer = &H800000
    'Public Const WS_CAPTION As Integer = &HC00000



    ' = 0x00C00000,

    'WS_CHILD = 0x40000000,

    'WS_CHILDWINDOW = 0x40000000,

    'WS_CLIPCHILDREN = 0x02000000,

    'WS_CLIPSIBLINGS = 0x04000000,

    'WS_DISABLED = 0x08000000,

    'WS_DLGFRAME = 0x00400000,

    'WS_GROUP = 0x00020000,

    'WS_HSCROLL = 0x00100000,

    'WS_ICONIC = 0x20000000,

    'WS_MAXIMIZE = 0x01000000,

    'WS_MAXIMIZEBOX = 0x00010000,

    'WS_MINIMIZE = 0x20000000,

    'WS_MINIMIZEBOX = 0x00020000,

    'WS_OVERLAPPED = 0x00000000,

    'WS_OVERLAPPEDWINDOW = WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX,

    'WS_POPUP = unchecked((int)0x80000000),

    'WS_POPUPWINDOW = WS_POPUP | WS_BORDER | WS_SYSMENU,

    'WS_SIZEBOX = 0x00040000,

    'WS_SYSMENU = 0x00080000,

    'WS_TABSTOP = 0x00010000,

    'WS_THICKFRAME = 0x00040000,

    'WS_TILED = 0x00000000,

    'WS_TILEDWINDOW = WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX,

    'WS_VISIBLE = 0x10000000,

    'WS_VSCROLL = 0x00200000;
End Module