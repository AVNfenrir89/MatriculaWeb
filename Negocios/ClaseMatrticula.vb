
Public Class ClaseMatrticula
    Dim _idMatricula As Integer
    Dim _idEstudiante As Integer
    Dim _idCarrera As String
    Dim _idCursos As String
    Dim _costo As Integer
    Dim _cuatrimestre As String
    Dim _periodo As String
#Region "Propiedades"
    Public Property IdMatricula As Integer
        Get
            Return _idMatricula
        End Get
        Set(value As Integer)
            _idMatricula = value
        End Set
    End Property

    Public Property IdEstudiante As Integer
        Get
            Return _idEstudiante
        End Get
        Set(value As Integer)
            _idEstudiante = value
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

    Public Property IdCursos As String
        Get
            Return _idCursos
        End Get
        Set(value As String)
            _idCursos = value
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

    Public Property Cuatrimestre As String
        Get
            Return _cuatrimestre
        End Get
        Set(value As String)
            _cuatrimestre = value
        End Set
    End Property

    Public Property Periodo As String
        Get
            Return _periodo
        End Get
        Set(value As String)
            _periodo = value
        End Set
    End Property
#End Region




End Class
