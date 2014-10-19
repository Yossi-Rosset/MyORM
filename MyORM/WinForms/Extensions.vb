Imports System.Windows.Forms

Public Module Extensions



    <System.Runtime.CompilerServices.Extension> _
    Public Function AllControls(ctl As Control) As Control()
        Return GetControls(ctl)
    End Function

    Private Function GetControls(ctl As Control) As Control()
        Dim lst As New List(Of Control)

        lst.Add(ctl)

        If ctl.HasChildren And ctl.GetType() <> GetType(HDateTimePicker) Then
            For Each child As Control In ctl.Controls
                lst.AddRange(GetControls(child))
            Next
        End If

        Return lst.ToArray()

    End Function

    Public Function GetVatPercent() As Decimal
        Return 0
    End Function


    <Runtime.CompilerServices.Extension()> _
    Public Sub Add(Of T)(ByRef arr As T(), item As T)
        Array.Resize(arr, arr.Length + 1)
        arr(arr.Length - 1) = item
    End Sub

#Region "cRecord Extenstions"

    <System.Runtime.CompilerServices.Extension> _
    Public Function LinesToTable(obj As cRecord, LinesTableName As String) As DataTable

        Dim lines As cRecord() = CallByName(obj, LinesTableName, CallType.Get, Nothing)

        Dim childInf As ObjectInfo() = cRecord.DicChildrenInfo(obj.GetType().FullName).Where(Function(p) p.TableName = LinesTableName).ToArray()

        If childInf.Length = 0 Then Throw New Exception("Info for LinesToTable not defined " & LinesTableName)

        Dim inf As ObjectFieldInfo() = cRecord.DicFieldsInfo(childInf(0).ObjectType.FullName).ToArray()

        Dim tbl As New DataTable(LinesTableName)

        For Each i As ObjectFieldInfo In inf

            tbl.Columns.Add(i.MappingName, i.PropInfo.PropertyType)

        Next

        If lines IsNot Nothing Then

            For Each line As Object In lines

                Dim newRow As DataRow = tbl.NewRow

                For Each i As ObjectFieldInfo In inf

                    Dim val As Object = CallByName(line, i.PropInfo.Name, CallType.Get, Nothing)

                    If i.PropInfo.PropertyType = GetType(Date) Then
                        newRow(i.MappingName) = If(val = DateTime.MinValue, DBNull.Value, val)
                    Else
                        newRow(i.MappingName) = val
                    End If



                Next

                tbl.Rows.Add(newRow)
            Next

        End If

        Return tbl

    End Function

    <System.Runtime.CompilerServices.Extension> _
    Public Function TableToLines(obj As cRecord, tbl As DataTable) As cRecord()

        Dim lst As New List(Of cRecord)

        If tbl Is Nothing Then Return lst.ToArray()

        Dim typ As ObjectInfo() = cRecord.DicChildrenInfo(obj.GetType.FullName).Where(Function(p) p.TableName = tbl.TableName).ToArray()

        If typ.Length = 0 Then Throw New Exception("Info for TableToLines not defined " & tbl.TableName)

        For Each row As DataRow In tbl.Rows

            If row.RowState = DataRowState.Detached Or row.RowState = DataRowState.Deleted Then Continue For

            Dim rec As cRecord = Activator.CreateInstance(typ(0).ObjectType)

            Dim inf As ObjectFieldInfo() = cRecord.DicFieldsInfo(typ(0).ObjectType.FullName).ToArray()

            For Each i As ObjectFieldInfo In inf

                Select Case i.PropInfo.PropertyType

                    Case GetType(Integer)

                        CallByName(rec, i.PropInfo.Name, CallType.Let, NZ(row(i.MappingName), 0))

                    Case GetType(Decimal), GetType(Double)

                        CallByName(rec, i.PropInfo.Name, CallType.Let, NZ(row(i.MappingName), 0))

                    Case GetType(String)

                        CallByName(rec, i.PropInfo.Name, CallType.Let, NZ(row(i.MappingName), ""))

                    Case GetType(DateTime)

                        CallByName(rec, i.PropInfo.Name, CallType.Let, If(NZ(row(i.MappingName), "") = "", Nothing, row(i.MappingName)))

                End Select



            Next
            lst.Add(rec)

        Next

        Return lst.ToArray()

    End Function

    <System.Runtime.CompilerServices.Extension> _
    Public Function GetFirst(obj As cRecord) As Integer

        Dim tblName As String = cRecord.DicObjInfo(obj.GetType.FullName).TableName
        Dim key As String = cRecord.DicKeyInfo(obj.GetType.FullName).MappingName

        Return DB.DMin(tblName, "", key)

    End Function

    <System.Runtime.CompilerServices.Extension> _
    Public Function GetLast(obj As cRecord) As Integer
        Dim tblName As String = cRecord.DicObjInfo(obj.GetType.FullName).TableName
        Dim key As String = cRecord.DicKeyInfo(obj.GetType.FullName).MappingName

        Return DB.DMax(tblName, "", key)
    End Function

    <System.Runtime.CompilerServices.Extension> _
    Public Function GetBack(obj As cRecord) As Integer

        Dim tblName As String = cRecord.DicObjInfo(obj.GetType.FullName).TableName
        Dim key As String = cRecord.DicKeyInfo(obj.GetType.FullName).MappingName
        Dim curr As Integer = CallByName(obj, cRecord.DicKeyInfo(obj.GetType.FullName).PropInfo.Name, CallType.Get, Nothing)

        Return DB.DMax(tblName, key & "<" & curr, key)

    End Function

    <System.Runtime.CompilerServices.Extension> _
    Public Function GetNext(obj As cRecord) As Integer

        Dim tblName As String = cRecord.DicObjInfo(obj.GetType.FullName).TableName
        Dim key As String = cRecord.DicKeyInfo(obj.GetType.FullName).MappingName
        Dim curr As Integer = CallByName(obj, cRecord.DicKeyInfo(obj.GetType.FullName).PropInfo.Name, CallType.Get, Nothing)

        Return DB.DMin(tblName, key & ">" & curr, key)

    End Function


#End Region


End Module
