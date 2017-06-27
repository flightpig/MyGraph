Imports Microsoft.VisualBasic
Imports System.Drawing.Imaging
Imports System.Drawing

Public Class ClassBmp
    Dim MyBmp As Drawing.Bitmap
    ''' <summary>
    ''' 圖片bmp
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property bmp As Drawing.Bitmap
        Get
            Return MyBmp
        End Get
        Set(ByVal value As Drawing.Bitmap)
            MyBmp = value
        End Set
    End Property

    Dim MyInterpolationMode As Drawing.Drawing2D.InterpolationMode = Drawing.Drawing2D.InterpolationMode.High
    ''' <summary>
    ''' 縮放或平移使用的演算法
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property InterpolationMode As Drawing.Drawing2D.InterpolationMode
        Get
            Return MyInterpolationMode
        End Get
        Set(ByVal value As Drawing.Drawing2D.InterpolationMode)
            MyInterpolationMode = value
        End Set
    End Property

    Dim MySmoothingMode As Drawing.Drawing2D.SmoothingMode = Drawing.Drawing2D.SmoothingMode.HighSpeed
    ''' <summary>
    ''' 設定平滑模式
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property SmoothingMode As Drawing.Drawing2D.SmoothingMode
        Get
            Return MySmoothingMode
        End Get
        Set(ByVal value As Drawing.Drawing2D.SmoothingMode)
            MySmoothingMode = value
        End Set
    End Property

    Dim MyName As String
    Property name As String
        Get
            Return MyName
        End Get
        Set(value As String)
            MyName = value
        End Set
    End Property

    Dim MyFullName As String
    Property fullName As String
        Get
            Return MyFullName
        End Get
        Set(value As String)
            MyFullName = value
        End Set
    End Property

    ReadOnly Property width As Integer
        Get
            Return Me.bmp.Width
        End Get
    End Property

    ReadOnly Property height As Integer
        Get
            Return Me.bmp.Height
        End Get
    End Property

    Sub New()

    End Sub

    Sub New(ByVal NewBmp As Drawing.Bitmap)
        Me.Bmp = NewBmp
    End Sub

    Sub New(dtByte As Byte())
        Me.SetBmp(dtByte)
    End Sub

    Sub New(newWidth As Integer, newHeight As Integer)
        Me.Bmp = New Drawing.Bitmap(newWidth, newHeight)
    End Sub

    Sub New(filePath As String)
        Dim newBmp As New Drawing.Bitmap(filePath)
        Me.bmp = newBmp
        Me.fullName = fullName
        Dim nameTmp() As String = filePath.Split("\")
        Me.name = nameTmp(nameTmp.GetUpperBound(0))
    End Sub

    Sub SetBmp(dtByte As Byte())
        Dim OriginalBmp As Drawing.Bitmap
        'Dim MyByte() As Byte = ProductDataSet.Tables(0).Rows(0).Item("圖片")
        Dim stream As New IO.MemoryStream(dtByte)
        OriginalBmp = System.Drawing.Bitmap.FromStream(stream)
        Me.Bmp = OriginalBmp
    End Sub

    ''' <summary>
    ''' 改變大小
    ''' </summary>
    ''' <param name="NewWidth"></param>
    ''' <param name="IsScale"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetResize(ByVal NewWidth As Integer, newHeight As Integer, ByVal IsScale As Boolean) As Drawing.Bitmap
        If IsScale Then
            Return Me.GetResize(NewWidth, newHeight)
        Else
            If Me.Bmp.Width < NewWidth Then Return Me.Bmp Else Return Me.GetResize(NewWidth, newHeight)
        End If
    End Function

    ''' <summary>
    ''' 改變大小
    ''' </summary>
    ''' <param name="NewWidth"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetResize(ByVal NewWidth As Integer, newHeight As Integer) As Drawing.Bitmap
        Dim OrgWidth As Integer = Me.Bmp.Width
        Dim OrgHeight As Integer = Me.Bmp.Height
        Dim Width As Integer '= NewWidth
        Dim Height As Integer '= OrgHeight * (NewWidth / OrgWidth)
        'If OrgWidth > NewWidth Or OrgHeight > newHeight Then
        If newHeight = 0 Then
            Dim ratio As Double = NewWidth / OrgWidth
            Width = NewWidth
            Height = CInt(OrgHeight * ratio)
        Else
            If OrgWidth >= OrgHeight Then
                Dim ratio As Double = NewWidth / OrgWidth
                Width = NewWidth
                Height = CInt(OrgHeight * ratio)
            Else
                Dim ratio As Double = newHeight / OrgHeight
                Width = CInt(OrgWidth * ratio)
                Height = newHeight
            End If
        End If

        Dim NewBmp As New Drawing.Bitmap(Width, Height)
        Dim Graph As Drawing.Graphics = Drawing.Graphics.FromImage(NewBmp)
        Graph.InterpolationMode = Me.InterpolationMode
        Graph.SmoothingMode = Me.SmoothingMode
        Graph.DrawImage(Me.Bmp, New Drawing.Rectangle(0, 0, NewBmp.Width, NewBmp.Height))
        Graph.Dispose()
        Return NewBmp
        'Else
        'Return Me.Bmp
        'End If
    End Function

    ''' <summary>
    ''' 改變大小，取中間
    ''' </summary>
    ''' <param name="newWidth"></param>
    ''' <param name="newHeight"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetResize2(newWidth As Integer, newHeight As Integer) As Drawing.Bitmap
        Dim Height As Integer = newHeight
        Dim Width As Integer = newWidth
        Dim OriginalBmp As Bitmap = Me.Bmp
        Dim DemoSize As Single = 1
        Dim pdemo As Drawing.Graphics
        If OriginalBmp.Height / OriginalBmp.Width < Height / Width Then
            DemoSize = Width / OriginalBmp.Width
        Else
            DemoSize = Height / OriginalBmp.Height
        End If
        Dim DemoBmp As Drawing.Bitmap
        If Height = 0 Then
            DemoBmp = New Drawing.Bitmap(CInt(OriginalBmp.Width * DemoSize), CInt(OriginalBmp.Height * DemoSize))
            pdemo = Drawing.Graphics.FromImage(DemoBmp)
            pdemo.DrawImage(OriginalBmp, 0, 0, CInt(OriginalBmp.Width * DemoSize), CInt(OriginalBmp.Height * DemoSize))
        Else
            DemoBmp = New Drawing.Bitmap(Width, Height)
            pdemo = Drawing.Graphics.FromImage(DemoBmp)
            pdemo.DrawImage(OriginalBmp, (Width - OriginalBmp.Width * DemoSize) / 2, (Height - OriginalBmp.Height * DemoSize) / 2, CInt(OriginalBmp.Width * DemoSize), CInt(OriginalBmp.Height * DemoSize))
        End If
        OriginalBmp.Dispose()
        Return DemoBmp
    End Function

    ''' <summary>
    ''' 取得改變大小
    ''' </summary>
    ''' <param name="newWidth"></param>
    ''' <param name="newHeight"></param>
    ''' <remarks></remarks>
    Sub SetResize(newWidth As Integer, newHeight As Integer)
        Me.Bmp = Me.GetResize(newWidth, newHeight)
    End Sub

    ''' <summary>
    ''' 設定改變大小
    ''' </summary>
    ''' <param name="newWidth"></param>
    ''' <param name="NewHeight"></param>
    ''' <remarks></remarks>
    Sub SetResize2(newWidth As Integer, NewHeight As Integer)
        Me.Bmp = Me.GetResize2(newWidth, NewHeight)
    End Sub

    Public Function ImgReduceCutOut(int_Width As Integer, int_Height As Integer) As Drawing.Bitmap
        ' ＝＝＝上傳標準圖大小＝＝＝
        Dim int_Standard_Width As Integer = 800
        Dim int_Standard_Height As Integer = 600

        Dim Reduce_Width As Integer = 0
        ' 縮小的寬度
        Dim Reduce_Height As Integer = 0
        ' 縮小的高度
        Dim CutOut_Width As Integer = 0
        ' 裁剪的寬度
        Dim CutOut_Height As Integer = 0
        ' 裁剪的高度
        Dim level As Integer = 100
        '縮略圖的品質 1-100的範圍
        ' ＝＝＝獲得縮小，裁剪大小＝＝＝
        If int_Standard_Height * int_Width \ int_Standard_Width > int_Height Then
            Reduce_Width = int_Width
            Reduce_Height = int_Standard_Height * int_Width \ int_Standard_Width
            CutOut_Width = int_Width
            CutOut_Height = int_Height
        ElseIf int_Standard_Height * int_Width \ int_Standard_Width < int_Height Then
            Reduce_Width = int_Standard_Width * int_Height \ int_Standard_Height
            Reduce_Height = int_Height
            CutOut_Width = int_Width
            CutOut_Height = int_Height
        Else
            Reduce_Width = int_Width
            Reduce_Height = int_Height
            CutOut_Width = int_Width
            CutOut_Height = int_Height
        End If

        ' ＝＝＝通過連接創建Image物件＝＝＝
        'Dim oldimage As System.Drawing.Image = System.Drawing.Image.FromFile(Server.MapPath(input_ImgUrl))
        'Dim oldimage As System.Drawing.Image = System.Drawing.Image.FromStream(Me.Bmp.t
        ' ＝＝＝縮小圖片＝＝＝
        'Dim thumbnailImage As System.Drawing.Image = oldimage.GetThumbnailImage(Reduce_Width, Reduce_Height, New System.Drawing.Image.GetThumbnailImageAbort(AddressOf ThumbnailCallback), IntPtr.Zero)
        Dim thumbnailImage As System.Drawing.Image = Me.Bmp.GetThumbnailImage(Reduce_Width, Reduce_Height, New System.Drawing.Image.GetThumbnailImageAbort(AddressOf ThumbnailCallback), IntPtr.Zero)
        Dim bm As New Drawing.Bitmap(thumbnailImage)

        ' ＝＝＝處理JPG品質的函數＝＝＝
        Dim codecs As ImageCodecInfo() = ImageCodecInfo.GetImageEncoders()
        Dim ici As ImageCodecInfo = Nothing
        For Each codec As ImageCodecInfo In codecs
            If codec.MimeType = "image/jpeg" Then
                ici = codec
            End If
        Next
        Dim ep As New EncoderParameters()
        ep.Param(0) = New EncoderParameter(Encoder.Quality, CLng(level))

        'bm.Save(Server.MapPath("2.jpg"), ici, ep)

        ' ＝＝＝裁剪圖片＝＝＝
        Dim cloneRect As New Rectangle(0, 0, CutOut_Width, CutOut_Height)
        Dim format As PixelFormat = bm.PixelFormat
        Dim cloneBitmap As Bitmap = bm.Clone(cloneRect, format)

        ' ＝＝＝保存圖片＝＝＝
        'cloneBitmap.Save(Server.MapPath(out_ImgUrl), ici, ep)
        bm.Dispose()
        Return cloneBitmap
    End Function

    Public Function ThumbnailCallback() As Boolean
        Return False
    End Function

    Function GetMask(width As Integer, height As Integer, color As Drawing.Color, framePath As String) As Drawing.Bitmap
        '製作遮罩
        Dim MaskBmp As New Drawing.Bitmap(width, height)
        Dim pmask As Drawing.Graphics = Drawing.Graphics.FromImage(MaskBmp)
        pmask.Clear(Drawing.Color.Green)
        pmask.FillEllipse(Drawing.Brushes.White, 0, 0, width, height)
        '設定白色透明
        MaskBmp.MakeTransparent(color)

        '貼上遮罩
        Dim DemoBmp As Drawing.Bitmap = Me.Bmp
        Dim pmesk As Drawing.Graphics = Drawing.Graphics.FromImage(DemoBmp)
        pmesk = Drawing.Graphics.FromImage(DemoBmp)
        pmesk.DrawImage(MaskBmp, 0, 0, width, height)
        '將遮罩變透明
        DemoBmp.MakeTransparent(Drawing.Color.Green)
        '貼上像框    
        pmesk = Drawing.Graphics.FromImage(DemoBmp)
        Dim MaskPic As New Drawing.Bitmap(framePath)
        pmesk.DrawImage(MaskPic, 0, 0, width, height)

        MaskBmp.Dispose()
        Return MaskPic
    End Function

    ''' <summary>
    ''' 在bmp上面寫字
    ''' </summary>
    ''' <param name="postStr"></param>
    ''' <param name="color"></param>
    ''' <param name="fontSize"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetBmpByString(postStr As String, color As Drawing.Color, fontSize As Integer) As Bitmap
        Dim DemoBmp As Drawing.Bitmap = Me.Bmp

        Dim pdemo As Drawing.Graphics = Drawing.Graphics.FromImage(DemoBmp)
        pdemo.Clear(Drawing.Color.White)

        'Dim PastStr As String = "照片準備中"
        Dim HttpFont As Drawing.Font = New Drawing.Font("新細明體", fontSize, Drawing.FontStyle.Bold)
        Dim httpStringSize As Drawing.SizeF = pdemo.MeasureString(postStr, HttpFont)
        Dim HttpX As Integer = (DemoBmp.Width - httpStringSize.Width) / 2
        Dim HttpY As Integer = (DemoBmp.Height - httpStringSize.Height) / 2

        pdemo.DrawString(postStr, HttpFont, New Drawing.SolidBrush(color), HttpX, HttpY)
        pdemo.Dispose()
        Return DemoBmp
    End Function

    Function GetByte(newBmp As Bitmap, imgFormat As System.Drawing.Imaging.ImageFormat) As Byte()
        Dim newByte() As Byte
        Using ms As New IO.MemoryStream
            newBmp.Save(ms, imgFormat)
            newByte = ms.ToArray
        End Using
        Return newByte
    End Function

    Function GetByte(imgFormat As System.Drawing.Imaging.ImageFormat) As Byte()
        Return Me.GetByte(Me.Bmp, imgFormat)
    End Function

    ''' <summary>
    ''' 轉換成灰階
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetGray() As Bitmap
        ' 0.299*R+ 0.587*G + 0.114*B
        Dim newBmp As New Drawing.Bitmap(Me.Bmp)
        Dim ia As New Drawing.Imaging.ImageAttributes
        Dim cm As New Drawing.Imaging.ColorMatrix(New Single()() _
                        {New Single() {0.299, 0.299, 0.299, 0, 0}, _
                         New Single() {0.587, 0.587, 0.587, 0, 0}, _
                         New Single() {0.114, 0.114, 0.114, 0, 0}, _
                         New Single() {0, 0, 0, 1, 0}, _
                         New Single() {0, 0, 0, 0, 1}})

        ia.SetColorMatrix(cm, Imaging.ColorMatrixFlag.Default, Imaging.ColorAdjustType.Bitmap)
        Dim g As Graphics = Drawing.Graphics.FromImage(newBmp)
        g.DrawImage(newBmp, New Rectangle(0, 0, newBmp.Width, newBmp.Height), 0, 0, newBmp.Width, newBmp.Height, GraphicsUnit.Pixel, ia)
        g.Dispose()
        ia.Dispose()
        Return newBmp
    End Function

    ''' <summary>
    ''' 影像反向
    ''' </summary>
    ''' <remarks></remarks>
    Function Negative() As Bitmap
        ' RGB 值 * -1
        Dim newBmp As New Drawing.Bitmap(Me.Bmp)
        Dim ia As New Drawing.Imaging.ImageAttributes
        Dim cm As New Drawing.Imaging.ColorMatrix(New Single()() _
               {New Single() {-1, 0, 0, 0, 0}, _
                New Single() {0, -1, 0, 0, 0}, _
                New Single() {0, 0, -1, 0, 0}, _
                New Single() {0, 0, 0, 1, 0}, _
                New Single() {1, 1, 1, 1, 1}})

        ia.SetColorMatrix(cm, Imaging.ColorMatrixFlag.Default, Imaging.ColorAdjustType.Bitmap)
        Dim g As Graphics = Drawing.Graphics.FromImage(newBmp)
        g.DrawImage(newBmp, New Rectangle(0, 0, newBmp.Width, newBmp.Height), 0, 0, newBmp.Width, newBmp.Height, GraphicsUnit.Pixel, ia)
        g.Dispose()
        ia.Dispose()
        Return newBmp
    End Function

    ''' <summary>
    ''' 轉置
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function Transport() As Bitmap
        Dim newBmp As New Drawing.Bitmap(Me.Bmp.Height, Me.Bmp.Width)
        For j As Integer = 0 To Me.Bmp.Height - 1
            For i As Integer = 0 To Me.Bmp.Width - 1
                Dim pixel As Color = Me.Bmp.GetPixel(i, j)
                newBmp.SetPixel(j, i, pixel)
            Next
        Next
        Return newBmp
    End Function

    ''' <summary>
    ''' 負片
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function Invert() As Bitmap
        Dim newBmp As New Drawing.Bitmap(Me.bmp.Width, Me.bmp.Height)

        For i As Integer = 0 To Me.bmp.Width - 1
            For j As Integer = 0 To Me.bmp.Height - 1
                Dim pixel As Color = Me.bmp.GetPixel(i, j)
                Dim newPixel As Color = Color.FromArgb(255 - pixel.R, 255 - pixel.G, 255 - pixel.B)
                newBmp.SetPixel(i, j, newPixel)
            Next
        Next
        Return newBmp
    End Function

    ''' <summary>
    ''' 平移
    ''' </summary>
    ''' <param name="xValue"></param>
    ''' <param name="yValue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function Shift(xValue As Integer, yValue As Integer) As Bitmap
        Dim newBmp As New Drawing.Bitmap(Me.Bmp.Width, Me.Bmp.Height)

        For x As Integer = 0 To Me.Bmp.Width - 1
            For y As Integer = 0 To Me.Bmp.Height - 1
                Dim newX As Integer = x - xValue
                Dim newY As Integer = y - yValue
                If newX < Me.Bmp.Width And newY < Me.Bmp.Height And newX > 0 And newY > 0 Then
                    Dim pixel As Color = Me.Bmp.GetPixel(newX, newY)
                    newBmp.SetPixel(x, y, pixel)
                Else
                    newBmp.SetPixel(x, y, System.Drawing.Color.White)
                End If
            Next
        Next

        Return newBmp
    End Function

 

    ''' <summary>
    ''' 水平鏡射
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function HorizontalMirror() As Bitmap
        Dim newBmp As New Drawing.Bitmap(Me.Bmp)
        newBmp.RotateFlip(RotateFlipType.RotateNoneFlipX)
        Return newBmp
    End Function

    ''' <summary>
    ''' 垂直鏡射
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function VerticalMirror() As Bitmap
        Dim newBmp As New Drawing.Bitmap(Me.Bmp)
        newBmp.RotateFlip(RotateFlipType.RotateNoneFlipY)
        Return newBmp
    End Function

    ''' <summary>
    ''' 轉90度
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function Rotate90Degree() As Bitmap
        Dim newBmp As New Drawing.Bitmap(Me.Bmp)
        newBmp.RotateFlip(RotateFlipType.Rotate90FlipNone)
        Return newBmp
    End Function

    ''' <summary>
    '''  轉180度
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function Rotate180Degree() As Bitmap
        Dim newBmp As New Drawing.Bitmap(Me.Bmp)
        newBmp.RotateFlip(RotateFlipType.Rotate180FlipNone)
        Return newBmp
    End Function

    ''' <summary>
    ''' 轉270度
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function Rotate270Degree() As Bitmap
        Dim newBmp As New Drawing.Bitmap(Me.Bmp)
        newBmp.RotateFlip(RotateFlipType.Rotate270FlipNone)
        Return newBmp
    End Function
End Class
