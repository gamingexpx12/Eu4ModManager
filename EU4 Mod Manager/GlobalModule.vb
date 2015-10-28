''' <summary>
''' Module that contains all global properties
''' </summary>
''' <remarks></remarks>
Module GlobalModule
    Property ModFolderPath As String
        Get
            Try
                My.Computer.FileSystem.CombinePath(My.Settings.UserFilesPath, "mod")
            Catch ex As Exception
                My.Application.Log.WriteException(ex, TraceEventType.Error, "UserFilesPath was not valid")
                If Settingsvb.ShowDialog() = DialogResult.Cancel Then
                    Form1.Close()
                End If
                Return My.Computer.FileSystem.CombinePath("C:\", "mod")
            End Try
            Return My.Computer.FileSystem.CombinePath(My.Settings.UserFilesPath, "mod")
        End Get
        Set(ByVal value As String)
            With My.Computer.FileSystem 'Pretend we're Filesystem
                If .DirectoryExists(value) Then 'If directory is valid
                    My.Settings.UserFilesPath = .GetParentPath(value)

                Else

                End If
            End With
        End Set
    End Property

    ReadOnly Property SettingsFilePath
        Get
            Return My.Computer.FileSystem.CombinePath(My.Settings.UserFilesPath, "settings.txt")
        End Get
    End Property

    Property GameFolderPath
        Get
            If My.Computer.FileSystem.DirectoryExists(My.Settings.GamePath) Then
                Return My.Settings.GamePath
            Else
                Return Nothing
            End If
        End Get
        Set(value)
            If My.Computer.FileSystem.DirectoryExists(value) Then
                My.Settings.GamePath = value
            Else

            End If
        End Set
    End Property

    Property FirstTimeSetup
        Get
            Return My.Settings.FirstTime
        End Get
        Set(value)
            My.Settings.FirstTime = value
        End Set
    End Property
End Module
