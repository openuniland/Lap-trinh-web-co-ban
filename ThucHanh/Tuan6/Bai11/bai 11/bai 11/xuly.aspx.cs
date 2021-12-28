using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bai_11
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var hoten = Request.Form.Get("hoten");
            var namsinh = Request.Form.Get("namsinh");
            List<nhanvien> listNhanvien = (List<nhanvien>)Session["danhsach"];
            nhanvien nv = new nhanvien();
            int check = 0;
            foreach (nhanvien i in listNhanvien)
            {
                if (i.Hoten == hoten && i.Namsinh == namsinh)
                {
                    check = 1;
                    break;
                }
            }
            if (check == 0)
            {
                nv.Hoten = hoten;
                nv.Namsinh = namsinh;
                listNhanvien.Add(nv);
                Session["danhsach"] = listNhanvien;
            }
            string output = "";
            foreach (nhanvien i in listNhanvien)
            {
                output += @"<tr>
                                    <td class='text-left'>" + i.Hoten + @"</td>
                                    <td class='text-left'>" + i.Namsinh + @"</td>
                                </tr>";
            }
            viewDanhSach.InnerHtml = output;
        }
    }
}