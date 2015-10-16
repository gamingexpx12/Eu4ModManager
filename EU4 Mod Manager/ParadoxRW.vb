Module ParadoxRW

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
End Module
