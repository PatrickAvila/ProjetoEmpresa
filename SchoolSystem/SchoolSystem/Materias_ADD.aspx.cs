using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;


namespace SchoolSystem
{
    public partial class Materias_ADD : System.Web.UI.Page
    {

       private Model.Model mdc;
      

        protected void Page_Load(object sender, EventArgs e)
        {
            tbDataCadrastro.Text = DateTime.Now.ToShortDateString();
        }


        protected void btnCadastrar_Click(object obj, EventArgs e)
        {
            this.onInsert();
        }


        private void onInsert()
        {
            mdc = new Model.Model();
            try
            {
                Materias_ADD materia = new Materias_ADD();

                materia.tbNome.Text = materia.tbNome.Text.Trim();
                materia.tbDescricao.Text = materia.tbDescricao.Text.Trim();
                materia.tbDataCadrastro.Text = materia.tbDataCadrastro.Text.Trim();
                Convert.ToDateTime(tbDataCadrastro);

                InsertOnSubmit(materia);

                mdc.change();

                Response.Redirect("Materias.aspx");


            }
            catch (Exception)
            {

                Response.Redirect("Materias.aspx");
            }
            finally
            {

                mdc.Dispose();
            }

        }

        private void InsertOnSubmit(Materias_ADD materia)
        {
            throw new NotImplementedException();
        }
    }
}