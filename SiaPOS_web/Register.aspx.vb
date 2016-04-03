
Partial Class Register
    Inherits System.Web.UI.Page

    Protected Sub CreateUserWizard1_ActiveStepChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CreateUserWizard1.ActiveStepChanged
      
    End Sub

    Protected Sub CreateUserWizard1_ContinueButtonClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CreateUserWizard1.ContinueButtonClick
        Dim username As String = User.Identity.Name
        '성별에서 선택된 값을 구한다

        Dim gender As String
        If (man.Checked) Then
            gender = man.Text
        Else
            gender = woman.Text
        End If
        ' Intro 컨트롤에 초기값이 남아 있을 경우에는 "없음"을, 새로운 값이 입력되었을 때는 
        ' 그 값을 Introduction에 보관한다
        Dim introduction As String
        If Intro.Text = "간단히 자기 소개를 해주세요." Then
            introduction = "없음"
        Else
            introduction = Intro.Text
        End If

        Dim member_dc As New MemberInfo_newDataContext
        'Dim memberid As Integer = member_dc.InsertMemberInfo(username, RealName.Text, gender, _
        '                                                    Phone.Text, Address.Text, introduction, memberid)
        Dim memberid As Integer = member_dc.InsertMemberInfo(username, RealName.Text, gender, _
                                                             Phone.Text, DropDownList1.SelectedValue, Address.Text, introduction, memberid)
        Dim shop_dc As New MemberShop_newDataContext
        'Dim shopid As Integer = shop_dc.InsertShopInfo(username, ShopName1.Text, ShopType1.SelectedValue, ShopTableAccount.Text, shopid)
        Dim shopid As Integer = shop_dc.InsertMemberShop(username, ShopName1.Text, ShopType1.SelectedValue, ShopTableAccount.Text, shopid)
        Response.Redirect("~/Default.aspx")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub UserInfo_Activate(ByVal sender As Object, ByVal e As System.EventArgs) Handles UserInfo.Activate

    End Sub
End Class
