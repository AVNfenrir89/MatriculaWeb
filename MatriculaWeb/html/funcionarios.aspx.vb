Public Class Formulario_web13
    Inherits System.Web.UI.Page
    Dim obj_Funcionarios As New Negocios.ClaseFuncionarios
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not User.Identity.IsAuthenticated Then
        '    Response.Redirect("login.aspx") ' Redirigir al inicio de sesión si no está autenticado
        'End If
        cargarInfo()
    End Sub

    Protected Sub btn_agregar_Click(sender As Object, e As EventArgs) Handles btn_agregar.Click
        Try
            obj_Funcionarios.Identificacion = id_funcionario.Value
            obj_Funcionarios.Nombre = nombre_funcionario.Value
            obj_Funcionarios.pApellido = pApellido_funcionario.Value
            obj_Funcionarios.sApellido = sApellido_funcionario.Value
            obj_Funcionarios.Correo = correo_funcionario.Value
            obj_Funcionarios.Usuario = usuario_funcionario.Value
            obj_Funcionarios.Clave = pass_funcionario.Value
            obj_Funcionarios.Estado = estado_funcionario.Value
            obj_Funcionarios.AgregarFuncionarios()
            cargarInfo()
            limpiar()


        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Sub cargarInfo()
        Try
            obj_Funcionarios.leerTablaFuncionarios()
            gv_funcionario.DataSource = obj_Funcionarios.TablaFuncionarios
            gv_funcionario.DataBind()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub limpiar()
        id_funcionario.Value = ""
        nombre_funcionario.Value = ""
        pApellido_funcionario.Value = ""
        sApellido_funcionario.Value = ""
        correo_funcionario.Value = ""
        usuario_funcionario.Value = ""
        pass_funcionario.Value = ""
        estado_funcionario.Value = ""
    End Sub
End Class