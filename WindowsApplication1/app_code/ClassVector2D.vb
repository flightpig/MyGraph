Public Class ClassVector2D
    Private XValue As Double
    Private YValue As Double
    Private IsVectorAbs As Boolean


    Property X() As Double
        Get
            X = XValue
        End Get
        Set(ByVal value As Double)
            XValue = value
            IsVectorAbs = False
        End Set
    End Property

    Property Y() As Double
        Get
            Y = YValue
        End Get
        Set(ByVal value As Double)
            YValue = value
            IsVectorAbs = False
        End Set
    End Property

    ReadOnly Property IsAbs() As Double
        Get
            IsAbs = IsVectorAbs
        End Get
    End Property

    ''' <summary>
    ''' �ײv
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Slope As Double
        Get
            'Debug.Print(Me.Y & "/" & Me.X & "  --Slope")
            If Me.X = 0 Then Slope = 1 / My.EzFunction.ClassSetting.Epi Else Slope = Me.Y / Me.X
        End Get
        Set(ByVal value As Double)
            Me.X = 1
            Me.Y = Slope
            Me.Abs()
        End Set
    End Property

    Sub New()
        XValue = 0
        YValue = 1
        IsVectorAbs = True
    End Sub

    Sub New(ByVal X As Double, ByVal Y As Double)
        XValue = X
        YValue = Y
    End Sub

    Sub New(ByVal PtStart As ClassPoint2D, ByVal PtEnd As ClassPoint2D, ByVal IsAbs As Boolean)
        Me.VectorPtToPt(PtStart, PtEnd, IsAbs)
    End Sub

    ''' <summary>
    ''' �Ψ��I�p��V�q
    ''' </summary>
    ''' <param name="PtStart">�ҩl�I</param>
    ''' <param name="PtEnd">�����I</param>
    ''' <returns>�^�ǦV�q</returns>
    ''' <remarks></remarks>
    Function VectorPtToPt(ByVal PtStart As ClassPoint2D, ByVal PtEnd As ClassPoint2D) As ClassVector2D
        XValue = PtEnd.X - PtStart.X
        YValue = PtEnd.Y - PtStart.Y
        Me.Abs()
        Return Me
    End Function

    Function VectorPtToPt(ByVal PtStart As ClassPoint2D, ByVal PtEnd As ClassPoint2D, ByVal IsAbs As Boolean) As ClassVector2D
        XValue = PtEnd.X - PtStart.X
        YValue = PtEnd.Y - PtStart.Y
        If IsAbs = True Then
            Me.Abs()
        End If
        Return Me
    End Function
    Function GetAbs() As ClassVector2D
        Dim SqrVector As Double = Me.Length
        Dim Vector As New ClassVector2D
        Vector.X = Me.XValue / SqrVector
        Vector.Y = Me.YValue / SqrVector
        'Vector.IsVectorAbs = True
        Return Vector
    End Function

    ''' <summary>
    ''' �p����V�q
    ''' </summary>
    ''' <remarks></remarks>
    Sub Abs()
        Me.SetSelf(Me.GetAbs())
    End Sub

    ''' <summary>
    ''' �p��Ѧۤw�ΥX�g�V�q�p��k�u�V�q
    ''' </summary>
    ''' <param name="VectorOut">�X�g�V�q</param>
    ''' <param name="N1">����1</param>
    ''' <param name="N2">����2</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function NormalVectorByRefraction(ByVal VectorOut As ClassVector2D, ByVal N1 As Double, ByVal N2 As Double) As ClassVector2D
        Dim Vytmp As Double
        Dim Result As New ClassVector2D

        Vytmp = (N1 * Me.YValue - N2 * VectorOut.YValue) / (N1 * Me.XValue - N2 * VectorOut.XValue)
        Result.X = 1
        Result.Y = Vytmp
        Result.Abs()
        NormalVectorByRefraction = Result
    End Function

    ''' <summary>
    ''' �Ѧۤv�ΤϮg�V�q�p��k�u�V�q
    ''' </summary>
    ''' <param name="VectorOut">�Ϯg�V�q</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function NormalVectorByReflection(ByVal VectorOut As ClassVector2D) As ClassVector2D
        Dim Vytmp As Double
        Dim Result As New ClassVector2D

        Vytmp = (Me.XValue - VectorOut.X) / (VectorOut.Y - Me.YValue)
        Result.X = 1
        Result.Y = -Vytmp   '�]���M�k�u�M�Ϯg�u�����j��90��
        Result.Abs()
        NormalVectorByReflection = Result
    End Function

    ''' <summary>
    ''' �p��V�q�~�n
    ''' </summary>
    ''' <param name="vector">�V�q</param>
    ''' <returns>�^�ǥ~�n��</returns>
    ''' <remarks></remarks>
    Function Close(ByVal vector As ClassVector2D) As Double
        Return Me.XValue * vector.Y - Me.YValue * vector.X
    End Function

    ''' <summary>
    ''' �p��V�q���n
    ''' </summary>
    ''' <param name="Vector">�V�q</param>
    ''' <returns>���n��</returns>
    ''' <remarks></remarks>
    Function Dot(ByVal Vector As ClassVector2D) As Double
        Return Me.XValue * Vector.X + Me.YValue * Vector.Y
    End Function

    ''' <summary>
    ''' �^�ǦV�q����
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function Length() As Double
        Return Math.Sqrt(Me.XValue ^ 2 + Me.YValue ^ 2)
    End Function

    ''' <summary>
    ''' �p��P�V�q������cos��
    ''' </summary>
    ''' <param name="Vector">��J�V�q�@</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function VectorCosRad(ByVal Vector As ClassVector2D) As Double
        Dim CosThidaRadial As Double
        CosThidaRadial = (XValue * Vector.X + Me.YValue * Vector.Y) / (Me.Length * Vector.Length)
        Return CosThidaRadial
    End Function  '�Τ��n�p�⧨��cos��

    ''' <summary>
    ''' �p��P�V�q������
    ''' </summary>
    ''' <param name="Vector"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function VectorAngle(ByVal Vector As ClassVector2D) As Double
        Dim MyMath As New ClassMyMath
        Return MyMath.RadToAngle(Math.Acos(Me.VectorCosRad(Vector)))
    End Function

    ''' <summary>
    ''' �V�q����
    ''' </summary>
    ''' <param name="Angle">����</param>
    ''' <returns>�V�q</returns>
    ''' <remarks></remarks>
    Function GetVectorRotate(ByVal Angle As Double) As ClassVector2D
        Dim MyMath As New ClassMyMath
        Dim Vector As New ClassVector2D
        Dim Rad As Double = MyMath.AngleToRad(Angle)
        Vector.X = Me.XValue * Math.Cos(Rad) - Me.YValue * Math.Sin(Rad)
        Vector.Y = Me.YValue * Math.Cos(Rad) + Me.XValue * Math.Sin(Rad)
        Me.SetSelf(Vector)
        Return Vector
    End Function

    Sub SetSelf(ByVal Vector As ClassVector2D)
        Me.XValue = Vector.X
        Me.YValue = Vector.Y
    End Sub
End Class
