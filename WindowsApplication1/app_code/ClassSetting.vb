Namespace My
    Namespace EzFunction
        Public Class ClassSetting
            ''' <summary>
            ''' 設定小數點間比較的精度
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Shared ReadOnly Property Epi As Double
                Get
                    Epi = 0.0000000001
                End Get
            End Property

            ''' <summary>
            ''' 小數點位數
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Shared ReadOnly Property Digit As Short
                Get
                    Digit = 10
                End Get
            End Property

            Public Class AxisType
                Shared ReadOnly Property X As Short
                    Get
                        X = 0
                    End Get
                End Property

                Shared ReadOnly Property Y As Short
                    Get
                        Y = 1
                    End Get
                End Property

                Shared ReadOnly Property Z As Short
                    Get
                        Z = 2
                    End Get
                End Property

                ''' <summary>
                ''' 取得軸向
                ''' </summary>
                ''' <param name="Type"></param>
                ''' <returns></returns>
                ''' <remarks></remarks>
                Shared Function GetAxisType(ByVal Type As String) As Short
                    Select Case Type
                        Case "X"
                            Return AxisType.X
                        Case "Y"
                            Return AxisType.Y
                        Case "Z"
                            Return AxisType.Z
                        Case Else
                            Return AxisType.Z
                    End Select
                End Function

                ''' <summary>
                ''' 取得軸向
                ''' </summary>
                ''' <param name="Type"></param>
                ''' <returns></returns>
                ''' <remarks></remarks>
                Shared Function GetAxisType(ByVal Type As Short) As String
                    Select Case Type
                        Case AxisType.X
                            Return "X"
                        Case AxisType.Y
                            Return "Y"
                        Case AxisType.Z
                            Return "Z"
                        Case Else
                            Return "Z"
                    End Select
                End Function

            End Class

        End Class
    End Namespace
End Namespace

