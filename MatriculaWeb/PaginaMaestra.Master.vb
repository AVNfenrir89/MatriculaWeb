Public Class Site1
    Inherits System.Web.UI.MasterPage
    Dim obj_funcionario As New Negocios.ClaseFuncionarios
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        funcionario.InnerText = "Funcionario " & obj_funcionario.Nombre
    End Sub



    Protected Sub cerrar_Click1(sender As Object, e As EventArgs)

    End Sub
End Class