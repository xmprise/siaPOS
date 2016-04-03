Imports System.Windows.Forms
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Public Class menuAdd
    Private mlmageFile As Image
    Private mlmageFilePath As String
    Sub New()

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.

    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Try
            If (Me.txtImageFile.Text = String.Empty Or Me.txtTitle.Text = String.Empty) Then
                MsgBox("메뉴로 등록할 이미지 파일이 없습니다. 찾기 버튼을 눌러 그림을 등록해 주세요.", "메뉴 이름을 적어 주십시오", _
                       vbOKOnly)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, "bmp, gif, jpg 형식의 그림파일이 아닙니다.", vbOKOnly)
        End Try

        Dim fs As FileStream = New FileStream(mlmageFilePath.ToString, FileMode.Open)
        Dim img As Byte() = New Byte(fs.Length) {}
        fs.Read(img, 0, fs.Length)
        fs.Close()

        mlmageFile = Image.FromFile(mlmageFilePath.ToString())
        Dim imgHeight As Integer = mlmageFile.Height
        Dim imgWidth As Integer = mlmageFile.Width
        Dim imgLength As Integer = mlmageFile.PropertyItems.Length
        Dim imgType As String = Path.GetExtension(mlmageFilePath)
        mlmageFile = Nothing

        Dim strConnect As String
        strConnect = "Data Source=124.198.16.87,8000;Initial Catalog=SibalChk2011;User ID=jung;Password=!jwj2114!"
        Dim conn As SqlConnection = New SqlConnection(strConnect)

        Dim sSQL As String = "INSERT INTO Product.MenuInformation (ImageContent, " & _
                "MenuName, ImageType, ImageHeight, ImageWidth, MenuPrice) VALUES(" & _
                "@pic, @title, @itype, @iheight, @iwidth, @price)"
        '파라미터를 지정해주어 sql 쿼리로 넘긴다

        Dim cmd As SqlCommand = New SqlCommand(sSQL, conn)

        ' 이미지 파일
        Dim pic As SqlParameter = New SqlParameter("@pic", SqlDbType.Image)
        pic.Value = img
        cmd.Parameters.Add(pic)

        ' title
        Dim title As SqlParameter = New SqlParameter("@title", System.Data.SqlDbType.VarChar, 50)
        title.Value = txtTitle.Text.ToString()
        cmd.Parameters.Add(title)

        ' type
        Dim itype As SqlParameter = New SqlParameter("@itype", System.Data.SqlDbType.Char, 4)
        itype.Value = imgType.ToString()
        cmd.Parameters.Add(itype)

        ' height
        Dim iheight As SqlParameter = New SqlParameter("@iheight", System.Data.SqlDbType.Int)
        iheight.Value = imgHeight
        cmd.Parameters.Add(iheight)

        ' width
        Dim iwidth As SqlParameter = New SqlParameter("@iwidth", System.Data.SqlDbType.Int)
        iwidth.Value = imgWidth
        cmd.Parameters.Add(iwidth)

        'price
        Dim price As SqlParameter = New SqlParameter("@price", System.Data.SqlDbType.Int)
        price.Value = Integer.Parse(txtPrice.Text.ToString)
        cmd.Parameters.Add(price)

        Try
            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()
            MsgBox("정상적으로 등록 되었습니다.")
            Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "등록 실패")
            Exit Sub
        End Try
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFind.Click
        OpenFileDialog1.Title = "이미지 화일 찾기"
        OpenFileDialog1.Filter = "Bitmap Files|*.bmp" & _
            "|Gif Files|*.gif|JPEG Files|*.jpg"
        OpenFileDialog1.DefaultExt = "bmp"
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.ShowDialog()

        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        Dim sFilePath As String
        sFilePath = OpenFileDialog1.FileName
        If sFilePath = "" Then Exit Sub

        If System.IO.File.Exists(sFilePath) = False Then
            Exit Sub
        Else
            txtImageFile.Text = sFilePath
            mlmageFilePath = sFilePath
        End If
    End Sub
End Class
