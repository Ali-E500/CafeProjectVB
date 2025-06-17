Public Class MainMenu

    Private Sub MainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Optional: Center the form or set user info here
    End Sub

    Private Sub tableBtn_Click(sender As Object, e As EventArgs) Handles tableBtn.Click
        Me.Hide()
        Dim frm As New Tables()
        frm.ShowDialog()
        Me.Show()
    End Sub

    Private Sub inventoryBtn_Click(sender As Object, e As EventArgs) Handles inventoryBtn.Click
        Me.Hide()
        Dim frm As New Inventory()
        frm.ShowDialog()
        Me.Show()
    End Sub

    Private Sub settingsBtn_Click(sender As Object, e As EventArgs) Handles settingsBtn.Click

        If Form1.LoggedInRole <> "Admin" Then
            MessageBox.Show("Only Admins can access settings.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' If admin, open the form
        Me.Hide()
        Dim s As New Settings()
        s.ShowDialog()
        Me.Show()

    End Sub

    Private Sub signoutBtn_Click(sender As Object, e As EventArgs) Handles signoutBtn.Click
        Dim loginForm As New Form1() ' Replace with your actual login form
        loginForm.Show()
        Me.Close() ' Use Close to fully sign out and dispose the main menu
    End Sub

    Private Sub exitBtn_Click(sender As Object, e As EventArgs) Handles exitBtn.Click
        Application.Exit()
    End Sub

End Class
