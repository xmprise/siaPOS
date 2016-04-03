Public Class MdiDays
    Public WithEvents cWin As StickyWindow
    Dim iYear As Integer
    Dim iMonth As Integer
    Public Acounts As Boolean = False
    Public picture As Label
    Public Sub New() 'ByVal iYear As Integer, ByVal iMonth As Integer)
        InitializeComponent()
        'Me.iYear = iYear '년도값을 받는다
        'Me.iMonth = iMonth '월값을 받는다

    End Sub

    Private Sub IvSchzle_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles IvSchzle.MouseDown
        If e.Button = System.Windows.Forms.MouseButtons.Left Then
            If e.Y >= 0 And e.Y <= Me.Pic2.Height Then
                Dim ptMove As Point = New Point(PointToScreen(e.Location))

                Win32.SendMessage(Me.Handle, Win32.WM.WM_NCLBUTTONDOWN, Win32.HT.HTCAPTION, Win32.Bit.MakeLParam(ptMove.X, ptMove.Y))
                
            End If
        End If
    End Sub

    Private Sub IvSchzle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IvSchzle.SelectedIndexChanged
        'Dim iItem As ListViewItem '리스트뷰 아이템 생성
        'If IvSchzle.Items(0).Selected = True Then 'New를 선택했다면
        'Dim sche As New ScheduleLIst(iYear, iMonth, Integer.Parse(Me.Text), True) '인스턴스 생성
        'sche.ShowDialog() '창을 띄워준다
        'If sche.AddNum = 1 Then '오류
        'IvSchzle.Items.Add(sche.nudHour.Value.ToString() + ":" + sche.nudMinute.Value.ToString())
        'End If
        'ElseIf IvSchzle.SelectedItems.Count = 0 Then '아무것도 선택되지 않았다면
        'Return '리턴
        'Else '무언가 선택되었다면
        'iItem = IvSchzle.SelectedItems(0) '선택된 리스트 아이템을 받는다
        'Dim sche As New ScheduleLIst(iYear, iMonth, Integer.Parse(Me.Text), False) '인스턴스 생성
        'sche.GetHour = Integer.Parse(iItem.Text.Substring(0, iItem.Text.IndexOf(":"))) '시간값 설정
        'sche.GetMin = Integer.Parse(iItem.Text.Substring(iItem.Text.IndexOf(":") + 1)) '분값 설정
        'sche.ShowDialog() '창을 띄어준다
        'If sche.AddNum = 2 Then '수정 했다면
        ' iItem.Text = sche.TakeHour + ":" + sche.TakeMin '리스트의 시간을 수정한다
        'ElseIf sche.AddNum = 3 Then '삭제했다면
        'iItem.Remove() '해당 리스트 삭제
        'End If
        'End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim frm5 As New frm_Order()
        Dim dialog As New frm_Account()

        If Acounts = False Then
            frm5.Text = Me.Text.ToString + " 번 테이블 주문"
            frm5.ShowDialog()
        ElseIf Acounts = True Then
            dialog.Text = Me.Text.ToString + " 번 테이블 계산"
            dialog.ShowDialog()
        End If
    End Sub

    Private Sub MdiDays_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cWin = New StickyWindow(Me)
        With cWin
            .StickGap = 10
            .StickToOther = True
        End With
        Label1.Parent = PictureBox1
        Label1.BackColor = Color.Transparent

    End Sub

    Private Sub Pic2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Pic2.MouseDown
        Call IvSchzle_MouseDown(Me, e)
    End Sub

    Public Sub pic(ByVal int As Integer)
        Dim row, col As Integer
        col = 4
        row = 0

        For i = 1 To int
            picture = New System.Windows.Forms.Label()

            If (i Mod 4 = 1) Then
                row += 24
                col = 4
            Else
                col += 24
            End If

            picture.BringToFront()
            picture.SetBounds(col, row, 24, 24)
            picture.Name = "pic" + i.ToString
            'picture.Size = New System.Drawing.Point(24, 24)
            picture.Image = Image.FromFile("D:\지우기\SiaPOS_POS\SiaPOS_POS\WindowsApplication2\1325088983_chicken.png")
            picture.BackColor = Color.DarkOrange
            Controls.Add(picture)
        Next
        Panel1.SendToBack()
    End Sub
    Public Sub endPic(ByVal int As Integer)
        For i = 1 To int
            Controls.Item("pic" + i.ToString).Dispose()
        Next

    End Sub
End Class