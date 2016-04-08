Imports System.Runtime.CompilerServices

Public Module GlobalProxy

    <ExtensionAttribute> _
    Public Sub fPrint(ByVal tstr As String)
        Console.WriteLine(tstr)
    End Sub

End Module
