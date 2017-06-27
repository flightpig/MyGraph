Namespace My
    Namespace EzFunction
        ''' <summary>
        ''' 確認數值的物件
        ''' </summary>
        ''' <remarks></remarks>
        Public Class ClassCheckValue

            Shared Function CompareLarge(ByVal Number1 As Integer, ByVal Number2 As Integer) As Integer
                Dim Tmp As Integer
                If Number1 >= Number2 Then
                    Tmp = Number1
                Else
                    Tmp = Number2
                End If
                Return Tmp
            End Function

            Shared Function CompareSmall(ByVal Number1 As Integer, ByVal Number2 As Integer) As Integer
                Dim Tmp As Integer
                If Number1 <= Number2 Then
                    Tmp = Number1
                Else
                    Tmp = Number2
                End If
                Return Tmp
            End Function

            Shared Function CompareLarge(ByVal Number1 As Double, ByVal Number2 As Double) As Double
                Dim Tmp As Double
                If Number1 > Number2 Then
                    Tmp = Number1
                Else
                    Tmp = Number2
                End If
                Return Tmp
            End Function

            Shared Function CompareSmall(ByVal Number1 As Double, ByVal Number2 As Double) As Double
                Dim Tmp As Double
                If Number1 < Number2 Then
                    Tmp = Number1
                Else
                    Tmp = Number2
                End If
                Return Tmp
            End Function

            Shared Function CompareLarge(ByVal Number1, ByVal Number2)
                Dim Tmp
                If Number1 > Number2 Then
                    Tmp = Number1
                Else
                    Tmp = Number2
                End If
                Return Tmp
            End Function

            Shared Function CompareSmall(ByVal Number1, ByVal Number2)
                Dim Tmp
                If Number1 < Number2 Then
                    Tmp = Number1
                Else
                    Tmp = Number2
                End If
                Return Tmp
            End Function

            ''' <summary>
            ''' 判斷兩個值是否相同
            ''' </summary>
            ''' <param name="Value1"></param>
            ''' <param name="Value2"></param>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Shared Function IsEqual(ByVal Value1 As Single, ByVal Value2 As Single) As Boolean
                If Math.Abs(Value1 - Value2) < My.EzFunction.ClassSetting.Epi Then Return True Else Return False
            End Function

            ''' <summary>
            ''' 判斷兩個值是否相同
            ''' </summary>
            ''' <param name="Value1"></param>
            ''' <param name="Value2"></param>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Shared Function IsEqual(ByVal Value1 As Double, ByVal Value2 As Double) As Boolean
                If Math.Abs(Value1 - Value2) < My.EzFunction.ClassSetting.Epi Then Return True Else Return False
            End Function

            ''' <summary>
            ''' 判斷是否有落在範圍內
            ''' </summary>
            ''' <param name="Value"></param>
            ''' <param name="Range1"></param>
            ''' <param name="Range2"></param>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Shared Function IsInRange(ByVal Value As Double, ByVal Range1 As Double, ByVal Range2 As Double) As Boolean
                Dim MaxValue As Double = FormatNumber(CompareLarge(Range1, Range2), My.EzFunction.ClassSetting.Digit)
                Dim MinValue As Double = FormatNumber(CompareSmall(Range1, Range2), My.EzFunction.ClassSetting.Digit)
                Value = FormatNumber(Value, My.EzFunction.ClassSetting.Digit)
                If Value >= MinValue And Value <= MaxValue Then
                    Return True
                Else
                    Return False
                End If
            End Function

            ''' <summary>
            ''' 是否為數字
            ''' </summary>
            ''' <param name="value"></param>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Shared Function IsNumber(ByVal value As Object) As Boolean
                If Not value Is Nothing And value <> "" And IsNumeric(value) Then Return True Else Return False
            End Function
        End Class
    End Namespace
End Namespace

