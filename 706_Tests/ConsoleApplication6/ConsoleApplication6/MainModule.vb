Module MainModule
    '
    Public Sub Main()
        Dim t_name As String = Nothing
        p_Set_Name(t_name)
        Console.WriteLine(t_name)


        'tools.tt()

        ''Dim tools As New CaseByUtil()

        'Dim ms As New Math()

        'Dim tools As New CaseRollTek()

        CaseRollTek.Log("Power")

        Dim t_h As New Human("HobisJung", 35)
        t_h.Print()

    End Sub

    '
    Private Sub p_Set_Name(ByRef name As String)
        name = "HobisJung"
    End Sub
End Module

Public Structure Human
    Public Sub New( _
            ByVal name As String, _
            ByVal age As Integer)
        Me._name = name
        Me._age = age
    End Sub

    Private _name As String
    Public Property Name() As String
        Get
            Return Me._name
        End Get
        Set(value As String)
        End Set
    End Property

    Private _age As Integer
    Public Property Age() As Integer
        Get
            Return Me._age
        End Get
        Set(ByVal value As Integer)
        End Set
    End Property

    Public Sub Print()
        Console.WriteLine("Name: " & Me._name & ", " & "Age: " & Me._age)
    End Sub
End Structure

Module CaseRollTek
    Public Sub Log(ByVal msg As String)
        Console.WriteLine("msg: " & msg)
    End Sub
End Module


'
Public NotInheritable Class CaseByUtil
    Private Sub New()
        '
    End Sub

    Public Shared Sub Log(ByVal msg As String)
        Console.WriteLine("msg: " & msg)
    End Sub
End Class
