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
    Private _CallBack As Action(Of Object()) = Nothing

    Private _BackWorker As BackgroundWorker

    Private _DownloadZipUrl As String
    Private _WorkBasePath As String
    Private _TargetZipFilePath As String
    Private _PurposeUnzipPath As String
    Private _UpdatePath As String

    Private _WebClien As WebClient

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

        _BackWorker = New BackgroundWorker()
        _BackWorker.WorkerSupportsCancellation = True
        _BackWorker.WorkerReportsProgress = True
        AddHandler _BackWorker.DoWork, AddressOf p_BackWorker_DoWork
        AddHandler _BackWorker.ProgressChanged, AddressOf p_BackWorker_ProgressChanged
        AddHandler _BackWorker.RunWorkerCompleted, AddressOf p_BackWorker_RunWorkerCompleted
    End Sub

    Public Sub fClear()
        If Not _CallBack Is Nothing Then
            If Not _BackWorker Is Nothing Then
                _BackWorker.CancelAsync()
                RemoveHandler _BackWorker.DoWork, AddressOf p_BackWorker_DoWork
                RemoveHandler _BackWorker.ProgressChanged, AddressOf p_BackWorker_ProgressChanged
                RemoveHandler _BackWorker.RunWorkerCompleted, AddressOf p_BackWorker_RunWorkerCompleted
                _BackWorker = Nothing
            End If

            p_ZipFile_Clear()

            _DownloadZipUrl = Nothing
            _WorkBasePath = Nothing
            _TargetZipFilePath = Nothing
            _PurposeUnzipPath = Nothing
            _PurposeUnzipPath = Nothing
            _UpdatePath = Nothing
            _CallBack = Nothing
        End If
    End Sub

    Public Sub fStop()
        If _CallBack Is Nothing Then Exit Sub
        _BackWorker.CancelAsync()
    End Sub

    Public Sub fStart()
        If _CallBack Is Nothing Then Exit Sub
        If Not _BackWorker.IsBusy Then
            _BackWorker.RunWorkerAsync()
        End If
    End Sub


    Private Sub p_CallBack(args() As Object)
        If Not _CallBack Is Nothing Then
            _CallBack(args)
        End If
    End Sub



    Private Sub p_BackWorker_DoWork(sender As Object, dwea As DoWorkEventArgs)
        p_DownloadZip_Start()
        p_ZipFile_Clear()
        p_ZipFile_Start()
    End Sub

    Private Sub p_BackWorker_ProgressChanged(sender As Object, pcea As ProgressChangedEventArgs)
        p_CallBack({CallBackType_AppendText, "p_BackWorker_ProgressChanged"})
    End Sub

    Private Sub p_BackWorker_RunWorkerCompleted(sender As Object, rcea As RunWorkerCompletedEventArgs)
        p_CallBack({CallBackType_AppendText, "p_BackWorker_RunWorkerCompleted"})
    End Sub

    Private Sub p_DownloadZip_Clear()
        If Not _WebClien Is Nothing Then
            _WebClien.Dispose()
            _WebClien = Nothing
        End If
    End Sub

    Private Sub p_DownloadZip_Start()
        p_DownloadZip_Clear()
        _WebClien = New WebClient()
        'AddHandler _WebClien.DownloadFileCompleted 
        p_CallBack({CallBackType_AppendText, "다운로드중..."})
        _WebClien.DownloadFile(_DownloadZipUrl, _TargetZipFilePath)
        p_DownloadZip_Clear()
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
        Using _ZipFile = New ZipFile(_TargetZipFilePath, Encoding.Default)
            _ZipFileEntryCountLen = _ZipFile.Entries.Count
            _ZipFileEntryCount = 0
            If _ZipFileEntryCount < _ZipFileEntryCountLen Then
                Try
                    AddHandler _ZipFile.ExtractProgress, AddressOf p_ZipFile_ExtractProgress
                    _ZipFile.ExtractAll(_PurposeUnzipPath, Ionic.Zip.ExtractExistingFileAction.OverwriteSilently)
                Catch
                End Try
                p_CopyUpdate()
                p_DeleteFolder(False)
            End If
        End Using
        p_ZipFile_Clear()
    End Sub

    Private Sub p_ZipFile_ExtractProgress(sender As Object, epea As ExtractProgressEventArgs)
        If _BackWorker.CancellationPending Then
            epea.Cancel = True
        Else
            Try
                If epea.EventType = ZipProgressEventType.Extracting_AfterExtractEntry Then
                    Thread.Sleep(_DelaySleep)
                    Dim t_ze As ZipEntry = epea.CurrentEntry
                    If Not t_ze Is Nothing Then
                        _ZipFileEntryCount += 1
                        p_CallBack({CallBackType_AppendText, String.Format("# 압축해제: {0}/{1}", _ZipFileEntryCount, _ZipFileEntryCountLen)})
                    End If
                End If
            Catch
            End Try
        End If
    End Sub


    Private Sub p_CopyUpdate()
        p_CopyFiles(_PurposeUnzipPath, _UpdatePath)
    End Sub

    Private Sub p_CopyFiles(tp As String, pp As String)
        Dim t_fps() As String = Directory.GetFiles(tp)
        If Not t_fps Is Nothing AndAlso t_fps.Length > 0 Then
            If Not Directory.Exists(pp) Then
                Directory.CreateDirectory(pp)
            End If

            For Each t_tfp As String In t_fps
                If _BackWorker.CancellationPending Then
                    Exit For
                Else
                    If File.Exists(t_tfp) Then
                        Thread.Sleep(_DelaySleep)
                        Dim t_pfp As String = Path.Combine(pp, Path.GetFileName(t_tfp))
                        File.Copy(t_tfp, t_pfp, True)
                        p_CallBack({CallBackType_AppendText, String.Format("# 파일복사: {0}", Path.GetFileName(t_pfp))})
                    End If
                End If
            Next
        End If

        Dim t_dps() As String = Directory.GetDirectories(tp)
        If Not t_dps Is Nothing AndAlso t_dps.Length > 0 Then
            For Each t_tp As String In t_dps
                If _BackWorker.CancellationPending Then
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

