<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Main
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기를 사용하여 수정하지 마십시오.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Main))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.menu_managemet = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_shoptable = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_ShopAdjust = New System.Windows.Forms.ToolStripMenuItem()
        Me.men_ShopStock = New System.Windows.Forms.ToolStripMenuItem()
        Me.DevMenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.picture = New System.Windows.Forms.ToolStripMenuItem()
        Me.pic2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.프로그램ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_End = New System.Windows.Forms.ToolStripMenuItem()
        Me.Calendar = New System.Windows.Forms.MonthCalendar()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnTabel = New System.Windows.Forms.Button()
        Me.btnOrder = New System.Windows.Forms.Button()
        Me.btnAccount = New System.Windows.Forms.Button()
        Me.btnCasherOpen = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 24)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(794, 12)
        Me.Panel1.TabIndex = 5
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menu_managemet, Me.DevMenuToolStripMenuItem, Me.프로그램ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(794, 24)
        Me.MenuStrip1.TabIndex = 7
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'menu_managemet
        '
        Me.menu_managemet.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menu_shoptable, Me.menu_ShopAdjust, Me.men_ShopStock})
        Me.menu_managemet.Name = "menu_managemet"
        Me.menu_managemet.Size = New System.Drawing.Size(43, 20)
        Me.menu_managemet.Text = "관리"
        '
        'menu_shoptable
        '
        Me.menu_shoptable.Name = "menu_shoptable"
        Me.menu_shoptable.Size = New System.Drawing.Size(246, 22)
        Me.menu_shoptable.Text = "매장 테이블을 수를 수정 합니다"
        '
        'menu_ShopAdjust
        '
        Me.menu_ShopAdjust.Name = "menu_ShopAdjust"
        Me.menu_ShopAdjust.Size = New System.Drawing.Size(246, 22)
        Me.menu_ShopAdjust.Text = "매장 테이블 배치를 조정 합니다"
        '
        'men_ShopStock
        '
        Me.men_ShopStock.Name = "men_ShopStock"
        Me.men_ShopStock.Size = New System.Drawing.Size(246, 22)
        Me.men_ShopStock.Text = "매장의 현재 재고를 수정 합니다"
        '
        'DevMenuToolStripMenuItem
        '
        Me.DevMenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuItem, Me.picture, Me.pic2})
        Me.DevMenuToolStripMenuItem.Name = "DevMenuToolStripMenuItem"
        Me.DevMenuToolStripMenuItem.Size = New System.Drawing.Size(74, 20)
        Me.DevMenuToolStripMenuItem.Text = "dev_Menu"
        '
        'menuItem
        '
        Me.menuItem.Name = "menuItem"
        Me.menuItem.Size = New System.Drawing.Size(126, 22)
        Me.menuItem.Text = "메뉴 설정"
        '
        'picture
        '
        Me.picture.Name = "picture"
        Me.picture.Size = New System.Drawing.Size(126, 22)
        Me.picture.Text = "그림"
        '
        'pic2
        '
        Me.pic2.Name = "pic2"
        Me.pic2.Size = New System.Drawing.Size(126, 22)
        Me.pic2.Text = "그림2"
        '
        '프로그램ToolStripMenuItem
        '
        Me.프로그램ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menu_End})
        Me.프로그램ToolStripMenuItem.Name = "프로그램ToolStripMenuItem"
        Me.프로그램ToolStripMenuItem.Size = New System.Drawing.Size(67, 20)
        Me.프로그램ToolStripMenuItem.Text = "프로그램"
        '
        'menu_End
        '
        Me.menu_End.Name = "menu_End"
        Me.menu_End.Size = New System.Drawing.Size(98, 22)
        Me.menu_End.Text = "종료"
        '
        'Calendar
        '
        Me.Calendar.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.Calendar.Name = "Calendar"
        Me.Calendar.TabIndex = 8
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(112, 615)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(103, 69)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "자리 합석"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnTabel
        '
        Me.btnTabel.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.btnTabel.Enabled = False
        Me.btnTabel.Location = New System.Drawing.Point(5, 539)
        Me.btnTabel.Name = "btnTabel"
        Me.btnTabel.Size = New System.Drawing.Size(103, 69)
        Me.btnTabel.TabIndex = 10
        Me.btnTabel.Text = "배치 완료"
        Me.btnTabel.UseVisualStyleBackColor = False
        Me.btnTabel.Visible = False
        '
        'btnOrder
        '
        Me.btnOrder.Location = New System.Drawing.Point(5, 615)
        Me.btnOrder.Name = "btnOrder"
        Me.btnOrder.Size = New System.Drawing.Size(103, 69)
        Me.btnOrder.TabIndex = 8
        Me.btnOrder.Text = "자리 이동"
        Me.btnOrder.UseVisualStyleBackColor = True
        '
        'btnAccount
        '
        Me.btnAccount.Location = New System.Drawing.Point(112, 540)
        Me.btnAccount.Name = "btnAccount"
        Me.btnAccount.Size = New System.Drawing.Size(103, 69)
        Me.btnAccount.TabIndex = 7
        Me.btnAccount.Text = "매장 정산"
        Me.btnAccount.UseVisualStyleBackColor = True
        '
        'btnCasherOpen
        '
        Me.btnCasherOpen.Location = New System.Drawing.Point(4, 540)
        Me.btnCasherOpen.Name = "btnCasherOpen"
        Me.btnCasherOpen.Size = New System.Drawing.Size(103, 69)
        Me.btnCasherOpen.TabIndex = 11
        Me.btnCasherOpen.Text = "돈통 열기"
        Me.btnCasherOpen.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Panel2.Controls.Add(Me.btnTabel)
        Me.Panel2.Controls.Add(Me.btnCasherOpen)
        Me.Panel2.Controls.Add(Me.btnAccount)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.DataGridView2)
        Me.Panel2.Controls.Add(Me.btnOrder)
        Me.Panel2.Controls.Add(Me.DataGridView1)
        Me.Panel2.Controls.Add(Me.Calendar)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(576, 36)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(218, 631)
        Me.Panel2.TabIndex = 13
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(31, 371)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(161, 138)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.AllowUserToResizeColumns = False
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2})
        Me.DataGridView2.Location = New System.Drawing.Point(0, 163)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.RowTemplate.Height = 23
        Me.DataGridView2.Size = New System.Drawing.Size(217, 179)
        Me.DataGridView2.TabIndex = 10
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column1.HeaderText = "메뉴명"
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column2.HeaderText = "수량"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.EnableHeadersVisualStyles = False
        Me.DataGridView1.Location = New System.Drawing.Point(0, 163)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.Size = New System.Drawing.Size(222, 179)
        Me.DataGridView1.TabIndex = 9
        '
        'frm_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(794, 667)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Main"
        Me.Text = "SiaPOS  매장 관리 시스템"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents menu_managemet As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Calendar As System.Windows.Forms.MonthCalendar
    Friend WithEvents menu_shoptable As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DevMenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents picture As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pic2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnOrder As System.Windows.Forms.Button
    Friend WithEvents btnAccount As System.Windows.Forms.Button
    Friend WithEvents menu_ShopAdjust As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnTabel As System.Windows.Forms.Button
    Friend WithEvents btnCasherOpen As System.Windows.Forms.Button
    Friend WithEvents 프로그램ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu_End As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents men_ShopStock As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox

End Class
