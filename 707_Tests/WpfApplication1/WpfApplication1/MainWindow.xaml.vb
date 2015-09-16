Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Windows.Interop

Public NotInheritable Class MainWindow

    ' ::
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        p_InitOnce()
    End Sub

    ' ::
    Private Sub p_InitOnce()
        'MessageBox.Show(Process.GetCurrentProcess().ProcessName)

        'Dim t_np As Process = Process.GetCurrentProcess()
        'MessageBox.Show("t_np.MainWindowHandle: " & t_np.MainWindowHandle.ToString())
        'MessageBox.Show("t_np.ProcessName: " & t_np.ProcessName)
        'MessageBox.Show("t_np.MainWindowTitle: " & t_np.MainWindowTitle)
        'MessageBox.Show("t_np.MainModule.GetHashCode: " & t_np.MainModule.GetHashCode)
        'Dim t_dps As Process() = Process.GetProcesses()

        'Return

        Dim t_np As Process = Process.GetCurrentProcess()
        Dim t_dps As Process() = Process.GetProcesses()
        For Each t_dp As Process In t_dps
            If (Not t_np.MainWindowHandle.Equals(t_dp.MainWindowHandle)) Then
                If (t_np.ProcessName.Equals(t_dp.ProcessName)) Then
                    If (t_np.MainModule.GetHashCode.Equals(t_dp.MainModule.GetHashCode)) Then
                        Me.Close()
                    End If
                End If
            End If
        Next
    End Sub



    ' ::
    Private Sub p_Me_Loaded(ByVal sender As Object, ByVal rea As RoutedEventArgs)
        Me.Title = "ClassByPasser Ver 1.0b"
        Me.TextBox1.Clear()

        'Program.Assembly()
        'TypeOf Progra

        'Dim t_ass As Assembly = Assembly.GetEntryAssembly()
        'MessageBox.Show(t_ass.GetType().GUID.ToString())

        'Dim t_wih As WindowInteropHelper = New WindowInteropHelper(Me)
        'MessageBox.Show(t_wih.Handle)
        'Dim t_cn As String = p_GetClassName(t_wih.Handle)
        'MessageBox.Show(t_cn)
        'MessageBox.Show(Process.GetCurrentProcess().ProcessName)
        'Dim t_cn As String = p_GetClassName(Process.GetCurrentProcess().MainWindowHandle))
        'MessageBox.Show(t_cn)

        Dim t_np As Process = Process.GetCurrentProcess()
        Dim t_dps As Process() = Process.GetProcesses()
        For Each t_dp As Process In t_dps
            If (Not t_np.MainWindowHandle.Equals(t_dp.MainWindowHandle)) Then
                If (t_np.MainWindowTitle.Equals(t_dp.MainWindowTitle)) Then
                    'Dim t_npcn As String = p_GetClassName(t_np.MainWindowHandle)
                    'Dim t_dpcn As String = p_GetClassName(t_dp.MainWindowHandle)
                    'Me.TextBox1.AppendText("t_npcn: " & t_npcn & vbNewLine)
                    'Me.TextBox1.AppendText("t_dpcn: " & t_dpcn & vbNewLine)
                    Me.Close()
                End If
            End If
        Next

    End Sub


    ' ::
    Private Sub p_Clear_Click(ByVal sender As Object, ByVal rea As RoutedEventArgs)
        Me.TextBox1.Clear()
    End Sub

    ' ::
    Private Sub p_Start_Click(ByVal sender As Object, ByVal rea As RoutedEventArgs)
        'Dim t_wih As WindowInteropHelper = New WindowInteropHelper(Me)
        'MessageBox.Show(t_wih.Handle)

        'Dim t_p As Process = Process.GetCurrentProcess()
        'MessageBox.Show(t_p.Handle.ToString)
        'Dim t_cn As String = MSysUtil.fGetClassName(New IntPtr(991270))
        'MessageBox.Show(t_cn)
    End Sub



























    ' ::
    Private Function p_GetClassName(ByVal hWnd As IntPtr) As String
        Dim t_rv As String = Nothing
        Dim t_sb As StringBuilder = New StringBuilder(Byte.MaxValue)

        Try
            p_GetClassName_Core(hWnd, t_sb, Byte.MaxValue)
        Catch ex As Exception
        End Try

        t_rv = t_sb.ToString()
        t_sb = Nothing

        Return t_rv
    End Function

    ' -
    Private Const _user32_dll As String = "user32.dll"
    <DllImportAttribute("user32.dll", EntryPoint:="GetClassName", CharSet:=CharSet.Auto, SetLastError:=True)> _
    Private Shared Function p_GetClassName_Core( _
                                ByVal hWnd As IntPtr, _
                                ByVal lpClassName As StringBuilder, _
                                ByVal nMaxCount As Integer) As Integer
    End Function
End Class





Friend Module MSysUtil

    ' ::
    Friend Function fGetIsStr(ByRef str As String, ByVal v As String) As Boolean
        If (v Is Nothing) Then
            Return False
        Else
            str = v
            Return True
        End If
    End Function


    ' ::
    Friend Function fGetHandle() As IntPtr
        Dim t_p As Process = Process.GetCurrentProcess()
        MessageBox.Show(t_p.Handle)
        Return t_p.Handle
    End Function


    ' ::
    Friend Function fGetClassName(ByVal hWnd As IntPtr) As String
        Dim t_rv As String = Nothing

        Try
            Dim t_sb As StringBuilder = New StringBuilder()
            p_GetClassName_Core(hWnd, t_sb, Byte.MaxValue)
            MessageBox.Show(t_sb.Length.ToString())
            t_rv = t_sb.ToString()
            t_sb = Nothing
        Catch
            MessageBox.Show("Error")
        End Try

        Return t_rv
    End Function


    ' -
    Private Const _user32_dll As String = "user32.dll"
    <DllImportAttribute(_user32_dll, EntryPoint:="GetClassName", CharSet:=CharSet.Auto, SetLastError:=True)> _
    Private Function p_GetClassName_Core( _
                                ByVal hWnd As IntPtr, _
                                ByVal lpClassName As StringBuilder, _
                                ByVal nMaxCount As Integer) As Integer
    End Function

End Module
