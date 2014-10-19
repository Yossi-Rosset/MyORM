Imports System.Reflection
Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Windows.Forms.Design
Imports System.Runtime.InteropServices
Imports Microsoft.Win32
Imports System.Drawing
Imports System.Windows.Forms
Imports MyORM.cRecord

Public Class frmBase

    Public Enum FormMode
        Find
        OK
        Update
        Add
    End Enum


    <Editor(GetType(cRecordDesignProperty), GetType(UITypeEditor))> _
    Public Property typ As Type

    Public Property ButtonOK As Button
    Public Property ButtonCancel As Button



    Public obj As cRecord
    Public objKey As Integer
    Public Mode As FormMode
    Private _isLoadingFlag As Boolean

    Public Property isLoadingFlag As Boolean
        Set(value As Boolean)
            _isLoadingFlag = value
        End Set
        Get
            Return _isLoadingFlag
        End Get
    End Property

    Public Sub New()

        isLoadingFlag = True
        ' This call is required by the designer.
        InitializeComponent()

        isLoadingFlag = False

        ' Add any initialization after the InitializeComponent() call.
        Me.objKey = -1

        Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("he-IL")

    End Sub

    Public Sub RefreshDataSources()
        For Each ctl As Control In Me.AllControls()

            If ctl.GetType() = GetType(ComboBox) Then

                Dim inf As ObjectFieldInfo() = cRecord.DicFieldsInfo(typ.FullName).Where(Function(p) p.MappingName = ctl.Name.Replace("cmb", "")).ToArray()

                Dim qry As String = ""

                If ctl.Tag <> "" Then qry = ctl.Tag Else If inf.Length > 0 Then qry = inf(0).QueryString

                If qry = "" Then Continue For


                qry = qry.Replace("{KEY}", obj.Key)

                Dim tbl As DataTable = DB.GetDatatable(qry)

                With CType(ctl, ComboBox)

                    .DataSource = tbl
                    .ValueMember = tbl.Columns(0).ColumnName
                    .DisplayMember = tbl.Columns(1).ColumnName

                End With

            End If

        Next

        For Each child As ObjectInfo In cRecord.DicChildrenInfo(typ.FullName)

            Dim grd As DataGridView() = Me.AllControls.Where(Function(p) p.Name = "grd" & child.TableName).Where(Function(p) p.GetType() = GetType(DataGridView) Or p.GetType() = GetType(grd)).Cast(Of DataGridView).ToArray()

            If grd.Length = 0 Then Continue For

            grd(0).AutoGenerateColumns = False

            RemoveHandler grd(0).DataError, AddressOf grds_DataError

            AddHandler grd(0).DataError, AddressOf grds_DataError

            For Each col As DataGridViewColumn In grd(0).Columns

                If col.GetType() = GetType(DataGridViewComboBoxColumn) Then

                    Dim inf As ObjectFieldInfo() = cRecord.DicFieldsInfo(child.ObjectType.FullName).Where(Function(p) p.MappingName = col.DataPropertyName).ToArray()

                    Dim qry As String = ""

                    If col.Tag <> "" Then qry = col.Tag Else If inf.Length > 0 Then qry = inf(0).QueryString

                    If qry = "" Then Continue For

                    qry = qry.Replace("{KEY}", obj.Key)

                    Dim tbl As DataTable = DB.GetDatatable(qry)

                    With CType(col, DataGridViewComboBoxColumn)
                        .DataSource = tbl
                        .ValueMember = tbl.Columns(0).ColumnName
                        .DisplayMember = tbl.Columns(1).ColumnName
                    End With

                End If

            Next

        Next


    End Sub

    Protected Overridable Sub grds_DataError(sender As Object, e As DataGridViewDataErrorEventArgs)

    End Sub

    Public Sub InitForm()

        AddHandler ButtonOK.Click, AddressOf btnOK_Click
        AddHandler ButtonCancel.Click, AddressOf btnCancel_Click

        obj = Activator.CreateInstance(typ)

        If Not IsTableExists("H_" & obj.MyInfo.TableName) Then HistToolStripButton.Visible = False

        RefreshDataSources()

        For Each ctl As Control In Me.AllControls()
            If ctl.Name.Length > 3 Then

                ' if does not appear in fields or grids list continue
                If Not (cRecord.DicFieldsInfo(typ.FullName).Where(Function(p) p.MappingName = ctl.Name.Substring(3)).Count() > 0 OrElse
                    cRecord.DicChildrenInfo(typ.FullName).Where(Function(p) p.TableName = ctl.Name.Substring(3)).Count() > 0) Then Continue For

                Select Case ctl.Name.Substring(0, 3)

                    Case "txt"
                        AddHandler CType(ctl, TextBox).Validated, AddressOf ValueChanged

                    Case "htp"
                        AddHandler CType(ctl, HDateTimePicker).ValueChanged, AddressOf ValueChanged

                    Case "chk"
                        AddHandler CType(ctl, CheckBox).CheckedChanged, AddressOf ValueChanged

                    Case "cmb"
                        AddHandler CType(ctl, ComboBox).SelectedValueChanged, AddressOf ValueChanged

                    Case "grd"
                        AddHandler CType(ctl, DataGridView).CellValueChanged, AddressOf ValueChanged
                        'AddHandler CType(ctl, DataGridView).RowsAdded, AddressOf ValueChanged
                        AddHandler CType(ctl, DataGridView).RowsRemoved, AddressOf ValueChanged
                End Select

            End If

        Next


        If objKey = -1 Then SetMode(FormMode.Find) Else LoadData(objKey)

    End Sub

    Private Sub ValueChanged(sender As Object, e As System.EventArgs)

        If isLoadingFlag Then Return

        If Mode = FormMode.Find Then Return

        If Not sender.GetType().IsSubclassOf(GetType(DataGridView)) AndAlso GetValueFromControl(sender) = CallByName(obj, sender.Name.Substring(3), CallType.Get, Nothing) Then Return

        If Mode = FormMode.OK Then SetMode(FormMode.Update)

        OnValueChanged(sender, e)

        FormToObject()


    End Sub

    Overridable Sub OnValueChanged(sender As Object, e As System.EventArgs)

    End Sub


    Private Sub SetMode(newmode As FormMode)

        Dim oldMode As FormMode = Mode

        BeforeModeChange(oldMode, newmode)

        Select Case newmode
            Case FormMode.Add
                ButtonOK.Text = "Add"
            Case FormMode.Find
                Clear()
                ButtonOK.Text = "Find"
            Case FormMode.OK
                ButtonOK.Text = "OK"
            Case FormMode.Update
                ButtonOK.Text = "Update"
        End Select

        Mode = newmode

        AfterModeChange(oldMode, newmode)

    End Sub

    Public Overridable Sub BeforeModeChange(oldmode As FormMode, newmode As FormMode)

    End Sub

    Public Overridable Sub AfterModeChange(oldmode As FormMode, newmode As FormMode)
    End Sub

    Public Overridable Sub AfterLoadData()
    End Sub


    Public Function LoadData(key As Integer) As Boolean

        obj = Activator.CreateInstance(typ)

        Dim res As cRecord.Result

        isLoadingFlag = True

        res = obj.Load(key)

        If res.Success Then
            Me.objKey = key

            RefreshDataSources()

            ObjectToForm(obj)

            AfterLoadData()

            SetMode(FormMode.OK)
        Else
            MsgBox("Loding of " & obj.MyInfo.Caption & " Failed" & vbCrLf & res.Message)
            SetMode(FormMode.Add)
        End If

        isLoadingFlag = False

        Return res.Success

    End Function

    Sub ObjectToForm(obj As cRecord)

        Try

            Clear()

            For Each ctl As Control In Me.AllControls

                If ctl.Name.Length <= 3 Then Continue For

                Dim name As String = ctl.Name.Substring(3)

                Dim field As ObjectFieldInfo() = cRecord.DicFieldsInfo(typ.FullName).Where(Function(p) p.PropInfo.Name = name).ToArray()

                Dim Pi As PropertyInfo = typ.GetProperty(name)

                If field.Length = 0 And Pi Is Nothing Then Continue For

                Dim Val As Object = CallByName(obj, name, CallType.Get, Nothing)

                Select Case ctl.Name.Substring(0, 3)

                    Case "txt"

                        Dim fmt As String

                        If field.Length = 0 Then
                            fmt = If(Pi.PropertyType = GetType(Decimal), "#.00", "")
                        Else
                            fmt = If(field(0).Format <> "", field(0).Format, If(field(0).PropInfo.PropertyType Is GetType(Decimal), "#.00", ""))
                        End If

                        ctl.Text = Format(Val, fmt)

                    Case "htp"
                        CType(ctl, HDateTimePicker).Value = Val

                    Case "chk"
                        CType(ctl, CheckBox).Checked = (Val = 1)

                    Case "cmb"

                        If CallByName(obj, name, CallType.Get) Is Nothing Then Continue For

                        CType(ctl, ComboBox).SelectedValue = Val

                    Case "grd"
                        CType(ctl, DataGridView).DataSource = obj.LinesToTable(name)

                End Select

            Next

        Catch ex As Exception
            MsgBox(ex.Message & " " & ex.StackTrace)
        End Try


    End Sub

    Function FormToSQLWhere() As String

        Dim sWhere As String = " 0=0 "

        For Each ctl As Control In Me.AllControls

            If ctl.Name.Length <= 3 Then Continue For

            Dim prop As PropertyInfo = obj.GetType.GetProperty(ctl.Name.Substring(3))

            If prop Is Nothing Then Continue For

            Dim infs As ObjectFieldInfo() = obj.FieldsInfo.Where(Function(p) p.PropInfo.Name = prop.Name).ToArray()

            If infs.Length = 0 Then Continue For

            Dim inf As ObjectFieldInfo = infs(0)

            Select Case ctl.Name.Substring(0, 3)

                Case "txt"

                    Select Case prop.PropertyType

                        Case GetType(Integer)
                            If Not Integer.TryParse(ctl.Text, Nothing) Then Continue For

                            sWhere &= " AND [" & inf.MappingName & "] = " & Q(ctl.Text)

                        Case GetType(Decimal), GetType(Double)

                            If Not IsNumeric(ctl.Text) Then Continue For

                            sWhere &= " AND [" & inf.MappingName & "] = " & Q(ctl.Text)

                        Case GetType(String)

                            If ctl.Text = "" Then Continue For

                            sWhere &= " AND [" & inf.MappingName & "] LIKE " & Q(ctl.Text.Replace("*", "%"))

                    End Select

                Case "htp"

                    If CType(ctl, HDateTimePicker).Value Is Nothing Then Continue For

                    sWhere &= " AND [" & inf.MappingName & "] = " & QD(CType(ctl, HDateTimePicker).Value)

                Case "chk"

                    If CType(ctl, CheckBox).CheckState = CheckState.Indeterminate Then Continue For

                    sWhere &= " AND [" & inf.MappingName & "] = " & If(CType(ctl, CheckBox).Checked, 1, 0)

                Case "cmb"

                    If CType(ctl, ComboBox).SelectedValue Is Nothing Then Continue For

                    sWhere &= " AND [" & inf.MappingName & "] = " & Q(CType(ctl, ComboBox).SelectedValue)

            End Select

        Next

        Return sWhere

    End Function

    Function GetValueFromControl(ctl As Control)

        If ctl.Name.Length <= 3 Then Return Nothing

        Dim prop As PropertyInfo = obj.GetType.GetProperty(ctl.Name.Substring(3))

        If prop Is Nothing Then Return Nothing

        Dim v As Type = prop.PropertyType

        Select Case ctl.Name.Substring(0, 3)

            Case "txt"

                Select Case v

                    Case GetType(Integer)
                        If Not Integer.TryParse(ctl.Text, Nothing) Then
                            Return 0
                        Else
                            Return ctl.Text
                        End If

                    Case GetType(Decimal), GetType(Double)

                        If Not IsNumeric(ctl.Text) Then
                            Return 0
                        Else
                            Return ctl.Text
                        End If

                    Case GetType(String)

                        Return ctl.Text

                End Select

            Case "htp"

                Return If(CType(ctl, HDateTimePicker).Value, New Date)

            Case "chk"
                Return If(CType(ctl, CheckBox).Checked, 1, 0)
            Case "cmb"
                Return CType(ctl, ComboBox).SelectedValue

            Case "grd"

                Dim ext As Object = CallByName(obj, ctl.Name.Substring(3), CallType.Get, Nothing)

                Dim rawlines = obj.TableToLines(CType(ctl, DataGridView).DataSource)

                Dim newlines = Array.CreateInstance(ext.GetType.GetElementType, rawlines.Length)

                For i As Integer = 0 To rawlines.Length - 1

                    newlines(i) = rawlines(i)

                Next

                Return newlines

        End Select

        Return Nothing

    End Function


    Function FormToObject() As cRecord

        For Each ctl As Control In Me.AllControls.OrderBy(Function(c) c.TabIndex)

            If ctl.Name.Length <= 3 Then Continue For

            Dim val = GetValueFromControl(ctl)

            If val Is Nothing Then Continue For

            CallByName(obj, ctl.Name.Substring(3), CallType.Let, val)

        Next

        OnAfterFormToObject(obj)

        Return obj

    End Function

    Protected Overridable Sub OnAfterFormToObject(obj As cRecord)

    End Sub


    Protected Overridable Function Save() As Result

        FormToObject()

        Dim res As Result = obj.Upsert()

        If res.Success Then

            LoadData(obj.Key)

        Else

            MsgBox("Saving Failed " & vbCrLf & res.Message)

        End If

        Return res

    End Function

    Sub OpenNew()

        obj = Activator.CreateInstance(typ)

        isLoadingFlag = True

        RefreshDataSources()

        ObjectToForm(obj)

        isLoadingFlag = False

        SetMode(FormMode.Add)

    End Sub



    Public Sub DoFind()

        Dim sSQL As String = "SELECT * FROM [" & obj.MyInfo.TableName & "] WHERE " & FormToSQLWhere()

        Dim tbl As DataTable = DB.GetDatatable(sSQL)

        If tbl.Rows.Count = 0 Then

            MsgBox("Data not Found")

        ElseIf tbl.Rows.Count = 1 Then

            LoadData(tbl.Rows(0)(obj.KeyInfo.MappingName))

        Else

            Dim frm As New frmFind(tbl, Me)

            frm.ShowDialog()


        End If


    End Sub


    Sub Clear()

        lstFiles.Items.Clear()
        lstFiles.Visible = False

        For Each ctl As Control In Me.AllControls

            Select Case ctl.GetType()

                Case GetType(CheckBox)
                    CType(ctl, CheckBox).CheckState = CheckState.Indeterminate
                Case GetType(ComboBox)
                    CType(ctl, ComboBox).SelectedItem = Nothing
                Case GetType(TextBox)
                    ctl.Text = ""
                Case GetType(DataGridView), GetType(grd)
                    With CType(ctl, DataGridView)
                        If .DataSource IsNot Nothing Then .DataSource = .DataSource.Clone()
                    End With
                Case GetType(HDateTimePicker)
                    CType(ctl, HDateTimePicker).Value = Nothing
            End Select

        Next


    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        OpenNew()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs)

        If Mode = FormMode.Add Or Mode = FormMode.Update Then
            Save()

        ElseIf Mode = FormMode.OK Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        ElseIf Mode = FormMode.Find Then

            DoFind()

        End If


    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs)
        If Mode = FormMode.OK Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click

        Dim i As Integer = obj.GetFirst()

        If i <> 0 Then
            Me.LoadData(i)
        End If

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        GoBack()
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        GoNext()
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        Dim i As Integer = obj.GetLast()

        If i <> 0 Then
            Me.LoadData(i)
        End If
    End Sub

    Private Function GoBack() As Boolean
        Dim i As Integer = obj.GetBack()

        If i <> 0 Then
            Me.LoadData(i)
            Return True
        End If
        Return False
    End Function

    Private Function GoNext() As Boolean
        Dim i As Integer = obj.GetNext()

        If i <> 0 Then
            Me.LoadData(i)
            Return True
        End If
        Return False
    End Function

    Private Sub DeleteToolStripButton_Click(sender As Object, e As EventArgs) Handles DeleteToolStripButton.Click

        If Mode = FormMode.OK AndAlso typ.GetMethod("Delete") IsNot Nothing Then

            Dim res As Result = CallByName(obj, "Delete", CallType.Method, objKey)

            If res.Success Then
                If Not GoBack() Then If Not GoNext() Then OpenNew()
                MsgBox("Deleted Successfully")
            Else
                MsgBox("Delete Failed" & vbCrLf & res.Message & " " & res.ErrorCode)
            End If

        End If


    End Sub

    Private Sub AttachToolStripButton_Click(sender As Object, e As EventArgs) Handles AttachToolStripButton.Click

        Dim dlg As New OpenFileDialog
        If dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Return

        For Each filename As String In dlg.FileNames
            AttachFile(filename)
        Next

    End Sub

    Private Sub frmBase_DragDrop(sender As Object, e As DragEventArgs) Handles MyBase.DragDrop

        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)

        For Each file As String In files

            If tmpDragFiles.Contains(file) Then Continue For

            AttachFile(file)

        Next

    End Sub

    Private Sub frmBase_DragEnter(sender As Object, e As DragEventArgs) Handles MyBase.DragEnter

        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If

    End Sub

    Private Sub AttachFile(path As String)

        Try

            If obj.Files.Where(Function(p) p.Name = path).Count() > 0 Then
                MsgBox("File already exists")
            End If

            obj.Files.Add(New cFile With {.Name = path, .Content = IO.File.ReadAllBytes(path)})
            SetMode(FormMode.Update)
        Catch ex As Exception
            MsgBox("Error in file loading " & ex.Message)
        End Try

    End Sub

    Private Sub ViewAttachedToolStripButton_Click(sender As Object, e As EventArgs) Handles ViewAttachedToolStripButton.Click

        If lstFiles.Visible Then
            lstFiles.Visible = False
            Return
        End If

        If obj.Files.Count = 0 Then Return

        lstFiles.Items.Clear()

        Dim lstIcons As New ImageList

        For Each file As cFile In obj.Files

            Dim ext As String = IO.Path.GetExtension(file.Name)

            Dim item As New ListViewItem({IO.Path.GetFileName(file.Name), file.FilID, file.Name, file.FileSize}) With {.ImageIndex = 1}

            item.ToolTipText = IO.Path.GetFileName(file.Name) & " " & file.FileSize & "KB"

            Dim iconForFile As Icon = SystemIcons.WinLogo

            ' Check to see if the image collection contains an image 
            ' for this extension, using the extension as a key. 
            If Not lstIcons.Images.ContainsKey(ext) Then
                Try
                    ' If not, add the image to the image list.
                    iconForFile = If(Icons.IconFromExtension(ext, Icons.SystemIconSize.Small), SystemIcons.WinLogo)

                    lstIcons.Images.Add(ext, iconForFile)
                Catch ex As Exception

                End Try


            End If

            item.ImageKey = ext
            lstFiles.Items.Add(item)

        Next

        lstFiles.MinimumSize = New Size(210, 118)

        lstFiles.View = View.SmallIcon

        lstFiles.SmallImageList = lstIcons

        lstFiles.BringToFront()

        lstFiles.Visible = True

    End Sub

    Dim tmpDragFiles As New List(Of String)

    Private Sub lstFiles_ItemDrag(sender As Object, e As ItemDragEventArgs) Handles lstFiles.ItemDrag

        Dim data As New DataObject()

        tmpDragFiles = New List(Of String)

        For Each itm As ListViewItem In lstFiles.SelectedItems

            If itm.SubItems(1).Text = 0 Then Return

            Dim UnsavedFile As cFile() = obj.Files.Where(Function(p) p.Name = itm.SubItems(2).Text And p.Content.Length > 0).ToArray()
            Dim bytes As Byte()

            If UnsavedFile.Length > 0 Then
                bytes = UnsavedFile(0).Content
            Else
                bytes = cFile.GetFileContent(itm.SubItems(1).Text)
            End If

            Dim filepath As String = IO.Path.GetTempPath() & itm.SubItems(0).Text

            If bytes Is Nothing Then Return

            If IO.File.Exists(filepath) Then IO.File.Delete(filepath)

            IO.File.WriteAllBytes(filepath, bytes)

            tmpDragFiles.Add(filepath)

        Next

        DoDragDrop(New DataObject(DataFormats.FileDrop, tmpDragFiles.ToArray()), DragDropEffects.Copy)

    End Sub

    Private Sub cmsFiles_Opening(sender As Object, e As CancelEventArgs) Handles cmsFiles.Opening

        If lstFiles.SelectedItems.Count = 0 Then e.Cancel = True

    End Sub

    Private Sub DeleteFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteFileToolStripMenuItem.Click

        If MsgBox("You are going to delete this file, Are you sure?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Return

        Dim ItemsToDelete As New List(Of Integer)

        For Each itm As ListViewItem In lstFiles.SelectedItems

            ItemsToDelete.Add(itm.Index)

            obj.Files.RemoveAll(Function(p) p.FilID = itm.SubItems(1).Text)

        Next

        For Each i As Integer In ItemsToDelete
            lstFiles.Items.RemoveAt(i)
        Next

        SetMode(FormMode.Update)

    End Sub

    Private Sub SaveFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveFileToolStripMenuItem.Click

        Dim data As New DataObject()

        If lstFiles.SelectedItems.Count = 0 Then Return

        If lstFiles.SelectedItems.Count = 1 Then

            Dim bytes As Byte() = cFile.GetFileContent(lstFiles.SelectedItems(0).SubItems(1).Text)

            If bytes Is Nothing Then Return

            Dim tmp As String = lstFiles.SelectedItems(0).SubItems(0).Text

            Dim dlg As New SaveFileDialog()
            dlg.FileName = tmp
            dlg.OverwritePrompt = True

            If dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Return

            If IO.File.Exists(dlg.FileName) Then IO.File.Delete(dlg.FileName)

            IO.File.WriteAllBytes(dlg.FileName, bytes)

        Else

            Dim dlg As New FolderBrowserDialog()
            dlg.ShowNewFolderButton = True
            If dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Return

            For Each itm As ListViewItem In lstFiles.SelectedItems

                Dim bytes As Byte() = cFile.GetFileContent(itm.SubItems(1).Text)

                If bytes Is Nothing Then Return

                Dim tmp As String = itm.SubItems(0).Text

                If IO.File.Exists(dlg.SelectedPath & "\" & tmp) Then IO.File.Delete(dlg.SelectedPath & "\" & tmp)

                IO.File.WriteAllBytes(dlg.SelectedPath & "\" & tmp, bytes)

            Next

        End If

    End Sub

    Private Sub lstFiles_VisibleChanged(sender As Object, e As EventArgs) Handles lstFiles.VisibleChanged

        ViewAttachedToolStripButton.Text = If(lstFiles.Visible, "Hide Attached Files", "View Attached Files")

    End Sub

    Private Sub lstFiles_DoubleClick(sender As Object, e As EventArgs) Handles lstFiles.DoubleClick
        If lstFiles.SelectedItems.Count <> 1 Then Return

        Dim itm As ListViewItem = lstFiles.SelectedItems(0)

        Dim bytes As Byte() = cFile.GetFileContent(itm.SubItems(1).Text)

        Dim filepath As String = IO.Path.GetTempPath() & itm.SubItems(0).Text

        If bytes Is Nothing Then Return

        If IO.File.Exists(filepath) Then IO.File.Delete(filepath)

        IO.File.WriteAllBytes(filepath, bytes)

        Process.Start(filepath)

    End Sub

    Private Sub HistToolStripButton_Click(sender As Object, e As EventArgs) Handles HistToolStripButton.Click

        If obj.Key = 0 Then Return

        Dim frmH As New frmHistory(obj)

        frmH.Show()

    End Sub


    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click

        SetMode(FormMode.Find)

    End Sub

    Private Sub IDToolStripTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles IDToolStripTextBox.KeyDown

        If Not IsNumeric(IDToolStripTextBox.Text) Then Return

        If e.KeyCode = Keys.Enter Then
            LoadData(IDToolStripTextBox.Text)
        End If

    End Sub

End Class


Public Class cRecordDesignProperty
    Inherits UITypeEditor
    Public Overrides Function GetEditStyle(context As ITypeDescriptorContext) As UITypeEditorEditStyle
        Return UITypeEditorEditStyle.DropDown
    End Function

    Public Overrides Function EditValue(context As ITypeDescriptorContext, provider As IServiceProvider, value As Object) As Object
        Dim edSvc = DirectCast(provider.GetService(GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)

        Dim lb As New ListBox()
        For Each type As Object In Me.[GetType]().Assembly.GetTypes().Where(Function(p) p.IsSubclassOf(GetType(cRecord)))
            lb.Items.Add(type)
        Next

        If value IsNot Nothing Then
            lb.SelectedItem = value
        End If

        edSvc.DropDownControl(lb)

        value = DirectCast(lb.SelectedItem, Type)

        Return value
    End Function
End Class

Public NotInheritable Class Icons
    Private Sub New()
    End Sub
#Region "Custom exceptions class"

    Public Class IconNotFoundException
        Inherits Exception
        Public Sub New(fileName As String, index As Integer)
            MyBase.New(String.Format("Icon with Id = {0} wasn't found in file {1}", index, fileName))
        End Sub
    End Class

    Public Class UnableToExtractIconsException
        Inherits Exception
        Public Sub New(fileName As String, firstIconIndex As Integer, iconCount As Integer)
            MyBase.New(String.Format("Tryed to extract {2} icons starting from the one with id {1} from the ""{0}"" file but failed", fileName, firstIconIndex, iconCount))
        End Sub
    End Class

#End Region

#Region "DllImports"

    ''' <summary>
    ''' Contains information about a file object. 
    ''' </summary>
    Private Structure SHFILEINFO
        ''' <summary>
        ''' Handle to the icon that represents the file. You are responsible for
        ''' destroying this handle with DestroyIcon when you no longer need it. 
        ''' </summary>
        Public hIcon As IntPtr

        ''' <summary>
        ''' Index of the icon image within the system image list.
        ''' </summary>
        Public iIcon As IntPtr

        ''' <summary>
        ''' Array of values that indicates the attributes of the file object.
        ''' For information about these values, see the IShellFolder::GetAttributesOf
        ''' method.
        ''' </summary>
        Public dwAttributes As UInteger

        ''' <summary>
        ''' String that contains the name of the file as it appears in the Microsoft
        ''' Windows Shell, or the path and file name of the file that contains the
        ''' icon representing the file.
        ''' </summary>
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)> _
        Public szDisplayName As String

        ''' <summary>
        ''' String that describes the type of file.
        ''' </summary>
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)> _
        Public szTypeName As String
    End Structure

    <Flags> _
    Private Enum FileInfoFlags As Integer
        ''' <summary>
        ''' Retrieve the handle to the icon that represents the file and the index 
        ''' of the icon within the system image list. The handle is copied to the 
        ''' hIcon member of the structure specified by psfi, and the index is copied 
        ''' to the iIcon member.
        ''' </summary>
        SHGFI_ICON = &H100
        ''' <summary>
        ''' Indicates that the function should not attempt to access the file 
        ''' specified by pszPath. Rather, it should act as if the file specified by 
        ''' pszPath exists with the file attributes passed in dwFileAttributes.
        ''' </summary>
        SHGFI_USEFILEATTRIBUTES = &H10
    End Enum

    ''' <summary>
    '''     Creates an array of handles to large or small icons extracted from
    '''     the specified executable file, dynamic-link library (DLL), or icon
    '''     file. 
    ''' </summary>
    ''' <param name="lpszFile">
    '''     Name of an executable file, DLL, or icon file from which icons will
    '''     be extracted.
    ''' </param>
    ''' <param name="nIconIndex">
    '''     <para>
    '''         Specifies the zero-based index of the first icon to extract. For
    '''         example, if this value is zero, the function extracts the first
    '''         icon in the specified file.
    '''     </para>
    '''     <para>
    '''         If this value is �1 and <paramref name="phiconLarge"/> and
    '''         <paramref name="phiconSmall"/> are both NULL, the function returns
    '''         the total number of icons in the specified file. If the file is an
    '''         executable file or DLL, the return value is the number of
    '''         RT_GROUP_ICON resources. If the file is an .ico file, the return
    '''         value is 1. 
    '''     </para>
    '''     <para>
    '''         Windows 95/98/Me, Windows NT 4.0 and later: If this value is a 
    '''         negative number and either <paramref name="phiconLarge"/> or 
    '''         <paramref name="phiconSmall"/> is not NULL, the function begins by
    '''         extracting the icon whose resource identifier is equal to the
    '''         absolute value of <paramref name="nIconIndex"/>. For example, use -3
    '''         to extract the icon whose resource identifier is 3. 
    '''     </para>
    ''' </param>
    ''' <param name="phIconLarge">
    '''     An array of icon handles that receives handles to the large icons
    '''     extracted from the file. If this parameter is NULL, no large icons
    '''     are extracted from the file.
    ''' </param>
    ''' <param name="phIconSmall">
    '''     An array of icon handles that receives handles to the small icons
    '''     extracted from the file. If this parameter is NULL, no small icons
    '''     are extracted from the file. 
    ''' </param>
    ''' <param name="nIcons">
    '''     Specifies the number of icons to extract from the file. 
    ''' </param>
    ''' <returns>
    '''     If the <paramref name="nIconIndex"/> parameter is -1, the
    '''     <paramref name="phIconLarge"/> parameter is NULL, and the
    '''     <paramref name="phiconSmall"/> parameter is NULL, then the return
    '''     value is the number of icons contained in the specified file.
    '''     Otherwise, the return value is the number of icons successfully
    '''     extracted from the file. 
    ''' </returns>
    <DllImport("Shell32", CharSet:=CharSet.Auto)> _
    Private Shared Function ExtractIconEx(<MarshalAs(UnmanagedType.LPTStr)> lpszFile As String, nIconIndex As Integer, phIconLarge As IntPtr(), phIconSmall As IntPtr(), nIcons As Integer) As Integer
    End Function

    <DllImport("Shell32", CharSet:=CharSet.Auto)> _
    Private Shared Function SHGetFileInfo(pszPath As String, dwFileAttributes As Integer, ByRef psfi As SHFILEINFO, cbFileInfo As Integer, uFlags As FileInfoFlags) As IntPtr
    End Function

#End Region

    ''' <summary>
    ''' Two constants extracted from the FileInfoFlags, the only that are
    ''' meaningfull for the user of this class.
    ''' </summary>
    Public Enum SystemIconSize As Integer
        Large = &H0
        Small = &H1
    End Enum

    ''' <summary>
    ''' Get the number of icons in the specified file.
    ''' </summary>
    ''' <param name="fileName">Full path of the file to look for.</param>
    ''' <returns></returns>
    Private Shared Function GetIconsCountInFile(fileName As String) As Integer
        Return ExtractIconEx(fileName, -1, Nothing, Nothing, 0)
    End Function




#Region "ExtractIcon-like functions"

    Public Shared Sub ExtractEx(fileName As String, largeIcons As List(Of Icon), smallIcons As List(Of Icon), firstIconIndex As Integer, iconCount As Integer)
        '
        '             * Memory allocations
        '             


        Dim smallIconsPtrs As IntPtr() = Nothing
        Dim largeIconsPtrs As IntPtr() = Nothing

        If smallIcons IsNot Nothing Then
            smallIconsPtrs = New IntPtr(iconCount - 1) {}
        End If
        If largeIcons IsNot Nothing Then
            largeIconsPtrs = New IntPtr(iconCount - 1) {}
        End If

        '
        '             * Call to native Win32 API
        '             


        Dim apiResult As Integer = ExtractIconEx(fileName, firstIconIndex, largeIconsPtrs, smallIconsPtrs, iconCount)
        If apiResult <> iconCount Then
            Throw New UnableToExtractIconsException(fileName, firstIconIndex, iconCount)
        End If

        '
        '             * Fill lists
        '             


        If smallIcons IsNot Nothing Then
            smallIcons.Clear()
            For Each actualIconPtr As IntPtr In smallIconsPtrs
                smallIcons.Add(Icon.FromHandle(actualIconPtr))
            Next
        End If
        If largeIcons IsNot Nothing Then
            largeIcons.Clear()
            For Each actualIconPtr As IntPtr In largeIconsPtrs
                largeIcons.Add(Icon.FromHandle(actualIconPtr))
            Next
        End If
    End Sub

    Public Shared Function ExtractEx(fileName As String, size As SystemIconSize, firstIconIndex As Integer, iconCount As Integer) As List(Of Icon)
        Dim iconList As New List(Of Icon)()

        Select Case size
            Case SystemIconSize.Large
                ExtractEx(fileName, iconList, Nothing, firstIconIndex, iconCount)
                Exit Select

            Case SystemIconSize.Small
                ExtractEx(fileName, Nothing, iconList, firstIconIndex, iconCount)
                Exit Select
            Case Else

                Throw New ArgumentOutOfRangeException("size")
        End Select

        Return iconList
    End Function

    Public Shared Sub Extract(fileName As String, largeIcons As List(Of Icon), smallIcons As List(Of Icon))
        Dim iconCount As Integer = GetIconsCountInFile(fileName)
        ExtractEx(fileName, largeIcons, smallIcons, 0, iconCount)
    End Sub

    Public Shared Function Extract(fileName As String, size As SystemIconSize) As List(Of Icon)
        Dim iconCount As Integer = GetIconsCountInFile(fileName)
        Return ExtractEx(fileName, size, 0, iconCount)
    End Function

    Public Shared Function ExtractOne(fileName As String, index As Integer, size As SystemIconSize) As Icon
        Try
            Dim iconList As List(Of Icon) = ExtractEx(fileName, size, index, 1)
            Return iconList(0)
        Catch generatedExceptionName As UnableToExtractIconsException
            Throw New IconNotFoundException(fileName, index)
        End Try
    End Function

    Public Shared Sub ExtractOne(fileName As String, index As Integer, ByRef largeIcon As Icon, ByRef smallIcon As Icon)
        Dim smallIconList As New List(Of Icon)()
        Dim largeIconList As New List(Of Icon)()
        Try
            ExtractEx(fileName, largeIconList, smallIconList, index, 1)
            largeIcon = largeIconList(0)
            smallIcon = smallIconList(0)
        Catch generatedExceptionName As UnableToExtractIconsException
            Throw New IconNotFoundException(fileName, index)
        End Try
    End Sub

#End Region

    Public Shared Function IconFromExtension(extension As String, size As SystemIconSize) As Icon
        ' Add the '.' to the extension if needed
        If extension(0) <> "."c Then
            extension = "."c & extension
        End If

        'opens the registry for the wanted key.
        Dim Root As RegistryKey = Registry.ClassesRoot
        Dim ExtensionKey As RegistryKey = Root.OpenSubKey(extension)
        ExtensionKey.GetValueNames()
        Dim ApplicationKey As RegistryKey = Root.OpenSubKey(ExtensionKey.GetValue("").ToString())

        Dim CurrentVer As RegistryKey = Nothing
        Try
            CurrentVer = Root.OpenSubKey(ApplicationKey.OpenSubKey("CurVer").GetValue("").ToString())
            'current version not found... carry on without it?
        Catch ex As Exception
        End Try

        If CurrentVer IsNot Nothing Then
            ApplicationKey = CurrentVer
        End If

        'gets the name of the file that have the icon.
        Dim IconLocation As String = ApplicationKey.OpenSubKey("DefaultIcon").GetValue("").ToString()
        Dim IconPath As String() = IconLocation.Split(","c)


        Dim Large As IntPtr() = Nothing
        Dim Small As IntPtr() = Nothing
        Dim iIconPathNumber As Integer = 0

        If IconPath.Length > 1 Then
            iIconPathNumber = 1
        Else
            iIconPathNumber = 0
        End If


        If IconPath(iIconPathNumber) Is Nothing Then
            IconPath(iIconPathNumber) = "0"
        End If
        Large = New IntPtr(0) {}
        Small = New IntPtr(0) {}



        'extracts the icon from the file.
        If iIconPathNumber > 0 Then
            ExtractIconEx(IconPath(0), Convert.ToInt16(IconPath(iIconPathNumber)), Large, Small, 1)
        Else
            ExtractIconEx(IconPath(0), Convert.ToInt16(0), Large, Small, 1)
        End If

        Try
            Return If(size = SystemIconSize.Large, Icon.FromHandle(Large(0)), Icon.FromHandle(Small(0)))
        Catch ex As Exception
            Return Nothing
        End Try

    End Function


    Public Shared Function IconFromExtensionShell(extension As String, size As SystemIconSize) As Icon
        'add '.' if nessesry
        If extension(0) <> "."c Then
            extension = "."c & extension
        End If

        'temp struct for getting file shell info
        Dim fileInfo As New SHFILEINFO()

        SHGetFileInfo(extension, 0, fileInfo, Marshal.SizeOf(fileInfo), FileInfoFlags.SHGFI_ICON Or FileInfoFlags.SHGFI_USEFILEATTRIBUTES Or CType(size, FileInfoFlags))

        Return Icon.FromHandle(fileInfo.hIcon)
    End Function

    Public Shared Function IconFromResource(resourceName As String) As Icon
        Dim assembly__1 As Assembly = Assembly.GetCallingAssembly()

        Return New Icon(assembly__1.GetManifestResourceStream(resourceName))
    End Function

    ''' <summary>
    ''' Parse strings in registry who contains the name of the icon and
    ''' the index of the icon an return both parts.
    ''' </summary>
    ''' <param name="regString">The full string in the form "path,index" as found in registry.</param>
    ''' <param name="fileName">The "path" part of the string.</param>
    ''' <param name="index">The "index" part of the string.</param>
    Public Shared Sub ExtractInformationsFromRegistryString(regString As String, ByRef fileName As String, ByRef index As Integer)
        If regString Is Nothing Then
            Throw New ArgumentNullException("regString")
        End If
        If regString.Length = 0 Then
            Throw New ArgumentException("The string should not be empty.", "regString")
        End If

        index = 0
        Dim strArr As String() = regString.Replace("""", "").Split(","c)
        fileName = strArr(0).Trim()
        If strArr.Length > 1 Then
            Integer.TryParse(strArr(1).Trim(), index)
        End If
    End Sub

End Class
