using BtlWebForm.Entity;
using BtlWebForm.Repository;
using System;

namespace BtlWebForm.Views.Ajax
{
    public partial class Comment : System.Web.UI.Page
    {
        UserRepository userRepository = new UserRepository();
        ProductRepository productRepository = new ProductRepository();
        CommentRepository commentRepository = new CommentRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            // chưa đăng nhập thì không được vào đây
            if (Session.Contents[Constant.USER_SESSION] == null)
                return;
            string IDProduct = Request.Form.Get("idProduct");
            string contentComment = Request.Form.Get("comment");
            string levelComment = Request.Form.Get("level");
            if ("".Equals(IDProduct) || "".Equals(contentComment) || IDProduct == null || contentComment == null)
                return;

            UserEntity user = (UserEntity)Session.Contents[Constant.USER_SESSION];
            // tránh trường hợp user này đang đăng nhập thì bị xóa khỏi hệ thống -> ở btl này có thể ko đụng đến
            if (userRepository.FindUserByID(user.ID) == null)
                return;

            // tránh trường hợp client cố tình thay đổi id trong javascript
            if (productRepository.FindProductByID(Int32.Parse(IDProduct)) == null)
                return;

            SimpleComment simpleComment = new SimpleComment();
            simpleComment.Content = contentComment;
            simpleComment.TimeComment = DateTime.Now;
            simpleComment.IDUser = user.ID;

            string role = user.Role == Constant.ROLE_ADMIN ? "admin" : "user";
            // nếu là comment level1 thì thêm mới thôi
            if (Constant.LEVEL_COMMENT_1.Equals(levelComment))
            {
                CommentLevel1Entity commentMain = new CommentLevel1Entity();
                commentMain.CommentMain = simpleComment;
                commentRepository.SaveCommentLevel1(ref commentMain, Int32.Parse(IDProduct));

                Response.Write(user.Fullname + "|" + role + "|" + commentMain.IDCommentMain);
            }
            else if (Constant.LEVEL_COMMENT_2.Equals(levelComment))
            {
                int idCmt = Int32.Parse(Request.Form.Get("idCmt"));
                
                commentRepository.SaveCommentLevel2(simpleComment, Int32.Parse(IDProduct), idCmt);
                Response.Write(user.Fullname + "|" + role);
               // commentRepository.SaveCommentLevel2(simpleComment, Int32.Parse(IDProduct));
            }

            
        }
    }
}