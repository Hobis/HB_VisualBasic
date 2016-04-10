Public Module Hobis

    Public Sub Main()
        Dim t_names() As String = {"Hobis_1", "Hobis_2", "Hobis_3", "Hobis_4"}
        Dim t_la As Integer = t_names.Length
        Dim i As Integer

        i = 0
        While (i < t_la)
            Dim t_name As String = t_names(i)

            Console.WriteLine("t_name: " & t_name)

            i += 1
        End While




        'Dim t_la As Integer = 3
        'Dim t_lb As Integer = 3
        'Dim i As Integer
        'Dim j As Integer

        'i = 0
        'While (i < t_la)
        '    j = 0
        '    While (j < t_lb)
        '        Console.WriteLine("i: " & i)
        '        Console.WriteLine("j: " & j)

        '        j += 1
        '    End While

        '    i += 1
        'End While




        'If (t_a = t_b) = 1 Then
        '    Console.WriteLine(t_a.Equals(t_b))

        'End If

        't_a = t_b
        'Console.WriteLine((t_a = t_b))
    End Sub

End Module
