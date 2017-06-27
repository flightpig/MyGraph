'Imports System.Math
Public Class ClassMyMath

    Function Sum(ByVal X() As Double) As Double
        Dim Tmp, Result As Double
        For Each Tmp In X
            Result = Result + Tmp
        Next
        Return Result
    End Function

    ''' <summary>
    ''' 加總x*y陣列
    ''' </summary>
    ''' <param name="X"></param>
    ''' <param name="Y"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function Sum(ByVal X() As Double, ByVal Y() As Double) As Double
        Dim result As Double
        Dim i As Integer
        For i = 0 To UBound(X)
            result = result + X(i) * Y(i)
        Next
        Return result
    End Function

    ''' <summary>
    ''' 加總二維陣列
    ''' </summary>
    ''' <param name="X"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function Sum(ByVal X(,) As Double) As Double
        Dim i, j As Integer
        Dim Result As Double
        For i = 0 To UBound(X, 1)
            For j = 0 To UBound(X, 2)
                Result += X(i, j)
            Next
        Next
        Return Result
    End Function

    ''' <summary>
    ''' 加總
    ''' </summary>
    ''' <param name="Array"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function Sum(ByVal Array As ArrayList) As Double
        Dim Result As Double
        For Each Item As Double In Array
            Result += Item
        Next
        Return Result
    End Function

    ''' <summary>
    ''' 平均
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <param name="Num"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function Average(ByVal Value As Double, ByVal Num As Integer) As Double
        Return Value / Num
    End Function

    ''' <summary>
    ''' 平均
    ''' </summary>
    ''' <param name="Array"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function Average(ByVal Array As ArrayList) As Double
        Return Me.Sum(Array) / Array.Count
    End Function

    ''' <summary>
    ''' 平方和
    ''' </summary>
    ''' <param name="Array"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function SquareSum(ByVal Array As ArrayList) As Double
        Dim Result As Double
        For Each Item As Object In Array
            Result += Item ^ 2
        Next
        Return Result
    End Function

    ''' <summary>
    ''' 次方和
    ''' </summary>
    ''' <param name="array"></param>
    ''' <param name="Order"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function OrderSum(ByVal array As ArrayList, ByVal Order As Integer) As Double
        Dim Result As Double
        For Each Item As Object In array
            Result += Item ^ Order
        Next
        Return Result
    End Function

    ''' <summary>
    ''' 離差平方和
    ''' </summary>
    ''' <param name="array"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function SquaresDifference(ByVal array As ArrayList) As Double
        Dim Ave As Double = Me.Average(array)
        Dim Sum As Double
        For Each item As Object In array
            Sum = Sum + (item - Ave) ^ 2
        Next
        Return Sum
    End Function

    ''' <summary>
    ''' 變異數
    ''' </summary>
    ''' <param name="array"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function Variance(ByVal array As ArrayList) As Double
        Dim Sum As Double = Me.SquaresDifference(array)
        Return Sum / array.Count
    End Function

    ''' <summary>
    ''' 標準差
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function StandardDeviation(ByVal array As ArrayList) As Double
        Return Math.Sqrt(Me.Variance(array))
    End Function

    ''' <summary>
    ''' 角度轉徑度
    ''' </summary>
    ''' <param name="X"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function AngleToRad(ByVal X As Double) As Double
        Return X * Math.PI / 180
    End Function

    ''' <summary>
    ''' 徑度轉角度
    ''' </summary>
    ''' <param name="X"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function RadToAngle(ByVal X As Double) As Double
        Return X * 180 / Math.PI
    End Function

    Function SecByRad(ByVal Rad As Double) As Double
        Return 1 / Cos(Rad)
    End Function

    Function CoSecByRad(ByVal Rad As Double) As Double
        Return 1 / Sin(Rad)
    End Function

    Function CoTanByRad(ByVal Rad As Double) As Double
        Return 1 / Tan(Rad)
    End Function

    ''' <summary>
    ''' 回傳較大值
    ''' </summary>
    ''' <param name="Number1"></param>
    ''' <param name="Number2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function CompareLarge(ByVal Number1 As Integer, ByVal Number2 As Integer) As Integer
        Dim Tmp As Integer
        If Number1 >= Number2 Then
            Tmp = Number1
        Else
            Tmp = Number2
        End If
        Return Tmp
    End Function

    ''' <summary>
    ''' 回傳較小值
    ''' </summary>
    ''' <param name="Number1"></param>
    ''' <param name="Number2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function CompareSmall(ByVal Number1 As Integer, ByVal Number2 As Integer) As Integer
        Dim Tmp As Integer
        If Number1 <= Number2 Then
            Tmp = Number1
        Else
            Tmp = Number2
        End If
        Return Tmp
    End Function

    ''' <summary>
    ''' 回傳較大值
    ''' </summary>
    ''' <param name="Number1"></param>
    ''' <param name="Number2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function CompareLarge(ByVal Number1 As Double, ByVal Number2 As Double) As Double
        Dim Tmp As Double
        If Number1 > Number2 Then
            Tmp = Number1
        Else
            Tmp = Number2
        End If
        Return Tmp
    End Function

    ''' <summary>
    ''' 回傳較小值
    ''' </summary>
    ''' <param name="Number1"></param>
    ''' <param name="Number2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function CompareSmall(ByVal Number1 As Double, ByVal Number2 As Double) As Double
        Dim Tmp As Double
        If Number1 < Number2 Then
            Tmp = Number1
        Else
            Tmp = Number2
        End If
        Return Tmp
    End Function

    ''' <summary>
    ''' 回傳較大值
    ''' </summary>
    ''' <param name="Number1"></param>
    ''' <param name="Number2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function CompareLarge(ByVal Number1, ByVal Number2)
        Dim Tmp
        If Number1 > Number2 Then
            Tmp = Number1
        Else
            Tmp = Number2
        End If
        Return Tmp
    End Function

    ''' <summary>
    ''' 回傳較小值
    ''' </summary>
    ''' <param name="Number1"></param>
    ''' <param name="Number2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function CompareSmall(ByVal Number1, ByVal Number2)
        Dim Tmp
        If Number1 < Number2 Then
            Tmp = Number1
        Else
            Tmp = Number2
        End If
        Return Tmp
    End Function

    Public Function GammaLog(ByVal dblX As Double) As Double
        'Declarations
        Dim intI As Integer 'Loop Counter
        Dim dblGL As Double 'Current Value of log(gamma(x))
        'Bernoulli Numbers
        Dim dblB(20) As Double
        dblB(0) = 1
        dblB(1) = -1 / 2
        dblB(2) = 1 / 6
        dblB(4) = -1 / 30
        dblB(6) = 1 / 42
        dblB(8) = -1 / 30
        dblB(10) = 5 / 66
        dblB(12) = -691 / 2730
        dblB(14) = 7 / 6
        dblB(16) = -3617 / 510
        dblB(18) = 43867 / 798
        dblB(20) = -174611 / 330
        'Special Cases
        If dblX <= 0 Then
            Return Double.NaN
        ElseIf dblX = 1 Then
            Return 0
        ElseIf dblX = 2 Then
            Return 0
        End If
        'Shift
        'Values less than the shift value will be incremented by
        'the value of shift and the value obtained from the
        'Stirling series modified.
        Dim dblShift As Double = 7
        If dblX < dblShift Then
            dblShift = 7
        Else
            dblShift = 0
        End If
        'Stirling Series - elements 1, 2 & 3
        dblGL = ((dblX + dblShift) - 0.5) * Math.Log((dblX + dblShift))
        dblGL = dblGL - (dblX + dblShift)
        dblGL = dblGL + Math.Log(2 * Math.PI) / 2
        'Stirling Series - elements 4......
        For intI = 1 To 10
            dblGL = dblGL + dblB(2 * intI) / 2 / intI / (2 * intI - 1) / Math.Pow((dblX + dblShift), 2 * intI - 1)
        Next
        'If x was less than shift, modify the result
        'obtained from the Stirling series.
        If dblShift > 0 Then
            'change from log(gamma) to gamma
            dblGL = Math.Exp(dblGL)
            'Modify value from Stirling series
            For intI = 0 To dblShift - 1
                dblGL = dblGL / (dblX + intI)
            Next
            'Back to log(gamma)
            dblGL = Math.Log(dblGL)
            'Return Value
            Return dblGL
        Else
            Return Nothing
        End If
    End Function

    Function Gamma(ByVal X As Double) As Double
        Return Math.Exp(Me.GammaLog(X))
    End Function

    ''' <summary>
    ''' 計算正規化值
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <returns>正規化陣列</returns>
    ''' <remarks></remarks>
    Function Normalize(ByVal Value() As Double) As Double()
        Dim TotalSqr As Double
        Dim Item As Double
        For Each Item In Value
            TotalSqr += Item ^ 2
        Next
        TotalSqr = Math.Sqrt(TotalSqr)
        Dim Result(Value.GetUpperBound(0)) As Double
        Dim i As Integer
        For Each Item In Value
            Result(i) = Value(i) / TotalSqr
            i += 1
        Next
        Return Result
    End Function

    ''' <summary>
    ''' 判斷是否有落在範圍內
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <param name="Range1"></param>
    ''' <param name="Range2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function IsInRange(ByVal Value As Double, ByVal Range1 As Double, ByVal Range2 As Double) As Boolean
        Dim MaxValue As Double = FormatNumber(Me.CompareLarge(Range1, Range2), My.EzFunction.ClassSetting.Digit)
        Dim MinValue As Double = FormatNumber(Me.CompareSmall(Range1, Range2), My.EzFunction.ClassSetting.Digit)
        Value = FormatNumber(Value, My.EzFunction.ClassSetting.Digit)
        If Value >= MinValue And Value <= MaxValue Then
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Angle"></param>
    ''' <returns></returns>
    ''' <remarks>輸入角度</remarks>
    Function Sin(ByVal Angle As Double) As Double
        Return Math.Sin(Me.AngleToRad(Angle))
    End Function

    ''' <summary>
    ''' 輸入角度
    ''' </summary>
    ''' <param name="Angle"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function Cos(ByVal Angle As Double) As Double
        Return Math.Cos(Me.AngleToRad(Angle))
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Angle"></param>
    ''' <returns></returns>
    ''' <remarks>輸入角度</remarks>
    Function Tan(ByVal Angle As Double) As Double
        Return Math.Tan(Me.AngleToRad(Angle))
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Angle"></param>
    ''' <returns></returns>
    ''' <remarks>輸入角度</remarks>
    Function CoTan(ByVal Angle As Double) As Double
        Return 1 / Me.Tan(Angle)
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Angle"></param>
    ''' <returns></returns>
    ''' <remarks>輸入角度</remarks>
    Function Sec(ByVal Angle As Double) As Double
        Return 1 / Me.Sin(Angle)
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Angle"></param>
    ''' <returns></returns>
    ''' <remarks>輸入角度</remarks>
    Function CoSec(ByVal Angle As Double) As Double
        Return 1 / Me.Cos(Angle)
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <returns></returns>
    ''' <remarks>傳回角度</remarks>
    Function ASin(ByVal Value As Double) As Double
        Return Me.RadToAngle(Math.Asin(Value))
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <returns></returns>
    ''' <remarks>傳回角度</remarks>
    Function ACos(ByVal Value As Double) As Double
        Return Me.RadToAngle(Math.Acos(Value))
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <returns></returns>
    ''' <remarks>傳回角度</remarks>
    Function ATan(ByVal Value As Double) As Double
        Return Me.RadToAngle(Math.Atan(Value))
    End Function

    ''' <summary>
    ''' 傳回徑度
    ''' </summary>
    ''' <param name="X"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function ASecToRad(ByVal X As Double) As Double
        Return Math.Atan(X / Math.Sqrt(X * X - 1)) + Math.Sign((X) - 1) * (2 * Math.Atan(1))
    End Function

    ''' <summary>
    ''' 傳回徑度
    ''' </summary>
    ''' <param name="X"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function ACoSecToRad(ByVal X As Double) As Double
        Return Math.Atan(X / Math.Sqrt(X * X - 1)) + (Math.Sign(X) - 1) * (2 * Math.Atan(1))
    End Function

    ''' <summary>
    ''' 傳回徑度
    ''' </summary>
    ''' <param name="X"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function ACoTanToRad(ByVal X As Double) As Double
        Return Math.Atan(X) + 2 * Math.Atan(1)
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="X"></param>
    ''' <returns></returns>
    ''' <remarks>傳回角度</remarks>
    Function ASec(ByVal X As Double) As Double
        Return Me.RadToAngle(Me.ASecToRad(X))
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="X"></param>
    ''' <returns></returns>
    ''' <remarks>傳回角度</remarks>
    Function ACoSec(ByVal X As Double) As Double
        Return Me.RadToAngle(Me.ACoSecToRad(X))
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="X"></param>
    ''' <returns></returns>
    ''' <remarks>傳回角度</remarks>
    Function ACoTan(ByVal X As Double) As Double
        Return Me.RadToAngle(Me.ACoTanToRad(X))
    End Function
End Class
