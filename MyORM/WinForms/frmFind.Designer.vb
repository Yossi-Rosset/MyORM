<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFind
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Grd1 = New grd()
        Me.colOpen = New System.Windows.Forms.DataGridViewLinkColumn()
        CType(Me.Grd1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grd1
        '
        Me.Grd1.AllowUserToAddRows = False
        Me.Grd1.AllowUserToDeleteRows = False
        Me.Grd1.AllowUserToOrderColumns = True
        Me.Grd1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grd1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colOpen})
        Me.Grd1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd1.Location = New System.Drawing.Point(0, 0)
        Me.Grd1.MultiSelect = False
        Me.Grd1.Name = "Grd1"
        Me.Grd1.ReadOnly = True
        Me.Grd1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grd1.Size = New System.Drawing.Size(520, 262)
        Me.Grd1.TabIndex = 0
        '
        'colOpen
        '
        Me.colOpen.ActiveLinkColor = System.Drawing.Color.Blue
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        Me.colOpen.DefaultCellStyle = DataGridViewCellStyle2
        Me.colOpen.Frozen = True
        Me.colOpen.HeaderText = ""
        Me.colOpen.Name = "colOpen"
        Me.colOpen.ReadOnly = True
        Me.colOpen.Text = "פתח"
        Me.colOpen.UseColumnTextForLinkValue = True
        Me.colOpen.VisitedLinkColor = System.Drawing.Color.Blue
        Me.colOpen.Width = 50
        '
        'frmFind
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(520, 262)
        Me.Controls.Add(Me.Grd1)
        Me.Name = "frmFind"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.Text = "Find results"
        CType(Me.Grd1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Grd1 As grd
    Friend WithEvents colOpen As System.Windows.Forms.DataGridViewLinkColumn
End Class
