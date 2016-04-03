Imports System.IO
Public Class frm_Main
    Dim iDayCount As Integer = 0 '일 변수 생성
    Dim iBorderStyle As Boolean = False
    Dim reLocation As Boolean = False
    Dim iRowCounts(MdiChildren.Length) As Integer
    Dim iColsCounts(MdiChildren.Length) As Integer
    Dim tempKey As Microsoft.Win32.Registry
    Dim registryObject As Microsoft.Win32.RegistryKey = Nothing
    Dim existBoolean As Boolean = False
    Public ShopID As String
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: 이 코드는 데이터를 'SibalChk2011DataSet.ShopStock' 테이블에 로드합니다. 필요한 경우 이 코드를 이동하거나 제거할 수 있습니다.
        init()
        ReDim iRowCounts(MdiChildren.Length)
        ReDim iColsCounts(MdiChildren.Length)

        If System.IO.File.Exists("iRowCounts.txt") Then 'MDI폼의 Y값을 가져온다
            Dim objReader As StreamReader = New StreamReader("iRowCounts.txt")
            Dim strTxt As String = objReader.ReadToEnd()
            objReader.Close()
            Dim arrTxt() As String
            arrTxt = strTxt.Split("a")
            For i = 0 To iDayCount - 1
                iRowCounts(i) = arrTxt(i)
            Next
        End If

        If System.IO.File.Exists("iColsCounts.txt") Then 'MDI폼의 X값을 
            Dim objReader As StreamReader = New StreamReader("iColsCounts.txt")
            Dim strTxt As String = objReader.ReadToEnd()
            objReader.Close()
            Dim arrTxt() As String
            arrTxt = strTxt.Split("a")
            For i = 0 To iDayCount - 1
                iColsCounts(i) = arrTxt(i)
            Next
            reLocation = True
            For i = 0 To Me.MdiChildren.Length - 1
                Me.MdiChildren(0).Close() '처음 생성된 MDI폼을 모두 닫는다
            Next
            init()
        End If

        GridVIew_Stock()
        Me.MdiParent.BackColor = Color.Brown

    End Sub

    Private Sub menu_shoptable_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menu_shoptable.Click
        Dim shop As New ShopTable()
        shop.ShowDialog()
    End Sub

    Public Sub init()
        Dim iRowCount As Integer = -1 '가로 변수
        Dim iColsCount As Integer = -100 '세로 변수
        Dim sql As String
        Dim conn As New DBconn() '따로 만들어 둔 인스턴스 생성
        Dim ds As New DataSet() '데이터셋 생성
        Dim dt As DataTable

        'If (iDayCount <> 0) Then '처음 버튼 클릭이 아니라면
        'For i As Integer = 0 To iDayCount - 1
        'MdiChildren(0).Close() '예전 자식창들을 닫는다
        'Next i
        'End If

        'sql = "select ShopTableNumber from ShopTable where ModifyTableNumber = (select MAX(ModifyTableNumber) from ShopTable);"
        sql = "select ShopTableAccount from Person.MemberShop where UserName = '" + ShopID + "'"
        conn.Open() 'db 연결
        ds = conn.ExeDataSet(sql)
        dt = ds.Tables.Item(0)

        Dim rws As DataRowCollection = dt.Rows
        Dim rw As DataRow

        For Each rw In rws
            iDayCount = Integer.Parse(rw.Item("ShopTableAccount").ToString)
            'DateTime.DaysInMonth(Integer.Parse(Calendar.TodayDate.Year), Integer.Parse(Calendar.TodayDate.Month))
            '달과 년도값을 받아 일수를 받는다
        Next

        For i As Integer = 1 To iDayCount
            Dim Days As New MdiDays() '자식창 생성

            If iBorderStyle = True Then '새로운 폼 배치를 했을때
                Days.Pic2.Visible = True
                Days.Button1.Enabled = False
            End If


            If existBoolean = False Then
                If (i Mod 8 = 1) Then '8번째 창이 뜨면
                    iRowCount += 1 '가로줄을 바꿔준다
                    iColsCount = 0 '세로위치를 처음으로 옮겨준다
                Else '그 외에
                    iColsCount += 143 '세로위치를 우측으로 옮겨준다
                End If
            End If

            If reLocation = False Then
                With Days
                    .Name = "frm" + i.ToString()  '이름 지정
                    .Text = i.ToString() '텍스트값 지정
                    .Button1.Text = i.ToString() + " 번 테이블"
                    .MdiParent = Me '부모창을 생성해준다
                    .Show() '창을 띄운다
                    .SetDesktopLocation(iColsCount, iRowCount * 143) '띄우는 위치를 설정해준다

                End With
            Else
                With Days
                    .Name = "frm" + i.ToString()  '이름 지정
                    .Text = i.ToString() '텍스트값 지정
                    .Button1.Text = i.ToString() + " 번 테이블"
                    .MdiParent = Me '부모창을 생성해준다
                    .Show() '창을 띄운다
                    .SetDesktopLocation(iColsCounts(i - 1), iRowCounts(i - 1)) '띄우는 위치를 설정해준다 

                End With
            End If


            'sql = "select Sale from ShopUnitSales where TableNumber = " + i.ToString
            'sql = "Select ShopAccountID from Shop.TempShopAccount where ShopID = '" + ShopID + "'" + "and TableNumber = " + i.ToString
            sql = "Select SUM(MenuAccount) from Shop.TempShopAccount where ShopID = '" + ShopID + "' and TableNumber = " + i.ToString + "group by TableNumber"
            '해당 연월일에 자료가 있는지 검색하는 쿼리문

            ds = conn.ExeDataSet(sql) '조건에 맞는 자료들을 데이터셋에 저장
            dt = ds.Tables.Item(0)
            Dim rows As DataRowCollection = dt.Rows
            Dim row As DataRow

            'Sale 열에 값이 들어 있으면 
            For Each row In rows
                Dim ints As String = row.Item(0)
                Days.Acounts = True
                Days.Button1.BackColor = Color.DarkOrange
                Days.PictureBox1.BackColor = Color.Yellow
                Days.Label1.Text = "주문상태"
                Days.pic(Integer.Parse(ints))
            Next
            'dt = ds.Tables.Item(0) '데이터셋의 맨처음 테이블을 꺼낸다
            'Dim rows As DataRowCollection = dt.Rows
            'Dim row As DataRow
            'For Each row In rows '로우값을 하나씩 빼내서
            'Days.IvSchzle.Items.Add(row.Item("시").ToString() + ":" + row.Item("분").ToString())
            '리스트뷰에 추가한다
            'Next
        Next i

        conn.Close()

    End Sub

    Private Sub menuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItem.Click
        Dim addMenu As New menuAdd()
        addMenu.ShowDialog()
    End Sub

    Private Sub picture_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles picture.Click

    End Sub

    Private Sub pic2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic2.Click
        Dim frm5 As New frm_Order()
        frm5.ShowDialog()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOrder.Click
        Dim log1 As New Login("재료주문")

        log1.ShowDialog()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccount.Click
        Dim dia4 As New frm_Total("매장정산")

        dia4.ShowDialog()
        
    End Sub

    Private Sub menu_ShopAdjust_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menu_ShopAdjust.Click
        MsgBox("매장 내 테이블 배치를 설정 할 수 있습니다.", Nothing, "SibalCHK POS.System")

        MdiDays.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle

        For i = 0 To iDayCount - 1
            MdiChildren(0).Close()
        Next
        iBorderStyle = True

        Me.btnTabel.Visible = True
        Me.btnTabel.Enabled = True

        init() '버그: 두번 이상 매장 배치 기능을 실행할 경우 테이블이 하나씩 사라짐. 배열 문제일 것임

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTabel.Click
        Me.btnTabel.Enabled = False
        Me.btnTabel.Visible = False

        For i = 0 To MdiChildren.Length - 1 '생성된 MDI폼 만큼 반복
            iRowCounts(i) = MdiChildren(0).Location.Y 'MDI폼 배열의 첫번째 폼의 위치 Row(y)반환
            iColsCounts(i) = MdiChildren(0).Location.X 'MDI폼 배열의 첫번째 폼의 위치 Colum(x)반환

            MdiChildren(0).Close() 'MdiChildren이 i가 아니고 0인 이유는 Mdi폼 배열에서 MdiChildren을 하나씩 닫기 때문에
        Next
        reLocation = True
        iBorderStyle = False

        init()

        'If My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\SibalCHK", "SibalCHK", Nothing) Is Nothing Then
        'MsgBox("값이 없습니다.")
        'End If http://msdn.microsoft.com/ko-kr/library/kw24csw0.aspx

        Dim objWriterRow As StreamWriter = New StreamWriter("iRowCounts.txt")
        Dim strRow As String = ""
        For a As Integer = 0 To iRowCounts.Length - 1
            strRow &= IIf(strRow = "", "", "a") & iRowCounts(a)
        Next
        objWriterRow.Write(strRow)
        objWriterRow.Close()

        Dim objWriterCol As StreamWriter = New StreamWriter("iColsCounts.txt")
        Dim strCol As String = ""
        For b As Integer = 0 To iColsCounts.Length - 1
            strCol &= IIf(strCol = "", "", "a") & iColsCounts(b)
        Next
        objWriterCol.Write(strCol)
        objWriterCol.Close()

        '각 MDI폼의 위치를 Counts.txt에 저장 

        MsgBox("테이블 배치를 완료 합니다.", Nothing, "SibalCHK POS.System")
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCasherOpen.Click
        MsgBox("돈통을 엽니다.")
    End Sub

    Private Sub menu_End_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menu_End.Click
        MsgBox("프로그램을 종료 합니다. 정산되지 않은 테이블의 기록은 보존 됩니다.")
        Try
            End
        Catch
        End Try

    End Sub

    Private Sub men_ShopStock_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles men_ShopStock.Click
        Dim frmStock As New frm_Stock("매장 재고")
        frmStock.ShowDialog()

    End Sub

    Public Sub GridVIew_Stock()
        Dim sql As String
        Dim conn As New DBconn() '따로 만들어 둔 인스턴스 생성
        Dim ds As New DataSet() '데이터셋 생성
        Dim dt As DataTable


        sql = "Select MenuName, Stock from Shop.ShopStock where ShopID = '" + Me.ShopID + "'"
        '해당 연월일에 자료가 있는지 검색하는 쿼리문
        conn.Open()
        ds = conn.ExeDataSet(sql) '조건에 맞는 자료들을 데이터셋에 저장
        dt = ds.Tables.Item(0)
        Dim rows As DataRowCollection = dt.Rows
        Dim row As DataRow
        Dim cols As DataColumnCollection = dt.Columns
        Dim arrRow(cols.Count) As String


        conn.Close()

        DataGridView2.Rows.Clear()

        For Each row In rows
            For j = 0 To cols.Count - 1
                arrRow(j) = row.Item(j)
            Next
            DataGridView2.Rows.Add(arrRow)
        Next
    End Sub

    Private Sub Panel3_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub
End Class
