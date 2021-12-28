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
    public partial class ShowDetailProduct : System.Web.UI.Page
    {
        ProductRepository productRepository = new ProductRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            // sử dụng url mặc định 
            if (!Request.Url.AbsolutePath.Contains("/api/product"))
                Response.Redirect("/api/product/1");

            // lấy data từ url: /api/product/{ID}
            int ID = Int32.Parse(RouteData.Values["ID"].ToString());
            ProductEntity product = productRepository.FindProductByID(ID);

            // Bắt đầu gán value vào các ID
            if (product != null)
            {
                bigImg.ImageUrl = product.ListImage[0];
                string imgs = @"<div class='chuyen' onclick='backImg()' style='display: none;'>
                                    <img src = '/static/img/icon/click-left.png' alt = '' >
                                </div> ";
                for (int i = 0; i < product.ListImage.Count; i++)
                {
                    imgs += @"<img src='" + product.ListImage[i] + @"' alt='Ảnh lỗi' class='small-img' onclick='showImage(this)' num='" + i + @" '>"; 
                }

                imgs += @"<div class='chuyen' onclick='nextImg()'>
                            <img src = '/static/img/icon/click-right.png' alt = '' >
                          </div>";

                PIC.InnerHtml = imgs;
                NAME.InnerHtml = product.Name;
                TRADEMARK.InnerHtml = product.Trademark;
                INFO.InnerText = product.Info;

                string html = @"<button id=" + "'btn-add-to-cart' onclick='addToCart(" + product.ID +  @")'>Cho vào Thêm vào giỏ hàng</button>";
                btn_server.InnerHtml = html;
                if (product.Quantity <= 0)
                {
                    QUANTITY_X.InnerText = "Hết hàng";
                    QUANTITY_X.Attributes.Add("style", "background: red !important");
                }
                else
                    QUANTITY_X.InnerText = "Còn hàng";

                if (product.Sale != 0f)
                {
                    GIA_CU.InnerText = String.Format("{0:0,0}", product.Price) + @"₫";
                    GIA_MOI.InnerText = String.Format("{0:0,0}", product.Price * (100 - product.Sale) / 100) + @"₫";
                }
                else
                {
                    GIA_MOI.InnerText = String.Format("{0:0,0}", product.Price) + @"₫";
                }
                LINK_PRODUCT.Attributes.Add("href", "/" + product.Category + "/" + product.Slug);
            }
            
        }
    }
}