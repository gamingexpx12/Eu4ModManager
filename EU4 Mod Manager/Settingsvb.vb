Public Class Settingsvb

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles CANCEL.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles GameExeButton.Click

    End Sub

    Private Sub Settingsvb_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GamePathTextBox.Text = My.Settings.GamePath
        ModspathTextBox.Text = My.Settings.UserFilesPath
        CheckBox1.Checked = My.Settings.DebugMode

    End Sub

    Private Sub OK_Click(sender As Object, e As EventArgs) Handles OK.Click
        My.Settings.GamePath = Me.GamePathTextBox.Text
        My.Settings.UserFilesPath = Me.ModspathTextBox.Text
        SetupFolder(My.Settings.UserFilesPath)
        Me.Close()


    End Sub

    Private Sub ModsPathButton_Click(sender As Object, e As EventArgs) Handles ModsPathButton.Click
        FBD.ShowDialog()
        ModspathTextBox.Text = FBD.SelectedPath

    End Sub

    Private Sub SetupFolder(path As String)
        Dim Manager As String

        Manager = "EU4ModManager"

        'Check if management folder exists
        If Not System.IO.Directory.Exists(path & "\mod\" & Manager) Then
            System.IO.Directory.CreateDirectory(path & "\mod\" & Manager) 'Dosent exist, let's create it

        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        My.Settings.DebugMode = CheckBox1.Checked
    End Sub
End Class