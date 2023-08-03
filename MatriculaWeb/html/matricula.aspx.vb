Public Class Formulario_web12
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_mostrar_Click(sender As Object, e As EventArgs)

        lb_curso_uno.InnerText = ""
        curso_uno.Value = ""

        lb_curso_dos.InnerText = ""
        curso_dos.Value = ""


    End Sub

    Protected Sub btn_matricular_Click(sender As Object, e As EventArgs)

    End Sub

    Protected Sub btn_total_Click(sender As Object, e As EventArgs)

    End Sub
End Class