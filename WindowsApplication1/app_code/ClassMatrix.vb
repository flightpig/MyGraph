''' <summary>
''' 矩陣
''' </summary>
''' <remarks></remarks>
Public Class ClassMatrix

    ''' <summary>
    ''' 列數
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Rows() As Integer
        Get
            Rows = Me.Matrix.GetUpperBound(0) + 1
        End Get
    End Property

    ''' <summary>
    '''  行數
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Columns() As Integer
        Get
            Columns = Me.Matrix.GetUpperBound(1) + 1
        End Get
    End Property

    ''' <summary>
    ''' 下三角矩陣
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property LMatrix() As ClassMatrix
        Get
            Dim Matrix() As ClassMatrix = Me.LUReduce
            Return Matrix(0)
        End Get
    End Property

    ''' <summary>
    ''' 上三角矩陣
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property UMatrix() As ClassMatrix
        Get
            Dim Matrix() As ClassMatrix = Me.LUReduce
            UMatrix = Matrix(1)
        End Get
    End Property

    Dim MyMatrix(1, 1) As Double
    ''' <summary>
    ''' 矩陣
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Matrix() As Double(,)
        Get
            Matrix = MyMatrix
        End Get
        Set(ByVal value(,) As Double)
            MyMatrix = value
        End Set
    End Property

    ReadOnly Property Dett() As Double
        Get
            If Me.Rows = 2 And Me.Columns = 2 Then
                Return Me.Matrix(0, 0) * Me.Matrix(1, 1) - Me.Matrix(0, 1) * Me.Matrix(1, 0)
            Else
                Dim UMatrix As ClassMatrix = Me.UMatrix
                Dim i As Integer
                Dim Det As Double = UMatrix.Matrix(0, 0)
                For i = 1 To Me.Matrix.GetUpperBound(0)
                    Det = Det * UMatrix.Matrix(i, i)
                Next
                Return Det
            End If
        End Get
    End Property

    Sub New()

    End Sub

    Sub New(ByVal NewMatrix As ClassMatrix)
        Me.Matrix = NewMatrix.Matrix
    End Sub

    Sub New(ByVal NewArray(,) As Double)
        Me.SetByArray(NewArray)
    End Sub

    Sub New(ByVal NewRow As Integer, ByVal NewColumn As Integer)
        ReDim Me.Matrix(NewRow, NewColumn)
    End Sub

    ''' <summary>
    ''' 由陣列設定矩陣
    ''' </summary>
    ''' <param name="NewArray"></param>
    ''' <remarks></remarks>
    Sub SetByArray(ByVal NewArray(,) As Double)
        Dim Row As Integer = NewArray.GetUpperBound(0)
        Dim Column As Integer = NewArray.GetUpperBound(1)
        ReDim Me.Matrix(Row, Column)
        For i As Integer = 0 To Row
            For j As Integer = 0 To Column
                Me.Matrix(i, j) = NewArray(i, j)
            Next
        Next
    End Sub

    ''' <summary>
    ''' 取得轉置矩陣
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetTranspose() As ClassMatrix
        Dim Row As Integer = Me.Matrix.GetUpperBound(0)
        Dim Column As Integer = Me.Matrix.GetUpperBound(1)
        Dim NewMatrix As New ClassMatrix(Column, Row)
        For i As Integer = 0 To Column
            For j As Integer = 0 To Row
                NewMatrix.Matrix(i, j) = Me.Matrix(j, i)
            Next
        Next
        Return NewMatrix
    End Function

    ''' <summary>
    ''' 設定轉置矩陣
    ''' </summary>
    ''' <remarks></remarks>
    Sub SetTranspose()
        Me.Matrix = Me.GetTranspose.Matrix
    End Sub

    Overloads Function ToString(Optional ByVal IsBranch As Boolean = False) As String
        Dim Sb As New System.Text.StringBuilder
        Dim Branch As String
        If IsBranch Then Branch = vbCrLf Else Branch = "|"
        For i As Integer = 0 To Me.Matrix.GetUpperBound(0)
            For j As Integer = 0 To Me.Matrix.GetUpperBound(1)
                Sb.Append(Me.Matrix(i, j))
                If j <> Me.Matrix.GetUpperBound(1) Then Sb.Append(",")
            Next
            If i <> Me.Matrix.GetUpperBound(0) Then Sb.Append(Branch)
        Next
        Return Sb.ToString
    End Function

    ''' <summary>
    ''' 取得乘過值的矩陣
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetMultiply(ByVal Value As Double) As ClassMatrix
        Dim Row As Integer = Me.Matrix.GetUpperBound(0)
        Dim Column As Integer = Me.Matrix.GetUpperBound(1)
        Dim NewMt As New ClassMatrix(Row, Column)
        For i As Integer = 0 To Row
            For j As Integer = 0 To Column
                NewMt.Matrix(i, j) = Me.Matrix(i, j) * Value
            Next
        Next
        Return NewMt
    End Function

    ''' <summary>
    ''' 設定乘過值的矩陣
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    Sub SetMultiply(ByVal Value As Double)
        Me.Matrix = Me.GetMultiply(Value).Matrix
    End Sub

    ''' <summary>
    ''' 取得兩矩陣相乘的矩陣
    ''' </summary>
    ''' <param name="Mt"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetMultiply(ByVal Mt As ClassMatrix) As ClassMatrix
        If Me.Rows = Mt.Columns Then
            Dim NewMt As New ClassMatrix(Me.Rows - 1, Mt.Columns - 1)
            Dim RowNum As Integer = NewMt.Matrix.GetUpperBound(0)
            Dim ColNum As Integer = NewMt.Matrix.GetUpperBound(1)
            For i As Integer = 0 To RowNum
                For j As Integer = 0 To ColNum
                    For k As Integer = 0 To Me.Columns - 1
                        NewMt.Matrix(i, j) += Me.Matrix(i, k) * Mt.Matrix(k, j)
                    Next
                Next
            Next
            Return NewMt
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    ''' 設定兩矩陣相乘的矩陣
    ''' </summary>
    ''' <param name="Mt"></param>
    ''' <remarks></remarks>
    Sub SetMultiply(ByVal Mt As ClassMatrix)
        Me.Matrix = Me.GetMultiply(Mt).Matrix
    End Sub

    ''' <summary>
    ''' 取得除過值的矩陣
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetDivide(ByVal Value As Double) As ClassMatrix
        Return Me.GetMultiply(1 / Value)
    End Function

    ''' <summary>
    ''' 設定除過值的矩陣
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <remarks></remarks>
    Sub SetDivide(ByVal Value As Double)
        Me.SetMultiply(1 / Value)
    End Sub

    ''' <summary>
    ''' 取得除去特定行及列的陣列
    ''' </summary>
    ''' <param name="ColNo">要除法的行</param>
    ''' <param name="RowNo">要除去的列</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetExceptRowAndColumn(ByVal RowNo As Integer, ByVal ColNo As Integer) As ClassMatrix
        Dim Row As Integer = Me.Matrix.GetUpperBound(0)
        Dim Column As Integer = Me.Matrix.GetUpperBound(1)
        Dim Mt As New ClassMatrix(Row - 1, Column - 1)
        Dim RowIndex, ColIndex As Integer
        For i As Integer = 0 To Row
            ColIndex = 0
            If i <> RowNo Then
                For j As Integer = 0 To Column
                    If j <> ColNo Then Mt.Matrix(RowIndex, ColIndex) = Me.Matrix(i, j) : ColIndex += 1
                Next
                RowIndex += 1
            End If
        Next
        Return Mt
    End Function

    ''' <summary>
    ''' 設定除去特定行及列的陣列
    ''' </summary>
    ''' <param name="RowNo"></param>
    ''' <param name="ColNo"></param>
    ''' <remarks></remarks>
    Sub SetExceptRowAndColumn(ByVal RowNo As Integer, ByVal ColNo As Integer)
        Me.Matrix = Me.GetExceptRowAndColumn(RowNo, ColNo).Matrix
    End Sub

    ''' <summary>
    ''' 取得簡化矩陣
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetSimplify() As ClassMatrix
        Dim RowNum As Integer = Me.Matrix.GetUpperBound(0)
        Dim ColNum As Integer = Me.Matrix.GetUpperBound(1)
        Dim Mt As New ClassMatrix(RowNum, ColNum)
        For i As Integer = 0 To RowNum
            For j As Integer = 0 To ColNum
                Dim DettMt As Double = Me.GetExceptRowAndColumn(i, j).Dett
                Mt.Matrix(i, j) = ((-1) ^ ((i + 1) + (j + 1))) * DettMt
            Next
        Next
        Return Mt
    End Function

    ''' <summary>
    ''' 設定簡化矩陣
    ''' </summary>
    ''' <remarks></remarks>
    Sub SetSimplify()
        Me.Matrix = Me.GetSimplify.Matrix
    End Sub

    ''' <summary>
    ''' 上下三角矩陣(0為下三角，1為上三角)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function LUReduce() As ClassMatrix()
        Dim a(,) As Double = Me.Matrix
        Dim nn, n, i, j, k As Integer
        Dim temp1, temp2 As Double
        nn = UBound(a, 1)
        Dim u(,), l(,) As Double
        ReDim u(nn, nn), l(nn, nn)

        For i = 0 To nn
            For j = 0 To nn
                u(i, j) = 0
                l(i, j) = 0
            Next
        Next
        For n = 0 To nn
            For j = n To nn
                temp1 = 0
                For k = 0 To n - 1
                    temp1 = temp1 + l(n, k) * u(k, j)
                Next
                u(n, j) = a(n, j) - temp1
            Next
            For i = n + 1 To nn
                temp2 = 0
                For k = 0 To n - 1
                    temp2 = temp2 + l(i, k) * u(k, n)
                Next
                If u(n, n) = 0 Then l(i, n) = 0 Else l(i, n) = (a(i, n) - temp2) / u(n, n)
            Next
        Next
        For i = 0 To nn
            l(i, i) = 1
        Next
        Return {New ClassMatrix(l), New ClassMatrix(u)}
    End Function

    ''' <summary>
    ''' 由高斯消去法求反矩陣
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetInverseByGuassElim() As ClassMatrix
        Dim DetA As Double = Me.Dett
        If Math.Abs(DetA) > My.EzFunction.ClassSetting.Epi Then
            Dim Mt As New ClassMatrix(Me.Matrix)
            Dim Inv As ClassMatrix = Me.GetUnitMatrix
            Dim Temp As Double
            For i As Integer = 0 To Mt.Matrix.GetUpperBound(0)
                Temp = Mt.Matrix(i, i)
                For j As Integer = 0 To Mt.Matrix.GetUpperBound(1)
                    Mt.Matrix(i, j) /= Temp
                    Inv.Matrix(i, j) /= Temp
                Next

                For j As Integer = 0 To Mt.Matrix.GetUpperBound(0)
                    If i <> j Then
                        Temp = Mt.Matrix(j, i)
                        For k As Integer = 0 To Mt.Matrix.GetUpperBound(1)
                            Mt.Matrix(j, k) -= Temp * Mt.Matrix(i, k)
                            Inv.Matrix(j, k) -= Temp * Inv.Matrix(i, k)
                        Next
                    End If
                Next
            Next
            Return Inv
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    ''' 設定為高斯消去法的反矩陣
    ''' </summary>
    ''' <remarks></remarks>
    Sub SetInverseByGuassElim()
        Dim Mt As ClassMatrix = Me.GetInverseByGuassElim
        If Not Mt Is Nothing Then Me.Matrix = Mt.Matrix
    End Sub

    ''' <summary>
    ''' 取得單位矩陣
    ''' </summary>
    ''' <param name="Int"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetUnitMatrix(ByVal Int As Integer) As ClassMatrix
        Dim Mt As New ClassMatrix(Int - 1, Int - 1)
        For i As Integer = 0 To Int - 1
            For j As Integer = 0 To Int - 1
                If i = j Then Mt.Matrix(i, j) = 1 Else Mt.Matrix(i, j) = 0
            Next
        Next
        Return Mt
    End Function

    ''' <summary>
    ''' 設定單位矩陣
    ''' </summary>
    ''' <param name="Int"></param>
    ''' <remarks></remarks>
    Sub SetUnitMatrix(ByVal Int As Integer)
        Me.Matrix = Me.GetUnitMatrix(Int).Matrix
    End Sub

    ''' <summary>
    ''' 取得單位矩陣
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetUnitMatrix() As ClassMatrix
        Return Me.GetUnitMatrix(Me.Rows)
    End Function

    ''' <summary>
    ''' 設定單位矩陣
    ''' </summary>
    ''' <remarks></remarks>
    Sub SetUnitMatrix()
        Me.Matrix = Me.GetUnitMatrix.Matrix
    End Sub

    ''' <summary>
    ''' 回傳兩矩陣相加後的矩陣
    ''' </summary>
    ''' <param name="MtAdd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetAdd(ByVal MtAdd As ClassMatrix) As ClassMatrix
        If MtAdd.Rows = Me.Rows And MtAdd.Columns = Me.Columns Then
            Dim RowNum As Integer = Me.Matrix.GetUpperBound(0)
            Dim ColNum As Integer = Me.Matrix.GetUpperBound(1)
            Dim Mt As New ClassMatrix(RowNum, ColNum)
            For i As Integer = 0 To RowNum
                For j As Integer = 0 To ColNum
                    Mt.Matrix(i, j) = Me.Matrix(i, j) + MtAdd.Matrix(i, j)
                Next
            Next
            Return Mt
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    ''' 設定為兩矩陣相加
    ''' </summary>
    ''' <param name="MtAdd"></param>
    ''' <remarks></remarks>
    Sub SetAdd(ByVal MtAdd As ClassMatrix)
        Me.SetByArray(Me.GetAdd(MtAdd).Matrix)
    End Sub

    ''' <summary>
    ''' 由伴隨矩陣法求反矩陣
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetInverseByAdjoint()
        Dim DetA As Double = Me.Dett
        If Math.Abs(DetA) > My.EzFunction.ClassSetting.Epi Then
            Dim Mt As New ClassMatrix(Me.Matrix)
            Mt.SetTranspose()
            Mt.SetSimplify()
            Mt.SetDivide(DetA)
            Return Mt
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    ''' 由伴隨矩陣法設定反矩陣
    ''' </summary>
    ''' <remarks></remarks>
    Sub SetInverseByAdjoint()
        Dim Mt As ClassMatrix = Me.GetInverseByAdjoint
        If Not Mt Is Nothing Then Me.SetByArray(Mt.Matrix)
    End Sub
End Class
