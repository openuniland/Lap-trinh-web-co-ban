using BtlWebForm.Entity;
using BtlWebForm.Repository;
using System;

namespace BtlWebForm.Views.Common
{
    public partial class login : System.Web.UI.Page
    {
        UserRepository userRepository = new UserRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            // Làm đẹp url nếu user cố tình vào trang domain.com/Views/Common/login.aspx
            if (Request.Url.AbsolutePath.Contains("login.aspx"))
                Response.Redirect("/login");

            // Nếu đã login thì không được vào trang này nữa
            if (Session.Contents["user-login"] != null)
                Response.Redirect("/");
            else
            {
                // check xem post hay get, username có dữ liệu là post, get thì cho vào trang đăng nhập
                // post thì tiến hành lấy thông tin để đăng ký
                string username = Request.Form.Get("username");
                if (username != null)
                    CheckLogin();
            }    

            
        }
        private void CheckLogin()
        {
            string username = Request.Form.Get("username");
            string password = Request.Form.Get("password");
            if (!"".Equals(username) && !"".Equals(password))
            {
                UserEntity user = userRepository.FindUserByUsername(username);
                if (user != null)
                {
                    if (user.Password.Equals(password))
                    {
                        Session["a"] = "";
                        Session.Add(Constant.USER_SESSION, user);
                        string redirect = user.Role == Constant.ROLE_ADMIN ? "/admin" : "/";
                        Response.Redirect(redirect);
                    }
                }
            }
            Response.Redirect("/login?msg=false");
        }
    }
}