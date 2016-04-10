Imports System.Globalization
Imports System.Text.RegularExpressions

Module Module1
    Public Sub Main()

        Dim dateString As String = "7/16/2008 8:32:45.126 AM"

        Try
            Dim dateValue As Date = Date.Parse(dateString)
            Dim dateOffsetValue As DateTimeOffset = DateTimeOffset.Parse(dateString)

            ' Display Millisecond component alone.
            Console.WriteLine("Millisecond component only: {0}", _
                              dateValue.ToString("fff"))
            Console.WriteLine("Millisecond component only: {0}", _
                              dateOffsetValue.ToString("fff"))

            ' Display Millisecond component with full date and time.
            Console.WriteLine("Date and Time with Milliseconds: {0}", _
                              dateValue.ToString("MM/dd/yyyy hh:mm:ss.fff tt"))
            Console.WriteLine("Date and Time with Milliseconds: {0}", _
                              dateOffsetValue.ToString("MM/dd/yyyy hh:mm:ss.fff tt"))

            ' Append millisecond pattern to current culture's full date time pattern
            Dim fullPattern As String = DateTimeFormatInfo.CurrentInfo.FullDateTimePattern
            fullPattern = Regex.Replace(fullPattern, "(:ss|:s)", "$1.fff")

            ' Display Millisecond component with modified full date and time pattern.
            Console.WriteLine("Modified full date time pattern: {0}", _
                              dateValue.ToString(fullPattern))
            Console.WriteLine("Modified full date time pattern: {0}", _
                              dateOffsetValue.ToString(fullPattern))
        Catch e As FormatException
            Console.WriteLine("Unable to convert {0} to a date.", dateString)
        End Try

        Console.WriteLine(p_GetTime)

        Console.WriteLine(String.Format("{0:000}", "1"))
    End Sub

    Private Function p_GetTime()
        Dim t_d As Date = DateTime.Now
        Return t_d.ToString() & ":" & t_d.Millisecond.ToString()
    End Function
End Module