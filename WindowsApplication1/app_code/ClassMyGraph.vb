Public Class ClassMyGraph
    Dim MyBmp As ClassBmp
    Property Bmp As ClassBmp
        Get
            Return MyBmp
        End Get
        Set(value As ClassBmp)
            MyBmp = value
        End Set
    End Property

    Dim MyPixelList As New List(Of ClassMyPixel)
    Property PixelList As List(Of ClassMyPixel)
        Get
            Return MyPixelList
        End Get
        Set(value As List(Of ClassMyPixel))
            MyPixelList = value
        End Set
    End Property

    Dim MyResultBmpList As New List(Of Bitmap)
    Property ResultBmpList As List(Of Bitmap)
        Get
            Return MyResultBmpList
        End Get
        Set(value As List(Of Bitmap))
            MyResultBmpList = value
        End Set
    End Property

    ''' <summary>
    ''' 將像素轉成陣列
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetPixelList() As List(Of ClassMyPixel)
        Dim pixelList As New List(Of ClassMyPixel)

        '將像素轉成陣列
        For i As Integer = 0 To Me.Bmp.width - 1
            For j As Integer = 0 To Me.Bmp.height - 1
                Dim myPixel As New ClassMyPixel(i, j, Me.Bmp.bmp.GetPixel(i, j))
                pixelList.Add(myPixel)
            Next
        Next
        Return pixelList
    End Function

    ''' <summary>
    ''' 設定像素陣列
    ''' </summary>
    ''' <remarks></remarks>
    Sub SetPixelList()
        Me.PixelList = Me.GetPixelList
    End Sub
End Class
