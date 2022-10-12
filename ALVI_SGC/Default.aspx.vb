
Partial Class _Default
    Inherits System.Web.UI.Page

    
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Response.Redirect("security/login.aspx")
    End Sub
End Class
