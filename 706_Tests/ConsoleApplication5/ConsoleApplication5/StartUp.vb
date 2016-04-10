Module StartUp

    Public Sub Main()
        Dim t_i As Integer = 0
        Do While t_i < 100000
            Console.WriteLine("t_i: " & t_i.ToString())
            t_i += 1
        Loop
    End Sub

End Module
