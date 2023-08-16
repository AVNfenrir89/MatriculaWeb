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

        End Try


    End Sub
    'Protected Sub btn_mostrar_Click(sender As Object, e As EventArgs)
    '    Try
    '        Dim i As Integer = 0
    '        obj_matricula.IdCarrera = select_carrera.SelectedValue
    '        obj_matricula.Cuatrimestre = select_cuatrimestre.SelectedValue
    '        obj_matricula.SelecionarCursosPorCarreraCuatrimestre()
    '        For Each fila As DataRow In obj_matricula.Tabla_Cursos.Rows
    '            If i = 0 Then
    '                lb_curso_uno.InnerText = fila("Nombre")
    '                curso_uno.Value = fila("ID_Cursos")
    '            ElseIf i = 1 Then
    '                lb_curso_dos.InnerText = fila("Nombre")
    '                curso_dos.Value = fila("ID_Cursos")
    '            ElseIf i = 2 Then
    '                lb_curso_tres.InnerText = fila("Nombre")
    '                curso_tres.Value = fila("ID_Cursos")
    '            End If
    '            i += 1

    '        Next

    '    Catch ex As Exception

    '    End Try



    'End Sub

    Protected Sub btn_total_Click(sender As Object, e As EventArgs)
        Try
            ' Dim minEstudiantes As Integer
            Dim total As Integer = 0
            If curso_uno.Checked Then
                obj_curso.IdCurso = curso_uno.Value
                obj_curso.SeleccionarPorIDcurso()
                For Each fila As DataRow In obj_curso.TablaCursos.Rows
                    ' minEstudiantes = fila("Min_Estudiantes")
                    'total = total + obj_curso.Costo_curso(fila(3)) 'parametro de creditos
                    total = total + fila(9)
                Next
            End If
            If curso_dos.Checked Then
                obj_curso.IdCurso = curso_uno.Value
                obj_curso.SeleccionarPorIDcurso()
                For Each fila As DataRow In obj_curso.TablaCursos.Rows
                    total = total + fila(9)
                Next
            End If
            If curso_tres.Checked Then
                obj_curso.IdCurso = curso_uno.Value
                obj_curso.SeleccionarPorIDcurso()
                For Each fila As DataRow In obj_curso.TablaCursos.Rows
                    total = total + fila(9)
                Next
            End If

            lb_total.InnerText = total
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub btn_matricular_Click(sender As Object, e As EventArgs) Handles btn_matricular.Click
        Try
            obj_matricula.IdCarrera = select_carrera.SelectedValue
            obj_matricula.IdEstudiante = select_estudiante.Value
            obj_matricula.Cuatrimestre = select_cuatrimestre.SelectedValue
            obj_matricula.Costo = lb_total.InnerText
            'falta el periodo
            obj_matricula.AgregarMatricula() 'usar el id de la matricula y el id del curso para guardar en cursos por matricula
            obj_matricula.RecibirTablaID()
            Dim idMatricula As String = obj_matricula.TablaMatricula.Rows(0)(0) 'traer id de matricula. 
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
            Throw ex
        End Try

    End Sub
    Sub CargarCursos()
        Try
            obj_curso.LeeDatosCursos()
            Dim listaIDCurso As New List(Of String)
            Dim listaNombre As New List(Of String)
            For Each fila As DataRow In obj_curso.TablaCursos.Rows
                If fila(1).Equals(select_carrera.SelectedValue) And fila(10).trim.Equals(select_cuatrimestre.SelectedValue) Then
                    listaIDCurso.Add(fila(0))
                    listaNombre.Add(fila(2))
                End If
            Next
            lb_curso_uno.InnerText = listaNombre(0) 'input y label son dos elementos diferentes
            lb_curso_dos.InnerText = listaNombre(1)
            lb_curso_tres.InnerText = listaNombre(2)
            curso_uno.Value = listaIDCurso(0)
            curso_dos.Value = listaIDCurso(1)
            curso_tres.Value = listaIDCurso(2)
        Catch ex As Exception
            Throw ex
        End Try


    End Sub

    Protected Sub select_carrera_SelectedIndexChanged(sender As Object, e As EventArgs) Handles select_carrera.SelectedIndexChanged
        CargarCursos()
    End Sub

    Protected Sub label_cuatrimestre_SelectedIndexChanged(sender As Object, e As EventArgs) Handles select_cuatrimestre.SelectedIndexChanged
        CargarCursos()
    End Sub
End Class