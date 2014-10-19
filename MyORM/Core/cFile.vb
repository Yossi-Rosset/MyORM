<ObjectInfo("Files", "Attachments")> _
Public Class cFile
    Inherits cUserTrackingRecord

    <ObjectFieldInfo("File ID", "FilID", PrimaryKey:=True)> _
    Public Property FilID As Integer

    <ObjectFieldInfo("File Table", "TableName", True)> _
    Public Property TableName As String

    <ObjectFieldInfo("Object ID", "ObjectID", True)> _
    Public Property ObjectID As String

    <ObjectFieldInfo("File Name", "Name", True)> _
    Public Property Name As String

    Dim _Content As Byte()

    <ObjectFieldInfo("File Content", "Content", True)> _
    Public Property Content As Byte()
        Set(value As Byte())
            _Content = value
            If value IsNot Nothing Then FileSize = Math.Round(value.Length / 1024, 2)
        End Set
        Get
            Return _Content
        End Get
    End Property

    Public Property FileSize As Integer


    Public Shared Function GetFilesList(TableName As String, ObjectID As Integer, Optional IncludeContent As Boolean = False) As cFile()

        Dim Files As New List(Of cFile)

        Dim tbl As DataTable = GetDatatable("SELECT FilID, TableName, Name, ROUND(DATALENGTH(Content) / 1024.0,2) AS FileSize" & IIf(IncludeContent, ", Content", "") & " FROM Files WHERE TableName=" & Q(TableName) & " AND ObjectID =" & ObjectID)

        For Each row As DataRow In tbl.Rows
            Dim file As New cFile With {.FilID = row("FilID"), .Name = row("Name"), .TableName = row("TableName"), .FileSize = row("FileSize")}
            If IncludeContent Then file.Content = row("Content")
            Files.Add(file)
        Next

        Return Files.ToArray()

    End Function

    Public Shared Function GetFileContent(FileID As Integer) As Byte()

        Dim o As Object = DB.GetScalar("SELECT Content FROM Files WHERE FilID =" & FileID)

        If o.GetType().Name = "Byte[]" Then
            Return o
        Else
            Return Nothing
        End If

    End Function




End Class
