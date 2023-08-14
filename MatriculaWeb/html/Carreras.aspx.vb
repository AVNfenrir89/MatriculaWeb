Imports Negocios
Public Class Formulario_web15
    Inherits System.Web.UI.Page
    Dim obj_Carreras As New Negocios.ClaseCarreras
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not User.Identity.IsAuthenticated Then
            Response.Redirect("login.aspx") ' Redirigir al inicio de sesión si no está autenticado
        Else
            cargarInfo()
        End If
    End Sub

    Protected Sub agregar_Click(sender As Object, e As EventArgs) Handles agregar.Click
        Try
            obj_Carreras.IdCarrera = input_id_carrera.Value
            obj_Carreras.Nombre = input_nombre_carrera.Value
            obj_Carreras.Estado = select_estado.Value
            obj_Carreras.Grados = select_grado.Value
            obj_Carreras.AgregarDatosCarrera()
            cargarInfo()
            limpiar()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Sub cargarInfo()
        Try
            obj_Carreras.LeeDatosCarrera()
            gv_carreras.DataSource = obj_Carreras.TablaCarreras
            gv_carreras.DataBind()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub limpiar()
        input_id_carrera.Value = ""
        input_nombre_carrera.Value = ""
        select_estado.Value = ""
        select_grado.Value = ""
    End Sub
End Class