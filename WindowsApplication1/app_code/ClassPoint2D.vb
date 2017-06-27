Imports System.Math

Public Class ClassPoint2D
    Protected XValue As Double
    Protected YValue As Double
    Protected MyValue As Double
    Protected MyID As Integer
    Protected MyID2 As Integer
    Protected MyName As String

    Property ID As Integer
        Get
            ID = MyID
        End Get
        Set(ByVal value As Integer)
            MyID = value
        End Set
    End Property

    Property ID2 As Integer
        Get
            ID2 = MyID2
        End Get
        Set(ByVal value As Integer)
            MyID2 = value
        End Set
    End Property

    Property X() As Double
        Get
            X = XValue
        End Get
        Set(ByVal value As Double)
            XValue = value
        End Set
    End Property

    Property Y() As Double
        Get
            Y = YValue
        End Get
        Set(ByVal value As Double)
            YValue = value
        End Set
    End Property

    Property Value() As Double
        Get
            Value = MyValue
        End Get
        Set(ByVal value As Double)
            MyValue = value
        End Set
    End Property

    Property Name As String
        Get
            Name = MyName
        End Get
        Set(ByVal value As String)
            MyName = value
        End Set
    End Property

    ReadOnly Property PtString(Optional ByVal Spliter As String = ",") As String
        Get
            PtString = FormatNumber(Me.X, 4) & Spliter & FormatNumber(Me.Y, 4)
        End Get
    End Property

    Sub New()
        XValue = 0
        YValue = 0
    End Sub

    Sub New(ByVal X As Double, ByVal Y As Double)
        XValue = X
        YValue = Y
    End Sub

    Sub New(ByVal X As Double, ByVal Y As Double, ByVal Value As Double)
        XValue = X
        YValue = Y
        MyValue = Value
    End Sub

    Sub New(ByVal Array() As Double)
        Me.X = Array(0)
        Me.Y = Array(1)
    End Sub

    ''' <summary>
    ''' 取出旋轉
    ''' </summary>
    ''' <param name="Angle"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetRotate(ByVal Angle As Double) As ClassPoint2D
        Dim Pt As New ClassPoint2D
        Dim MyMath As New ClassMyMath
        Dim Rad As Double = MyMath.AngleToRad(Angle)
        Pt.X = Me.XValue * Cos(Rad) - Me.YValue * Sin(Rad)
        Pt.Y = Me.YValue * Cos(Rad) + Me.XValue * Sin(Rad)
        Pt.ID = Me.ID
        Pt.ID2 = Me.ID2
        Pt.Value = Me.Value
        Pt.Name = Me.Name
        Return Pt
    End Function

    ''' <summary>
    ''' 設定旋轉
    ''' </summary>
    ''' <param name="Angle"></param>
    ''' <remarks></remarks>
    Sub SetRotate(ByVal Angle As Double)
        Dim Pt As New ClassPoint2D
        Pt = Me.GetRotate(Angle)
        Me.SetSelf(Pt)
    End Sub

    ''' <summary>
    ''' 抓取平移
    ''' </summary>
    ''' <param name="Xa"></param>
    ''' <param name="Ya"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetTranslate(ByVal Xa As Double, ByVal Ya As Double) As ClassPoint2D
        Dim Pt As New ClassPoint2D
        Pt.X = Me.XValue + Xa
        Pt.Y = Me.YValue + Ya
        Pt.ID = Me.ID
        Pt.ID2 = Me.ID2
        Pt.Value = Me.Value
        Pt.Name = Me.Name
        Return Pt
    End Function

    ''' <summary>
    ''' 設定平移
    ''' </summary>
    ''' <param name="Xa"></param>
    ''' <param name="Ya"></param>
    ''' <remarks></remarks>
    Sub SetTranslate(ByVal Xa As Double, ByVal Ya As Double)
        Dim Pt As ClassPoint2D = Me.GetTranslate(Xa, Ya)
        Me.SetSelf(Pt)
    End Sub

    ''' <summary>
    ''' 與另一點距離
    ''' </summary>
    ''' <param name="Pt2">點</param>
    ''' <returns>距離</returns>
    ''' <remarks></remarks>
    Function Distance(ByVal Pt2 As ClassPoint2D) As Double
        Return Math.Sqrt((Pt2.X - Me.XValue) ^ 2 + (Pt2.Y - YValue) ^ 2)
    End Function

    ''' <summary>
    ''' 回傳沒開根號的距離
    ''' </summary>
    ''' <param name="Pt2"></param>
    ''' <param name="IsSqr"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function Distance(ByVal Pt2 As ClassPoint2D, ByVal IsSqr As Boolean) As Double
        Dim Value As Double = (Pt2.X - Me.XValue) ^ 2 + (Pt2.Y - YValue) ^ 2
        If IsSqr Then Return Math.Sqrt(Value) Else Return Value
    End Function

   

    ''' <summary>
    ''' 是否有落在線範圍內
    ''' </summary>
    ''' <param name="Line"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function IsInLine(ByVal Line As ClassLine2D) As Boolean
        Dim MyMath As New ClassMyMath
        If Line.Length <> 0 Then
            If Math.Abs(Line.PtStart.X - Line.PtEnd.X) > My.EzFunction.ClassSetting.Epi Then
                Return MyMath.IsInRange(Me.X, Line.PtStart.X, Line.PtEnd.X)
            Else
                Return MyMath.IsInRange(Me.Y, Line.PtStart.Y, Line.PtEnd.Y)
            End If
        Else
            Return True
        End If
    End Function

    ''' <summary>
    ''' 判斷是否落在兩條線內
    ''' </summary>
    ''' <param name="Line1"></param>
    ''' <param name="Line2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function IsInLine(ByVal Line1 As ClassLine2D, ByVal Line2 As ClassLine2D) As Boolean
        Dim Chk As Boolean = Me.IsInLine(Line1)
        If Chk Then
            Chk = Me.IsInLine(Line2)
        End If
        Return Chk
    End Function

    ''' <summary>
    ''' 兩點間作cross
    ''' </summary>
    ''' <param name="Pt"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function Cross(ByVal Pt As ClassPoint2D) As Double
        Return Me.X * Pt.Y - Me.Y * Pt.X
    End Function

    Function GetArray() As Double()
        Dim Arr() As Double = {Me.X, Me.Y}
        Return Arr
    End Function

    Sub SetArray(ByVal Arr() As Double)
        Me.X = Arr(0)
        Me.Y = Arr(1)
    End Sub

    ''' <summary>
    ''' 有無通過盒子測試
    ''' </summary>
    ''' <param name="Line"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function IsBoxTest(ByVal Line As ClassLine2D) As Boolean
        Dim MyMath As New ClassMyMath
        If MyMath.IsInRange(Me.X, Line.PtStart.X, Line.PtEnd.X) And MyMath.IsInRange(Me.Y, Line.PtStart.Y, Line.PtEnd.Y) Then
            Return True
        Else
            Return False
        End If
        'Dim Chk As Boolean = MyMath.IsInRange(Me.X, Line.PtStart.X, Line.PtEnd.X)
        'If Chk Then Chk = MyMath.IsInRange(Me.Y, Line.PtStart.Y, Line.PtEnd.Y)
        'Return Chk
    End Function


    ''' <summary>
    ''' 點對點平移
    ''' </summary>
    ''' <param name="PtStart"></param>
    ''' <param name="PtEnd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetTranslate(ByVal PtStart As ClassPoint2D, ByVal PtEnd As ClassPoint2D) As ClassPoint2D
        Dim Pt As New ClassPoint2D(Me.XValue + (PtEnd.X - PtStart.X), Me.YValue + (PtEnd.Y - PtStart.Y))
        Pt.ID = Me.ID
        Pt.ID2 = Me.ID2
        Pt.Value = Me.Value
        Pt.Name = Me.Name
        Return Pt
    End Function

    ''' <summary>
    ''' 點對點平移
    ''' </summary>
    ''' <param name="PtStart"></param>
    ''' <param name="PtEnd"></param>
    ''' <remarks></remarks>
    Sub SetTranslate(ByVal PtStart As ClassPoint2D, ByVal PtEnd As ClassPoint2D)
        Me.SetSelf(Me.GetTranslate(PtStart, PtEnd))
    End Sub

    Private Sub SetSelf(ByVal Pt As ClassPoint2D)
        Me.X = Pt.X
        Me.Y = Pt.Y
        Me.ID = Pt.ID
        Me.ID2 = Me.ID2
        Me.Value = Pt.Value
        Me.Name = Pt.Name
    End Sub

    ''' <summary>
    ''' 判斷兩點是否相同
    ''' </summary>
    ''' <param name="Pt"></param>
    ''' <param name="IsEpi">是否用誤差值判斷</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function IsTheSame(ByVal Pt As ClassPoint2D, Optional ByVal IsEpi As Boolean = True) As Boolean
        If IsEpi Then
            If Math.Abs(Me.X - Pt.X) < My.EzFunction.ClassSetting.Epi And Math.Abs(Me.Y - Pt.Y) < My.EzFunction.ClassSetting.Epi Then
                Return True
            Else
                Return False
            End If
        Else
            If Me.X = Pt.X And Me.Y = Pt.Y Then Return True Else Return False
        End If
    End Function

    ''' <summary>
    ''' 是否為線的端點
    ''' </summary>
    ''' <param name="Line"></param>
    ''' <param name="IsEpi"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function IsLineEndPoint(ByVal Line As ClassLine2D, Optional ByVal IsEpi As Boolean = True) As Boolean
        If Me.IsTheSame(Line.PtStart, IsEpi) Or Me.IsTheSame(Line.PtEnd, IsEpi) Then Return True Else Return False
    End Function

    ''' <summary>
    ''' 點是否在線上
    ''' </summary>
    ''' <param name="Line"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function IsOnLine(ByVal Line As ClassLine2D) As Boolean
        Dim MyMath As New ClassMyMath
        If Math.Abs(Line.Vector.X) > My.EzFunction.ClassSetting.Epi Then
            If Math.Abs(Me.Y - (Line.PtStart.Y + ((Me.X - Line.PtStart.X) / Line.Vector.X) * Line.Vector.Y)) < My.EzFunction.ClassSetting.Epi Then
                If MyMath.IsInRange(Me.X, Line.PtStart.X, Line.PtEnd.X) Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Else
            If Math.Abs(Me.Y - Line.PtStart.Y) < My.EzFunction.ClassSetting.Epi Then
                Return True
            Else
                Return False
            End If
        End If
    End Function
End Class
