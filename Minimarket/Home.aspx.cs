using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Minimarket
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void BtnGestionar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionarP.aspx");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            String parametro = Request.Params["parametro"];
            Response.Redirect("BuscarC.aspx?parametro=" + parametro);
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            String parametro = Request.Params["parametro"];
            Response.Redirect("BuscarC.aspx?parametro=" + parametro);
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            String parametro = Request.Params["parametro"];
            Response.Redirect("BuscarC.aspx?parametro=" + parametro);
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            String parametro = Request.Params["parametro"];
            Response.Redirect("BuscarC.aspx?parametro=" + parametro);
        }
    }
}