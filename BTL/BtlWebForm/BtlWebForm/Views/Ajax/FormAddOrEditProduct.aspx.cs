using BtlWebForm.Entity;
using BtlWebForm.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BtlWebForm.Views.Ajax
{
    public partial class FormAddOrEditProduct : System.Web.UI.Page
    {
        ProductRepository productRepository = new ProductRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.Url.AbsolutePath.Contains("api/form"))
                Response.Redirect("/api/form");

            /*
                - /api/form -> trả về form thêm sản phẩm
                - /api/form/{ID} -> trả về form chứa sản phẩm để sửa
            */

            
            Object id = RouteData.Values["ID"];
            if (id != null)
            {
                int ID = Int32.Parse(id.ToString());
                ProductEntity product = productRepository.FindProductByID(ID);
                if (product != null)
                {
                    type_form.InnerText = "Thay đổi thông tin sản phẩm";
                    name_pro.Value = product.Name;
                    price_pro.Value = product.Price.ToString();
                    quantity_pro.Value = product.Quantity.ToString();
                    sale_pro.Value = product.Sale.ToString();
                    
                    info_pro.Value = product.Info;
                    url_pro.Value = product.Category + "/" + product.Slug;
                }
                
            }
            else
            {
                type_form.InnerText = "Nhập thông tin sản phẩm";
            }
        }
    }
}