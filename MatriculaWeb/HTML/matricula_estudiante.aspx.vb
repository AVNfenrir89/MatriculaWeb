﻿Imports Negocios
Public Class Formulario_web11
    Inherits System.Web.UI.Page
    Dim obj_Estudiantes As New ClaseEstudiantes
    Dim obj_Carreras As New Negocios.ClaseCarreras
    Shared valor As Boolean = True
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            beca_no.Checked = True
            select_beca.Disabled = True
            cargarInfo()
            ' Dim Carreras As New DataTable
            Dim nombre_carrera As String
            Dim idCarrera As String
            obj_Carreras.LeeDatosCarrera()


            'se itera cada fila de la tabla carreras y se agrega items al select_carrera
            If valor Then
                For Each fila As DataRow In obj_Carreras.TablaCarreras.Rows
                    nombre_carrera = fila("nombre")
                    idCarrera = fila("ID_Carrera")
                    Dim opcion As New ListItem(nombre_carrera, idCarrera)
                    select_carrera.Items.Add(opcion)
                    select_carrera2.Items.Add(opcion)
                Next
                valor = False
            End If
        End If
    End Sub

    Protected Sub btn_Agregar_estudiante_Click(sender As Object, e As EventArgs) Handles btn_Agregar_estudiante.Click
        Try
            obj_Estudiantes.IdEstudiantes = input_id_estudiante.Value
            obj_Estudiantes.IdCarrera = select_carrera.Value
            obj_Estudiantes.Nombre = input_nombre_est.Value
            obj_Estudiantes.Apellidos = input_apellidos.Value
            obj_Estudiantes.Telefono = input_telefono.Value
            If beca_no.Checked Then
                obj_Estudiantes.Beca = 0
            Else
                obj_Estudiantes.Beca = select_beca.Value
            End If
            'obj_Estudiantes.Beca = select_beca.Value
            obj_Estudiantes.FechaNacimiento = input_fecha.Value
            obj_Estudiantes.Correo = input_correo.Value
            obj_Estudiantes.Direccion = input_direccion.Value
            obj_Estudiantes.AgregarDatosEstudiantes()
            cargarInfo()
            limpiar_Agregar()
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
    Protected Sub btn_Borrar_Click(sender As Object, e As EventArgs) Handles btn_Borrar.Click
        Try
            obj_Estudiantes.IdEstudiantes = input_buscar.Value
            obj_Estudiantes.borrarEstudiante()
            cargarInfo()
            limpiar_Modificar_Borrar()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub limpiar_Agregar()
        input_id_estudiante.Value = ""
        input_nombre_est.Value = ""
        input_apellidos.Value = ""
        input_telefono.Value = ""
        input_fecha.Value = ""
        input_correo.Value = ""
        input_direccion.Value = ""
    End Sub
    Sub limpiar_Modificar_Borrar()
        input_buscar.Value = ""
        input_nombre_est2.Value = ""
        input_apellidos2.Value = ""
        input_telefono2.Value = ""
        input_fecha2.Value = ""
        input_correo2.Value = ""
        input_direccion2.Value = ""
    End Sub

    Protected Sub btn_Modificar_Click(sender As Object, e As EventArgs) Handles btn_Modificar.Click
        Try
            obj_Estudiantes.IdEstudiantes = input_buscar.Value
            obj_Estudiantes.IdCarrera = select_carrera2.Value
            obj_Estudiantes.Nombre = input_nombre_est2.Value
            obj_Estudiantes.Apellidos = input_apellidos2.Value
            obj_Estudiantes.Telefono = input_telefono2.Value
            If beca_no.Checked Then
                obj_Estudiantes.Beca = 0
            Else
                obj_Estudiantes.Beca = select_beca2.Value
            End If
            'obj_Estudiantes.Beca = select_beca.Value
            obj_Estudiantes.FechaNacimiento = input_fecha2.Value
            obj_Estudiantes.Correo = input_correo2.Value
            obj_Estudiantes.Direccion = input_direccion2.Value
            obj_Estudiantes.ModificarEstudiante()
            cargarInfo()
            limpiar_Modificar_Borrar()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub btn_buscar_Click(sender As Object, e As EventArgs)
        ' Dim estudiates As New DataTable
        obj_Estudiantes.IdEstudiantes = input_buscar.Value
        obj_Estudiantes.SelecionarEstudiante()
        'estudiates = obj_Estudiantes.TablaEstudiantes

        For Each fila As DataRow In obj_Estudiantes.TablaEstudiantes.Rows

            input_nombre_est2.Value = fila("Nombre")
            input_apellidos2.Value = fila("Apellidos")
            input_fecha2.Value = fila("Fecha_Nacimiento")
            input_direccion2.Value = fila("Direccion")
            input_telefono2.Value = fila("Telefono")
            input_correo2.Value = fila("Correo")

            If fila("Beca") = 0 Then
                beca_no2.Checked = True
                beca_si2.Checked = False
                select_beca2.Disabled = True
            Else
                beca_si2.Checked = True
                beca_no2.Checked = False
                select_beca2.Disabled = False
                If fila("Beca") = 25 Then
                    select_beca2.SelectedIndex = 0
                ElseIf fila("Beca") = 50 Then
                    select_beca2.SelectedIndex = 1
                ElseIf fila("Beca") = 75 Then
                    select_beca2.SelectedIndex = 2
                End If
            End If
            Dim i As Integer = 0
            For Each item As ListItem In select_carrera2.Items
                If item.Value = fila("ID_Carrera") Then
                    select_carrera2.SelectedIndex = i
                    Exit For
                End If
                i += 1
            Next

        Next
    End Sub
    Protected Sub beca_si_CheckedChanged(sender As Object, e As EventArgs)
        If beca_si.Checked Then
            beca_no.Checked = False
            select_beca.Disabled = False

        End If
    End Sub

    Protected Sub beca_no_CheckedChanged(sender As Object, e As EventArgs)
        If beca_no.Checked Then
            beca_si.Checked = False
            select_beca.Disabled = True
        End If
    End Sub

    Protected Sub beca_no2_CheckedChanged(sender As Object, e As EventArgs)
        If beca_no2.Checked Then
            beca_si2.Checked = False
            select_beca2.Disabled = True
        End If
    End Sub

    Protected Sub beca_si2_CheckedChanged(sender As Object, e As EventArgs)
        If beca_si2.Checked Then
            beca_no2.Checked = False
            select_beca2.Disabled = False
        End If
    End Sub
End Class