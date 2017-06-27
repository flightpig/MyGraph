Public Class ClassLine2D
    Dim MyPt As ClassPoint2D
    Dim MyVector As ClassVector2D
    Dim MyLength As Double
    Dim MyPtEnd As ClassPoint2D
    Dim MyID As Integer
    Dim MyName As String

    Property Name As String
        Get
            Name = MyName
        End Get
        Set(ByVal value As String)
            MyName = value
        End Set
    End Property

    Property ID As Integer
        Get
            ID = MyID
        End Get
        Set(ByVal value As Integer)
            MyID = value
        End Set
    End Property

    ''' <summary>
    ''' 斜率
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Slope() As Double
        Get
            Slope = MyVector.Slope
        End Get
    End Property

    ''' <summary>
    ''' 啟始點
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property PtStart() As ClassPoint2D
        Get
            PtStart = MyPt
        End Get
        Set(ByVal value As ClassPoint2D)
            MyPt = value
        End Set
    End Property

    ''' <summary>
    ''' 結束點
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property PtEnd As ClassPoint2D
        Get
            PtEnd = MyPtEnd
        End Get
        Set(ByVal value As ClassPoint2D)
            MyPtEnd = value
            MyLength = MyPt.Distance(value)
        End Set
    End Property

    Property Vector() As ClassVector2D
        Get
            Vector = MyVector
        End Get
        Set(ByVal value As ClassVector2D)
            MyVector = value
        End Set
    End Property

    ''' <summary>
    ''' 線的長度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Length As Double
        Get
            Length = MyLength
        End Get
        Set(ByVal value As Double)
            MyLength = value
            MyPtEnd = Me.PtByDistance(value)
        End Set
    End Property

    Sub New()
        MyPt = New ClassPoint2D
        MyPt.X = 0
        MyPt.Y = 0
        MyVector = New ClassVector2D
        MyVector.X = 0
        MyVector.Y = 1
    End Sub

    Sub New(ByVal pt As ClassPoint2D, ByVal Vector As ClassVector2D)
        MyPt = New ClassPoint2D(pt.GetArray)
        MyVector = New ClassVector2D(Vector.X, Vector.Y)
    End Sub

    Sub New(ByVal NewPtStart As ClassPoint2D, ByVal NewPtEnd As ClassPoint2D)
        Dim Vector As New ClassVector2D(NewPtStart, NewPtEnd, True)
        MyPt = New ClassPoint2D(NewPtStart.GetArray)
        Dim MyPtEndTmp As New ClassPoint2D(NewPtEnd.GetArray)
        Me.PtEnd = MyPtEndTmp
        MyVector = Vector
    End Sub

    Sub New(ByVal NewPtStart As ClassPoint2D, ByVal NewPtEnd As ClassPoint2D, ByVal IsAbs As Boolean)
        Dim Vector As New ClassVector2D(NewPtStart, NewPtEnd, IsAbs)
        MyPt = New ClassPoint2D(NewPtStart.GetArray)
        Dim MyPtEndTmp As New ClassPoint2D(NewPtEnd.GetArray)
        Me.PtEnd = MyPtEndTmp
        MyVector = Vector
    End Sub

    Sub New(ByVal NewPtStart() As Double, ByVal NewPtEnd() As Double, ByVal IsAbs As Boolean)
        MyPt = New ClassPoint2D(NewPtStart(0), NewPtStart(1))
        Dim NewPtEndTmp As New ClassPoint2D(NewPtEnd(0), NewPtEnd(1))
        Me.PtEnd = NewPtEndTmp
        Dim NewVector As New ClassVector2D(NewPtEnd(0) - NewPtStart(0), NewPtEnd(1) - NewPtStart(1))
        If IsAbs Then NewVector.Abs()
        MyVector = NewVector
    End Sub

    Function PtByDistance(ByVal Distance As Double) As ClassPoint2D
        Dim T As Double
        T = Math.Sqrt((Distance ^ 2) / (MyVector.X ^ 2 + MyVector.Y ^ 2))
        Dim Result As New ClassPoint2D(MyPt.X + Vector.X * T, MyPt.Y + Vector.Y * T)
        Return Result
    End Function

    ''' <summary>
    ''' 輸入x值求得線上一點
    ''' </summary>
    ''' <param name="X">x值</param>
    ''' <returns>點</returns>
    ''' <remarks></remarks>
    Function PtByXValue(ByVal X As Double) As ClassPoint2D
        Dim Pt As New ClassPoint2D(X, Slope * (X - MyPt.X) + MyPt.Y)
        Return Pt
    End Function
    ''' <summary>
    ''' 回傳點陣列
    ''' </summary>
    ''' <param name="X"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function PtByXValue(ByVal X As ArrayList) As ArrayList
        Dim Array As New ArrayList
        Dim Pt As ClassPoint2D
        For Each item As Object In X
            Pt = New ClassPoint2D
            Pt = PtByXValue(item)
            Array.Add(Pt)
        Next
        Return Array
    End Function

    ''' <summary>
    ''' 輸入y值求得線上一點
    ''' </summary>
    ''' <param name="Y">y值</param>
    ''' <returns>點</returns>
    ''' <remarks></remarks>
    Function PtByYValue(ByVal Y As Double) As ClassPoint2D
        Dim Pt As New ClassPoint2D((Y - MyPt.Y) / Slope + MyPt.X, Y)
        Return Pt
    End Function

    ''' <summary>
    ''' 回傳點陣列
    ''' </summary>
    ''' <param name="Y"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function PtByYValue(ByVal Y As ArrayList) As List(Of ClassPoint2D)
        Dim Array As New List(Of ClassPoint2D)
        Dim Pt As ClassPoint2D
        For Each item As Object In Y
            Pt = New ClassPoint2D
            Pt = PtByYValue(item)
            Array.Add(Pt)
        Next
        Return Array
    End Function

    ''' <summary>
    ''' 輸入x值求y值
    ''' </summary>
    ''' <param name="x"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function ValueByX(ByVal x As Double) As Double
        Return Slope * (x - MyPt.X) + MyPt.Y
    End Function

    ''' <summary>
    ''' 輸入x陣列求y陣列
    ''' </summary>
    ''' <param name="X"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function ValuebyX(ByVal X As ArrayList) As ArrayList
        Dim array As New ArrayList
        For Each item As Object In X
            array.Add(ValuebyX(item))
        Next
        Return array
    End Function

    ''' <summary>
    ''' 輸入y值求x值
    ''' </summary>
    ''' <param name="y"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function ValueByY(ByVal y As Double) As Double
        Return (y - MyPt.Y) / Slope + MyPt.X
    End Function

    ''' <summary>
    ''' 輸入y陣列求x陣列
    ''' </summary>
    ''' <param name="Y"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function ValuebyY(ByVal Y As ArrayList) As ArrayList
        Dim array As New ArrayList
        For Each item As Object In Y
            array.Add(Valuebyy(item))
        Next
        Return array
    End Function

    ''' <summary>
    ''' 與線相交一點(Error，會有斜率為0的問題)
    ''' </summary>
    ''' <param name="Line">線</param>
    ''' <returns>點</returns>
    ''' <remarks></remarks>
    Function IntersectionLine(ByVal Line As ClassLine2D) As ClassPoint2D
        '判斷是否平行，平行則為nothing
        If Math.Abs(Me.Vector.Dot(Line.Vector)) = 1 Then
            Return Nothing
        Else
            Dim MeSlope As Double = Me.Slope
            Dim LineSlope As Double = Line.Slope
            Dim X As Double = (MeSlope * Me.MyPt.X - LineSlope * Line.PtStart.X + Line.PtStart.Y - MyPt.Y) / (MeSlope - LineSlope)
            Dim Y As Double = MeSlope * (X - MyPt.X) + MyPt.Y
            Dim NewPt As New ClassPoint2D(X, Y)
            If Me.Length <> 0 Then
                If NewPt.Distance(Me.PtEnd) < Me.Length Then
                    Return NewPt
                Else
                    Return Nothing
                End If
            Else
                Return NewPt
            End If
        End If
    End Function

    ''' <summary>
    ''' 與線相交一點
    ''' </summary>
    ''' <param name="Line"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function Intersection(ByVal Line As ClassLine2D) As ClassPoint2D
        Dim IsBoxTest As Boolean
        If Length <> 0 Then
            IsBoxTest = Me.IsBoxTest(Line)
        Else
            IsBoxTest = True
        End If
        If IsBoxTest Then
            'ax+by=c,dx+ey=f
            Dim a, b, c, d, e, f As Double
            a = Me.Vector.X
            b = Line.Vector.X
            c = Line.PtStart.X - Me.PtStart.X
            d = Me.Vector.Y
            e = Line.Vector.Y
            f = Line.PtStart.Y - Me.PtStart.Y
            Dim ClassAlg As New ClassAlgorithm
            Dim MyMath As New ClassMyMath
            Dim T() As Double = ClassAlg.DualityLinearEquation(a, b, c, d, e, f)
            If Not T Is Nothing Then
                Dim NewPt As New ClassPoint2D(Me.PtStart.X + Me.Vector.X * T(0), Me.PtStart.Y + Me.Vector.Y * T(0))
                If Me.Length <> 0 Then
                    Dim ChkInLine As Boolean = NewPt.IsInLine(Me, Line)
                    If ChkInLine Then
                        Return NewPt
                    Else
                        Return Nothing
                    End If
                Else
                    Return NewPt
                End If
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If

    End Function

   


    ''' <summary>
    ''' 兩平行線距離
    ''' </summary>
    ''' <param name="Line"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function Distance(ByVal Line As ClassLine2D) As Double
        'Dim Vx As double = Me.Vector.Y
        'Dim Vy As double = Me.Vector.X
        'Dim NewLine As New ClassLine2D(Me.PtStart, New ClassVector2D(Vx, Vy))
        'Dim PtInt As ClassPoint2D = NewLine.Intersection(Line)
        'Return Me.PtStart.Distance(PtInt)
        Dim c1 As Double = -Me.PtStart.X * Me.Vector.Y + Me.PtStart.Y * Me.Vector.X
        Dim c2 As Double = -Line.PtStart.Y * Line.Vector.X + Line.PtStart.Y * Line.Vector.X
        Return Math.Abs(c1 - c2)
    End Function

    ''' <summary>
    ''' 是否有端點相同
    ''' </summary>
    ''' <param name="Line"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function IsEndPoint(ByVal Line As ClassLine2D) As Boolean
        If Me.PtStart.IsTheSame(Line.PtStart, False) Or Me.PtStart.IsTheSame(Line.PtEnd, False) Or Me.PtEnd.IsTheSame(Line.PtStart, False) Or Me.PtEnd.IsTheSame(Line.PtEnd, False) Then
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' 是否有交點
    ''' </summary>
    ''' <param name="Line"></param>
    ''' <param name="IsEndPoint">有無包含端點</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function IsIntersection(ByVal Line As ClassLine2D, Optional ByVal IsEndPoint As Boolean = True) As Boolean
        Dim PtInt As ClassPoint2D = Me.Intersection(Line)
        If Not PtInt Is Nothing Then
            If IsEndPoint Then
                Return True
            Else
                If Not PtInt.IsTheSame(Line.PtStart) And Not PtInt.IsTheSame(Line.PtEnd) Then
                    Return True
                Else
                    Return False
                End If
            End If
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' 兩條線是否相同
    ''' </summary>
    ''' <param name="Line"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function IsTheSame(ByVal Line As ClassLine2D) As Boolean
        If Me.PtStart.IsTheSame(Line.PtStart) And Me.PtEnd.IsTheSame(Line.PtEnd) Then
            Return True
        ElseIf Me.PtStart.IsTheSame(Line.PtEnd) And Me.PtEnd.IsTheSame(Line.PtStart) Then
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    '''  點是否在線上
    ''' </summary>
    ''' <param name="Line"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function IsOnLine(ByVal Line As ClassLine2D) As Boolean
        If 1 - Math.Abs(Me.Vector.Dot(Line.Vector)) < My.EzFunction.ClassSetting.Epi And Me.Distance(Line) < My.EzFunction.ClassSetting.Epi Then
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' 取得平移
    ''' </summary>
    ''' <param name="PtOrg"></param>
    ''' <param name="PtTarget"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetTranslate(ByVal PtOrg As ClassPoint2D, ByVal PtTarget As ClassPoint2D) As ClassLine2D
        If Me.Length > 0 Then
            Return New ClassLine2D(Me.PtStart.GetTranslate(PtOrg, PtTarget), Me.PtEnd.GetTranslate(PtOrg, PtTarget))
        Else
            Return New ClassLine2D(Me.PtStart.GetTranslate(PtOrg, PtTarget), Me.Vector)
        End If
    End Function

    ''' <summary>
    ''' 是否通過盒子測試
    ''' </summary>
    ''' <param name="Line"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function IsBoxTest(ByVal Line As ClassLine2D) As Boolean
        Dim MyMath As New ClassMyMath
        Dim MyMaxX As Double = MyMath.CompareLarge(Me.PtStart.X, Me.PtEnd.X)
        Dim MyMinX As Double = MyMath.CompareSmall(Me.PtStart.X, Me.PtEnd.X)
        Dim MyMaxY As Double = MyMath.CompareLarge(Me.PtStart.Y, Me.PtEnd.Y)
        Dim MyMinY As Double = MyMath.CompareSmall(Me.PtStart.Y, Me.PtEnd.Y)
        Dim LineMaxX As Double = MyMath.CompareLarge(Line.PtStart.X, Line.PtEnd.X)
        Dim LineMinX As Double = MyMath.CompareSmall(Line.PtStart.X, Line.PtEnd.X)
        Dim LineMaxY As Double = MyMath.CompareLarge(Line.PtStart.Y, Line.PtEnd.Y)
        Dim LineMinY As Double = MyMath.CompareSmall(Line.PtStart.Y, Line.PtEnd.Y)
        If MyMinX > LineMaxX Or MyMinY > LineMaxY Or MyMaxX < LineMinX Or MyMaxY < LineMinY Then
            Return False
        Else
            Return True
        End If
    End Function
End Class
