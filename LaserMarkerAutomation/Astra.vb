Imports System.Xml
Imports System.IO
Imports System.Text

Module Astra
    Public Sub CreateXML(filepath As String, PrintList As List(Of MrkStrip))
        Try
            Using xmlDoc As New XmlTextWriter(filepath, System.Text.Encoding.UTF8)
                xmlDoc.WriteStartDocument(True)
                xmlDoc.Formatting = Formatting.Indented
                xmlDoc.Indentation = 2

                xmlDoc.WriteStartElement("data")

                xmlDoc.WriteStartElement("data_order")
                xmlDoc.WriteAttributeString("name", "EthanTest")

                xmlDoc.WriteStartElement("list_materials")

                xmlDoc.WriteStartElement("material")
                xmlDoc.WriteAttributeString("name", "TestMaterial")

                xmlDoc.WriteStartElement("list_parts")

                For Each strip As MrkStrip In PrintList
                    xmlDoc.WriteStartElement("part")
                    xmlDoc.WriteAttributeString("number", strip.Number.ToString)
                    xmlDoc.WriteAttributeString("quantity", "1")
                    xmlDoc.WriteAttributeString("length", strip.SizeX.ToString)
                    xmlDoc.WriteAttributeString("width", strip.SizeY.ToString)
                    xmlDoc.WriteAttributeString("thick", "1.0")
                    xmlDoc.WriteAttributeString("rotate", "1")
                    xmlDoc.WriteEndElement()
                Next

                xmlDoc.WriteEndElement()

                xmlDoc.WriteStartElement("list_sheets")

                'length=24 and width=12 for newer 24x12 sheets, 24x20 until then
                xmlDoc.WriteStartElement("sheet")
                xmlDoc.WriteAttributeString("length", "24")
                xmlDoc.WriteAttributeString("width", "12")
                xmlDoc.WriteAttributeString("thick", "1.0")
                xmlDoc.WriteEndElement()

                xmlDoc.WriteEndElement()
                xmlDoc.WriteEndElement()
                xmlDoc.WriteEndElement()
                xmlDoc.WriteEndElement()
                xmlDoc.WriteEndElement()

                xmlDoc.WriteEndDocument()
            End Using
        Catch ex As Exception
            MsgBox("Error creating the xml document of marking strips. Please close the application and restart")
        End Try

    End Sub

    Public Function ReadXML(filepath As String, ByRef PrintList As List(Of MrkStrip), ByVal Optional NestingPlanNum As Integer = 0) As List(Of MrkStrip)
        Dim NewList As New List(Of MrkStrip)
        Try
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance)
            Using fs As New FileStream(filepath, FileMode.Open, FileAccess.Read)
                Dim xmlDoc As New XmlDataDocument()
                xmlDoc.Load(fs)
                Dim xmlNodeList As XmlNodeList = xmlDoc.GetElementsByTagName("nesting_plan")

                For i As Integer = 0 To xmlNodeList(NestingPlanNum).ChildNodes.Item(0).ChildNodes.Count - 1
                    Dim sNumber = xmlNodeList(NestingPlanNum).ChildNodes.Item(0).ChildNodes.Item(i).Attributes.GetNamedItem("number").InnerText
                    Dim CoordX = xmlNodeList(NestingPlanNum).ChildNodes.Item(0).ChildNodes.Item(i).Attributes.GetNamedItem("x").InnerText
                    Dim CoordY = xmlNodeList(NestingPlanNum).ChildNodes.Item(0).ChildNodes.Item(i).Attributes.GetNamedItem("y").InnerText
                    Dim Rotate = xmlNodeList(NestingPlanNum).ChildNodes.Item(0).ChildNodes.Item(i).Attributes.GetNamedItem("rotate").InnerText
                    For Each MarkingStrip As MrkStrip In PrintList
                        If MarkingStrip.Number = sNumber Then
                            MarkingStrip.CoordX = CDbl(CoordX)
                            MarkingStrip.CoordY = CDbl(CoordY)
                            MarkingStrip.Rotate = CBool(Rotate)
                            NewList.Add(MarkingStrip)
                            Exit For
                        End If
                    Next
                Next
            End Using
        Catch ex As Exception
            MsgBox("Error reading the xml document of marking strip coordinates. Please close the application and restart")
        End Try

        Return NewList
    End Function

    Public Sub StartNesting()
        Try
            If CheckIfRunning("Astra") Then
                For Each proc As Process In Process.GetProcessesByName("Astra")
                    proc.Kill()
                Next
            End If

            Threading.Thread.Sleep(150)

            Process.Start(NestingBatPath)

            Threading.Thread.Sleep(250)

            'Once the output file is there we know nesting is complete
            While File.Exists(AstraReadPath) = False
                Threading.Thread.Sleep(250)
            End While

            'Go ahead and wait until Astra is all the way closed
            While CheckIfRunning("Astra")
                Threading.Thread.Sleep(250)
            End While
        Catch ex As Exception
            MsgBox("Error nesting the order. Please close the application and restart")
        End Try

    End Sub

    Public Function CheckIfRunning(ByVal sProcess As String) As Boolean
        Dim p() As Process = Process.GetProcessesByName(sProcess)
        If p.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Module
