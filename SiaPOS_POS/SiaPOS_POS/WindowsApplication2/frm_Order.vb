Imports System.Data.SqlClient
Public Class frm_Order
    Dim strArray1() As String
    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: 이 코드는 데이터를 'SibalChk_MenuInfo.MenuInformation' 테이블에 로드합니다. 필요한 경우 이 코드를 이동하거나 제거할 수 있습니다.
        Me.MenuInformationTableAdapter.Fill(Me.SibalChk_MenuInfo.MenuInformation)
        'TODO: 이 코드는 데이터를 'VbnetDBDataSet1.ShopMenu' 테이블에 로드합니다. 필요한 경우 이 코드를 이동하거나 제거할 수 있습니다.

        ReDim strArray1(DataGridView1.Rows.Count) '동적배열 할당

        Me.MenuInformationTableAdapter.FillBy(Me.SibalChk_MenuInfo.MenuInformation, frm_Main.ShopID)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Dim sql As String
        Dim conn As New DBconn()
        Dim i As Integer
        Dim z As Integer

        Dim a() As String
        Dim b() As String
        Dim MenuAccount As Integer

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

        Dim TableNumber() As String
        TableNumber = Me.Text.Split(" ")

        If DataGridView2.Rows.Count <= 0 Then
            MsgBox("메뉴와 수량을 추가하고 확인해 주세요.")
            Exit Sub
        End If

        conn.Open()
        Dim StrArray3(2) As String
        For i = 0 To DataGridView2.Rows.Count - 1
            For z = 0 To DataGridView2.ColumnCount - 1
                StrArray3(z) = DataGridView2.Rows(i).Cells(z).Value
            Next
            sql = "Insert into Shop.TempShopAccount Values ('" + frm_Main.ShopID + "'" + "," + "'" + StrArray3(0).ToString + "'" + "," + "'" + uTime + "'" + "," + TableNumber(0) + "," + StrArray3(2).ToString + ", 1)"
            'ShopUnitSales 테이블에 데이터를 저장한다. 
            '트리거로 새로운 값이 들어올때마다 State열에 1을 입력한다. 계산에서 취소 버튼을 누르면 0으로 바꾼다
            conn.ExeSQL(sql)
            MenuAccount += Integer.Parse(StrArray3(2))
        Next
        conn.Close()

        MsgBox(TableNumber(0) + " 테이블에 주문을 입력했습니다.")
        Dim Days As MdiDays = frm_Main.MdiChildren(TableNumber(0) - 1)
        Days.Acounts = True
        Days.Button1.BackColor = Color.DarkOrange
        Days.PictureBox1.BackColor = Color.Yellow
        Days.Label1.Text = "주문상태"
        Days.pic(MenuAccount)

        Dim strArray4(1) As String
        For i = 0 To DataGridView2.Rows.Count - 1
            For j = 0 To frm_Main.DataGridView2.Rows.Count - 1
                If DataGridView2.Rows(i).Cells(0).Value Like frm_Main.DataGridView2.Rows(j).Cells(0).Value Then
                    strArray4(0) = Integer.Parse(frm_Main.DataGridView2.Rows(j).Cells(1).Value) - Integer.Parse(DataGridView2.Rows(i).Cells(2).Value)
                    sql = "update Shop.ShopStock set Stock = " + strArray4(0) + "where MenuName = '" + DataGridView2.Rows(i).Cells(0).Value + "' and ShopID = '" + frm_Main.ShopID + "'"
                    conn.Open()
                    conn.ExeSQL(sql)
                    conn.Close()
                End If
            Next
        Next

        frm_Main.GridVIew_Stock()
        Me.Close()
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim strArray(2) As String
        Dim a As Integer

        For a = 0 To DataGridView1.ColumnCount - 2
            Try
                strArray(a) = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex + a).Value
            Catch ex As Exception
                MsgBox("메뉴명을 클릭하세요.")
                Exit Sub
            End Try
        Next

        Dim z As Integer
        For z = 0 To DataGridView1.Rows.Count - 1
            If strArray1(z) Like DataGridView1.Rows(e.RowIndex).Cells(1).Value Then 'strArray1에 선택된 메뉴가 있는지 확인
                MsgBox(strArray1(z))
                strArray = Nothing '이미 추가가 된 메뉴가 선택 되었다면 DataGridView2에 같은 메뉴를 추가 하지 않는다
                Exit For
            ElseIf strArray1(z) <> Nothing Then
            Else
                strArray1(z) = DataGridView1.Rows(e.RowIndex).Cells(1).Value
                strArray(2) = 1
                Exit For
            End If
        Next

        Try
            If strArray Is Nothing Then '처음 DataGridView에 입력 된다면
                Dim y As Integer
                For y = 0 To DataGridView2.Rows.Count - 1
                    If DataGridView1.Rows(e.RowIndex).Cells(1).Value Like DataGridView2.Rows(y).Cells(0).Value Then
                        DataGridView2.Rows(y).Cells(2).Value += 1
                    End If
                Next
            Else
                MsgBox(strArray(0))
                DataGridView2.Rows.Add(strArray)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DataGridView2_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        If DataGridView2.Rows(e.RowIndex).Cells(2).Value > 0 Then
            DataGridView2.Rows(e.RowIndex).Cells(2).Value -= 1
            If DataGridView2.Rows(e.RowIndex).Cells(2).Value Like 0 Then
                DataGridView2.Rows.RemoveAt(e.RowIndex)
                'row를 삭제 해도, strArray1에 값이 그대로 남아 있기 때문에 다음번에 추가가 되지 않는다.
            End If
        Else
            MsgBox("수량을 클릭하면 갯수를 하나 줄입니다.")
        End If

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class