using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
namespace SchoolSystem
{
    public partial class Materias_Edit : System.Web.UI.Page
    {

        private Model.Model mdc;
        private DateTime dataAtualizacao;

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

        protected void bntAtualizar_Click(object sender, EventArgs e)
        {
            this.onUpdate();
        }

        private void onUpdate()
        {
            mdc = new Model.Model();
            try
            {

                Materias_Edit materia = mdc.Materia.First(mat => mat.idMateria == int.Parse(tbCodMateria.Text.Trim()));

                tbNome.Text = materia.tbNome.Text.Trim();
                tbDescricao.Text = materia.tbDescricao.Text.Trim();
                materia.dataAtualizacao = DateTime.Parse(DateTime.Now.ToShortDateString());

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

                    tbCodMateria.Text = pGetID.ToString();
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
}