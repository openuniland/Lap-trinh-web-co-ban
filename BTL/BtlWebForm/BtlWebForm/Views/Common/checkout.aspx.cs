using BtlWebForm.Entity;
using BtlWebForm.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BtlWebForm.Views.Common
{
    public partial class checkout : System.Web.UI.Page
    {
        UserRepository userRepository = new UserRepository();
        OrderRepository orderRepository = new OrderRepository();
        ProductRepository productRepository = new ProductRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            // Chưa mua hàng thì không được vào trang này
            OrderEntity orderCurrent = (OrderEntity)Session.Contents[Constant.ORDER_SESSION];
            if (orderCurrent == null || orderCurrent.ListProduct.Count == 0)
                Response.Redirect("/cart?msg=cart-null");

            string username = Request.Form.Get("_username");
            UserEntity user = (UserEntity)Session.Contents[Constant.USER_SESSION];

            // nếu username = null -> request là get
            // nếu username = "" -> request là post (gửi data lên server)

            if (username != null) // xử lí khi post
            {
                string password = "";
                string fullname = Request.Form.Get("_fullname");
                string address = Request.Form.Get("_address");
                string phonenumber = Request.Form.Get("_phonenumber");
                string note = Request.Form.Get("_note");
                string pay = Request.Form.Get("_pay");
                // nếu chưa đăng nhập thì chỉ lấy thông tin username, password
                if (user == null)
                {
                    if ("".Equals(fullname) || "".Equals(address) || "".Equals(phonenumber))
                    {
                        Response.Redirect("/checkout?msg=invalid");
                    }
                    password = Request.Form.Get("_password");
                    user = new UserEntity(userRepository.FindAllUser().Count + 1, username, password, fullname, 0, address, phonenumber);
                    userRepository.SaveUser(user);
                    // username da get roi
                }
                else // nếu đã đăng nhập
                {
                    user.changeUserEntity(fullname, user.Role, address, phonenumber);
                    userRepository.ChangeInfoUser(user);
                }

                // save cart
                orderCurrent.IDUser = user.ID;
                int idOrder = orderRepository.FindAllOrder() == null ? 1 : orderRepository.FindAllOrder().Count + 1;
                orderCurrent.IDOrder = idOrder;
                orderCurrent.TimeToAdd = DateTime.Now;
                orderCurrent.Note = note;
                orderRepository.SaveOrder(orderCurrent);

                // giải phóng cart session
                Session.Remove(Constant.ORDER_SESSION);

                // Đăng nhập cho user và quay lại trang cart
                Session.Add(Constant.USER_SESSION, user);
                Response.Redirect("/cart?msg=success");
            }
            else // xử lí khi get
            {
                
                // Nếu đăng nhập rồi thì đưa các thông tin cơ bản cho người dùng có thể sửa lại
                if (user != null)
                {
                    _username.Value = user.Username;
                    _username.Style.Add("display", "none");
                    //_password.Style.Add("display", "none");
                    _fullname.Value = user.Fullname;
                    _phonenumber.Value = user.PhoneNumber;
                }


                // show list người dùng mua
                string HTML = "";
                float sum = 0;
                foreach (ProductEntity product in orderCurrent.ListProduct)
                {
                    ProductEntity detail = productRepository.FindProductByID(product.ID);
                    string html = @"<div class='_product'>
                                        <div class='img_quantity'>
                                            <span>" + product.Quantity + @"</span>
                                            <img src = '" + detail.ListImage[0] + @"'>
                                        </div>
                                        <div class='_name'>
                                            " + detail.Name + @" 
                                        </div>
                                        <div class='_price'>
                                            " + String.Format("{0:0,0}", detail.Price * (100 - detail.Sale) / 100) + @"₫
                                        </div>
                                    </div>";
                    HTML += html;
                    sum += detail.Price * (100 - detail.Sale) / 100 * product.Quantity;
                }
                list_server.InnerHtml = HTML;

                _total.InnerText = String.Format("{0:0,0}", sum) + "₫";

            }    

            
           
        }
    }
}