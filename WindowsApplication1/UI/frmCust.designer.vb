<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCust
    Inherits frmBase

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtMobile = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDiscPercent = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chkForzen = New System.Windows.Forms.CheckBox()
        Me.txtForzenComments = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tSub = New System.Windows.Forms.TabPage()
        Me.grdEnrolls = New MyORM.grd()
        Me.colEnrID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSubID = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colPayMean = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colFromDate = New MyORM.HCalendarColumn()
        Me.colToDate = New MyORM.HCalendarColumn()
        Me.colActive = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colStreet = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHouse = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHouseFloor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colApartment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCity = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colUserSign2 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colCreateDate2 = New MyORM.HCalendarColumn()
        Me.colCreatedBy2 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colComments1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tSer = New System.Windows.Forms.TabPage()
        Me.grdCalls = New MyORM.grd()
        Me.colCalID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colProblem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRemDate = New MyORM.HCalendarColumn()
        Me.colResolution = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSolved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colComments = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCreateDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCreatedBy = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colSolvedBy = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colUserSign = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.tPayMean = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.chkViewCC = New System.Windows.Forms.CheckBox()
        Me.grdCreditCards = New MyORM.grd()
        Me.CreID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PayDay = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CCNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CCExp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CCName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CCID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CCCVV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Comments = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UserSign = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.CreateDate = New MyORM.HCalendarColumn()
        Me.CreatedBy = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.grdBankDetails = New MyORM.grd()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewComboBoxColumn1 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.HCalendarColumn1 = New MyORM.HCalendarColumn()
        Me.DataGridViewComboBoxColumn2 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtApartment = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtHouse = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtStreet = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtHouseFloor = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtZip = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtCusID = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtCountry = New System.Windows.Forms.TextBox()
        Me.cmbCreatedBy = New System.Windows.Forms.ComboBox()
        Me.txtBalance = New System.Windows.Forms.TextBox()
        Me.htpCreateDate = New MyORM.HDateTimePicker()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.cmbCity = New System.Windows.Forms.ComboBox()
        Me.chkApproved = New System.Windows.Forms.CheckBox()
        Me.TabControl1.SuspendLayout()
        Me.tSub.SuspendLayout()
        CType(Me.grdEnrolls, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tSer.SuspendLayout()
        CType(Me.grdCalls, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tPayMean.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.grdCreditCards, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdBankDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "First Name"
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(84, 49)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(100, 20)
        Me.txtFirstName.TabIndex = 3
        '
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(84, 75)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(100, 20)
        Me.txtLastName.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Last Name"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(250, 49)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(100, 20)
        Me.txtEmail.TabIndex = 7
        Me.txtEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(208, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Mail"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtPhone
        '
        Me.txtPhone.Location = New System.Drawing.Point(250, 75)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(100, 20)
        Me.txtPhone.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(208, 78)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Phone"
        '
        'txtMobile
        '
        Me.txtMobile.Location = New System.Drawing.Point(250, 101)
        Me.txtMobile.Name = "txtMobile"
        Me.txtMobile.Size = New System.Drawing.Size(100, 20)
        Me.txtMobile.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(208, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Mobile"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 104)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Disc %"
        '
        'txtDiscPercent
        '
        Me.txtDiscPercent.Location = New System.Drawing.Point(84, 101)
        Me.txtDiscPercent.Name = "txtDiscPercent"
        Me.txtDiscPercent.Size = New System.Drawing.Size(100, 20)
        Me.txtDiscPercent.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(682, 128)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Balance"
        '
        'chkForzen
        '
        Me.chkForzen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkForzen.AutoSize = True
        Me.chkForzen.Location = New System.Drawing.Point(203, 354)
        Me.chkForzen.Name = "chkForzen"
        Me.chkForzen.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkForzen.Size = New System.Drawing.Size(58, 17)
        Me.chkForzen.TabIndex = 13
        Me.chkForzen.Text = "Frozen"
        Me.chkForzen.UseVisualStyleBackColor = True
        '
        'txtForzenComments
        '
        Me.txtForzenComments.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtForzenComments.Location = New System.Drawing.Point(285, 352)
        Me.txtForzenComments.Multiline = True
        Me.txtForzenComments.Name = "txtForzenComments"
        Me.txtForzenComments.Size = New System.Drawing.Size(244, 62)
        Me.txtForzenComments.TabIndex = 14
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(197, 373)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(91, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Freeze Comments"
        '
        'txtComments
        '
        Me.txtComments.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtComments.Location = New System.Drawing.Point(582, 352)
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(292, 62)
        Me.txtComments.TabIndex = 14
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(537, 355)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 13)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Comments"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tSub)
        Me.TabControl1.Controls.Add(Me.tSer)
        Me.TabControl1.Controls.Add(Me.tPayMean)
        Me.TabControl1.Location = New System.Drawing.Point(11, 147)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(866, 200)
        Me.TabControl1.TabIndex = 16
        '
        'tSub
        '
        Me.tSub.Controls.Add(Me.grdEnrolls)
        Me.tSub.Location = New System.Drawing.Point(4, 22)
        Me.tSub.Name = "tSub"
        Me.tSub.Padding = New System.Windows.Forms.Padding(3)
        Me.tSub.Size = New System.Drawing.Size(858, 174)
        Me.tSub.TabIndex = 0
        Me.tSub.Text = "Subscriptions"
        Me.tSub.UseVisualStyleBackColor = True
        '
        'grdEnrolls
        '
        Me.grdEnrolls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdEnrolls.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colEnrID, Me.colSubID, Me.colPayMean, Me.colFromDate, Me.colToDate, Me.colActive, Me.colStreet, Me.colHouse, Me.colHouseFloor, Me.colApartment, Me.colCity, Me.colUserSign2, Me.colCreateDate2, Me.colCreatedBy2, Me.colComments1})
        Me.grdEnrolls.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdEnrolls.Location = New System.Drawing.Point(3, 3)
        Me.grdEnrolls.Name = "grdEnrolls"
        Me.grdEnrolls.Size = New System.Drawing.Size(852, 168)
        Me.grdEnrolls.TabIndex = 9
        '
        'colEnrID
        '
        Me.colEnrID.DataPropertyName = "EnrID"
        Me.colEnrID.HeaderText = "מזהה"
        Me.colEnrID.Name = "colEnrID"
        Me.colEnrID.ReadOnly = True
        '
        'colSubID
        '
        Me.colSubID.DataPropertyName = "SubID"
        Me.colSubID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colSubID.HeaderText = "סוג מנוי"
        Me.colSubID.Name = "colSubID"
        '
        'colPayMean
        '
        Me.colPayMean.DataPropertyName = "PayMean"
        Me.colPayMean.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colPayMean.HeaderText = "אמצעי תשלום"
        Me.colPayMean.Name = "colPayMean"
        Me.colPayMean.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colPayMean.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colFromDate
        '
        Me.colFromDate.DataPropertyName = "FromDate"
        Me.colFromDate.HeaderText = "מתאריך"
        Me.colFromDate.Name = "colFromDate"
        '
        'colToDate
        '
        Me.colToDate.DataPropertyName = "ToDate"
        Me.colToDate.HeaderText = "עד תאריך"
        Me.colToDate.Name = "colToDate"
        '
        'colActive
        '
        Me.colActive.DataPropertyName = "Active"
        Me.colActive.FalseValue = "0"
        Me.colActive.HeaderText = "פעיל"
        Me.colActive.Name = "colActive"
        Me.colActive.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colActive.TrueValue = "1"
        '
        'colStreet
        '
        Me.colStreet.DataPropertyName = "Street"
        Me.colStreet.HeaderText = "רחוב"
        Me.colStreet.Name = "colStreet"
        '
        'colHouse
        '
        Me.colHouse.DataPropertyName = "House"
        Me.colHouse.HeaderText = "בית"
        Me.colHouse.Name = "colHouse"
        '
        'colHouseFloor
        '
        Me.colHouseFloor.DataPropertyName = "HouseFloor"
        Me.colHouseFloor.HeaderText = "בית"
        Me.colHouseFloor.Name = "colHouseFloor"
        '
        'colApartment
        '
        Me.colApartment.DataPropertyName = "Apartment"
        Me.colApartment.HeaderText = "דירה"
        Me.colApartment.Name = "colApartment"
        '
        'colCity
        '
        Me.colCity.DataPropertyName = "City"
        Me.colCity.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colCity.HeaderText = "עיר"
        Me.colCity.Name = "colCity"
        '
        'colUserSign2
        '
        Me.colUserSign2.DataPropertyName = "UserSign"
        Me.colUserSign2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colUserSign2.HeaderText = "שינוי על ידי"
        Me.colUserSign2.Name = "colUserSign2"
        Me.colUserSign2.ReadOnly = True
        '
        'colCreateDate2
        '
        Me.colCreateDate2.DataPropertyName = "CreateDate"
        Me.colCreateDate2.HeaderText = "תאריך יצירה"
        Me.colCreateDate2.Name = "colCreateDate2"
        Me.colCreateDate2.ReadOnly = True
        '
        'colCreatedBy2
        '
        Me.colCreatedBy2.DataPropertyName = "CreatedBy"
        Me.colCreatedBy2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colCreatedBy2.HeaderText = "נוצר ע""י"
        Me.colCreatedBy2.Name = "colCreatedBy2"
        Me.colCreatedBy2.ReadOnly = True
        '
        'colComments1
        '
        Me.colComments1.DataPropertyName = "Comments"
        Me.colComments1.HeaderText = "הערות"
        Me.colComments1.Name = "colComments1"
        '
        'tSer
        '
        Me.tSer.Controls.Add(Me.grdCalls)
        Me.tSer.Location = New System.Drawing.Point(4, 22)
        Me.tSer.Name = "tSer"
        Me.tSer.Padding = New System.Windows.Forms.Padding(3)
        Me.tSer.Size = New System.Drawing.Size(858, 174)
        Me.tSer.TabIndex = 2
        Me.tSer.Text = "Customer Services"
        Me.tSer.UseVisualStyleBackColor = True
        '
        'grdCalls
        '
        Me.grdCalls.AllowUserToOrderColumns = True
        Me.grdCalls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCalls.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCalID, Me.colProblem, Me.colRemDate, Me.colResolution, Me.colSolved, Me.colComments, Me.colCreateDate, Me.colCreatedBy, Me.colSolvedBy, Me.colUserSign})
        Me.grdCalls.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCalls.Location = New System.Drawing.Point(3, 3)
        Me.grdCalls.Name = "grdCalls"
        Me.grdCalls.Size = New System.Drawing.Size(852, 168)
        Me.grdCalls.TabIndex = 0
        '
        'colCalID
        '
        Me.colCalID.DataPropertyName = "CalID"
        Me.colCalID.HeaderText = "מזהה"
        Me.colCalID.Name = "colCalID"
        Me.colCalID.ReadOnly = True
        '
        'colProblem
        '
        Me.colProblem.DataPropertyName = "Problem"
        Me.colProblem.HeaderText = "תיאור הבעיה"
        Me.colProblem.Name = "colProblem"
        '
        'colRemDate
        '
        Me.colRemDate.DataPropertyName = "RemDate"
        DataGridViewCellStyle1.Format = "dd-MM-yyyy"
        Me.colRemDate.DefaultCellStyle = DataGridViewCellStyle1
        Me.colRemDate.HeaderText = "תאריך תזכורת"
        Me.colRemDate.Name = "colRemDate"
        Me.colRemDate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colRemDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colResolution
        '
        Me.colResolution.DataPropertyName = "Resolution"
        Me.colResolution.HeaderText = "הפתרון"
        Me.colResolution.Name = "colResolution"
        '
        'colSolved
        '
        Me.colSolved.DataPropertyName = "Solved"
        Me.colSolved.FalseValue = "0"
        Me.colSolved.HeaderText = "נפתר?"
        Me.colSolved.Name = "colSolved"
        Me.colSolved.TrueValue = "1"
        '
        'colComments
        '
        Me.colComments.DataPropertyName = "Comments"
        Me.colComments.HeaderText = "הערות"
        Me.colComments.Name = "colComments"
        Me.colComments.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colComments.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colCreateDate
        '
        Me.colCreateDate.DataPropertyName = "CreateDate"
        Me.colCreateDate.HeaderText = "נוצר ב"
        Me.colCreateDate.Name = "colCreateDate"
        Me.colCreateDate.ReadOnly = True
        '
        'colCreatedBy
        '
        Me.colCreatedBy.DataPropertyName = "CreatedBy"
        Me.colCreatedBy.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colCreatedBy.HeaderText = "נוצר ע""י"
        Me.colCreatedBy.Name = "colCreatedBy"
        Me.colCreatedBy.ReadOnly = True
        Me.colCreatedBy.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'colSolvedBy
        '
        Me.colSolvedBy.DataPropertyName = "SolvedBy"
        Me.colSolvedBy.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colSolvedBy.HeaderText = "נפתר ע""י"
        Me.colSolvedBy.Name = "colSolvedBy"
        Me.colSolvedBy.ReadOnly = True
        Me.colSolvedBy.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'colUserSign
        '
        Me.colUserSign.DataPropertyName = "UserSign"
        Me.colUserSign.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colUserSign.HeaderText = "עדכון אחרון ע""י"
        Me.colUserSign.Name = "colUserSign"
        Me.colUserSign.ReadOnly = True
        '
        'tPayMean
        '
        Me.tPayMean.Controls.Add(Me.SplitContainer1)
        Me.tPayMean.Location = New System.Drawing.Point(4, 22)
        Me.tPayMean.Name = "tPayMean"
        Me.tPayMean.Padding = New System.Windows.Forms.Padding(3)
        Me.tPayMean.Size = New System.Drawing.Size(858, 174)
        Me.tPayMean.TabIndex = 3
        Me.tPayMean.Text = "Payment"
        Me.tPayMean.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkViewCC)
        Me.SplitContainer1.Panel1.Controls.Add(Me.grdCreditCards)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label20)
        Me.SplitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.grdBankDetails)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label22)
        Me.SplitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SplitContainer1.Size = New System.Drawing.Size(852, 168)
        Me.SplitContainer1.SplitterDistance = 421
        Me.SplitContainer1.TabIndex = 0
        '
        'chkViewCC
        '
        Me.chkViewCC.AutoSize = True
        Me.chkViewCC.Location = New System.Drawing.Point(199, 5)
        Me.chkViewCC.Name = "chkViewCC"
        Me.chkViewCC.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkViewCC.Size = New System.Drawing.Size(109, 17)
        Me.chkViewCC.TabIndex = 9
        Me.chkViewCC.Text = "View CC numbers"
        Me.chkViewCC.UseVisualStyleBackColor = True
        '
        'grdCreditCards
        '
        Me.grdCreditCards.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdCreditCards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCreditCards.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CreID, Me.PayDay, Me.CCNum, Me.CCExp, Me.CCName, Me.CCID, Me.CCCVV, Me.Comments, Me.UserSign, Me.CreateDate, Me.CreatedBy})
        Me.grdCreditCards.Location = New System.Drawing.Point(3, 24)
        Me.grdCreditCards.Name = "grdCreditCards"
        Me.grdCreditCards.Size = New System.Drawing.Size(415, 141)
        Me.grdCreditCards.TabIndex = 8
        '
        'CreID
        '
        Me.CreID.DataPropertyName = "CreID"
        Me.CreID.HeaderText = "מזהה"
        Me.CreID.Name = "CreID"
        Me.CreID.ReadOnly = True
        '
        'PayDay
        '
        Me.PayDay.DataPropertyName = "PayDay"
        Me.PayDay.HeaderText = "יום תשלום"
        Me.PayDay.Name = "PayDay"
        '
        'CCNum
        '
        Me.CCNum.DataPropertyName = "CCNum"
        Me.CCNum.HeaderText = "מספר כרטיס"
        Me.CCNum.Name = "CCNum"
        '
        'CCExp
        '
        Me.CCExp.DataPropertyName = "CCExp"
        Me.CCExp.HeaderText = "תוקף"
        Me.CCExp.Name = "CCExp"
        '
        'CCName
        '
        Me.CCName.DataPropertyName = "CCName"
        Me.CCName.HeaderText = "שם בעל הכרטיס"
        Me.CCName.Name = "CCName"
        '
        'CCID
        '
        Me.CCID.DataPropertyName = "CCID"
        Me.CCID.HeaderText = "ת.ז."
        Me.CCID.Name = "CCID"
        '
        'CCCVV
        '
        Me.CCCVV.DataPropertyName = "CCCVV"
        Me.CCCVV.HeaderText = "CVV"
        Me.CCCVV.Name = "CCCVV"
        '
        'Comments
        '
        Me.Comments.DataPropertyName = "Comments"
        Me.Comments.HeaderText = "הערות"
        Me.Comments.Name = "Comments"
        '
        'UserSign
        '
        Me.UserSign.DataPropertyName = "UserSign"
        Me.UserSign.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.UserSign.HeaderText = "שינוי על ידי"
        Me.UserSign.Name = "UserSign"
        Me.UserSign.ReadOnly = True
        '
        'CreateDate
        '
        Me.CreateDate.DataPropertyName = "CreateDate"
        Me.CreateDate.HeaderText = "תאריך יצירה"
        Me.CreateDate.Name = "CreateDate"
        Me.CreateDate.ReadOnly = True
        '
        'CreatedBy
        '
        Me.CreatedBy.DataPropertyName = "CreatedBy"
        Me.CreatedBy.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CreatedBy.HeaderText = "נוצר ע""י"
        Me.CreatedBy.Name = "CreatedBy"
        Me.CreatedBy.ReadOnly = True
        '
        'Label20
        '
        Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(3, 9)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(64, 13)
        Me.Label20.TabIndex = 7
        Me.Label20.Text = "Credit Cards"
        '
        'grdBankDetails
        '
        Me.grdBankDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdBankDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdBankDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewComboBoxColumn1, Me.HCalendarColumn1, Me.DataGridViewComboBoxColumn2})
        Me.grdBankDetails.Location = New System.Drawing.Point(3, 24)
        Me.grdBankDetails.Name = "grdBankDetails"
        Me.grdBankDetails.Size = New System.Drawing.Size(421, 141)
        Me.grdBankDetails.TabIndex = 9
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "BanID"
        Me.DataGridViewTextBoxColumn1.HeaderText = "מזהה"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "BNum"
        Me.DataGridViewTextBoxColumn2.HeaderText = "מספר חשבון"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "BBranch"
        Me.DataGridViewTextBoxColumn3.HeaderText = "סניף"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "BBank"
        Me.DataGridViewTextBoxColumn4.HeaderText = "בנק"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "BName"
        Me.DataGridViewTextBoxColumn5.HeaderText = "שם בעל חשבון"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Comments"
        Me.DataGridViewTextBoxColumn6.HeaderText = "הערות"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewComboBoxColumn1
        '
        Me.DataGridViewComboBoxColumn1.DataPropertyName = "UserSign"
        Me.DataGridViewComboBoxColumn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DataGridViewComboBoxColumn1.HeaderText = "שינוי ע""י"
        Me.DataGridViewComboBoxColumn1.Name = "DataGridViewComboBoxColumn1"
        Me.DataGridViewComboBoxColumn1.ReadOnly = True
        '
        'HCalendarColumn1
        '
        Me.HCalendarColumn1.DataPropertyName = "CreateDate"
        Me.HCalendarColumn1.HeaderText = "נוצר בתאריך"
        Me.HCalendarColumn1.Name = "HCalendarColumn1"
        Me.HCalendarColumn1.ReadOnly = True
        '
        'DataGridViewComboBoxColumn2
        '
        Me.DataGridViewComboBoxColumn2.DataPropertyName = "CreatedBy"
        Me.DataGridViewComboBoxColumn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DataGridViewComboBoxColumn2.HeaderText = "נוצר ע""י"
        Me.DataGridViewComboBoxColumn2.Name = "DataGridViewComboBoxColumn2"
        Me.DataGridViewComboBoxColumn2.ReadOnly = True
        '
        'Label22
        '
        Me.Label22.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(3, 9)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(72, 13)
        Me.Label22.TabIndex = 8
        Me.Label22.Text = "Wire transfers"
        '
        'txtApartment
        '
        Me.txtApartment.Location = New System.Drawing.Point(403, 102)
        Me.txtApartment.Name = "txtApartment"
        Me.txtApartment.Size = New System.Drawing.Size(100, 20)
        Me.txtApartment.TabIndex = 22
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(356, 104)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(26, 13)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Apt."
        '
        'txtHouse
        '
        Me.txtHouse.Location = New System.Drawing.Point(403, 76)
        Me.txtHouse.Name = "txtHouse"
        Me.txtHouse.Size = New System.Drawing.Size(100, 20)
        Me.txtHouse.TabIndex = 20
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(356, 78)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(38, 13)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "House"
        '
        'txtStreet
        '
        Me.txtStreet.Location = New System.Drawing.Point(403, 50)
        Me.txtStreet.Name = "txtStreet"
        Me.txtStreet.Size = New System.Drawing.Size(100, 20)
        Me.txtStreet.TabIndex = 18
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(356, 52)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(35, 13)
        Me.Label12.TabIndex = 17
        Me.Label12.Text = "Street"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(510, 105)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(43, 13)
        Me.Label13.TabIndex = 27
        Me.Label13.Text = "Country"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(510, 79)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(24, 13)
        Me.Label14.TabIndex = 25
        Me.Label14.Text = "City"
        '
        'txtHouseFloor
        '
        Me.txtHouseFloor.Location = New System.Drawing.Point(557, 50)
        Me.txtHouseFloor.Name = "txtHouseFloor"
        Me.txtHouseFloor.Size = New System.Drawing.Size(100, 20)
        Me.txtHouseFloor.TabIndex = 24
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(510, 53)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(30, 13)
        Me.Label15.TabIndex = 23
        Me.Label15.Text = "Floor"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtZip
        '
        Me.txtZip.Location = New System.Drawing.Point(557, 128)
        Me.txtZip.Name = "txtZip"
        Me.txtZip.Size = New System.Drawing.Size(100, 20)
        Me.txtZip.TabIndex = 30
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(510, 131)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(50, 13)
        Me.Label16.TabIndex = 29
        Me.Label16.Text = "Zip Code"
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(682, 101)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(59, 13)
        Me.Label17.TabIndex = 33
        Me.Label17.Text = "Created By"
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(682, 75)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(64, 13)
        Me.Label18.TabIndex = 31
        Me.Label18.Text = "Create Date"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtCusID
        '
        Me.txtCusID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCusID.BackColor = System.Drawing.SystemColors.Info
        Me.txtCusID.Location = New System.Drawing.Point(761, 46)
        Me.txtCusID.Name = "txtCusID"
        Me.txtCusID.ReadOnly = True
        Me.txtCusID.Size = New System.Drawing.Size(113, 20)
        Me.txtCusID.TabIndex = 36
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(683, 49)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(65, 13)
        Me.Label19.TabIndex = 35
        Me.Label19.Text = "Customer ID"
        '
        'txtCountry
        '
        Me.txtCountry.Location = New System.Drawing.Point(557, 102)
        Me.txtCountry.Name = "txtCountry"
        Me.txtCountry.Size = New System.Drawing.Size(100, 20)
        Me.txtCountry.TabIndex = 28
        '
        'cmbCreatedBy
        '
        Me.cmbCreatedBy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbCreatedBy.DisplayMember = "Name"
        Me.cmbCreatedBy.Enabled = False
        Me.cmbCreatedBy.FormattingEnabled = True
        Me.cmbCreatedBy.Location = New System.Drawing.Point(761, 98)
        Me.cmbCreatedBy.Name = "cmbCreatedBy"
        Me.cmbCreatedBy.Size = New System.Drawing.Size(113, 21)
        Me.cmbCreatedBy.TabIndex = 37
        Me.cmbCreatedBy.Tag = "SELECT * FROM USERS"
        Me.cmbCreatedBy.ValueMember = "UseID"
        '
        'txtBalance
        '
        Me.txtBalance.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBalance.BackColor = System.Drawing.SystemColors.Info
        Me.txtBalance.Location = New System.Drawing.Point(761, 125)
        Me.txtBalance.Name = "txtBalance"
        Me.txtBalance.ReadOnly = True
        Me.txtBalance.Size = New System.Drawing.Size(113, 20)
        Me.txtBalance.TabIndex = 11
        '
        'htpCreateDate
        '
        Me.htpCreateDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.htpCreateDate.Format = "dd MM yyyy"
        Me.htpCreateDate.Location = New System.Drawing.Point(761, 72)
        Me.htpCreateDate.Name = "htpCreateDate"
        Me.htpCreateDate.ReadOnly = True
        Me.htpCreateDate.Size = New System.Drawing.Size(113, 19)
        Me.htpCreateDate.TabIndex = 42
        Me.htpCreateDate.Value = Nothing
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(101, 409)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 80
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(18, 409)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 79
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'cmbCity
        '
        Me.cmbCity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCity.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbCity.FormattingEnabled = True
        Me.cmbCity.Location = New System.Drawing.Point(557, 76)
        Me.cmbCity.Name = "cmbCity"
        Me.cmbCity.Size = New System.Drawing.Size(100, 21)
        Me.cmbCity.TabIndex = 81
        '
        'chkApproved
        '
        Me.chkApproved.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkApproved.AutoSize = True
        Me.chkApproved.Location = New System.Drawing.Point(6, 369)
        Me.chkApproved.Name = "chkApproved"
        Me.chkApproved.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkApproved.Size = New System.Drawing.Size(72, 17)
        Me.chkApproved.TabIndex = 13
        Me.chkApproved.Text = "Approved"
        Me.chkApproved.UseVisualStyleBackColor = True
        '
        'frmCust
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ButtonCancel = Me.btnCancel
        Me.ButtonOK = Me.btnOK
        Me.ClientSize = New System.Drawing.Size(888, 444)
        Me.Controls.Add(Me.cmbCity)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.htpCreateDate)
        Me.Controls.Add(Me.cmbCreatedBy)
        Me.Controls.Add(Me.txtCusID)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtZip)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtCountry)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtHouseFloor)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtApartment)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtHouse)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtStreet)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtComments)
        Me.Controls.Add(Me.txtForzenComments)
        Me.Controls.Add(Me.chkApproved)
        Me.Controls.Add(Me.chkForzen)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtBalance)
        Me.Controls.Add(Me.txtDiscPercent)
        Me.Controls.Add(Me.txtMobile)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtPhone)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtLastName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtFirstName)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmCust"
        Me.Text = "Customer"
        Me.typ = GetType(MyORM_GUI.cCustomer)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtFirstName, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.txtLastName, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtEmail, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.txtPhone, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.txtMobile, 0)
        Me.Controls.SetChildIndex(Me.txtDiscPercent, 0)
        Me.Controls.SetChildIndex(Me.txtBalance, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.chkForzen, 0)
        Me.Controls.SetChildIndex(Me.chkApproved, 0)
        Me.Controls.SetChildIndex(Me.txtForzenComments, 0)
        Me.Controls.SetChildIndex(Me.txtComments, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.txtStreet, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.txtHouse, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.txtApartment, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.txtHouseFloor, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.txtCountry, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.txtZip, 0)
        Me.Controls.SetChildIndex(Me.Label18, 0)
        Me.Controls.SetChildIndex(Me.Label17, 0)
        Me.Controls.SetChildIndex(Me.Label19, 0)
        Me.Controls.SetChildIndex(Me.txtCusID, 0)
        Me.Controls.SetChildIndex(Me.cmbCreatedBy, 0)
        Me.Controls.SetChildIndex(Me.htpCreateDate, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.cmbCity, 0)
        Me.TabControl1.ResumeLayout(False)
        Me.tSub.ResumeLayout(False)
        CType(Me.grdEnrolls, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tSer.ResumeLayout(False)
        CType(Me.grdCalls, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tPayMean.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.grdCreditCards, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdBankDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents txtLastName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPhone As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtMobile As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDiscPercent As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkForzen As System.Windows.Forms.CheckBox
    Friend WithEvents txtForzenComments As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tSub As System.Windows.Forms.TabPage
    Friend WithEvents tSer As System.Windows.Forms.TabPage
    Friend WithEvents txtApartment As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtHouse As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtStreet As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtHouseFloor As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtZip As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtCusID As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtCountry As System.Windows.Forms.TextBox
    Friend WithEvents cmbCreatedBy As System.Windows.Forms.ComboBox
    Friend WithEvents txtBalance As System.Windows.Forms.TextBox
    Friend WithEvents grdCalls As grd
    Friend WithEvents htpCreateDate As HDateTimePicker
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents tPayMean As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents grdCreditCards As grd
    Friend WithEvents CreID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PayDay As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CCNum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CCExp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CCName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CCID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CCCVV As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Comments As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserSign As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents CreateDate As HCalendarColumn
    Friend WithEvents CreatedBy As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents grdBankDetails As grd
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn1 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents HCalendarColumn1 As HCalendarColumn
    Friend WithEvents DataGridViewComboBoxColumn2 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents chkViewCC As System.Windows.Forms.CheckBox
    Friend WithEvents grdEnrolls As grd
    Friend WithEvents cmbCity As System.Windows.Forms.ComboBox
    Friend WithEvents colCalID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colProblem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRemDate As HCalendarColumn
    Friend WithEvents colResolution As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSolved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colComments As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCreateDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCreatedBy As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colSolvedBy As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colUserSign As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents chkApproved As System.Windows.Forms.CheckBox
    Friend WithEvents colEnrID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSubID As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colPayMean As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colFromDate As HCalendarColumn
    Friend WithEvents colToDate As HCalendarColumn
    Friend WithEvents colActive As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colStreet As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHouse As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHouseFloor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colApartment As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCity As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colUserSign2 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colCreateDate2 As HCalendarColumn
    Friend WithEvents colCreatedBy2 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colComments1 As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
