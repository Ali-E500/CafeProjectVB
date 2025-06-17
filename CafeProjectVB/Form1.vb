Imports System.Data.SqlClient

Public Class Form1

    Public Shared LoggedInUser As String = ""
    Public Shared LoggedInRole As String = ""

    Private Sub LoginBtn_Click(sender As Object, e As EventArgs) Handles LoginBtn.Click
        Dim user = txtUsername.Text.Trim()
        Dim pass = txtPassword.Text

        If user = "" OrElse pass = "" Then
            MessageBox.Show("Enter username and password.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            Return
        End If

        ' Hash password via extension
        Dim hashed = pass.ComputeSha256()

        Const sql = "SELECT Role FROM dbo.Users WHERE Username=@u AND PasswordHash=@p;"

        Try
            Using cn = New SqlConnection(My.Settings.CafeDB)
                Using cmd As New SqlCommand(sql, cn)
                    cmd.Parameters.AddWithValue("@u", user)
                    cmd.Parameters.AddWithValue("@p", hashed)
                    cn.Open()

                    Dim roleObj = cmd.ExecuteScalar()
                    If roleObj IsNot Nothing Then
                        LoggedInUser = user
                        LoggedInRole = roleObj.ToString()

                        Dim menuForm As New MainMenu()
                        menuForm.Show()
                        Me.Hide()
                    Else
                        MessageBox.Show("Invalid credentials.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        txtUsername.Clear()
                        txtPassword.Clear()
                        txtUsername.Focus()
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("DB error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Application.Exit()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
