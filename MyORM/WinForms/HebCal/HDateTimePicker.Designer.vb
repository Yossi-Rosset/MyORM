<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HDateTimePicker
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.txtValue = New System.Windows.Forms.TextBox()
        Me.picClear = New System.Windows.Forms.PictureBox()
        Me.picPicker = New System.Windows.Forms.PictureBox()
        CType(Me.picClear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPicker, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtValue
        '
        Me.txtValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtValue.Location = New System.Drawing.Point(0, 0)
        Me.txtValue.Name = "txtValue"
        Me.txtValue.ReadOnly = True
        Me.txtValue.Size = New System.Drawing.Size(159, 20)
        Me.txtValue.TabIndex = 0
        '
        'picClear
        '
        Me.picClear.BackColor = System.Drawing.Color.Transparent
        Me.picClear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picClear.Image = Global.MyORM.My.Resources.Resources.calDel
        Me.picClear.Location = New System.Drawing.Point(18, 2)
        Me.picClear.Margin = New System.Windows.Forms.Padding(0)
        Me.picClear.Name = "picClear"
        Me.picClear.Size = New System.Drawing.Size(16, 16)
        Me.picClear.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picClear.TabIndex = 2
        Me.picClear.TabStop = False
        '
        'picPicker
        '
        Me.picPicker.BackColor = System.Drawing.Color.Transparent
        Me.picPicker.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picPicker.Image = Global.MyORM.My.Resources.Resources.calPicker
        Me.picPicker.Location = New System.Drawing.Point(0, 2)
        Me.picPicker.Margin = New System.Windows.Forms.Padding(0)
        Me.picPicker.Name = "picPicker"
        Me.picPicker.Size = New System.Drawing.Size(16, 16)
        Me.picPicker.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picPicker.TabIndex = 1
        Me.picPicker.TabStop = False
        '
        'HDateTimePicker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.picClear)
        Me.Controls.Add(Me.picPicker)
        Me.Controls.Add(Me.txtValue)
        Me.Name = "HDateTimePicker"
        Me.Size = New System.Drawing.Size(159, 20)
        CType(Me.picClear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPicker, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtValue As System.Windows.Forms.TextBox
    Friend WithEvents picPicker As System.Windows.Forms.PictureBox
    Friend WithEvents picClear As System.Windows.Forms.PictureBox

End Class
