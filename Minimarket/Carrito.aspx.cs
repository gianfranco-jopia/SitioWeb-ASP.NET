using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Minimarket
{
    public partial class Carrito : System.Web.UI.Page
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
            DateTime Fecha = DateTime.Today;
            TxtFecha.Text = Fecha.Date.Day.ToString() + "/" + "0" + Fecha.Date.Month.ToString() + "/" + Fecha.Date.Year.ToString();
            TxtFecha.Visible = false;
            if (!IsPostBack)
            {
                listar();
                MontoTotal();
            }
        }
        public void listar()
        {
            try
            {
                ConectarBD();
                Dadap = new SqlDataAdapter("Select Codigo,Descripcion,Precio,Cantidad,PrecioTotal,TipoProducto from Carrito;", Conn);
                DataTable dt = new DataTable();
                Dadap.Fill(dt);
                this.GvListar.DataSource = dt;
                GvListar.DataBind();
            }
            catch (Exception EE)
            {
                //MessageBox.Show("Desconectado de la base de datos", "Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        public void MontoTotal()
        {
            ConectarBD();
            Tabb = new SqlCommand("Select SUM(PrecioTotal) as TotalP from Carrito;", Conn);
            SqlDataReader registro = Tabb.ExecuteReader();
            if (registro.Read())
            {
                TotalP.Text = registro["TotalP"].ToString();
            }
        }

        protected void GvListar_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GvListar.EditIndex = -1;
            listar();
            MontoTotal();
        }

        protected void GvListar_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                ConectarBD();
                Tabb = new SqlCommand("Delete From Carrito Where Codigo=@Codigo;", Conn);
                Dadap.DeleteCommand = Tabb;
                Dadap.DeleteCommand.Parameters.Add(new SqlParameter("@Codigo", SqlDbType.Int));
                Dadap.DeleteCommand.Parameters["@Codigo"].Value = Convert.ToInt32(GvListar.DataKeys[e.RowIndex].Value.ToString());
                Dadap.DeleteCommand.ExecuteNonQuery();
                GvListar.EditIndex = -1;
                listar();
                MontoTotal();
            }
            catch (Exception EE)
            {
                //MessageBox.Show("No se pudo eliminar producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected void GvListar_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GvListar.EditIndex = e.NewEditIndex;
            listar();
            MontoTotal();
        }

        protected void GvListar_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                ConectarBD();
                Tabb = new SqlCommand("Select Producto.Cantidad from Producto,Carrito where Carrito.Descripcion=@Descripcion and Producto.Descripcion=@Descripcion and Producto.Cantidad >= @Cantidad;", Conn);
                Tabb.Parameters.AddWithValue("Descripcion", (GvListar.Rows[e.RowIndex].FindControl("TxtDescripcion") as TextBox).Text);
                Tabb.Parameters.AddWithValue("Cantidad", (GvListar.Rows[e.RowIndex].FindControl("TxtCantidad") as TextBox).Text);
                Dadap = new SqlDataAdapter(Tabb);
                DataTable dt = new DataTable();
                Dadap.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    if (int.Parse((GvListar.Rows[e.RowIndex].FindControl("TxtCantidad") as TextBox).Text) >=1)
                    {
                        Tabb = new SqlCommand("Update Carrito set Descripcion = @Descripcion, Precio = @Precio, Cantidad = @Cantidad, PrecioTotal = @PrecioTotal, TipoProducto = @TipoProducto Where Codigo=@Codigo", Conn);
                        Dadap.UpdateCommand = Tabb;
                        Dadap.UpdateCommand.Parameters.Add("@Codigo", SqlDbType.Int);
                        Dadap.UpdateCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar);
                        Dadap.UpdateCommand.Parameters.Add("@Precio", SqlDbType.Int);
                        Dadap.UpdateCommand.Parameters.Add("@Cantidad", SqlDbType.Int);
                        Dadap.UpdateCommand.Parameters.Add("@PrecioTotal", SqlDbType.Int);
                        Dadap.UpdateCommand.Parameters.Add("@TipoProducto", SqlDbType.Int);

                        Dadap.UpdateCommand.Parameters["@Codigo"].Value = Convert.ToInt32(GvListar.DataKeys[e.RowIndex].Value.ToString());
                        Dadap.UpdateCommand.Parameters["@Descripcion"].Value = (GvListar.Rows[e.RowIndex].FindControl("TxtDescripcion") as TextBox).Text.Trim();
                        Dadap.UpdateCommand.Parameters["@Precio"].Value = (GvListar.Rows[e.RowIndex].FindControl("TxtPrecio") as TextBox).Text.Trim();
                        Dadap.UpdateCommand.Parameters["@Cantidad"].Value = (GvListar.Rows[e.RowIndex].FindControl("TxtCantidad") as TextBox).Text.Trim();
                        Dadap.UpdateCommand.Parameters["@PrecioTotal"].Value = (int.Parse((GvListar.Rows[e.RowIndex].FindControl("TxtPrecio") as TextBox).Text.Trim()) * int.Parse((GvListar.Rows[e.RowIndex].FindControl("TxtCantidad") as TextBox).Text.Trim()));
                        Dadap.UpdateCommand.Parameters["@TipoProducto"].Value = (GvListar.Rows[e.RowIndex].FindControl("TxtTipoProducto") as TextBox).Text.Trim();

                        Dadap.UpdateCommand.ExecuteNonQuery();
                        GvListar.EditIndex = -1;
                        listar();
                        MontoTotal();
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "campos()", true);
                }
            }
            catch (Exception EE)
            {
                //MessageBox.Show("No se pudo modificar la cantidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected void BtnComprar_Click(object sender, EventArgs e)
        {
            ConectarBD();
            Tabb = new SqlCommand("select * from carrito;", Conn);
            Dadap = new SqlDataAdapter(Tabb);
            DataTable dt = new DataTable();
            Dadap.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                String parametro = Request.Params["parametro"];
                Response.Redirect("RealizarCompra.aspx?parametro="+parametro);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "carro()", true);
            }
        }
    }
}
