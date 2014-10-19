<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHistory
    Inherits System.Windows.Forms.Form

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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.HCalendarColumn1 = New HCalendarColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colObjName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colChangeDate = New HCalendarColumn()
        Me.colUserSign = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colColumnName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOldValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNewValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAction = New System.Windows.Forms.DataGridViewComboBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colObjName, Me.colChangeDate, Me.colUserSign, Me.colColumnName, Me.colOldValue, Me.colNewValue, Me.colAction})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(778, 258)
        Me.DataGridView1.TabIndex = 0
        '
        'HCalendarColumn1
        '
        Me.HCalendarColumn1.DataPropertyName = "ChangeDate"
        Me.HCalendarColumn1.HeaderText = "Change Date"
        Me.HCalendarColumn1.Name = "HCalendarColumn1"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "ColumnName"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Field"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "OldValue"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Old Value"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "NewValue"
        Me.DataGridViewTextBoxColumn3.HeaderText = "New value"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'colObjName
        '
        Me.colObjName.DataPropertyName = "ObjName"
        Me.colObjName.HeaderText = "Entity"
        Me.colObjName.Name = "colObjName"
        Me.colObjName.ReadOnly = True
        '
        'colChangeDate
        '
        Me.colChangeDate.DataPropertyName = "ChangeDate"
        Me.colChangeDate.HeaderText = "Change Date"
        Me.colChangeDate.Name = "colChangeDate"
        Me.colChangeDate.ReadOnly = True
        Me.colChangeDate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'colUserSign
        '
        Me.colUserSign.DataPropertyName = "Instance"
        Me.colUserSign.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.colUserSign.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colUserSign.HeaderText = "השתנה ע""י"
        Me.colUserSign.Name = "colUserSign"
        Me.colUserSign.ReadOnly = True
        Me.colUserSign.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colUserSign.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colColumnName
        '
        Me.colColumnName.DataPropertyName = "ColumnName"
        Me.colColumnName.HeaderText = "Field"
        Me.colColumnName.Name = "colColumnName"
        Me.colColumnName.ReadOnly = True
        Me.colColumnName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colColumnName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colOldValue
        '
        Me.colOldValue.DataPropertyName = "OldValue"
        Me.colOldValue.HeaderText = "Old Value"
        Me.colOldValue.Name = "colOldValue"
        Me.colOldValue.ReadOnly = True
        '
        'colNewValue
        '
        Me.colNewValue.DataPropertyName = "NewValue"
        Me.colNewValue.HeaderText = "New Value"
        Me.colNewValue.Name = "colNewValue"
        Me.colNewValue.ReadOnly = True
        '
        'colAction
        '
        Me.colAction.DataPropertyName = "Action"
        Me.colAction.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.colAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colAction.HeaderText = "Action"
        Me.colAction.Name = "colAction"
        Me.colAction.ReadOnly = True
        '
        'frmHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(778, 258)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "frmHistory"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.Text = "Change Log"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents HCalendarColumn1 As HCalendarColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colObjName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colChangeDate As HCalendarColumn
    Friend WithEvents colUserSign As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colColumnName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOldValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNewValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAction As System.Windows.Forms.DataGridViewComboBoxColumn
End Class
