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
        Me._BtnStart = New System.Windows.Forms.Button()
        Me._TxbRoot = New System.Windows.Forms.TextBox()
        Me._BtnStop = New System.Windows.Forms.Button()
        Me._BtnClear = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        '_BtnStart
        '
        Me._BtnStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._BtnStart.Location = New System.Drawing.Point(413, 565)
        Me._BtnStart.Name = "_BtnStart"
        Me._BtnStart.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me._BtnStart.Size = New System.Drawing.Size(75, 23)
        Me._BtnStart.TabIndex = 0
        Me._BtnStart.Text = "Start"
        Me._BtnStart.UseVisualStyleBackColor = True
        '
        '_TxbRoot
        '
        Me._TxbRoot.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._TxbRoot.Location = New System.Drawing.Point(12, 12)
        Me._TxbRoot.Multiline = True
        Me._TxbRoot.Name = "_TxbRoot"
        Me._TxbRoot.ReadOnly = True
        Me._TxbRoot.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me._TxbRoot.Size = New System.Drawing.Size(476, 547)
        Me._TxbRoot.TabIndex = 1
        Me._TxbRoot.WordWrap = False
        '
        '_BtnStop
        '
        Me._BtnStop.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._BtnStop.Location = New System.Drawing.Point(332, 565)
        Me._BtnStop.Name = "_BtnStop"
        Me._BtnStop.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me._BtnStop.Size = New System.Drawing.Size(75, 23)
        Me._BtnStop.TabIndex = 2
        Me._BtnStop.Text = "Stop"
        Me._BtnStop.UseVisualStyleBackColor = True
        '
        '_BtnClear
        '
        Me._BtnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._BtnClear.Location = New System.Drawing.Point(251, 565)
        Me._BtnClear.Name = "_BtnClear"
        Me._BtnClear.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me._BtnClear.Size = New System.Drawing.Size(75, 23)
        Me._BtnClear.TabIndex = 3
        Me._BtnClear.Text = "Clear"
        Me._BtnClear.UseVisualStyleBackColor = True
        '
        'FrmRoot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(500, 600)
        Me.Controls.Add(Me._BtnClear)
        Me.Controls.Add(Me._BtnStop)
        Me.Controls.Add(Me._TxbRoot)
        Me.Controls.Add(Me._BtnStart)
        Me.Name = "FrmRoot"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents _TxbRoot As System.Windows.Forms.TextBox
    Private WithEvents _BtnStart As System.Windows.Forms.Button
    Private WithEvents _BtnStop As System.Windows.Forms.Button
    Private WithEvents _BtnClear As System.Windows.Forms.Button

End Class
