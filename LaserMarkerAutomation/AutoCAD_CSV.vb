Imports System.IO
Imports System.Runtime.InteropServices

Module AutoCAD_CSV
    Public PrintList As New List(Of MrkStrip)

    Public Structure MrkStrip
        Public Number As Integer
        Public SizeX As Double
        Public SizeY As Double
        Public CoordX As Double
        Public CoordY As Double
        Public Rotate As Boolean
        Public BaseTemplate As List(Of String)
        Public Text As String
        Public Completed As Boolean
    End Structure

#Region "CSV"
    'Returns the list of Base Templates from Templates.csv
    Public Function GetBaseTemplates() As List(Of String)
        Dim BaseTemplates As New List(Of String)

        Dim fs As New FileStream(TemplatesPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
        Using sr As New StreamReader(fs)
            For Each line As String In sr.ReadToEnd.Split(Environment.NewLine)
                If line <> "" Then
                    BaseTemplates.Add(line.Split(",")(0))
                End If
            Next
        End Using
        fs.Close()

        Return BaseTemplates
    End Function

    'Returns if a Base Template exists in Templates.csv
    Public Function CheckBaseTemplates(BaseTemplate As String) As Boolean
        Dim fs As New FileStream(TemplatesPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
        Using sr As New StreamReader(fs)
            For Each line As String In sr.ReadToEnd.Split(Environment.NewLine)
                If line.Split(",")(0) = BaseTemplate Then
                    Return True
                End If
            Next
        End Using
        fs.Close()
        Return False
    End Function

    'Returns the Specs for a specific base template from Templates.csv
    Public Function GetBaseTemplateSpecs(BaseTemplate As String) As List(Of String)
        Dim BaseTemplateSpecs As New List(Of String)
        If CheckBaseTemplates(BaseTemplate) Then
            Dim fs As New FileStream(TemplatesPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
            Using sr As New StreamReader(fs)
                For Each line As String In sr.ReadToEnd.Split(Environment.NewLine)
                    If line.Split(",")(0) = BaseTemplate Then
                        For Each column As String In line.Split(",")
                            BaseTemplateSpecs.Add(column)
                        Next
                    End If
                Next
            End Using
            fs.Close()
        End If
        Return BaseTemplateSpecs
    End Function

    'Returns the list of Previous Part Numbers in the PrevDocs folder
    Public Function GetPrevDocs() As FileInfo()
        Dim Dir As New DirectoryInfo(PrevDocsPath)
        Dim fileArr As FileInfo() = Dir.GetFiles()
        Return fileArr
    End Function

    'Returns if a previous document exists and is not currently open
    Public Function CheckPrevDocs(filename As String) As Boolean
        If File.Exists(filename) Then
            Return True
        Else
            Return False
        End If
    End Function

    'Returns the text in a PrevDocs file
    Public Function GetPrevDocText(filename As String) As List(Of String)
        Dim TextList As New List(Of String)
        If CheckPrevDocs(filename) Then
            Dim fs As New FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
            Using sr As New StreamReader(fs)
                For Each line In sr.ReadToEnd.Split(Environment.NewLine)
                    TextList.Add(line)
                Next
            End Using
            fs.Close()
        End If
        Return TextList
    End Function

    Public Sub AddMarkingStrips(filename As String, partnum As String)
        'Get the text for that PN
        Dim PrevDocText = GetPrevDocText(filename)
        'Get the base template associated with that PN
        Dim BaseTemplate = GetPrev(partnum)
        'Gets the specs with the associated base template
        Dim BaseTemplateSpecs = GetBaseTemplateSpecs(BaseTemplate)

        If BaseTemplateSpecs.Count = 0 Or PrevDocText.Count = 0 Then
            MsgBox("Error adding the marking strip")
            Return
        Else
            For Each line As String In PrevDocText
                If line.Trim() <> "" Then
                    Dim MarkingStrip As MrkStrip
                    MarkingStrip.Number = PrintList.Count + 1
                    MarkingStrip.BaseTemplate = BaseTemplateSpecs
                    MarkingStrip.SizeX = BaseTemplateSpecs(1)
                    MarkingStrip.SizeY = BaseTemplateSpecs(2)
                    MarkingStrip.Text = line
                    PrintList.Add(MarkingStrip)
                End If
            Next
        End If
    End Sub

    'Clears all the marking strips from the MarkingStripInfo.txt file
    Public Sub ClearMarkingStrips()
        Using sw As New StreamWriter(MarkingStripInfoPath)
            sw.Write("")
        End Using
    End Sub

    Public Sub CreateMarkingStripInfoTxt(NestedList As List(Of MrkStrip))
        File.WriteAllText(MarkingStripInfoPath, "")
        Dim fs As New FileStream(MarkingStripInfoPath, FileMode.Open, FileAccess.Write, FileShare.Read)
        Using sw As New IO.StreamWriter(fs)
            For Each MarkingStrip As MrkStrip In NestedList
                sw.WriteLine(MarkingStrip.Text & "^" & MarkingStrip.CoordX & "^" & MarkingStrip.CoordY & "^" & MarkingStrip.Rotate.ToString & "^" & MarkingStrip.BaseTemplate(1) & "^" & MarkingStrip.BaseTemplate(2) & "^" & MarkingStrip.BaseTemplate(3) & "^" & MarkingStrip.BaseTemplate(4) & "^" & MarkingStrip.BaseTemplate(5) & "^" & MarkingStrip.BaseTemplate(6) & "^" & MarkingStrip.BaseTemplate(7) & "^" & MarkingStrip.BaseTemplate(8))
            Next
        End Using
        fs.Close()
    End Sub
#End Region

#Region "AutoCAD"

    Public Sub RunAcadScript()
        If IO.File.Exists(acadInactivePath) Then
            My.Computer.FileSystem.RenameFile(acadInactivePath, "acaddoc.lsp")
        End If

        Process.Start(batPath)

        Dim finished As Boolean = WaitScriptFinished()
        If finished = False Then
            MsgBox("Error running script")
        End If

        Threading.Thread.Sleep(1500)

        If IO.File.Exists(acadActivePath) Then
            My.Computer.FileSystem.RenameFile(acadActivePath, "acaddoc_NOTRUN_LASER.lsp")
        End If
    End Sub
    Public Function WaitScriptFinished() As Boolean
        Dim EndTime As DateTime = DateTime.Now.AddSeconds(120)
        Dim counter2 = 0
        Try
            System.IO.File.WriteAllText(ScriptCompletePath, "0")
            'Waits for the drawing to close
            Dim read As String = ""
            While read.Contains("1") = False
                Using sw As New IO.StreamReader(ScriptCompletePath)
                    read = sw.ReadLine()
                End Using
                If counter2 > 2 Then
                    MsgBox("Too many batch file reattempts: ")
                    Return False
                End If
                If DateTime.Now >= EndTime Then
                    'Process.Start(batPath)
                    counter2 += 1
                    EndTime = DateTime.Now.AddSeconds(120)
                End If
                Threading.Thread.Sleep(1000)
            End While
            System.IO.File.WriteAllText(ScriptCompletePath, "0")
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Sub CreateDXF()
        Try
            My.Computer.FileSystem.DeleteFile(AstraReadPath)
        Catch ex As Exception
        End Try

        CreateXML(AstraWritePath, PrintList)

        StartNesting()

        Dim NestingPlanNum As Integer = 0
        Dim CompletedNum = 0

NextNestingPlan2:
        Dim CompletedList = ReadXML(AstraReadPath, PrintList, NestingPlanNum)
        CompletedNum += CompletedList.Count

        CreateMarkingStripInfoTxt(CompletedList)

        Threading.Thread.Sleep(250)

        RunAcadScript()

        If CompletedNum < PrintList.Count Then
            Dim response = MsgBox("There are more Marking Strips left, would you like to keep going?", vbYesNo)
            If response = vbNo Then
                Exit Sub
            End If
            NestingPlanNum += 1
            GoTo NextNestingPlan2
        End If
    End Sub
#End Region

#Region "File Open Checks"
    ' EPM 8/1/2019
    Public Function IsFileOpen(ByVal file As FileInfo) As Boolean
        Dim stream As FileStream = Nothing
        Try
            stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None)
            stream.Close()
            IsFileOpen = False
        Catch ex As Exception
            If TypeOf ex Is IOException AndAlso IsFileLocked(ex) Then
                IsFileOpen = True
            End If
        End Try
    End Function

    ' EPM 8/1/2019
    Public Function IsFileLocked(exception As Exception) As Boolean
        Dim errorCode As Integer = Marshal.GetHRForException(exception) And ((1 << 16) - 1)
        Return errorCode = 32 OrElse errorCode = 33
    End Function
#End Region
End Module
