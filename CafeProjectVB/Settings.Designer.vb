<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dgvUsers = New System.Windows.Forms.DataGridView()
        Me.searchBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.resetDbBtn = New System.Windows.Forms.Button()
        Me.changeDbBtn = New System.Windows.Forms.Button()
        Me.editUserBtn = New System.Windows.Forms.Button()
        Me.addUserbtn = New System.Windows.Forms.Button()
        Me.deleteUserBtn = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.checkedTables = New System.Windows.Forms.CheckedListBox()
        CType(Me.dgvUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvUsers
        '
        Me.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUsers.Location = New System.Drawing.Point(215, 114)
        Me.dgvUsers.Name = "dgvUsers"
        Me.dgvUsers.RowHeadersWidth = 62
        Me.dgvUsers.RowTemplate.Height = 28
        Me.dgvUsers.Size = New System.Drawing.Size(290, 223)
        Me.dgvUsers.TabIndex = 0
        '
        'searchBox
        '
        Me.searchBox.Location = New System.Drawing.Point(215, 82)
        Me.searchBox.Name = "searchBox"
        Me.searchBox.Size = New System.Drawing.Size(198, 26)
        Me.searchBox.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(211, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Search Users :"
        '
        'resetDbBtn
        '
        Me.resetDbBtn.Location = New System.Drawing.Point(16, 170)
        Me.resetDbBtn.Name = "resetDbBtn"
        Me.resetDbBtn.Size = New System.Drawing.Size(151, 55)
        Me.resetDbBtn.TabIndex = 3
        Me.resetDbBtn.Text = "Reset Database"
        Me.resetDbBtn.UseVisualStyleBackColor = True
        '
        'changeDbBtn
        '
        Me.changeDbBtn.Location = New System.Drawing.Point(12, 381)
        Me.changeDbBtn.Name = "changeDbBtn"
        Me.changeDbBtn.Size = New System.Drawing.Size(151, 55)
        Me.changeDbBtn.TabIndex = 4
        Me.changeDbBtn.Text = "Change Database"
        Me.changeDbBtn.UseVisualStyleBackColor = True
        '
        'editUserBtn
        '
        Me.editUserBtn.Location = New System.Drawing.Point(511, 134)
        Me.editUserBtn.Name = "editUserBtn"
        Me.editUserBtn.Size = New System.Drawing.Size(151, 55)
        Me.editUserBtn.TabIndex = 5
        Me.editUserBtn.Text = "Edit User"
        Me.editUserBtn.UseVisualStyleBackColor = True
        '
        'addUserbtn
        '
        Me.addUserbtn.Location = New System.Drawing.Point(289, 343)
        Me.addUserbtn.Name = "addUserbtn"
        Me.addUserbtn.Size = New System.Drawing.Size(151, 55)
        Me.addUserbtn.TabIndex = 6
        Me.addUserbtn.Text = "Add User"
        Me.addUserbtn.UseVisualStyleBackColor = True
        '
        'deleteUserBtn
        '
        Me.deleteUserBtn.Location = New System.Drawing.Point(511, 195)
        Me.deleteUserBtn.Name = "deleteUserBtn"
        Me.deleteUserBtn.Size = New System.Drawing.Size(151, 55)
        Me.deleteUserBtn.TabIndex = 7
        Me.deleteUserBtn.Text = "Delete User"
        Me.deleteUserBtn.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(182, 20)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Select Tables To Reset :"
        '
        'checkedTables
        '
        Me.checkedTables.CheckOnClick = True
        Me.checkedTables.FormattingEnabled = True
        Me.checkedTables.Location = New System.Drawing.Point(16, 45)
        Me.checkedTables.Name = "checkedTables"
        Me.checkedTables.Size = New System.Drawing.Size(178, 119)
        Me.checkedTables.TabIndex = 9
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.checkedTables)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.deleteUserBtn)
        Me.Controls.Add(Me.addUserbtn)
        Me.Controls.Add(Me.editUserBtn)
        Me.Controls.Add(Me.changeDbBtn)
        Me.Controls.Add(Me.resetDbBtn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.searchBox)
        Me.Controls.Add(Me.dgvUsers)
        Me.Name = "Settings"
        Me.Text = "Settings"
        CType(Me.dgvUsers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvUsers As DataGridView
    Friend WithEvents searchBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents resetDbBtn As Button
    Friend WithEvents changeDbBtn As Button
    Friend WithEvents editUserBtn As Button
    Friend WithEvents addUserbtn As Button
    Friend WithEvents deleteUserBtn As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents checkedTables As CheckedListBox
End Class
