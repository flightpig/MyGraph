Public Class ClassAlgorithm
    Dim MyMath As New ClassMyMath
    ''' <summary>
    ''' 線性內差(Lagrange法)
    ''' </summary>
    ''' <param name="Xa">所求值之x值陣列</param>
    ''' <param name="X">已知x值陣列</param>
    ''' <param name="F">已知y值陣列</param>
    ''' <returns>所求y值陣列</returns>
    ''' <remarks></remarks>
    Public Function Interpolation_Lagrange(ByVal Xa() As Double, ByVal X() As Double, ByVal F() As Double) As Double()
        Dim i, j, n, k, FxNum As Integer
        Dim La, Fx() As Double
        n = X.Length
        FxNum = Xa.Length
        ReDim Fx(FxNum)
        For k = 0 To FxNum - 1
            For i = 0 To n - 1
                La = 1
                For j = 0 To n - 1
                    If j <> i Then
                        La = La * (Xa(k) - X(j)) / (X(i) - X(j))
                    End If
                Next
                Fx(k) = Fx(k) + La * F(i)
            Next
        Next
        Return Fx
    End Function

    ''' <summary>
    ''' 1維線性內插法
    ''' </summary>
    ''' <param name="X">所求值之x值</param>
    ''' <param name="X1">較小值之x值</param>
    ''' <param name="Y1">較小值之y值</param>
    ''' <param name="X2">較大值之x值</param>
    ''' <param name="Y2">較大值之y值</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function Interpolation_1D(ByVal X As Double, ByVal X1 As Double, ByVal Y1 As Double, ByVal X2 As Double, ByVal Y2 As Double) As Double
        Return (X - X1) * (Y2 - Y1) / (X2 - X1) + Y1
    End Function

    ''' <summary>
    ''' 2維線性內差(矩形網格)
    ''' </summary>
    ''' <param name="Xa">所求值之x值</param>
    ''' <param name="Ya">所求值之y值</param>
    ''' <param name="X">已知值x值陣列</param>
    ''' <param name="Y">已知值y值陣列</param>
    ''' <param name="F">已知值陣列</param>
    ''' <returns>所求值</returns>
    ''' <remarks></remarks>
    Function Interpolation_2D(ByVal Xa As Double, ByVal Ya As Double, ByVal X() As Double, ByVal Y() As Double, ByVal F() As Double) As Double
        Dim Result As Double
        Dim i, j, k As Integer
        Dim Xb(1), Yb(1), Fb(1) As Double
        Dim Xs(1), Ys(1), Fs(1) As Double
        Dim FbTmp, FsTmp As Double

        For Each Item As Double In Y
            If Item > Ya Then
                Xb(i) = X(k)
                Yb(i) = Item
                Fb(i) = F(k)
                i += 1
            Else
                Xs(j) = X(k)
                Ys(j) = Item
                Fs(j) = F(k)
                j += 1
            End If
            k += 1
        Next

        FbTmp = Me.Interpolation_1D(Xa, Xb(0), Fb(0), Xb(1), Fb(1))
        FsTmp = Me.Interpolation_1D(Xa, Xs(0), Fs(0), Xs(1), Fs(1))
        Result = Me.Interpolation_1D(Ya, Yb(0), FbTmp, Ys(0), FsTmp)
        Return Result
    End Function

    ''' <summary>
    ''' 2維線性內差(矩形網格)
    ''' </summary>
    ''' <param name="PtOrg">所求點</param>
    ''' <param name="Pt">已知點</param>
    ''' <returns>所求點</returns>
    ''' <remarks></remarks>
    Function Interpolation_2D(ByVal PtOrg As ClassPoint2D, ByVal Pt() As ClassPoint2D) As ClassPoint2D
        Dim Result As Double
        Dim i, j, k As Integer
        Dim FbTmp, FsTmp As Double
        Dim Ptb(1), Pts(1) As ClassPoint2D

        For Each Item As ClassPoint2D In Pt
            If Item.Y > PtOrg.Y Then
                Ptb(i) = Item
                i += 1
            Else
                Pts(j) = Item
                j += 1
            End If
            k += 1
        Next

        FbTmp = Me.Interpolation_1D(PtOrg.X, Ptb(0).X, Ptb(0).Value, Ptb(1).X, Ptb(1).Value)
        FsTmp = Me.Interpolation_1D(PtOrg.X, Pts(0).X, Pts(0).Value, Pts(1).X, Pts(1).Value)
        Result = Me.Interpolation_1D(PtOrg.Y, Ptb(0).Y, FbTmp, Pts(0).Y, FsTmp)

        Dim PtResult As New ClassPoint2D(PtOrg.X, PtOrg.Y, Result)
        Return PtResult
    End Function

    ''' <summary>
    ''' 2維線性內差(矩形網格)
    ''' </summary>
    ''' <param name="PtOrg">所求點</param>
    ''' <param name="Pt1">已知點1</param>
    ''' <param name="Pt2">已知點2</param>
    ''' <param name="Pt3">已知點3</param>
    ''' <param name="Pt4">已知點4</param>
    ''' <returns>所求點</returns>
    ''' <remarks></remarks>
    Function Interpolation_2D(ByVal PtOrg As ClassPoint2D, ByVal Pt1 As ClassPoint2D, ByVal Pt2 As ClassPoint2D, ByVal Pt3 As ClassPoint2D, ByVal Pt4 As ClassPoint2D) As ClassPoint2D
        Dim Result As Double
        Dim i, j, k As Integer
        Dim FbTmp, FsTmp As Double
        Dim Ptb(1), Pts(1) As ClassPoint2D
        Dim Pt(3) As ClassPoint2D
        Pt(0) = Pt1
        Pt(1) = Pt2
        Pt(2) = Pt3
        Pt(3) = Pt4
        For Each Item As ClassPoint2D In Pt
            If Item.Y > PtOrg.Y Then
                Ptb(i) = Item
                i += 1
            Else
                Pts(j) = Item
                j += 1
            End If
            k += 1
        Next

        FbTmp = Me.Interpolation_1D(PtOrg.X, Ptb(0).X, Ptb(0).Value, Ptb(1).X, Ptb(1).Value)
        FsTmp = Me.Interpolation_1D(PtOrg.X, Pts(0).X, Pts(0).Value, Pts(1).X, Pts(1).Value)
        Result = Me.Interpolation_1D(PtOrg.Y, Ptb(0).Y, FbTmp, Pts(0).Y, FsTmp)

        Dim PtResult As New ClassPoint2D(PtOrg.X, PtOrg.Y, Result)

        Return PtResult
    End Function

    ''' <summary>
    ''' 高斯消去法(ax+by+cz=d)
    ''' </summary>
    ''' <param name="a"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function LinearAlgebra_GaussElimination(ByVal a(,) As Double) As Double()
        Dim i, j, k, m, n As Integer
        Dim Temp, bb, cc As Double
        n = UBound(a, 1) + 1
        Dim x(n - 1) As Double
        For k = 0 To n - 2
            If a(k, k) = 0 Then
                For m = 0 To n
                    Temp = a(k, m)
                    a(k, m) = a(k + 1, m)
                    a(k + 1, m) = Temp
                Next
            End If
            For i = k To n - 2
                bb = a(i + 1, k) / a(k, k)
                For j = k To n
                    a(i + 1, j) = a(i + 1, j) - bb * a(k, j)
                Next
            Next
        Next

        If Math.Abs(a(n - 1, n - 1)) <> 0 Then
            x(n - 1) = a(n - 1, n) / a(n - 1, n - 1)
            For i = n - 2 To 0 Step -1
                cc = 0
                For j = i + 1 To n - 1
                    cc = cc + a(i, j) * x(j)
                Next
                x(i) = (a(i, n) - cc) / a(i, i)
            Next
            Return x
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    ''' 高斯喬丹法(ax+by+cz=d)
    ''' </summary>
    ''' <param name="a"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function LinearAlgebra_GaussJordon(ByVal a(,) As Double) As Double()
        Dim i, j, k, m As Integer
        Dim Temp, bb, jj As Double
        Dim x() As Double
        Dim n As Integer
        n = UBound(a, 1) + 1
        ReDim x(n - 1)
        Debug.Print(n)
        For k = 0 To n - 1
            If a(k, k) = 0 Then
                For m = 0 To n
                    Temp = a(k, m)
                    a(k, m) = a(k + 1, m)
                    a(k + 1, m) = Temp
                Next
            End If
            For i = k To n - 2
                bb = a(i + 1, k) / a(k, k)
                For j = k To n
                    a(i + 1, j) = a(i + 1, j) - bb * a(k, j)
                Next
            Next
        Next
        If Math.Abs(a(n - 1, n - 1)) = 0 Then
            Return Nothing
        Else
            For k = n - 1 To 1 Step -1
                For i = k - 1 To 0 Step -1
                    jj = a(i, k) / a(k, k)
                    For j = n To k Step -1
                        a(i, j) = a(i, j) - jj * a(k, j)
                    Next
                Next

            Next
            For i = 0 To n - 1
                x(i) = a(i, n) / a(i, i)
            Next
            Return x
        End If

    End Function

    ''' <summary>
    ''' 解二元一次方程組
    ''' ax+by=c
    ''' dx+ey=f
    ''' </summary>
    ''' <param name="a"></param>
    ''' <param name="b"></param>
    ''' <param name="c"></param>
    ''' <param name="d"></param>
    ''' <param name="e"></param>
    ''' <param name="f"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function DualityLinearEquation(ByVal a As Double, ByVal b As Double, ByVal c As Double, ByVal d As Double, ByVal e As Double, ByVal f As Double) As Double()
        Try
            Dim Result(1) As Double
            Dim Denominator1 = a * e - d * b
            Dim Denominator2 = d * b - a * e
            If Denominator1 = 0 Or Denominator2 = 0 Then
                Return Nothing
            Else
                Result(0) = (c * e - f * b) / Denominator1
                Result(1) = (d * c - a * f) / Denominator2
                Return Result
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' 高斯疊代法(ax+by+cz=d)
    ''' </summary>
    ''' <param name="A"></param>
    ''' <param name="Z"></param>
    ''' <param name="Tolerance"></param>
    ''' <param name="Lambda"></param>
    ''' <param name="Imax"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function LinearAlgebra_GaussSeider(ByVal A(,) As Double, ByVal Z() As Double, ByVal Tolerance As Double, ByVal Lambda As Integer, ByVal Imax As Integer)
        Dim Flag As Boolean = False
        Dim Over As Boolean = False
        Dim i, j, n, L, k, Iter As Integer
        Dim TmpBig, Hold, Sum As Double
        Dim Coef() As Double
        Dim ResultCheck As String = ""
        n = UBound(A, 1)
        ReDim Coef(n)
        For i = 0 To n
            TmpBig = Math.Abs(A(i, i))
            L = i
            For j = i + 1 To n
                If Math.Abs(A(j, i)) > TmpBig Then
                    TmpBig = Math.Abs(A(j, i))
                    L = j
                End If
            Next
            If TmpBig = 0 Then
                Flag = True
                Exit For
            ElseIf L <> i Then
                For j = 0 To n
                    Hold = A(L, j)
                    A(L, j) = A(i, j)
                    A(i, j) = Hold
                Next
                Hold = Z(L)
                Z(L) = Z(i)
                Z(i) = Hold
            End If
        Next

        Dim aa As String = ""
        Dim tmp As Double
        For i = 0 To n
            For j = 0 To n
                aa += A(i, j) & "   "
            Next
            'Debug.Print(aa & " ---1")
            aa = ""
        Next

        Dim b(,) As Double
        Dim check As Boolean = False
        Dim CheckBig As Boolean = False
        Dim p As Integer
        ReDim b(UBound(A, 1), UBound(A, 2))
        For i = 0 To n - 1
            For j = i + 1 To n
                If Math.Abs(A(i, i)) < Math.Abs(A(i, j)) Then
                    tmp = A(i, j)
                    For p = 0 To n
                        A(i, p) = A(i, p) / tmp
                    Next
                    Z(i) = Z(i) / tmp
                End If
            Next
        Next

        For i = 0 To n
            For j = 0 To n
                aa += A(i, j) & "   "
            Next
            'Debug.Print(aa & "---2")
            aa = ""
        Next

        If A(n, n) = 0 Then
            Flag = True
        Else
            For i = 0 To n
                Coef(i) = 0
            Next

            While (Over = False And Iter <= Imax)
                Iter += 1
                For j = 0 To n
                    Sum = Z(j)
                    For k = 0 To n
                        If j <> k Then
                            Sum = Sum - A(j, k) * Coef(k)
                        End If
                    Next
                    Hold = Sum / A(j, j)
                    If Math.Abs(Hold - Coef(j)) < Tolerance Then
                        Over = True
                    Else
                        Over = False
                    End If
                    If Hold * Coef(j) < 0 Then
                        Hold = (Coef(j) + Hold) / 2
                    End If
                    Coef(j) = Lambda * Hold + (1 - Lambda) * Coef(j)
                    ResultCheck += Coef(j) & "   "
                Next
                'Debug.Print(ResultCheck)
                ResultCheck = ""
            End While
            If Over <> True Then Flag = True
        End If
        If Flag = True Then Debug.Print("no solution")
        Return Coef
    End Function

    ''' <summary>
    ''' 最小平方誤差法
    ''' </summary>
    ''' <param name="X"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function LeastSquareForPointToPlane(ByVal X(,) As Double) 'As double()'仍有問題
        Dim A(,) As Double
        Dim SumX(), z() As Double
        ReDim SumX(3)
        ReDim A(3, 3)
        ReDim z(3)
        Dim i, j As Integer
        For i = 0 To UBound(SumX)
            If i <> UBound(SumX) Then
                For j = 0 To UBound(X, 1)
                    SumX(i) += X(j, i)
                Next
            Else
                SumX(i) = 1
            End If
        Next
        Dim Test As String = ""
        'Debug.Print(UBound(A, 1))
        For i = 0 To UBound(A, 1)
            For j = 0 To UBound(A, 2)
                'If j = UBound(A, 2) Then
                '    A(i, j) = 0
                'Else
                '    A(i, j) = SumX(i) * SumX(j)
                'End If
                'If j = UBound(A, 2) Then
                'z(i) = 0
                'Else
                If i = UBound(A, 1) And j = UBound(A, 2) Then
                    A(i, j) = UBound(X, 1) + 1
                Else
                    A(i, j) = SumX(i) * SumX(j)
                End If

                'End If

                If j = UBound(A, 2) Then
                    Test += A(i, j) & ""
                Else
                    Test += A(i, j) & ","
                End If
            Next
            Test += vbCrLf
        Next

        Dim Result() As Double
        'Dim z(3) As double

        'Result = LinearAlgebra_GaussElimination(A)
        Result = LinearAlgebra_GaussSeider(A, z, 0.001, 1, 50)
        For i = 0 To UBound(Result)
            'For j = 0 To UBound(Result, 2)
            If i = UBound(Result) Then
                Test += Result(i) & ""
            Else
                Test += Result(i) & ","
            End If
        Next
        'Test += vbCrLf
        'Next
        Return Test
    End Function
End Class
