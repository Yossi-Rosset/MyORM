
<ObjectInfo("Enrolls", "רישום", "CusID")> _
Public Class cEnrolls
    Inherits cUserTrackingRecord

    Public Const PayMeanQS As String = "SELECT CreID Value, 'אשראי - ' + CAST(LastDigits AS NVARCHAR(4)) Name FROM CreditCards WHERE CusID = '{KEY}' " &
        "UNION SELECT BanID, 'הו""ק - ' + CAST(BNum AS NVARCHAR(20)) FROM BankDetails WHERE CusID = '{KEY}'"

    <ObjectFieldInfo("מזהה רישום", "EnrID", PrimaryKey:=True)> Public Property PayID As Integer
    <ObjectFieldInfo("מספר לקוח", "CusID", True, QueryString:=cCustomer.CustomerQS)> Public Property CusID() As Integer
    <ObjectFieldInfo("אמצעי תשלום", "PayMean", QueryString:=cEnrolls.PayMeanQS)> Public Property PayMean() As Integer
    <ObjectFieldInfo("מתאריך", "FromDate", True)> Public Property FromDate() As Date
    <ObjectFieldInfo("עד תאריך", "ToDate")> Public Property ToDate() As Date
    <ObjectFieldInfo("מחיר מיוחד", "Price")> Public Property Price() As Decimal
    <ObjectFieldInfo("פעיל", "Active", DefaultValue:=1)> Public Property Active() As Integer
    <ObjectFieldInfo("רחוב", "Street")> Public Property Street() As String
    <ObjectFieldInfo("בית", "House")> Public Property House() As String
    <ObjectFieldInfo("קומה", "HouseFloor")> Public Property HouseFloor() As String
    <ObjectFieldInfo("דירה", "Apartment")> Public Property Apartment() As String
    <ObjectFieldInfo("עיר", "City", QueryString:=cCustomer.CitiesQS)> Public Property City() As String
    <ObjectFieldInfo("ארץ", "Country")> Public Property Country() As String
    <ObjectFieldInfo("מיקוד", "Zip")> Public Property Zip() As String
    <ObjectFieldInfo("הערות", "Comments")> Public Property Comments() As String

End Class
