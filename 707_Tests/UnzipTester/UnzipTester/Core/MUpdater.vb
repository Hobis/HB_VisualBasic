Imports System
Imports System.ComponentModel
Imports System.IO
Imports System.Text
Imports System.Net
Imports System.Threading
Imports Ionic.Zip


Public Module MUpdater
    Private Const _DelaySleep As Integer = 10

    Public Const CallBackType_AppendText As String = "CT_AppendText"
    Public Const CallBackType_Complete As String = "CT_Complete"
    Private _CallBack As Action(Of Object()) = Nothing

    Private _ThreadStartInvoker As MethodInvoker
    Private _DownloadZipUrl As String
    Private _WorkBasePath As String
    Private _TargetZipFilePath As String
    Private _PurposeUnzipPath As String
    Private _UpdatePath As String

    Private _WebClient As WebClient

    Private _ZipFile As ZipFile
    Private _ZipFileEntryCountLen As Integer
    Private _ZipFileEntryCount As Integer

    Public Sub fInit(cb As Action(Of Object()), dlzu As String, wbp As String, ddn As String)
        If Not _CallBack Is Nothing Then Exit Sub
        _CallBack = cb
        _DownloadZipUrl = dlzu
        _WorkBasePath = wbp
        Dim t_zfn As String = Path.GetFileName(_DownloadZipUrl)
        _TargetZipFilePath = Path.Combine(_WorkBasePath, t_zfn)
        _PurposeUnzipPath = Path.GetFileNameWithoutExtension(_TargetZipFilePath) & "-UnzipTemp"
        _PurposeUnzipPath = Path.Combine(_WorkBasePath, _PurposeUnzipPath)
        _UpdatePath = Path.Combine(_WorkBasePath, ddn)
        p_CallBack({CallBackType_AppendText, "_CallBack: " & _CallBack.ToString()})
        p_CallBack({CallBackType_AppendText, "_DownloadZipUrl: " & _DownloadZipUrl})
        p_CallBack({CallBackType_AppendText, "_WorkBasePath: " & _WorkBasePath})
        p_CallBack({CallBackType_AppendText, "_TargetZipFilePath: " & _TargetZipFilePath})
        p_CallBack({CallBackType_AppendText, "_PurposeUnzipPath: " & _PurposeUnzipPath})
        p_CallBack({CallBackType_AppendText, "_UpdatePath: " & _UpdatePath})
    End Sub

    Public Sub fClear()
        If Not _CallBack Is Nothing Then
            _ThreadStartInvoker = Nothing
            _DownloadZipUrl = Nothing
            _WorkBasePath = Nothing
            _TargetZipFilePath = Nothing
            _PurposeUnzipPath = Nothing
            _UpdatePath = Nothing
            _CallBack = Nothing
        End If
    End Sub

    Public Sub fStop()
        If _CallBack Is Nothing Then Exit Sub
        _ThreadStartInvoker = Nothing
    End Sub

    Public Sub fStart()
        If _CallBack Is Nothing Then Exit Sub
        If _ThreadStartInvoker Is Nothing Then
            _ThreadStartInvoker = AddressOf p_DownloadZip_Start
            _ThreadStartInvoker.BeginInvoke(Nothing, Nothing)
        End If
    End Sub

    Private Sub p_CallBack(args() As Object)
        If _CallBack Is Nothing Then Exit Sub
        _CallBack(args)
    End Sub




    Private Sub p_DownloadZip_Clear()
        If Not _WebClient Is Nothing Then
            Dim t_wc As WebClient = _WebClient
            _WebClient = Nothing
            Try
                RemoveHandler t_wc.DownloadProgressChanged, AddressOf p_DownloadZip_DownloadProgressChanged
                RemoveHandler t_wc.DownloadFileCompleted, AddressOf p_DownloadZip_DownloadFileCompleted
                t_wc.CancelAsync()
                t_wc.Dispose()
            Catch
            End Try
        End If
    End Sub

    Private Sub p_DownloadZip_Start()
        p_DeleteFolder(False)
        p_DownloadZip_Clear()
        Dim t_uri As Uri
        Try
            _DownloadZipUrl = "http://play.afreecatv.com/kss7749/175874775/jhasd.zip"
            t_uri = New Uri(_DownloadZipUrl)
            _WebClient = New WebClient()
            AddHandler _WebClient.DownloadProgressChanged, AddressOf p_DownloadZip_DownloadProgressChanged
            AddHandler _WebClient.DownloadFileCompleted, AddressOf p_DownloadZip_DownloadFileCompleted
            p_CallBack({CallBackType_AppendText, "# 다운로드 시작: ~~~~"})
            _WebClient.DownloadFileAsync(t_uri, _TargetZipFilePath)
        Catch ex As Exception
            MsgBox("~~: " & ex.ToString())
            p_DownloadZip_Clear()
        End Try
    End Sub

    Private Sub p_DownloadZip_DownloadProgressChanged(sender As Object, dpcea As DownloadProgressChangedEventArgs)
        If _ThreadStartInvoker Is Nothing Then
            p_DownloadZip_Clear()
        Else
            p_CallBack({CallBackType_AppendText, "# 다운로드 진행: " & dpcea.ProgressPercentage.ToString() & "%"c})
        End If
    End Sub

    Private Sub p_DownloadZip_DownloadFileCompleted(sender As Object, acea As AsyncCompletedEventArgs)
        p_DownloadZip_Clear()
        If Not _ThreadStartInvoker Is Nothing Then
            If acea.Error Is Nothing Then
                p_CallBack({CallBackType_AppendText, "# 다운로드 완료: "})
                p_ZipFile_Start()
            Else
                p_CallBack({CallBackType_AppendText, "# 다운로드 실패: "})
            End If
        End If
    End Sub




    Private Sub p_ZipFile_Clear()
        If Not _ZipFile Is Nothing Then
            RemoveHandler _ZipFile.ExtractProgress, AddressOf p_ZipFile_ExtractProgress
            Try
                _ZipFile.Dispose()
            Catch
            End Try
            _ZipFile = Nothing
        End If
    End Sub

    Private Sub p_ZipFile_Start()
        If _ThreadStartInvoker Is Nothing Then
            Exit Sub
        Else
            p_ZipFile_Clear()
            Using _ZipFile = New ZipFile(_TargetZipFilePath, Encoding.Default)
                _ZipFileEntryCountLen = _ZipFile.Entries.Count
                _ZipFileEntryCount = 0
                If _ZipFileEntryCount < _ZipFileEntryCountLen Then
                    Try
                        p_CallBack({CallBackType_AppendText, "# 압축해제 시작: ~~~~"})
                        AddHandler _ZipFile.ExtractProgress, AddressOf p_ZipFile_ExtractProgress
                        _ZipFile.ExtractAll(_PurposeUnzipPath, Ionic.Zip.ExtractExistingFileAction.OverwriteSilently)
                        p_CallBack({CallBackType_AppendText, "# 압축해제 완료: "})
                    Catch
                        Debug.WriteLine("# ZipFile: 예외발생~~")
                    End Try
                    If Not _ThreadStartInvoker Is Nothing Then
                        '~~~~
                        p_CallBack({CallBackType_AppendText, "# 파일복사 시작: ~~~~"})
                        p_CopyFiles(_PurposeUnzipPath, _UpdatePath)
                        p_CallBack({CallBackType_AppendText, "# 파일복사 완료: "})
                        '~~~~
                        p_CallBack({CallBackType_AppendText, "# 파일삭제 시작: ~~~~"})
                        p_DeleteFolder(False)
                        p_CallBack({CallBackType_AppendText, "# 파일삭제 완료: "})
                    End If
                End If
            End Using
            p_ZipFile_Clear()

            If Not _ThreadStartInvoker Is Nothing Then
                _ThreadStartInvoker = Nothing
            End If
        End If
    End Sub

    Private Sub p_ZipFile_ExtractProgress(sender As Object, epea As ExtractProgressEventArgs)
        If _ThreadStartInvoker Is Nothing Then
            epea.Cancel = True
            Exit Sub
        Else
            Try
                If epea.EventType = ZipProgressEventType.Extracting_AfterExtractEntry Then
                    Thread.Sleep(_DelaySleep)
                    Dim t_ze As ZipEntry = epea.CurrentEntry
                    If Not t_ze Is Nothing Then
                        _ZipFileEntryCount += 1
                        p_CallBack({CallBackType_AppendText, String.Format("# 압축해제 진행: {0}/{1}", _ZipFileEntryCount, _ZipFileEntryCountLen)})
                    End If
                End If
            Catch
            End Try
        End If
    End Sub

    Private Sub p_CopyFiles(tp As String, pp As String)
        Dim t_fps() As String = Directory.GetFiles(tp)
        If Not t_fps Is Nothing AndAlso t_fps.Length > 0 Then
            If Not Directory.Exists(pp) Then
                Directory.CreateDirectory(pp)
            End If

            For Each t_tfp As String In t_fps
                If _ThreadStartInvoker Is Nothing Then
                    Exit For
                Else
                    If File.Exists(t_tfp) Then
                        Thread.Sleep(_DelaySleep)
                        Dim t_pfp As String = Path.Combine(pp, Path.GetFileName(t_tfp))
                        File.Copy(t_tfp, t_pfp, True)
                        p_CallBack({CallBackType_AppendText, String.Format("# 파일복사 진행: {0}", Path.GetFileName(t_pfp))})
                    End If
                End If
            Next
        End If

        Dim t_dps() As String = Directory.GetDirectories(tp)
        If Not t_dps Is Nothing AndAlso t_dps.Length > 0 Then
            For Each t_tp As String In t_dps
                If _ThreadStartInvoker Is Nothing Then
                    Exit For
                Else
                    If Directory.Exists(t_tp) Then
                        Dim t_pp As String = Path.Combine(pp, Path.GetFileName(t_tp))
                        p_CopyFiles(t_tp, t_pp)
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub p_DeleteFolder(bStronger As Boolean)
        If Directory.Exists(_PurposeUnzipPath) Then
            If bStronger Then
                Try
                    Dim t_dir As New DirectoryInfo(_PurposeUnzipPath)
                    Dim t_fis() As FileInfo = t_dir.GetFiles("*.*", SearchOption.AllDirectories)
                    For Each t_fi As FileInfo In t_fis
                        t_fi.Attributes = FileAttributes.Normal
                    Next
                Catch
                End Try
            End If

            Try
                Directory.Delete(_PurposeUnzipPath, True)
            Catch
            End Try
        End If
    End Sub

End Module

