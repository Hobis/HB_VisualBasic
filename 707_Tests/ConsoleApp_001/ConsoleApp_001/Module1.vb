Public NotInheritable Class FocusTask
    ' # 생성자
    Public Sub New(ByVal name As String)
        Me._name = name

    End Sub

    Private _name As String


    Public Sub GoGo()
        Console.WriteLine("Me._name: " & Me._name)
    End Sub

End Class

Module Module1

    Public Sub Main()
        Console.WriteLine("Hello VisualBasic")

        Dim t_ft As FocusTask = New FocusTask("Hobis")
        t_ft.GoGo()

    End Sub

End Module

