Imports System.IO

Module Module1
    Private Sub p_FileLinePrint(ByVal filePath As String)
        ' 파일이 존재하면
        If My.Computer.FileSystem.FileExists(filePath) Then
            Dim t_sr As StreamReader = Nothing
            Try
                t_sr = My.Computer.FileSystem.OpenTextFileReader(filePath)
                While t_sr.Peek() >= 0
                    Dim t_lineStr = t_sr.ReadLine()
                    Console.WriteLine("Line At String: " & t_lineStr)
                End While
            Catch ex As Exception
                '
            Finally
                If t_sr IsNot Nothing Then
                    t_sr.Close()
                    t_sr.Dispose()
                End If
            End Try
        End If
    End Sub

    ' 
    Public Sub Main()
        'Dim t_a As Integer
        'Dim t_s As String

        p_FileLinePrint("C:\Users\Hobis-PC\Desktop\Game_Info.txt")


        'Const t_filePath As String = "C:\Users\Hobis-PC\Desktop\Game_Info.txt"
        '' 파일이 존재하면
        'If My.Computer.FileSystem.FileExists(t_filePath) Then
        '    Dim t_sr As StreamReader = Nothing
        '    Try
        '        t_sr = My.Computer.FileSystem.OpenTextFileReader(t_filePath)
        '        While t_sr.Peek() >= 0
        '            Dim t_lineStr = t_sr.ReadLine()
        '            Console.WriteLine("Line At String: " & t_lineStr)
        '        End While
        '    Catch ex As Exception
        '        '
        '    Finally
        '        If t_sr IsNot Nothing Then
        '            t_sr.Close()
        '            t_sr.Dispose()
        '        End If
        '    End Try
        'End If





        'Try
        '    Dim t_sr As StreamReader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\Hobis-PC\Desktop\Game_Info2.txt")

        '    While True
        '        Dim t_lineStr = t_sr.ReadLine()
        '        If t_lineStr Is Nothing Then
        '            Exit While
        '        Else
        '            Console.WriteLine("Line At String: " & t_lineStr)
        '        End If
        '    End While

        '    t_sr.Close()
        '    t_sr.Dispose()
        'Catch ex As Exception
        '    '
        '    Console.WriteLine("여긴1")
        'Finally
        '    'If t_sr IsNot Nothing Then
        '    '    t_sr.Close()
        '    '    t_sr.Dispose()
        '    'End If
        '    Console.WriteLine("여긴2")
        'End Try


    End Sub
End Module
