Imports System
Imports System.IO
Imports System.Net


' #
Public Module MainStarter
    '
    Public Sub Main()
        'Dim t_hbt As New HB_Test("HobisJung")
        'Console.WriteLine(": " & t_hbt.Name)
        'Console.WriteLine("당신은 맴버였나요?: " & t_hbt.IsMember)


        'Dim t_bl As Integer = 100000
        'Dim t_bytes(t_bl) As Byte
        'For t_i As Integer = 0 To t_bytes.Length - 1 Step 1
        '    t_bytes(t_i) = &H10
        'Next

        'Console.WriteLine("억번 우습내요 ㅋㅋ")


        p_UrlLoad()

    End Sub

    '
    Private Sub p_UrlClose( _
            ByRef wreq As WebRequest, _
            ByRef wres As WebResponse, _
            ByRef stream As Stream, _
            ByRef sr As StreamReader)
        If (Not Object.Equals(sr, Nothing)) Then
            sr.Close()
            sr = Nothing
        End If
        If (Not Object.Equals(stream, Nothing)) Then
            stream.Close()
            stream = Nothing
        End If
        If (Not Object.Equals(wres, Nothing)) Then
            wres.Close()
            wres = Nothing
        End If
        If (Not Object.Equals(wreq, Nothing)) Then
            wreq = Nothing
        End If
    End Sub

    '
    Private Sub p_UrlOpen( _
            ByRef wreq As WebRequest, _
            ByRef wres As WebResponse, _
            ByRef stream As Stream, _
            ByRef sr As StreamReader, _
            ByVal url As String)
        Try
            wreq = WebRequest.Create(url)
            wres = wreq.GetResponse()
            stream = wres.GetResponseStream()
            sr = New StreamReader(stream)
        Catch ex As Exception
        End Try
    End Sub

    '
    Private Sub p_UrlLoad()
        Dim t_wreq As WebRequest = Nothing
        Dim t_wres As WebResponse = Nothing
        Dim t_stream As Stream = Nothing
        Dim t_sr As StreamReader = Nothing

        p_UrlOpen(t_wreq, t_wres, t_stream, t_sr, _
            "http://msdn.microsoft.com/ko-kr/library/456dfw4f(v=vs.110).aspx?cs-save-lang=1&cs-lang=vb#code-snippet-15")

        Try
            While (t_sr.Peek() >= 0)
                Dim t_str As String = t_sr.ReadLine()
                If (t_str.IndexOf("Microsoft") > -1) Then
                    Console.WriteLine("검색어 Microsoft가 있는 텍스트 라인: " & t_str)
                End If
            End While
        Catch ex As Exception
        End Try

        p_UrlClose(t_wreq, t_wres, t_stream, t_sr)

    End Sub

End Module

' #
Public NotInheritable Class HB_Test
    ' ::
    Public Sub New(ByVal name As String)
        Me._name = name
    End Sub

    ' ::
    Private _name As String = Nothing
    Public ReadOnly Property Name As String
        Get
            Return Me._name
        End Get
    End Property

    ' ::
    Public ReadOnly Property IsMember As Boolean
        Get
            Dim t_rv As Boolean = False
            If (Me._name.Equals("HobisJung") Or _
                Me._name.Equals("Pook61") Or _
                Me._name.Equals("Inoff79")) Then
                t_rv = True
            End If
            Return t_rv
        End Get
    End Property

End Class