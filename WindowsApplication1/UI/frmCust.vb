Public Class frmCust
    Inherits frmBase

    Public Sub New()
        MyBase.New()

        ' This call is required by the designer.
        InitializeComponent()

        InitForm()

    End Sub

    Public Overrides Sub AfterModeChange(oldmode As frmBase.FormMode, newmode As frmBase.FormMode)
        MyBase.AfterModeChange(oldmode, newmode)

        btnNewDel.Enabled = (Me.Mode = FormMode.OK Or Me.Mode = FormMode.Update)

    End Sub


    Private Sub grdCreditCards_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles grdCreditCards.CellFormatting
        If e.ColumnIndex <> CCNum.Index OrElse NZ(e.Value) = "" OrElse IsNumeric(e.Value) Then Return

        isLoadingFlag = True

        If chkViewCC.Checked Then
            e.Value = cCreditCards.DecryptCC(e.Value)
        Else
            e.Value = Microsoft.VisualBasic.Right(cCreditCards.DecryptCC(NZ(e.Value)), 4) & "****"
        End If

        isLoadingFlag = False

        e.FormattingApplied = True

    End Sub


    Public Overrides Sub AfterLoadData()

        If txtBalance.Text = 0 Then txtBalance.ForeColor = Color.Black
        If txtBalance.Text > 0 Then txtBalance.ForeColor = Color.Green
        If txtBalance.Text < 0 Then txtBalance.ForeColor = Color.Red

    End Sub

    Private Sub chkViewCC_CheckedChanged(sender As Object, e As EventArgs) Handles chkViewCC.CheckedChanged, chkViewCC.CheckedChanged
        grdCreditCards.Refresh()
    End Sub

    Private Sub chkApproved_CheckedChanged(sender As Object, e As EventArgs) Handles chkApproved.CheckedChanged
        chkApproved.ForeColor = If(chkApproved.Checked, Color.Green, Color.Red)
    End Sub

End Class
