<ObjectInfo("Users", "משתמשים")> _
Public Class cUser
    Inherits cRecord

    Public Const UserQS As String = "SELECT UseID Value, Name FROM Users ORDER BY 2"

    <ObjectFieldInfo("קוד משתמש", "UseID", Primarykey:=True)> Public Property UseID() As Integer
    <ObjectFieldInfo("שם משתמש", "Name")> Public Property Name() As String
    <ObjectFieldInfo("סיסמה", "Pwd")> Public Property Pwd() As String

End Class
