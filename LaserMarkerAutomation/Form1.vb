Imports System.Net.Sockets
Imports System.Net
Imports System.Text
Imports System.Runtime.InteropServices
Public Class Form1
#Region "Global Vars"
    Public acadProc As New Process()
    Public lbProc As New Process()

    Public ActivePN As String = ""
#End Region

#Region "BOM"
    Public Sub GetBomAsync()
        If TxtBreakerSN.Text = String.Empty Then
            MsgBox("You must first enter a serial number")
            Exit Sub
        Else
            DataGridMain.Rows.Clear()
            ProgressBarBOM.Value = 0

            Dim Dir As New IO.DirectoryInfo(PrevDocsPath)
            Dim fileArr As IO.FileInfo() = Dir.GetFiles()

            Dim BomTable As DataTable = GetBOM(TxtBreakerSN.Text)
            If BomTable.Rows.Count = 0 Then
                MsgBox("This serial number isn't valid or hasn't been extracted from SAP by SFM. Please do so and try again")
                Exit Sub
            End If

            Dim StepValue As Double = 100.0 / BomTable.Rows.Count
            Dim count As Integer = 1

            For Each row As DataRow In BomTable.Rows
                If Strings.UCase(row.Item(5).ToString).Contains("NAMEPLATE") Or Strings.UCase(row.Item(5).ToString).Contains("STRIP") Then
                    Dim PrevRun As Boolean = False
                    For Each fil As IO.FileInfo In fileArr
                        If fil.Name = row.Item(4) & ".csv" Then
                            PrevRun = True
                        End If
                    Next
                    DataGridMain.Rows.Add({row.Item(4), row.Item(5), row.Item(7), PrevRun})
                End If
                ProgressBarBOM.Value = count * StepValue
                ProgressBarBOM.Update()
                count += 1
            Next

            DataGridMain.AutoResizeColumns()
        End If
    End Sub

    Public Sub CheckPrevious()
        Dim TotalRows As Integer = DataGridMain.Rows.Count
        Dim completed As Integer = 0

        For Each row As DataGridViewRow In DataGridMain.Rows
            Dim currentRow = DataGridMain.Rows.IndexOf(row)
            If row.Cells.Item(3).Value = True Then
                DataGridMain.Rows.Item(currentRow).DefaultCellStyle.ForeColor = Color.Green
                completed += 1
            Else
                Dim boolTemp As Boolean = False

                For Each UniqueTemplate As String In GetBaseTemplates()
                    Dim templateDashless As String = ""
                    For Each item As String In UniqueTemplate.Split("-")
                        templateDashless &= item
                    Next

                    Try
                        If row.Cells.Item(0).Value.ToString.Split("P3R")(1).Substring(0, 8) = templateDashless Then
                            boolTemp = True
                        End If
                    Catch ex As Exception

                    End Try
                Next

                If boolTemp Then
                    DataGridMain.Rows.Item(currentRow).DefaultCellStyle.ForeColor = Color.Blue
                Else
                    DataGridMain.Rows.Item(currentRow).DefaultCellStyle.ForeColor = Color.Red
                End If

            End If
        Next

        Dim PercentComplete As Double = Math.Round(completed / TotalRows * 100.0, 2)
        If Double.IsNaN(PercentComplete) Then
            Exit Sub
        ElseIf PercentComplete < 60.0 Then
            LblEngravedex.Text = "Engravédex: " & PercentComplete & "% complete"
            LblEngravedex.ForeColor = Color.Red
        ElseIf PercentComplete < 90.0 Then
            LblEngravedex.Text = "Engravédex: " & PercentComplete & "% complete"
            LblEngravedex.ForeColor = Color.Orange
        Else
            LblEngravedex.Text = "Engravédex: " & PercentComplete & "% complete"
            LblEngravedex.ForeColor = Color.Green
        End If
    End Sub
#End Region

#Region "Manual DXF"
    Private Sub BtnCreateDXF_Click(sender As Object, e As EventArgs) Handles BtnCreateDXF.Click
        CreateDXF()

        MsgBox("Completed")
    End Sub
#End Region

