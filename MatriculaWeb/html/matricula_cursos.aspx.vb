Imports Negocios
Public Class Formulario_web1
    Inherits System.Web.UI.Page
    Dim obj_Cursos As New Negocios.ClaseCursos
    Dim obj_Carreras As New Negocios.ClaseCarreras
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Carreras As New DataTable
        Dim nombre As New List(Of String)
        Dim id_carrera As New List(Of String)
        Dim nombre_carrera As String
        Dim idCarrera As String
        obj_Carreras.LeeDatosCarrera()
        Carreras = obj_Carreras.TablaCarreras

        For Each fila As DataRow In Carreras.Rows
            nombre_carrera = fila("nombre")
            idCarrera = fila("ID_Carrera")
            nombre.Add(nombre_carrera)
            id_carrera.Add(idCarrera)
        Next

        For i As Integer = 0 To nombre.Count - 1
            Dim opcion As New ListItem(nombre(i), id_carrera(i))
            select_carrera.Items.Add(opcion)
        Next



        'cargar el dgv cuando se levante la pantalla
        cargarInfo()

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
        'limpiar()
    End Sub
    'Sub limpiar()
    '    obj_Cursos.IdCurso = ""
    '    obj_Cursos.IdCarrera = ""
    '    obj_Cursos.Nombre = ""
    '    obj_Cursos.Creditos = ""
    '    obj_Cursos.NotaMinima =
    '    obj_Cursos.CantMax =
    '    obj_Cursos.CantMin =
    '    obj_Cursos.Costo =
    '    obj_Cursos.Grado = ""
    '    obj_Cursos.Estado = ""
    'End Sub
End Class