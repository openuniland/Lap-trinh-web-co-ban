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
    public partial class RowOrder : System.Web.UI.Page
    {
        OrderRepository orderRepository = new OrderRepository();
        ProductRepository productRepository = new ProductRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            UserEntity userss = (UserEntity)Session.Contents[Constant.USER_SESSION];
            if (userss == null || userss.Role != Constant.ROLE_ADMIN)
            {
                Response.Redirect("/login");
            }

            List<OrderEntity> orders = orderRepository.FindAllOrder();
            if (orders == null || orders.Count == 0)
                return;
            string htmlOrder = "";
            foreach (OrderEntity order in orders)
            {
                float sum1 = 0;
                float sum2 = 0;
                htmlOrder += @"<tr>
                                        <td>" + order.IDOrder + @"</td>
                                    <td>" + order.IDUser + @"</td>
                                    <td style='text-align: left;'>
                                        <ol>";
                foreach (ProductEntity product in order.ListProduct)
                {
                    ProductEntity detail = productRepository.FindProductByID(product.ID);
                    if (detail == null)
                        continue;
                    float x = product.Quantity * detail.Price;
                    sum1 += x;
                    sum2 += x * (100 - detail.Sale) / 100;
                    htmlOrder += @"<li><a target='_blank' style='color: #ed419c; text-decoration: none;' href ='/" + detail.Category + "/" + detail.Slug + "'>" + detail.Name + " (</a><span style='color: red; font-weight: bold;'> x" + product.Quantity + @"</span>)</li>";
                }
                htmlOrder += @"</ol>
                                    </td>
                                    <td style='color: red'>" + String.Format("{0:0,0}", sum1) + @"₫</td>
                                    <td style='color: red'>" + String.Format("{0:0,0}", sum1-sum2) + @"₫</td>
                                    <td style='color: red; font-weight: bold;'>" + String.Format("{0:0,0}", sum2) + @"₫</td>
                                    <td>" + order.TimeToAdd + @"</td>
                                    <td>" + order.Note + @"</td>
                                 </tr>";
            }
            Response.Write(htmlOrder);
        }
    }
}