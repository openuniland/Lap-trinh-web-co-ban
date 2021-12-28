using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bai9
{
    public partial class xuly2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "text/xml";
            var ten = "<TenVXL>" + Request.QueryString["txtTenVXL"] + "</TenVXL>";
            var hang = "<Hang>" + Request.QueryString["txtHang"] + "</Hang>";
            var ngay = "<NgayRaMat>" + Request.QueryString["txtNgayRaMat"] + "</NgayRaMat>";
            var gia = "<Gia>" + Request.QueryString["txtCost"] + "</Gia>";
            Response.Write("<XML>" + ten + hang + ngay + gia + "</XML>");
            Response.End();
        }
    }
}