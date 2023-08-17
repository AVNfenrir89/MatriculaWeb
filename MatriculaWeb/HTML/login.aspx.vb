Public Class login
    Inherits System.Web.UI.Page
    Dim obj_Funcionario As New Negocios.ClaseFuncionarios

    Sub Mensaje(mensaje)
        Dim script As String = "alert('" + mensaje + "');"
        ClientScript.RegisterStartupScript(Me.GetType(), "MensajeEmergente", script, True)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_IniciarSesion_Click(sender As Object, e As EventArgs)

        Try
            obj_Funcionario.Usuario = input_usuario.Value
            obj_Funcionario.LoginFuncionarios()
            obj_Funcionario.Usuario = input_usuario.Value
            obj_Funcionario.Clave = input_contrasena.Value
            obj_Funcionario.ValidaDatosFuncionario()


            If obj_Funcionario.Estado.ToLower = "activo" Then
                FormsAuthentication.RedirectFromLoginPage(obj_Funcionario.Usuario, False)
                Response.Redirect("Carreras.aspx")
                Return
            End If


        Catch ex As Exception
            Mensaje("Error. " & ex.Message)
        End Try


    End Sub


End Class