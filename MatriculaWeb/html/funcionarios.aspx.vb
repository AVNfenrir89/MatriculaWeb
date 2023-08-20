Public Class Formulario_web13
    Inherits System.Web.UI.Page
    Dim obj_Funcionarios As New Negocios.ClaseFuncionarios


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not User.Identity.IsAuthenticated Then
            Response.Redirect("login.aspx") ' Redirigir al inicio de sesión si no está autenticado
        End If
        cargarInfo()
    End Sub

    Protected Sub btn_agregar_Click(sender As Object, e As EventArgs) Handles btn_agregar.Click

        Try

            If obj_Funcionarios.ValidaContasena(pass_funcionario.Value) Then
                If obj_Funcionarios.ValidaCorreo(correo_funcionario.Value) Then

                    obj_Funcionarios.Identificacion = id_funcionario.Value
                    obj_Funcionarios.Nombre = nombre_funcionario.Value
                    obj_Funcionarios.pApellido = pApellido_funcionario.Value
                    obj_Funcionarios.sApellido = sApellido_funcionario.Value
                    obj_Funcionarios.Correo = correo_funcionario.Value
                    obj_Funcionarios.Usuario = usuario_funcionario.Value
                    obj_Funcionarios.Clave = pass_funcionario.Value
                    obj_Funcionarios.validaciones()
                    obj_Funcionarios.Estado = estado_funcionario.Value
                    obj_Funcionarios.AgregarFuncionarios()
                    cargarInfo()
                    limpiar()

                Else
                        Mensaje("El correo es incorrecto")
                End If
            Else
                Mensaje("La contraseña no es válida")
            End If

        Catch ex As Exception
            Mensaje("Error " & ex.Message)
        End Try

    End Sub

    Protected Sub btn_buscar_Click(sender As Object, e As EventArgs)
        Try

            obj_Funcionarios.Identificacion = input_buscar.Value
            If input_buscar.Value = String.Empty Or Not IsNumeric(input_buscar.Value) Then
                Throw New System.Exception("El ID de usuario no puede estar en letras o quedar vacio")
            End If
            obj_Funcionarios.SelecionarFuncionario()
            If obj_Funcionarios.TablaFuncionarios.Rows.Count = 0 Then
                Throw New System.Exception("El ID de usuario no existe")
            End If

            For Each Fila As DataRow In obj_Funcionarios.TablaFuncionarios.Rows
                nombre_funcionario2.Value = Fila("Nombre")
                pApellido_funcionario2.Value = Fila("P_Apellido")
                sApellido_funcionario2.Value = Fila("S_Apellido")
                correo_funcionario2.Value = Fila("Correo")
                usuario_funcionario2.Value = Fila("Usuario")
                pass_funcionario2.Value = Fila("Contrasena")
                If Fila("Estado").trim = "activo" Then
                    estado_funcionario2.SelectedIndex = 0
                Else
                    estado_funcionario2.SelectedIndex = 1
                End If
            Next

        Catch ex As Exception
            Mensaje("Error " & ex.Message)
        End Try
    End Sub

    Protected Sub btn_Modificar_Click(sender As Object, e As EventArgs)
        Try

            If obj_Funcionarios.ValidaContasena(pass_funcionario.Value) Then
                If obj_Funcionarios.ValidaCorreo(correo_funcionario.Value) Then

                    obj_Funcionarios.Identificacion = input_buscar.Value
                    obj_Funcionarios.Nombre = nombre_funcionario2.Value
                    obj_Funcionarios.pApellido = pApellido_funcionario2.Value
                    obj_Funcionarios.sApellido = sApellido_funcionario2.Value
                    obj_Funcionarios.Correo = correo_funcionario2.Value
                    obj_Funcionarios.Usuario = usuario_funcionario2.Value
                    obj_Funcionarios.Clave = pass_funcionario2.Value
                    obj_Funcionarios.validaciones()
                    obj_Funcionarios.Estado = estado_funcionario2.Value
                    obj_Funcionarios.ModificarFuncionario()
                    cargarInfo()
                    limpiarModificarLimpiar()

                Else
                    Mensaje("El correo es incorrecto")
                End If
            Else
                Mensaje("El contraseña no es válida")
            End If

        Catch ex As Exception
            Mensaje("Error. " & ex.Message)
        End Try
    End Sub


    Protected Sub btn_Borrar_Click(sender As Object, e As EventArgs)

        Try

            obj_Funcionarios.Identificacion = input_buscar.Value
            obj_Funcionarios.borrarFuncionario()
            limpiarModificarLimpiar()
        Catch ex As Exception
            Mensaje("Error " & ex.Message)
        End Try
    End Sub


#Region "Métodos"
    Sub cargarInfo()
        Try
            obj_Funcionarios.leerTablaFuncionarios()
            obj_Funcionarios.TablaFuncionarios.Columns("ID_Funcionarios").ColumnName = "ID Funcionario"
            obj_Funcionarios.TablaFuncionarios.Columns("P_Apellido").ColumnName = "Primer Apellido"
            obj_Funcionarios.TablaFuncionarios.Columns("S_Apellido").ColumnName = "Segundo Apellido"
            obj_Funcionarios.TablaFuncionarios.Columns("Contrasena").ColumnName = "Contraseña"
            gv_funcionario.DataSource = obj_Funcionarios.TablaFuncionarios
            gv_funcionario.DataBind()
        Catch ex As Exception
            Mensaje("Error " & ex.Message)
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


    Sub limpiarModificarLimpiar()
        input_buscar.Value = ""
        nombre_funcionario2.Value = ""
        pApellido_funcionario2.Value = ""
        sApellido_funcionario2.Value = ""
        correo_funcionario2.Value = ""
        usuario_funcionario2.Value = ""
        pass_funcionario2.Value = ""
        estado_funcionario2.Value = ""
    End Sub
    Sub Mensaje(mensaje)
        Dim script As String = "alert('" + mensaje + "');"
        ClientScript.RegisterStartupScript(Me.GetType(), "MensajeEmergente", script, True)
    End Sub




#End Region


End Class