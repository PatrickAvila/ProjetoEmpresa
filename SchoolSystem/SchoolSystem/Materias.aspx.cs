using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;

namespace SchoolSystem
{
    public partial class Default : System.Web.UI.Page
    {
        private Model.Model mdc;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.popularGrid();
            } 
        }

        private void popularGrid()
        {
            mdc = new Model.Model();
            try
            {
                var sourceMateria = from mat in mdc.Materia select mat;

                gwDados.DataSource = sourceMateria;
                gwDados.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                mdc.Dispose();
            }

        }


    }
}