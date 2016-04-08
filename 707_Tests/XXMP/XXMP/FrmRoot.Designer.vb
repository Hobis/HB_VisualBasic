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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRoot))
        Me.wbRoot = New System.Windows.Forms.WebBrowser()
        Me.btn2 = New System.Windows.Forms.Button()
        Me.tmrRoot = New System.Windows.Forms.Timer(Me.components)
        Me.txb2 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txb1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn1 = New System.Windows.Forms.Button()
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
        'btn2
        '
        Me.btn2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn2.Location = New System.Drawing.Point(488, 465)
        Me.btn2.Name = "btn2"
        Me.btn2.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.btn2.Size = New System.Drawing.Size(100, 23)
        Me.btn2.TabIndex = 1
        Me.btn2.TabStop = False
        Me.btn2.Text = "플래시로 보냄"
        Me.btn2.UseVisualStyleBackColor = True
        '
        'tmrRoot
        '
        '
        'txb2
        '
        Me.txb2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txb2.Location = New System.Drawing.Point(388, 288)
        Me.txb2.Multiline = True
        Me.txb2.Name = "txb2"
        Me.txb2.Size = New System.Drawing.Size(200, 170)
        Me.txb2.TabIndex = 2
        Me.txb2.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(386, 270)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "# 플래시로 보냄"
        '
        'txb1
        '
        Me.txb1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txb1.Location = New System.Drawing.Point(182, 288)
        Me.txb1.Multiline = True
        Me.txb1.Name = "txb1"
        Me.txb1.ReadOnly = True
        Me.txb1.Size = New System.Drawing.Size(200, 170)
        Me.txb1.TabIndex = 4
        Me.txb1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(180, 270)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 12)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "# 플래시에서 받음"
        '
        'btn1
        '
        Me.btn1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn1.Location = New System.Drawing.Point(282, 465)
        Me.btn1.Name = "btn1"
        Me.btn1.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.btn1.Size = New System.Drawing.Size(100, 23)
        Me.btn1.TabIndex = 6
        Me.btn1.TabStop = False
        Me.btn1.Text = "비우기"
        Me.btn1.UseVisualStyleBackColor = True
        '
        'FrmRoot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(600, 500)
        Me.Controls.Add(Me.btn1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txb1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txb2)
        Me.Controls.Add(Me.btn2)
        Me.Controls.Add(Me.wbRoot)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(40, 40)
        Me.MaximizeBox = False
        Me.Name = "FrmRoot"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents wbRoot As System.Windows.Forms.WebBrowser

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Friend WithEvents btn2 As System.Windows.Forms.Button
    Friend WithEvents tmrRoot As System.Windows.Forms.Timer
    Friend WithEvents txb2 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txb1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn1 As System.Windows.Forms.Button
End Class
