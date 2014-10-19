Imports System.Reflection
Imports System.Data.SqlClient


Public Class ObjectInfo
    Inherits Attribute

    Public Property TableName() As String

    Public Property Caption() As String

    Public Property ParentForeignKey() As String

    Public Property ObjectType() As Type

    Sub New(ByVal TableName As String,
            Optional ByVal Caption As String = "",
            Optional ByVal ParentForeignKey As String = "")

        Me.TableName = TableName
        Me.Caption = Caption
        Me.ParentForeignKey = ParentForeignKey
    End Sub

End Class

Public Class ObjectFieldInfo
    Inherits Attribute

    ' Specifies if field is mandatory
    Public Property Mandatory() As Boolean

    ' Valid values from query string
    Public Property QueryString() As String

    ' Mapping name to table
    Public Property MappingName() As String

    ' Returns field's caption
    Public Property Caption() As String

    ' Maximum field length allowed
    Public Property MaxLength() As Integer

    ' If the value is empty, set the value to this value
    Public Property DefaultValue As Object

    'Primary Key Field
    Public Property PrimaryKey As Boolean

    'Object .Net PropertyInfo
    Public Property PropInfo As PropertyInfo

    'Optional Formatting string
    Public Property Format As String

    Sub New(Optional ByVal Caption As String = "",
            Optional ByVal MappingName As String = "",
            Optional ByVal Mandatory As Boolean = False, _
            Optional ByVal QueryString As String = "", _
            Optional ByVal PrimaryKey As Boolean = False,
            Optional ByVal MaxLength As Integer = 0,
            Optional ByVal DefaultValue As Object = Nothing
            )


        Me.Mandatory = Mandatory
        Me.QueryString = QueryString
        Me.MappingName = MappingName
        Me.MaxLength = MaxLength
        Me.DefaultValue = DefaultValue
        Me.PrimaryKey = PrimaryKey
        Me.Caption = Caption

    End Sub
End Class

Public MustInherit Class cRecord

    Public Shared HistoryTablePrefix As String = "H_"
    Public Shared HistoryLinesTablePrefix As String = "HL_"

    Private _MyInfo As ObjectInfo
    Private _FieldsInfo As ObjectFieldInfo()
    Private _KeyInfo As ObjectFieldInfo
    Private _Children As PropertyInfo()
    Private _ChildrenInfo As ObjectInfo()

    Public ReadOnly Property MyInfo As ObjectInfo
        Get
            Return _MyInfo
        End Get
    End Property
    Public ReadOnly Property FieldsInfo As ObjectFieldInfo()
        Get
            Return _FieldsInfo
        End Get
    End Property
    Public ReadOnly Property KeyInfo As ObjectFieldInfo
        Get
            Return _KeyInfo
        End Get
    End Property
    Public ReadOnly Property Children As PropertyInfo()
        Get
            Return _Children
        End Get
    End Property
    Public ReadOnly Property ChildrenInfo As ObjectInfo()
        Get
            Return _ChildrenInfo
        End Get
    End Property


    Public Structure Result
        Public Success As Boolean
        Public ErrorCode As Integer
        Public Message As String
    End Structure

    Sub New()
        SingletonTypeReflection(Me.GetType())
        SetDefaults()

        _MyInfo = DicObjInfo(Me.GetType().FullName)
        _FieldsInfo = DicFieldsInfo(Me.GetType().FullName)
        _KeyInfo = DicKeyInfo(Me.GetType().FullName)
        _Children = DicChildren(Me.GetType().FullName)
        _ChildrenInfo = DicChildrenInfo(Me.GetType().FullName)

    End Sub


