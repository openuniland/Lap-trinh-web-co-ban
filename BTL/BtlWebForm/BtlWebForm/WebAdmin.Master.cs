using BtlWebForm.Entity;
using System;

namespace BtlWebForm
{
    public partial class WebAdmin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Đã phân quyền rồi nên vào đây chỉ có thể là admin
            UserEntity user = (UserEntity)Session.Contents[Constant.USER_SESSION];
            if (user != null)
            {
                if (user.Role == Constant.ROLE_USER)
                    Response.Redirect("/access-denied");
                name_admin.InnerText = user.Fullname;
            }
            else
                Response.Redirect("/login");
               

            
        }
    }
}