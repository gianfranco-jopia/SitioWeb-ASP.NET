using System.Net;
using System.Net.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Minimarket
{
    public partial class Contactanos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Autores_Click(object sender, EventArgs e)
        {
            String parametro = Request.Params["parametro"];
            Response.Redirect("Autores.aspx?parametro=" + parametro);
        }

        protected void BtnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(TextFrom.Text);
                msg.To.Add(TextTo.Text);
                msg.Subject = TextSubjet.Text;
                msg.Body = TextMessage.Text;
                MailAddress ms = new MailAddress(TexCopy.Text);
                msg.CC.Add(ms);
                SmtpClient sc = new SmtpClient("smtp.gmail.com");
                sc.Port = 25;
                sc.Credentials = new NetworkCredential(TextFrom.Text, TextPass.Text);
                sc.EnableSsl = true;
                sc.Send(msg);
                Response.Write("Correo Enviado Exitosamente");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}