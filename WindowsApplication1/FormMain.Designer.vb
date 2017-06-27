<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
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
        Me.ButtonShowSplitGray = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ButtonShowSplitGray
        '
        Me.ButtonShowSplitGray.Location = New System.Drawing.Point(2, 1)
        Me.ButtonShowSplitGray.Name = "ButtonShowSplitGray"
        Me.ButtonShowSplitGray.Size = New System.Drawing.Size(75, 23)
        Me.ButtonShowSplitGray.TabIndex = 0
        Me.ButtonShowSplitGray.Text = "拆灰階值"
        Me.ButtonShowSplitGray.UseVisualStyleBackColor = True
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(539, 92)
        Me.Controls.Add(Me.ButtonShowSplitGray)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMain"
        Me.Text = "轉圖小工具"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButtonShowSplitGray As System.Windows.Forms.Button
End Class
