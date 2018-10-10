using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AcroniWeb_4._5
{
    public partial class editar_conta : System.Web.UI.Page
    {
        Utilitarios ut = new Utilitarios();
        SQLMetodos sql = new SQLMetodos();
        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> campos = new List<string>();
            campos = sql.selectCampos("nome, cpf, cep, email, usuario, senha", "tblCliente", "usuario = '" + Session["usuario"] + "'");
            Nome.Attributes["placeholder"] = campos[0];
            CPF.Attributes["placeholder"] = campos[1];
            CEP.Attributes["placeholder"] = campos[2];
            Email.Attributes["placeholder"] = campos[3];
            Usuario.Attributes["placeholder"] = campos[4];
            Senha.Attributes["placeholder"] = campos[5];
        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            bool imagemSN = false;
            if (!FileUpload1.HasFile)
            {
                imagemSN = false;   
            }
            else if (!(FileUpload1.PostedFile.ContentType == "image/jpeg" ||
                       FileUpload1.PostedFile.ContentType == "image/png" ||
                       FileUpload1.PostedFile.ContentType == "image/bmp" ||
                       FileUpload1.PostedFile.ContentType == "image/tiff" ||
                       FileUpload1.PostedFile.ContentType == "image/gif"))
            {
                //Mensagem de erro porque não é imagem K
            }
            else if (FileUpload1.PostedFile.ContentLength > 8388608)
            {
                //Criar uma mensagem de erro pois a imagem é muito grande
            }
            else
            {
                byte[] imgBytes;
                HttpFileCollection hfc = Request.Files;
                System.Drawing.Image image = System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream);
                HttpPostedFile hpf = hfc[0];
                if (hpf.ContentLength > 0)
                {
                    if (Path.GetExtension(hpf.FileName) == ".jpeg")
                        imgBytes = ut.ConvertImageToByteArray(image, System.Drawing.Imaging.ImageFormat.Jpeg);
                    else if (Path.GetExtension(hpf.FileName) == ".png")
                        imgBytes = ut.ConvertImageToByteArray(image, System.Drawing.Imaging.ImageFormat.Png);
                    else if (Path.GetExtension(hpf.FileName) == ".bmp")
                        imgBytes = ut.ConvertImageToByteArray(image, System.Drawing.Imaging.ImageFormat.Bmp);
                    else if (Path.GetExtension(hpf.FileName) == ".tiff")
                        imgBytes = ut.ConvertImageToByteArray(image, System.Drawing.Imaging.ImageFormat.Tiff);
                    else if (Path.GetExtension(hpf.FileName) == ".gif")
                        imgBytes = ut.ConvertImageToByteArray(image, System.Drawing.Imaging.ImageFormat.Gif);
                }

                

            }

        }
    }
}