#Region "Main"
    'This is going to serve as the main method of selecting, creating and printing a list of marking strips
    Public Sub Main()
        If DataGridMain.SelectedRows Is Nothing Then
            MsgBox("Please select the cells you would like to print")
            Exit Sub
        End If

        PrintList.Clear()

        'Loops through every Part Number selected
        For Each row As DataGridViewRow In DataGridMain.SelectedRows
            Dim PN As String = row.Cells(0).Value
            Dim Qty As Integer = row.Cells(2).Value
            Dim PreviouslyRun As Boolean = CBool(row.Cells(3).Value)
            If PreviouslyRun = False Then
                MsgBox("One of the selected PNs has not been configured yet.")
                Exit Sub
            End If
            AddMarkingStrips(PrevDocsPath & PN & ".csv", PN)
        Next

        CreateDXF()

        MsgBox("Completed")
    End Sub
#End Region

#Region "LightBurn Controls"
    Private Sub BtnLoadFile_Click(sender As Object, e As EventArgs) Handles BtnLoadFile.Click
        SendAndReceive("LOADFILE:" & TxtFileName.Text)
    End Sub

    Private Sub BtnForceLoad_Click(sender As Object, e As EventArgs) Handles BtnForceLoad.Click
        SendAndReceive("FORCELOAD:" & TxtFileName.Text)
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        SendAndReceive("CLOSE")
    End Sub

    Private Sub BtnForceClose_Click(sender As Object, e As EventArgs) Handles BtnForceClose.Click
        SendAndReceive("FORCECLOSE")
    End Sub

    Private Sub BtnStart_Click(sender As Object, e As EventArgs) Handles BtnStart.Click
        SendAndReceive("START")
    End Sub

    Private Sub BtnStatus_Click(sender As Object, e As EventArgs) Handles BtnStatus.Click
        SendAndReceive("STATUS")
    End Sub

    Private Sub BtnPing_Click(sender As Object, e As EventArgs) Handles BtnPing.Click
        SendAndReceive("PING")
    End Sub


#End Region

#Region "Form Controls"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConnectSockets()
        TxtFileName.Text = CurrentDXFPath
        LoadPrevDocs()
        Timer1.Start()

    End Sub

