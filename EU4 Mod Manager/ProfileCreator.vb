Imports System.IO
Imports EU4_Mod_Manager.ParadoxRW
Imports EU4_Mod_Manager.Form1

Public Class ProfileCreator

    Public Mode As String 'Create new profile or edit one
    Public ProfileName As String = "Selected Profile Name" 'If editinng, which name should we use
    Private Sub ProfileCreator_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim ModName As String

        ModeChange(Mode)
        LoadMods()

        'For Each FoundFile As String In My.Computer.FileSystem.GetFiles(
        '    oGlobals.ModsFolder,
        '    Microsoft.VisualBasic.FileIO.SearchOption.SearchTopLevelOnly, "*.mod") 'Get all .mod files

        '    Dim filetxt As String = My.Computer.FileSystem.ReadAllText(FoundFile)
        '    ModName = GetStringValue(filetxt, "name")
        '    FoundFile = FoundFile.Replace(Form1.oGlobals.ModsFolder & "\", "")
        '    If My.Settings.DebugMode Then 'Debug Info
        '        ModList.Items.Add(ModName & "   -   (" & FoundFile & ")")
        '    Else
        '        ModList.Items.Add(ModName)
        '    End If

        'Next
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles ProfileTextBox.TextChanged

    End Sub

    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles CancelProfileButton.Click
        Me.Close()
    End Sub

    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        'Dim ToTrim() As Char = {Chr(34), Chr(1)}
        'ProfileName = ProfileTextBox.Text.Trim(ToTrim())

        ProfileName = ProfileTextBox.Text.Replace(" ", "") 'No whitespace in filename, for max compatibility
        Dim ProfileFile = File.CreateText(Form1.oGlobals.ProfileFolder & "\" & ProfileName & ".profile") 'Create a textfile with the desited name
        ProfileName = ProfileTextBox.Text 'Get the actual name again

        '***Temporary until SetStringValue is ready***
        ProfileFile.WriteLine("name=" & ParadoxRW.Stringify(ProfileName)) ' Write the readable name in a PRW string format
        ProfileFile.Close() 'Close the file?
        Me.Close()
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