Public Class Formulario_web16
    Inherits System.Web.UI.Page
    Dim obj_Cursos As New Negocios.ClaseCursos
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not User.Identity.IsAuthenticated Then
        '    Response.Redirect("login.aspx") ' Redirigir al inicio de sesión si no está autenticado
        'End If
        cargarInfo()
    End Sub

    Sub cargarInfo()
        Try
            obj_Cursos.LeeDatosCursos()
            obj_Cursos.TablaCursos.Columns("ID_Cursos").ColumnName = "ID Curso"
            obj_Cursos.TablaCursos.Columns("ID_Carrera").ColumnName = "ID Carrera"
            obj_Cursos.TablaCursos.Columns("Nota_Min").ColumnName = "Nota Mínima"
            obj_Cursos.TablaCursos.Columns("Min_Estudiantes").ColumnName = "Cantidad Mínima Estudiantes"
            obj_Cursos.TablaCursos.Columns("Max_Estudiantes").ColumnName = "Cantidad Máxima Estudiantes"
            gv_matricula_cursos.DataSource = obj_Cursos.TablaCursos
            gv_matricula_cursos.DataBind()
        Catch ex As Exception
            Throw ex
        End Try


    End Sub

End Class