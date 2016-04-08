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
        Me.btn1 = New System.Windows.Forms.Button()
        Me.btn2 = New System.Windows.Forms.Button()
        Me.lb1 = New System.Windows.Forms.Label()
        Me.lb2 = New System.Windows.Forms.Label()
        Me.btn4 = New System.Windows.Forms.Button()
        Me.btn3 = New System.Windows.Forms.Button()
        Me.lb3 = New System.Windows.Forms.Label()
        Me.txb1 = New System.Windows.Forms.TextBox()
        Me.txb2 = New System.Windows.Forms.TextBox()
        Me.txb3 = New System.Windows.Forms.TextBox()
        Me.btn5 = New System.Windows.Forms.Button()
        Me.btn6 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btn1
        '
        Me.btn1.Location = New System.Drawing.Point(513, 243)
        Me.btn1.Name = "btn1"
        Me.btn1.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.btn1.Size = New System.Drawing.Size(75, 23)
        Me.btn1.TabIndex = 1
        Me.btn1.TabStop = False
        Me.btn1.Text = "비우기"
        Me.btn1.UseVisualStyleBackColor = True
        '
        'btn2
        '
        Me.btn2.Location = New System.Drawing.Point(387, 243)
        Me.btn2.Name = "btn2"
        Me.btn2.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.btn2.Size = New System.Drawing.Size(120, 23)
        Me.btn2.TabIndex = 2
        Me.btn2.TabStop = False
        Me.btn2.Text = "Url들 추출"
        Me.btn2.UseVisualStyleBackColor = True
        '
        'lb1
        '
        Me.lb1.AutoSize = True
        Me.lb1.Font = New System.Drawing.Font("Gulim", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lb1.Location = New System.Drawing.Point(12, 18)
        Me.lb1.Name = "lb1"
        Me.lb1.Size = New System.Drawing.Size(386, 13)
        Me.lb1.TabIndex = 3
        Me.lb1.Text = "■ Url 목록 (Image Url들을 추출할 Url목록을 여기에 넣어주세요.)"
        '
        'lb2
        '
        Me.lb2.AutoSize = True
        Me.lb2.Font = New System.Drawing.Font("Gulim", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lb2.Location = New System.Drawing.Point(12, 273)
        Me.lb2.Name = "lb2"
        Me.lb2.Size = New System.Drawing.Size(421, 13)
        Me.lb2.TabIndex = 4
        Me.lb2.Text = "■ Img 목록 (위에 Url목로에서 추출한 모든 Image Url들의 목록입니다.)"
        '
        'btn4
        '
        Me.btn4.Location = New System.Drawing.Point(387, 498)
        Me.btn4.Name = "btn4"
        Me.btn4.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.btn4.Size = New System.Drawing.Size(120, 23)
        Me.btn4.TabIndex = 7
        Me.btn4.TabStop = False
        Me.btn4.Text = "Url들 다운로드"
        Me.btn4.UseVisualStyleBackColor = True
        '
        'btn3
        '
        Me.btn3.Location = New System.Drawing.Point(513, 498)
        Me.btn3.Name = "btn3"
        Me.btn3.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.btn3.Size = New System.Drawing.Size(75, 23)
        Me.btn3.TabIndex = 6
        Me.btn3.TabStop = False
        Me.btn3.Text = "비우기"
        Me.btn3.UseVisualStyleBackColor = True
        '
        'lb3
        '
        Me.lb3.AutoSize = True
        Me.lb3.Font = New System.Drawing.Font("Gulim", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.lb3.Location = New System.Drawing.Point(12, 528)
        Me.lb3.Name = "lb3"
        Me.lb3.Size = New System.Drawing.Size(142, 13)
        Me.lb3.TabIndex = 8
        Me.lb3.Text = "■ 다운로드된 Img 목록"
        '
        'txb1
        '
        Me.txb1.Location = New System.Drawing.Point(12, 37)
        Me.txb1.Multiline = True
        Me.txb1.Name = "txb1"
        Me.txb1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txb1.Size = New System.Drawing.Size(576, 200)
        Me.txb1.TabIndex = 12
        Me.txb1.WordWrap = False
        '
        'txb2
        '
        Me.txb2.Location = New System.Drawing.Point(12, 292)
        Me.txb2.Multiline = True
        Me.txb2.Name = "txb2"
        Me.txb2.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txb2.Size = New System.Drawing.Size(576, 200)
        Me.txb2.TabIndex = 13
        Me.txb2.WordWrap = False
        '
        'txb3
        '
        Me.txb3.Location = New System.Drawing.Point(12, 547)
        Me.txb3.Multiline = True
        Me.txb3.Name = "txb3"
        Me.txb3.ReadOnly = True
        Me.txb3.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txb3.Size = New System.Drawing.Size(576, 200)
        Me.txb3.TabIndex = 14
        Me.txb3.WordWrap = False
        '
        'btn5
        '
        Me.btn5.Location = New System.Drawing.Point(513, 753)
        Me.btn5.Name = "btn5"
        Me.btn5.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.btn5.Size = New System.Drawing.Size(75, 23)
        Me.btn5.TabIndex = 15
        Me.btn5.TabStop = False
        Me.btn5.Text = "비우기"
        Me.btn5.UseVisualStyleBackColor = True
        '
        'btn6
        '
        Me.btn6.Location = New System.Drawing.Point(12, 753)
        Me.btn6.Name = "btn6"
        Me.btn6.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.btn6.Size = New System.Drawing.Size(75, 23)
        Me.btn6.TabIndex = 16
        Me.btn6.TabStop = False
        Me.btn6.Text = "도움말"
        Me.btn6.UseVisualStyleBackColor = True
        '
        'FrmRoot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(600, 800)
        Me.Controls.Add(Me.btn6)
        Me.Controls.Add(Me.btn5)
        Me.Controls.Add(Me.txb3)
        Me.Controls.Add(Me.txb2)
        Me.Controls.Add(Me.txb1)
        Me.Controls.Add(Me.lb3)
        Me.Controls.Add(Me.btn4)
        Me.Controls.Add(Me.btn3)
        Me.Controls.Add(Me.lb2)
        Me.Controls.Add(Me.lb1)
        Me.Controls.Add(Me.btn2)
        Me.Controls.Add(Me.btn1)
        Me.Location = New System.Drawing.Point(40, 40)
        Me.MaximizeBox = False
        Me.Name = "FrmRoot"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn1 As System.Windows.Forms.Button
    Friend WithEvents btn2 As System.Windows.Forms.Button
    Friend WithEvents lb1 As System.Windows.Forms.Label
    Friend WithEvents lb2 As System.Windows.Forms.Label
    Friend WithEvents btn4 As System.Windows.Forms.Button
    Friend WithEvents btn3 As System.Windows.Forms.Button
    Friend WithEvents lb3 As System.Windows.Forms.Label
    Friend WithEvents txb1 As System.Windows.Forms.TextBox
    Friend WithEvents txb2 As System.Windows.Forms.TextBox
    Friend WithEvents txb3 As System.Windows.Forms.TextBox
    Friend WithEvents btn5 As System.Windows.Forms.Button
    Friend WithEvents btn6 As System.Windows.Forms.Button

End Class
