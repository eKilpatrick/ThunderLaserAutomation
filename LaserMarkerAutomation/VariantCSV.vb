Public Class VariantCSV
#Region "Global Vars"
    Public ActivePN As String = ""
    Public SelectedBaseTemplate As List(Of String)
    Public PreviouslyRun As Boolean = False
#End Region

#Region "Form Controls"
    Private Sub VariantCSV_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LblActivePN.Text = "Active PN: " & Form1.ActivePN
        ActivePN = Form1.ActivePN
        LoadBaseTemplates()
        Dim PrevTemplate As String = GetPrev(ActivePN)
        If PrevTemplate <> String.Empty Then
            ComboBoxBaseTemplates.SelectedItem = PrevTemplate
            PreviouslyRun = True
        End If
    End Sub

    Private Sub VariantCSV_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If PreviouslyRun Then
            DataGridView1.Rows.Clear()
            Dim fileName As String = ActivePN & ".csv"
            Dim filepath As String = PrevDocsPath & fileName
            If IO.File.Exists(filepath) Then
                Dim fs As New IO.FileStream(filepath, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.ReadWrite)
                Using sr As New IO.StreamReader(fs)
                    For Each line As String In sr.ReadToEnd().Split(Environment.NewLine)
                        Dim currentIndex = DataGridView1.Rows.Add()
                        Try
                            For i As Integer = 0 To line.Split(",").Length - 1
                                DataGridView1.Rows(currentIndex).Cells(i).Value = line.Split(",")(i)
                            Next
                        Catch ex As Exception
                        End Try
                    Next
                End Using
                DrawTemplate(SelectedBaseTemplate)
            Else
                MsgBox("For some reason, this file is in the database as having existed, but does not exist in the PrevDocs directory. Please manually confirm and sort this out.")
            End If
        End If
    End Sub

    Private Sub ComboBoxBaseTemplates_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxBaseTemplates.SelectedIndexChanged
        SelectedBaseTemplate = GetBaseTemplateSpecs(ComboBoxBaseTemplates.SelectedItem)

        If CInt(SelectedBaseTemplate(6)) <> 0 Then
            DataGridView1.Columns.Clear()
            For i As Integer = 1 To CInt(SelectedBaseTemplate(6))
                DataGridView1.Columns.Add("TextInfo" & i, "Text Info " & i)
            Next
            DataGridView1.Columns.Add("Qty", "Quantity")
            DataGridView1.AutoResizeColumns()
        Else
            DataGridView1.Columns.Clear()
            DataGridView1.Columns.Add("TextInfo1", "Text Info")
            DataGridView1.Columns.Add("Qty", "Quantity")
            DataGridView1.AutoResizeColumns()
        End If

        DrawTemplate(SelectedBaseTemplate)
    End Sub

    Public Sub LoadBaseTemplates()
        ComboBoxBaseTemplates.Items.Clear()
        Dim BaseTemplates = GetBaseTemplates()
        For Each item As String In BaseTemplates
            If item.Trim.Contains("PartNum") = False Then
                ComboBoxBaseTemplates.Items.Add(item)
            End If
        Next
    End Sub
#End Region

#Region "CSV"
    Private Sub BtnCreateCSV_Click(sender As Object, e As EventArgs) Handles BtnCreateCSV.Click
        Try
            Using sw As New IO.StreamWriter(PrevDocsPath & ActivePN & ".csv", False)
                For Each row As DataGridViewRow In DataGridView1.Rows

                    If SelectedBaseTemplate(6) = 0 Then
                        If row.Cells.Item(1).Value = Nothing Then
                            sw.WriteLine(row.Cells.Item(0).Value)
                        Else
                            For i As Integer = 1 To row.Cells.Item(1).Value
                                sw.WriteLine(row.Cells.Item(0).Value)
                            Next
                        End If
                    Else
                        If row.Cells.Item(CInt(SelectedBaseTemplate(6))).Value = Nothing Then
                            For i As Integer = 0 To CInt(SelectedBaseTemplate(6)) - 1
                                sw.Write(row.Cells.Item(i).Value & ",")
                            Next
                            sw.WriteLine()
                        Else
                            For j As Integer = 1 To row.Cells.Item(CInt(SelectedBaseTemplate(6))).Value
                                For i As Integer = 0 To CInt(SelectedBaseTemplate(6)) - 1
                                    sw.Write(row.Cells.Item(i).Value & ",")
                                Next
                                sw.WriteLine()
                            Next
                        End If
                    End If

                Next
            End Using
        Catch ex As Exception
            MsgBox("File might be open and locked for editing")
        End Try

        'Black is the default for now, we will add the option to choose later.
        UpdatePN(ActivePN, SelectedBaseTemplate(0), "Black")
    End Sub
