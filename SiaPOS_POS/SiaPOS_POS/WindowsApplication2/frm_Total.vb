Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class frm_Total
    Dim strArray1() As String
    Public Sub New(ByVal frmName As String)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()
        Me.Text = frmName
        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.

    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        Dim conn As New DBconn()
        Dim StrArray3(2) As String

        'Shop.ShopDayFinish에 ShopID와 총 정산금액, 오차금액을 입력
        'ShopAccount에 AccountState를 모두 1로 만든다
        ExecuteSqlTransaction("ShopTotalAccounts")

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalProfit.TextChanged
        Label7.Text = Integer.Parse(Label5.Text) - Integer.Parse(txtTotalProfit.Text)

        If Integer.Parse(Label7.Text) = 0 Then
            Label7.ForeColor = Color.Black
        Else
            Label7.ForeColor = Color.Red
        End If
    End Sub

    Private Sub frm_Total_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql As String
        Dim conn As New DBconn() '따로 만들어 둔 인스턴스 생성
        Dim ds As New DataSet() '데이터셋 생성
        Dim dt As DataTable

        sql = "select MenuName, Date, TableNumber, MenuAccount,(MenuAccount*Profit) as Profit from Shop.ShopAccount where OrderState = 1 and AccountsState = 0 and ShopID = '" + frm_Main.ShopID + "'"
        '쿼리문
        conn.Open()
        ds = conn.ExeDataSet(sql) '조건에 맞는 자료들을 데이터셋에 저장
        dt = ds.Tables.Item(0)
        Dim rows As DataRowCollection = dt.Rows
        Dim row As DataRow
        Dim cols As DataColumnCollection = dt.Columns
        Dim arrRow(cols.Count) As String

        conn.Close()

        For Each row In rows
            For j = 0 To cols.Count - 1
                arrRow(j) = row.Item(j)
            Next
            DataGridView1.Rows.Add(arrRow)
        Next
        'DataGridView1에 해당 자료를 넣어준다
        ReDim strArray1(DataGridView1.Rows.Count)

        Dim total As Integer

        For i = 0 To DataGridView1.Rows.Count - 1
            total += DataGridView1.Rows(i).Cells(4).Value
        Next

        Label5.Text = total.ToString

    End Sub

    Private Function NowTime()
        Dim a() As String
        Dim b() As String
        Dim uTime As String = ""
        a = Now.ToString().Split(" ")
        b = a(2).ToString.Split(":")
        If a(1) Like "오후" Then
            b(0) = Integer.Parse(b(0)) + 12
            a(1) = " "
            a(2) = b(0) + ":" + b(1) + ":" + b(2)
        Else
            a(1) = " "
        End If
        'System 시간을 yyyy-yy-yy yy:yy 로 변환
        For i = 0 To a.Length - 1
            uTime += a(i)
        Next
        Return uTime
    End Function

    Public Sub ExecuteSqlTransaction(ByVal transactionName As String) '작업단위를 트랜잭션 처리
        Using connection As New SqlConnection("Data Source=124.198.16.87,8000;Initial Catalog=SibalChk2011;User ID=jung;Password=!jwj2114!")
            connection.Open()
            Dim Sql1, Sql2 As String
            Dim command As SqlCommand = connection.CreateCommand()
            Dim transaction As SqlTransaction
            Sql1 = "Insert into Shop.ShopDayFinish Values ('" + frm_Main.ShopID + "'" + "," + "'" + NowTime() + "'" + "," + txtTotalProfit.Text + "," + Label7.Text + ")"

            transaction = connection.BeginTransaction(transactionName)

            command.Connection = connection
            command.Transaction = transaction

            Try
                command.CommandText = sql1
                command.ExecuteNonQuery()

                For i = 0 To DataGridView1.Rows.Count - 1
                    For j = 0 To DataGridView1.ColumnCount - 1
                        sql2 = "update Shop.ShopAccount set AccountsState = 1" + "where MenuName = '" + DataGridView1.Rows(i).Cells(0).Value + "' and ShopID = '" + frm_Main.ShopID + "'"
                        command.CommandText = sql2
                        command.ExecuteNonQuery()
                    Next
                Next

                ' 트랜잭션 커밋
                transaction.Commit()
                MessageBox.Show("처리를 완료 하였습니다.")

            Catch ex As Exception
                MessageBox.Show("처리에 실패 했습니다. 아래 에러메세지를 참고하여 관리자에게 문의 하십시오." + ex.GetType().ToString)
                MessageBox.Show(ex.Message.ToString)

                ' Attempt to roll back the transaction.
                Try
                    transaction.Rollback()

                Catch ex2 As Exception
                    ' This catch block will handle any errors that may have occurred
                    ' on the server that would cause the rollback to fail, such as
                    ' a closed connection.
                    MessageBox.Show("Rollback Exception Type: {0}", ex2.GetType().ToString)
                    MessageBox.Show("  Message: {0}", ex2.Message.ToString)
                End Try
            End Try
        End Using
    End Sub

End Class
