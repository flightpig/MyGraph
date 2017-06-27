Public Class FormSplitGray
    Dim myGraph As ClassMyGrayGraph
    Dim bmpList As New List(Of Bitmap)
    Dim bmpIndex As Integer

    Dim formWidth As Integer
    Dim formHeight As Integer

    Private Sub FormSplitGray_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.ComboBoxGrayType.SelectedIndex = 0
        Me.formWidth = Me.Width
        Me.formHeight = Me.Height
    End Sub



    Private Sub ButtonOpen_Click(sender As Object, e As EventArgs) Handles ButtonOpen.Click
        If Me.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim path As String = Me.OpenFileDialog1.FileName
            myGraph = New ClassMyGrayGraph(path)

            Dim name() As String = path.Split("\")
            Me.Text = name(name.GetUpperBound(0)) & " (" & myGraph.Bmp.width & "," & myGraph.Bmp.height & ")"
            Me.PictureBoxOrg.Image = myGraph.Bmp.bmp
            Me.PanelSetup.Enabled = True
        End If
    End Sub

    Private Sub ButtonStart_Click(sender As Object, e As EventArgs) Handles ButtonStart.Click
        'Dim newGraph As New ClassMyGrayGraph
        'If Me.CheckBoxInvert.Checked Then
        '    newGraph.Bmp.bmp = myGraph.Bmp.Invert
        'Else
        '    newGraph.Bmp.bmp = myGraph.Bmp.bmp
        'End If
        myGraph.IsInvert = Me.CheckBoxInvert.Checked
        bmpList = myGraph.SplitGrayToBmpList(Me.TextBoxNum.Text.Trim, Me.ComboBoxGrayType.SelectedIndex)

        If Me.CheckBoxReverseSelect.Checked Then
            Dim newBmpList As New List(Of Bitmap)
            For Each newBmp As Bitmap In bmpList
                newBmpList.Add(Me.setReverseSelect(newBmp))
            Next
            bmpList = newBmpList
        End If

        If Not bmpList Is Nothing Then
            Me.SetResultCombo()
            Me.PanelResultTool.Enabled = True
        Else
            Me.PanelResultTool.Enabled = False
        End If
        'newGraph.Bmp.bmp.Dispose()
        'newGraph = Nothing
    End Sub

    Private Sub ComboBoxSelectNum_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxSelectNum.SelectedIndexChanged
        Me.PictureBoxTarget.Image = bmpList(Me.ComboBoxSelectNum.SelectedIndex)
        Me.bmpIndex = Me.ComboBoxSelectNum.SelectedIndex
    End Sub

    Private Sub ButtonShowNext_Click(sender As Object, e As EventArgs) Handles ButtonShowNext.Click
        bmpIndex += 1
        If bmpIndex > bmpList.Count - 1 Then bmpIndex = 0
        Me.ComboBoxSelectNum.SelectedIndex = bmpIndex
    End Sub

    Private Sub FormSplitGray_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Dim width As Integer = Me.Width
        Dim height As Integer = Me.Height

        If Me.Width > Me.formWidth And Me.Height > Me.formHeight Then

        End If
    End Sub

    Private Sub ButtonSaveSingle_Click(sender As Object, e As EventArgs) Handles ButtonSaveSingle.Click
        If bmpList.Count > 0 Then
            If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                bmpList(Me.ComboBoxSelectNum.SelectedIndex).Save(Me.SaveFileDialog1.FileName & ".jpg", Imaging.ImageFormat.Jpeg)
            End If
        End If
    End Sub

    Private Sub ButtonSpcGray_Click(sender As Object, e As EventArgs) Handles ButtonSpcGray.Click
        If Me.TextBoxSpcGrayValue.Text.Trim = "" Then Exit Sub
        'Dim newGraph As New ClassMyGrayGraph
        'If Me.CheckBoxInvert.Checked Then
        '    newGraph.Bmp.bmp = myGraph.Bmp.Invert
        'Else
        '    newGraph.Bmp.bmp = myGraph.Bmp.bmp
        'End If

        Dim val() As Integer = Me.GetGrayRange
        Me.myGraph.IsInvert = Me.CheckBoxInvert.Checked
        myGraph.SetPixelList()
        Dim newbmp As Bitmap = myGraph.GetGrayRangeByList(myGraph.PixelList, val(0), val(1), Me.ComboBoxGrayType.SelectedIndex)

        newbmp = setReverseSelect(newbmp)

        bmpList.Clear()
        bmpList.Add(newbmp)
        SetResultCombo()

        'newGraph.Bmp.bmp.Dispose()
        'newGraph = Nothing
    End Sub

    ''' <summary>
    ''' 取得gray的範圍
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetGrayRange() As Integer()
        Dim grayValue As Integer = Me.HScrollBarGrayRange.Value
        Dim range As Integer = Me.TextBoxSpcGrayValue.Text.Trim
        Dim min As Integer = grayValue - range / 2
        If min < 5 Then min = 5
        Dim max As Integer = grayValue + range / 2
        If max > 250 Then max = 250
        Dim val(2) As Integer
        val(0) = min
        val(1) = max
        Return val
    End Function

    ''' <summary>
    ''' 設定ResultCombo
    ''' </summary>
    ''' <remarks></remarks>
    Sub SetResultCombo()
        Me.ComboBoxSelectNum.Items.Clear()
        For i As Integer = 0 To bmpList.Count - 1
            Me.ComboBoxSelectNum.Items.Add(i + 1)
        Next
        Me.ComboBoxSelectNum.SelectedIndex = 0
        bmpIndex = 0
    End Sub

    Private Sub ButtonSaveAll_Click(sender As Object, e As EventArgs) Handles ButtonSaveAll.Click
        If bmpList.Count > 0 Then
            If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim path As String = Me.SaveFileDialog1.FileName
                path = path.Remove(path.LastIndexOf(".jpg"))
                Dim index As Integer = 1
                For Each bmp As Bitmap In bmpList
                    bmp.Save(path & "-" & index & ".jpg", Imaging.ImageFormat.Jpeg)
                    index += 1
                Next
            End If
        End If
    End Sub

    Private Sub ButtonShowPrv_Click(sender As Object, e As EventArgs) Handles ButtonShowPrv.Click
        bmpIndex -= 1
        If bmpIndex < 0 Then bmpIndex = bmpList.Count - 1
        Me.ComboBoxSelectNum.SelectedIndex = bmpIndex
    End Sub

    Private Sub HScrollBarGrayRange_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBarGrayRange.Scroll
        Me.LabelShowHScrollBar.Text = HScrollBarGrayRange.Value

        If Me.myGraph.PixelList.Count > 0 Then
            Me.myGraph.IsInvert = Me.CheckBoxInvert.Checked
            Dim val() As Integer = Me.GetGrayRange
            Dim newbmp As Bitmap = Me.myGraph.GetGrayRangeByList(Me.myGraph.PixelList, val(0), val(1), Me.ComboBoxGrayType.SelectedIndex)

            newbmp = setReverseSelect(newbmp)

            bmpList.Clear()
            bmpList.Add(newbmp)
            SetResultCombo()
        End If
    End Sub

    ''' <summary>
    ''' 反向選擇
    ''' </summary>
    ''' <param name="newBmp"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function setReverseSelect(newBmp As Bitmap) As Bitmap
        If Me.CheckBoxReverseSelect.Checked Then
            Dim ClsBmp As New ClassBmp(newBmp)
            newBmp = ClsBmp.Negative()
            ' newBmp = ClsBmp.Invert
            ClsBmp.bmp.Dispose()
        End If
        Return newBmp
    End Function


    Private Sub ComboBoxGrayType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxGrayType.SelectedIndexChanged
        If Not Me.myGraph Is Nothing Then
            If Me.myGraph.PixelList.Count > 0 Then

            End If
        End If

    End Sub
End Class