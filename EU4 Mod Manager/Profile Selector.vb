Public Class Form1
    Dim Settingstxt As String = My.Computer.FileSystem.ReadAllText(My.Settings.UserFilesPath & "\settings.txt")
    Dim Profiles() As String 'Stores all the profiles in short form
    Dim Mods() As String 'Store all the mods in short form
    Public Shared oGlobals As New Globals()


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If My.Settings.FirstTime Then
            MsgBox("Please select game executable and mod folder.", MsgBoxStyle.OkOnly, "First time setup")
            Settingsvb.ShowDialog()
        End If

        oGlobals.ModsFolder = My.Settings.UserFilesPath & "\mod"
        oGlobals.ProfileFolder = My.Settings.UserFilesPath & "\mod\EU4ModManager"

        My.Application.Log.WriteEntry(ProfileWatcher.Path)
        LoadProfiles() 'Load the profiles list

        Dim Mods() As String = ParadoxRW.GetArrayValue(Settingstxt, "last_mods")
        Dim CurrentMod As String

        For i = 0 To Mods.GetUpperBound(0)
            CurrentMod = Mods(i).Replace(Chr(34), "")
            CurrentMod = CurrentMod.Replace(Chr(9), "")
            ModList.Items.Add(CurrentMod)
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

    Public Shared Sub LoadMods()
        Dim ModName As String
        Dim i As Integer = 0
        Dim Dir As String = oGlobals.ModsFolder
        ProfileCreator.ModList.Items.Clear()
        Erase Form1.Mods

        For Each foundFile As String In My.Computer.FileSystem.GetFiles(
            Dir,
            FileIO.SearchOption.SearchTopLevelOnly, "*.mod") 'Get all .mod files



            Dim filetxt As String = My.Computer.FileSystem.ReadAllText(foundFile) 'Read the file

            foundFile = foundFile.Replace(Dir, "") 'get rid of the extra stuff
            foundFile = foundFile.Substring(1) 'remove the last slash
            If My.Settings.DebugMode Then
                ModName = ParadoxRW.GetStringValue(filetxt, "name") & "   -   (" & foundFile & ")"
            Else
                ModName = ParadoxRW.GetStringValue(filetxt, "name")
            End If

            Array.Resize(Form1.Mods, i + 1) 'Update the arrays size
            Form1.Mods(i) = foundFile ' add profile to array
            i = i + 1 'increment index

            ProfileCreator.ModList.Items.Add(ModName)
        Next
    End Sub

    Public Sub LoadProfiles()
        Dim ProfileName As String
        Dim i As Integer = 0
        Dim Dir As String = oGlobals.ProfileFolder
        ProfileList.Items.Clear()
        Erase Profiles

        For Each foundFile As String In My.Computer.FileSystem.GetFiles(
            Dir,
            FileIO.SearchOption.SearchTopLevelOnly, "*.profile") 'Get all .profile files



            Dim filetxt As String = My.Computer.FileSystem.ReadAllText(foundFile) 'Read the file

            foundFile = foundFile.Replace(Dir, "") 'get rid of the extra stuff
            foundFile = foundFile.Substring(1) 'remove the last slash
            If My.Settings.DebugMode Then
                ProfileName = ParadoxRW.GetStringValue(filetxt, "name") & "   -   (" & foundFile & ")"
            Else
                ProfileName = ParadoxRW.GetStringValue(filetxt, "name")
            End If

            Array.Resize(Profiles, i + 1) 'Update the arrays size
            Profiles(i) = foundFile ' add profile to array
            i = i + 1 'increment index

            ProfileList.Items.Add(ProfileName)
        Next
    End Sub

    Private Sub ProfileText_TextChanged(sender As Object, e As EventArgs) Handles ProfileText.TextChanged

    End Sub

    Private Sub SplitContainer1_Panel2_Paint(sender As Object, e As PaintEventArgs) Handles SplitContainer1.Panel2.Paint

    End Sub

    Private Sub ProfileList_DragDrop(sender As Object, e As DragEventArgs) Handles ProfileList.DragDrop

    End Sub
    Private Sub ProfileCreate(Mode As String, Optional Name As String = "Profile")
        ProfileCreator.Mode = Mode
        ProfileCreator.ProfileName = Name
        ProfileCreator.ShowDialog()
    End Sub

    Private Sub EditProfie_Click(sender As Object, e As EventArgs) Handles EditProfileButton.Click
        Try
            ProfileList.SelectedItem.ToString()
        Catch ex As NullReferenceException
            My.Application.Log.WriteEntry("No Item selected/found")
            MsgBox("Please Select an item first", , "Null Refererence Exception")
            Return
        Catch ex As Exception
            MsgBox("Exception Encountered:" & Environment.NewLine & ex.Message, , "Error")
            Return
        End Try

        Dim SelectedName = Profiles(ProfileList.SelectedIndex)
        Dim SelectedTxt = My.Computer.FileSystem.ReadAllText(oGlobals.ProfileFolder & "\" & SelectedName)
        SelectedName = ParadoxRW.GetStringValue(SelectedTxt, "name")
        ProfileCreate("Edit", SelectedName)
    End Sub

    Private Sub ProfileWatcherEvent(sender As Object, e As IO.RenamedEventArgs) Handles ProfileWatcher.Renamed, ProfileWatcher.Deleted, ProfileWatcher.Created, ProfileWatcher.Changed
        LoadProfiles()
    End Sub

    Private Sub ModsWatcherEvent(sender As Object, e As IO.FileSystemEventArgs) Handles ModsWatcher.Deleted, ModsWatcher.Created, ModsWatcher.Changed, ModsWatcher.Renamed
        LoadMods()
    End Sub
End Class

Public Class Globals
    Private ModsPath As String
    Private ProfilesPath As String

    Private ProfilesArray() As String
    Private ModsArray() As String


    Public Property ProfileFolder As String
        Get
            Return ProfilesPath
        End Get
        Set(value As String)

            Try
                FileIO.FileSystem.DirectoryExists(ProfilesPath)
            Catch ex As Exception
                My.Application.Log.WriteEntry(ex.ToString())
                Exit Property
            End Try
            
            ProfilesPath = value
            Form1.ProfileWatcher.Path = value
        End Set

    End Property

    Public Property ModsFolder As String
        Get
            Return ModsPath
        End Get
        Set(value As String)

            Try
                FileIO.FileSystem.DirectoryExists(ModsPath)
            Catch ex As Exception
                My.Application.Log.WriteEntry(ex.ToString())
            End Try
            ModsPath = value
            Form1.ModsWatcher.Path = value
        End Set

    End Property

End Class