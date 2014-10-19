Public Class frmFind

    Dim frm As frmBase

    Private Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub


    Public Sub New(tbl As DataTable, frm As frmBase)

        ' This call is required by the designer.
        InitializeComponent()

        Me.frm = frm

        ' Add any initialization after the InitializeComponent() call.

        For Each inf As ObjectFieldInfo In frm.obj.FieldsInfo

            If tbl.Columns.Contains(inf.MappingName) = False Then Continue For

            If inf.QueryString <> "" Then

                Dim vals As DataTable = DB.GetDatatable(inf.QueryString)

                vals.PrimaryKey = {vals.Columns(0)}

                tbl.Columns.Add("_" & inf.MappingName, GetType(String))

                For Each row As DataRow In tbl.Rows

                    If NZ(row(inf.MappingName), "0") = "0" Then Continue For

                    Dim val As DataRow = vals.Rows.Find(row(inf.MappingName))

                    If val Is Nothing Then Continue For

                    row("_" & inf.MappingName) = val(1)

                Next

                tbl.Columns.Remove(inf.MappingName)

                tbl.Columns("_" & inf.MappingName).ColumnName = inf.Caption

            Else

                tbl.Columns(inf.MappingName).ColumnName = inf.Caption

            End If

        Next

        Grd1.DataSource = tbl


    End Sub

    Private Sub Grd1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grd1.CellContentClick

        If e.ColumnIndex <> colOpen.Index Then Return

        Dim frm As Object = Activator.CreateInstance(Me.frm.GetType(), True)

        frm.LoadData(Grd1.Rows(e.RowIndex).Cells(1).Value)

        frm.show()

    End Sub

    Private Sub Grd1_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Grd1.RowHeaderMouseDoubleClick

        Me.Close()

        frm.LoadData(Grd1.Rows(e.RowIndex).Cells(1).Value)

    End Sub

    Private Sub Grd1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grd1.CellContentDoubleClick

        Me.Close()

        frm.LoadData(Grd1.Rows(e.RowIndex).Cells(1).Value)

    End Sub
End Class