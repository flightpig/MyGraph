<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
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

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意:  以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ButtonOpen = New System.Windows.Forms.Button()
        Me.PictureBoxOrg = New System.Windows.Forms.PictureBox()
        Me.PictureBoxTarget = New System.Windows.Forms.PictureBox()
        Me.ButtonSetGray = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ButtonTransport = New System.Windows.Forms.Button()
        Me.ButtonShift = New System.Windows.Forms.Button()
        Me.ButtonHorizontalMirror = New System.Windows.Forms.Button()
        Me.ButtonVerticalMirror = New System.Windows.Forms.Button()
        Me.ButtonSplitGray = New System.Windows.Forms.Button()
        Me.ButtonNext = New System.Windows.Forms.Button()
        CType(Me.PictureBoxOrg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxTarget, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonOpen
        '
        Me.ButtonOpen.Location = New System.Drawing.Point(12, 12)
        Me.ButtonOpen.Name = "ButtonOpen"
        Me.ButtonOpen.Size = New System.Drawing.Size(75, 23)
        Me.ButtonOpen.TabIndex = 0
        Me.ButtonOpen.Text = "開啟"
        Me.ButtonOpen.UseVisualStyleBackColor = True
        '
        'PictureBoxOrg
        '
        Me.PictureBoxOrg.Location = New System.Drawing.Point(12, 41)
        Me.PictureBoxOrg.Name = "PictureBoxOrg"
        Me.PictureBoxOrg.Size = New System.Drawing.Size(300, 300)
        Me.PictureBoxOrg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxOrg.TabIndex = 1
        Me.PictureBoxOrg.TabStop = False
        '
        'PictureBoxTarget
        '
        Me.PictureBoxTarget.Location = New System.Drawing.Point(327, 41)
        Me.PictureBoxTarget.Name = "PictureBoxTarget"
        Me.PictureBoxTarget.Size = New System.Drawing.Size(300, 300)
        Me.PictureBoxTarget.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxTarget.TabIndex = 1
        Me.PictureBoxTarget.TabStop = False
        '
        'ButtonSetGray
        '
        Me.ButtonSetGray.Location = New System.Drawing.Point(93, 12)
        Me.ButtonSetGray.Name = "ButtonSetGray"
        Me.ButtonSetGray.Size = New System.Drawing.Size(75, 23)
        Me.ButtonSetGray.TabIndex = 2
        Me.ButtonSetGray.Text = "灰階"
        Me.ButtonSetGray.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'ButtonTransport
        '
        Me.ButtonTransport.Location = New System.Drawing.Point(174, 12)
        Me.ButtonTransport.Name = "ButtonTransport"
        Me.ButtonTransport.Size = New System.Drawing.Size(75, 23)
        Me.ButtonTransport.TabIndex = 2
        Me.ButtonTransport.Text = "轉置"
        Me.ButtonTransport.UseVisualStyleBackColor = True
        '
        'ButtonShift
        '
        Me.ButtonShift.Location = New System.Drawing.Point(256, 12)
        Me.ButtonShift.Name = "ButtonShift"
        Me.ButtonShift.Size = New System.Drawing.Size(75, 23)
        Me.ButtonShift.TabIndex = 3
        Me.ButtonShift.Text = "平移"
        Me.ButtonShift.UseVisualStyleBackColor = True
        '
        'ButtonHorizontalMirror
        '
        Me.ButtonHorizontalMirror.Location = New System.Drawing.Point(338, 11)
        Me.ButtonHorizontalMirror.Name = "ButtonHorizontalMirror"
        Me.ButtonHorizontalMirror.Size = New System.Drawing.Size(75, 23)
        Me.ButtonHorizontalMirror.TabIndex = 4
        Me.ButtonHorizontalMirror.Text = "水平鏡射"
        Me.ButtonHorizontalMirror.UseVisualStyleBackColor = True
        '
        'ButtonVerticalMirror
        '
        Me.ButtonVerticalMirror.Location = New System.Drawing.Point(419, 11)
        Me.ButtonVerticalMirror.Name = "ButtonVerticalMirror"
        Me.ButtonVerticalMirror.Size = New System.Drawing.Size(75, 23)
        Me.ButtonVerticalMirror.TabIndex = 5
        Me.ButtonVerticalMirror.Text = "垂直鏡射"
        Me.ButtonVerticalMirror.UseVisualStyleBackColor = True
        '
        'ButtonSplitGray
        '
        Me.ButtonSplitGray.Location = New System.Drawing.Point(500, 11)
        Me.ButtonSplitGray.Name = "ButtonSplitGray"
        Me.ButtonSplitGray.Size = New System.Drawing.Size(75, 23)
        Me.ButtonSplitGray.TabIndex = 7
        Me.ButtonSplitGray.Text = "拆灰階值"
        Me.ButtonSplitGray.UseVisualStyleBackColor = True
        '
        'ButtonNext
        '
        Me.ButtonNext.Location = New System.Drawing.Point(581, 11)
        Me.ButtonNext.Name = "ButtonNext"
        Me.ButtonNext.Size = New System.Drawing.Size(75, 23)
        Me.ButtonNext.TabIndex = 8
        Me.ButtonNext.Text = "next"
        Me.ButtonNext.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(683, 351)
        Me.Controls.Add(Me.ButtonNext)
        Me.Controls.Add(Me.ButtonSplitGray)
        Me.Controls.Add(Me.ButtonVerticalMirror)
        Me.Controls.Add(Me.ButtonHorizontalMirror)
        Me.Controls.Add(Me.ButtonShift)
        Me.Controls.Add(Me.ButtonTransport)
        Me.Controls.Add(Me.ButtonSetGray)
        Me.Controls.Add(Me.PictureBoxTarget)
        Me.Controls.Add(Me.PictureBoxOrg)
        Me.Controls.Add(Me.ButtonOpen)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.PictureBoxOrg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxTarget, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButtonOpen As System.Windows.Forms.Button
    Friend WithEvents PictureBoxOrg As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxTarget As System.Windows.Forms.PictureBox
    Friend WithEvents ButtonSetGray As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ButtonTransport As System.Windows.Forms.Button
    Friend WithEvents ButtonShift As System.Windows.Forms.Button
    Friend WithEvents ButtonHorizontalMirror As System.Windows.Forms.Button
    Friend WithEvents ButtonVerticalMirror As System.Windows.Forms.Button
    Friend WithEvents ButtonSplitGray As System.Windows.Forms.Button
    Friend WithEvents ButtonNext As System.Windows.Forms.Button

End Class
