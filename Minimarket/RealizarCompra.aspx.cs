using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Minimarket
{
    public partial class RealizarCompra : System.Web.UI.Page
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
        }

        public DataTable MostrarVenta()
        {
            ConectarBD();
            SqlDataAdapter da = new SqlDataAdapter("Select Carrito.Codigo,Carrito.Descripcion,Carrito.Precio,Carrito.Cantidad,TipoP.Descripcion from Carrito,TipoP where Carrito.TipoProducto = TipoP.Codigo;", Conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            SqlCommand com = new SqlCommand();
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "Carrito";
            da.Dispose();
            return dt;
        }

        protected void btnComprar_Click(object sender, EventArgs e)
        {
            if (CbxTipoP.SelectedIndex == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "campos()", true);
            }
            else if(CbxTipoP.SelectedIndex == 1)
            {
                if (CbxTipoB.SelectedIndex==0 || TxtRut.Text=="")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "camposS()", true);
                }
                else
                {
                    DataTable dt = new DataTable();
                    Document document = new Document();
                    PdfWriter writer = PdfWriter.GetInstance(document, HttpContext.Current.Response.OutputStream);
                    dt = MostrarVenta();
                    if (dt.Rows.Count > 0)
                    {
                        document.Open();
                        String fecha = TxtFecha.Text;

                        Font fontTitle = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 25);
                        Font fontSub = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
                        Font font9 = FontFactory.GetFont(FontFactory.TIMES, 9);

                        PdfPTable table = new PdfPTable(dt.Columns.Count);

                        document.Add(new Paragraph(10, "Minimarket", fontTitle));
                        document.Add(new Chunk("\n"));
                        document.Add(new Paragraph(10, "Fecha de compra:" + fecha, fontSub));
                        document.Add(new Chunk("\n"));
                        document.Add(new Paragraph(10, "Correo: contactominimarket@gmail.com", fontSub));
                        document.Add(new Chunk("\n"));
                        document.Add(new Paragraph(10, "Contacto: +569 81735101", fontSub));
                        document.Add(new Chunk("\n"));
                        document.Add(new Paragraph(10, "Estableciminto: Av.San Carlos, 787-829 Comuna de Puente Alto, Santiago", fontSub));
                        document.Add(new Chunk("\n"));
                        document.Add(new Paragraph(10, "Region: Metropolitana", fontSub));
                        document.Add(new Chunk("\n"));
                        document.Add(new Chunk("\n"));


                        float[] widths = new float[dt.Columns.Count];
                        for (int i = 0; i < dt.Columns.Count; i++)
                            widths[i] = 4f;

                        table.SetWidths(widths);
                        table.WidthPercentage = 90;

                        PdfPCell cell = new PdfPCell(new Phrase("columns"));
                        cell.Colspan = dt.Columns.Count;

                        foreach (DataColumn c in dt.Columns)
                        {
                            table.AddCell(new Phrase(c.ColumnName, font9));
                        }

                        foreach (DataRow r in dt.Rows)
                        {
                            if (dt.Rows.Count > 0)
                            {
                                for (int h = 0; h < dt.Columns.Count; h++)
                                {
                                    table.AddCell(new Phrase(r[h].ToString(), font9));
                                }
                            }
                        }
                        document.Add(table);

                        document.Add(new Chunk("\n"));
                        document.Add(new Chunk("\n"));
                        document.Add(new Chunk("\n"));

                        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("C:/Users/Gambito/source/repos/Minimarket/Minimarket/img/CodigoBR.png");
                        img.ScaleAbsoluteWidth(200);
                        img.ScaleAbsoluteHeight(100);
                        img.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
                        document.Add(img);
                    }
                    document.Close();

                    ConectarBD();
                    Tabb = new SqlCommand("Insert into Historial(Codigo,Descripcion,Precio,Cantidad,TipoProducto) select Codigo,Descripcion,Precio,Cantidad,TipoProducto from Carrito;", Conn);
                    Dadap.InsertCommand = Tabb;
                    Dadap.InsertCommand.ExecuteNonQuery();

                    Tabb = new SqlCommand("Update Historial set Rut=@Rut where Cantidad>=0;", Conn);
                    Dadap.UpdateCommand = Tabb;
                    Dadap.UpdateCommand.Parameters.Add("@Rut", SqlDbType.Char);
                    Dadap.UpdateCommand.Parameters["@Rut"].Value = TxtRut.Text;
                    Dadap.UpdateCommand.ExecuteNonQuery();

                    Tabb = new SqlCommand("Update Producto set Producto.Cantidad=(Producto.Cantidad - Carrito.Cantidad) from Producto,Carrito where Producto.Descripcion=Carrito.Descripcion;", Conn);
                    Dadap.UpdateCommand = Tabb;
                    Dadap.UpdateCommand.ExecuteNonQuery();

                    Tabb = new SqlCommand("Delete From Carrito;", Conn);
                    Dadap.DeleteCommand = Tabb;
                    Dadap.DeleteCommand.ExecuteNonQuery();

                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=Boleta" + ".pdf");
                    HttpContext.Current.Response.Write(document);
                    Response.Flush();
                    Response.End();
                }
            }else if (CbxTipoP.SelectedIndex == 2)
            {
                if (TxtNumT.Text==""|| TxtFechaV.Text==""|| TxtCodigoS.Text=="")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "camposS()", true);
                }
                else
                {
                    DataTable dt = new DataTable();
                    Document document = new Document();
                    PdfWriter writer = PdfWriter.GetInstance(document, HttpContext.Current.Response.OutputStream);
                    dt = MostrarVenta();
                    if (dt.Rows.Count > 0)
                    {
                        document.Open();
                        String fecha = TxtFecha.Text;

                        Font fontTitle = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 25);
                        Font fontSub = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
                        Font font9 = FontFactory.GetFont(FontFactory.TIMES, 9);

                        PdfPTable table = new PdfPTable(dt.Columns.Count);

                        document.Add(new Paragraph(10, "Minimarket", fontTitle));
                        document.Add(new Chunk("\n"));
                        document.Add(new Paragraph(10, "Fecha de compra:" + fecha, fontSub));
                        document.Add(new Chunk("\n"));
                        document.Add(new Paragraph(10, "Correo: contactominimarket@gmail.com", fontSub));
                        document.Add(new Chunk("\n"));
                        document.Add(new Paragraph(10, "Contacto: +569 81735101", fontSub));
                        document.Add(new Chunk("\n"));
                        document.Add(new Paragraph(10, "Estableciminto: Av.San Carlos, 787-829 Comuna de Puente Alto, Santiago", fontSub));
                        document.Add(new Chunk("\n"));
                        document.Add(new Paragraph(10, "Region: Metropolitana", fontSub));
                        document.Add(new Chunk("\n"));
                        document.Add(new Chunk("\n"));


                        float[] widths = new float[dt.Columns.Count];
                        for (int i = 0; i < dt.Columns.Count; i++)
                            widths[i] = 4f;

                        table.SetWidths(widths);
                        table.WidthPercentage = 90;

                        PdfPCell cell = new PdfPCell(new Phrase("columns"));
                        cell.Colspan = dt.Columns.Count;

                        foreach (DataColumn c in dt.Columns)
                        {
                            table.AddCell(new Phrase(c.ColumnName, font9));
                        }

                        foreach (DataRow r in dt.Rows)
                        {
                            if (dt.Rows.Count > 0)
                            {
                                for (int h = 0; h < dt.Columns.Count; h++)
                                {
                                    table.AddCell(new Phrase(r[h].ToString(), font9));
                                }
                            }
                        }
                        document.Add(table);

                        document.Add(new Chunk("\n"));
                        document.Add(new Chunk("\n"));
                        document.Add(new Chunk("\n"));

                        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("C:/Users/Gambito/source/repos/Minimarket/Minimarket/img/CodigoBR.png");
                        img.ScaleAbsoluteWidth(200);
                        img.ScaleAbsoluteHeight(100);
                        img.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
                        document.Add(img);
                    }
                    document.Close();

                    ConectarBD();
                    Tabb = new SqlCommand("Insert into Historial(Codigo,Descripcion,Precio,Cantidad,TipoProducto) select Codigo,Descripcion,Precio,Cantidad,TipoProducto from Carrito;", Conn);
                    Dadap.InsertCommand = Tabb;
                    Dadap.InsertCommand.ExecuteNonQuery();

                    Tabb = new SqlCommand("Update Historial set Rut=@Rut where Cantidad>=0;", Conn);
                    Dadap.UpdateCommand = Tabb;
                    Dadap.UpdateCommand.Parameters.Add("@Rut", SqlDbType.Char);
                    Dadap.UpdateCommand.Parameters["@Rut"].Value = TxtRut1.Text;
                    Dadap.UpdateCommand.ExecuteNonQuery();

                    Tabb = new SqlCommand("Update Producto set Producto.Cantidad=(Producto.Cantidad - Carrito.Cantidad) from Producto,Carrito where Producto.Descripcion=Carrito.Descripcion;", Conn);
                    Dadap.UpdateCommand = Tabb;
                    Dadap.UpdateCommand.ExecuteNonQuery();

                    Tabb = new SqlCommand("Delete From Carrito;", Conn);
                    Dadap.DeleteCommand = Tabb;
                    Dadap.DeleteCommand.ExecuteNonQuery();

                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=Boleta" + ".pdf");
                    HttpContext.Current.Response.Write(document);
                    Response.Flush();
                    Response.End();
                }
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            CbxTipoP.SelectedIndex = 1;
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            CbxTipoP.SelectedIndex = 2;
        }
    }
}