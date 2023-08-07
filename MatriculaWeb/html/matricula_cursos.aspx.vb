Imports Negocios
Public Class Formulario_web1
    Inherits System.Web.UI.Page
    Dim obj_Cursos As New Negocios.ClaseCursos
    Dim obj_Carreras As New Negocios.ClaseCarreras
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'cargar el dgv cuando se levante la pantalla
        cargarInfo()
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

    Protected Sub btn_Borrar_Click(sender As Object, e As EventArgs) Handles btn_Borrar.Click
        obj_Cursos.IdCurso = input_id_curso.Value
        obj_Cursos.borrarCurso()
        cargarInfo()
        limpiar()
    End Sub
    Sub limpiar()
        input_id_curso.Value = ""
        input_nombre.Value = ""
        input_nota.Value = ""
        input_cant_max.Value = ""
        input_cant_min.Value = ""
        input_creditos.Value = ""
        select_carrera.Value = ""
        select_estado.Value = ""
        select_grado.Value = ""
    End Sub

    Protected Sub btn_Modificar_Click(sender As Object, e As EventArgs) Handles btn_Modificar.Click

    End Sub
End Class