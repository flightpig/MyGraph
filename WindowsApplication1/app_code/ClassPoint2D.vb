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
    ''' ���X����
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
    ''' �]�w����
    ''' </summary>
    ''' <param name="Angle"></param>
    ''' <remarks></remarks>
    Sub SetRotate(ByVal Angle As Double)
        Dim Pt As New ClassPoint2D
        Pt = Me.GetRotate(Angle)
        Me.SetSelf(Pt)
    End Sub

    ''' <summary>
    ''' �������
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
    ''' �]�w����
    ''' </summary>
    ''' <param name="Xa"></param>
    ''' <param name="Ya"></param>
    ''' <remarks></remarks>
    Sub SetTranslate(ByVal Xa As Double, ByVal Ya As Double)
        Dim Pt As ClassPoint2D = Me.GetTranslate(Xa, Ya)
        Me.SetSelf(Pt)
    End Sub

    ''' <summary>
    ''' �P�t�@�I�Z��
    ''' </summary>
    ''' <param name="Pt2">�I</param>
    ''' <returns>�Z��</returns>
    ''' <remarks></remarks>
    Function Distance(ByVal Pt2 As ClassPoint2D) As Double
        Return Math.Sqrt((Pt2.X - Me.XValue) ^ 2 + (Pt2.Y - YValue) ^ 2)
    End Function

    ''' <summary>
    ''' �^�ǨS�}�ڸ����Z��
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
    ''' �O�_�����b�u�d��
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
    ''' �P�_�O�_���b����u��
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
    ''' ���I���@cross
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
    ''' ���L�q�L���l����
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
    ''' �I���I����
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
    ''' �I���I����
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
    ''' �P�_���I�O�_�ۦP
    ''' </summary>
    ''' <param name="Pt"></param>
    ''' <param name="IsEpi">�O�_�λ~�t�ȧP�_</param>
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
    ''' �O�_���u�����I
    ''' </summary>
    ''' <param name="Line"></param>
    ''' <param name="IsEpi"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function IsLineEndPoint(ByVal Line As ClassLine2D, Optional ByVal IsEpi As Boolean = True) As Boolean
        If Me.IsTheSame(Line.PtStart, IsEpi) Or Me.IsTheSame(Line.PtEnd, IsEpi) Then Return True Else Return False
    End Function

    ''' <summary>
    ''' �I�O�_�b�u�W
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
