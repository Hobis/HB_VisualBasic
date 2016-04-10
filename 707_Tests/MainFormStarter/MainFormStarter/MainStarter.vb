Imports Microsoft.VisualBasic
Imports System
Imports System.Text
Imports System.Windows.Forms


' #
Public Module MainStarter
    ' ::
    Public Sub Main()
        'Dim t_b As Boolean = (1.Equals(1))

        'Dim t_x As New String("~~~~")
        'Dim t_y As New String("~~~~")
        'Dim t_c As Boolean = (t_x Is t_y)

        ''MsgBox(": " & t_b)
        'MsgBox(": " & t_c)
        'Sub()

        'Dim t_sb As StringBuilder()
        'Dim t_la As Integer = 100
        'Dim i As Integer = 0
        'While (i < t_la)
        '    Console.WriteLine(":: " & (i = 3))
        '    i += 1
        'End While

        'Beep()
        'Beep()
        'Beep()

        'Dim t_test As String = "[[[[[[[[["
        'Dim t_aa As String = IIf(t_test.Equals("aaaa"), "Target", "Off")
        ''MsgBox(":: " & t_aa)

        'Dim t_a As Boolean
        't_a = (1 = 2)
        'Console.WriteLine("==: " & t_a)


        'Dim t_stro As Object = "``````````````"
        ''Dim t_strs As String = DirectCast(t_stro, Integer)
        ''Dim t_strs As String = TryCast(t_stro, Double)
        ''Console.WriteLine(":: " & t_strs)
        'Try
        '    Dim t_strs As String = DirectCast(t_stro, Integer)
        'Catch e As Exception
        '    Console.WriteLine("캐스팅이 잘못 되었습니다.")
        'End Try

        'Dim t_o As Object = 300
        'Dim t_p As Integer
        'Try
        '    t_p = DirectCast(t_o, Integer)
        '    Console.WriteLine(t_p.ToString())
        'Catch e As Exception

        'End Try

        'Dim t_a As String = "0123456"
        'Console.WriteLine(Left(t_a, 3))

        'MainUtil.Print()

        'Dim tb As New MainUtil()

        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Dim t_form As New MainForm()
        Application.Run(t_form)
    End Sub
End Module


'Public NotInheritable Class MainUtil
'    Private Sub New()

'    End Sub

'    ' ::
'    Public Shared Sub Print()
'        Console.WriteLine("~~~~~")
'    End Sub
'End Class
