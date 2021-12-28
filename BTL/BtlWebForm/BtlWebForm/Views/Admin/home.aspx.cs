using BtlWebForm.Entity;
using System;
namespace BtlWebForm.Views.Admin
{
    public partial class home : System.Web.UI.Page
    {
     
        protected void Page_Load(object sender, EventArgs e)
        {
            // làm đẹp url nếu truy cập vào /Views/Admin/home.aspx
            if (!Request.Url.AbsolutePath.Equals("/admin"))
                Response.Redirect("/admin");

        }
    }
}