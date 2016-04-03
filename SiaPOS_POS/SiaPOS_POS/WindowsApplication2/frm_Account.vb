Imports System.Windows.Forms
Imports System.Data.SqlClient
Public Class frm_Account
    Dim Dname() As String '테이블 번호
    Dim Modify As Boolean = False
    Dim OrderData() As Integer
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        'MsgBox(Dname(0))

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
        MsgBox(uTime + " 계산 완료")

        Dim conn As New DBconn()
        Dim sql As String
        Dim num As Integer
        conn.Open()
        Dim StrArray(3) As String
        For i = 0 To DataGridView1.Rows.Count - 1
            For z = 0 To DataGridView1.ColumnCount - 1
                StrArray(z) = DataGridView1.Rows(i).Cells(z).Value
            Next
            'sql = "Insert into ShopAccounts Values(" + "'" + uTime + "'" + "," + "'" + Dname(0) + "'" + "," + "'" + StrArray(0) + "'" + "," + "'" + StrArray(1) + "'" + "," + "'" + StrArray(2) + "'" + ")"
            num += DataGridView1.Rows(i).Cells(2).Value
            sql = "Insert into Shop.ShopAccount Values('" + frm_Main.ShopID + "'" + "," + "'" + StrArray(0) + "'" + "," + "'" + uTime + "'" + "," + Dname(0) + "," + StrArray(2) + "," + StrArray(1) + ", 1, 0)"
            conn.ExeSQL(sql)
        Next
        conn.Close()
        'ShopAccounts 테이블에 계산이 완료된 값들을 입력한다

        conn.Open()
        sql = "Delete from Shop.TempShopAccount where (TableNumber = " + Dname(0) + "and ShopID =" + "'" + frm_Main.ShopID + "'" + ")"
        conn.ExeSQL(sql)
        conn.Close()
        '임시 계산테이블인 ShopUnitSales 테이블에서 값을 지운다
        Dim Days As MdiDays = frm_Main.MdiChildren(Dname(0) - 1)
        Days.Acounts = False
        Days.Button1.BackColor = Color.Silver  '버튼 원래 대로 
        Days.PictureBox1.BackColor = Color.MediumBlue
        Days.Label1.Text = "주문대기"
        Days.endPic(num)
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        'Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Dialog3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: 이 코드는 데이터를 'VbnetDBDataSet2.ShopUnitSales' 테이블에 로드합니다. 필요한 경우 이 코드를 이동하거나 제거할 수 있습니다.
        Dim MenuName As String
        Dim MenuPrice As String
        Dim Quantity As String
        Dim Price As String

        Dname = Me.Text.Split(" ")

        Dim conn As New DBconn()
        Dim ds As New DataSet
        Dim dt As DataTable

        conn.Open()
        'Dim sql As String = "select TableNumber, MenuName, MenuPrice, Quantity, sum(MenuPrice * Quantity) as [price]from ShopUnitSales where TableNumber = " + Dname(0).ToString + "group by TableNumber,MenuName,MenuPrice,Quantity "
        Dim sql As String
        sql = "select b.TableNumber, b.MenuName, a.MenuPrice, b.MenuAccount, (a.MenuPrice * b.MenuAccount) as price from Product.MenuInformation as a inner join Shop.TempShopAccount as b on a.MenuName = b.MenuName Where b.ShopID = '" + frm_Main.ShopID + "'" + "and b.TableNumber = " + Dname(0)

        'sql 쿼리
        ds = conn.ExeDataSet(sql)
        dt = ds.Tables.Item(0)
        Dim rows As DataRowCollection = dt.Rows
        Dim row As DataRow

        For Each row In rows
            MenuName = row.Item("MenuName")
            MenuPrice = row.Item("MenuPrice")
            Quantity = row.Item("MenuAccount")
            Price = row.Item("price")
            '그리드뷰에 데이터를 삽입한다
            DataGridView1.Rows.Add(MenuName, MenuPrice, Quantity, Price)
        Next
        conn.Close()

        Dim total As Integer
        For i = 0 To DataGridView1.Rows.Count - 1
            total += DataGridView1.Rows(i).Cells(3).Value
        Next
        '주문된 메뉴들의 총 가격을 구한다
        Label1.Text = total

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        MsgBox("할인")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MsgBox("돈통을 엽니다.")
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        ReDim OrderData(DataGridView1.Rows.Count - 1)

        MsgBox("주문을 취소 합니다. 수량을 클릭하여 주문을 취소 하세요.")
        Modify = True
        OK_Button.Enabled = False
        Button5.Visible = True
        Button6.Visible = True

        For i = 0 To DataGridView1.Rows.Count - 1
            OrderData(i) = DataGridView1.Rows(i).Cells(2).Value
        Next

    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        If Modify = True Then
            If DataGridView1.Rows(e.RowIndex).Cells(2).Value > 0 Then
                DataGridView1.Rows(e.RowIndex).Cells(2).Value -= 1 '메뉴의 수량을 -1만큼 

                If DataGridView1.Rows(e.RowIndex).Cells(2).Value Like 0 Then '메뉴의 수량이 0 일때
                    MsgBox(DataGridView1.Rows(e.RowIndex).Cells(0).Value.ToString + "의 주문을 모두 취소 합니다.")
                End If

            End If

        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        '재고 처리. 취소한 만큼 재고 데이터로 값 돌려주기
        Modify = False
        OK_Button.Enabled = True
        Button5.Visible = False
        Button6.Visible = False

        Dim strArray(3) As String

        Modify = False
        OK_Button.Enabled = True
        Button5.Visible = False
        Button6.Visible = False

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

        Dim conn As New DBconn()
        Dim sql As String
        Dim n As Integer '재고로 복구 할 개수
        Dim endNum As Integer
        Dim num As Integer
        Dim Days As MdiDays = frm_Main.MdiChildren(Dname(0) - 1)

        For i = 0 To DataGridView1.Rows.Count - 1
            For j = 0 To DataGridView1.Columns.Count - 1
                strArray(j) = DataGridView1.Rows(i).Cells(j).Value
            Next
            n = OrderData(i) - strArray(2)
            If n > 0 Then
                conn.Open()
                sql = "update Shop.ShopStock set Stock = Stock +" + n.ToString + "where MenuName = '" + strArray(0) + "' and ShopID = '" + frm_Main.ShopID + "'" + " update Shop.TempShopAccount set MenuAccount = " + strArray(2) + " where MenuName = '" + strArray(0) + "' and ShopID = '" + frm_Main.ShopID + "'"
                conn.ExeSQL(sql)
                conn.Close()
            End If
            If DataGridView1.Rows(i).Cells(2).Value = 0 Then
                conn.Open()
                sql = "Delete from Shop.TempShopAccount where (TableNumber = " + Dname(0) + "and ShopID =" + "'" + frm_Main.ShopID + "'" + "and MenuName = '" + DataGridView1.Rows(i).Cells(0).Value + "')"
                conn.ExeSQL(sql)
                conn.Close()
            End If
            '수량이 0이 아니라면 TempShopAccount의 Account를 수정하고 차감된 수량은 ShopAccout로 불용으로 처리한다.
            '수량이 0이 라면 Form2의 BackColor을 바꿔야 하고 TempShopAccout의 데이터를 삭제하고 차감된 수량만큼 ShopAccout로 불용 처리한다
            endNum += Integer.Parse(DataGridView1.Rows(i).Cells(2).Value)
            num += n
        Next
        Days.endPic(num)
        If endNum = 0 Then
            Days.Acounts = False
            Days.Button1.BackColor = Color.Silver  '버튼 원래 대로 
            Days.PictureBox1.BackColor = Color.MediumBlue
            Days.Label1.Text = "주문대기"
            Me.Close()
        End If
        MsgBox("수정된 주문으로 변경 합니다. 취소한 수량은 재고로 반영 됩니다.")
        frm_Main.GridVIew_Stock()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim strArray(3) As String

        Modify = False
        OK_Button.Enabled = True
        Button5.Visible = False
        Button6.Visible = False

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

        Dim conn As New DBconn()
        Dim sql As String
        Dim n As Integer '불용 개수
        Dim endNum As Integer
        Dim num As Integer
        Dim Days As MdiDays = frm_Main.MdiChildren(Dname(0) - 1)
        For i = 0 To DataGridView1.Rows.Count - 1
            For j = 0 To DataGridView1.Columns.Count - 1
                strArray(j) = DataGridView1.Rows(i).Cells(j).Value
            Next
            n = OrderData(i) - strArray(2)
            If n > 0 Then
                conn.Open()
                sql = "Insert into Shop.ShopAccount Values('" + frm_Main.ShopID + "'" + "," + "'" + strArray(0) + "'" + "," + "'" + uTime + "'" + "," + Dname(0) + "," + n.ToString + "," + strArray(1) + ", 0,0) " + "update Shop.TempShopAccount set MenuAccount = " + strArray(2) + "where MenuName = '" + strArray(0) + "' and ShopID = '" + frm_Main.ShopID + "'"
                conn.ExeSQL(sql)
                conn.Close()
            End If
            If DataGridView1.Rows(i).Cells(2).Value = 0 Then
                conn.Open()
                sql = "Delete from Shop.TempShopAccount where (TableNumber = " + Dname(0) + "and ShopID =" + "'" + frm_Main.ShopID + "'" + "and MenuName = '" + DataGridView1.Rows(i).Cells(0).Value + "')"
                conn.ExeSQL(sql)
                conn.Close()
            End If
            '수량이 0이 아니라면 TempShopAccount의 Account를 수정하고 차감된 수량은 ShopAccout로 불용으로 처리한다.
            '수량이 0이 라면 Form2의 BackColor을 바꿔야 하고 TempShopAccout의 데이터를 삭제하고 차감된 수량만큼 ShopAccout로 불용 처리한다
            endNum += Integer.Parse(DataGridView1.Rows(i).Cells(2).Value)
            num += n
        Next
        MsgBox("수정된 주문으로 변경 합니다.재고에 반영되지 않고 불용 처리 됩니다.")
        Days.endPic(num)
        If endNum = 0 Then
            Days.Acounts = False
            Days.Button1.BackColor = Color.Silver  '버튼 원래 대로 
            Days.PictureBox1.BackColor = Color.MediumBlue
            Days.Label1.Text = "주문대기"
            Me.Close()
        End If
    End Sub
End Class
