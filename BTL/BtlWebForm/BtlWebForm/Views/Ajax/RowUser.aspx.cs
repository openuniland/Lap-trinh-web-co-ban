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
    public partial class RowUser : System.Web.UI.Page
    {
        UserRepository userRepository = new UserRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            List<UserEntity> users = userRepository.FindAllUser();
            if (users == null)
                return;
            foreach (UserEntity user in users)
            {
                string html = @"<tr>
                                    <td>" + user.ID + @"</td>
                                    <td>" + user.Username + @"</td>
                                    <td>" + user.Fullname + @"</td>
                                    <td>" + user.PhoneNumber + @"</td>
                                    <td>" + user.Address + @"</td>
                                    <td>" + (user.Role == Constant.ROLE_ADMIN ? "ADMIN" : "USER") + @"</td>
                                </tr>";
                Response.Write(html);
            }
        }
    }
}