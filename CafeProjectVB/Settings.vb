Imports System.Data.SqlClient

Public Class Settings




    Private Sub resetDbBtn_Click(sender As Object, e As EventArgs) Handles resetDbBtn.Click
        ' Collect all checked tables
        Dim selectedTables As New List(Of String)
        For Each item As Object In checkedTables.CheckedItems
            selectedTables.Add(item.ToString())
        Next

        If selectedTables.Count = 0 Then
            MessageBox.Show("Please select at least one table to reset.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Confirm reset action
        Dim confirmMsg = "Are you sure you want to reset the following tables?" & Environment.NewLine &
                     String.Join(", ", selectedTables)
        Dim confirm = MessageBox.Show(confirmMsg, "Confirm Reset Database", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If confirm <> DialogResult.Yes Then Return

        ' Backup the database before resetting
        If Not BackupDatabase() Then
            MessageBox.Show("Backup failed. Reset operation canceled.", "Backup Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Using cn As New SqlConnection(My.Settings.CafeDB)
                cn.Open()

                Using tran = cn.BeginTransaction()
                    Try
                        For Each tbl As String In selectedTables
                            ' Execute delete/reset command for each selected table
                            Dim sql = $"DELETE FROM [{tbl}];"

                            Using cmd As New SqlCommand(sql, cn, tran)
                                cmd.ExecuteNonQuery()
                            End Using
                        Next

                        tran.Commit()
                    Catch ex As Exception
                        tran.Rollback()
                        MessageBox.Show("Error resetting database: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End Try
                End Using
            End Using

            MessageBox.Show("Selected tables have been reset successfully.", "Reset Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadUsers() ' Reload users if Users table was reset
        Catch ex As Exception
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvUsers.ReadOnly = True
        dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvUsers.MultiSelect = False
        dgvUsers.AllowUserToAddRows = False
        checkedTables.Items.Clear()
        checkedTables.Items.Add("Reservations")
        checkedTables.Items.Add("Orders")
        checkedTables.Items.Add("Inventory")
        checkedTables.Items.Add("Users")
        LoadUsers()
    End Sub

    Private Sub dgvUsers_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsers.CellContentClick

    End Sub
    Private Sub addUserbtn_Click(sender As Object, e As EventArgs) Handles addUserbtn.Click
        Dim username = InputBox("Enter new username:", "Add User")
        If String.IsNullOrWhiteSpace(username) Then
            MessageBox.Show("Username cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim password = InputBox("Enter password for user:", "Add User")
        If String.IsNullOrWhiteSpace(password) Then
            MessageBox.Show("Password cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim role = InputBox("Enter role (Admin or Staff):", "Add User")
        role = role.Trim()
        If role.ToLower() <> "admin" AndAlso role.ToLower() <> "staff" Then
            MessageBox.Show("Role must be 'Admin' or 'Staff'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        role = If(role.ToLower() = "admin", "Admin", "Staff")

        Dim hashedPassword = password.ComputeSha256()

        Dim checkSql = "SELECT COUNT(*) FROM Users WHERE Username = @username"
        Dim insertSql = "INSERT INTO Users (Username, PasswordHash, Role) VALUES (@username, @passwordHash, @role)"

        Try
            Using cn As New SqlConnection(My.Settings.CafeDB)
                cn.Open()

                ' Check if username exists
                Using cmdCheck As New SqlCommand(checkSql, cn)
                    cmdCheck.Parameters.AddWithValue("@username", username)
                    Dim exists = CInt(cmdCheck.ExecuteScalar()) > 0
                    If exists Then
                        MessageBox.Show("Username already exists.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If
                End Using

                ' Insert new user
                Using cmdInsert As New SqlCommand(insertSql, cn)
                    cmdInsert.Parameters.AddWithValue("@username", username)
                    cmdInsert.Parameters.AddWithValue("@passwordHash", hashedPassword)
                    cmdInsert.Parameters.AddWithValue("@role", role)
                    cmdInsert.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("User added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadUsers() ' Refresh the user list
        Catch ex As Exception
            MessageBox.Show("Error adding user: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub editUserBtn_Click(sender As Object, e As EventArgs) Handles editUserBtn.Click

    End Sub
    Private Sub deleteUserBtn_Click(sender As Object, e As EventArgs) Handles deleteUserBtn.Click
        ' Check if a row is selected
        If dgvUsers.CurrentRow Is Nothing Then
            MessageBox.Show("Please select a user to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Get the UserId of the selected user
        Dim userId = CInt(dgvUsers.CurrentRow.Cells("UserId").Value)

        ' Prevent deletion of the default admin (assumed to have UserId = 1)
        If userId = 1 Then
            MessageBox.Show("You cannot delete the main Admin user.", "Action Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        ' Confirm deletion
        Dim confirm = MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirm <> DialogResult.Yes Then Return

        Dim sql = "DELETE FROM Users WHERE UserId = @userId"

        Try
            Using cn As New SqlConnection(My.Settings.CafeDB)
                Using cmd As New SqlCommand(sql, cn)
                    cmd.Parameters.AddWithValue("@userId", userId)
                    cn.Open()
                    Dim rowsAffected = cmd.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        MessageBox.Show("User deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LoadUsers()
                    Else
                        MessageBox.Show("User could not be deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error deleting user: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub searchBox_TextChanged(sender As Object, e As EventArgs) Handles searchBox.TextChanged
        Dim keyword = searchBox.Text.Trim()

        Dim sql = "SELECT UserId, Username, Role FROM Users WHERE Username LIKE @search ORDER BY Username"
        Dim dt As New DataTable()

        Try
            Using cn As New SqlConnection(My.Settings.CafeDB)
                Using cmd As New SqlCommand(sql, cn)
                    cmd.Parameters.AddWithValue("@search", "%" & keyword & "%")
                    cn.Open()
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        dt.Load(reader)
                    End Using
                End Using
            End Using

            dgvUsers.DataSource = dt

            If dgvUsers.Columns.Contains("UserId") Then
                dgvUsers.Columns("UserId").Visible = False
            End If

        Catch ex As Exception
            MessageBox.Show("Search error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub changeDbBtn_Click(sender As Object, e As EventArgs) Handles changeDbBtn.Click
        Dim newConn = InputBox("Enter new connection string:", "Change Database Connection", My.Settings.CafeDB)
        If String.IsNullOrWhiteSpace(newConn) Then Return

        Try
            ' Optional: test the connection before saving
            Using cn As New SqlConnection(newConn)
                cn.Open()
            End Using

            My.Settings.CafeDB = newConn
            My.Settings.Save()
            MessageBox.Show("Connection string updated successfully.", "Success")
        Catch ex As Exception
            MessageBox.Show("Invalid connection string: " & ex.Message)
        End Try
    End Sub


    Private Sub LoadUsers()
        Dim sql = "SELECT UserId, Username, Role FROM Users ORDER BY Username"
        Dim dt As New DataTable()

        Try
            Using cn As New SqlConnection(My.Settings.CafeDB)
                Using cmd As New SqlCommand(sql, cn)
                    cn.Open()
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        dt.Load(reader)  ' Load DataReader data directly into DataTable
                    End Using
                End Using
            End Using

            dgvUsers.DataSource = dt

            ' Optionally hide the UserId column
            If dgvUsers.Columns.Contains("UserId") Then
                dgvUsers.Columns("UserId").Visible = False
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading users: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function BackupDatabase() As Boolean
        Try
            Using sfd As New SaveFileDialog
                sfd.Filter = "Backup Files (*.bak)|*.bak"
                sfd.FileName = "CafeDB_Backup_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".bak"

                If sfd.ShowDialog() = DialogResult.OK Then
                    Dim backupPath = "C:\Users\alien\Documents\CafeDB_Backup_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".bak"

                    Using cn As New SqlConnection(My.Settings.CafeDB)
                        Dim dbName = cn.Database
                        Dim sql = $"BACKUP DATABASE [{dbName}] TO DISK = @path WITH INIT;"

                        Using cmd As New SqlCommand(sql, cn)
                            cmd.Parameters.AddWithValue("@path", backupPath)
                            cn.Open()
                            cmd.ExecuteNonQuery()
                        End Using
                    End Using

                    MessageBox.Show("Backup saved to: " & backupPath, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return True
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Backup failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return False
    End Function



End Class