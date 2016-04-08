<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRoot
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRoot))
        Me.wbRoot = New System.Windows.Forms.WebBrowser()
        Me.pnl1 = New System.Windows.Forms.Panel()
        Me.btnYes = New System.Windows.Forms.Button()
        Me.txbPrint = New System.Windows.Forms.TextBox()
        Me.pnl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'wbRoot
        '
        Me.wbRoot.AllowNavigation = False
        Me.wbRoot.AllowWebBrowserDrop = False
        Me.wbRoot.CausesValidation = False
        Me.wbRoot.IsWebBrowserContextMenuEnabled = False
        Me.wbRoot.Location = New System.Drawing.Point(12, 12)
        Me.wbRoot.MinimumSize = New System.Drawing.Size(10, 10)
        Me.wbRoot.Name = "wbRoot"
        Me.wbRoot.ScrollBarsEnabled = False
        Me.wbRoot.Size = New System.Drawing.Size(10, 10)
        Me.wbRoot.TabIndex = 0
        Me.wbRoot.TabStop = False
        Me.wbRoot.WebBrowserShortcutsEnabled = False
        '
        'pnl1
        '
        Me.pnl1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnl1.Controls.Add(Me.btnYes)
        Me.pnl1.Controls.Add(Me.txbPrint)
        Me.pnl1.Location = New System.Drawing.Point(12, 256)
        Me.pnl1.Name = "pnl1"
        Me.pnl1.Size = New System.Drawing.Size(576, 232)
        Me.pnl1.TabIndex = 1
        '
        'btnYes
        '
        Me.btnYes.Location = New System.Drawing.Point(498, 206)
        Me.btnYes.Name = "btnYes"
        Me.btnYes.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.btnYes.Size = New System.Drawing.Size(75, 23)
        Me.btnYes.TabIndex = 1
        Me.btnYes.Text = "확인"
        Me.btnYes.UseVisualStyleBackColor = True
        '
        'txbPrint
        '
        Me.txbPrint.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txbPrint.Location = New System.Drawing.Point(3, 3)
        Me.txbPrint.Multiline = True
        Me.txbPrint.Name = "txbPrint"
        Me.txbPrint.ReadOnly = True
        Me.txbPrint.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txbPrint.Size = New System.Drawing.Size(570, 197)
        Me.txbPrint.TabIndex = 0
        Me.txbPrint.WordWrap = False
        '
        'FrmRoot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(600, 500)
        Me.Controls.Add(Me.pnl1)
        Me.Controls.Add(Me.wbRoot)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(40, 40)
        Me.MaximizeBox = False
        Me.Name = "FrmRoot"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Form1"
        Me.pnl1.ResumeLayout(False)
        Me.pnl1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents wbRoot As System.Windows.Forms.WebBrowser

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Friend WithEvents pnl1 As System.Windows.Forms.Panel
    Friend WithEvents txbPrint As System.Windows.Forms.TextBox
    Friend WithEvents btnYes As System.Windows.Forms.Button
End Class
