using BtlWebForm.Entity;
using BtlWebForm.Repository;
using BtlWebForm.Utils;
using System;
using System.Collections.Generic;
namespace BtlWebForm.Views.Common
{
    public partial class search : System.Web.UI.Page
    {
        ProductRepository productRepository = new ProductRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            string q = Request.QueryString.Get("q");
            List<ProductEntity> products = productRepository.FindProductsLikeName(q);
            if (products == null)
            {
                CountResult.InnerText = "Không có sản phẩm nào được tìm thấy !";
                ListProduct.InnerHtml = @"<div style='height: 200px'></div>";
            }    
            else
            {
                CountResult.InnerText = "Có " + products.Count + " kết quả được tìm thấy";
                string html = "";
                foreach (ProductEntity product in products)
                    html += ProductUtil.MatchHtmlWithData(product);
                ListProduct.InnerHtml = html;
            }    
        }
    }
}