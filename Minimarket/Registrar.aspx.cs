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
    public partial class Registrar : System.Web.UI.Page
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
            btnConectar.Visible = false;
            btnDesconectar.Visible = false;
        }

        protected void btnConectar_Click(object sender, EventArgs e)
        {
            ConectarBD();
            MessageBox.Show("Conectado", "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnConectar.Enabled = false;
            btnDesconectar.Enabled = true;
            TxtRut.Enabled = true;
            TxtNombre.Enabled = true;
            TxtApellido.Enabled = true;
            TxtContrasena.Enabled = true;
            TxtRut.Focus();
            btnDesconectar.BackColor = System.Drawing.Color.Blue;
            btnConectar.BackColor = System.Drawing.Color.Gray;
        }

        protected void btnDesconectar_Click(object sender, EventArgs e)
        {
            DesconectarBD();
            MessageBox.Show("Desconetado", "Base de datos", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            btnConectar.Enabled = true;
            btnDesconectar.Enabled = false;
            TxtRut.Enabled = false;
            TxtNombre.Enabled = false;
            TxtApellido.Enabled = false;
            TxtContrasena.Enabled = false;
            btnDesconectar.BackColor =  System.Drawing.Color.Gray;
            btnConectar.BackColor = System.Drawing.Color.Blue;
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

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                ConectarBD();
                if (this.TxtRut.Text == "" || this.TxtNombre.Text == "" || this.TxtApellido.Text == "" || this.TxtContrasena.Text == "")
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
                else if(CheckBoxConfirma.Checked == true)
                {
                    bool respuesta=validarRut(TxtRut.Text);
                    if (respuesta==true)
                    {
                        string genero = string.Empty;
                        if (RbtMasculino.Checked)
                        {
                            genero = "Masculino";
                            Tabb = new SqlCommand("Insert Into Registrar Values(@Rut,@Nombre,@Apellido,@Genero,@Contrasena,@TipoUser);", Conn);
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
                            Dadap.InsertCommand.Parameters["@TipoUser"].Value = 3;
                            Dadap.InsertCommand.ExecuteNonQuery();

                            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "Agrego()", true);
                            LimpiarCasillas();
                            SoltarDatos();
                            Response.Redirect("Login.aspx");
                        }
                        else if (RbtFemenino.Checked)
                        {
                            genero = "Femenino";
                            Tabb = new SqlCommand("Insert Into Registrar Values(@Rut,@Nombre,@Apellido,@Genero,@Contrasena,@TipoUser);", Conn);
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
                            Dadap.InsertCommand.Parameters["@TipoUser"].Value = 3;
                            Dadap.InsertCommand.ExecuteNonQuery();

                            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "Agrego()", true);
                            LimpiarCasillas();
                            SoltarDatos();
                            Response.Redirect("Login.aspx");
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
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "camposConfirmar()", true);
                }         
            }
            catch (Exception RR)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "Error()", true);
            }
        }
        protected void LimpiarCasillas()
        {
            TxtRut.Text = "";
            TxtNombre.Text = "";
            TxtApellido.Text = "";
            TxtContrasena.Text = "";      
        }

        protected void SoltarDatos()
        {
            Dset.Clear();
            Dset.Dispose();
        }
    }
}