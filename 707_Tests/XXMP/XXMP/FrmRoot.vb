Imports System.IO
Imports System.Collections.Specialized

Public NotInheritable Class FrmRoot

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'Me.wbRoot.Hide()
    End Sub

    ' ::
    Private Sub p_MeLoad(ByVal sender As Object, _
                         ByVal e As EventArgs) Handles MyBase.Load
        ' ====
        Me.Text = "XXMP Ver 1.23c In .NET 2.0"
        '

        Me.wbRoot.Dock = DockStyle.Fill
        Me.wbRoot.ObjectForScripting = Me
        Dim t_url As String = Path.Combine(Application.StartupPath, "Root/Root.html")
        Me.wbRoot.Navigate(t_url)

        Me.txb2.Text = "Type=FlaTest&Name=정희범"
        'Me.tmrRoot.Interval = 100
        'Me.tmrRoot.Start()
        'MsgBox(Me.wbRoot.Version.Major)
    End Sub

    ' ::
    Private Sub p_Shown(ByVal sender As Object, _
                        ByVal e As EventArgs) Handles MyBase.Shown
        'Me.Show()
    End Sub

    ' ::
    'Protected Overrides Sub SetVisibleCore(ByVal b As Boolean)
    '    'MyBase.SetVisibleCore(b)
    'End Sub

    ' ::
    Private Sub p_wbRoot_DocumentCompleted(ByVal sender As Object, _
            ByVal e As WebBrowserDocumentCompletedEventArgs) Handles wbRoot.DocumentCompleted
        'MyBase.SetVisibleCore(True)
        'Me.Show()
        'Me.wbRoot.Show()
    End Sub

    ' ::
    Private Sub p_btn1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn2.Click
        'Me.wbRoot.Document.InvokeScript("p_flas3_Call", New Object() {"Email=hobisjung@gmail.com&Age=36"})
        'Me.tmrRoot.Interval = 100
        ''Me.tmrRoot.Start()
        'Dim t_nvc As New NameValueCollection()
        't_nvc.Add("Name", "=")
        't_nvc.Add("Age", "32")
        'MessageBox.Show(p_convert_qStr(t_nvc))
        Dim t_str As String = Me.txb2.Text
        Me.wbRoot.Document.InvokeScript("p_flas3_Call", New Object() {t_str})
    End Sub

    ' ::
    Private Sub p_btn2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn1.Click
        Me.txb1.Clear()
    End Sub

    ' ::
    Private Sub p_tmr_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles tmrRoot.Tick
        Dim t_nvc As New NameValueCollection()
        t_nvc.Add("Type", "FlaTime")
        t_nvc.Add("Time", p_GetTime())
        Me.wbRoot.Document.InvokeScript("p_flas3_Call", New Object() {p_Convert_QueryString(t_nvc)})
    End Sub









    ' ::
    ' # QueryString 규칙 (속성네임은 대문자로 시작할것)
    '   Type=무엇을할지
    '   Data1=데이터1
    '   Data2=데이터2
    Public Function wform_Call(ByVal qStr As String) As String
        If (qStr Is Nothing) Then
            MessageBox.Show("널입니다.")
        End If

        Dim t_nvc As NameValueCollection = HttpUtility.ParseQueryString(qStr)
        Dim t_type As String = t_nvc("Type")
        If (String.IsNullOrEmpty(t_type)) Then
            Return Nothing
        End If

        Select Case t_type
            Case "FrmTest"
                Me.txb1.AppendText(qStr & vbNewLine)

            Case "FrmResult"
                Return "~~~~"
        End Select

        Return Nothing
    End Function

    ' ::
    Public Function wform_GetTime() As String
        Return p_GetTime()
    End Function






    ' :: pObj -> qStr
    Private Function p_Convert_QueryString(ByVal nvc As NameValueCollection) As String
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
    Private Function p_GetTime()
        Dim t_d As Date = DateTime.Now
        Return t_d.ToString() & ":" & String.Format("{0:000}", t_d.Millisecond)
    End Function

End Class
