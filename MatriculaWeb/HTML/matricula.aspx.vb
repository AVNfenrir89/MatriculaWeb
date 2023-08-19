Imports System.Security.Cryptography
Imports Negocios
Public Class Formulario_web12

    Inherits System.Web.UI.Page
    Dim obj_Carreras As New Negocios.ClaseCarreras
    Dim obj_Estudiantes As New Negocios.ClaseEstudiantes
    Dim obj_matricula As New Negocios.ClaseMatrticula
    Dim obj_curso As New Negocios.ClaseCursos

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'If Not User.Identity.IsAuthenticated Then
            '    Response.Redirect("login.aspx") ' Redirigir al inicio de sesión si no está autenticado
            'End If
            If Not IsPostBack Then

                Dim nombre As String
                Dim id As String
                obj_Carreras.LeeDatosCarrera()
                obj_Estudiantes.LeeDatosEstudiantes()
                'se itera cada fila de la tabla carreras y se agrega items al select_carrera
                For Each fila As DataRow In obj_Carreras.TablaCarreras.Rows
                    nombre = fila("Nombre")
                    id = fila("ID_Carrera")
                    Dim opcion As New ListItem(nombre, id)
                    select_carrera.Items.Add(opcion)
                Next
                'se itera cada fila de la tabla carreras y se agrega items al select_estudiante
                For Each fila As DataRow In obj_Estudiantes.TablaEstudiantes.Rows
                    nombre = fila("Nombre")
                    id = fila("ID_Estudiantes")
                    Dim opcion As New ListItem(id, id)
                    select_estudiante.Items.Add(opcion)
                Next
                CargarCursos()
            End If



        Catch ex As Exception
            Throw ex
        End Try


    End Sub


    Protected Sub btn_total_Click(sender As Object, e As EventArgs)
        Try
            ' Dim minEstudiantes As Integer
            ' minEstudiantes = fila("Min_Estudiantes")
            'total = total + obj_curso.Costo_curso(fila(3)) 'parametro de creditos
            Dim total As Integer = 0

            'costo del curso uno
            If curso_uno.Checked Then
                obj_curso.IdCurso = curso_uno.Value
                obj_curso.SeleccionarPorIDcurso()
                For Each fila As DataRow In obj_curso.TablaCursos.Rows
                    total = total + fila(9)
                Next
            End If

            'costo del curso dos
            If curso_dos.Checked Then
                obj_curso.IdCurso = curso_uno.Value
                obj_curso.SeleccionarPorIDcurso()
                For Each fila As DataRow In obj_curso.TablaCursos.Rows
                    total = total + fila(9)
                Next
            End If

            'costo del curso tres
            If curso_tres.Checked Then
                obj_curso.IdCurso = curso_uno.Value
                obj_curso.SeleccionarPorIDcurso()
                For Each fila As DataRow In obj_curso.TablaCursos.Rows
                    total = total + fila(9)
                Next
            End If

            'Verificación si elestudiante tiene beca
            obj_Estudiantes.IdEstudiantes = select_estudiante.Value
            obj_Estudiantes.SelecionarBeca()
            Dim beca As Integer
            Dim mensajeBeca As String = "Total a pagar: "
            For Each fila As DataRow In obj_Estudiantes.TablaEstudiantes.Rows
                beca = fila("Beca")
                If beca = 25 Then
                    total = (total / 100) * beca
                    mensajeBeca = String.Empty
                    mensajeBeca = "Se aplica al estudiante beca del 25 %. Total con beca aplicada: "
                ElseIf beca = 50 Then
                    total = (total / 100) * beca
                    mensajeBeca = String.Empty
                    mensajeBeca = "Se aplica al estudiante beca del 50 %. Total con beca aplicada: "
                ElseIf beca = 75 Then
                    total = (total / 100) * beca
                    mensajeBeca = String.Empty
                    mensajeBeca = "Se aplica al estudiante beca del 75 %. Total con beca aplicada: "
                End If
            Next
            lb_beca.InnerText = mensajeBeca
            lb_total.InnerText = total

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub btn_matricular_Click(sender As Object, e As EventArgs) Handles btn_matricular.Click
        Try

            If Not curso_uno.Checked And Not curso_dos.Checked And Not curso_tres.Checked Then
                Throw New System.Exception("No se puede matricular sin haber seleccionado al menos un curso")
            ElseIf lb_total.InnerText = String.Empty Or Not IsNumeric(lb_total.InnerText) Then
                Throw New System.Exception("No se puede matricular sin haber hecho antes click en el botón total")
            End If

            obj_matricula.IdCarrera = select_carrera.SelectedValue
            obj_matricula.IdEstudiante = select_estudiante.Value
            obj_matricula.Cuatrimestre = select_cuatrimestre.SelectedValue
            obj_matricula.Costo = lb_total.InnerText
            obj_matricula.SeleccionaIDMatricula()

            Dim CantMaxCursoUno As Integer = 1
            Dim CantMaxCursoDos As Integer = 1
            Dim CantMaxCursoTres As Integer = 1


            For Each fila As DataRow In obj_matricula.TablaMatricula.Rows
                'verifica la cantidad máxima del curso seleccionado
                If curso_uno.Checked Then
                    obj_curso.IdCurso = curso_uno.Value
                    obj_curso.SelecionarCantMax()
                    obj_curso.CantMax = obj_curso.TablaCursos(0)(0)
                    obj_curso.consultarCursosPormatricula(fila("ID_Matricula"))
                    If obj_curso.TablaCursosPorMatricula(0)(0) = 1 And CantMaxCursoUno < obj_curso.CantMax Then
                        CantMaxCursoUno += 1
                    Else
                        Throw New System.Exception("Se alcanzó el número máximo de estudiantes en " & lb_curso_uno.InnerText)
                    End If
                End If

                If curso_dos.Checked Then
                    obj_curso.IdCurso = curso_dos.Value
                    obj_curso.SelecionarCantMax()
                    obj_curso.CantMax = obj_curso.TablaCursos(0)(0)
                    obj_curso.consultarCursosPormatricula(fila("ID_Matricula"))
                    If obj_curso.TablaCursosPorMatricula(0)(0) And CantMaxCursoDos < obj_curso.CantMax Then
                        CantMaxCursoDos += 1
                    Else
                        Throw New System.Exception("Se alcanzó el número máximo de estudiantes en " & lb_curso_dos.InnerText)
                    End If
                End If

                If curso_tres.Checked Then
                    obj_curso.IdCurso = curso_tres.Value
                    obj_curso.SelecionarCantMax()
                    obj_curso.CantMax = obj_curso.TablaCursos(0)(0)
                    obj_curso.consultarCursosPormatricula(fila("ID_Matricula"))
                    If obj_curso.TablaCursosPorMatricula(0)(0) And CantMaxCursoTres < obj_curso.CantMax Then
                        CantMaxCursoTres += 1
                    Else
                        Throw New System.Exception("Se alcanzó el número máximo de estudiantes en " & lb_curso_tres.InnerText)
                    End If
                End If
            Next

            'falta el periodo
            obj_matricula.AgregarMatricula() 'usar el id de la matricula y el id del curso para guardar en cursos por matricula
            obj_matricula.RecibirTablaID()
            Dim idMatricula As String = obj_matricula.TablaMatricula.Rows(0)(1) 'traer id de matricula. 
            obj_matricula.IdMatricula = idMatricula
            If curso_uno.Checked Then
                obj_curso.IdCurso = curso_uno.Value
                ' obj_curso.SeleccionarPorIDcurso()
                obj_matricula.IdCursos = curso_uno.Value
                obj_matricula.GuardarCursosporMatricula()
            End If

            If curso_dos.Checked Then
                obj_curso.IdCurso = curso_dos.Value
                'obj_curso.SeleccionarPorIDcurso()
                obj_matricula.IdCursos = curso_dos.Value
                obj_matricula.GuardarCursosporMatricula()
            End If

            If curso_tres.Checked Then
                obj_curso.IdCurso = curso_tres.Value
                'obj_curso.SeleccionarPorIDcurso()
                obj_matricula.IdCursos = curso_tres.Value
                obj_matricula.GuardarCursosporMatricula()
            End If

        Catch ex As Exception
            Mensaje("Error. " & ex.Message)
        End Try

    End Sub
    Sub CargarCursos()
        Try
            btn_total.Visible = True
            btn_matricular.Visible = True
            obj_curso.LeeDatosCursos()
            Dim listaIDCurso As New List(Of String)
            Dim listaNombre As New List(Of String)
            For Each fila As DataRow In obj_curso.TablaCursos.Rows
                If fila(1).Equals(select_carrera.SelectedValue) And fila(10).trim.Equals(select_cuatrimestre.SelectedValue) Then
                    listaIDCurso.Add(fila(0))
                    listaNombre.Add(fila(2))
                End If
            Next
            'valida si hay cursos en el cuatrimestre selecionado
            If listaIDCurso.Count = 0 Then
                lb_curso_uno.InnerText = String.Empty
                lb_curso_dos.InnerText = String.Empty
                lb_curso_tres.InnerText = String.Empty
                curso_uno.Value = String.Empty
                curso_dos.Value = String.Empty
                curso_tres.Value = String.Empty
                btn_total.Visible = False
                btn_matricular.Visible = False
                Throw New System.Exception("No hay cursos registrados en el cuatrimestre selecionado")

            End If

            lb_curso_uno.InnerText = listaNombre(0) 'input y label son dos elementos diferentes
            lb_curso_dos.InnerText = listaNombre(1)
            lb_curso_tres.InnerText = listaNombre(2)
            curso_uno.Value = listaIDCurso(0)
            curso_dos.Value = listaIDCurso(1)
            curso_tres.Value = listaIDCurso(2)
        Catch ex As Exception
            Mensaje("Error. " & ex.Message)

        End Try


    End Sub

    Protected Sub select_carrera_SelectedIndexChanged(sender As Object, e As EventArgs) Handles select_carrera.SelectedIndexChanged
        CargarCursos()
    End Sub

    Protected Sub label_cuatrimestre_SelectedIndexChanged(sender As Object, e As EventArgs) Handles select_cuatrimestre.SelectedIndexChanged
        CargarCursos()
    End Sub
    Sub cargarInfo()
        Try
            obj_matricula.leeTablaMatricula()
            gv_matricular.DataSource = obj_matricula.TablaMatricula
            gv_matricular.DataBind()
        Catch ex As Exception
            Mensaje("Error. " & ex.Message)
        End Try

    End Sub

    Protected Sub btn_buscar_Click(sender As Object, e As EventArgs) Handles btn_buscar.Click
        Try

            If Not IsNumeric(input_buscar) Or input_buscar.ToString.Length = 0 Then
                Throw New System.Exception("El ID de buscar no puedeestar en letras o quedar vacio")
            End If
            obj_matricula.IdMatricula = input_buscar.Value


        Catch ex As Exception
            Mensaje("Error. " & ex.Message)
        End Try

    End Sub

    Sub Mensaje(mensaje)

        Dim script As String = "alert('" + mensaje + "');"
        ClientScript.RegisterStartupScript(Me.GetType(), "MensajeEmergente", script, True)


    End Sub

End Class