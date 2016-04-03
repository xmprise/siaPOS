Imports System.Data.SqlClient
Public Class Login

    ' TODO: 제공된 사용자 이름과 암호를 사용하여 사용자 지정 인증을 수행하는 코드를 삽입합니다
    ' (자세한 내용은 http://go.microsoft.com/fwlink/?LinkId=35339 참조).  
    ' 그러면 사용자 지정 보안 주체가 현재 스레드의 보안 주체에 다음과 같이 첨부될 수 있습니다. 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' 여기서 CustomPrincipal은 인증을 수행하는 데 사용되는 IPrincipal이 구현된 것입니다. 
    ' 나중에 My.User는 CustomPrincipal 개체에 캡슐화된 사용자 이름, 표시 이름 등의
    ' ID 정보를 반환합니다.
    Dim frmName As String
    Public Sub New(ByVal frmName As String)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()
        Me.frmName = frmName
        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.

    End Sub

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim conn As New DBconn()
        Dim sql As String
        Dim ds As New DataSet

        sql = "select ID, Password from Login where ID = " + "'" + UsernameTextBox.Text + "'" + "and Password = " + "'" + PasswordTextBox.Text + "'"

        conn.Open()
        ds = conn.ExeDataSet(sql)
        Try
            If ds.Tables.Item(0).Rows(0).RowState Then
                conn.Close()
                MsgBox("로그인 확인")
            End If

            If frmName Like "매장정산" Then
                Dim dia4 As New frm_Total(frmName)
                dia4.ShowDialog()
            End If

        Catch ex As Exception
            conn.Close()
            MsgBox("아이디와 패스워드를 다시 확인해주세요.")
        End Try
        Me.Close()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub LoginForm1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = frmName
    End Sub
End Class