#End Region

#Region "UI"
    Public Sub DrawTemplate(TemplateSpecs As List(Of String))
        Using g As Graphics = PanelVisual.CreateGraphics()
            g.Clear(Color.WhiteSmoke)
            Dim BlackPen As New Pen(Brushes.Black)

            Dim x As Double = TemplateSpecs(1)
            Dim y As Double = TemplateSpecs(2)
            Dim holeDiam As Double = TemplateSpecs(3)
            Dim holeDistX As Double = TemplateSpecs(4)
            Dim holeDistY As Double = TemplateSpecs(5)
            Dim MultiText As Integer = TemplateSpecs(6)
            Dim TextLoc As String = TemplateSpecs(7)

            Dim panelHeight = PanelVisual.Height
            Dim panelWidth = PanelVisual.Width

            Dim scale = 0

            'If x > y -> x = height /// Else x < y -> x = width
            If x > y Then

                If panelHeight / (x * 2) < panelWidth / (y * 2) Then
                    scale = panelHeight / (x * 2)
                Else
                    scale = panelWidth / (y * 2)
                End If

                Dim startingX = (panelWidth / 2) - ((y * scale) / 2)
                Dim startingY = (panelHeight / 2) - ((x * scale) / 2)

                Dim startingPoint As New Point(startingX, startingY)
                Dim rectSize As New Size(Math.Round(y * scale), Math.Round(x * scale))
                Dim rect As New Rectangle(startingPoint, rectSize)
                g.DrawRectangle(BlackPen, rect)

                Dim circleX1 = startingX + (holeDistY * scale) - ((holeDiam * scale) / 2)
                Dim circleY1 = startingY + (holeDistX * scale) - ((holeDiam * scale) / 2)
                Dim circleX2 = startingX + (y * scale) - (holeDistY * scale) - ((holeDiam * scale) / 2)
                Dim circleY2 = startingY + (x * scale) - (holeDistX * scale) - ((holeDiam * scale) / 2)

                Dim circlePoint As New Point(circleX1, circleY1)
                Dim circlePoint2 As New Point(circleX2, circleY2)

                Dim circleRectSize As New Size(Math.Round(holeDiam * scale), Math.Round(holeDiam * scale))
                Dim circleRect As New Rectangle(circlePoint, circleRectSize)
                Dim circleRect2 As New Rectangle(circlePoint2, circleRectSize)

                g.DrawEllipse(BlackPen, circleRect)
                g.DrawEllipse(BlackPen, circleRect2)

                LblHeight.Text = "Height: " & x
                LblWidth.Text = "Width: " & y

            Else
                If panelHeight / (y * 2) < panelWidth / (x * 2) Then
                    scale = panelHeight / (y * 2)
                Else
                    scale = panelWidth / (x * 2)
                End If

                Dim startingX = (panelWidth / 2) - ((x * scale) / 2)
                Dim startingY = (panelHeight / 2) - ((y * scale) / 2)

                Dim startingPoint As New Point(startingX, startingY)
                Dim rectSize As New Size(Math.Round(x * scale), Math.Round(y * scale))
                Dim rect As New Rectangle(startingPoint, rectSize)
                g.DrawRectangle(BlackPen, rect)

                Dim circleX1 = startingX + (holeDistX * scale) - ((holeDiam * scale) / 2)
                Dim circleY1 = startingY + (holeDistY * scale) - ((holeDiam * scale) / 2)
                Dim circleX2 = startingX + (x * scale) - (holeDistX * scale) - ((holeDiam * scale) / 2)
                Dim circleY2 = startingY + (y * scale) - (holeDistY * scale) - ((holeDiam * scale) / 2)

                Dim circlePoint As New Point(circleX1, circleY1)
                Dim circlePoint2 As New Point(circleX2, circleY2)

                Dim circleRectSize As New Size(Math.Round(holeDiam * scale), Math.Round(holeDiam * scale))
                Dim circleRect As New Rectangle(circlePoint, circleRectSize)
                Dim circleRect2 As New Rectangle(circlePoint2, circleRectSize)

                g.DrawEllipse(BlackPen, circleRect)
                g.DrawEllipse(BlackPen, circleRect2)

                LblHeight.Text = "Height: " & y
                LblWidth.Text = "Width: " & x
            End If

            LblHoleDiam.Text = "Hole Diameter: " & holeDiam
            If MultiText = 0 Then
                LblText.Text = "# of Text: " & 1
            Else
                LblText.Text = "# of Text: " & MultiText
            End If


            Invalidate()
        End Using
    End Sub
#End Region
End Class