Public Class Form1
    Dim Settingstxt As String = My.Computer.FileSystem.ReadAllText(My.Settings.UserFilesPath & "\settings.txt")
    Dim Profiles() As String


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If My.Settings.FirstTime Then
            MsgBox("Please select game executable and mod folder.", MsgBoxStyle.OkOnly, "First time setup")
            Settingsvb.ShowDialog()
        End If

        LoadProfiles() 'Load the profiles list

        Dim Descs() As String = ParadoxRW.GetArrayValue(Settingstxt, "last_mods")

        ProfileText.Clear()
        For i = 0 To Descs.GetUpperBound(0)
            ProfileText.AppendText(Descs(i).Replace(Chr(34), ""))
        Next


    End Sub

    Private Sub ToolStripContainer1_TopToolStripPanel_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click

    End Sub

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        My.Settings.FirstTime = False
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        System.Diagnostics.Process.Start(My.Settings.GamePath, "-skiplauncher")
        Me.Close()

    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        Settingsvb.ShowDialog()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ProfileList.SelectedIndexChanged

    End Sub

    Private Sub ProfileDelete_Click(sender As Object, e As EventArgs) Handles ProfileDelete.Click

    End Sub

    Private Sub NewProfile_Click(sender As Object, e As EventArgs) Handles NewProfile.Click
        ProfileCreate("Create")
    End Sub

    Private Sub LoadProfiles()
        Dim ProfileName As String
        ReDim Profiles(0 To 1)
        Dim i As Integer = 0
        Dim Dir As String = My.Settings.UserFilesPath & "\mod\EU4ModManager"

        Dim Filecount As String = My.Computer.FileSystem.GetFiles(Dir, FileIO.SearchOption.SearchTopLevelOnly, "*.profile").Count
        My.Application.Log.WriteEntry("Found " & Filecount & " Files.")

        For Each foundFile As String In My.Computer.FileSystem.GetFiles(
            Dir,
            FileIO.SearchOption.SearchTopLevelOnly, "*.profile") 'Get all .profile files

            Profiles(i) = foundFile
            i = i + 1 'increment index
            Dim filetxt As String = My.Computer.FileSystem.ReadAllText(foundFile) 'Read the file
            foundFile = foundFile.Replace(Dir, "")
            If My.Settings.DebugMode Then
                ProfileName = ParadoxRW.GetStringValue(filetxt, "name") & "   -   (" & foundFile & ")"
            Else
                ProfileName = ParadoxRW.GetStringValue(filetxt, "name")
            End If

            ProfileList.Items.Add(ProfileName)
        Next
    End Sub

    Private Sub ProfileText_TextChanged(sender As Object, e As EventArgs) Handles ProfileText.TextChanged

    End Sub

    Private Sub SplitContainer1_Panel2_Paint(sender As Object, e As PaintEventArgs) Handles SplitContainer1.Panel2.Paint

    End Sub

    Private Sub ProfileList_DragDrop(sender As Object, e As DragEventArgs) Handles ProfileList.DragDrop

    End Sub
    Private Sub ProfileCreate(Mode As String)
        ProfileCreator.Mode = Mode
        ProfileCreator.ShowDialog()
    End Sub

    Private Sub EditProfie_Click(sender As Object, e As EventArgs) Handles EditProfie.Click
        ProfileCreate("Edit")
    End Sub
End Class
