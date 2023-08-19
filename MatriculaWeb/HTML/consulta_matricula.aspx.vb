Imports Negocios
Public Class Formulario_web17
    Inherits System.Web.UI.Page
    Dim obj_Matricula As New ClaseMatrticula
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not User.Identity.IsAuthenticated Then
            Response.Redirect("login.aspx") ' Redirigir al inicio de sesión si no está autenticado
        End If

        cargarInfo()

    End Sub
    Sub cargarInfo()
        Try


            obj_Matricula.MostrarMatriculas()
            obj_Matricula.TablaMatricula.Columns("ID_Matricula").ColumnName = "ID Matrícula"
            obj_Matricula.TablaMatricula.Columns("ID_Estudiante").ColumnName = "ID Estudiante"
            obj_Matricula.TablaMatricula.Columns("ID_Carrera").ColumnName = "ID Carrera"
            gv_matricula.DataSource = obj_Matricula.TablaMatricula
            gv_matricula.DataBind()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

End Class