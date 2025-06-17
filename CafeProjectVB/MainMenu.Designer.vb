<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainMenu
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
        Me.tableBtn = New System.Windows.Forms.Button()
        Me.inventoryBtn = New System.Windows.Forms.Button()
        Me.settingsBtn = New System.Windows.Forms.Button()
        Me.signoutBtn = New System.Windows.Forms.Button()
        Me.exitBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'tableBtn
        '
        Me.tableBtn.Location = New System.Drawing.Point(37, 38)
        Me.tableBtn.Name = "tableBtn"
        Me.tableBtn.Size = New System.Drawing.Size(124, 62)
        Me.tableBtn.TabIndex = 0
        Me.tableBtn.Text = "Table Reservation"
        Me.tableBtn.UseVisualStyleBackColor = True
        '
        'inventoryBtn
        '
        Me.inventoryBtn.Location = New System.Drawing.Point(37, 106)
        Me.inventoryBtn.Name = "inventoryBtn"
        Me.inventoryBtn.Size = New System.Drawing.Size(124, 62)
        Me.inventoryBtn.TabIndex = 1
        Me.inventoryBtn.Text = "Inventory"
        Me.inventoryBtn.UseVisualStyleBackColor = True
        '
        'settingsBtn
        '
        Me.settingsBtn.Location = New System.Drawing.Point(37, 174)
        Me.settingsBtn.Name = "settingsBtn"
        Me.settingsBtn.Size = New System.Drawing.Size(124, 62)
        Me.settingsBtn.TabIndex = 2
        Me.settingsBtn.Text = "Settings"
        Me.settingsBtn.UseVisualStyleBackColor = True
        '
        'signoutBtn
        '
        Me.signoutBtn.Location = New System.Drawing.Point(37, 242)
        Me.signoutBtn.Name = "signoutBtn"
        Me.signoutBtn.Size = New System.Drawing.Size(124, 62)
        Me.signoutBtn.TabIndex = 3
        Me.signoutBtn.Text = "Sign Out"
        Me.signoutBtn.UseVisualStyleBackColor = True
        '
        'exitBtn
        '
        Me.exitBtn.Location = New System.Drawing.Point(12, 391)
        Me.exitBtn.Name = "exitBtn"
        Me.exitBtn.Size = New System.Drawing.Size(86, 47)
        Me.exitBtn.TabIndex = 4
        Me.exitBtn.Text = "Exit"
        Me.exitBtn.UseVisualStyleBackColor = True
        '
        'MainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.exitBtn)
        Me.Controls.Add(Me.signoutBtn)
        Me.Controls.Add(Me.settingsBtn)
        Me.Controls.Add(Me.inventoryBtn)
        Me.Controls.Add(Me.tableBtn)
        Me.Name = "MainMenu"
        Me.Text = "MainMenu"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tableBtn As Button
    Friend WithEvents inventoryBtn As Button
    Friend WithEvents settingsBtn As Button
    Friend WithEvents signoutBtn As Button
    Friend WithEvents exitBtn As Button
End Class
