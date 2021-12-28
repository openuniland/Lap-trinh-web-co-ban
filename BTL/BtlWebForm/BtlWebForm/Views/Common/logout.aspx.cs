using System;

namespace BtlWebForm.Views.Common
{
    public partial class action : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("/login");
        }
    }
}
