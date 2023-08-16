﻿Imports Datos

Public Class ClaseMatrticula
    Inherits ClaseCursos
    Dim _idMatricula As Integer
    Dim _idEstudiante As Integer
    Dim _idCarrera As String
    Dim _idCursos As String
    Dim _costo As Integer
    Dim _cuatrimestre As String
    Dim _periodo As String
    Dim obj_MatriculaBD As New SQL

#Region "Propiedades"
    Public Property TablaMatricula As DataTable
        Get
            Return obj_MatriculaBD.TablaMatricula
        End Get
        Set(value As DataTable)

        End Set
    End Property

    Public Property Tabla_Cursos As DataTable
        Get
            Return obj_MatriculaBD.TablaCursos
        End Get
        Set(value As DataTable)

        End Set
    End Property
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

    Sub AgregarMatricula()
        obj_MatriculaBD.InsertarMatricula(_idMatricula, _idEstudiante, _idCarrera, _costo, _cuatrimestre, "1")
    End Sub

    Sub RecibirTablaID()
        obj_MatriculaBD.ConsultarIdMatricula(_idEstudiante, _idCarrera, _cuatrimestre)
    End Sub

    Sub GuardarCursosporMatricula()
        obj_MatriculaBD.InsertarCursosxMatricula(_idCursos, _idMatricula)
    End Sub

    Sub leeTablaMatricula()
        obj_MatriculaBD.LeerTablaMatriculaBD()
    End Sub
End Class
