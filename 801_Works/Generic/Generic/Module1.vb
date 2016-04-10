Module Module1

    Sub Main()
        Dim t_von As UInteger = 100

        p_CaseBy(t_von)
    End Sub


    Private Sub p_CaseBy(Of t)(ByVal n As t)
        Console.WriteLine(TypeOf n Is UInteger)
    End Sub

End Module
