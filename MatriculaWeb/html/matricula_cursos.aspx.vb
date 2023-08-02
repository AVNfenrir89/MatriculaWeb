Imports Negocios
Public Class Formulario_web1
    Inherits System.Web.UI.Page
    Dim obj_Cursos As New Negocios.ClaseCursos
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
End Class