#Region "Cache"

    ' Singleton Repository
    Public Shared DicObjInfo As New Dictionary(Of String, ObjectInfo)
    Public Shared DicFieldsInfo As New Dictionary(Of String, ObjectFieldInfo())
    Public Shared DicKeyInfo As New Dictionary(Of String, ObjectFieldInfo)
    Public Shared DicChildren As New Dictionary(Of String, PropertyInfo())
    Public Shared DicChildrenInfo As New Dictionary(Of String, ObjectInfo())


    Public Shared Sub SingletonTypeReflection(Typ As Type)

        SyncLock DicObjInfo

            ' Singleton for Type Reflection
            If DicObjInfo.ContainsKey(Typ.FullName) = False Then
                Dim inf As ObjectInfo = Typ.GetCustomAttribute(GetType(ObjectInfo))
                inf.ObjectType = Typ
                DicObjInfo.Add(Typ.FullName, inf)
            End If


            If DicFieldsInfo.ContainsKey(Typ.FullName) = False Then

                DicFieldsInfo.Add(Typ.FullName,
                                  Typ.GetProperties().
                                  Where(Function(p) Attribute.IsDefined(p, GetType(ObjectFieldInfo))).
                                  Select(Of ObjectFieldInfo)(Function(p)
                                                                 Dim inf As ObjectFieldInfo = p.GetCustomAttribute(GetType(ObjectFieldInfo))
                                                                 inf.PropInfo = p
                                                                 Return inf
                                                             End Function).ToArray())
            End If

            If DicKeyInfo.ContainsKey(Typ.FullName) = False Then DicKeyInfo.Add(Typ.FullName, DicFieldsInfo.Item(Typ.FullName).First(Function(p) p.PrimaryKey))
            
            If DicChildren.ContainsKey(Typ.FullName) = False Then

                DicChildren.Add(Typ.FullName, Typ.GetProperties() _
                                .Where(Function(p) p.PropertyType.IsArray AndAlso
                                           p.Module.Assembly.GetType(p.PropertyType.GetElementType().FullName) IsNot Nothing AndAlso
                                           p.Module.Assembly.GetType(p.PropertyType.GetElementType().FullName).GetCustomAttributes(GetType(ObjectInfo), False).Length = 1).ToArray())
            End If

            If DicChildrenInfo.ContainsKey(Typ.FullName) = False Then

                DicChildrenInfo.Add(Typ.FullName, DicChildren.Item(Typ.FullName).Select(Of ObjectInfo)(Function(p)
                                                                                                           Dim inf As ObjectInfo = p.Module.Assembly.GetType(p.PropertyType.GetElementType().FullName).GetCustomAttribute(GetType(ObjectInfo), False)
                                                                                                           inf.ObjectType = p.PropertyType.GetElementType()
                                                                                                           Return inf
                                                                                                       End Function).ToArray())

            End If


            For Each child As ObjectInfo In DicChildrenInfo(Typ.FullName)
                SingletonTypeReflection(child.ObjectType)
            Next

        End SyncLock
    End Sub

#End Region

#Region "Overrides"

    Protected Overridable Sub OnBeforeUpsert()

    End Sub
    Protected Overridable Sub OnAfterUpsert(bSuccess As Boolean)

    End Sub

    Protected Overridable Sub OnBeforeUpdate()

    End Sub
    Protected Overridable Sub OnBeforeUpdateCommit()
        UpdateFiles()
    End Sub
    Protected Overridable Sub OnAfterUpdate(bSuccess As Boolean)

    End Sub

    Protected Overridable Sub OnBeforeInsert()

    End Sub
    Protected Overridable Sub OnBeforeInsertCommit()

    End Sub
    Protected Overridable Sub OnAfterInsert(bSuccess As Boolean)
        UpdateFiles()
    End Sub

    Protected Overridable Sub OnBeforeLoad()
    End Sub

    Protected Overridable Sub OnAfterLoad(bSuccess As Boolean)
        LoadFiles()
    End Sub

#End Region

