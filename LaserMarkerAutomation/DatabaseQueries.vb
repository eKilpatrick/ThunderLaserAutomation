Module DatabaseQueries
    Public Function GetBOM(SN As String) As DataTable
        Dim dal As New DALControl
        Dim query As String = "SELECT * FROM SFM_RCH.SO_BOM WHERE SD = '" & SN & "'"
        dal.RunQuery(query)
        Return dal.SQLDataset01.Tables(0)
    End Function

    Public Sub UpdatePN(PN As String, BT As String, MT As String)
        Dim dal As New DALControl
        Dim query As String = "SELECT * FROM SFM_RCH.Y_THUNDER_LASER WHERE PARTNUMBER = '" & PN & "'"
        dal.RunQuery(query)
        If dal.SQLDataset01.Tables(0).Rows.Count <> 0 Then
            query = "UPDATE SFM_RCH.Y_THUNDER_LASER SET BASETEMPLATE = '" & BT & "', MATERIALTYPE = '" & MT & "' WHERE PARTNUMBER = '" & PN & "'"
        Else
            query = "INSERT INTO SFM_RCH.Y_THUNDER_LASER (PARTNUMBER, BASETEMPLATE, MATERIALTYPE) VALUES ('" & PN & "', '" & BT & "', '" & MT & "')"
        End If
        Dim dal2 As New DALControl
        dal2.RunQuery(query)
    End Sub

    'Gets the previous base template
    Public Function GetPrev(PN As String) As String
        Dim dal As New DALControl
        Dim query As String = "SELECT * FROM SFM_RCH.Y_THUNDER_LASER WHERE PARTNUMBER = '" & PN & "'"
        dal.RunQuery(query)
        If dal.SQLDataset01.Tables(0).Rows.Count <> 0 Then
            Return dal.SQLDataset01.Tables(0).Rows(0).Item(1)
        Else
            Return String.Empty
        End If
    End Function
End Module
