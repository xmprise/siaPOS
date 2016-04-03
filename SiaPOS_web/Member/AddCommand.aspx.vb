
Partial Class AddCommand
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '사용자의 이름을 구해서 넣는다
        If Not IsPostBack Then
            lblUserName.Text = User.Identity.Name
            'lblUserName.Text = "Y4321"
            Dim message_dc As New ShopMessageDataContext
            Dim MessageTypes = _
                               From activeType In message_dc.MessageTypes _
                               Where activeType.Status = True _
                               Select activeType
            ServiceTypeDDL.DataSource = MessageTypes
            DataBind()
        End If
    End Sub
    '달력에서 선택한 날짜를 String 타입으로 텍스트 박스에 넣는다
    Protected Sub MyCalendar_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyCalendar.SelectionChanged
        ServiceDate.Text = MyCalendar.SelectedDate.ToShortDateString()
    End Sub
    '등록 버튼을 클릭하면 컨트롤에 입력된 데이터를 추출하여 데이터베이스에 삽입한다
    Protected Sub AddServiceBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AddServiceBtn.Click
        If Page.IsValid = True Then
            '서비스 설명을 기입하지 않은 경우에는 "없음"이라고 설정한다
            Dim Description As String
            If ServiceDescription.Text = "매장에 전달할 내용을 입력해 주세요." Then
                Description = "없음"
            Else
                Description = ServiceDescription.Text
            End If

            '서비스 요청일을 오늘의 날짜로 설정한다
            Dim TodayDate As Date = Now.ToShortDateString()

            ' 서비스 타입은 DropDownList로부터 가져온다
            Dim ServiceType As String = ServiceTypeDDL.SelectedItem.Text

            ' ShopMessageDataContext 클래스의 객체 message_dc를 생성한다
            ' message_dc 객체의 AddService 메서드를 실행시켜 새로운 서비스를 데이터베이스에 저장하고
            ' 반환 값인 서비스 번호를 Integer 변수 messageID에 보관한다
            Dim meesageID As Integer
            Dim message_dc As New ShopMessageDataContext
            meesageID = message_dc.InsertShopMessage(lblUserName.Text, _
                                                     Description, ServiceType, TodayDate, meesageID)

            ' 등록이 끝나면 새 서비스 번호를 알려주어 확인할 수 있도록 한다
            Message.Text = "메세지 ID는 다음과 같습니다." & "ID 번호 = " & meesageID

        Else
            Message.Text = "요청을 완료하지 못했습니다."

        End If
    End Sub
End Class
