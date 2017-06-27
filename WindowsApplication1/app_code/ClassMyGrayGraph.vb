Imports System.Threading
Public Class ClassMyGrayGraph
    Inherits ClassMyGraph

    Dim MyGrayMax As Integer = 250
    ''' <summary>
    ''' 初始最大灰度值
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property GrayMax As Integer
        Get
            Return MyGrayMax
        End Get
        Set(value As Integer)
            MyGrayMax = value
        End Set
    End Property

    Dim MyGrayMin As Integer = 5
    ''' <summary>
    ''' 初始最小灰度值
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property GrayMin As Integer
        Get
            Return MyGrayMin
        End Get
        Set(value As Integer)
            MyGrayMin = value
        End Set
    End Property

    Dim MyIsInvert As Boolean
    ''' <summary>
    ''' 是否負片
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property IsInvert As Boolean
        Get
            Return MyIsInvert
        End Get
        Set(value As Boolean)
            MyIsInvert = value
        End Set
    End Property

    Sub New()
        Me.Bmp = New ClassBmp
    End Sub

    Sub New(path As String)
        Me.Bmp = New ClassBmp(path)
    End Sub

    ''' <summary>
    ''' 灰階值的種類
    ''' </summary>
    ''' <remarks></remarks>
    Enum SplitGrayType As Integer
        originalColor = 0
        toGray = 1
        toBlack = 2
    End Enum

    ''' <summary>
    ''' 將灰階值拆成幾段的bitmap
    ''' </summary>
    ''' <param name="num">段數</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function SplitGrayToBmpList(num As Integer, Optional grayType As SplitGrayType = SplitGrayType.originalColor) As List(Of Bitmap)
        ' 0.299*R+ 0.587*G + 0.114*B
        If Not Me.Bmp.bmp Is Nothing Then
            '將像素轉成陣列
            Dim pixelList As List(Of ClassMyPixel) = Me.GetPixelList

            If Me.IsInvert Then
                pixelList = Me.GetPixelInvert(pixelList)
            End If

            Dim maxGray = (From px As ClassMyPixel In pixelList Select px.gray).Max
            Dim grayStep As Double = maxGray / num
            'Debug.Print(maxGray & "," & grayStep & " --gray")

            '將灰階大小拆成段數
            Dim grayStepList As New List(Of Integer)
            For i As Integer = 0 To num
                grayStepList.Add(grayStep * i)
            Next

            'Dim timeS As Integer = System.Environment.TickCount


            Dim bmpList As New List(Of Bitmap)
            For i As Integer = 0 To grayStepList.Count - 2
                Dim newBmp As New Bitmap(Me.Bmp.width, Me.Bmp.height)
                Dim graph As Drawing.Graphics = Drawing.Graphics.FromImage(newBmp)
                graph.Clear(Drawing.Color.White)
                bmpList.Add(newBmp)
                graph.Dispose()
            Next

            For Each px As ClassMyPixel In pixelList
                For i As Integer = 0 To grayStepList.Count - 2
                    If px.gray > grayStepList(i) And px.gray < grayStepList(i + 1) Then
                        If px.gray < Me.GrayMax And px.gray > Me.GrayMin Then
                            px.level = i
                            Select Case grayType
                                Case SplitGrayType.toBlack
                                    bmpList(i).SetPixel(px.point.X, px.point.Y, Color.Black)
                                Case SplitGrayType.toGray
                                    bmpList(i).SetPixel(px.point.X, px.point.Y, Color.FromArgb(px.gray, px.gray, px.gray))
                                Case Else
                                    bmpList(i).SetPixel(px.point.X, px.point.Y, px.pixel)
                            End Select
                        End If
                        Exit For
                    End If
                Next
            Next



            'Dim timeE As Integer = System.Environment.TickCount
            'Dim timeDis As Integer = timeE - timeS
            'Debug.Print(timeS & "," & timeE & "," & timeDis & " -TimeE")
            Return bmpList
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    ''' 取得特定灰階值
    ''' </summary>
    ''' <param name="min"></param>
    ''' <param name="max"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetGrayRange(min As Integer, max As Integer, Optional grayType As SplitGrayType = SplitGrayType.originalColor) As Bitmap
        '將像素轉成陣列
        Dim newPixelList As List(Of ClassMyPixel) = Me.GetPixelList
        Return GetGrayRangeByList(newPixelList, min, max, grayType)

    End Function

    ''' <summary>
    ''' 由pixel陣列取得bitmap
    ''' </summary>
    ''' <param name="newPixelList"></param>
    ''' <param name="min"></param>
    ''' <param name="max"></param>
    ''' <param name="grayType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetGrayRangeByList(newPixelList As List(Of ClassMyPixel), min As Integer, max As Integer, Optional grayType As SplitGrayType = SplitGrayType.originalColor) As Bitmap
        Dim newList As List(Of ClassMyPixel) = Me.GetPixelRange(newPixelList, min, max)

        Dim newBmp As New Bitmap(Me.Bmp.width, Me.Bmp.height)
        Dim graph As Drawing.Graphics = Drawing.Graphics.FromImage(newBmp)
        graph.Clear(Drawing.Color.White)

        newBmp = Me.SplitGrayToBmp(newBmp, newList, grayType)

        graph.Dispose()
        Return newBmp
    End Function

    ''' <summary>
    ''' 由拆灰階種類傳回圖
    ''' </summary>
    ''' <param name="newbmp"></param>
    ''' <param name="grayType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function SplitGrayToBmp(newbmp As Bitmap, pixelList As List(Of ClassMyPixel), Optional grayType As SplitGrayType = SplitGrayType.originalColor) As Bitmap
        Dim newPxList As List(Of ClassMyPixel)
        If Me.IsInvert Then
            newPxList = Me.GetPixelInvert(pixelList)
        Else
            newPxList = pixelList
        End If

        Select Case grayType
            Case SplitGrayType.toBlack
                For Each px As ClassMyPixel In newPxList
                    If px.gray < Me.GrayMax And px.gray > Me.GrayMin Then
                        newbmp.SetPixel(px.point.X, px.point.Y, Color.Black)
                    End If
                Next
            Case SplitGrayType.toGray
                For Each px As ClassMyPixel In newPxList
                    If px.gray < Me.GrayMax And px.gray > Me.GrayMin Then
                        newbmp.SetPixel(px.point.X, px.point.Y, Color.FromArgb(px.gray, px.gray, px.gray))
                    End If
                Next
            Case Else
                For Each px As ClassMyPixel In newPxList
                    If px.gray < Me.GrayMax And px.gray > Me.GrayMin Then
                        newbmp.SetPixel(px.point.X, px.point.Y, px.pixel)
                    End If
                Next
        End Select

        Return newbmp
    End Function

    ''' <summary>
    ''' 取得特定範圍內灰度值的pixel
    ''' </summary>
    ''' <param name="min"></param>
    ''' <param name="max"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetPixelRange(PixelList As List(Of ClassMyPixel), min As Integer, max As Integer) As List(Of ClassMyPixel)
        Dim newList As New List(Of ClassMyPixel)
        For Each px As ClassMyPixel In PixelList
            If px.gray > min And px.gray < max Then
                newList.Add(px)
            End If
        Next
        Return newList
    End Function

    ''' <summary>
    ''' 轉換負片pixel
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetPixelInvert(newPxList As List(Of ClassMyPixel)) As List(Of ClassMyPixel)
        Dim newList As New List(Of ClassMyPixel)
        For Each px As ClassMyPixel In newPxList
            Dim newPx As New ClassMyPixel(px.point.X, px.point.Y, Drawing.Color.FromArgb(255 - px.pixel.R, 255 - px.pixel.G, 255 - px.pixel.B))
            newList.Add(newPx)
        Next
        Return newList
    End Function

End Class
