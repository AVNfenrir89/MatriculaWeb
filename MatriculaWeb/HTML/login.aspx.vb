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
            obj_Funcionario.Identificacion = input_idFuncioanrio.Value
            obj_Funcionario.LoginFuncionarios()
            obj_Funcionario.Nombre = input_nombre.Value
            obj_Funcionario.pApellido = input_pApellido.Value
            obj_Funcionario.sApellido = input_sApellido.Value
            obj_Funcionario.Correo = input_correo.Value
            obj_Funcionario.Usuario = input_usuario.Value
            obj_Funcionario.Clave = input_contrasena.Value
            obj_Funcionario.ValidaDatosFuncionario()
            If obj_Funcionario.Estado.ToLower = Nothing Then
                Mensaje("Error!! El usuario no exite o esta inactivo")
                Return
            ElseIf obj_Funcionario.Estado.ToLower = "activo" Then
                Response.Redirect("matricula_cursos.aspx")
            Else
                Mensaje(obj_Funcionario.Mensaje)
            End If


        Catch ex As Exception
            Mensaje("Error")
        End Try


    End Sub
End Class