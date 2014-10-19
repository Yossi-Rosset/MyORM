Public Class frmHistory

    Public Const ActionQS As String = "SELECT 'I' Value, 'יצירת חדש' Name UNION SELECT 'D' ,'מחיקה' UNION SELECT 'U' ,'עדכון'"

    Private Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(obj As cRecord)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Dim tbl As DataTable = GetDatatable("SELECT " & Q(obj.MyInfo.Caption) & " AS ObjName,* FROM [H_" & obj.MyInfo.TableName & "] WHERE [Key] = " & obj.Key)

        For Each p As ObjectFieldInfo In obj.FieldsInfo
            For Each row In tbl.Rows

                If NZ(row("ColumnName")) = "Object" Then
                    row("ColumnName") = ""
                    Continue For
                End If

                If NZ(row("ColumnName")) = p.MappingName Then
                    row("ColumnName") = p.Caption
                End If
            Next
        Next


        For Each inf As ObjectInfo In obj.ChildrenInfo

            Dim sPK As String = cRecord.DicKeyInfo(inf.ObjectType.FullName).MappingName
            Dim sFK As String = inf.ParentForeignKey

            If Not IsTableExists("H_" & inf.TableName) Then Continue For

            Dim tblchild As DataTable =
                GetDatatable("SELECT " & Q(inf.Caption) & " AS ObjName,* FROM [H_" & inf.TableName & "]" &
                             " WHERE [Key] IN (SELECT " & sPK & " FROM " & inf.TableName & " WHERE [" & sFK & "] = " & obj.Key & ")")

            For Each p As ObjectFieldInfo In cRecord.DicFieldsInfo(inf.ObjectType.FullName)
                For Each row In tblchild.Rows

                    If NZ(row("ColumnName")) = "Object" Then
                        row("ColumnName") = ""
                        Continue For
                    End If

                    If NZ(row("ColumnName")) = p.MappingName Then
                        row("ColumnName") = p.Caption
                    End If
                Next
            Next

            tbl.Merge(tblchild)

        Next


        DataGridView1.AutoGenerateColumns = False

        DataGridView1.DataSource = tbl

    End Sub



    Private Sub frmHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        colAction.DataSource = DB.GetDatatable(ActionQS)
        colAction.ValueMember = "Value"
        colAction.DisplayMember = "Name"


        colUserSign.DataSource = DB.GetDatatable(cUser.UserQS)
        colUserSign.ValueMember = "Value"
        colUserSign.DisplayMember = "Name"


    End Sub


    Private Sub DataGridView1_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError

    End Sub
End Class