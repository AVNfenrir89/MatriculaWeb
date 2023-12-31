﻿Imports Negocios
Public Class Formulario_web11
    Inherits System.Web.UI.Page
    Dim obj_Estudiantes As New ClaseEstudiantes
    Dim obj_Carreras As New Negocios.ClaseCarreras
    Shared valor As Boolean = True
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not User.Identity.IsAuthenticated Then
            Response.Redirect("login.aspx") ' Redirigir al inicio de sesión si no está autenticado
        End If


        If Not IsPostBack Then
            beca_no.Checked = True
            select_beca.Disabled = True
            cargarInfo()

            Dim nombre_carrera As String
            Dim idCarrera As String
            obj_Carreras.LeeDatosCarrera()


            'se itera cada fila de la tabla carreras y se agrega items al select_carrera

            For Each fila As DataRow In obj_Carreras.TablaCarreras.Rows
                nombre_carrera = fila("nombre")
                idCarrera = fila("ID_Carrera")
                Dim opcion As New ListItem(nombre_carrera, idCarrera)
                select_carrera.Items.Add(opcion)
                select_carrera2.Items.Add(opcion)
            Next
        End If
    End Sub

    Protected Sub btn_Agregar_estudiante_Click(sender As Object, e As EventArgs) Handles btn_Agregar_estudiante.Click
        Try

            If Not IsNumeric(input_id_estudiante.Value) Or input_id_estudiante.Value.ToString.Length = 0 Then
                Throw New System.Exception("EL ID no pude estar en letras o quedar vacio")
            ElseIf input_id_estudiante.Value.ToString.Length <= 8 Then
                Throw New System.Exception("EL ID tiene que ser de 9 dígitos")
            End If
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

            If Not IsDate(input_fecha.Value) Then
                Throw New System.Exception("La fecha ingresada es incorrecto")
            End If
            obj_Estudiantes.FechaNacimiento = input_fecha.Value
            If obj_Estudiantes.ValidaCorreo(input_correo.Value) Then
                obj_Estudiantes.Correo = input_correo.Value
            Else
                Throw New System.Exception("El correo ingresado es incorrecto")
            End If
            obj_Estudiantes.Direccion = input_direccion.Value
            obj_Estudiantes.validaciones()
            obj_Estudiantes.AgregarDatosEstudiantes()
            cargarInfo()
            limpiar_Agregar()
        Catch ex As Exception
            Mensaje("Error. " & ex.Message)
        End Try
    End Sub
    Sub cargarInfo()
        Try
            obj_Estudiantes.LeeDatosEstudiantes()
            gv_matricula_estudiantes.DataSource = obj_Estudiantes.TablaEstudiantes
            obj_Estudiantes.TablaEstudiantes.Columns("ID_Estudiantes").ColumnName = "ID Estudiante"
            obj_Estudiantes.TablaEstudiantes.Columns("ID_Carrera").ColumnName = "ID Carrera"
            obj_Estudiantes.TablaEstudiantes.Columns("Fecha_Nacimiento").ColumnName = "Fecha de Nacimiento"
            obj_Estudiantes.TablaEstudiantes.Columns("Telefono").ColumnName = "Teléfono"
            obj_Estudiantes.TablaEstudiantes.Columns("Direccion").ColumnName = "Dirección"
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
            obj_Estudiantes.Direccion = input_direccion2.Value
            obj_Estudiantes.validaciones()
            If beca_no2.Checked Then
                obj_Estudiantes.Beca = 0
            Else
                obj_Estudiantes.Beca = select_beca2.Value
            End If
            'obj_Estudiantes.Beca = select_beca.Value
            If Not IsDate(input_fecha2.Value) Then
                Throw New System.Exception("La fecha ingresada es incorrecto")
            End If
            obj_Estudiantes.FechaNacimiento = input_fecha2.Value

            If obj_Estudiantes.ValidaCorreo(input_correo2.Value) Then
                obj_Estudiantes.Correo = input_correo2.Value
            Else
                Throw New System.Exception("El correo ingresado es incorrecto")
            End If
            obj_Estudiantes.ModificarEstudiante()
            cargarInfo()
            limpiar_Modificar_Borrar()
        Catch ex As Exception
            Mensaje("Error. " & ex.Message)
        End Try
    End Sub

    Protected Sub btn_buscar_Click(sender As Object, e As EventArgs)
        Try
            obj_Estudiantes.IdEstudiantes = input_buscar.Value
            obj_Estudiantes.SelecionarEstudiante()
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

        Catch ex As Exception
            Mensaje("Error. " & ex.Message)
        End Try

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


    Sub Mensaje(mensaje)
        Dim script As String = "alert('" + mensaje + "');"
        ClientScript.RegisterStartupScript(Me.GetType(), "MensajeEmergente", script, True)

    End Sub


End Class