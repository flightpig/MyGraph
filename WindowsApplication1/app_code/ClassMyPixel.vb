Public Class ClassMyPixel
    Dim MyPixel As New Drawing.Color
    Property pixel As Color
        Get
            Return MyPixel
        End Get
        Set(value As Color)
            MyPixel = value
        End Set
    End Property

    Dim MyID As Integer
    Property ID As Integer
        Get
            Return MyID
        End Get
        Set(value As Integer)
            MyID = value
        End Set
    End Property

    Dim MyPoint As New ClassPoint2D
    Property point As ClassPoint2D
        Get
            Return MyPoint
        End Get
        Set(value As ClassPoint2D)
            MyPoint = value
        End Set
    End Property

    ReadOnly Property DrawingPt As Drawing.Point
        Get
            Return New Drawing.Point(Me.point.X, Me.point.Y)
        End Get
    End Property

    Dim MyLevel As Integer
    ''' <summary>
    ''' 我的層級
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property level As Integer
        Get
            Return MyLevel
        End Get
        Set(value As Integer)
            MyLevel = value
        End Set
    End Property

    Sub New()

    End Sub

    Sub New(x As Integer, y As Integer, newPixel As Drawing.Color)
        Me.point.X = x
        Me.point.Y = y
        Me.pixel = newPixel
        Me.gray = Me.GetGrayValue(newPixel)
    End Sub

    Sub New(newPixel As Color)
        Me.pixel = newPixel
        Me.gray = Me.GetGrayValue(newPixel)
    End Sub

    Dim MyGray As Integer
    ''' <summary>
    ''' 灰度值
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property gray As Integer
        Get
            Return MyGray
        End Get
        Set(value As Integer)
            MyGray = value
        End Set
    End Property

    ''' <summary>
    ''' 計算灰度值
    ''' </summary>
    ''' <param name="r"></param>
    ''' <param name="g"></param>
    ''' <param name="b"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetGrayValue(r As Integer, g As Integer, b As Integer) As Integer
        Return r * 0.299 + g * 0.587 + b * 0.114
    End Function

    ''' <summary>
    ''' 計算灰度值
    ''' </summary>
    ''' <param name="newPixel"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetGrayValue(newPixel As Color) As Integer
        Return Me.GetGrayValue(newPixel.R, newPixel.G, newPixel.B)
    End Function

End Class
