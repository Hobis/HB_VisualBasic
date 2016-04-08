Public NotInheritable Class FrmRoot

    ' ::
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    ' ::
    Private Sub p_Load( _
                    ByVal sender As Object, _
                    ByVal e As EventArgs) Handles MyBase.Load
        '
        Me.Text = "이미지-Url-검출기 Ver 1.0b"

        'Me.lb1.Text = "■ Url 목록 (Image Url들을 추출할 Url목록을 여기에 넣어주세요.)"
        'Me.lb2.Text = "■ Img 목록 (위에 Url목로에서 추출한 모든 Image Url들의 목록입니다.)"
        'Me.lb3.Text = "■ 다운로드된 Img 목록"
    End Sub

    ' ::
    Private Sub p_btn2_Click( _
                    ByVal sender As Object, _
                    ByVal e As EventArgs) Handles btn2.Click

    End Sub

    ' ::
    Private Sub p_btn1_Click( _
                    ByVal sender As Object, _
                    ByVal e As EventArgs) Handles btn1.Click

    End Sub

End Class













Friend NotInheritable Class UrlWork

End Class


Friend NotInheritable Class DownloadWork

End Class
