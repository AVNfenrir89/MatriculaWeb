Imports Negocios
Public Class Formulario_web15
    Inherits System.Web.UI.Page
    Dim obj_Carrera As New Negocios.ClaseCarreras
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not User.Identity.IsAuthenticated Then
            Response.Redirect("login.aspx") ' Redirigir al inicio de sesión si no está autenticado
        End If

        cargarInfo()
    End Sub

    Protected Sub agregar_Click(sender As Object, e As EventArgs) Handles agregar.Click
        Try

            obj_Carrera.IdCarrera = input_id_carrera.Value
            obj_Carrera.Nombre = input_nombre_carrera.Value
            obj_Carrera.Validaciones()
            obj_Carrera.Estado = select_estado.Value
            obj_Carrera.Grados = select_grado.Value
            obj_Carrera.AgregarDatosCarrera()
            cargarInfo()
            limpiar()
        Catch ex As Exception
            Mensaje("Error. " & ex.Message)
        End Try

    End Sub

    Sub cargarInfo()
        Try
            obj_Carrera.LeeDatosCarrera()
            obj_Carrera.TablaCarreras.Columns("ID_Carrera").ColumnName = "ID Carrera"
            gv_carreras.DataSource = obj_Carrera.TablaCarreras
            gv_carreras.DataBind()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub limpiar()
        input_id_carrera.Value = ""
        input_nombre_carrera.Value = ""

    End Sub
    Sub limpiarBorrarModifcar()
        input_id_carrera2.Value = ""
        input_nombre_carrera2.Value = ""
    End Sub

    Protected Sub btn_Borrar_Click(sender As Object, e As EventArgs) Handles btn_Borrar.Click
        obj_Carrera.IdCarrera = input_id_carrera2.Value
        obj_Carrera.BorrarDatosCarrera()
        cargarInfo()
        limpiarBorrarModifcar()
    End Sub

    Protected Sub btn_Modificar_Click(sender As Object, e As EventArgs) Handles btn_Modificar.Click

        Try

            obj_Carrera.IdCarrera = input_id_carrera2.Value
            obj_Carrera.Nombre = input_nombre_carrera2.Value
            obj_Carrera.Validaciones()
            obj_Carrera.Estado = select_estado2.Value
            obj_Carrera.Grados = select_grado2.Value
            obj_Carrera.ModificarCarrera()
            cargarInfo()
            limpiarBorrarModifcar()
        Catch ex As Exception
            Mensaje("Error. " & ex.Message)
        End Try


    End Sub

    Protected Sub btn_buscar_Click(sender As Object, e As EventArgs)

        obj_Carrera.IdCarrera = input_id_carrera2.Value
        obj_Carrera.SeleccionarCarrera()

        For Each fila As DataRow In obj_Carrera.TablaCarreras.Rows
            input_nombre_carrera2.Value = fila("Nombre")
            If "activo" = fila("Estado").trim Then
                select_estado2.SelectedIndex = 0
            Else
                select_estado2.SelectedIndex = 1
            End If

            If fila("Grado").trim = "BACH" Then
                select_grado2.SelectedIndex = 0
            Else
                select_grado2.SelectedIndex = 1
            End If
        Next

    End Sub

    Sub Mensaje(mensaje)

        Dim script As String = "alert('" + mensaje + "');"
        ClientScript.RegisterStartupScript(Me.GetType(), "MensajeEmergente", script, True)


    End Sub

End Class