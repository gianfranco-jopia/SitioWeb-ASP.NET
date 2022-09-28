using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Drawing;
using System.Windows.Forms.VisualStyles;
using System.Web.Configuration;
using System.Web.Services.Protocols;

namespace Minimarket
{
    public partial class Login : System.Web.UI.Page
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
        }

        public void logear(string rut, string contrasena)
        {
            ConectarBD();
            if(txtUsuario.Text=="" || txtContrasena.Text=="" || CbxTipoU.SelectedIndex==0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "campos()", true);
            }
            else{
                Tabb = new SqlCommand("select Rut, tipoUser from Registrar where Rut = @rut and Contrasena = @Contrasena and TipoUser = @TipoUser ", Conn);
                Tabb.Parameters.AddWithValue("Rut", rut);
                Tabb.Parameters.AddWithValue("Contrasena", contrasena);
                Tabb.Parameters.AddWithValue("TipoUser", CbxTipoU.SelectedIndex+1);
                Dadap = new SqlDataAdapter(Tabb);
                DataTable dt = new DataTable();
                Dadap.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    if (dt.Rows[0][1].ToString() == "2")
                    { 
                        Response.Redirect("home.aspx?parametro="+dt.Rows[0][1].ToString());
                    }
                    else if (dt.Rows[0][1].ToString() == "3")
                    {
                        Response.Redirect("home.aspx?parametro="+dt.Rows[0][1].ToString());
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(),"randomtext","error()",true);
                }
            } 
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            logear(this.txtUsuario.Text, this.txtContrasena.Text);
        }
    }
}