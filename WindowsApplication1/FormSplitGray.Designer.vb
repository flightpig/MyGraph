<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSplitGray
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
        Me.ButtonStart = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxNum = New System.Windows.Forms.TextBox()
        Me.PictureBoxTarget = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBoxSelectNum = New System.Windows.Forms.ComboBox()
        Me.ButtonSaveSingle = New System.Windows.Forms.Button()
        Me.ButtonSaveAll = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.ComboBoxGrayType = New System.Windows.Forms.ComboBox()
        Me.ButtonShowNext = New System.Windows.Forms.Button()
        Me.PanelResultTool = New System.Windows.Forms.Panel()
        Me.ButtonShowPrv = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBoxSpcGrayValue = New System.Windows.Forms.TextBox()
        Me.ButtonSpcGray = New System.Windows.Forms.Button()
        Me.PanelSetup = New System.Windows.Forms.Panel()
        Me.CheckBoxReverseSelect = New System.Windows.Forms.CheckBox()
        Me.LabelShowHScrollBar = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.HScrollBarGrayRange = New System.Windows.Forms.HScrollBar()
        Me.StatusStripGray = New System.Windows.Forms.StatusStrip()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.CheckBoxInvert = New System.Windows.Forms.CheckBox()
        CType(Me.PictureBoxOrg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxTarget, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelResultTool.SuspendLayout()
        Me.PanelSetup.SuspendLayout()
        Me.StatusStripGray.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonOpen
        '
        Me.ButtonOpen.Location = New System.Drawing.Point(2, 3)
        Me.ButtonOpen.Name = "ButtonOpen"
        Me.ButtonOpen.Size = New System.Drawing.Size(75, 23)
        Me.ButtonOpen.TabIndex = 0
        Me.ButtonOpen.Text = "開啟檔案"
        Me.ButtonOpen.UseVisualStyleBackColor = True
        '
        'PictureBoxOrg
        '
        Me.PictureBoxOrg.BackColor = System.Drawing.Color.White
        Me.PictureBoxOrg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBoxOrg.Location = New System.Drawing.Point(2, 81)
        Me.PictureBoxOrg.Name = "PictureBoxOrg"
        Me.PictureBoxOrg.Size = New System.Drawing.Size(400, 300)
        Me.PictureBoxOrg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxOrg.TabIndex = 1
        Me.PictureBoxOrg.TabStop = False
        '
        'ButtonStart
        '
        Me.ButtonStart.Location = New System.Drawing.Point(161, 3)
        Me.ButtonStart.Name = "ButtonStart"
        Me.ButtonStart.Size = New System.Drawing.Size(75, 23)
        Me.ButtonStart.TabIndex = 2
        Me.ButtonStart.Text = "切割灰階值"
        Me.ButtonStart.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "張數"
        '
        'TextBoxNum
        '
        Me.TextBoxNum.Location = New System.Drawing.Point(37, 3)
        Me.TextBoxNum.Name = "TextBoxNum"
        Me.TextBoxNum.Size = New System.Drawing.Size(30, 22)
        Me.TextBoxNum.TabIndex = 4
        Me.TextBoxNum.Text = "3"
        Me.TextBoxNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PictureBoxTarget
        '
        Me.PictureBoxTarget.BackColor = System.Drawing.Color.White
        Me.PictureBoxTarget.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBoxTarget.Location = New System.Drawing.Point(420, 82)
        Me.PictureBoxTarget.Name = "PictureBoxTarget"
        Me.PictureBoxTarget.Size = New System.Drawing.Size(400, 300)
        Me.PictureBoxTarget.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxTarget.TabIndex = 1
        Me.PictureBoxTarget.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "選擇張數"
        '
        'ComboBoxSelectNum
        '
        Me.ComboBoxSelectNum.FormattingEnabled = True
        Me.ComboBoxSelectNum.Location = New System.Drawing.Point(59, 5)
        Me.ComboBoxSelectNum.Name = "ComboBoxSelectNum"
        Me.ComboBoxSelectNum.Size = New System.Drawing.Size(36, 20)
        Me.ComboBoxSelectNum.TabIndex = 6
        '
        'ButtonSaveSingle
        '
        Me.ButtonSaveSingle.Location = New System.Drawing.Point(229, 3)
        Me.ButtonSaveSingle.Name = "ButtonSaveSingle"
        Me.ButtonSaveSingle.Size = New System.Drawing.Size(75, 23)
        Me.ButtonSaveSingle.TabIndex = 7
        Me.ButtonSaveSingle.Text = "單張存檔"
        Me.ButtonSaveSingle.UseVisualStyleBackColor = True
        '
        'ButtonSaveAll
        '
        Me.ButtonSaveAll.Location = New System.Drawing.Point(307, 3)
        Me.ButtonSaveAll.Name = "ButtonSaveAll"
        Me.ButtonSaveAll.Size = New System.Drawing.Size(75, 23)
        Me.ButtonSaveAll.TabIndex = 8
        Me.ButtonSaveAll.Text = "全部存檔"
        Me.ButtonSaveAll.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Filter = "jpg|*.jpg|所有檔案|*.*"
        '
        'ComboBoxGrayType
        '
        Me.ComboBoxGrayType.FormattingEnabled = True
        Me.ComboBoxGrayType.Items.AddRange(New Object() {"彩色", "灰階", "黑白"})
        Me.ComboBoxGrayType.Location = New System.Drawing.Point(74, 3)
        Me.ComboBoxGrayType.Name = "ComboBoxGrayType"
        Me.ComboBoxGrayType.Size = New System.Drawing.Size(81, 20)
        Me.ComboBoxGrayType.TabIndex = 9
        '
        'ButtonShowNext
        '
        Me.ButtonShowNext.Location = New System.Drawing.Point(160, 2)
        Me.ButtonShowNext.Name = "ButtonShowNext"
        Me.ButtonShowNext.Size = New System.Drawing.Size(50, 23)
        Me.ButtonShowNext.TabIndex = 10
        Me.ButtonShowNext.Text = "下一張"
        Me.ButtonShowNext.UseVisualStyleBackColor = True
        '
        'PanelResultTool
        '
        Me.PanelResultTool.Controls.Add(Me.ButtonShowPrv)
        Me.PanelResultTool.Controls.Add(Me.ButtonSaveSingle)
        Me.PanelResultTool.Controls.Add(Me.ButtonShowNext)
        Me.PanelResultTool.Controls.Add(Me.Label2)
        Me.PanelResultTool.Controls.Add(Me.ComboBoxSelectNum)
        Me.PanelResultTool.Controls.Add(Me.ButtonSaveAll)
        Me.PanelResultTool.Enabled = False
        Me.PanelResultTool.Location = New System.Drawing.Point(420, 47)
        Me.PanelResultTool.Name = "PanelResultTool"
        Me.PanelResultTool.Size = New System.Drawing.Size(385, 30)
        Me.PanelResultTool.TabIndex = 11
        '
        'ButtonShowPrv
        '
        Me.ButtonShowPrv.Location = New System.Drawing.Point(101, 2)
        Me.ButtonShowPrv.Name = "ButtonShowPrv"
        Me.ButtonShowPrv.Size = New System.Drawing.Size(56, 23)
        Me.ButtonShowPrv.TabIndex = 11
        Me.ButtonShowPrv.Text = "上一張"
        Me.ButtonShowPrv.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 12)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "灰階值"
        '
        'TextBoxSpcGrayValue
        '
        Me.TextBoxSpcGrayValue.Location = New System.Drawing.Point(223, 29)
        Me.TextBoxSpcGrayValue.Name = "TextBoxSpcGrayValue"
        Me.TextBoxSpcGrayValue.Size = New System.Drawing.Size(36, 22)
        Me.TextBoxSpcGrayValue.TabIndex = 13
        Me.TextBoxSpcGrayValue.Text = "75"
        Me.TextBoxSpcGrayValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ButtonSpcGray
        '
        Me.ButtonSpcGray.Location = New System.Drawing.Point(322, 28)
        Me.ButtonSpcGray.Name = "ButtonSpcGray"
        Me.ButtonSpcGray.Size = New System.Drawing.Size(75, 23)
        Me.ButtonSpcGray.TabIndex = 14
        Me.ButtonSpcGray.Text = "特定灰階值"
        Me.ButtonSpcGray.UseVisualStyleBackColor = True
        '
        'PanelSetup
        '
        Me.PanelSetup.Controls.Add(Me.CheckBoxInvert)
        Me.PanelSetup.Controls.Add(Me.CheckBoxReverseSelect)
        Me.PanelSetup.Controls.Add(Me.LabelShowHScrollBar)
        Me.PanelSetup.Controls.Add(Me.Label4)
        Me.PanelSetup.Controls.Add(Me.HScrollBarGrayRange)
        Me.PanelSetup.Controls.Add(Me.ButtonSpcGray)
        Me.PanelSetup.Controls.Add(Me.ButtonStart)
        Me.PanelSetup.Controls.Add(Me.TextBoxSpcGrayValue)
        Me.PanelSetup.Controls.Add(Me.Label1)
        Me.PanelSetup.Controls.Add(Me.Label3)
        Me.PanelSetup.Controls.Add(Me.TextBoxNum)
        Me.PanelSetup.Controls.Add(Me.ComboBoxGrayType)
        Me.PanelSetup.Enabled = False
        Me.PanelSetup.Location = New System.Drawing.Point(2, 26)
        Me.PanelSetup.Name = "PanelSetup"
        Me.PanelSetup.Size = New System.Drawing.Size(400, 54)
        Me.PanelSetup.TabIndex = 15
        '
        'CheckBoxReverseSelect
        '
        Me.CheckBoxReverseSelect.AutoSize = True
        Me.CheckBoxReverseSelect.Location = New System.Drawing.Point(270, 33)
        Me.CheckBoxReverseSelect.Name = "CheckBoxReverseSelect"
        Me.CheckBoxReverseSelect.Size = New System.Drawing.Size(48, 16)
        Me.CheckBoxReverseSelect.TabIndex = 20
        Me.CheckBoxReverseSelect.Text = "反相"
        Me.CheckBoxReverseSelect.UseVisualStyleBackColor = True
        '
        'LabelShowHScrollBar
        '
        Me.LabelShowHScrollBar.AutoSize = True
        Me.LabelShowHScrollBar.Location = New System.Drawing.Point(167, 35)
        Me.LabelShowHScrollBar.Name = "LabelShowHScrollBar"
        Me.LabelShowHScrollBar.Size = New System.Drawing.Size(23, 12)
        Me.LabelShowHScrollBar.TabIndex = 19
        Me.LabelShowHScrollBar.Text = "100"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(192, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 12)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "範圍"
        '
        'HScrollBarGrayRange
        '
        Me.HScrollBarGrayRange.Location = New System.Drawing.Point(46, 32)
        Me.HScrollBarGrayRange.Maximum = 255
        Me.HScrollBarGrayRange.Name = "HScrollBarGrayRange"
        Me.HScrollBarGrayRange.Size = New System.Drawing.Size(119, 19)
        Me.HScrollBarGrayRange.TabIndex = 17
        Me.HScrollBarGrayRange.Value = 100
        '
        'StatusStripGray
        '
        Me.StatusStripGray.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar1})
        Me.StatusStripGray.Location = New System.Drawing.Point(0, 363)
        Me.StatusStripGray.Name = "StatusStripGray"
        Me.StatusStripGray.Size = New System.Drawing.Size(824, 22)
        Me.StatusStripGray.TabIndex = 16
        Me.StatusStripGray.Text = "StatusStrip1"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 16)
        '
        'CheckBoxInvert
        '
        Me.CheckBoxInvert.AutoSize = True
        Me.CheckBoxInvert.Location = New System.Drawing.Point(270, 11)
        Me.CheckBoxInvert.Name = "CheckBoxInvert"
        Me.CheckBoxInvert.Size = New System.Drawing.Size(48, 16)
        Me.CheckBoxInvert.TabIndex = 20
        Me.CheckBoxInvert.Text = "負片"
        Me.CheckBoxInvert.UseVisualStyleBackColor = True
        '
        'FormSplitGray
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(824, 385)
        Me.Controls.Add(Me.StatusStripGray)
        Me.Controls.Add(Me.PanelSetup)
        Me.Controls.Add(Me.PanelResultTool)
        Me.Controls.Add(Me.PictureBoxTarget)
        Me.Controls.Add(Me.PictureBoxOrg)
        Me.Controls.Add(Me.ButtonOpen)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSplitGray"
        Me.Text = "拆灰階值"
        CType(Me.PictureBoxOrg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxTarget, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelResultTool.ResumeLayout(False)
        Me.PanelResultTool.PerformLayout()
        Me.PanelSetup.ResumeLayout(False)
        Me.PanelSetup.PerformLayout()
        Me.StatusStripGray.ResumeLayout(False)
        Me.StatusStripGray.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonOpen As System.Windows.Forms.Button
    Friend WithEvents PictureBoxOrg As System.Windows.Forms.PictureBox
    Friend WithEvents ButtonStart As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNum As System.Windows.Forms.TextBox
    Friend WithEvents PictureBoxTarget As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxSelectNum As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonSaveSingle As System.Windows.Forms.Button
    Friend WithEvents ButtonSaveAll As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ComboBoxGrayType As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonShowNext As System.Windows.Forms.Button
    Friend WithEvents PanelResultTool As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBoxSpcGrayValue As System.Windows.Forms.TextBox
    Friend WithEvents ButtonSpcGray As System.Windows.Forms.Button
    Friend WithEvents PanelSetup As System.Windows.Forms.Panel
    Friend WithEvents ButtonShowPrv As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents HScrollBarGrayRange As System.Windows.Forms.HScrollBar
    Friend WithEvents StatusStripGray As System.Windows.Forms.StatusStrip
    Friend WithEvents LabelShowHScrollBar As System.Windows.Forms.Label
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents CheckBoxReverseSelect As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxInvert As System.Windows.Forms.CheckBox
End Class
