Public Class MainLogin
    Public ShopID As String
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        End
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim conn As New DBconn()
        Dim sql As String
        Dim ds As New DataSet
        Dim dt As DataTable
        'sql = "select ID, Password from Login where ID = " + "'" + UsernameTextBox.Text + "'" + "and Password = " + "'" + PasswordTextBox.Text + "'"
        sql = "select UserName, UserShopName from Person.MemberShop where UserName = " + "'" + UserNameTextBox.Text + "'" + "and UserShopName = " + "'" + PasswordTextBox.Text + "'"
        conn.Open()
        ds = conn.ExeDataSet(sql)
        Try
            If ds.Tables.Item(0).Rows(0).RowState Then

                dt = ds.Tables.Item(0)
                Dim rws As DataRowCollection = dt.Rows
                Dim rw As DataRow

                For Each rw In rws
                    ShopID = rw.Item("UserName").ToString
                Next
                conn.Close()
                MsgBox("로그인 확인")
                MsgBox(ShopID)
                frm_Main.ShopID = Me.ShopID
                frm_Main.Show()
                Me.Hide()
            End If
        Catch ex As Exception
            conn.Close()
            MsgBox("아이디와 패스워드를 다시 확인해주세요.")
        End Try

    End Sub
End Class