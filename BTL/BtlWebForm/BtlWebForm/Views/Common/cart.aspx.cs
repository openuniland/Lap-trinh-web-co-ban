using BtlWebForm.Entity;
using BtlWebForm.Repository;
using BtlWebForm.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BtlWebForm.Views.Common
{
    public partial class cart : System.Web.UI.Page
    {
        ProductRepository productRepository = new ProductRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            OrderEntity order = (OrderEntity)Session.Contents[Constant.ORDER_SESSION];
            if (order == null)
            {
                status_order.InnerHtml = @"<div style='height: 200px'>
                                                 <span> Bạn chưa chọn sản phẩm nào </span>
                                           </div> ";
            }    
            else
            {
                string HTML = "";
                float sumMoney = 0;
                for (int i = 0; i < order.ListProduct.Count; i++)
                {
                    ProductEntity product = productRepository.FindProductByID(order.ListProduct[i].ID);
                    HTML += ProductUtil.MatchHtmlWithProductSession(product, order.ListProduct[i].Quantity);

                    sumMoney += product.Price * order.ListProduct[i].Quantity * (100 - product.Sale) / 100;
                }
                data_render.InnerHtml = HTML;
                tong.InnerText = String.Format("{0:0,0}", sumMoney);
            }    
        }
    }
}