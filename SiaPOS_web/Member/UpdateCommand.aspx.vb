
Partial Class UpdateCommand
    Inherits System.Web.UI.Page
    Dim ShopMessageID As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ShopMessageID = Request.QueryString("MessageID")
        ShopMessageID = 2
        '사용자의 이름을 구해서 넣는다
        If Not IsPostBack Then
            Dim message_dc As New ShopMessageDataContext
            Dim MessageTypes = _
                               From activeType In message_dc.MessageTypes _
                               Where activeType.Status = True _
                               Select activeType
            ServiceTypeDDL.DataSource = MessageTypes
            DataBind()
            LoadData()
        End If
    End Sub
    'LoadData() 서브루틴은 VisualStudio에서 템플릿을 제공하지 않는 본인 직접 선언 내용
    Sub LoadData()
        ' 검색할 ShopMessage 테이블에서 MessageID값을 쿼리 문자열로부터 받아 변수 ShopMessageID에 저장한다
        'Dim ShopMessageID As Integer = Request.QueryString("MessageID")
        ' 아직 쿼리 문자열에 MessageID 속성값이 설정되지 않았으므로 임시로 1을 넣는다
        'ShopMessageID = 1
        ' 데이터 작업을 위해 DAL의 ShopMessageDataContext 개체의 인스턴스를 생성하여 사용한다
        Dim message_dc As New ShopMessageDataContext
        ' 데이터 컨텍스트 객체는 LINQ to SQL 클래스 개체이므로 LINQ를 사용하여 코드를 작성할 수 있다. 아래 코드는 LINQ 쿼리 예제이다
        Dim messages = From msg In message_dc.ShopMessage _
                      Where msg.MessageID = ShopMessageID _
                      Select msg

        '검색한 서비스 컬렉션에서 개별 서비스에 대해 모든 속성 값을 추출하여 서비스 폼에 넣는다
        For Each msg In messages
            lblUserName.Text = "Y4321" '임시로 직접 선언된 사용자 ID 값
            ServiceTypeDDL.Text = msg.MessageType
            ServiceDate.Text = msg.MessageDate
            ServiceDescription.Text = msg.Message
        Next
        ' 수정한 서비스 번호와 함께 서비스 폼을 보여준다
        Message.Text = "메세지 번호 " & ShopMessageID & " 의 내용은 다음과 같습니다."
    End Sub

    Protected Sub AddServiceBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AddServiceBtn.Click
        If Page.IsValid = True Then
            ' 여기서 서비스 업데이트 작업을 수행한다
            ' Dim ShopMessageID As Integer = Request.QueryString("MessageID")
            ' ShopMessageID = 1
            ' 데이터 작업이므로 먼저 ShopMessageDataContext 객체의 인스턴스 message_dc를 생성한다
            Dim message_dc As New ShopMessageDataContext
            ' 데이터 컨텍스트 객체의 업데이트 메서들ㄹ 호출한다. 이때 매개변수의 수효와 순서 그리고 
            ' 데이터 타입은 DAL에서 생성된 시그니처를 정확히 따라야 한다(실수 말자!)
            message_dc.UpdateShopMessage(ShopMessageID, lblUserName.Text, ServiceDescription.Text, _
                                         ServiceTypeDDL.SelectedItem.Text, ServiceDate.Text)
            ' 업데이트 메서드가 완료되었으면 데이터베이스로부터 데이터를 다시 불러 브라우저에서 
            ' 확인할 수 있도록 한다. 이는 LoadData()를 호출하면 된다.
            LoadData()
            ' 사용자 이름을 사용하여 적절한 메시지를 표시하는 것은 사용자 우호적인
            ' 인터페이스를 만드는데 도움이 된다.
            Message.Text = "<font color=blue>" & lblUserName.Text & "님이 요청하신 서비스는 다음과 같이 수정되었습니다. </font>"
        Else
            ' 페이지가 유효성 검사에 실패했으므로 오류 메시지를 보낸다
            Message.Text = "<font color=red>" & lblUserName.Text & "님이 요청하신 서비스 수정은 실패했습니다. </font>"
        End If
    End Sub

    Protected Sub MyCalendar_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyCalendar.SelectionChanged
        ServiceDate.Text = MyCalendar.SelectedDate.ToShortDateString()

    End Sub
End Class
