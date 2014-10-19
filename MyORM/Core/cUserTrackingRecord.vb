Public Class cUserTrackingRecord
    Inherits cRecord

    <ObjectFieldInfo("Create Date", "CreateDate")> Public Property CreateDate() As Date
    <ObjectFieldInfo("Creator", "CreatedBy", QueryString:=cUser.UserQS)> Public Property CreatedBy() As Integer
    <ObjectFieldInfo("Update By", "UserSign", QueryString:=cUser.UserQS)> Public Property UserSign() As Integer

    Protected Overrides Sub OnBeforeInsert()
        MyBase.OnBeforeInsert()

        CreatedBy = DB.UserID
        CreateDate = Now

    End Sub

    Protected Overrides Sub OnBeforeUpsert()
        MyBase.OnBeforeUpsert()

        UserSign = DB.UserID

    End Sub


End Class