#Region "Core Functions"

    Public ReadOnly Property Key As Integer
        Get
            Return CallByName(Me, DicKeyInfo(Me.GetType.FullName).PropInfo.Name, CallType.Get, Nothing)
        End Get
    End Property


    Public Overridable Function Load(key As Integer) As Result

        OnBeforeLoad()

        Dim typ As Type = Me.GetType()

        ' Table Information
        Dim ObjInfo As ObjectInfo = DicObjInfo.Item(typ.FullName)

        Dim KeyInfo As ObjectFieldInfo = DicKeyInfo.Item(typ.FullName)

        ' Child Tables Information
        Dim Children As PropertyInfo() = DicChildren.Item(typ.FullName)

        Dim ChildrenInfo As ObjectInfo() = DicChildrenInfo.Item(typ.FullName)

        Dim FieldsInfo As ObjectFieldInfo() = DicFieldsInfo.Item(typ.FullName)

        Dim sSQL As String

        'Generate SQL Select Clause
        sSQL = "SELECT * FROM [" & ObjInfo.TableName & "] " &
                             "WHERE " & KeyInfo.MappingName & "=" & FormatSQLVal(KeyInfo.PropInfo.PropertyType, key)

        Try

            ' Get Table
            Dim tblParent As DataTable = DB.GetDatatable(sSQL)

            If (tblParent Is Nothing OrElse tblParent.Rows.Count = 0) Then
                Throw New Exception("Object not Found")
            End If

            ' Get Fields
            For i As Integer = 0 To FieldsInfo.Length - 1

                Dim att As ObjectFieldInfo = FieldsInfo(i)

                Dim val As Object = tblParent.Rows(0)(att.MappingName)

                If val Is DBNull.Value Then Continue For

                att.PropInfo.SetValue(Me, val, BindingFlags.SetProperty Or BindingFlags.NonPublic, Nothing, Nothing, Nothing)

            Next

            '' Get Child Tables
            ' Loop child types
            For i As Integer = 0 To Children.Count - 1

                ' get type 
                Dim ChildTyp As Type = Children(i).Module.Assembly.GetType(Children(i).PropertyType.GetElementType().FullName)
                ' get Keys info from cache
                Dim ChildKeyInfo As ObjectFieldInfo = DicKeyInfo.Item(ChildTyp.FullName)
                ' get Keys porperties from cache
                Dim ChildFields As ObjectFieldInfo() = DicFieldsInfo.Item(ChildTyp.FullName)

                ' Empty SQL variables
                Dim sSQLWhere As String = ""
                sSQL = ""

                Dim sPK As String = ChildrenInfo(i).ParentForeignKey

                Dim keyType As Type = ChildFields.Where(Function(p) p.MappingName = sPK).First().PropInfo.PropertyType

                sSQLWhere &= If(sSQLWhere = "", "", " AND ") & sPK & "=" & FormatSQLVal(keyType, tblParent.Rows(0)(sPK))


                ' Select just the child table keys (in order to use Load())
                sSQL = "SELECT [" & ChildKeyInfo.MappingName & "] FROM [" + ChildrenInfo(i).TableName + "] " +
                    "WHERE " + sSQLWhere

                ' Get chid lines Keys List
                Dim tblChild As DataTable = DB.GetDatatable(sSQL)

                ' Array to hold the Child lines object
                Dim objChildren As New List(Of Object)

                For Each row As DataRow In tblChild.Rows

                    Dim objChild As cRecord = Activator.CreateInstance(ChildTyp)

                    Dim resChild As Result = objChild.Load(row.ItemArray()(0))

                    If Not resChild.Success Then
                        Throw New Exception(resChild.Message)
                    End If

                    objChildren.Add(objChild)

                Next

                Dim a As Object = Array.CreateInstance(ChildTyp, objChildren.Count)

                For j As Integer = 0 To objChildren.Count - 1
                    a(j) = objChildren(j)
                Next

                Children(i).SetValue(Me, a)

            Next

            OnAfterLoad(True)

            Return New Result() With {.Success = True}

        Catch ex As Exception
            OnAfterLoad(False)

            Return New Result With {.Success = False, .ErrorCode = -1, .Message = MyInfo.Caption & ": מזהה - " & key & " " & ex.Message}
        End Try

    End Function

    Public Overridable Function Upsert() As Result

        OnBeforeUpsert()

        'Collecting Information
        Dim typ As Type = Me.GetType()

        Dim ObjInfo As ObjectInfo = DicObjInfo.Item(typ.FullName)

        Dim FieldsInfo As ObjectFieldInfo() = DicFieldsInfo.Item(typ.FullName)

        Dim KeyInfo As ObjectFieldInfo = DicKeyInfo.Item(typ.FullName)

        ' Child Tables Information
        Dim Children As PropertyInfo() = DicChildren.Item(typ.FullName)

        Dim ChildrenInfo As ObjectInfo() = DicChildrenInfo.Item(typ.FullName)

        Dim Values As New List(Of String)

        Dim Mappings As String() = FieldsInfo.Where(Function(p) Not p.PrimaryKey).Select(Of String)(Function(p) p.MappingName).ToArray()

        Dim sSQL As String = ""

        Dim sSQLWhere As String = ""

        sSQLWhere = "[" + KeyInfo.MappingName & "]=" & FormatSQLVal(KeyInfo.PropInfo.PropertyType, KeyInfo.PropInfo.GetValue(Me))

        ' Validations
        Dim ValidErrs As String = ""

        For i As Integer = 0 To FieldsInfo.Length - 1

            Dim inf As ObjectFieldInfo = FieldsInfo(i)

            Dim val As Object = inf.PropInfo.GetValue(Me)

            If inf.PropInfo.PropertyType = GetType(String) Then
                If inf.MaxLength > 0 AndAlso val IsNot Nothing AndAlso val.ToString().Length > inf.MaxLength Then
                    ValidErrs &= "Field " & inf.Caption & " exceeded the Max. length of " & inf.MaxLength & " characters" & vbCrLf
                End If

                If inf.Mandatory = True AndAlso (val Is Nothing OrElse Not IsValueDefined(inf.PropInfo.PropertyType, val)) Then
                    ValidErrs &= "Field " & inf.Caption & " is mandatory " & vbCrLf
                End If

            End If

            If inf.PropInfo.PropertyType = GetType(Byte()) Then

                If inf.MaxLength > 0 AndAlso val IsNot Nothing AndAlso CType(val, Byte()).Length > inf.MaxLength * 1024 * 1024 Then
                    ValidErrs &= "File " & inf.Caption & " exceeded the Max. size of " & inf.MaxLength & " MB" & vbCrLf
                End If

            End If

        Next

        If ValidErrs <> "" Then
            Return New Result With {.Success = False, .ErrorCode = -1, .Message = ValidErrs}
        End If

        Dim bIsInsert As Boolean = False

        Dim IsExternalTran As Boolean = DB.IsInTransaction()

        Try

            If Not IsExternalTran Then DB.BeginTran()

            If DB.DCount(ObjInfo.TableName, sSQLWhere) = 0 Then bIsInsert = True

            Dim sOuterValidateRes As String = Validate(bIsInsert)

            If sOuterValidateRes <> "" Then
                DB.Rollback()
                Return New Result With {.Success = False, .ErrorCode = -1, .Message = sOuterValidateRes}
            End If

            If bIsInsert Then OnBeforeInsert() Else OnBeforeUpdate()

            For Each inf As ObjectFieldInfo In FieldsInfo

                If inf.PrimaryKey Then Continue For

                Dim sVal As Object = FormatSQLVal(inf.PropInfo.PropertyType, inf.PropInfo.GetValue(Me))

                Values.Add(sVal)

            Next

            If bIsInsert Then
                sSQL = DB.SQLInsert(ObjInfo.TableName, Mappings.ToArray(), Values.ToArray())
            Else
                sSQL = DB.SQLUpdate(ObjInfo.TableName, Mappings.ToArray(), Values.ToArray()) & " WHERE " + sSQLWhere
            End If

            ' Save object
            DB.Execute(sSQL)

            If bIsInsert Then
                'Update new Key in Object
                Dim i As Integer = DB.GetScalar("SELECT IDENT_CURRENT(" & Q(ObjInfo.TableName) & ")")

                CallByName(Me, KeyInfo.PropInfo.Name, CallType.Let, i)

            End If


            For i As Integer = 0 To Children.Count - 1

                'Collect Child Info 
                ' get type 
                Dim ChildTyp As Type = Children(i).Module.Assembly.GetType(Children(i).PropertyType.GetElementType().FullName)

                ' get Keys info from cache
                Dim ChildKeyInfo As ObjectFieldInfo = DicKeyInfo.Item(ChildTyp.FullName)

                ' get child object info
                Dim childInfo As ObjectInfo = ChildrenInfo(i)

                ' get properties in child that are FK to parent
                Dim ChildProps As ObjectFieldInfo() = DicFieldsInfo(ChildTyp.FullName).Where(Function(p) childInfo.ParentForeignKey = p.MappingName).ToArray()

                Dim a As Object = Children(i).GetValue(Me)

                If a Is Nothing Then Continue For

                ' Prepare Select statement for children that removed from object
                Dim sSQLAllLines As String = "SELECT [" & ChildKeyInfo.MappingName & "] FROM [" & childInfo.TableName & "] WHERE 0=0 "

                ' Add Condition to Select just lines that related to this parent 
                Dim sKey As String = ChildrenInfo(i).ParentForeignKey

                Dim pKey As ObjectFieldInfo = FieldsInfo.Where(Function(p) p.MappingName = sKey).First()

                sSQLAllLines &= If(sSQLWhere = "", "", " AND ") & sKey & "=" & FormatSQLVal(pKey.PropInfo.PropertyType, pKey.PropInfo.GetValue(Me))


                Dim AllLinesKeys As Integer() = DB.GetList(sSQLAllLines).Select(Function(p) CInt(p)).ToArray()
                Dim ExistingLineKeys As Integer() = CType(a, Object()).Select(Function(p) CInt(CallByName(p, ChildKeyInfo.PropInfo.Name, CallType.Get, Nothing))).ToArray()

                Dim LinesToDelete As Integer() = AllLinesKeys.Except(ExistingLineKeys).ToArray()

                For Each line As Integer In LinesToDelete

                    cRecord.Delete(ChildTyp, line)

                Next

                For j As Integer = 0 To a.Length - 1

                    ' override children's FK to father's values
                    For Each prop As ObjectFieldInfo In ChildProps

                        Dim val As Object = FieldsInfo.Where(Function(p) p.MappingName = prop.MappingName).First().PropInfo.GetValue(Me)

                        prop.PropInfo.SetValue(a(j), val, BindingFlags.SetProperty Or BindingFlags.NonPublic, Nothing, Nothing, Nothing)

                    Next

                    Dim sRes As Result = a(j).Upsert()

                    If Not sRes.Success Then
                        Throw New Exception(sRes.Message)
                    End If

                Next

            Next

            If bIsInsert Then OnBeforeInsertCommit() Else OnBeforeUpdateCommit()

            If Not IsExternalTran Then DB.Commit()

            If bIsInsert Then OnAfterInsert(True) Else OnAfterUpdate(True)

            OnAfterUpsert(True)

        Catch ex As Exception

            If Not IsExternalTran Then DB.Rollback()

            If bIsInsert Then OnAfterInsert(False) Else OnAfterUpdate(False)

            OnAfterUpsert(False)

            Debug.WriteLine(ex.Message & ex.StackTrace)

            Return New Result With {.Success = False, .Message = ex.Message, .ErrorCode = -1}

        End Try

        Return New Result With {.Success = True}

    End Function

    Protected Shared Function Delete(typ As Type, key As Integer) As Result

        If key = 0 Then Return New Result With {.Success = False, .Message = "No keys defined for DELETE function"}

        ' Table Information
        Dim ObjInfo As ObjectInfo = DicObjInfo.Item(typ.FullName)

        Dim KeyInfo As ObjectFieldInfo = DicKeyInfo.Item(typ.FullName)

        ' Child Tables Information
        Dim Children As PropertyInfo() = DicChildren.Item(typ.FullName)

        Dim ChildrenInfo As ObjectInfo() = DicChildrenInfo.Item(typ.FullName)

        Dim FieldsInfo As ObjectFieldInfo() = DicFieldsInfo.Item(typ.FullName)

        Dim sSQLWhere As String = KeyInfo.MappingName & "=" & FormatSQLVal(KeyInfo.PropInfo.PropertyType, key)

        Dim bIsExrtenalTran As Boolean = DB.IsInTransaction()

        Try

            If Not bIsExrtenalTran Then DB.BeginTran()

            ' Loop child types
            For i As Integer = 0 To Children.Count - 1

                ' get type 
                Dim ChildTyp As Type = Children(i).Module.Assembly.GetType(Children(i).PropertyType.GetElementType().FullName)
                ' get Keys info from cache
                Dim ChildKeyInfo As ObjectFieldInfo = DicKeyInfo.Item(ChildTyp.FullName)
                ' get child object info
                Dim childInfo As ObjectInfo = ChildrenInfo(i)

                Dim sChildSQLWhere As String = ""

                ' Add Condition to Select just lines that related to this parent 
                Dim sKey As String = ChildrenInfo(i).ParentForeignKey

                Dim pKey As ObjectFieldInfo = FieldsInfo.Where(Function(p) p.MappingName = sKey).First()

                Dim val As Object = DB.GetScalar("SELECT [" & sKey & "] FROM [" & ObjInfo.TableName & "] WHERE " & sSQLWhere)

                sChildSQLWhere &= If(sChildSQLWhere = "", "", " AND ") & sKey & "=" & FormatSQLVal(pKey.PropInfo.PropertyType, val)


                Dim tblChildren As DataTable

                tblChildren = DB.GetDatatable("SELECT [" & ChildKeyInfo.MappingName & "]" & vbCrLf &
                                              " FROM [" & childInfo.TableName & "]" & vbCrLf &
                                              " WHERE " & sChildSQLWhere)

                For Each row As DataRow In tblChildren.Rows

                    Dim sRes As Result = cRecord.Delete(ChildTyp, row.ItemArray()(0))

                    If Not sRes.Success Then
                        Throw New Exception(sRes.Message)
                    End If

                Next


            Next

            DB.Execute("DELETE FROM [" & ObjInfo.TableName & "] " &
                         "WHERE " & sSQLWhere)

            If Not bIsExrtenalTran Then DB.Commit()

            Return New Result() With {.Success = True}

        Catch ex As Exception

            DB.Rollback()

            Return New Result With {.Success = False, .ErrorCode = -1, .Message = typ.FullName & ": Key - " & key & " " & ex.Message}
        End Try

    End Function

    Protected Overridable Function Validate(IsInsert As Boolean) As String

        Return ""

    End Function

