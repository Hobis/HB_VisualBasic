<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CheckBox_Resize = New System.Windows.Forms.CheckBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.CheckBox_MaxBox = New System.Windows.Forms.CheckBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextBox_Bound_H = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBox_Bound_W = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBox_Bound_Y = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox_Process = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox_Bound_X = New System.Windows.Forms.TextBox()
        Me.TextBox_Opacity = New System.Windows.Forms.TextBox()
        Me.TextBox_Caption = New System.Windows.Forms.TextBox()
        Me.TextBox_Class = New System.Windows.Forms.TextBox()
        Me.TextBox_Handle = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Button_Clear = New System.Windows.Forms.Button()
        Me.Button_Apply = New System.Windows.Forms.Button()
        Me.Button_About = New System.Windows.Forms.Button()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer1.Panel1.Controls.Add(Me.FlowLayoutPanel1)
        Me.SplitContainer1.Panel1.ForeColor = System.Drawing.SystemColors.ControlText
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.FlowLayoutPanel2)
        Me.SplitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SplitContainer1.Size = New System.Drawing.Size(424, 401)
        Me.SplitContainer1.SplitterDistance = 369
        Me.SplitContainer1.SplitterWidth = 1
        Me.SplitContainer1.TabIndex = 0
        Me.SplitContainer1.TabStop = False
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox2)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Padding = New System.Windows.Forms.Padding(6)
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(424, 369)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CheckBox_Resize)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.CheckBox_MaxBox)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.TextBox_Bound_H)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.TextBox_Bound_W)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.TextBox_Bound_Y)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.TextBox_Process)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.TextBox_Bound_X)
        Me.GroupBox2.Controls.Add(Me.TextBox_Opacity)
        Me.GroupBox2.Controls.Add(Me.TextBox_Caption)
        Me.GroupBox2.Controls.Add(Me.TextBox_Class)
        Me.GroupBox2.Controls.Add(Me.TextBox_Handle)
        Me.GroupBox2.Controls.Add(Me.PictureBox1)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 9)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(381, 340)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Target Info"
        '
        'CheckBox_Resize
        '
        Me.CheckBox_Resize.AutoSize = True
        Me.CheckBox_Resize.Location = New System.Drawing.Point(224, 303)
        Me.CheckBox_Resize.Name = "CheckBox_Resize"
        Me.CheckBox_Resize.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox_Resize.TabIndex = 69
        Me.CheckBox_Resize.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(149, 304)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(69, 12)
        Me.Label11.TabIndex = 68
        Me.Label11.Text = "Resizable: "
        '
        'CheckBox_MaxBox
        '
        Me.CheckBox_MaxBox.AutoSize = True
        Me.CheckBox_MaxBox.Location = New System.Drawing.Point(107, 303)
        Me.CheckBox_MaxBox.Name = "CheckBox_MaxBox"
        Me.CheckBox_MaxBox.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox_MaxBox.TabIndex = 67
        Me.CheckBox_MaxBox.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(11, 304)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(91, 12)
        Me.Label10.TabIndex = 66
        Me.Label10.Text = "MaximizeBox: "
        '
        'TextBox_Bound_H
        '
        Me.TextBox_Bound_H.Location = New System.Drawing.Point(159, 237)
        Me.TextBox_Bound_H.Name = "TextBox_Bound_H"
        Me.TextBox_Bound_H.Size = New System.Drawing.Size(50, 21)
        Me.TextBox_Bound_H.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(105, 241)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 12)
        Me.Label9.TabIndex = 64
        Me.Label9.Text = "Height: "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(105, 214)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 12)
        Me.Label8.TabIndex = 63
        Me.Label8.Text = "Width: "
        '
        'TextBox_Bound_W
        '
        Me.TextBox_Bound_W.Location = New System.Drawing.Point(159, 210)
        Me.TextBox_Bound_W.Name = "TextBox_Bound_W"
        Me.TextBox_Bound_W.Size = New System.Drawing.Size(50, 21)
        Me.TextBox_Bound_W.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 241)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(21, 12)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Y: "
        '
        'TextBox_Bound_Y
        '
        Me.TextBox_Bound_Y.Location = New System.Drawing.Point(38, 237)
        Me.TextBox_Bound_Y.Name = "TextBox_Bound_Y"
        Me.TextBox_Bound_Y.Size = New System.Drawing.Size(50, 21)
        Me.TextBox_Bound_Y.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(11, 214)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(21, 12)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "X: "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 187)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 12)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Opacity: "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(86, 78)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 12)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "ProcessName: "
        '
        'TextBox_Process
        '
        Me.TextBox_Process.Location = New System.Drawing.Point(191, 74)
        Me.TextBox_Process.Name = "TextBox_Process"
        Me.TextBox_Process.ReadOnly = True
        Me.TextBox_Process.Size = New System.Drawing.Size(178, 21)
        Me.TextBox_Process.TabIndex = 62
        Me.TextBox_Process.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 160)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 12)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Caption: "
        '
        'TextBox_Bound_X
        '
        Me.TextBox_Bound_X.Location = New System.Drawing.Point(38, 210)
        Me.TextBox_Bound_X.Name = "TextBox_Bound_X"
        Me.TextBox_Bound_X.Size = New System.Drawing.Size(50, 21)
        Me.TextBox_Bound_X.TabIndex = 2
        '
        'TextBox_Opacity
        '
        Me.TextBox_Opacity.Location = New System.Drawing.Point(73, 183)
        Me.TextBox_Opacity.Name = "TextBox_Opacity"
        Me.TextBox_Opacity.Size = New System.Drawing.Size(50, 21)
        Me.TextBox_Opacity.TabIndex = 1
        '
        'TextBox_Caption
        '
        Me.TextBox_Caption.Location = New System.Drawing.Point(73, 156)
        Me.TextBox_Caption.Name = "TextBox_Caption"
        Me.TextBox_Caption.Size = New System.Drawing.Size(296, 21)
        Me.TextBox_Caption.TabIndex = 0
        '
        'TextBox_Class
        '
        Me.TextBox_Class.Location = New System.Drawing.Point(191, 47)
        Me.TextBox_Class.Name = "TextBox_Class"
        Me.TextBox_Class.ReadOnly = True
        Me.TextBox_Class.Size = New System.Drawing.Size(178, 21)
        Me.TextBox_Class.TabIndex = 61
        Me.TextBox_Class.TabStop = False
        '
        'TextBox_Handle
        '
        Me.TextBox_Handle.Location = New System.Drawing.Point(191, 20)
        Me.TextBox_Handle.Name = "TextBox_Handle"
        Me.TextBox_Handle.ReadOnly = True
        Me.TextBox_Handle.Size = New System.Drawing.Size(178, 21)
        Me.TextBox_Handle.TabIndex = 60
        Me.TextBox_Handle.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.PictureBox1.Image = Global.WndTool_x86.My.Resources.Resources.MIcon01
        Me.PictureBox1.Location = New System.Drawing.Point(14, 26)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(60, 60)
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(86, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "ClassName: "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(86, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Handle: "
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.Button_Clear)
        Me.FlowLayoutPanel2.Controls.Add(Me.Button_Apply)
        Me.FlowLayoutPanel2.Controls.Add(Me.Button_About)
        Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(424, 31)
        Me.FlowLayoutPanel2.TabIndex = 0
        '
        'Button_Clear
        '
        Me.Button_Clear.Location = New System.Drawing.Point(346, 3)
        Me.Button_Clear.Name = "Button_Clear"
        Me.Button_Clear.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.Button_Clear.Size = New System.Drawing.Size(75, 24)
        Me.Button_Clear.TabIndex = 0
        Me.Button_Clear.TabStop = False
        Me.Button_Clear.Text = "Clear"
        Me.Button_Clear.UseVisualStyleBackColor = True
        '
        'Button_Apply
        '
        Me.Button_Apply.Location = New System.Drawing.Point(265, 3)
        Me.Button_Apply.Name = "Button_Apply"
        Me.Button_Apply.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.Button_Apply.Size = New System.Drawing.Size(75, 24)
        Me.Button_Apply.TabIndex = 1
        Me.Button_Apply.TabStop = False
        Me.Button_Apply.Text = "Apply"
        Me.Button_Apply.UseVisualStyleBackColor = True
        '
        'Button_About
        '
        Me.Button_About.Location = New System.Drawing.Point(184, 3)
        Me.Button_About.Name = "Button_About"
        Me.Button_About.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.Button_About.Size = New System.Drawing.Size(75, 24)
        Me.Button_About.TabIndex = 2
        Me.Button_About.TabStop = False
        Me.Button_About.Text = "About"
        Me.Button_About.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(424, 401)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Button_Clear As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBox_Process As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox_Bound_X As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_Opacity As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_Caption As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_Class As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_Handle As System.Windows.Forms.TextBox
    Friend WithEvents Button_Apply As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button_About As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBox_Bound_Y As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextBox_Bound_W As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_Bound_H As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CheckBox_MaxBox As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox_Resize As System.Windows.Forms.CheckBox
    Friend WithEvents Label11 As System.Windows.Forms.Label

End Class
