Imports System.Windows.Forms

Public Class frm_Stock
    Dim strArray1() As String
    Public Sub New(ByVal frmName As String)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()
        Me.Text = frmName
        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.

    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim sql As String
        Dim conn As New DBconn()

        conn.Open()

        Dim StrArray3(1) As String
        For i = 0 To DataGridView2.Rows.Count - 1
            For z = 0 To DataGridView2.ColumnCount - 1
                StrArray3(z) = DataGridView2.Rows(i).Cells(z).Value
            Next
            sql = "update Shop.ShopStock set Stock = " + StrArray3(1) + "where MenuName = '" + StrArray3(0) + "'" + "and ShopID = '" + frm_Main.ShopID + "'"
            'ShopUnitSales 테이블에 데이터를 저장한다. 
            conn.ExeSQL(Sql)
        Next

        conn.Close()

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()

        frm_Main.GridVIew_Stock()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frm_Stock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql As String
        Dim conn As New DBconn() '따로 만들어 둔 인스턴스 생성
        Dim ds As New DataSet() '데이터셋 생성
        Dim dt As DataTable


        sql = "Select MenuName, Stock from Shop.ShopStock where ShopID = '" + frm_Main.ShopID + "'"
        '해당 연월일에 자료가 있는지 검색하는 쿼리문
        conn.Open()
        ds = conn.ExeDataSet(Sql) '조건에 맞는 자료들을 데이터셋에 저장
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

    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim strArray(1) As String

        For a = 0 To DataGridView1.ColumnCount - 1
            Try
                strArray(a) = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex + a).Value
            Catch ex As Exception
                MsgBox("메뉴명을 클릭하세요.")
                Exit Sub
            End Try
        Next

        Dim z As Integer
        For z = 0 To DataGridView1.Rows.Count - 1
            If strArray1(z) Like DataGridView1.Rows(e.RowIndex).Cells(0).Value Then 'strArray1에 선택된 메뉴가 있는지 확인
                MsgBox(strArray1(z))
                strArray = Nothing '이미 추가가 된 메뉴가 선택 되었다면 DataGridView2에 같은 메뉴를 추가 하지 않는다
                Exit For
            ElseIf strArray1(z) <> Nothing Then
            Else
                strArray1(z) = DataGridView1.Rows(e.RowIndex).Cells(0).Value
                strArray(1) = 0
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

End Class
