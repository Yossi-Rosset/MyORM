Imports System.Text
Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing

Public Class grd
    Inherits DataGridView

    Dim btnExcel As PictureBox
    Dim btnSave As PictureBox

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        btnExcel = New PictureBox
        btnExcel.Visible = False
        btnExcel.SizeMode = PictureBoxSizeMode.AutoSize
        btnExcel.Image = My.Resources.excel

        Me.Controls.Add(btnExcel)

        btnExcel.BringToFront()

        AddHandler btnExcel.Click, AddressOf btnExeclClick

        btnSave = New PictureBox
        btnSave.Visible = False
        btnSave.SizeMode = PictureBoxSizeMode.AutoSize
        btnSave.Image = My.Resources.save

        Me.Controls.Add(btnSave)

        btnSave.BringToFront()

        AddHandler btnSave.Click, AddressOf btnSaveClick

        OnResize(Nothing)

    End Sub


    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)

        btnSave.Location = New Point(34, Me.Height - btnExcel.Height - 20)
        btnExcel.Location = New Point(10, Me.Height - btnExcel.Height - 20)

    End Sub

    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        MyBase.OnMouseMove(e)

        If e.X < 50 AndAlso e.Y > Me.Height - btnExcel.Height - 30 Then
            btnExcel.Visible = True
            btnSave.Visible = True
        Else
            btnExcel.Visible = False
            btnSave.Visible = False
        End If

    End Sub

    Private Sub btnExeclClick(sender As Object, e As EventArgs)

        Dim sFilePath As String = IO.Path.GetTempFileName.Replace(".tmp", ".xls")
        ToCsV(Me, sFilePath)

        Process.Start(sFilePath)

    End Sub

    Private Sub btnSaveClick(sender As Object, e As EventArgs)

        Dim sfd As New SaveFileDialog()
        sfd.Filter = "Excel Documents (*.xls)|*.xls"
        sfd.FileName = "export.xls"
        If sfd.ShowDialog() = DialogResult.OK Then
            ToCsV(Me, sfd.FileName)
        End If


    End Sub

    Private Sub ToCsV(dGV As DataGridView, filename As String)
        Dim stOutput As String = ""
        ' Export titles:
        Dim sHeaders As String = ""

        For j As Integer = 0 To dGV.Columns.Count - 1
            sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns(j).HeaderText) + vbTab
        Next
        stOutput += sHeaders & Convert.ToString(vbCr & vbLf)

        ' Export data.
        For i As Integer = 0 To dGV.RowCount - 2

            Dim stLine As String = ""

            For j As Integer = 0 To dGV.Rows(i).Cells.Count - 1

                Dim cell As DataGridViewCell = dGV.Rows(i).Cells(j)

                stLine = stLine & cell.FormattedValue & vbTab

            Next

            stOutput += stLine & Convert.ToString(vbCr & vbLf)
        Next

        Dim utf16 As Encoding = Encoding.GetEncoding(1255)
        Dim output As Byte() = utf16.GetBytes(stOutput)
        Dim fs As New FileStream(filename, FileMode.Create)
        Dim bw As New BinaryWriter(fs)
        bw.Write(output, 0, output.Length)
        'write the encoded file
        bw.Flush()
        bw.Close()
        fs.Close()
    End Sub

End Class