#Region "User32 Controls"
    <DllImport("user32.dll")>
    Public Shared Function ShowWindow(hWnd As IntPtr, <MarshalAs(UnmanagedType.I4)> nCmdShow As ShowWindowCommands) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    Enum ShowWindowCommands As Integer
        ''' <summary>
        ''' Hides the window and activates another window.
        ''' </summary>
        Hide = 0
        ''' <summary>
        ''' Activates and displays a window. If the window is minimized or
        ''' maximized, the system restores it to its original size and position.
        ''' An application should specify this flag when displaying the window
        ''' for the first time.
        ''' </summary>
        Normal = 1
        ''' <summary>
        ''' Activates the window and displays it as a minimized window.
        ''' </summary>
        ShowMinimized = 2
        ''' <summary>
        ''' Maximizes the specified window.
        ''' </summary>
        Maximize = 3
        ' is this the right value?
        ''' <summary>
        ''' Activates the window and displays it as a maximized window.
        ''' </summary>      
        ShowMaximized = 3
        ''' <summary>
        ''' Displays a window in its most recent size and position. This value
        ''' is similar to <see cref="Win32.ShowWindowCommands.Normal"/>, except
        ''' the window is not actived.
        ''' </summary>
        ShowNoActivate = 4
        ''' <summary>
        ''' Activates the window and displays it in its current size and position.
        ''' </summary>
        Show = 5
        ''' <summary>
        ''' Minimizes the specified window and activates the next top-level
        ''' window in the Z order.
        ''' </summary>
        Minimize = 6
        ''' <summary>
        ''' Displays the window as a minimized window. This value is similar to
        ''' <see cref="Win32.ShowWindowCommands.ShowMinimized"/>, except the
        ''' window is not activated.
        ''' </summary>
        ShowMinNoActive = 7
        ''' <summary>
        ''' Displays the window in its current size and position. This value is
        ''' similar to <see cref="Win32.ShowWindowCommands.Show"/>, except the
        ''' window is not activated.
        ''' </summary>
        ShowNA = 8
        ''' <summary>
        ''' Activates and displays the window. If the window is minimized or
        ''' maximized, the system restores it to its original size and position.
        ''' An application should specify this flag when restoring a minimized window.
        ''' </summary>
        Restore = 9
        ''' <summary>
        ''' Sets the show state based on the SW_* value specified in the
        ''' STARTUPINFO structure passed to the CreateProcess function by the
        ''' program that started the application.
        ''' </summary>
        ShowDefault = 10
        ''' <summary>
        '''  <b>Windows 2000/XP:</b> Minimizes a window, even if the thread
        ''' that owns the window is not responding. This flag should only be
        ''' used when minimizing windows from a different thread.
        ''' </summary>
        ForceMinimize = 11
    End Enum
#End Region

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        'For Each proc As Process In Process.GetProcessesByName("acad")
        'proc.Kill()
        'Next

        'For Each proc As Process In Process.GetProcessesByName("astra")
        'proc.Kill()
        'Next

        'acadProc.StartInfo.FileName = acadPath
        'acadProc.Start()
        'ShowWindow(acadProc.MainWindowHandle, ShowWindowCommands.Hide)

        'lbProc.StartInfo.FileName = AstraExePath
        'lbProc.Start()
        'ShowWindow(lbProc.MainWindowHandle, ShowWindowCommands.Hide)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim procs As Process() = Process.GetProcessesByName("LightBurn")
        If procs.Length <> 0 Then
            lblLBStatus.Text = "LB Status: Good"
            lblLBStatus.ForeColor = Color.Green
        Else
            lblLBStatus.Text = "LB Status: Not Open"
            lblLBStatus.ForeColor = Color.Red
        End If

        Dim procs2 As Process() = Process.GetProcessesByName("acad")
        If procs2.Length <> 0 Then
            LblAcadStatus.Text = "Acad Status: Good"
            LblAcadStatus.ForeColor = Color.Green
        Else
            LblAcadStatus.Text = "Acad Status: Not Open"
            LblAcadStatus.ForeColor = Color.Red
        End If
    End Sub

    Public Sub LoadPrevDocs()
        ComboBoxPrevDocs.Items.Clear()
        Dim PrevDocs = GetPrevDocs()
        For Each item As IO.FileInfo In PrevDocs
            ComboBoxPrevDocs.Items.Add(item.Name)
        Next
    End Sub

    Private Sub BtnAddToOrder_Click(sender As Object, e As EventArgs) Handles BtnAddToOrder.Click
        If ComboBoxPrevDocs.SelectedItem Is Nothing Then
            MsgBox("Please select a previous document first")
        ElseIf TxtQty.Text Is Nothing Then
            MsgBox("Please enter a quantity to add")
        Else
            For i As Integer = 1 To CInt(TxtQty.Text)
                AddMarkingStrips(PrevDocsPath & ComboBoxPrevDocs.SelectedItem, CStr(ComboBoxPrevDocs.SelectedItem).Split(".")(0))
            Next
            AcadTxtBox.Clear()
            For Each MarkingStrip As MrkStrip In PrintList
                AcadTxtBox.Text &= MarkingStrip.Text & Environment.NewLine
            Next
        End If
    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        PrintList.Clear()
        AcadTxtBox.Clear()
    End Sub

    Private Sub DataGridMain_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridMain.CellDoubleClick
        If e.RowIndex >= 0 Then
            ActivePN = DataGridMain.Rows(e.RowIndex).Cells(0).Value.ToString()
            VariantCSV.Show()
        End If
    End Sub

    Private Sub BtnPrepareLB_Click(sender As Object, e As EventArgs) Handles BtnPrepareLB.Click
        Main()
    End Sub

    Private Sub BtnGetBOM_Click(sender As Object, e As EventArgs) Handles BtnGetBOM.Click
        GetBomAsync()
        CheckPrevious()
    End Sub

    Private Sub BtnOpenEditor_Click(sender As Object, e As EventArgs) Handles BtnOpenEditor.Click
        If txtCSVPN.Text = "" Then
            MsgBox("Please enter a partnumber")
        Else
            ActivePN = txtCSVPN.Text
            VariantCSV.Show()
        End If
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedTab Is TabAcad Then
            LoadPrevDocs()
        End If
    End Sub
#End Region

End Class
