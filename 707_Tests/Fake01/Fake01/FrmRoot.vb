Imports System.IO
Imports System.Collections.Specialized

Public NotInheritable Class FrmRoot

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    ' ::
    Private Sub p_MeLoad(ByVal sender As Object, _
                         ByVal e As EventArgs) Handles MyBase.Load
        ' ==========
        Me.Text = "이미지URL-검색기 Ver 1.0"
        '

        Me.wbRoot.Dock = DockStyle.Fill
        Me.wbRoot.ObjectForScripting = Me
        Dim t_url As String = Path.Combine(Application.StartupPath, "Root/Root.html")
        Me.wbRoot.Navigate(t_url)

        Me.pnl1.Hide()
    End Sub

    ' ::
    Private Sub p_Shown( _
                    ByVal sender As Object, _
                    ByVal e As EventArgs) Handles MyBase.Shown
    End Sub

    ' ::
    Private Sub p_wbRoot_DocumentCompleted( _
                    ByVal sender As Object, _
                    ByVal e As WebBrowserDocumentCompletedEventArgs) Handles wbRoot.DocumentCompleted
    End Sub





#Region "# 플래시와 연동"

    ' :: 플래시에서 윈폼함수 호출
    ' # QueryString 규칙 (속성네임은 대문자로 시작할것)
    '   Type=무엇을할지
    '   Data1=데이터1
    '   Data2=데이터2
    Public Function Wform_Call(ByVal qStr As String) As String
        If (qStr Is Nothing) Then
            Return Nothing
        End If

        Dim t_nvc As NameValueCollection = HttpUtility.ParseQueryString(qStr)
        Dim t_type As String = t_nvc("Type")
        If (String.IsNullOrEmpty(t_type)) Then
            Return Nothing
        End If

        Select Case t_type
            Case "FrmTest"
                Return Nothing
            Case "FrmStartProc"
                Dim t_urls As String = t_nvc("Urls")
                If (Not String.IsNullOrEmpty(t_urls)) Then
                    ProcessModule.fStartPoint(Me, t_urls)
                End If
                Return Nothing
        End Select

        Return Nothing
    End Function


    ' :: 윈폼에서 플래시 함수 호출
    Private Function p_Flash_Call(ByVal nvc As NameValueCollection) As String
        Dim t_args() As Object = {p_Util_ConvertQueryString(nvc)}
        Me.wbRoot.Document.InvokeScript("p_flas3_Call", t_args)
        Return Nothing
    End Function

#End Region




#Region "# 유틸 함수들"

    ' :: pObj -> qStr
    Private Function p_Util_ConvertQueryString(ByVal nvc As NameValueCollection) As String
        If (nvc Is Nothing) OrElse (nvc.Count = 0) Then
            Return Nothing
        End If

        Dim t_list As List(Of String) = New List(Of String)()
        For Each t_name As String In nvc
            Dim t_value As String = nvc(t_name)
            t_value = HttpUtility.UrlEncode(t_value)
            Dim t_str As String = String.Concat(t_name, "=", t_value)
            t_list.Add(t_str)
        Next

        Dim t_rv As String = String.Join("&", t_list.ToArray())
        t_list.Clear()
        Return t_rv
    End Function


    ' ::
    Private Function p_Util_GetTime()
        Dim t_d As Date = DateTime.Now
        Return t_d.ToString() & ":" & String.Format("{0:000}", t_d.Millisecond)
    End Function

#End Region









    ' ::
    'Private _b As Boolean = False
    'Private Sub p_btnOpen_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    If (_b) Then
    '        Me.pnl1.Hide()
    '        _b = False
    '    Else
    '        Me.pnl1.Show()
    '        _b = True
    '    End If
    'End Sub

    ' ::
    'Private Sub p_btn1_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    p_Flash_Call(New NameValueCollection() From _
    '                 {{"Type", "FlaTest"}, {"Name", "HobisJung"}, {"Age", "36"}})
    'End Sub

    ' ::
    Private Sub p_btnYes_Click(ByVal sender As Object, ByVal e As EventArgs) _
            Handles btnYes.Click
        Me.pnl1.Hide()
        Me.txbPrint.Clear()
        p_Flash_Call(New NameValueCollection() From {{"Type", "FlaCancle"}})
    End Sub
End Class
