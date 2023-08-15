Imports Negocios
Public Class Formulario_web12

    Inherits System.Web.UI.Page
    Dim obj_Carreras As New Negocios.ClaseCarreras
    Dim obj_Estudiantes As New Negocios.ClaseEstudiantes
    Dim obj_matricula As New Negocios.ClaseMatrticula
    Dim obj_curso As New Negocios.ClaseCursos

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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
        End If

    End Sub
    Protected Sub btn_mostrar_Click(sender As Object, e As EventArgs)

        lb_curso_uno.InnerText = ""
        curso_uno.Value = ""
        lb_curso_dos.InnerText = ""
        curso_dos.Value = ""


    End Sub

    Protected Sub btn_total_Click(sender As Object, e As EventArgs)
        Dim minEstudiantes As Integer

        If curso_uno.Checked Then
            obj_curso.IdCurso = curso_uno.Value
            obj_curso.SeleccionarPorIDcurso()
            For Each fila As DataRow In obj_curso.TablaCursos.Rows
                minEstudiantes = fila("Min_Estudiantes")
            Next
        End If
    End Sub

    Protected Sub btn_matricular_Click(sender As Object, e As EventArgs) Handles btn_matricular.Click
        obj_matricula.IdCarrera = select_carrera.Value
        obj_matricula.IdEstudiante = select_estudiante.Value
        obj_matricula.Cuatrimestre = label_cuatrimestre.Value
        obj_matricula.Costo = lb_total.InnerText
        'falta el periodo
        obj_matricula.AgregarMatricula() 'usar el id de la matricula y el id del curso para guardar en cursos por matricula
        obj_matricula.RecibirTablaID()
        If curso_uno.Checked Then
            obj_curso.BuscarIDPorNombre()
            obj_matricula.GuardarCursosporMatricula()
        End If

    End Sub

    'consultar nombre de cursos para los checkbox
    'arreglar total
    'revisar matricula
    'revisar modificar
End Class