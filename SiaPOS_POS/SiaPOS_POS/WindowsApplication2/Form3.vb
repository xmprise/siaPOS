Imports System.Data.SqlClient
Public Class ScheduleLIst

    Private iYear As Integer
    Private iMonth As Integer
    Private iDay As Integer
    Private isNew As Boolean
    Shared isAdd As Integer 'Shared는 객체와는 상관없이 프로그램 종료시까지 살아있다
    Shared strContent As String
    Shared iHour As Integer
    Shared iMin As Integer

    Sub New(ByVal iYear As Integer, ByVal iMonth As Integer, ByVal iDay As Integer, ByVal isNew As Boolean)
        InitializeComponent()
        Me.iYear = iYear
        Me.iMonth = iMonth
        Me.iDay = iDay
        Me.isNew = isNew
    End Sub

    Public Property AddNum As Integer '수정 삭제 모드 관리속성
        Get
            Return isAdd
        End Get
        Set(ByVal value As Integer)
            isAdd = value
        End Set
    End Property

    Public ReadOnly Property TakeHour() As String '읽기전용으로 시간 값을 문자열로 반환한다
        Get
            Return iHour.ToString()
        End Get
    End Property

    Public ReadOnly Property TakeMin() As String '읽기전용으로 분값을 문자열로 반환한다
        Get
            Return iMin.ToString()
        End Get
    End Property

    Public WriteOnly Property GetHour() As Integer '쓰기전용으로 시간값을 숫자형으로 받는다
        Set(ByVal value As Integer)
            iHour = value
        End Set
    End Property

    Public WriteOnly Property GetMin() As Integer '쓰기전용으로 분값을 숫자형으로 받는다
        Set(ByVal value As Integer)
            iMin = value
        End Set
    End Property
    Private Sub ScheduleLIst_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If isNew = False Then '리스트뷰가 아니었다면
            Dim sql As String = "Select * from ScheduleData where 년 =" + iYear.ToString() +
                "AND 월=" + iMonth.ToString() +
                "AND 일=" + iDay.ToString() +
                "AND 시=" + iHour.ToString() +
                "AND 분=" + iMin.ToString() '받아온 변수들을 이용한 쿼리문 작성
            Dim conn As New DBconn()
            conn.Open()
            Dim reader As SqlDataReader = conn.ExeReader(sql) '연결기반으로 쿼리값을 받아온다
            If reader.Read() Then
                nudHour.Value = Integer.Parse(reader("시").ToString()) '시간값을 받는다
                nudMinute.Value = Integer.Parse(reader("분").ToString()) '분값을 받는다
                txtContent.Text = reader("내용").ToString() '내용을 받는다
                nudHour.Enabled = False
                nudMinute.Enabled = False
                txtContent.Enabled = False
                btnSave.Visible = False
                btnEdit.Visible = True
                btnDelete.Visible = True
            End If
            reader.Close() '연결해제
            conn.Close() '연결 종료

            AddNum = 0
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        '저장 버튼
        strContent = txtContent.Text '텍스트 박스 내용을 가져온다
        iHour = nudHour.Value '시간을 받고
        iMin = nudMinute.Value '분값을 받고
        Dim sql As String = "Insert into ScheduleData Values (" + iYear.ToString + "," + iMonth.ToString() + "," + iDay.ToString() + "," + nudHour.Value.ToString() + "," + nudMinute.Value.ToString() + ",'" + txtContent.Text + "'" + ")"
        '삽입 쿼리문을 작성해준다
        Dim conn As New DBconn()
        conn.Open()
        conn.ExeSQL(sql)
        conn.Close()
        AddNum = 1
        Close()
    End Sub

    Private Sub txtContent_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtContent.TextChanged
        If txtContent.Text = "" Then '내용이 있어야 저장버튼이 활성화된다
            btnSave.Enabled = False
        Else
            btnSave.Enabled = True
        End If
    End Sub

    Private Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        '수정버튼
        AddNum = 0 '수정시 폼의 컨트롤 속성들 변화
        nudHour.Enabled = True
        nudMinute.Enabled = True
        txtContent.Enabled = True
        btnEdit.Visible = False
        btnDelete.Visible = False
        btnEditFin.Visible = True
    End Sub

    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        '삭제버튼
        Dim sql As String = "Delete from ScheduleData where = 년" + iYear.ToString() + " AND 월" + iMonth.ToString() + "AND 일" + iDay.ToString() + "AND 시" + iHour.ToString() + "AND 분" + iMin.ToString() + "AND 내용" + txtContent.Text
        '삭제 쿼리
        Dim conn As New DBconn()
        conn.Open()
        conn.ExeSQL(sql)
        conn.Close()
        AddNum = 3
        Close()
    End Sub

    Private Sub btnEditFin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEditFin.Click
        '수정완료
        strContent = txtContent.Text '내용을 받아온다
        Dim sql As String = "Update ScheduleData set 시=" + nudHour.Value.ToString() +
            ",분=" + nudMinute.Value.ToString() +
            ",내용=" + txtContent.Text +
            " where (년=" + iYear.ToString() +
            " AND 월=" + iMonth.ToString() +
            "AND 일=" + iDay.ToString() +
            "AND 시=" + iHour.ToString() +
            "AND 분=" + iMin.ToString()
        '수정 쿼리문 작성
        iHour = nudHour.Value
        iMin = nudMinute.Value
        Dim conn As New DBconn()
        conn.Open()
        conn.ExeSQL(sql)
        AddNum = 2
        Close()
    End Sub
End Class