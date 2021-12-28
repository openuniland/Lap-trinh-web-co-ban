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
    public partial class register : System.Web.UI.Page
    {
        UserRepository userRepository = new UserRepository();
        protected void Page_Load(object sender, EventArgs e)
        {    
            // chỉnh lại path nếu run từ trang này
            if (!Request.Url.AbsolutePath.Equals("/register"))
                Response.Redirect("/register");

            // xem đăng nhập chưa, đăng nhập rồi thì không được vào đây
            if (Session.Contents[Constant.USER_SESSION] != null)
                Response.Redirect("/");
            else
            {
                // kiểm tra xem post hay get,
                // get thì cho vào page đăng ký
                // post thì đọc thông tin ra để đăng ký
                if (Request.Form.Get("ctl00$CommonBody$username") != null)
                    Register();
            }
        }

        private void Register()
        {
            string _username = Request.Form.Get("ctl00$CommonBody$username");
            string _password = Request.Form.Get("ctl00$CommonBody$password");
            string _repassword = Request.Form.Get("ctl00$CommonBody$repassword");
            string _fullname = Request.Form.Get("ctl00$CommonBody$fullname");
            string _phonenumber = Request.Form.Get("ctl00$CommonBody$phonenumber");
            bool saveError = false;

            // đã validate bằng js nhưng vẫn kiểm tra lại
            if ("".Equals(fullname) || "".Equals(password) || "".Equals(phonenumber) || "".Equals(username))
            {
                fullname_warn.InnerText = username_warn.InnerText = password_warn.InnerText =
                phonenumber_warn.InnerText = "* Trường này không được để trống !";
            }
            else
                // tìm kiểm xem username này đã tồn tại chưa
                if (userRepository.FindUserByUsername(_username) == null)
                {
                    UserEntity user = new UserEntity();
                    user.ID = userRepository.FindAllUser().Count + 1; // id mới bằng số lượng id cũ + 1
                    user.Username = _username;
                    user.Password = _password; // phạm vi bài đơn giản nên không mã hóa password
                    user.Fullname = _fullname;
                    user.PhoneNumber = _phonenumber;
                    user.Role = Constant.ROLE_USER; // mặc định sẽ là role user


                    // tam save mai lam
                    if (userRepository.SaveUser(user))
                    {
                        Response.Redirect("/login?msg=register-success");
                    }                 
                    else // lỗi ghi file không thành công (lỗi dự đoán có thể
                        //xảy ra nếu nhiều ng cùng đăng ký, file user.json đang mở -> conflict - dư đoán)
                    {
                        saveError = true;
                        fullname_warn.InnerText = "* Lỗi xảy ra khi ko thể save user vào file json";
                    }    
                }

            // nếu đến đây chưa bị redirect thì đã có lỗi
            // báo lỗi username đã tồn tại, nhưng vẫn trả lại form dữ liệu như cũ
                
            username.Value = _username;
            fullname.Value = _fullname;
            phonenumber.Value = _phonenumber;
            if (!saveError)
                username_warn.InnerText = "* Username nãy đã tồn tại, vui lòng sử dụng tên khác";
                
        }
    }
}