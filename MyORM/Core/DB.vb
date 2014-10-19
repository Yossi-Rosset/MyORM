Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Data
Imports System.Threading
Imports System.Data.SqlClient
Imports System.Web
Imports System.Xml

Public Module DB

    Public UserID As Integer

    Private _cnn As New Dictionary(Of String, SqlClient.SqlConnection)

    Private Function GetSessionID() As String

        Return "USER" & UserID & ":" & My.Computer.Name

    End Function

    Private ReadOnly Property cnn() As SqlClient.SqlConnection
        Get
            Dim cn As SqlConnection
            Dim sessionid As String = GetSessionID()

            SyncLock _cnn

                If _cnn.ContainsKey(sessionid) Then

                    If _cnn(sessionid).State <> ConnectionState.Open Then _cnn(sessionid).Open()
                    Return _cnn(sessionid)

                End If

                cn = CreateConnection()
                _cnn.Add(sessionid, cn)

            End SyncLock

            Return cn

        End Get
    End Property

    Private Function CreateConnection() As SqlConnection
        Dim cn As SqlConnection

        Dim xmldoc As New XmlDocument

        xmldoc.LoadXml(IO.File.ReadAllText(Reflection.Assembly.GetExecutingAssembly.Location & ".config"))

        Dim bldr As New SqlConnectionStringBuilder()

        bldr.ConnectionString = xmldoc.SelectSingleNode("//add[@name='OyORM.My.MySettings.cnnStr']").Attributes("connectionString").Value

        xmldoc = Nothing

        bldr.ApplicationName = Reflection.Assembly.GetEntryAssembly().GetName().Name & GetSessionID()
        cn = New SqlConnection(bldr.ConnectionString)
        cn.Open()

        Return cn

    End Function

    Public Sub RemoveConnection()

        Dim sessionid As String = GetSessionID()

        If IsInTransaction() Then Return

        SyncLock _cnn

            If _cnn.ContainsKey(sessionid) Then

                _cnn.Remove(sessionid)

            End If

        End SyncLock

    End Sub

    Public Function NZ(oVal As Object, Optional ValueIfNull As String = "") As String
        If oVal Is Nothing OrElse String.IsNullOrWhiteSpace(oVal.ToString()) Then
            Return ValueIfNull
        Else
            Return oVal.ToString()
        End If
    End Function

    Public Function Q(sVal As String) As String
        Return "N'" + (If(sVal, "")).Replace("'", "''") + "'"
    End Function

    ''' <summary>
    ''' Like Q but without the N (use for non sql quoting)
    ''' </summary>
    Public Function AQ(sVal As String) As String
        Return "'" + sVal.Replace("'", "''") + "'"
    End Function

    Public Function QD(dt As DateTime) As String
        Return "N'" + dt.ToString("yyyyMMdd HH:mm:ss") + "'"
    End Function

    Public Function QDX(sVal As String) As String
        Return "N'" + DateTime.ParseExact(sVal, "yyyyMMdd", Thread.CurrentThread.CurrentCulture.DateTimeFormat).ToString("yyyy-MM-dd") + "'"
    End Function

    Public Function DateStr(sVal As Object, Format As String) As DateTime
        Return DateTime.ParseExact(sVal.ToString(), Format, Thread.CurrentThread.CurrentCulture.DateTimeFormat)
    End Function

    Public Function IsDate(sVal As Object, Optional sFormat As String = "") As Boolean
        Dim dt As DateTime
        If sFormat = "" Then
            Return DateTime.TryParse(NZ(sVal), dt)
        Else
            Try
                DateTime.ParseExact(NZ(sVal), sFormat, Thread.CurrentThread.CurrentCulture.DateTimeFormat)
                Return True
            Catch
                Return False

            End Try
        End If
    End Function

    Public Function Dlookup(sTableName As String, sFilter As String, sFieldName As String) As String
        Dim dt As DataTable = GetDatatable("SELECT TOP 1 [" & sFieldName & "] FROM [" & sTableName & "] " + (If(String.IsNullOrEmpty(sFilter), "", "WHERE " & sFilter)))

        If dt.Rows.Count = 0 Then
            Return ""
        End If

        Return DB.NZ(dt.Rows(0)(0))

    End Function

    Public Function Dlookup(sTableName As String, sFilter As String, sFieldName As String, sDBName As String) As String
        Dim dt As DataTable = GetDatatable("SELECT TOP 1 [" & sFieldName & "] FROM [" & sDBName + "]..[" & sTableName + "] " & (If(String.IsNullOrEmpty(sFilter), "", "WHERE " & sFilter)))

        If dt.Rows.Count = 0 Then
            Return ""
        End If

        Return DB.NZ(dt.Rows(0)(0))

    End Function

    Public Function GetScalar(sCommand As String) As Object
        Dim adp As New SqlDataAdapter(sCommand, cnn)

        Dim dt As New DataTable()

        adp.Fill(dt)

        Return dt.Rows(0).ItemArray(0)

    End Function

    Public Function DCount(sTableName As String, sFilter As String) As Integer
        Dim adp As New SqlDataAdapter("SELECT COUNT(*) FROM [" & sTableName & "] " & (If(String.IsNullOrEmpty(sFilter), "", "WHERE " & sFilter)), cnn)

        Dim dt As New DataTable()

        adp.Fill(dt)

        Return Integer.Parse(dt.Rows(0).ItemArray(0).ToString())

    End Function

    Public Function DCount(sTableName As String, sFilter As String, sDBName As String) As Integer

        Dim adp As New SqlDataAdapter("SELECT COUNT(*) FROM [" & sDBName & "]..[" & sTableName & "] " & (If(String.IsNullOrEmpty(sFilter), "", "WHERE " & sFilter)), cnn)

        Dim dt As New DataTable()

        adp.Fill(dt)

        Return Integer.Parse(dt.Rows(0).ItemArray(0).ToString())

    End Function


    Public Function DSum(sTableName As String, sFilter As String, ColumnName As String) As Decimal

        Dim adp As New SqlDataAdapter("SELECT ISNULL(SUM([" & ColumnName + "]),0) FROM [" & sTableName & "] " & (If(String.IsNullOrEmpty(sFilter), "", "WHERE " & sFilter)), cnn)

        Dim dt As New DataTable()

        adp.Fill(dt)

        Return Decimal.Parse(dt.Rows(0).ItemArray(0).ToString())

    End Function

    Public Function DSum(sTableName As String, sFilter As String, ColumnName As String, sDBName As String) As Decimal
        Dim adp As New SqlDataAdapter("SELECT ISNULL(SUM([" & ColumnName + "]),0) FROM [" & sTableName & "] " & (If(String.IsNullOrEmpty(sFilter), "", "WHERE " & sFilter)), cnn)

        Dim dt As New DataTable()

        adp.Fill(dt)

        Return Decimal.Parse(dt.Rows(0).ItemArray(0).ToString())

    End Function

    Public Function DMax(sTableName As String, sFilter As String, sFieldName As String) As Decimal
        Dim adp As New SqlDataAdapter("SELECT ISNULL(MAX([" & sFieldName + "]),0) FROM [" & sTableName & "] " & (If(String.IsNullOrEmpty(sFilter), "", Convert.ToString("WHERE ") & sFilter)), cnn)

        Dim dt As New DataTable()

        adp.Fill(dt)

        Return Decimal.Parse(dt.Rows(0).ItemArray(0).ToString())
    End Function

    Public Function DMin(sTableName As String, sFilter As String, sFieldName As String) As Decimal
        Dim adp As New SqlDataAdapter("SELECT ISNULL(MIN([" & sFieldName + "]),0) FROM [" & sTableName & "] " & (If(String.IsNullOrEmpty(sFilter), "", Convert.ToString("WHERE ") & sFilter)), cnn)

        Dim dt As New DataTable()

        adp.Fill(dt)

        Return Decimal.Parse(dt.Rows(0).ItemArray(0).ToString())
    End Function

    Public Function Execute(sCommand As String) As Integer
        Dim i As Integer = New SqlCommand(sCommand, cnn).ExecuteNonQuery()

        Return i

    End Function

    Public Function GetDatatable(sSql As String) As DataTable
        Dim adp As New SqlDataAdapter(sSql, cnn)

        Dim tbl As New DataTable()

        adp.Fill(tbl)

        Return tbl

    End Function



    Public Sub BeginTran()
        Dim i As Integer = New SqlCommand("BEGIN TRAN", cnn).ExecuteNonQuery()
    End Sub

    Public Sub Commit()
        If IsInTransaction() Then
            DB.Execute("COMMIT TRAN")
        End If
    End Sub

    Public Function IsInTransaction() As Boolean

        Dim adp As New SqlDataAdapter("SELECT @@TRANCOUNT", cnn)

        Dim dt As New DataTable()

        adp.Fill(dt)

        Return DB.NZ(dt.Rows(0).ItemArray(0)) <> "0"

    End Function

    Public Sub Rollback()
        If IsInTransaction() Then
            DB.Execute("ROLLBACK TRAN")
        End If
    End Sub

    Public Function SQLInsert(sTableName As String, ParamArray list As String()) As String
        Dim sRes As String = "INSERT INTO " & sTableName & "(#fields#) VALUES(#values#)"
        Dim sFields As String
        Dim sValues As String

        'Get even elements to fields list
        sFields = String.Join(",", list.Select(Function(field, index) New With { _
            Key .Index = index, _
            Key .Field = field _
        }).Where(Function(p) p.Index Mod 2 = 0).[Select](Function(field) field.Field))
        'Get odd elements to values list
        sValues = String.Join(",", list.Select(Function(field, index) New With { _
            Key .Index = index, _
            Key .Field = field _
        }).Where(Function(p) p.Index Mod 2 <> 0).Select(Function(field) field.Field))

        'combine statement
        Return sRes.Replace("#fields#", sFields).Replace("#values#", sValues)

    End Function

    Public Function SQLInsert(sTableName As String, fields As String(), Values As String()) As String
        Dim sRes As String = "INSERT INTO [" & sTableName & "] ([#fields#]) VALUES (#values#)"
        Dim sFields As String
        Dim sValues As String

        'Get even elements to fields list
        sFields = String.Join("],[", fields)
        'Get odd elements to values list
        sValues = String.Join(",", Values)

        'combine statement
        Return sRes.Replace("#fields#", sFields).Replace("#values#", sValues)

    End Function

    Public Function SQLUpdate(sTableName As String, ParamArray list As String()) As String
        Dim sValues As String

        'list of fields to update
        ' add index to list
        ' select just the odd numbers
        sValues = String.Join(",", list.[Select](Function(value, index) New With { _
            Key .Index = index, _
            Key .Value = value _
        }).Where(Function(p) p.Index Mod 2 <> 0).[Select](Function(value) "[" + list(value.Index - 1).ToString() + "]=" + value.Value + " "))
        ' add to the even elements(Field names) with value
        'Concat statement
        Return "UPDATE [" & sTableName & "] SET " & sValues

    End Function

    Public Function SQLUpdate(sTableName As String, fields As String(), Values As String()) As String
        Dim sValues As String

        'list of fields to update
        ' add index to list
        sValues = String.Join(",", fields.[Select](Function(field, index) New With { _
            Key .Index = index, _
            Key .Value = field _
        }).[Select](Function(field) "[" + field.Value + "]=" + Values(field.Index).ToString() + " "))
        ' add the elements(Field names) with value
        'Concat statement
        Return "UPDATE [" & sTableName & "] SET " & sValues

    End Function

    Public Function IsTableExists(TableName As String) As Boolean
        If DB.DCount("sysobjects", "name = " & DB.Q(TableName) + " AND xtype = 'U'") = 0 Then
            Return False
        End If

        Return True
    End Function

    Public Function IsTableExists(TableName As String, DBName As String) As Boolean
        If DB.DCount("sysobjects", "name = " & DB.Q(TableName) & " AND xtype = 'U'", DBName) = 0 Then
            Return False
        End If

        Return True
    End Function

    Public Function GetList(sSql As String) As List(Of String)
        Return GetDatatable(sSql).Select().Select(Of String)(Function(p) p.Item(0).ToString()).ToList()
    End Function


End Module

