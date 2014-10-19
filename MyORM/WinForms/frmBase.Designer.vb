<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBase
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
        Me.components = New System.ComponentModel.Container()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnNew = New System.Windows.Forms.ToolStripButton()
        Me.DeleteToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.btnFind = New System.Windows.Forms.ToolStripButton()
        Me.btnLast = New System.Windows.Forms.ToolStripButton()
        Me.btnNext = New System.Windows.Forms.ToolStripButton()
        Me.btnBack = New System.Windows.Forms.ToolStripButton()
        Me.btnFirst = New System.Windows.Forms.ToolStripButton()
        Me.AttachToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ViewAttachedToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.HistToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.IDToolStripTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.lstFiles = New System.Windows.Forms.ListView()
        Me.cmsFiles = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1.SuspendLayout()
        Me.cmsFiles.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNew, Me.DeleteToolStripButton, Me.btnFind, Me.btnLast, Me.btnNext, Me.btnBack, Me.btnFirst, Me.AttachToolStripButton, Me.ViewAttachedToolStripButton, Me.HistToolStripButton, Me.ToolStripSeparator1, Me.ToolStripLabel1, Me.IDToolStripTextBox})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(508, 25)
        Me.ToolStrip1.TabIndex = 39
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnNew
        '
        Me.btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnNew.Image = Global.MyORM.My.Resources.Resources.add
        Me.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(23, 22)
        Me.btnNew.Text = "Create New"
        '
        'DeleteToolStripButton
        '
        Me.DeleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.DeleteToolStripButton.Image = Global.MyORM.My.Resources.Resources.calDel
        Me.DeleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DeleteToolStripButton.Name = "DeleteToolStripButton"
        Me.DeleteToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.DeleteToolStripButton.Text = "Delete"
        '
        'btnFind
        '
        Me.btnFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnFind.Image = Global.MyORM.My.Resources.Resources.find
        Me.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(23, 22)
        Me.btnFind.Text = "Find"
        '
        'btnLast
        '
        Me.btnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnLast.Image = Global.MyORM.My.Resources.Resources.last
        Me.btnLast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnLast.Name = "btnLast"
        Me.btnLast.Size = New System.Drawing.Size(23, 22)
        Me.btnLast.Text = "Last"
        '
        'btnNext
        '
        Me.btnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnNext.Image = Global.MyORM.My.Resources.Resources._next
        Me.btnNext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(23, 22)
        Me.btnNext.Text = "Next"
        '
        'btnBack
        '
        Me.btnBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnBack.Image = Global.MyORM.My.Resources.Resources.back
        Me.btnBack.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(23, 22)
        Me.btnBack.Text = "Back"
        '
        'btnFirst
        '
        Me.btnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnFirst.Image = Global.MyORM.My.Resources.Resources.first
        Me.btnFirst.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.Size = New System.Drawing.Size(23, 22)
        Me.btnFirst.Text = "First"
        Me.btnFirst.ToolTipText = "First"
        '
        'AttachToolStripButton
        '
        Me.AttachToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AttachToolStripButton.Image = Global.MyORM.My.Resources.Resources.att
        Me.AttachToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AttachToolStripButton.Name = "AttachToolStripButton"
        Me.AttachToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.AttachToolStripButton.Text = "Attach File"
        '
        'ViewAttachedToolStripButton
        '
        Me.ViewAttachedToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ViewAttachedToolStripButton.Image = Global.MyORM.My.Resources.Resources.open
        Me.ViewAttachedToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ViewAttachedToolStripButton.Name = "ViewAttachedToolStripButton"
        Me.ViewAttachedToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.ViewAttachedToolStripButton.Text = "View Attached Files"
        '
        'HistToolStripButton
        '
        Me.HistToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.HistToolStripButton.Image = Global.MyORM.My.Resources.Resources.history
        Me.HistToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.HistToolStripButton.Name = "HistToolStripButton"
        Me.HistToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.HistToolStripButton.Text = "View History"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(21, 22)
        Me.ToolStripLabel1.Text = "ID:"
        '
        'IDToolStripTextBox
        '
        Me.IDToolStripTextBox.Name = "IDToolStripTextBox"
        Me.IDToolStripTextBox.Size = New System.Drawing.Size(100, 25)
        '
        'lstFiles
        '
        Me.lstFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstFiles.ContextMenuStrip = Me.cmsFiles
        Me.lstFiles.GridLines = True
        Me.lstFiles.Location = New System.Drawing.Point(205, 28)
        Me.lstFiles.Name = "lstFiles"
        Me.lstFiles.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lstFiles.ShowItemToolTips = True
        Me.lstFiles.Size = New System.Drawing.Size(10, 10)
        Me.lstFiles.TabIndex = 41
        Me.lstFiles.UseCompatibleStateImageBehavior = False
        Me.lstFiles.View = System.Windows.Forms.View.SmallIcon
        Me.lstFiles.Visible = False
        '
        'cmsFiles
        '
        Me.cmsFiles.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteFileToolStripMenuItem, Me.SaveFileToolStripMenuItem})
        Me.cmsFiles.Name = "cmsFiles"
        Me.cmsFiles.Size = New System.Drawing.Size(142, 48)
        '
        'DeleteFileToolStripMenuItem
        '
        Me.DeleteFileToolStripMenuItem.Name = "DeleteFileToolStripMenuItem"
        Me.DeleteFileToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.DeleteFileToolStripMenuItem.Text = "מחיקה"
        '
        'SaveFileToolStripMenuItem
        '
        Me.SaveFileToolStripMenuItem.Name = "SaveFileToolStripMenuItem"
        Me.SaveFileToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.SaveFileToolStripMenuItem.Text = "שמירה בשם"
        '
        'frmBase
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(508, 399)
        Me.Controls.Add(Me.lstFiles)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "frmBase"
        Me.Text = "frmBase"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.cmsFiles.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnFind As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnFirst As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnBack As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnNext As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnLast As System.Windows.Forms.ToolStripButton
    Friend WithEvents DeleteToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents AttachToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ViewAttachedToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents lstFiles As System.Windows.Forms.ListView
    Friend WithEvents cmsFiles As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HistToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents IDToolStripTextBox As System.Windows.Forms.ToolStripTextBox
End Class
