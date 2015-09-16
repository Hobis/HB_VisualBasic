Imports System
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports System.Net
Imports System.Threading
Imports Microsoft.VisualBasic

Public NotInheritable Class MainForm

    ' ::
    Private Sub p_Me_Load(ByVal sender As Object, _
                          ByVal ea As EventArgs) Handles MyBase.Load

        Me.TextBox1.MaxLength = Integer.MaxValue
        Me.TextBox2.MaxLength = Integer.MaxValue





        'Me.TextBox1.Text = "HoldOn"

        'Dim t_source As String = Me.TextBox1.Text
        'Dim t_pattern As String = "(\S+)=[""']?((?:.(?![""']?\s+(?:\S+)=|[>""']))+.)[""']?"
        'Dim t_pattern As String = "href=""([^""]+)"""

        'Dim t_mc As MatchCollection = Regex.Matches(t_source, t_pattern)
        'For Each t_m As Match In t_mc
        'Me.TextBox2.AppendText(t_m.Value & Constants.vbNewLine)
        'Next

        'MessageBox.Show(": " & Me.TextBox1.Text)

        'Dim t_tags As String() = MImgTagKiller.GetTags(Me.TextBox1.Text)
        'Dim t_tagAllStr As String = String.Concat(t_tags)
        ''MessageBox.Show("t_tagAllStr: " & t_tagAllStr)

        'Dim t_srcVal As String = MImgTagKiller.GetSrcValue(t_tags(0))
        'If (t_srcVal Is Nothing) Then
        '    MessageBox.Show("src속성 없음")
        'Else
        '    MessageBox.Show(t_srcVal)
        'End If

        'https://www.torrentmoa.com/index.php?mid=JAV&page=1&document_srl=114870
        'https://www.torrentmoa.com/index.php?mid=JAV&page=1&document_srl=114864
        'https://www.torrentmoa.com/index.php?mid=JAV&page=5&document_srl=114667

        'For i As Integer = 114870 To 114870 - 9999 Step -1
        Dim t_la As Integer = 114870 - 9999
        For i As Integer = t_la To 0 Step -1
            Dim t_url As String = String.Format("https://www.torrentmoa.com/index.php?mid=JAV&page=5&document_srl={0:D6}", i)
            Me.TextBox1.AppendText(t_url & vbNewLine)
        Next



    End Sub

    ' ::
    Private Sub p_Button1_Click( _
                    ByVal sender As Object, _
                    ByVal ea As EventArgs) Handles Button1.Click


        'Dim t_source As String = Me.TextBox1.Text
        'If (String.IsNullOrEmpty(t_source)) Then Return

        'Dim t_tags As String() = MImgTagKiller.GetTags(t_source)
        ''MessageBox.Show(t_tags.Length)
        'Dim t_la As Integer = t_tags.Length
        'Dim i As Integer = 0
        'While (i < t_la)
        '    Dim t_tag As String = t_tags(i)
        '    Dim t_srcVal As String = MImgTagKiller.GetSrcValue(t_tag)
        '    If (String.IsNullOrEmpty(t_srcVal)) Then
        '    Else
        '        'MessageBox.Show(": " & i & ", : " & t_srcVal)
        '    End If

        '    i += 1
        'End While

        If (Me._playThead Is Nothing) Then
            Me._playThead = New Thread(AddressOf Me.p_WebUrlsLoadStart)
            Me._playThead.IsBackground = True
            Me._playThead.Start()
        End If

    End Sub

    ' ::
    Private Sub p_Button2_Click( _
                    ByVal sender As Object, _
                    ByVal ea As EventArgs) Handles Button2.Click
        Me.TextBox2.Clear()
    End Sub






    ' ::
    Private Sub p_Trace(ByVal str As String)
        Me.TextBox2.AppendText(str & vbNewLine)
    End Sub


    Private _playThead As Thread = Nothing
    ' ::
    Private Sub p_Kill_playThead()
        If (Me._playThead IsNot Nothing) Then
            Me._playThead = Nothing
        End If
    End Sub


    ' ::
    Private Sub p_WebUrlsLoadStart()
        Dim t_urls As String() = Me.TextBox1.Lines

        If (t_urls IsNot Nothing) Then
            Dim t_la As Integer = t_urls.Length
            If (t_la > 0) Then
                Dim i As Integer = 0
                While (i < t_la)
                    Dim t_url As String = t_urls(i)
                    'MessageBox.Show("t_url: " & t_url)
                    Dim t_pstr As String = p_WebUrlLoad(t_url)
                    'MessageBox.Show("t_pstr: " & t_pstr)
                    Me.p_TargetLogical(t_pstr)

                    i += 1
                End While
            End If
        End If

        Me.p_Kill_playThead()
        Me.p_Trace("End Work")
    End Sub

    ' ::
    Private Function p_WebUrlLoad(ByVal url As String)
        Dim t_str As String = Nothing
        Dim t_wc As WebClient = Nothing

        Try
            t_wc = New WebClient()
            t_str = t_wc.DownloadString(url)
        Catch
        End Try

        Return t_str
    End Function

    ' ::
    Private Sub p_TargetLogical(ByVal pstr As String)
        If (String.IsNullOrEmpty(pstr)) Then Return

        Dim t_tags As String() = Me.p_GetTags(pstr)
        If (t_tags Is Nothing) Then Return

        Dim t_la As Integer = t_tags.Length
        'Me.p_Trace("t_la: " & t_la)
        Dim i As Integer = 0
        While (i < t_la)
            Dim t_tag As String = t_tags(i)
            Dim t_srcVal As String = Me.p_GetSrcValue(t_tag)
            If (String.IsNullOrEmpty(t_srcVal)) Then
            Else
                'Me.p_Trace(t_srcVal)
                Me.p_DownLoadFile(t_srcVal)
            End If

            i += 1
        End While

    End Sub

    Private _downPath As String = Path.Combine(Environment.CurrentDirectory, "_Imgs")
    ' ::
    Private Sub p_DownLoadFile(ByVal url As String)
        Dim t_uri As Uri = Nothing
        Dim t_fileName As String = Nothing
        Dim t_filePath As String = Nothing
        Dim t_wc As WebClient = Nothing

        Try
            t_uri = New Uri(url)
            t_fileName = Path.GetFileName(t_uri.LocalPath)
            'Me.p_Trace("t_fileName: " & t_fileName)
            t_filePath = Path.Combine(_downPath, t_fileName)
            'Me.p_Trace("t_filePath: " & t_filePath)
            If (File.Exists(t_filePath)) Then Return

            t_wc = New WebClient()
            t_wc.DownloadFile(url, t_filePath)
            Me.p_Trace(url)
        Catch
        End Try

        If (t_wc IsNot Nothing) Then
            t_wc.Dispose()
            t_wc = Nothing
        End If
    End Sub


    ' ::
    Private Function p_GetTags( _
                ByVal source As String) As String()

        Dim t_tags As String() = Nothing

        'Const t_pattern As String = "href=""([^""]+)"""
        Const t_pattern As String = "<img ([^<|>]+)>"
        Dim t_mc As MatchCollection = Regex.Matches(source, t_pattern)
        Dim t_count As Integer = t_mc.Count

        If (t_count > 0) Then
            t_tags = New String(t_count - 1) {}

            Dim i As Integer = 0
            While (i < t_count)
                Dim t_m As Match = t_mc(i)
                t_tags(i) = t_m.Value
                i += 1
            End While
        End If

        Return t_tags
    End Function

    ' ::
    Private Function p_GetSrcValue( _
                ByVal tag As String) As String

        Dim t_val As String = Nothing

        Const t_pattern As String = "src=""([^""]+)"""
        Dim t_mc As MatchCollection = Regex.Matches(tag, t_pattern)
        Dim t_count As Integer = t_mc.Count

        If (t_count > 0) Then
            t_val = t_mc(0).Value
            't_val = t_val.Replace("src=", "")
            't_val = t_val.Replace("""", "")

            If (Regex.IsMatch(t_val, "https://www.torrentmoa.com/files/attach/images/") _
                AndAlso Regex.IsMatch(t_val, ".jpg")) Then
                '
                t_val = t_val.Replace("src=", "")
                t_val = t_val.Replace("""", "")
            Else
                t_val = Nothing
            End If
        End If

        Return t_val
    End Function


End Class




