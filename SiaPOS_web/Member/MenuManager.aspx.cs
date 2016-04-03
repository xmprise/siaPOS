using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Member_MenuManager : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(! IsPostBack ){
            UserName.Text = User.Identity.Name;
        }
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string strMenuName = MenuName.Text.ToString();
        string strMenuPrice = Price.Text.ToString();
        string strMenuInfo = MenuInfo.Text.ToString();
        string strShopID = UserName.Text.ToString();

        if (FileUpload1.PostedFile != null && FileUpload1.PostedFile.FileName != "")
        {
            byte[] imageSize = new byte[FileUpload1.PostedFile.ContentLength];
            HttpPostedFile uploadedImage = FileUpload1.PostedFile;
            uploadedImage.InputStream.Read(imageSize, 0, (int)FileUpload1.PostedFile.ContentLength);

            // Create SQL Connection 
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["SibalChk2011ConnectionString"].ConnectionString;

            // Create SQL Command 

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Product.MenuInformation(MenuName, ImageContent, MenuPrice, MenuInfomation, ShopID) VALUES (@MenuName,@ImageContent, @MenuPrice, @MenuInfomation, @ShopID)";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            SqlParameter ImageName = new SqlParameter("@MenuName", SqlDbType.VarChar, 50);
            ImageName.Value = strMenuName.ToString();
            cmd.Parameters.Add(ImageName);

            SqlParameter UploadedImage = new SqlParameter("@ImageContent", SqlDbType.Image, imageSize.Length);
            UploadedImage.Value = imageSize;
            cmd.Parameters.Add(UploadedImage);

            SqlParameter MenuPrice = new SqlParameter("@MenuPrice", SqlDbType.VarChar, 50);
            MenuPrice.Value = strMenuPrice.ToString();
            cmd.Parameters.Add(MenuPrice);

            SqlParameter MenuInfomation = new SqlParameter("@MenuInfomation", SqlDbType.VarChar);
            MenuInfomation.Value = strMenuInfo.ToString();
            cmd.Parameters.Add(MenuInfomation);

            SqlParameter ShopID = new SqlParameter("@ShopID", SqlDbType.VarChar, 50);
            ShopID.Value = strShopID.ToString();
            cmd.Parameters.Add(ShopID);

            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            GridView1.DataBind();
            
            //트랜잭션 처리
            cmd.CommandText = "";
            cmd.CommandText = "INSERT INTO Shop.ShopStock(ShopID, MenuName, Stock) VALUES (@ShopID2, @MenuName2, 0)";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            SqlParameter ShopID2 = new SqlParameter("@ShopID2", SqlDbType.VarChar, 50);
            ShopID2.Value = strShopID.ToString();
            cmd.Parameters.Add(ShopID2);
         
            SqlParameter ImageName2 = new SqlParameter("@MenuName2", SqlDbType.VarChar, 50);
            ImageName2.Value = strMenuName.ToString();
            cmd.Parameters.Add(ImageName2);
                        
            con.Open();
            int result2 = cmd.ExecuteNonQuery();
            con.Close();

            MenuName.Text = "";
            FileUpload1.Dispose();
            Price.Text = "";
            MenuInfo.Text = "";
        }
    }
}