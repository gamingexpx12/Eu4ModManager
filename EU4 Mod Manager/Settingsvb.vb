Imports EU4_Mod_Manager.GlobalModule
Public Class Settingsvb
    Public StartupMode As Mode = Mode.GamePath 'How to load
    Public Enum Mode As Integer 'Ways to load
        GamePath
        ModsPath
        FirstTime
        Normal
    End Enum

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles CANCEL.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles GameExeButton.Click

    End Sub

    Private Sub Settingsvb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Select Case StartupMode
            Case Mode.GamePath 'If gamepath is incorrect
                With ModspathTextBox
                    .ReadOnly = True
                    .Text = "Mod Folder Path"
                    ModsPathButton.Enabled = False


                End With
                With GamePathTextBox
                    .ReadOnly = False
                    .Text = Nothing
                    .Focus()
                    GameExeButton.Enabled = True
                End With

            Case Mode.ModsPath
                With ModspathTextBox
                    .ReadOnly = False
                    .Text = Nothing
                    .Focus()
                    ModsPathButton.Enabled = True
                End With

                With GamePathTextBox
                    .ReadOnly = True
                    .Text = "Game Path"
                    GameExeButton.Enabled = False
                End With
                

            Case Mode.FirstTime
                GamePathTextBox.Text = Nothing
                GameExeButton.Enabled = False
                ModspathTextBox.Text = Nothing
                ModsPathButton.Enabled = True
                GameExeButton.Focus()
            Case Else
                GamePathTextBox.Text = GameFolderPath
                GameExeButton.Enabled = True
                ModsPathButton.Enabled = True
                ModspathTextBox.Text = ModFolderPath

        End Select

        
        CheckBox1.Checked = My.Settings.DebugMode

    End Sub

    Private Sub OK_Click(sender As Object, e As EventArgs) Handles OK.Click
        My.Settings.GamePath = Me.GamePathTextBox.Text
        My.Settings.UserFilesPath = Me.ModspathTextBox.Text
        SetupFolder(My.Settings.UserFilesPath)
        Me.DialogResult = Windows.Forms.DialogResult.OK
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