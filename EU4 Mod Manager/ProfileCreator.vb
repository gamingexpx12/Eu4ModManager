Public Class ProfileCreator

    Public Mode As String 'Create new profile or edit one
    Public ProfileName As String = "Selected Profile Name" 'If editinng, which name should we use
    Private Sub ProfileCreator_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ModName As String

        ModeChange(Mode)

        For Each FoundFile As String In My.Computer.FileSystem.GetFiles(
            Form1.oglobals,
            Microsoft.VisualBasic.FileIO.SearchOption.SearchTopLevelOnly, "*.mod") 'Get all .mod files

            Dim filetxt As String = My.Computer.FileSystem.ReadAllText(FoundFile)
            ModName = ParadoxRW.GetStringValue(filetxt, "name")
            FoundFile = FoundFile.Replace(My.Settings.UserFilesPath, "")
            If My.Settings.DebugMode Then 'Debug Info
                ModList.Items.Add(ModName & "   -   (" & FoundFile & ")")
            Else
                ModList.Items.Add(ModName)
            End If

        Next
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles ProfileTextBox.TextChanged

    End Sub

    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles CancelProfileButton.Click
        Me.Close()
    End Sub

    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click

    End Sub

    Private Sub ModeChange(Mode As String)
        Select Case Mode
            Case "Create"
                Text = "Create New Profile"
                ProfileTextBox.Text = "New Profile"
            Case "Edit"
                Text = "Edit Existing Profile"
                ProfileTextBox.Text = ProfileName

            Case Else
                My.Application.Log.WriteEntry("Invalid Mode", TraceEventType.Error)
                Me.Close()
        End Select

    End Sub
End Class