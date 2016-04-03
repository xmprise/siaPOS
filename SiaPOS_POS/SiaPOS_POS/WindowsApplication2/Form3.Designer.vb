<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ScheduleLIst
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.nudHour = New System.Windows.Forms.NumericUpDown()
        Me.nudMinute = New System.Windows.Forms.NumericUpDown()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtContent = New System.Windows.Forms.TextBox()
        Me.btnEditFin = New System.Windows.Forms.Button()
        CType(Me.nudHour, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudMinute, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "시간:"
        '
        'nudHour
        '
        Me.nudHour.Location = New System.Drawing.Point(72, 12)
        Me.nudHour.Name = "nudHour"
        Me.nudHour.Size = New System.Drawing.Size(40, 21)
        Me.nudHour.TabIndex = 2
        '
        'nudMinute
        '
        Me.nudMinute.Location = New System.Drawing.Point(133, 12)
        Me.nudMinute.Name = "nudMinute"
        Me.nudMinute.Size = New System.Drawing.Size(35, 21)
        Me.nudMinute.TabIndex = 3
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(3, 154)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 23)
        Me.btnEdit.TabIndex = 5
        Me.btnEdit.Text = "수정"
        Me.btnEdit.UseVisualStyleBackColor = True
        Me.btnEdit.Visible = False
        '
        'btnDelete
        '
        Me.btnDelete.Enabled = False
        Me.btnDelete.Location = New System.Drawing.Point(93, 154)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 6
        Me.btnDelete.Text = "삭제"
        Me.btnDelete.UseVisualStyleBackColor = True
        Me.btnDelete.Visible = False
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(93, 154)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "저장"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(118, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(9, 12)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = ":"
        '
        'txtContent
        '
        Me.txtContent.Location = New System.Drawing.Point(3, 39)
        Me.txtContent.Multiline = True
        Me.txtContent.Name = "txtContent"
        Me.txtContent.Size = New System.Drawing.Size(165, 109)
        Me.txtContent.TabIndex = 9
        '
        'btnEditFin
        '
        Me.btnEditFin.Location = New System.Drawing.Point(3, 154)
        Me.btnEditFin.Name = "btnEditFin"
        Me.btnEditFin.Size = New System.Drawing.Size(75, 23)
        Me.btnEditFin.TabIndex = 10
        Me.btnEditFin.Text = "수정완료"
        Me.btnEditFin.UseVisualStyleBackColor = True
        Me.btnEditFin.Visible = False
        '
        'ScheduleLIst
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(172, 181)
        Me.Controls.Add(Me.btnEditFin)
        Me.Controls.Add(Me.txtContent)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.nudMinute)
        Me.Controls.Add(Me.nudHour)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ScheduleLIst"
        Me.Text = "스케줄작성"
        CType(Me.nudHour, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudMinute, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nudHour As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudMinute As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtContent As System.Windows.Forms.TextBox
    Friend WithEvents btnEditFin As System.Windows.Forms.Button
End Class
