
<ObjectInfo("BankDetails", "הוראת קבע", "CusID")> _
Public Class cBankDetails
    Inherits cUserTrackingRecord

    <ObjectFieldInfo("מזהה הוראת קבע", "BanID", PrimaryKey:=True)> Public Property PayID As Integer
    <ObjectFieldInfo("מספר לקוח", "CusID", True, QueryString:=cCustomer.CustomerQS)> Public Property CusID() As Integer
    <ObjectFieldInfo("מספר חשבון", "BNum", True)> Public Property BNum() As String
    <ObjectFieldInfo("קוד בנק", "BBank", True)> Public Property BBank() As String
    <ObjectFieldInfo("שם חשבון בנק", "BName", True)> Public Property BName() As String
    <ObjectFieldInfo("סניף בנק", "BBranch", True)> Public Property BBranch() As String
    <ObjectFieldInfo("הערות", "Comments")> Public Property Comments() As String

End Class