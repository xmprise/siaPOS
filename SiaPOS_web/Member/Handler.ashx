<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

public class Handler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["SibalChk2011ConnectionString1"].ConnectionString;

        // Create SQL Command 

        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "Select ImageContent,MenuPrice,MenuInfomation From Product.MenuInformation Where MenuName = @ID"; //
        cmd.CommandType = System.Data.CommandType.Text;
        cmd.Connection = con;

        SqlParameter ImageID = new SqlParameter("@ID", System.Data.SqlDbType.VarChar,50);
        ImageID.Value = context.Request.QueryString["MenuName"];
        cmd.Parameters.Add(ImageID);
        con.Open();
        SqlDataReader dReader = cmd.ExecuteReader();
        dReader.Read();
        context.Response.BinaryWrite((byte[])dReader["ImageContent"]);
        dReader.Close();
        con.Close();
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}