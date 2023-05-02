using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proj5
{
    public partial class Logado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            MsgGeral.Text = Session["NomeUsusario"].ToString();


        }
    }
}