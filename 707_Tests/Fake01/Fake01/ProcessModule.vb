Imports System.Net


Public Module ProcessModule

    Private _owner As FrmRoot
    Private _urls() As String
    Public Sub fStartPoint(ByVal owner As FrmRoot, ByVal urls As String)
        _owner = owner
        _owner.pnl1.Show()
        p_PolStart()
        _owner.txbPrint.Text = urls.Replace(vbCr, vbNewLine)
        _urls = urls.Split(vbNewLine)
        CType(AddressOf p_CaseBy, MethodInvoker).BeginInvoke(Nothing, Nothing)
        'p_CaseBy()



        'MessageBox.Show(_urls.Length)
        'owner.txbPrint.Text = "xxxx" & vbNewLine & "aaaa"
        'Dim t_str As String = "abcd"
        'MessageBox.Show(t_str.Replace("ab", "_"))
        'urls.Replace(vbNewLine, vbNewLine)
        'MessageBox.Show(urls.Replace(vbCr, "").Length)


        'Dim t_mi As MethodInvoker = _
        '    Sub()
        '        Dim t_lss() As String = urls.Split(vbNewLine)
        '        For Each t_ls As String In t_lss
        '            owner.txbPrint.AppendText(t_ls & vbNewLine)
        '        Next
        '    End Sub
        't_mi.BeginInvoke(Nothing, Nothing)


        'owner.Invoke(Sub()
        '                 Dim t_lss() As String = urls.Split(vbNewLine)
        '                 For Each t_ls As String In t_lss
        '                     owner.txbPrint.AppendText(t_ls & vbNewLine)
        '                 Next
        '             End Sub)

        ''MessageBox.Show(owner.InvokeRequired)
        'Dim t_lss() As String = urls.Split(vbNewLine)
        ''MsgBox(t_ls.Length.ToString)
        ''urls.Replace(vbNewLine, "\r\n")
        ''owner.txbPrint.Text = urls
        'For Each t_ls As String In t_lss
        '    owner.txbPrint.AppendText(t_ls & vbNewLine)
        'Next
    End Sub

    ' ::
    Private Sub p_PolStart()
        _owner.pnl1.Enabled = False
    End Sub

    ' ::
    Private Sub p_PolEnd()
        _owner.pnl1.Enabled = True
    End Sub

    ' ::
    Private Sub p_CaseBy()
        If (Not _urls Is Nothing) Then
            For Each url As String In _urls
                p_UrlChecker(url)
            Next
            _owner.Invoke(CType(AddressOf p_PolEnd, MethodInvoker))
        End If
    End Sub

    ' ::
    Private Sub p_UrlChecker(ByVal url As String)
        If (Not String.IsNullOrEmpty(url)) Then
            Dim t_wc As WebClient = Nothing
            Dim t_txt As String
            Try
                t_wc = New WebClient()
                t_txt = t_wc.DownloadString(url)
                _owner.Invoke(Sub()
                                  MessageBox.Show(t_txt.Length)
                              End Sub)
                'MessageBox.Show(t_txt.Length)
            Catch
            End Try

            If (Not t_wc Is Nothing) Then
                t_wc.Dispose()
            End If
        End If
    End Sub

End Module
