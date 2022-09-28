using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Minimarket
{
    public partial class menu : System.Web.UI.MasterPage
    {
        public SqlConnection Conn = new SqlConnection();
        public SqlCommand Tabb = new SqlCommand();
        public SqlDataAdapter Dadap = new SqlDataAdapter();
        public DataSet Dset = new DataSet();

        protected void ConectarBD()
        {
            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConectionBD"].ConnectionString);
            Conn.Open();
        }

        protected void DesconectarBD()
        {
            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConectionBD"].ConnectionString);
            Conn.Close();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["parametro"] == null) return;
                if (Request.Params["parametro"] == "2")
                {
                    GestionarP.Visible = true;
                }
                else if (Request.Params["parametro"] == "3")
                {
                    GestionarP.Visible = false;
                }
            }
        }
        protected void AjustesU_Click(object sender, EventArgs e)
        {
            String parametro = Request.Params["parametro"];
            Response.Redirect("AjustesUsuario.aspx?parametro="+parametro);
        }

        protected void GestionarP_Click(object sender, EventArgs e)
        {
            String parametro = Request.Params["parametro"];
            Response.Redirect("GestionarP.aspx?parametro=" + parametro);
        }

        protected void Home_Click(object sender, EventArgs e)
        {
            String parametro = Request.Params["parametro"];
            Response.Redirect("home.aspx?parametro=" + parametro);
        }

        protected void Carniceria_Click(object sender, EventArgs e)
        {
            String parametro = Request.Params["parametro"];
            Response.Redirect("Carniceria.aspx?parametro=" + parametro);
        }

        protected void Despensa_Click(object sender, EventArgs e)
        {
            String parametro = Request.Params["parametro"];
            Response.Redirect("Despensa.aspx?parametro=" + parametro);
        }

        protected void Panaderia_Click(object sender, EventArgs e)
        {
            String parametro = Request.Params["parametro"];
            Response.Redirect("Panaderia.aspx?parametro=" + parametro);
        }

        protected void Botilleria_Click(object sender, EventArgs e)
        {
            String parametro = Request.Params["parametro"];
            Response.Redirect("Botilleria.aspx?parametro=" + parametro);
        }

        protected void BuscarP_Click(object sender, EventArgs e)
        {
            String parametro = Request.Params["parametro"];
            Response.Redirect("Producto.aspx?parametro=" + parametro);
        }

        protected void NuestrosP_Click(object sender, EventArgs e)
        {
            String parametro = Request.Params["parametro"];
            Response.Redirect("NuestrosProveedores.aspx?parametro=" + parametro);
        }

        protected void Contactenos_Click(object sender, EventArgs e)
        {
            String parametro = Request.Params["parametro"];
            Response.Redirect("Contactanos.aspx?parametro=" + parametro);
        }

        protected void Carrito_Click(object sender, EventArgs e)
        {
            String parametro = Request.Params["parametro"];
            Response.Redirect("Carrito.aspx?parametro=" + parametro);
        }

        protected void CerrarS_Click(object sender, EventArgs e)
        {
            ConectarBD();
            Tabb = new SqlCommand("Delete From Carrito;", Conn);
            Dadap.DeleteCommand = Tabb;
            Dadap.DeleteCommand.ExecuteNonQuery();
            Response.Redirect("Login.aspx");
        }

        protected void BuscarC_Click(object sender, EventArgs e)
        {
            String parametro = Request.Params["parametro"];
            Response.Redirect("BuscarC.aspx?parametro=" + parametro);
        }

        protected void VerProducto_Click(object sender, EventArgs e)
        {
            String parametro = Request.Params["parametro"];
            Response.Redirect("VerProducto.aspx?parametro=" + parametro);
        }

        protected void Quienes_Click(object sender, EventArgs e)
        {
            String parametro = Request.Params["parametro"];
            Response.Redirect("Autores.aspx?parametro=" + parametro);
        }
    }
}