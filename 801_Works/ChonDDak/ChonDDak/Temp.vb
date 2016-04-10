﻿Imports System.Threading
Imports System.IO
Imports System.Text.RegularExpressions

Public NotInheritable Class FrmRoot

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub p_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "내컴에 파일 검색기  Ver 1.30"
        Me.BackgroundImage = Global.ChonDDak.My.Resources.Resources.Untitled_1

        Dim t_sb As Rectangle = Screen.PrimaryScreen.Bounds
        Dim t_ws As Size = Me.Size
        Dim t_lp As Point = New Point(t_sb.Width, t_sb.Height)
        t_lp.Offset(-(t_ws.Width + 40), -(t_ws.Height + 80))
        Me.Location = t_lp
        'Me.Location = New Point(0, 0)

        Me.AllowDrop = True
        p_Ckb1_CheckedChanged(Nothing, Nothing)
        p_Ckb2_CheckedChanged(Nothing, Nothing)
    End Sub


    ' -
    Private _cf_Path As String = Nothing
    ' -
    Private _cf_Action As Action = Nothing
    '
    Private _cf_TotalCount As Integer = 0
    '
    Private _cf_MatchingCount As Integer = 0
    '
    Private _cf_SearchStrs() As String = Nothing
    '
    Private _cf_IsUseRegEx As Boolean = False
    '
    Private _cf_IsIgnoreCase As Boolean = False


    ' ::
    Private Sub p_Alert(msg As String)
        If Me.InvokeRequired Then
            Me.Invoke( _
                Sub()
                    MMsgBox.Show(Me, msg, "~~~~")
                End Sub)
        Else
            MMsgBox.Show(Me, msg, "~~~~")
        End If
    End Sub

    ' ::
    Private Sub p_Txb1_AppendText(v As String)
        If _Txb1.InvokeRequired Then
            _Txb1.Invoke( _
                Sub()
                    _Txb1.AppendText(v & vbNewLine)
                End Sub)
        Else
            _Txb1.AppendText(v & vbNewLine)
        End If
    End Sub

    ' ::
    Private Sub p_Txb12_Update()
        If _Txb12.InvokeRequired Then
            _Txb12.Invoke( _
                Sub()
                    _Txb12.Text = String.Format("(전체: {0}, 매칭: {1})", _cf_TotalCount, _cf_MatchingCount)
                End Sub)
        Else
            _Txb12.Text = String.Format("(전체: {0}, 매칭: {1})", _cf_TotalCount, _cf_MatchingCount)
        End If
    End Sub


    ' ::
    Private Sub p_WorkClear()
        If Not _cf_Action Is Nothing Then
            p_WorkingStringsStop()
            _cf_Action = Nothing
        End If
    End Sub

    ' ::
    Private Sub p_WorkReady()
        If _cf_Action Is Nothing Then
            _cf_SearchStrs = _Txb2.Lines
            If _cf_SearchStrs Is Nothing OrElse _
                _cf_SearchStrs.Length < 1 Then
                _cf_SearchStrs = Nothing
            End If
            p_Btn11_Click(Nothing, Nothing)
            p_WorkingStringsStart()
            _cf_TotalCount = 0
            _cf_MatchingCount = 0
            _cf_Action = AddressOf p_WorkAction
            _cf_Action.BeginInvoke(Nothing, Nothing)
        Else
            p_Alert("이미 작업쓰레드가 진행중임")
        End If
    End Sub

    ' ::
    Private Sub p_WorkAction()
        p_WorkCore(_cf_Path)
        'p_Txb1_AppendText("검색파일수: " & _cf_Count)
        p_WorkClear()
    End Sub

    ' ::
    Private Sub p_WorkCore(dp As String)
        Thread.Sleep(100)
        Try
            Dim t_la As Integer
            Dim i As Integer

            Dim t_fps() As String = Directory.GetFiles(dp)
            Dim t_fp As String
            t_la = t_fps.Length
            i = 0
            While i < t_la
                If _cf_Action Is Nothing Then
                    Exit Sub
                End If
                t_fp = t_fps(i)
                If Not _cf_SearchStrs Is Nothing Then
                    Dim t_ab As Boolean = False
                    If _cf_IsUseRegEx Then
                        For Each t_rp In _cf_SearchStrs
                            Trace.WriteLine(">>>>:: " & t_rp)
                            If _cf_IsIgnoreCase Then
                                If Regex.IsMatch(t_fp, t_rp, RegexOptions.IgnoreCase) Then
                                    t_ab = True
                                End If
                            Else
                                If Regex.IsMatch(t_fp, t_rp, RegexOptions.None) Then
                                    t_ab = True
                                End If
                            End If
                        Next
                    Else
                        For Each t_rp In _cf_SearchStrs
                            If _cf_IsIgnoreCase Then
                                If t_fp.IndexOf(t_rp) > -1 Then
                                    t_ab = True
                                End If
                            Else
                                If t_fp.IndexOf(t_rp, StringComparison.OrdinalIgnoreCase) > -1 Then
                                    t_ab = True
                                End If
                            End If
                        Next
                    End If
                    If t_ab Then
                        p_Txb1_AppendText(t_fp)
                        _cf_MatchingCount += 1
                    End If
                Else
                    p_Txb1_AppendText(t_fp)
                    _cf_MatchingCount += 1
                End If
                _cf_TotalCount += 1
                p_Txb12_Update()
                i += 1
            End While

            Dim t_dps() As String = Directory.GetDirectories(dp)
            Dim t_dp As String
            t_la = t_dps.Length
            i = 0
            While i < t_la
                If _cf_Action Is Nothing Then
                    Exit Sub
                End If
                t_dp = t_dps(i)
                p_WorkCore(t_dp)
                i += 1
            End While
        Catch
        End Try
    End Sub


    ' ::
    Private Sub p_Btn1_Click(sender As Object, e As EventArgs) Handles _Btn1.Click
        If String.IsNullOrEmpty(_cf_Path) Then
            p_Alert("경로가 설정되지 않음")
            Return
        End If
        If Not Directory.Exists(_cf_Path) Then
            p_Alert("경로가 잘못되어 있음")
            Return
        End If
        p_WorkReady()
    End Sub

    ' ::
    Private Sub p_Btn2_Click(sender As Object, e As EventArgs) Handles _Btn2.Click
        p_WorkClear()
    End Sub

    ' ::
    Private Sub p_Btn3_Click(sender As Object, e As EventArgs) Handles _Btn3.Click
        'Dim t_dr As DialogResult = _Fbd1.ShowDialog()
        Dim t_dr As DialogResult = MMsgBox.Show(Me, _Fbd1)
        If t_dr = Windows.Forms.DialogResult.OK Then
            _cf_Path = _Fbd1.SelectedPath
            _Txb11.Text = _cf_Path
        End If
    End Sub

    ' ::
    Private Sub p_Btn11_Click(sender As Object, e As EventArgs) Handles _Btn11.Click
        _Txb1.Clear()
        _Txb13.Clear()
        _Txb12.Clear()
        'Clipboard.Clear()
        GC.Collect()
        GC.WaitForPendingFinalizers()
    End Sub

    ' ::
    Private Sub p_Btn12_Click(sender As Object, e As EventArgs) Handles _Btn12.Click
        Dim t_v As String = _Txb1.Text
        If Not String.IsNullOrEmpty(t_v) Then
            Clipboard.SetText(t_v)
        End If
    End Sub

    ' ::
    Private Sub p_Btn4_Click(sender As Object, e As EventArgs) Handles _Btn4.Click
        _Txb2.Clear()
    End Sub

    ' ::
    Private Sub p_Btn5_Click(sender As Object, e As EventArgs) Handles _Btn5.Click
        Dim t_v As String = _Txb2.Text
        If Not String.IsNullOrEmpty(t_v) Then
            Clipboard.SetText(t_v)
        End If
    End Sub

    ' ::
    Private Sub p_Btn6_Click(sender As Object, e As EventArgs) Handles _Btn6.Click
        Dim t_v As String = Clipboard.GetText()
        If Not String.IsNullOrEmpty(t_v) Then
            _Txb2.Text = t_v
        End If
    End Sub





    ' ::
    Private Sub p_Txb11_TextChanged(sender As Object, e As EventArgs) Handles _Txb11.TextChanged
        _cf_Path = _Txb11.Text
    End Sub

    ' ::
    Private Sub p_Txb11_DragEnter(sender As Object, e As DragEventArgs) Handles MyBase.DragEnter
        e.Effect = DragDropEffects.Copy
    End Sub

    ' ::
    Private Sub p_Txb11_DragDrop(sender As Object, e As DragEventArgs) Handles MyBase.DragDrop
        If e.Data.GetDataPresent(DataFormats.Text) Then
            _Txb11.Text = CType(e.Data.GetData(DataFormats.Text), String)
        ElseIf e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim t_fds() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())
            If t_fds.Length = 1 Then
                _Txb11.Text = t_fds(0)
            End If
        End If
    End Sub

    ' ::
    Private Sub p_BtnEtc_Click(sender As Object, e As EventArgs) Handles _BtnEtc.Click
        Process.Start("http://regexr.com/")
    End Sub

    ' ::
    'Private ReadOnly _LoadingChars() As Char = {"△"c, "▷"c, "▽"c, "◁"c}
    Private ReadOnly _WorkingStrings() As String = {"▷▷▷", "▶▷▷", "▶▶▷", "▶▶▶"}
    Private _lcc As Integer = 0
    Private Sub p_WorkingStringsStop()
        _Tmr1.Stop()
        _lcc = 0
        _Txb13.Text = String.Format("{0}", _WorkingStrings(_lcc))
    End Sub
    Private Sub p_WorkingStringsStart()
        _Tmr1.Start()
    End Sub
    Private Sub p_WorkingStringsDisplay()
        _Txb13.Text = String.Format("{0}", _WorkingStrings(_lcc))
        _lcc += 1
        If _lcc >= _WorkingStrings.Length Then
            _lcc = 0
        End If
    End Sub
    Private Sub p_Tmr1_Tick(sender As Object, e As EventArgs) Handles _Tmr1.Tick
        p_WorkingStringsDisplay()
    End Sub

    ' ::
    Private Sub p_BtnInfo_Click(sender As Object, e As EventArgs) Handles _BtnInfo.Click
        p_Alert("정규식을 이용한 파일 검색 프로그램 입니다." & vbNewLine & _
                "정규식을 알아야 사용할수 있어요." & vbNewLine & vbNewLine & _
                "제작자: 호비스" & vbNewLine & _
                "블로그: http://hobis.tistory.com/" & vbNewLine & _
                "제작언어: VB.NET Framework 3.5" & vbNewLine)

    End Sub



    Private Sub p_Ckb1_CheckedChanged(sender As Object, e As EventArgs) Handles _Ckb1.CheckedChanged
        _cf_IsUseRegEx = _Ckb1.Checked
    End Sub

    Private Sub p_Ckb2_CheckedChanged(sender As Object, e As EventArgs) Handles _Ckb2.CheckedChanged
        _cf_IsIgnoreCase = _Ckb2.Checked
    End Sub

    Private Sub p_FocusOut_MouseUp(sender As Object, e As MouseEventArgs) Handles _
                        _Btn12.MouseUp, _Btn11.MouseUp,
                        _BtnEtc.MouseUp, _BtnInfo.MouseUp,
                        _Btn6.MouseUp, _Btn5.MouseUp, _Btn4.MouseUp,
                        _Btn3.MouseUp, _Btn2.MouseUp, _Btn1.MouseUp
        _Txb13.Focus()
    End Sub

End Class
