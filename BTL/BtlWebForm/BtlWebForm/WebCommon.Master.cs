using BtlWebForm.Entity;
using System;

namespace BtlWebForm
{
    public partial class WebCommon : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserEntity user = (UserEntity)Session.Contents[Constant.USER_SESSION];
            if (user != null)
            {
                full_name.InnerText = user.Fullname;
                logout.InnerText = "Logout";
                string link = "/";
                if (user.Role == Constant.ROLE_ADMIN)
                    link = "/admin";

                LINK.Attributes.Add("href", link);
                LINK1.Attributes.Add("href", link);

                // mobile
                __fullname_m.Attributes.Add("href", link);
                __fullname_m.InnerText = user.Fullname;
            }
            OrderEntity orderCurent = (OrderEntity)Session.Contents[Constant.ORDER_SESSION];
            if (orderCurent != null)
            {
                number_oder.InnerText = orderCurent.ListProduct.Count.ToString();
                number_oder2.InnerText = orderCurent.ListProduct.Count.ToString();
                number_oder_m.InnerText = orderCurent.ListProduct.Count.ToString();
            }
        }
    }
}