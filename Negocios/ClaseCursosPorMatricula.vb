
Imports Datos
Public Class ClaseCursosPorMatricula

    Dim _idCursosPorMatricula As String
    Dim _idCarrera As String
    Dim _idCursos As String
    Dim _cuatrimestre As String
    Dim _idMatricula As String
    Dim obj_idCursosPorMatricula As New SQL

    Public Property IdCursosPorMatricula As String
        Get
            Return _idCursosPorMatricula
        End Get
        Set(value As String)
            _idCursosPorMatricula = value
        End Set
    End Property

    Public Property idCarrera As String
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

    Public Property TablaidCursosPorMatricula As DataTable
        Get
            Return obj_idCursosPorMatricula.TablaCursoPorMatricula
        End Get
        Set(value As DataTable)

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

    Public Property IdMatricula As String
        Get
            Return _idMatricula
        End Get
        Set(value As String)
            _idMatricula = value
        End Set
    End Property

    Sub crearIDCursosPorMatricula()
        IdCursosPorMatricula = _idCarrera.Trim + "-" + _cuatrimestre.Trim & "-" & _idCursos.Trim
    End Sub

    Sub GuardarCursosporMatricula()
        obj_idCursosPorMatricula.InsertarCursosxMatricula(_idCursosPorMatricula, _idCursos, _idMatricula)
    End Sub

    Sub consultarCursosPormatricula()
        obj_idCursosPorMatricula.consultarCursosPormatricula(_idCursosPorMatricula)
    End Sub

    Sub EliminarCursosPorMatricula()
        obj_idCursosPorMatricula.EliminarCursosPorMatricula(_idMatricula)
    End Sub

End Class
