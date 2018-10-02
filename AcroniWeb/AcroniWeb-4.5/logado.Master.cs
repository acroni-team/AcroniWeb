using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AcroniWeb_4._5
{
    public partial class logado : System.Web.UI.MasterPage
    {
        SqlConnection conexao_SQL = new SqlConnection(acroni.classes.Conexao.nome_conexao);
        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["logado"].ToString() != "1")
                Response.Redirect("default.aspx");
            else
                lblUser.Text = Session["usuario"].ToString();

            try
            {
                if (conexao_SQL.State != ConnectionState.Open)
                    conexao_SQL.Open();
                String select = "SELECT * FROM tblCliente";
                SqlDataAdapter da = new SqlDataAdapter(select, conexao_SQL);
                ds = new DataSet();
                da.Fill(ds);


                foreach (DataRow row in ds.Tables[0].Rows)
                {

                    //Get the byte array from image file
                    byte[] imgBytes = (byte[])row["imagem"];

                    //If you want convert to a bitmap file
                    TypeConverter tc = TypeDescriptor.GetConverter(typeof(Bitmap));
                    Bitmap MyBitmap = (Bitmap)tc.ConvertFrom(imgBytes);


                    string imgString = Convert.ToBase64String(imgBytes);
                    //Set the source with data:image/bmp
                    profilePicture.ImageUrl = String.Format("data:image/Bmp;base64,{0}\"", imgString);   //img is the Image control ID
                }

                conexao_SQL.Close();
            }
            catch (Exception ex)
            {
                conexao_SQL.Close();
            }
        }

        protected void deslogar_Click(object sender, EventArgs e)
        {
            Session["logado"] = "0";
            Response.Redirect("default.aspx");

        }
    }
}