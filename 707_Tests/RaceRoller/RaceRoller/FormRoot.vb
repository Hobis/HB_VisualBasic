Public NotInheritable Class FormRoot
#Region "!!~초기화"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        p_Init()
    End Sub
#End Region


    ' ::
    Private Sub p_Init()
        AddHandler Me.Load, AddressOf p_Load
    End Sub


    Private Const _AppFirstName As String = "RaceRoller"
    Private Const _AppName As String = _AppFirstName & " Ver 1.00b"

    ' ::
    Private Sub p_Load(ByVal sender As Object, ByVal e As EventArgs)
        Me.Text = _AppName
        Me.TxbMain.MaxLength = Integer.MaxValue
        'Me.TxbMain.ShortcutsEnabled = False

        AddHandler Me.TxbMain.KeyDown, AddressOf p_TxbMain_KeyDown
        AddHandler Me.BtnClear.Click, AddressOf p_BtnClear_Click
    End Sub

    ' ::
    Private Sub p_BtnClear_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.TxbMain.Clear()
    End Sub

    ' ::
    Private Sub p_TxbMain_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        If (e.Control AndAlso (e.KeyValue.Equals(Keys.A))) Then
            Me.TxbMain.SelectAll()
            e.Handled = True
        End If
    End Sub



End Class
