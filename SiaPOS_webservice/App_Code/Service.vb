Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data
Imports System.Data.SqlClient

' ASP.NET AJAX를 사용하여 스크립트에서 이 웹 서비스를 호출하려면 다음 줄의 주석 처리를 제거합니다.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class Service
    Inherits System.Web.Services.WebService

    <System.Web.Services.WebMethod()> _
    Public Function Login(ByVal id As String, ByVal password As String) As String
        Dim dbConnString As String
        Dim my_adt As SqlDataAdapter
        Dim my_ds As DataSet
        Dim my_dt As DataTable
        Dim my_con As SqlConnection
        Dim my_cmd As SqlCommand
        Dim strSql As String = ""
        Dim value As String
        Dim er As String = "error"
        Dim su As String = "succes"
        'Dim sha1 As New System.Security.Cryptography.SHA1CryptoServiceProvider
        'Dim enc As System.Text.UnicodeEncoding
        Dim authService As New AuthenticationServiceManager()

        dbConnString = "Data Source=220.92.62.65;Initial Catalog=ASPNETDB;User ID=jung;Password=!jwj2114!"
        my_con = New SqlConnection(dbConnString)

        strSql = "select b.UserName from dbo.aspnet_Membership as a inner join dbo.aspnet_Users as b on a.UserId = b.UserId where b.UserName = @ShopID and a.Password= @Password"
        my_cmd = New SqlCommand(strSql, my_con)

        Dim ShopID As SqlParameter = New SqlParameter("@ShopID", System.Data.SqlDbType.NVarChar, 256)
        ShopID.Value = id
        my_cmd.Parameters.Add(ShopID)
        Dim iPassword As SqlParameter = New SqlParameter("@Password", System.Data.SqlDbType.NVarChar, 128)
        iPassword.Value = password
        my_cmd.Parameters.Add(iPassword)

        my_adt = New SqlDataAdapter(my_cmd)
        my_con.Open()

        my_ds = New DataSet("TBL")
        my_adt.Fill(my_ds)
        Try
            If my_ds.Tables.Item(0).Rows(0).RowState Then
                my_dt = my_ds.Tables.Item(0)
                Dim rws As DataRowCollection = my_dt.Rows
                Dim rw As DataRow

                For Each rw In rws
                    value = rw.Item("UserName").ToString
                Next
                my_con.Close()
            End If
            Return su
        Catch ex As Exception
            my_con.Close()
            Return er
        End Try

    End Function
    <System.Web.Services.WebMethod()> _
    Public Function getCategory(ByVal ID As String, ByVal State As String, ByVal SDate As String, ByVal EDate As String) As Category()

        Dim objRet As Category()

        Dim dbConnString As String

        Dim my_adt As SqlDataAdapter
        Dim my_ds As DataSet
        Dim my_con As SqlConnection
        Dim my_cmd As SqlCommand
        Dim strSql As String = ""
        Dim dblrecent As Double

        dbConnString = "Data Source=220.92.62.65;Initial Catalog=SibalChk2011;User ID=jung;Password=!jwj2114!" 'Inital Catalog 실행이안되면 DATABASE 로 바꿔줌"

        my_con = New SqlConnection(dbConnString)     'db접속

        strSql += "SELECT"
        strSql += "[MenuName]"
        strSql += ",[Date]"
        strSql += ",[TableNumber]"
        strSql += ",[MenuAccount]"
        strSql += ",[Profit]"
        strSql += "FROM [Shop].[ShopAccount] WHERE [ShopID] = @ShopID and "
        strSql += "OrderState = @OrderState and "
        strSql += "Date between @StartDate and @EndDate"

        'select MenuName, Date, MenuAccount, Profit
        'from(Shop.ShopAccount)
        'where ShopID = 'y4321' and 
        'OrderState = 1 and 
        'Date between '2011-08-22' and  '2011-08-23'

        Dim ShopID As SqlParameter = New SqlParameter("@ShopID", System.Data.SqlDbType.VarChar, 50)
        ShopID.Value = ID
        Dim OrderState As SqlParameter = New SqlParameter("@OrderState", System.Data.SqlDbType.Int)
        OrderState.Value = State
        Dim StartDate As SqlParameter = New SqlParameter("@StartDate", System.Data.SqlDbType.Date)
        StartDate.Value = SDate
        Dim EndDate As SqlParameter = New SqlParameter("@EndDate", System.Data.SqlDbType.Date)
        EndDate.Value = EDate

        my_cmd = New SqlCommand(strSql, my_con)
        my_cmd.Parameters.Add(ShopID)
        my_cmd.Parameters.Add(OrderState)
        my_cmd.Parameters.Add(StartDate)
        my_cmd.Parameters.Add(EndDate)

        my_adt = New SqlDataAdapter(my_cmd)   'db접속을 실행을 시켜서 adp에 넣어라 결과값이ㅣ  들어있음.
        my_con.Open()


        my_ds = New DataSet("TBL")
        my_adt.Fill(my_ds)                    '버퍼라고 생각하면됨. adt값을 ds에 가득 채워넣어라


        my_con.Close()

        dblrecent = my_ds.Tables(0).Rows.Count      '레코드가 몇개의 줄이 있느냐

        ReDim objRet(dblrecent - 1)    '배열을 제정의

        For x = 0 To dblrecent - 1              'x=는 0에서부터 dblrecent -1까지
            objRet(x) = New Category        '초기화 = 오브젝트리턴이라는 방에 새로운 카테고리 적용
            objRet(x).category_menuname = my_ds.Tables(0).Rows(x).Item("MenuName")
            objRet(x).category_date = my_ds.Tables(0).Rows(x).Item("Date")
            objRet(x).category_tablenumber = my_ds.Tables(0).Rows(x).Item("TableNumber")
            objRet(x).category_menuaccount = my_ds.Tables(0).Rows(x).Item("MenuAccount")
            objRet(x).category_profit = my_ds.Tables(0).Rows(x).Item("Profit")
        Next
        Return objRet
    End Function

    <System.Web.Services.WebMethod()> _
    Public Function getTempShop(ByVal ID As String) As Category()
        Dim objRet As Category()

        Dim dbConnString As String

        Dim my_adt As SqlDataAdapter
        Dim my_ds As DataSet
        Dim my_con As SqlConnection
        Dim strSql As String = ""
        Dim dblrecent As Double
        Dim my_cmd As SqlCommand

        dbConnString = "Data Source=220.92.62.65;Initial Catalog=SibalChk2011;User ID=jung;Password=!jwj2114!" 'Inital Catalog 실행이안되면 DATABASE 로 바꿔줌"

        my_con = New SqlConnection(dbConnString)     'db접속

        strSql += "SELECT"
        strSql += "[MenuName]"
        strSql += ",[Date]"
        strSql += ",[TableNumber]"
        strSql += ",[MenuAccount]"
        strSql += "FROM [Shop].[TempShopAccount] WHERE [ShopID] = @ShopID"

        Dim ShopID As SqlParameter = New SqlParameter("@ShopID", System.Data.SqlDbType.VarChar, 50)
        ShopID.Value = ID

        my_cmd = New SqlCommand(strSql, my_con)
        my_cmd.Parameters.Add(ShopID)

        my_adt = New SqlDataAdapter(my_cmd)   'db접속을 실행을 시켜서 adp에 넣어라 결과값이ㅣ  들어있음.

        my_con.Open()


        my_ds = New DataSet("TBL")
        my_adt.Fill(my_ds)                    '버퍼라고 생각하면됨. adt값을 ds에 가득 채워넣어라


        my_con.Close()

        dblrecent = my_ds.Tables(0).Rows.Count      '레코드가 몇개의 줄이 있느냐

        ReDim objRet(dblrecent - 1)    '배열을 제정의

        For x = 0 To dblrecent - 1              'x=는 0에서부터 dblrecent -1까지
            objRet(x) = New Category        '초기화 = 오브젝트리턴이라는 방에 새로운 카테고리 적용
            objRet(x).category_menuname = my_ds.Tables(0).Rows(x).Item("MenuName")
            objRet(x).category_date = my_ds.Tables(0).Rows(x).Item("Date")
            objRet(x).category_tablenumber = my_ds.Tables(0).Rows(x).Item("TableNumber")
            objRet(x).category_menuaccount = my_ds.Tables(0).Rows(x).Item("MenuAccount")
        Next
        Return objRet
    End Function

    <System.Web.Services.WebMethod()> _
    Public Function getTotal(ByVal ID As String, ByVal State As String) As Category()

        Dim objRet As Category()

        Dim dbConnString As String

        Dim my_adt As SqlDataAdapter
        Dim my_ds As DataSet
        Dim my_con As SqlConnection
        Dim my_cmd As SqlCommand
        Dim strSql As String = ""
        Dim dblrecent As Double

        dbConnString = "Data Source=220.92.62.65;Initial Catalog=SibalChk2011;User ID=jung;Password=!jwj2114!" 'Inital Catalog 실행이안되면 DATABASE 로 바꿔줌"

        my_con = New SqlConnection(dbConnString)     'db접속

        strSql += "SELECT"
        strSql += "[MenuName]"
        strSql += ",[Date]"
        strSql += ",[TableNumber]"
        strSql += ",[MenuAccount]"
        strSql += ",[Profit]"
        strSql += "FROM [Shop].[ShopAccount] WHERE [ShopID] = @ShopID and "
        strSql += "OrderState = @OrderState"

        Dim ShopID As SqlParameter = New SqlParameter("@ShopID", System.Data.SqlDbType.VarChar, 50)
        ShopID.Value = ID
        Dim OrderState As SqlParameter = New SqlParameter("@OrderState", System.Data.SqlDbType.Int)
        OrderState.Value = State

        my_cmd = New SqlCommand(strSql, my_con)
        my_cmd.Parameters.Add(ShopID)
        my_cmd.Parameters.Add(OrderState)

        my_adt = New SqlDataAdapter(my_cmd)   'db접속을 실행을 시켜서 adp에 넣어라 결과값이ㅣ  들어있음.
        my_con.Open()


        my_ds = New DataSet("TBL")
        my_adt.Fill(my_ds)                    '버퍼라고 생각하면됨. adt값을 ds에 가득 채워넣어라


        my_con.Close()

        dblrecent = my_ds.Tables(0).Rows.Count      '레코드가 몇개의 줄이 있느냐

        ReDim objRet(dblrecent - 1)    '배열을 제정의

        For x = 0 To dblrecent - 1              'x=는 0에서부터 dblrecent -1까지
            objRet(x) = New Category        '초기화 = 오브젝트리턴이라는 방에 새로운 카테고리 적용
            objRet(x).category_menuname = my_ds.Tables(0).Rows(x).Item("MenuName")
            objRet(x).category_date = my_ds.Tables(0).Rows(x).Item("Date")
            objRet(x).category_tablenumber = my_ds.Tables(0).Rows(x).Item("TableNumber")
            objRet(x).category_menuaccount = my_ds.Tables(0).Rows(x).Item("MenuAccount")
            objRet(x).category_profit = my_ds.Tables(0).Rows(x).Item("Profit")
        Next
        Return objRet
    End Function

    <System.Web.Services.WebMethod()> _
    Public Function getMenuTop(ByVal ID As String, ByVal Num As String, ByVal SDate As String, ByVal EDate As String) As Category()

        Dim objRet As Category()

        Dim dbConnString As String

        Dim my_adt As SqlDataAdapter
        Dim my_ds As DataSet
        Dim my_con As SqlConnection
        Dim my_cmd As SqlCommand
        Dim strSql As String = ""
        Dim dblrecent As Double

        dbConnString = "Data Source=220.92.62.65;Initial Catalog=SibalChk2011;User ID=jung;Password=!jwj2114!" 'Inital Catalog 실행이안되면 DATABASE 로 바꿔줌"

        my_con = New SqlConnection(dbConnString)     'db접속

        strSql += "select top (@number) MenuName, count(MenuAccount)as total from Shop.ShopAccount where ShopID = @ShopID and date between @StartDate and @EndDate group by MenuName Order by total desc"

        'select top (@number) MenuName, count(MenuAccount)as total 
        'from(Shop.ShopAccount)
        'where ShopID = @ShopID and date between @StartDate and @EndDate 
        'group by MenuName 
        'Order by total desc

        Dim ShopID As SqlParameter = New SqlParameter("@ShopID", System.Data.SqlDbType.VarChar, 50)
        ShopID.Value = ID
        Dim Number As SqlParameter = New SqlParameter("@Number", System.Data.SqlDbType.Int)
        Number.Value = Num
        Dim StartDate As SqlParameter = New SqlParameter("@StartDate", System.Data.SqlDbType.Date)
        StartDate.Value = SDate
        Dim EndDate As SqlParameter = New SqlParameter("@EndDate", System.Data.SqlDbType.Date)
        EndDate.Value = EDate

        my_cmd = New SqlCommand(strSql, my_con)
        my_cmd.Parameters.Add(ShopID)
        my_cmd.Parameters.Add(Number)
        my_cmd.Parameters.Add(StartDate)
        my_cmd.Parameters.Add(EndDate)

        my_adt = New SqlDataAdapter(my_cmd)   'db접속을 실행을 시켜서 adp에 넣어라 결과값이ㅣ  들어있음.
        my_con.Open()


        my_ds = New DataSet("TBL")
        my_adt.Fill(my_ds)                    '버퍼라고 생각하면됨. adt값을 ds에 가득 채워넣어라


        my_con.Close()

        dblrecent = my_ds.Tables(0).Rows.Count      '레코드가 몇개의 줄이 있느냐

        ReDim objRet(dblrecent - 1)    '배열을 제정의

        For x = 0 To dblrecent - 1              'x=는 0에서부터 dblrecent -1까지
            objRet(x) = New Category        '초기화 = 오브젝트리턴이라는 방에 새로운 카테고리 적용
            objRet(x).category_menuname = my_ds.Tables(0).Rows(x).Item("MenuName")
            objRet(x).category_date = my_ds.Tables(0).Rows(x).Item("total")
        Next
        Return objRet
    End Function

End Class

Public Class Category
    Public category_menuname As String
    Public category_date As String
    Public category_tablenumber As String
    Public category_menuaccount As String
    Public category_profit As String
End Class