Public Class Formulario_web18
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FormsAuthentication.SignOut()
        Session.Abandon()
        Response.Redirect("login.aspx")
    End Sub

    Protected Sub Login1_Authenticate(sender As Object, e As AuthenticateEventArgs)

    End Sub
End Class