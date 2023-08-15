Imports Negocios
Public Class Formulario_web1
    Inherits System.Web.UI.Page
    Dim obj_Cursos As New Negocios.ClaseCursos
    Dim obj_Carreras As New Negocios.ClaseCarreras
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not User.Identity.IsAuthenticated Then
        '    Response.Redirect("login.aspx") ' Redirigir al inicio de sesión si no está autenticado
        'End If
        If Not IsPostBack Then
            'cargar el dgv cuando se levante la pantalla
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

    Protected Sub agrega_curso_Click(sender As Object, e As EventArgs) Handles agrega_curso.Click
        'cargar los valores respectivos
        Try
            obj_Cursos.IdCurso = input_id_curso.Value
            obj_Cursos.IdCarrera = select_carrera.Value
            obj_Cursos.Nombre = input_nombre.Value
            obj_Cursos.Creditos = input_creditos.Value
            obj_Cursos.NotaMinima = input_nota.Value
            obj_Cursos.CantMax = input_cant_max.Value
            obj_Cursos.CantMin = input_cant_min.Value
            obj_Cursos.Costo = obj_Cursos.Costo_curso(input_creditos.Value)
            obj_Cursos.Grado = select_grado.Value
            obj_Cursos.Estado = select_estado.Value
            obj_Cursos.Cuatri = label_cuatrimestre.Value
            'agregar y cargar en tiempo real
            obj_Cursos.AgregarDatosCursos()
            cargarInfo()
            limpiar()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub cargarInfo()
        Try
            obj_Cursos.LeeDatosCursos()
            gv_matricula_cursos.DataSource = obj_Cursos.TablaCursos
            gv_matricula_cursos.DataBind()
        Catch ex As Exception
            Throw ex
        End Try


    End Sub


    Sub limpiar()
        input_id_curso.Value = ""
        input_nombre.Value = ""
        select_carrera.Value = ""
        select_estado.Value = ""
        select_grado.Value = ""
    End Sub

    Protected Sub btn_Modificar_Click(sender As Object, e As EventArgs) Handles btn_Modificar.Click
        Try
            obj_Cursos.IdCurso = input_buscar.Value
            obj_Cursos.IdCarrera = select_carrera2.Value
            obj_Cursos.Nombre = input_nombre2.Value
            obj_Cursos.Creditos = input_creditos2.Value
            obj_Cursos.NotaMinima = input_nota2.Value
            obj_Cursos.CantMax = input_cant_max2.Value
            obj_Cursos.CantMin = input_cant_min2.Value
            obj_Cursos.Costo = obj_Cursos.Costo_curso(input_creditos2.Value)
            obj_Cursos.Grado = select_grado2.Value
            obj_Cursos.Estado = select_estado2.Value
            obj_Cursos.Cuatri = select_cuatrimestre_2.Value
            obj_Cursos.modificarCurso()
            cargarInfo()
            limpiar()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub btn_buscar_Click(sender As Object, e As EventArgs)
        obj_Cursos.IdCurso = input_buscar.Value
        obj_Cursos.SeleccionarPorIDcurso()
        For Each fila As DataRow In obj_Cursos.TablaCursos.Rows
            input_nombre2.Value = fila("Nombre")
            input_creditos2.Value = fila("Creditos")
            input_nota2.Value = fila("Nota_Min")


            If fila("Grado") = "bachillerato" Then
                select_grado2.SelectedIndex = 0
            Else
                select_grado2.SelectedIndex = 1
            End If
            If fila("Estado") = "activo" Then
                select_estado2.SelectedIndex = 0
            Else
                select_estado2.SelectedIndex = 1
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
    End Sub
End Class