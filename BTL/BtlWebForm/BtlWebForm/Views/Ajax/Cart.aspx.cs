using BtlWebForm.Entity;
using BtlWebForm.Repository;
using BtlWebForm.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BtlWebForm.Views.Ajax
{
    public partial class Cart : System.Web.UI.Page
    {
        ProductRepository productRepository = new ProductRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            // Xử lý trường hợp ấn run ngay tại trang này, sẽ điều hướng đến trang home
            if (!Request.Url.AbsolutePath.Contains("api/cart"))
                Response.Redirect("/");

            // url /api/cart/{id} -> add product to cart
            string ID = (string) RouteData.Values["ID"];
            if (ID != null)
            {
                // url /api/cart/{id}/{type}/{quantity} -> type là tăng, giảm
                string type = (string)RouteData.Values["type"];
                string quantity = (string)RouteData.Values["quantity"];
                int qtt = 0;
                if (quantity == null)
                    qtt = 1;
                else
                    qtt = Int32.Parse(quantity);

                // sau 1 hồi sửa =))
                SaveProductToSession(Session, Int32.Parse(ID), type, qtt);
                
            }
            // url /api/cart -> get full product from session
            else
            {
                OrderEntity order = (OrderEntity)Session.Contents[Constant.ORDER_SESSION];
                if (order != null)
                {
                    List<int> ids = GetListIDFromSession(order);
                    List<ProductEntity> products = productRepository.FindProductByListID(ids);
                    if (products == null)
                        return;
                    string html = "" + ids.Count + "|"; // trả về số lượng hiện tại luôn
                    // edit part 2
                    int i = 0;
                    foreach (ProductEntity product in products)
                    {
                        html += ProductUtil.MatchHtmlWithProductSession(product, order.ListProduct[i].Quantity);
                        i++;
                    }
                    Response.Write(html);
                }
            }
            OrderEntity ordertest = (OrderEntity)Session.Contents[Constant.ORDER_SESSION];
        }

        private void SaveProductToSession(HttpSessionState session, int ID, string type, int Quantity)
        {
            OrderEntity order = (OrderEntity)Session.Contents[Constant.ORDER_SESSION];
            if (order == null)
            {
                order = new OrderEntity(1, ID, 1);
                Session.Add(Constant.ORDER_SESSION, order);
            }
            else
            {
                bool isExist = false;
                for (int i = 0; i < order.ListProduct.Count; i++)
                {
                    if (ID == order.ListProduct[i].ID)
                    {
                        isExist = true;
                        if ("minus".Equals(type)) // xử lý click giảm
                        {
                            order.ListProduct[i].Quantity -= Quantity;
                            if (order.ListProduct[i].Quantity < 1)
                                order.ListProduct[i].Quantity = 1; // mặc định luôn = 1
                        }
                        else if (type == null)
                        {
                            order.ListProduct[i].Quantity++;  
                        }
                        else if ("remove".Equals(type)) // sự kiện remove
                        {
                            order.ListProduct.RemoveAt(i);
                          
                            break;
                        }
                        else // còn lại là sự kiện onchange
                        {
                            order.ListProduct[i].Quantity = Quantity;
                        }
                        
                    }
                }
                if (isExist)
                    Session.Add(Constant.ORDER_SESSION, order);
                else
                {
                    ProductEntity product = new ProductEntity(ID, Quantity);
                    order.ListProduct.Add(product);
                    Session.Add(Constant.ORDER_SESSION, order);
                }
            }

        }

        private List<int> GetListIDFromSession(OrderEntity order)
        {
            List<int> ids = new List<int>();
            foreach (ProductEntity product in order.ListProduct)
            {
                int id = product.ID;
                ids.Add(id);
            }
            return ids;
        }

    }
}