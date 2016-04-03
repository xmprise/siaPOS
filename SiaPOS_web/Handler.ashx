<%@ WebHandler Language="VB" Class="Handler" %>

Imports System
Imports System.Web
Imports System.Data.SqlClient

Public Class Handler : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Dim con As New SqlConnection()
        con.ConnectionString = ConfigurationManager.ConnectionStrings("Data Source=124.198.16.87;Initial Catalog=SibalChk2011;User ID=jung;Password=!jwj860517!").ConnectionString
 
        ' Create SQL Command 
 
        Dim cmd As New SqlCommand()
        cmd.CommandText = "Select ImageContent from Product.MenuInformation" +
                          " where MenuName =@IID"
        cmd.CommandType = System.Data.CommandType.Text
        cmd.Connection = con
 
        Dim ImageID As New SqlParameter("@IID", System.Data.SqlDbType.Int)
        ImageID.Value = context.Request.QueryString("MenuName")
        cmd.Parameters.Add(ImageID)
        con.Open()
        Dim dReader As SqlDataReader = cmd.ExecuteReader()
        dReader.Read()
        context.Response.BinaryWrite(DirectCast(dReader("ImageContent"), Byte()))
        dReader.Close()
        con.Close()

    End Sub
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class