
Partial Class Member_DAL_AccountGridView
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            UserName.Text = User.Identity.Name
        End If
    End Sub
End Class
