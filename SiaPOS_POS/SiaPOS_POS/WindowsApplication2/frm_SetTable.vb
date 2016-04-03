Imports System.Windows.Forms

Public Class ShopTable
    Sub New()
        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.

    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ok_button.Click
        
        Dim sql As String = "update Person.MemberShop set ShopTableAccount = " + txtTable.Text + "where UserName = '" + frm_Main.ShopID + "'"
        '삽입 쿼리문을 작성해준다
        Dim conn As New DBconn()
        conn.Open()
        conn.ExeSQL(sql)
        conn.Close()
        MsgBox("매장내 테이블을 새로 배치 합니다.")
        For i = 0 To frm_Main.MdiChildren.Length - 1
            frm_Main.MdiChildren(0).Close()
        Next
        frm_Main.init()
        Close()

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
