
Partial Class UpdateMyInfo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' 테스트하기 위하여 등록된 사용자 이름 중에서 선택하여 할당한다.
        ' 아래의 코드는 로그인 페이지가 완성된 후 삭제 한다...
        lblUserName.Text = "y4321"
        If Not IsPostBack Then
            ' 로그인 페이지가 완성된 후에는 아래의 코드에서 주석 표시를 삭제한다.
            ' lblUserName.Text = User.Identity.Name
            ' 데이터베이스로부터 데이터를 불러오는 서브루틴 LoadData()를 호출한다.
            LoadData()
        End If
    End Sub

    Sub LoadData()
        ' Email은 MembershipUser 객체의 속성을 이용하여 구한다
        Dim mu As MembershipUser = Membership.GetUser(lblUserName.Text)
        Email.Text = mu.Email
        ' 회원 추가 정보는 ASPNETDBDataContext 개체를 사용하여 구한다.
        Dim aspnetdb_dc As New MemberInfo_newDataContext
        Dim myinfo = From meminfo In aspnetdb_dc.MemberInfo _
                     Where meminfo.UserName = lblUserName.Text _
                     Select meminfo

        For Each minfo In myinfo
            lblUserName.Text = minfo.UserName
            lblMemberId.Text = minfo.MemberID
            RealName.Text = minfo.RealName
            ' Gender 값을 구해 해당 Radio Button의 Cheked 속성을 "true"로 설정한다.
            ' 다른 속성의 값은 Text 속성에 넣어준다.
            If minfo.Gender = "남자" Then
                man.Checked = "true"
            Else
                woman.Checked = "true"
            End If
            Phone.Text = minfo.Phone
            DropDownList1.SelectedValue = minfo.Region
            Address.Text = minfo.Address
            Intro.Text = minfo.Intro
            lblMemberId.Text = minfo.MemberID
        Next
        Message.Text = RealName.Text & "님의 개인 정보는 다음과 같습니다. "
    End Sub

    Protected Sub UpdateBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpdateBtn.Click
        ' 수정하기 버튼을 클릭하면 먼저 페이지에 있는 폼의 모든 입력 데이터가 
        ' 유효한지를 검사하고 모두 검사를 통과한다면 수정 작업을 수행한다.
        If Page.IsValid = True Then
            ' Email은 MembershipUser 객체와 Membership 객체의 UpdateUser 메서드를 이용하여 수정한다.
            Dim mu As MembershipUser = Membership.GetUser(lblUserName.Text)
            mu.Email = Email.Text
            Membership.UpdateUser(mu)
            Dim gender As String
            If (man.Checked) Then
                gender = man.Text
            Else
                gender = woman.Text
            End If
            Dim aspnetdb_dc As New MemberInfo_newDataContext
            aspnetdb_dc.UpdateMemberInfo(lblMemberId.Text, lblUserName.Text, RealName.Text, gender, _
                                         Phone.Text, DropDownList1.SelectedValue, Address.Text, Intro.Text)
            '수정 작업이 정확히 이루어졌는지 확인하기 위해 데이터베이스에 저장된 데이터를 다시 불러온다
            LoadData()
            Message.Text = RealName.Text & " 님의 개인 정보는 다음과 같이 수정 되었습니다. "

        End If
    End Sub
End Class
