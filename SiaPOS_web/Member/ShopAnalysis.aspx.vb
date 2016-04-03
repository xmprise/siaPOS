
Partial Class Member_ShopAnalysis
    Inherits System.Web.UI.Page
    Dim sdate As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            UserName.Text = User.Identity.Name
        End If
    End Sub

    Protected Sub Calendar1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Calendar1.SelectionChanged
        If RadioStart.Checked = True Then
            StartDate.Text = Calendar1.SelectedDate.ToShortDateString()
        End If

        If RadioEnd.Checked = True Then
            EndDate.Text = Calendar1.SelectedDate.ToShortDateString()
        End If

    End Sub


End Class
