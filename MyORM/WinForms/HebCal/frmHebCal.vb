Public Class frmHebCal

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Button1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.Close()
        End If
    End Sub

    Private Sub HebDTP_DayDoubleClick(ByVal greg As Date, ByVal heb As String) Handles HebDTP.DayDoubleClick
        Me.Close()
    End Sub
End Class