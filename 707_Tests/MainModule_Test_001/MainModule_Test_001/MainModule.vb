Imports System.Text

'
Public Module MainModule
    Public Sub Main()
        Dim t_u As New User("hobis-j", "123456789", "HobisJung", 35)

        Console.WriteLine(t_u)
        Console.ReadLine()

    End Sub
End Module

'
Public Structure User
    Public Sub New( _
        ByVal id As String, _
        ByVal pw As String, _
        ByVal name As String, _
        ByVal age As Integer)

        Me._id = id
        Me._pw = pw
        Me._name = name
        Me._age = age
    End Sub

    Private _id As String
    Public ReadOnly Property Id As String
        Get
            Return Me._id
        End Get
    End Property

    Private _pw As String
    Public ReadOnly Property Pw As String
        Get
            Return Me._pw
        End Get
    End Property

    Private _name As String
    Public ReadOnly Property Name As String
        Get
            Return Me._name
        End Get
    End Property

    Private _age As Integer
    Public ReadOnly Property Age As Integer
        Get
            Return Me._age
        End Get
    End Property

    '
    Public Overrides Function ToString() As String
        Dim t_rv As New StringBuilder()

        t_rv.Append("Id: " & Me._id)
        t_rv.Append(", ")
        t_rv.Append("Pw: " & Me._pw)
        t_rv.Append(", ")
        t_rv.Append("Name: " & Me._name)
        t_rv.Append(", ")
        t_rv.Append("Age: " & Me._age)

        Return t_rv.ToString()
    End Function
End Structure

