using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bai10
{
    public partial class Bai10 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            if (txtFile.HasFile)
            {
                content.Value = txtNoiDung.Value;
                string fileName = "~/App_Data/" + txtFile.FileName;
                string filePath = MapPath(fileName);
                txtFile.SaveAs(filePath);
            }
            else
            {
                Response.Write("<script>alert('Chua Nhap File!')</script>");
            }
        }
    }
}