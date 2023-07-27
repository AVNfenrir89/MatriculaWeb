Public Class ClaseCursos
    Dim _idCurso As String
    Dim _idCarrera As String
    Dim _nombre As String
    Dim _creditos As Integer
    Dim _notaMinima As Integer
    Dim _cantMin As Integer
    Dim _cantMax As Integer
    Dim _grado As String
    Dim _estado As String
    Dim _costo As Integer

#Region "Propiedades"
    Public Property IdCurso As String
        Get
            Return _idCurso
        End Get
        Set(value As String)
            _idCurso = value
        End Set
    End Property

    Public Property Nombre As String
        Get
            Return _nombre
        End Get
        Set(value As String)
            _nombre = value
        End Set
    End Property

    Public Property Creditos As Integer
        Get
            Return _creditos
        End Get
        Set(value As Integer)
            _creditos = value
        End Set
    End Property

    Public Property CantMin As Integer
        Get
            Return _cantMin
        End Get
        Set(value As Integer)
            _cantMin = value
        End Set
    End Property

    Public Property CantMax As Integer
        Get
            Return _cantMax
        End Get
        Set(value As Integer)
            _cantMax = value
        End Set
    End Property

    Public Property Grado As String
        Get
            Return _grado
        End Get
        Set(value As String)
            _grado = value
        End Set
    End Property

    Public Property Estado As String
        Get
            Return _estado
        End Get
        Set(value As String)
            _estado = value
        End Set
    End Property

    Public Property Costo As Integer
        Get
            Return _costo
        End Get
        Set(value As Integer)
            _costo = value
        End Set
    End Property

    Public Property IdCarrera As String
        Get
            Return _idCarrera
        End Get
        Set(value As String)
            _idCarrera = value
        End Set
    End Property
#End Region
End Class
