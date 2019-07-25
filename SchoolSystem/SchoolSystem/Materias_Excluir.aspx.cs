using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
namespace SchoolSystem
{
    public partial class Materias_Excluir : System.Web.UI.Page
    {

        private Model.Model mdc;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    this.popularFields(int.Parse(Request.QueryString["id"]));
                }
                catch
                {
                    this.popularFields();
                }

            }
        }

        protected void btnExcluir_Click(Object obj, EventArgs e)
        {
            this.onDelete();
        }
        
        private void onDelete()
        {
            mdc = new Model.Model();
            try
            {
            
                Materias_Edit materia = mdc.Materia.First(mat => mat.idMateria == int.Parse(tbCodigo.Text.Trim()));

                mdc.Materia.RowDeleted();

                mdc.AcceptChanges();

                Response.Redirect("Materias.aspx");

            }
            catch (Exception)
            {

            }
            finally
            {
                mdc.Dispose();
            }
        }

        private void popularFields(int pGetID = 0)
        {
            mdc = new Model.Model();
            try
            {
                if (pGetID > 0)
                {

                    Materias_Edit materia = mdc.Materia.First(mat => mat.idMateria == pGetID);

                    tbCodigo.Text = pGetID.ToString();
                    tbNome.Text = materia.tbNome.Text.Trim();
                    tbDescricao.Text = materia.tbDescricao.Text.Trim();

                }
                else
                {
                    Response.Redirect("Materias.aspx");
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                mdc.Dispose();
            }

        }
}