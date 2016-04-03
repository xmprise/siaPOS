Imports System.Data.SqlClient
Public Class DBconn
    Dim _strSource As String = "Data Source=210.118.69.65,8000;Initial Catalog=SibalChk2011;User ID=jung;Password=!jwj2114!"
    Dim _strLogin As String = "Data Source=210.118.69.65,8000;Initial Catalog=ASPNETDB;User ID=jung;Password=!jwj2114!"
    '데이터 소스
    Private _conn As SqlConnection '컨넥션 이름 지정
    Public Sub Open() '오픈 메서드
        _conn = New SqlConnection(_strSource) '인스턴스 생성
        _conn.Open() '오픈
    End Sub
    Public Sub Login() '로그인 메서드
        _conn = New SqlConnection(_strLogin)
        _conn.Open()
    End Sub
    Public Sub Close() '닫기 메서드
        _conn.Close()
    End Sub
    Public Sub ExecuteSqlTransaction(ByVal transactionName As String, ByVal sql1 As String, ByVal sql2 As String) '작업단위를 트랜잭션 처리
        Using connection As New SqlConnection("Data Source=210.118.69.65,8000;Initial Catalog=SibalChk2011;User ID=jung;Password=!jwj2114!")
            connection.Open()

            Dim command As SqlCommand = connection.CreateCommand()
            Dim transaction As SqlTransaction


            transaction = connection.BeginTransaction(transactionName)

            command.Connection = connection
            command.Transaction = transaction

            Try
                command.CommandText = sql1
                command.ExecuteNonQuery()
                command.CommandText = sql2

                command.ExecuteNonQuery()

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

    Public Sub ExeSQL(ByVal sql As String) '검색문 외에 쿼리 실행 메서드
        Dim cmd As SqlCommand = New SqlCommand(sql, _conn)
        cmd.ExecuteNonQuery()
    End Sub
    Public Function ExeReader(ByVal sql As String) As SqlDataReader '데이터 연결기반으로 불러온다
        Dim cmd As SqlCommand = New SqlCommand(sql, _conn)
        Return cmd.ExecuteReader()
    End Function
    Public Function ExeDataSet(ByVal sql As String) As DataSet '데이터를 비연결 기반으로 불러온다
        Dim adapter As SqlDataAdapter = New SqlDataAdapter()
        adapter.SelectCommand = New SqlCommand(sql, _conn)

        Dim ds As DataSet = New DataSet()
        adapter.Fill(ds)

        Return ds
    End Function

End Class