#End Region

#Region "Helpers"

    Private Sub SetDefaults()

        Dim typ As Type = Me.GetType()
        Dim childinfo As PropertyInfo() = DicChildren(typ.FullName)
        Dim Fields As ObjectFieldInfo() = DicFieldsInfo.Item(typ.FullName)


        For Each inf As PropertyInfo In childinfo
            inf.SetValue(Me, CObj(Array.CreateInstance(inf.PropertyType.GetElementType, 0)))
        Next

        For i As Integer = 0 To Fields.Length - 1

            Dim att As ObjectFieldInfo = Fields(i)

            If att.DefaultValue Is Nothing Then Continue For

            Dim val As Object = att.DefaultValue

            If val Is DBNull.Value Then Continue For

            att.PropInfo.SetValue(Me, val, BindingFlags.SetProperty Or BindingFlags.NonPublic, Nothing, Nothing, Nothing)

        Next

    End Sub

    Public Shared Function FormatSQLVal(T As Type, oVal As Object) As String
        Dim sVal As String

        Select Case T

            Case GetType(String)
                sVal = DB.Q(oVal)

            Case GetType(DateTime)
                If CDate(oVal) = DateTime.MinValue OrElse CDate(oVal).Year < 1900 Then
                    sVal = "NULL"
                Else
                    sVal = DB.QD(oVal)
                End If

            Case GetType(Byte())
                If oVal Is Nothing OrElse CType(oVal, Byte()).Length = 0 Then Return "0x0"
                sVal = "0x" & String.Join("", CType(oVal, Byte()).Select(Of String)(Function(b) Hex(b).PadLeft(2, "0"c)).ToArray())

            Case GetType(Decimal), GetType(Double), GetType(Integer), GetType(Single)
                sVal = oVal

            Case Else
                sVal = oVal

        End Select
        Return sVal
    End Function

    Private Function IsValueDefined(T As Type, oVal As Object) As Boolean

        Select Case T

            Case GetType(String)
                Return oVal IsNot Nothing AndAlso oVal.ToString().Length > 0

            Case GetType(DateTime)
                Return oVal IsNot Nothing AndAlso CDate(oVal) > DateTime.MinValue

            Case GetType(Byte())
                Return oVal IsNot Nothing AndAlso CType(oVal, Byte()).Length > 0

            Case GetType(Decimal), GetType(Double), GetType(Integer), GetType(Single)
                Return oVal IsNot Nothing AndAlso oVal <> 0

            Case Else
                Return oVal IsNot Nothing AndAlso oVal.ToString().Length > 0

        End Select

    End Function

#End Region

#Region "Attachment Files"

    Public Files As New List(Of cFile)

    Private Sub LoadFiles()

        Files.Clear()

        Files.AddRange(cFile.GetFilesList(MyInfo.TableName, Key))

    End Sub

    Private Sub UpdateFiles()

        Dim AllLinesKeys As Integer() = cFile.GetFilesList(MyInfo.TableName, Key).Select(Function(p) p.FilID).ToArray()

        Dim ExistingLineKeys As Integer() = Files.Select(Function(p) p.FilID).ToArray()

        Dim LinesToDelete As Integer() = AllLinesKeys.Except(ExistingLineKeys).ToArray()

        For Each line As Integer In LinesToDelete

            Dim res As Result = cRecord.Delete(GetType(cFile), line)

            If Not res.Success Then Throw New Exception("File Delete Failed " & res.Message)
        Next

        For Each file As cFile In Files

            If file.Content IsNot Nothing AndAlso file.Content.Length > 0 Then

                file.TableName = MyInfo.TableName
                file.ObjectID = Key

                Dim res As Result = file.Upsert()

                If Not res.Success Then Throw New Exception("File Save Failed " & res.Message)


            End If

        Next

    End Sub


#End Region

End Class