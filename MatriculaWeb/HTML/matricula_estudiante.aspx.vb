﻿Imports Negocios
Public Class Formulario_web11
    Inherits System.Web.UI.Page
    Dim obj_Estudiantes As New ClaseEstudiantes
    Dim obj_Carreras As New Negocios.ClaseCarreras
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Carreras As New DataTable
        Dim nombre_carrera As String
        Dim idCarrera As String
        obj_Carreras.LeeDatosCarrera()
        Carreras = obj_Carreras.TablaCarreras

        'se itera cada fila de la tabla carreras y se agrega items al select_carrera
        For Each fila As DataRow In Carreras.Rows
            nombre_carrera = fila("nombre")
            idCarrera = fila("ID_Carrera")
            Dim opcion As New ListItem(nombre_carrera, idCarrera)
            select_carrera.Items.Add(opcion)
        Next


        cargarInfo()
    End Sub


    Protected Sub btn_Agregar_estudiante_Click(sender As Object, e As EventArgs) Handles btn_Agregar_estudiante.Click
        Try
            obj_Estudiantes.IdEstudiantes = input_id_estudiante.Value
            obj_Estudiantes.IdCarrera = select_carrera.Value
            obj_Estudiantes.Nombre = input_nombre_est.Value
            obj_Estudiantes.Apellidos = input_apellidos.Value
            obj_Estudiantes.Telefono = input_telefono.Value
            obj_Estudiantes.Beca = select_beca.Value
            obj_Estudiantes.FechaNacimiento = input_fecha.Value
            obj_Estudiantes.Correo = input_correo.Value
            obj_Estudiantes.Direccion = input_direccion.Value
            obj_Estudiantes.AgregarDatosEstudiantes()
            cargarInfo()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub cargarInfo()
        Try
            obj_Estudiantes.LeeDatosEstudiantes()
            gv_matricula_estudiantes.DataSource = obj_Estudiantes.TablaEstudiantes
            gv_matricula_estudiantes.DataBind()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class