Public Class HDateTimePicker

    Dim _Value As Object
    Dim _HValue As String

    Dim dispalyHeb As Boolean = False

    Private Sub picPicker_Click(sender As Object, e As EventArgs) Handles picPicker.Click
        If [ReadOnly] Then Return

        Dim frm As New frmHebCal
        frm.Location = CType(sender, PictureBox).Location
        frm.HebDTP.Value = If(_Value, Now)
        frm.ShowDialog()
        Value = frm.HebDTP.Value
    End Sub

    Public Event ValueChanged(sender As Object, e As EventArgs)

    Public Property Format() As String = "dd-MM-yyyy"

    Private _ReadOnly As Boolean

    Public Property [ReadOnly]() As Boolean
        Set(value As Boolean)
            picClear.Visible = Not value
            picPicker.Visible = Not value
            _ReadOnly = value
        End Set
        Get
            Return _ReadOnly
        End Get
    End Property


    Public Property Value() As Object
        Set(value As Object)

            If IsDate(value) AndAlso Year(value) >= 1583 AndAlso Year(value) < 2239 Then
                _Value = value
                _HValue = ctlHebCal.GregToHeb(value)
                txtValue.Text = CDate(value).ToString(Format)
            Else
                _Value = Nothing
                _HValue = ""
                txtValue.Text = ""
            End If

            OnValueChanged(New EventArgs)

            dispalyHeb = False

        End Set
        Get
            Return _Value
        End Get
    End Property

    Public ReadOnly Property HebValue() As String
        Get
            Return _HValue
        End Get
    End Property

    Private Sub txtValue_Click(sender As Object, e As EventArgs) Handles txtValue.Click

        If Value Is Nothing Then Return

        txtValue.Text = If(dispalyHeb, CDate(Value).ToString(Format), HebValue)

        dispalyHeb = Not dispalyHeb
    End Sub

    Private Sub picClear_Click(sender As Object, e As EventArgs) Handles picClear.Click
        If [ReadOnly] Then Return
        Value = Nothing
    End Sub

    Protected Overridable Sub OnValueChanged(ByVal e As EventArgs)
        RaiseEvent ValueChanged(Me, New EventArgs)
    End Sub




End Class
