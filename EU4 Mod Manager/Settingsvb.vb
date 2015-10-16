Public Class Settingsvb

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles CANCEL.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles GameExeButton.Click

    End Sub

    Private Sub Settingsvb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim GamePath As String
        Dim ModsPath As String

        GamePath = My.Settings.GamePath
        ModsPath = My.Settings.UserFilesPath

        Me.GamePathTextBox.Text = GamePath
        Me.ModspathTextBox.Text = ModsPath

        GamePath = Nothing
        ModsPath = Nothing

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
End Class