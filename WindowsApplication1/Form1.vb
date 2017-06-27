Public Class Form1
    Dim bmp As ClassBmp
    Dim myGraph As New ClassMyGrayGraph

    Private Sub ButtonOpen_Click(sender As Object, e As EventArgs) Handles ButtonOpen.Click
        If Me.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim path As String = Me.OpenFileDialog1.FileName
            bmp = New ClassBmp(path)
            myGraph.Bmp = bmp
            Me.PictureBoxOrg.Image = bmp.Bmp
            Dim name() As String = path.Split("\")

            Me.Text = name(name.GetUpperBound(0)) & " (" & bmp.Bmp.Width & "," & bmp.Bmp.Height & ")"
        End If
    End Sub

    Private Sub ButtonSetGray_Click(sender As Object, e As EventArgs) Handles ButtonSetGray.Click
        Me.PictureBoxTarget.Image = bmp.GetGray
    End Sub

    Private Sub ButtonTransport_Click(sender As Object, e As EventArgs) Handles ButtonTransport.Click
        Me.PictureBoxTarget.Image = bmp.Transport
    End Sub

    Private Sub ButtonShift_Click(sender As Object, e As EventArgs) Handles ButtonShift.Click
        Me.PictureBoxTarget.Image = bmp.Shift(-100, -100)
    End Sub

    Private Sub ButtonHorizontalMirror_Click(sender As Object, e As EventArgs) Handles ButtonHorizontalMirror.Click
        Me.PictureBoxTarget.Image = bmp.HorizontalMirror
    End Sub

    Private Sub ButtonVerticalMirror_Click(sender As Object, e As EventArgs) Handles ButtonVerticalMirror.Click
        Me.PictureBoxTarget.Image = bmp.VerticalMirror
    End Sub

    Dim bmpList As List(Of Bitmap)
    Dim bmpIndex As Integer
    Private Sub ButtonSplitGray_Click(sender As Object, e As EventArgs) Handles ButtonSplitGray.Click
        bmpList = Me.myGraph.SplitGrayToBmpList(4, ClassMyGrayGraph.SplitGrayType.toBlack)
        Me.PictureBoxTarget.Image = bmpList(bmpIndex)
    End Sub

    Private Sub ButtonNext_Click(sender As Object, e As EventArgs) Handles ButtonNext.Click
        bmpIndex += 1
        If bmpIndex > bmpList.Count - 1 Then bmpIndex = 0
        Me.PictureBoxTarget.Image = bmpList(bmpIndex)
    End Sub
End Class
