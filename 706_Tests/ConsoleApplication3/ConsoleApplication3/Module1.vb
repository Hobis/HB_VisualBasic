Imports System.Runtime.CompilerServices

Public Module Module1

    <ExtensionAttribute> _
    Private Sub p_Print(ByVal tStr As String)
        Console.WriteLine(tStr)
    End Sub

    Public Sub Main()
        Call "희범이 입니다".p_Print()
    End Sub

End Module

Public Module KKMS

    Public Sub Roo()
        'Call "희범이 입니다".p_Print()
        Call "희범이 입니다".fPrint()
    End Sub

End Module

