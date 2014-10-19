
<ObjectInfo("CreditCards", "כרטיס אשראי", "CusID")> _
Public Class cCreditCards
    Inherits cUserTrackingRecord

    Private Shared EncrKey As String = "Billing"

    <ObjectFieldInfo("מזהה כרטיס אשראי", "CreID", PrimaryKey:=True)> Public Property PayID As Integer
    <ObjectFieldInfo("מספר לקוח", "CusID", True, QueryString:=cCustomer.CustomerQS)> Public Property CusID() As Integer
    <ObjectFieldInfo("יום חיוב", "PayDay", True)> Public Property PayDay() As Integer

    <ObjectFieldInfo("תוקף", "CCExp", True)> Public Property CCExp() As String
    <ObjectFieldInfo("שם מחזיק", "CCName")> Public Property CCName() As String
    <ObjectFieldInfo("ת.ז. מחזיק", "CCID", True)> Public Property CCID() As String
    <ObjectFieldInfo("CVV", "CCCVV")> Public Property CCCVV() As String
    <ObjectFieldInfo("הערות", "Comments")> Public Property Comments() As String

    <ObjectFieldInfo("4 ספרות אחרונות", "LastDigits")> Public Property LastDigits() As Integer

    'Encrypt on set in order to keep DB value encrypted
    Private _CCNum As String
    <ObjectFieldInfo("מספר", "CCNum", True)> Public Property CCNum() As String
        Set(value As String)
            _CCNum = If(IsNumeric(value), EncryptCC(value), value)
            _CCNumPlainText = If(IsNumeric(value), value, DecryptCC(value))
            LastDigits = Microsoft.VisualBasic.Right(_CCNumPlainText, 4)
        End Set
        Get
            Return _CCNum
        End Get
    End Property

    Private _CCNumPlainText As String
    Public ReadOnly Property CCNumPlainText() As String
        Get
            Return _CCNumPlainText
        End Get
    End Property

    Public Shared Function EncryptCC(CCnum As String)
        Return Encryption.AES_Encrypt(CCnum, EncrKey)
    End Function

    Public Shared Function DecryptCC(EncCCnum As String)
        Return Encryption.AES_Decrypt(EncCCnum, EncrKey)
    End Function

    Protected Overrides Function Validate(IsInsert As Boolean) As String

        Dim basevalidations As String = MyBase.Validate(IsInsert)

        If basevalidations <> "" Then Return basevalidations

        If DB.IsDate(CCExp, "MM-yy") = False Then
            Return "תוקף לא תקין, צריך להיות במבנה MM-yy"
        End If

        If IsNumeric(_CCNumPlainText) = False Then
            Return "מספר כרטיס אשראי לא תקין צריך להיות ספרות בלבד"
        End If

        If IsNumeric(CCID) = False Then
            Return "ת.ז. מחזיק לא תקינה צריך להיות ספרות בלבד"
        End If

        If IsNumeric(CCID) = False Then
            Return "CVV לא תקין צריך להיות ספרות בלבד"
        End If

        Return ""
    End Function

End Class


