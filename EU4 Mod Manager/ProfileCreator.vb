Public Class ProfileCreator

    Public Mode As String
    Private Sub ProfileCreator_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ModName As String

        ModeChange(Mode)

        For Each FoundFile As String In My.Computer.FileSystem.GetFiles(
            My.Settings.UserFilesPath & "/mod",
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

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

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
            Case "Edit"
                Text = "Edit Existing Profile"
            Case Else
                My.Application.Log.WriteEntry("Invalid Mode", TraceEventType.Error)
                Me.Close()
        End Select

    End Sub
End Class