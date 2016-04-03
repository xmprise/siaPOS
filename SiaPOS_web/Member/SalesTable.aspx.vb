
Partial Class Member_SalesTable
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            UserName.Text = User.Identity.Name
        End If
    End Sub

    Protected Sub Calendar1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Calendar1.SelectionChanged
        StartDate.Text = Calendar1.SelectedDate.ToShortDateString()
    End Sub

    Protected Sub Calendar3_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Calendar3.SelectionChanged
        EndDate.Text = Calendar3.SelectedDate.ToShortDateString()
    End Sub
End Class
