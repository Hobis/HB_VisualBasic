Imports System.IO

Module Module1
    Public Enum CaseByer
        Type1 = 1
        Type2 = 2
        Type3 = 3
        Type4 = 4
    End Enum

    '
    Public Sub Main()
        Dim t_a As Integer = 100
        Dim t_b As Integer = 100

        t_a -= t_b
        Console.WriteLine(t_a = t_b)


        Dim t_c As UInteger = 100I
        Console.WriteLine("t_c: " & t_c)


        Dim t_d As Char = "c"
        Console.WriteLine("t_d: " & t_d)


        Dim t_x As Double = Double.MaxValue
        Dim t_y As UInteger = If((t_x > UInteger.MaxValue), UInteger.MaxValue, t_x)
        Console.WriteLine("t_y: " & t_y)


        Console.WriteLine("p_GetLoaderName: " & p_GetLoaderName)
        Console.WriteLine("p_GetLoaderName: " & p_GetOverMindKillerNameToStringEdgerLogical())

        'Dim t_z As System.UInt32 = 100
        'Dim t_o As Int32 = 10
        'For i As Int32 = 900 To 100 Step -3
        '    Console.WriteLine("i: " & i)
        'Next


        Dim t_la As Int32 = 33
        Dim t_s As Int32 = 3
        Dim i As Int32 = 0
        While (i < t_la)
            Console.WriteLine("i: " & (i + 0))
            Console.WriteLine("i: " & (i + 1))
            Console.WriteLine("i: " & (i + 2))
            i += t_s
        End While


        Console.WriteLine("0x7fffffff: " + &H7FFFFFFF.ToString())
        Console.WriteLine("0x7fffffff: " + 2147483647.5.ToString())
        Console.WriteLine("0x7fffffff: " + Int32.MaxValue.ToString())

        'FileIO.ToString()

        'Dim t_aa As String = ""
        Dim t_aa As String = String.Empty
        Console.WriteLine(": " & ((t_aa = "")).ToString())

        'char.
        Dim t_bb() As Char = "HobisJung".ToCharArray()
        Dim t_cc As Int32 = t_bb.Count
        Dim j As Int32 = 0
        While (j < t_cc)
            Console.Write(": " & t_bb(j))
            j += 1
        End While
        Console.Write(vbNewLine)

        Dim t_aaa As String = "10"
        Dim t_bbb As Integer = Integer.Parse(t_aaa)
        Console.WriteLine("t_bbb: " & t_bbb)

        'Console.WriteLine(": " & (vbNull))
        'Console.WriteLine(": " & (VariantType.Null))
        'Console.WriteLine(": " & (VarType(10)))
        'Console.WriteLine(": " & Nothing.ToString)
        'Console.WriteLine(": " & (VarType(Nothing)))

        'ControlChars.

        ''Dim t_name As String = Def

        Console.WriteLine((New HobisLogical())(150))
        Console.WriteLine((New HobisLogical()).GetItem(350))

        Console.WriteLine("0"c)


        Dim t_ms As MemoryStream = New MemoryStream()
        t_ms.Close()


        Dim t_br As New BinaryReader()


    End Sub


    Private ReadOnly Property p_GetLoaderName
        Get
            Return "BaseTake Of " & "TallGates"
        End Get
    End Property


    Private Function p_GetOverMindKillerNameToStringEdgerLogical()
        Return "p_GetOverMindKillerNameToStringEdgerLogical"
    End Function
End Module


' 이것이 바로 인덱서
Public NotInheritable Class HobisLogical
    'Inherits Object Implements I

    Public Sub New()
    End Sub

    Default Public ReadOnly Property _
            GetItem(ByVal i As Integer)
        Get
            Return "Outsiders " & i
        End Get
    End Property
End Class


