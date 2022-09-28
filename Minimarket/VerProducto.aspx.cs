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

namespace Minimarket
{
    public partial class VerProducto : System.Web.UI.Page
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
            listar(); 
        }

        public void listar()
        {
            try
            {
                ConectarBD();
                Dadap = new SqlDataAdapter("select * from Producto;", Conn);
                DataTable dt = new DataTable();
                Dadap.Fill(dt);
                this.GvListar.DataSource = dt;
                GvListar.DataBind();
            }
            catch (Exception EE)
            {
                MessageBox.Show("Desconectado de la base de datos", "Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        protected void GvListar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow gr = GvListar.SelectedRow;
                ConectarBD();

                Tabb = new SqlCommand("Select Descripcion from Carrito where Descripcion = @Descripcion", Conn);
                Tabb.Parameters.AddWithValue("Descripcion", gr.Cells[0].Text);
                Dadap = new SqlDataAdapter(Tabb);
                DataTable dt = new DataTable();
                Dadap.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "campos()", true);
                }
                else
                {
                    Tabb = new SqlCommand("Select Cantidad from Producto where Descripcion=@Descripcion", Conn);
                    Tabb.Parameters.AddWithValue("Descripcion", gr.Cells[0].Text);
                    Dadap = new SqlDataAdapter(Tabb);
                    dt = new DataTable();
                    Dadap.Fill(dt);
                    if (dt.Rows.Count == 1)
                    {
                        if (dt.Rows[0][0].ToString() == "0")
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "advertencia()", true);
                        }
                        else
                        {
                            Tabb = new SqlCommand("Insert Into Carrito Values(@Descripcion,@Precio,@Cantidad,@PrecioTotal,@TipoProducto)", Conn);
                            Dadap.InsertCommand = Tabb;
                            Dadap.InsertCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar);
                            Dadap.InsertCommand.Parameters.Add("@Precio", SqlDbType.Int);
                            Dadap.InsertCommand.Parameters.Add("@Cantidad", SqlDbType.Int);
                            Dadap.InsertCommand.Parameters.Add("@PrecioTotal", SqlDbType.Int);
                            Dadap.InsertCommand.Parameters.Add("@TipoProducto", SqlDbType.Int);

                            Dadap.InsertCommand.Parameters["@Descripcion"].Value = gr.Cells[0].Text;
                            Dadap.InsertCommand.Parameters["@Precio"].Value = gr.Cells[1].Text;
                            Dadap.InsertCommand.Parameters["@Cantidad"].Value = 1;
                            Dadap.InsertCommand.Parameters["@PrecioTotal"].Value = (int.Parse(gr.Cells[1].Text) * 1);
                            Dadap.InsertCommand.Parameters["@TipoProducto"].Value = gr.Cells[3].Text;
                            Dadap.InsertCommand.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "advertencia()", true);
                    }
                }
            }
            catch (Exception EE)
            {
                MessageBox.Show("Error al agregar" + EE.Message);
            }
        }
    }
}