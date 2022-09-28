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
    public partial class AjustesUsuario : System.Web.UI.Page
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
            
            if (Request.Params["parametro"] == "2")
            {
                BtnAgregar.Visible = true;
                BtnListar.Visible = true;
                CbxTipoU.Visible = true;
            }
            else if (Request.Params["parametro"] == "3")
            {
                BtnAgregar.Visible = false;
                BtnListar.Visible = false;
                CbxTipoU.Visible = false;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                ConectarBD();
                if (TxtRut.Text == "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "campos()", true);
                }
                else
                {
                    eliminar(this.TxtRut.Text);
                    TxtRut.Text = "";
                    TxtNombre.Text = "";
                    TxtApellido.Text = "";
                    TxtContrasena.Text = "";
                }  
            }
            catch (Exception RR)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "ErrorE()", true);
            }
        }
        public void eliminar(String rut)
        {
            Tabb = new SqlCommand("select * from Registrar Where Rut = @Rut", Conn);
            Tabb.Parameters.AddWithValue("Rut", rut);
            Dadap = new SqlDataAdapter(Tabb);
            DataTable dt = new DataTable();
            Dadap.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                if (Request.Params["parametro"] == "2")
                {
                    ConectarBD();
                    Tabb = new SqlCommand("Delete From Registrar Where Rut = @Rut", Conn);
                    Dadap.DeleteCommand = Tabb;
                    Dadap.DeleteCommand.Parameters.Add(new SqlParameter("@Rut", SqlDbType.Char));
                    Dadap.DeleteCommand.Parameters["@Rut"].Value = TxtRut.Text;
                    Dadap.DeleteCommand.ExecuteNonQuery();
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "AgregoE()", true);
                }
                else if (Request.Params["parametro"] == "3")
                {
                    ConectarBD();
                    Tabb = new SqlCommand("Delete From Registrar Where Rut = @Rut", Conn);
                    Dadap.DeleteCommand = Tabb;
                    Dadap.DeleteCommand.Parameters.Add(new SqlParameter("@Rut", SqlDbType.Char));
                    Dadap.DeleteCommand.Parameters["@Rut"].Value = TxtRut.Text;
                    Dadap.DeleteCommand.ExecuteNonQuery();
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "AgregoE()", true);
                    Response.Redirect("homeP.aspx");
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "ErrorE()", true);
            }
        }
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                ConectarBD();
                if (this.TxtRut.Text == "" || this.TxtNombre.Text == "" || this.TxtApellido.Text == "" || this.TxtContrasena.Text == "" || this.CbxTipoU.SelectedIndex == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "campos()", true);
                }
                else if (TxtRut.Text.Length <= 11)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "camposR()", true);
                }
                else if (TxtNombre.Text.Length <= 3)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "camposN()", true);
                }
                else if (TxtApellido.Text.Length <= 3)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "camposA()", true);
                }
                else if (TxtContrasena.Text.Length < 8)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "camposC()", true);
                }
                else
                {
                    string genero = string.Empty;
                    if (RbtMasculino.Checked)
                    {
                        genero = "Masculino";
                        Tabb = new SqlCommand("Update Registrar set Nombre = @Nombre, Apellido = @Apelldio, Genero = @Genero, Contrasena = @Contrasena, TipoUser = @TipoUser Where Rut=@Rut", Conn);
                        Dadap.UpdateCommand = Tabb;
                        Dadap.UpdateCommand.Parameters.Add("@Rut", SqlDbType.Char);
                        Dadap.UpdateCommand.Parameters.Add("@Nombre", SqlDbType.VarChar);
                        Dadap.UpdateCommand.Parameters.Add("@Apelldio", SqlDbType.VarChar);
                        Dadap.UpdateCommand.Parameters.Add("@Genero", SqlDbType.VarChar);
                        Dadap.UpdateCommand.Parameters.Add("@Contrasena", SqlDbType.VarChar);
                        Dadap.UpdateCommand.Parameters.Add("@TipoUser", SqlDbType.Int);

                        Dadap.UpdateCommand.Parameters["@Rut"].Value = TxtRut.Text;
                        Dadap.UpdateCommand.Parameters["@Nombre"].Value = TxtNombre.Text;
                        Dadap.UpdateCommand.Parameters["@Apelldio"].Value = TxtApellido.Text;
                        Dadap.UpdateCommand.Parameters["@Genero"].Value = genero;
                        Dadap.UpdateCommand.Parameters["@Contrasena"].Value = TxtContrasena.Text;
                        Dadap.UpdateCommand.Parameters["@TipoUser"].Value = CbxTipoU.SelectedIndex + 1;
                        Dadap.UpdateCommand.ExecuteNonQuery();
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "AgregoA()", true);
                        TxtRut.Text = "";
                        TxtNombre.Text = "";
                        TxtApellido.Text = "";
                        TxtContrasena.Text = "";
                    }
                    else if (RbtFemenino.Checked)
                    {
                        genero = "Femenino";
                        Tabb = new SqlCommand("Update Registrar set Nombre = @Nombre, Apellido = @Apelldio, Genero = @Genero, Contrasena = @Contrasena, TipoUser = @TipoUser Where Rut=@Rut", Conn);
                        Dadap.UpdateCommand = Tabb;
                        Dadap.UpdateCommand.Parameters.Add("@Rut", SqlDbType.Char);
                        Dadap.UpdateCommand.Parameters.Add("@Nombre", SqlDbType.VarChar);
                        Dadap.UpdateCommand.Parameters.Add("@Apelldio", SqlDbType.VarChar);
                        Dadap.UpdateCommand.Parameters.Add("@Genero", SqlDbType.VarChar);
                        Dadap.UpdateCommand.Parameters.Add("@Contrasena", SqlDbType.VarChar);
                        Dadap.UpdateCommand.Parameters.Add("@TipoUser", SqlDbType.Int);

                        Dadap.UpdateCommand.Parameters["@Rut"].Value = TxtRut.Text;
                        Dadap.UpdateCommand.Parameters["@Nombre"].Value = TxtNombre.Text;
                        Dadap.UpdateCommand.Parameters["@Apelldio"].Value = TxtApellido.Text;
                        Dadap.UpdateCommand.Parameters["@Genero"].Value = genero;
                        Dadap.UpdateCommand.Parameters["@Contrasena"].Value = TxtContrasena.Text;
                        Dadap.UpdateCommand.Parameters["@TipoUser"].Value = CbxTipoU.SelectedIndex + 1;
                        Dadap.UpdateCommand.ExecuteNonQuery();
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "AgregoA()", true);
                        TxtRut.Text = "";
                        TxtNombre.Text = "";
                        TxtApellido.Text = "";
                        TxtContrasena.Text = "";
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "camposG()", true);
                    }
                }
            }
            catch (Exception EE)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "ErrorAc()", true);
            }
        }

        public bool validarRut(string rut)
        {
            bool validacion = false;
            try
            {
                rut = rut.ToUpper();
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));

                char dv = char.Parse(rut.Substring(rut.Length - 1, 1));

                int m = 0, s = 1;
                for (; rutAux != 0; rutAux /= 10)
                {
                    s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                }
                if (dv == (char)(s != 0 ? s + 47 : 75))
                {
                    validacion = true;
                }
            }
            catch (Exception)
            {
            }
            return validacion;
        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                ConectarBD();
                if (this.TxtRut.Text == "" || this.TxtNombre.Text == "" || this.TxtApellido.Text == "" || this.TxtContrasena.Text == "" || this.CbxTipoU.SelectedIndex == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "campos()", true);
                }
                else if (TxtRut.Text.Length <= 11)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "camposR()", true);
                }
                else if (TxtNombre.Text.Length <= 3)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "camposN()", true);
                }
                else if (TxtApellido.Text.Length <= 3)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "camposA()", true);
                }
                else if (TxtContrasena.Text.Length < 8)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "camposC()", true);
                }
                else
                {
                    bool respuesta = validarRut(TxtRut.Text);
                    if (respuesta == true)
                    {
                        string genero = string.Empty;
                        if (RbtMasculino.Checked)
                        {
                            genero = "Masculino";
                            ConectarBD();
                            Tabb = new SqlCommand("Insert Into Registrar Values(@Rut,@Nombre,@Apellido,@Genero,@Contrasena,@TipoUser)", Conn);
                            Dadap.InsertCommand = Tabb;
                            Dadap.InsertCommand.Parameters.Add("@Rut", SqlDbType.Char);
                            Dadap.InsertCommand.Parameters.Add("@Nombre", SqlDbType.VarChar);
                            Dadap.InsertCommand.Parameters.Add("@Apellido", SqlDbType.VarChar);
                            Dadap.InsertCommand.Parameters.Add("@Genero", SqlDbType.VarChar);
                            Dadap.InsertCommand.Parameters.Add("@Contrasena", SqlDbType.VarChar);
                            Dadap.InsertCommand.Parameters.Add("@TipoUser", SqlDbType.VarChar);

                            Dadap.InsertCommand.Parameters["@Rut"].Value = TxtRut.Text;
                            Dadap.InsertCommand.Parameters["@Nombre"].Value = TxtNombre.Text;
                            Dadap.InsertCommand.Parameters["@Apellido"].Value = TxtApellido.Text;
                            Dadap.InsertCommand.Parameters["@Genero"].Value = genero;
                            Dadap.InsertCommand.Parameters["@Contrasena"].Value = TxtContrasena.Text;
                            Dadap.InsertCommand.Parameters["@TipoUser"].Value = CbxTipoU.SelectedIndex + 1;
                            Dadap.InsertCommand.ExecuteNonQuery();
                            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "Agrego()", true);
                            TxtRut.Text = "";
                            TxtNombre.Text = "";
                            TxtApellido.Text = "";
                            TxtContrasena.Text = "";
                        }
                        else if (RbtFemenino.Checked)
                        {
                            genero = "Femenino";
                            ConectarBD();
                            Tabb = new SqlCommand("Insert Into Registrar Values(@Rut,@Nombre,@Apellido,@Genero,@Contrasena,@TipoUser)", Conn);
                            Dadap.InsertCommand = Tabb;
                            Dadap.InsertCommand.Parameters.Add("@Rut", SqlDbType.Char);
                            Dadap.InsertCommand.Parameters.Add("@Nombre", SqlDbType.VarChar);
                            Dadap.InsertCommand.Parameters.Add("@Apellido", SqlDbType.VarChar);
                            Dadap.InsertCommand.Parameters.Add("@Genero", SqlDbType.VarChar);
                            Dadap.InsertCommand.Parameters.Add("@Contrasena", SqlDbType.VarChar);
                            Dadap.InsertCommand.Parameters.Add("@TipoUser", SqlDbType.VarChar);

                            Dadap.InsertCommand.Parameters["@Rut"].Value = TxtRut.Text;
                            Dadap.InsertCommand.Parameters["@Nombre"].Value = TxtNombre.Text;
                            Dadap.InsertCommand.Parameters["@Apellido"].Value = TxtApellido.Text;
                            Dadap.InsertCommand.Parameters["@Genero"].Value = genero;
                            Dadap.InsertCommand.Parameters["@Contrasena"].Value = TxtContrasena.Text;
                            Dadap.InsertCommand.Parameters["@TipoUser"].Value = CbxTipoU.SelectedIndex + 1;
                            Dadap.InsertCommand.ExecuteNonQuery();
                            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "Agrego()", true);
                            TxtRut.Text = "";
                            TxtNombre.Text = "";
                            TxtApellido.Text = "";
                            TxtContrasena.Text = "";
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "camposG()", true);
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "rut()", true);
                    }
                }
            }
            catch (Exception RR)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "ErrorA()", true);
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
                Dadap = new SqlDataAdapter("select * from Registrar", Conn);
                DataTable dt = new DataTable();
                Dadap.Fill(dt);
                this.GvListar.DataSource = dt;
                GvListar.DataBind();
            }
            catch (Exception EE)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "ErrorL()", true);
            }
        }

        protected void GvListar_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gr = GvListar.SelectedRow;
            TxtRut.Text = gr.Cells[1].Text;
            TxtNombre.Text = gr.Cells[2].Text;
            TxtApellido.Text = gr.Cells[3].Text;
            TxtContrasena.Text = gr.Cells[5].Text;
            CbxTipoU.SelectedIndex = int.Parse(gr.Cells[6].Text)-1;
        }
    }
}