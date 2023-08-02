Public Class Formulario_web1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub agrega_curso_Click(sender As Object, e As EventArgs) Handles agrega_curso.Click
        Dim dt As New DataTable()
        dt.Columns.Add("ID Curso", GetType(String))
        dt.Columns.Add("Nombre", GetType(String))
        dt.Columns.Add("Créditos", GetType(String))
        dt.Columns.Add("Nota Minima", GetType(String))
        dt.Columns.Add("Cantidad Maxima", GetType(String))
        dt.Columns.Add("Costos", GetType(String))
        dt.Columns.Add("Grado", GetType(String))
        dt.Columns.Add("Carrera", GetType(String))
        dt.Columns.Add("Estado", GetType(String))
        dt.Rows.Add(input_id_curso.Value, input_nombre.Value, input_creditos.Value, input_nota.Value, input_cant_min.Value, input_cant_max.Value, select_grado.Value, select_carrera.Value, select_estado.Value)
        gv_matricula_cursos.DataSource = dt
        gv_matricula_cursos.DataBind()
    End Sub
End Class