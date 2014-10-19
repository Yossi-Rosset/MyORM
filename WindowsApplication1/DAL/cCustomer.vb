
<ObjectInfo("Customer", "נתוני לקוח")>
Public Class cCustomer
    Inherits cUserTrackingRecord

    Public Const CustomerQS As String = "SELECT CusID Value, ISNULL(FirstName,'') + ' ' + ISNULL(LastName,'') as Name FROM Customer ORDER BY 2"
    Public Const CitiesQS As String = "SELECT ID Value, Name FROM Cities ORDER BY 2"
    Public Const PayMeanTypeQS As String = "SELECT 'R' AS Value, 'כרטיס אשראי' AS Name UNION SELECT 'B', 'הו""ק' UNION SELECT 'C', 'צ''ק' UNION SELECT 'S', 'מזומן'"

    <ObjectFieldInfo("מספר לקוח", "CusID", PrimaryKey:=True)> Public Property CusID() As Integer
    <ObjectFieldInfo("שם פרטי", "FirstName")> Public Property FirstName() As String
    <ObjectFieldInfo("שם משפחה", "LastName")> Public Property LastName() As String
    <ObjectFieldInfo("מייל", "Email")> Public Property Email() As String
    <ObjectFieldInfo("טלפון", "Phone")> Public Property Phone() As String
    <ObjectFieldInfo("נייד", "Mobile")> Public Property Mobile() As String
    <ObjectFieldInfo("אחוי הנחה", "DiscPercent")> Public Property DiscPercent() As Decimal
    <ObjectFieldInfo("מוקפא", "Forzen")> Public Property Forzen() As Integer
    <ObjectFieldInfo("הערות להקפאה", "ForzenComments")> Public Property ForzenComments() As String
    <ObjectFieldInfo("הערות", "Comments")> Public Property Comments() As String
    <ObjectFieldInfo("רחוב", "Street")> Public Property Street() As String
    <ObjectFieldInfo("בית", "House")> Public Property House() As String
    <ObjectFieldInfo("קומה", "HouseFloor")> Public Property HouseFloor() As String
    <ObjectFieldInfo("דירה", "Apartment")> Public Property Apartment() As String
    <ObjectFieldInfo("עיר", "City", QueryString:=cCustomer.CitiesQS)> Public Property City() As Integer
    <ObjectFieldInfo("מדינה", "Country")> Public Property Country() As String
    <ObjectFieldInfo("מיקוד", "Zip")> Public Property Zip() As String
    <ObjectFieldInfo("מאושר", "Approved")> Public Property Approved() As Integer

    Public Property Balance() As Decimal

    Public Property CreditCards As cCreditCards()
    Public Property BankDetails As cBankDetails()
    Public Property Enrolls As cEnrolls()


    Public Overloads Function Load(CusID As Integer) As Result

        Return MyBase.Load(CusID)

    End Function

    Protected Overrides Sub OnAfterLoad(bSuccess As Boolean)
        MyBase.OnAfterLoad(bSuccess)

        If Not bSuccess Then Return


        Balance = GetBalance(Key)

    End Sub

    Public Overloads Shared Function Delete(CusID As Integer) As Result

        Return cRecord.Delete(GetType(cCustomer), CusID)

    End Function


    Shared Function GetDiscPercent(CusID As Integer) As Decimal

        Return DB.DSum("Customer", "CusID=" & CusID, "DiscPercent")

    End Function


    Shared Function GetBalance(CusID As Integer) As Decimal

        Return DB.GetScalar("SELECT dbo.GetCustBalance(" & CusID & ")")

    End Function

    Shared Function GetBalanceReport(CusID As Integer) As DataTable

        Return DB.GetDatatable("SELECT * FROM CustBalance WHERE CusID = " & CusID & " ORDER BY CusID, CreateDate")

    End Function
End Class

