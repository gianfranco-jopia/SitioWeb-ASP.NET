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
using System.Reflection;

namespace Minimarket
{
    public partial class GestionarP : System.Web.UI.Page
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
        protected void LimpiarCasillas()
        {
            TxtCodigo.Text = "";
            TxtDescripcion.Text = "";
            TxtPrecio.Text = "";
            TxtCantidad.Text = "";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void BtnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                ConectarBD();
                if (this.TxtCodigo.Text == "" || this.TxtDescripcion.Text == "" || this.TxtCantidad.Text == "" || this.TxtPrecio.Text == "" || this.CbxTipoP.SelectedIndex == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "campos()", true);
                }
                else if (TxtCodigo.Text.Length <=5)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "camposC()", true);
                }
                else if (TxtDescripcion.Text.Length <= 2)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "camposD()", true);
                }
                else if (TxtPrecio.Text.Length < 3)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "camposP()", true);
                }
                else
                {
                    Tabb = new SqlCommand("Insert Into Producto Values(@Codigo,@Descripcion,@Precio,@Cantidad,@TipoProducto)", Conn);
                    Dadap.InsertCommand = Tabb;
                    Dadap.InsertCommand.Parameters.Add("@Codigo", SqlDbType.Char);
                    Dadap.InsertCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar);
                    Dadap.InsertCommand.Parameters.Add("@Precio", SqlDbType.Int);
                    Dadap.InsertCommand.Parameters.Add("@Cantidad", SqlDbType.Int);
                    Dadap.InsertCommand.Parameters.Add("@TipoProducto", SqlDbType.VarChar);

                    Dadap.InsertCommand.Parameters["@Codigo"].Value = TxtCodigo.Text;
                    Dadap.InsertCommand.Parameters["@Descripcion"].Value = TxtDescripcion.Text;
                    Dadap.InsertCommand.Parameters["@Precio"].Value = TxtPrecio.Text;
                    Dadap.InsertCommand.Parameters["@Cantidad"].Value = TxtCantidad.Text;
                    Dadap.InsertCommand.Parameters["@TipoProducto"].Value = CbxTipoP.SelectedIndex+1;
                    Dadap.InsertCommand.ExecuteNonQuery();
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "Agrego()", true);

                    TxtCodigo.Text = "";
                    TxtDescripcion.Text = "";
                    TxtPrecio.Text = "";
                    TxtCantidad.Text = "";
                }
            }
            catch (Exception RR)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "ErrorA()", true);
            }
        }
        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            ConectarBD();
            if (TxtCodigo.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "campos()", true);
            }
            else
            {
                eliminar(this.TxtCodigo.Text);
                LimpiarCasillas();
                TxtCodigo.Enabled = true;
            }              
        }
        public void eliminar(String codigo)
        {
            Tabb = new SqlCommand("select * from Producto Where Codigo = @Codigo", Conn);
            Tabb.Parameters.AddWithValue("Codigo", codigo);
            Dadap = new SqlDataAdapter(Tabb);
            DataTable dt = new DataTable();
            Dadap.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                Tabb = new SqlCommand("Delete From Producto Where Codigo = @Codigo", Conn);
                Dadap.DeleteCommand = Tabb;
                Dadap.DeleteCommand.Parameters.Add(new SqlParameter("@Codigo", SqlDbType.Char));
                Dadap.DeleteCommand.Parameters["@Codigo"].Value = TxtCodigo.Text;
                Dadap.DeleteCommand.ExecuteNonQuery();
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "AgregoE()", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "ErrorE()", true);
            }
        }
        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                ConectarBD();
                if (this.TxtCodigo.Text == "" || this.TxtDescripcion.Text == "" || this.TxtCantidad.Text == "" || this.TxtPrecio.Text == "" || this.CbxTipoP.SelectedIndex == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "campos()", true);
                }
                else if (TxtCodigo.Text.Length <= 5)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "camposC()", true);
                }
                else if (TxtDescripcion.Text.Length <= 2)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "camposD(", true);
                }
                else if (TxtPrecio.Text.Length < 3)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "camposP()", true);
                }
                else
                {
                    Tabb = new SqlCommand("Update Producto set Descripcion = @Descripcion, Precio = @Precio, Cantidad = @Cantidad, TipoProducto = @TipoProducto Where Codigo=@Codigo", Conn);
                    Dadap.UpdateCommand = Tabb;
                    Dadap.UpdateCommand.Parameters.Add("@Codigo", SqlDbType.Char);
                    Dadap.UpdateCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar);
                    Dadap.UpdateCommand.Parameters.Add("@Precio", SqlDbType.Int);
                    Dadap.UpdateCommand.Parameters.Add("@Cantidad", SqlDbType.Int);
                    Dadap.UpdateCommand.Parameters.Add("@TipoProducto", SqlDbType.VarChar);

                    Dadap.UpdateCommand.Parameters["@Codigo"].Value = TxtCodigo.Text;
                    Dadap.UpdateCommand.Parameters["@Descripcion"].Value = TxtDescripcion.Text;
                    Dadap.UpdateCommand.Parameters["@Precio"].Value = TxtPrecio.Text;
                    Dadap.UpdateCommand.Parameters["@Cantidad"].Value = TxtCantidad.Text;
                    Dadap.UpdateCommand.Parameters["@TipoProducto"].Value = CbxTipoP.SelectedIndex+1;

                    Dadap.UpdateCommand.ExecuteNonQuery();
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "AgregoAc()", true);
                    LimpiarCasillas();
                    TxtCodigo.Enabled = true;
                }
            }
            catch (Exception AA)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "ErrorAc()", true);
            }
        }
        protected void BtnListar_Click(object sender, EventArgs e)
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
                //MessageBox.Show("Desconectado de la base de datos"+ EE.Message, "Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "ErrorL()", true);
            }
        }

        protected void BtnOtroIngreso_Click(object sender, EventArgs e)
        {
            TxtCodigo.Text = "";
            TxtDescripcion.Text = "";
            TxtPrecio.Text = "";
            TxtCantidad.Text = "";
            BtnGrabar.Enabled = true;
        }

        protected void GvListar_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gr = GvListar.SelectedRow;
            TxtCodigo.Text = gr.Cells[1].Text;
            TxtDescripcion.Text = gr.Cells[2].Text;
            TxtPrecio.Text = gr.Cells[3].Text;
            TxtCantidad.Text = gr.Cells[4].Text;
            CbxTipoP.SelectedIndex = int.Parse(gr.Cells[5].Text)-1;
            TxtCodigo.Enabled = false;
        }
    }
}