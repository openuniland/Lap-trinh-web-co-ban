using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bai9
{
    public partial class bai9 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void post_Click(object sender, EventArgs e)
        {
            Response.Redirect("/xuly.aspx");
        }

        protected void get_Click(object sender, EventArgs e)
        {
            Response.Redirect("/xuly2.aspx?" + "VatLieu=" + txtTenVXL.Value +
                "&Hang=" + txtHang.Value + "&Ngay=" + txtNgayRaMat.Value + "&Gia=" + txtCost.Value);
        }
    }
}