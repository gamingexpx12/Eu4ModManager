''' <summary>
''' Module Responsible for reading and writing Paradox Files.
''' </summary>
Module ParadoxRW
    Private UserFilesPath As String = My.Settings.UserFilesPath
    Private ModsPath As String = My.Computer.FileSystem.CombinePath(UserFilesPath, "mod")
    Private ProfilesPath As String = My.Computer.FileSystem.CombinePath(ModsPath, "Eu4ModManager")

    
    ''' <summary>
    ''' Return the value of the target key inside the given file
    ''' </summary>
    Public Function GetKeyValue(file As String, target As String) As String 'The real function, the best function
        Dim i As Integer
        Dim CurrentString As String
        Dim Newline As Integer
        Try
            file.IndexOf(target)
        Catch ex As IndexOutOfRangeException
            My.Application.Log.WriteEntry("File or Target Missing", TraceEventType.Error)
        Catch ex As Exception

        End Try
        'If file Or target = Nothing Then 'Do nothing if given nothing
        '    My.Application.Log.WriteEntry("File or Target Missing", TraceEventType.Error)
        '    Return Nothing
        'End If

        i = file.IndexOf(target) 'find the index of the search

        'If i = -1 Then
        '    My.Application.Log.WriteEntry("Can't find target in file", TraceEventType.Error)
        '    Return Nothing 'Can't find the target
        'End If

        i = i + target.Length + 1 'Add the rest of the key and the =
        If file.IndexOf(Environment.NewLine, i) = -1 Then
            Newline = file.IndexOf(vbLf, i) - i
        Else
            Newline = file.IndexOf(Environment.NewLine, i) - i
        End If


        CurrentString = file.Substring(i, Newline) 'cut out before key
        Return CurrentString

    End Function

    Public Function GetBoolValue(file As String, target As String) As String
        Dim Value As String = GetKeyValue(file, target)

        Return Value 'True is true, false is false

    End Function

    Public Function GetStringValue(file As String, target As String) As String
        Dim Value As String = GetKeyValue(file, target)

        Return Value.Replace(Chr(34), "")

    End Function

    Public Function GetArrayValue(file As String, target As String) As String()
        Dim Value As String = GetKeyValue(file, target)
        Dim i As Integer = 0
        Dim ending As UInteger
        'Dim Newline As UInteger


        i = file.IndexOf(target) + target.Length + 1 'find the index of the search
        ending = file.IndexOf("}", i) - i 'find the last importart index
        file = file.Substring(i + 1, ending - 1) 'remove all excess in the front

        'starting = +1
        'While Not i = -1
        '    ending = i
        '    i = file.IndexOf("{", i)
        'End While


        file = file.Trim()


        Return file.Split(Environment.NewLine) '.Trim 'trimmed output
    End Function

    Public Function GetArrayCount(file As String, target As String) As Integer
        Return 0
    End Function

    Public Function Stringify(Text As String)
        Return Chr(34) & Text & Chr(34)
    End Function

    ''' <summary>
    ''' Gets the value associated with the key in the file specified as filepath
    ''' </summary>
    ''' <param name="filepath"></param>
    ''' <param name="Key"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetParadox(filepath As String, Optional Key As String = "Name") As String

        Key = Key & "=" 'add the extra = early, so we get the right thing
        'Key = Key.ToLower 'To lowercase
        Dim Index As Integer
        If filepath = Nothing Then
            Throw New ArgumentNullException("filepath", "No filepath was specified")

        ElseIf Not My.Computer.FileSystem.FileExists(filepath) Then
            Throw New ArgumentException("File does not exist", "filepath")

        Else
            filepath = My.Computer.FileSystem.ReadAllText(filepath)
            'filepath = filepath.ToLower 'To lower case 
            If filepath.IndexOf(Key, StringComparison.OrdinalIgnoreCase) = -1 Then
                Return Nothing
            Else

            End If

            Index = filepath.IndexOf(Key, StringComparison.OrdinalIgnoreCase)
            filepath = filepath.Substring(Index + Key.Length) 'Remove left fluff
            If Not filepath.IndexOf(vbCrLf) = -1 Then 'Do if Newline is found
                Index = filepath.IndexOf(vbCrLf)

            ElseIf Not filepath.IndexOf(vbCr) = -1 Then 'Do if Cr is found
                Index = filepath.IndexOf(vbCr)

            ElseIf Not filepath.IndexOf(vbLf) = -1 Then 'Dp if LF
                Index = filepath.IndexOf(vbLf)

            End If
            filepath = filepath.Substring(0, Index)

        End If

        Return filepath
    End Function
    Public Function GetParadoxString(filepath As String, Optional Key As String = "Name") As String
        filepath = GetParadox(filepath, Key)
        If filepath = Nothing Then Return Nothing
        filepath = filepath.Trim(Chr(34))
        Return filepath
    End Function

    Public Function GetParadoxDouble(filepath As String, Key As String) As Double
        filepath = GetParadoxString(filepath, Key)
        If filepath = Nothing Then Return Nothing
        Return CDbl(filepath)
    End Function


    '--- Classes ---


    ''' <summary>
    ''' Base Class for Storing mod and profile info.
    ''' </summary>
    Public MustInherit Class EU4Obj
        Private Localname As String 'Readable Name
        Private Filename As String 'Name of the file
        Private Folder As String = UserFilesPath
        Private Version As Double = 1.13
        ''' <summary>
        ''' Get the readable name of the file
        ''' </summary>
        ''' <returns>Name</returns>
        ''' <remarks>Mirrors Name</remarks>
        ''' <filterPriority>2</filterPriority>
        Public Overrides Function ToString() As String
            If My.Settings.DebugMode Then
                Return Name & " - " & Version
            Else
                Return Name
            End If

        End Function
        ''' <summary>
        ''' Get the readable name of the file
        ''' </summary>
        ''' <value></value>
        ''' <returns>Private LocalName</returns>
        ''' <remarks></remarks>
        Public Property Name As String
            Get
                If Localname = Nothing Then Return "No Name" 'If empty return something

                Return Localname 'Just the name
            End Get

            Set(value As String)
                If value = Nothing Then Throw New ArgumentNullException("Name", "Can't set Name to Nothing")
                Localname = value
            End Set
        End Property
        ''' <summary>
        ''' Returns the full path for the file
        ''' </summary>
        ''' <value></value>
        ''' <returns>Path</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Path As String
            Get
                Return My.Computer.FileSystem.CombinePath(Folder, Filename)
            End Get
        End Property

        Public Sub New(ByVal File As String, Folder As String)
            NewFile(File, Folder)
        End Sub

        Protected Sub NewFile(FileNameF As String, FolderF As String)
            If FileNameF = Nothing Then Throw New ArgumentNullException("Filename is Empty", "File")
            Me.Filename = FileNameF 'Filename
            FolderF = My.Computer.FileSystem.CombinePath(FolderF, FileNameF) 'Make into a proper path
            Me.Localname = ParadoxRW.GetParadoxString(FolderF)
            Me.Version = ParadoxRW.GetParadoxDouble(FolderF, "supported_version")
            'Me.Folder = ParadoxRW.GetParadox(FolderF)
           
        End Sub
    End Class

    ''' <summary>
    ''' Class for handling individual mods
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ModObj
        Inherits EU4Obj
        Dim Ext = ".mod"
        Dim Folder As String = ModsPath
        ''' <summary>
        ''' Associates the ModObj with an actual file
        ''' </summary>
        ''' <param name="FileName">Name of the file</param>
        ''' <remarks>No Paths Allowed</remarks>
        Public Sub New(ByVal FileName As String)
            MyBase.New(FileName, ModsPath)
            'NewFile(FileName, Folder)
        End Sub
    End Class

    ''' <summary>
    ''' Class for handling profiles
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ProfileObj
        Inherits EU4Obj
        Dim Ext = ".profile"
        Dim Folder As String = ProfilesPath
        ''' <summary>
        ''' Associates the ProfileObj with an actual file
        ''' </summary>
        ''' <param name="FileName">Name of the file</param>
        ''' <remarks>No Paths Allowed</remarks>
        Public Sub New(ByVal FileName As String)
            MyBase.New(FileName, ProfilesPath)
        End Sub
    End Class

    ''' <summary>
    ''' Class for handling the settings file
    ''' </summary>
    ''' <remarks></remarks>
    Public Class SettingsObj
        Inherits EU4Obj
        Dim Ext = ".txt"
        Dim Folder As String = My.Settings.UserFilesPath & "\"
        Dim Mods As ModObj()
        ''' <summary>
        ''' Associates the object with the file
        ''' </summary>
        ''' <param name="FileName">Filename of the settings file</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal FileName As String)
            MyBase.New(FileName, My.Settings.UserFilesPath & "\")

        End Sub

        Public Property LastMods As ModObj()
            Get
                Return Mods
            End Get
            Set(value As ModObj())
                Mods = value
            End Set
        End Property

    End Class

End Module
