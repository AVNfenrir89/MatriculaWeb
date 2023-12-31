﻿Imports Negocios
Public Class Formulario_web1
    Inherits System.Web.UI.Page
    Dim obj_Cursos As New Negocios.ClaseCursos
    Dim obj_Carreras As New Negocios.ClaseCarreras


    Sub Mensaje(mensaje)
        Dim script As String = "alert('" + mensaje + "');"
        ClientScript.RegisterStartupScript(Me.GetType(), "MensajeEmergente", script, True)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not User.Identity.IsAuthenticated Then
            Response.Redirect("login.aspx") ' Redirigir al inicio de sesión si no está autenticado
        End If
        If Not IsPostBack Then
            'cargar el dgv cuando se levante la pantalla
            'cargarInfo()
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

    Protected Sub agrega_curso_Click(sender As Object, e As EventArgs) Handles agrega_curso.Click
        'cargar los valores respectivos
        Try

            obj_Cursos.IdCurso = input_id_curso.Value
            obj_Cursos.IdCarrera = select_carrera.Value
            obj_Cursos.Nombre = input_nombre.Value
            obj_Cursos.Validaciones()
            If Not IsNumeric(input_creditos.Value) Or input_creditos.Value.ToString.Length = 0 Then
                Throw New System.Exception("El valor de créditos no debe estar en letras o quedar vacio")
            End If
            obj_Cursos.Creditos = input_creditos.Value
            obj_Cursos.Costo = obj_Cursos.Costo_curso(input_creditos.Value)

            If Not IsNumeric(input_nota.Value) Or input_nota.Value.ToString.Length = 0 Then
                Throw New System.Exception("El valor de nota mínima no debe estar en letras o quedar vacio")
            End If
            obj_Cursos.NotaMinima = input_nota.Value

            If Not IsNumeric(input_cant_max.Value) Or input_cant_max.Value.ToString.Length = 0 Then
                Throw New System.Exception("El valor de cantidad máxima de estudiantes no debe estar en letras o quedar vacio")
            End If
            obj_Cursos.CantMax = input_cant_max.Value

            If Not IsNumeric(input_cant_min.Value) Or input_cant_min.Value.ToString.Length = 0 Then
                Throw New System.Exception("El valor de cantidad mínima de estudiantes no debe estar en letras o quedar vacio")
            End If
            obj_Cursos.CantMin = input_cant_min.Value


            obj_Cursos.Grado = select_grado.Value
            obj_Cursos.Estado = select_estado.Value
            obj_Cursos.Cuatri = select_cuatrimestre.Value
            'agregar y cargar en tiempo real
            obj_Cursos.AgregarDatosCursos()
            'cargarInfo()
            limpiar()
        Catch ex As Exception

            Mensaje("Error. " & ex.Message)

        End Try
    End Sub



    Sub limpiar()
        input_id_curso.Value = ""
        input_nombre.Value = ""
        input_creditos.Value = ""
        input_nota.Value = ""
        input_cant_min.Value = ""
        input_cant_max.Value = ""
    End Sub

    Sub LimpiarModificarBorar()
        input_buscar.Value = ""
        input_nombre2.Value = ""
        input_creditos2.Value = ""
        input_nota2.Value = ""
        input_cant_max2.Value = ""
        input_cant_min2.Value = ""
        input_creditos2.Value = ""
    End Sub
    Protected Sub btn_Modificar_Click(sender As Object, e As EventArgs) Handles btn_Modificar.Click
        Try
            obj_Cursos.IdCurso = input_buscar.Value
            obj_Cursos.IdCarrera = select_carrera2.Value
            obj_Cursos.Nombre = input_nombre2.Value
            'obj_Carreras.Validaciones()

            If Not IsNumeric(input_creditos2.Value) Or input_creditos2.Value.ToString.Length = 0 Then
                Throw New System.Exception("El valor de créditos no debe estar en letras o quedar vacio")
            End If
            obj_Cursos.Creditos = input_creditos2.Value
            obj_Cursos.Costo = obj_Cursos.Costo_curso(input_creditos2.Value)

            If Not IsNumeric(input_nota2.Value) Or input_nota2.Value.ToString.Length = 0 Then
                Throw New System.Exception("El valor de nota mínima no debe estar en letras o quedar vacio")
            End If
            obj_Cursos.NotaMinima = input_nota2.Value

            If Not IsNumeric(input_cant_max2.Value) Or input_cant_max2.Value.ToString.Length = 0 Then
                Throw New System.Exception("El valor de cantida máxima de estudiantes  no debe estar en letras o quedar vacio")
            End If
            obj_Cursos.CantMax = input_cant_max2.Value

            If Not IsNumeric(input_cant_min2.Value) Or input_cant_min2.Value.ToString.Length = 0 Then
                Throw New System.Exception("El valor de cantida mínima de estudiantes  no debe estar en letras o quedar vacio")
            End If
            obj_Cursos.CantMin = input_cant_min2.Value

            obj_Cursos.Grado = select_grado2.Value
            obj_Cursos.Estado = select_estado2.Value
            obj_Cursos.Cuatri = select_cuatrimestre_2.Value
            obj_Cursos.modificarCurso()
            'cargarInfo()
            LimpiarModificarBorar()

        Catch ex As Exception
            Mensaje("Error. " & ex.Message)
        End Try
    End Sub

    Protected Sub btn_buscar_Click(sender As Object, e As EventArgs)
        Try
            obj_Cursos.IdCurso = input_buscar.Value
            obj_Cursos.SeleccionarPorIDcurso()
            For Each fila As DataRow In obj_Cursos.TablaCursos.Rows
                input_nombre2.Value = fila("Nombre")
                input_creditos2.Value = fila("Creditos")
                input_nota2.Value = fila("Nota_Min")
                input_cant_min2.Value = fila("Min_Estudiantes")
                input_cant_max2.Value = fila("Max_Estudiantes")

                If fila("Grado") = "bachillerato" Then
                    select_grado2.SelectedIndex = 0
                Else
                    select_grado2.SelectedIndex = 1
                End If
                If fila("Estado") = "activo" Then
                    select_estado2.SelectedIndex = 1
                Else
                    select_estado2.SelectedIndex = 0
                End If

                Dim i As Integer = 0
                For Each item As ListItem In select_carrera2.Items
                    If item.Value = fila("ID_Carrera") Then
                        select_carrera2.SelectedIndex = i
                        Exit For
                    End If
                    i += 1
                Next
                i = 0
                For Each item As ListItem In select_cuatrimestre_2.Items
                    If item.Value = fila("Cuatrimestre") Then
                        select_cuatrimestre_2.SelectedIndex = i
                        Exit For
                    End If
                    i += 1
                Next
            Next
        Catch ex As Exception
            Mensaje(ex.Message)
        End Try

    End Sub
End Class