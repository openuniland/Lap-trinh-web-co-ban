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
    public partial class detail : System.Web.UI.Page
    {
        ProductRepository productRepository = new ProductRepository();
        PostRepository postRepository = new PostRepository();
        CommentRepository commentRepository = new CommentRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
          
            string url = Request.Url.AbsolutePath;

            // đọc slug từ router
            string slug = (string)RouteData.Values["slug"];
            ProductEntity product = productRepository.FindProductBySlug(slug);

            // nếu tìm thấy sp thì sẽ hiển thị thông tin sản phẩm
            // nếu không tìm thấy thì sẽ cho về trang home
            if (product != null)
            {
                if (url.Contains("QUAN_AO"))
                {
                    url_page.Attributes.Add("href", "/QUAN_AO");
                    name_page.InnerText = "Quần áo";
                    slug_.Attributes.Add("href", "/QUAN_AO/" + product.Slug);
                }
                else
                {
                    url_page.Attributes.Add("href", "/VAY_NU");
                    name_page.InnerText = "Váy nữ";
                    slug_.Attributes.Add("href", "/VAY_NU/" + product.Slug);
                }

                name_product.InnerText = product.Name;

                bigImg.Attributes.Add("src", product.ListImage[0]);

                __title.InnerText = product.Name;
                // load list image
                string html_img = @"<div class='chuyen' onclick='backImg()' style='display: none;'>
                                          <img src='/static/img/icon/click-left.png' >
                                    </div>";
                
                int i = 0;
                foreach (string img in product.ListImage)
                {
                    i++; // tạo biến đếm để hiển thì 3 ảnh trong list ảnh, tạm thời để none, sau đấy dùng js để thao tác
                    html_img += @"<img src='" + img +@"' class='small-img "+ (i > 3 ? "none" : "") + @"' onclick='showImage(this)' num='" + i + @"'>";
                }
                html_img += @"<div class='chuyen' onclick='nextImg()'>
                                    <img src='/static/img/icon/click-right.png' >
                              </div>";


                list_anh.InnerHtml = html_img;

                name_pro.InnerText = product.Name;
                // url sản phẩm sẽ có dạng: /category-name/slug
                name_pro.Attributes.Add("href", "/" + product.Category + "/" + product.Slug);

                price_new.InnerText = String.Format("{0:0,0}", product.Price * (100 - product.Sale) / 100) + @"₫";
                price_old.InnerText = String.Format("{0:0,0}", product.Price) + @"₫";

                 if (product.Quantity <= 0)
                 {
                        _status.InnerText = "Hết hàng";
                        _status.Attributes.Add("style", "background: red !important");
                 }

                // xử lí lại chỗ miêu tả cấu hình
                product.Info = product.Info.Replace("\n", "<br>");
                product.Info = product.Info.Replace("\t", ": ");
                info_detail.InnerHtml = product.Info;

                string html = @"<button id=" + "'btn-add-to-cart' onclick='addToCart(" + product.ID + @")'>Thêm vào giỏ hàng</button>";
                btn_server.InnerHtml = html;

                // load bài viết chi tiết
                PostEntity post = postRepository.FindPostByIDProduct(product.ID);
                if (post == null)
                    post_details.InnerText = "Chưa có bài đánh giá sản phẩm này";
                else
                {                 // gán link ảnh vào trong các thẻ img,  "src='filename'" -> "src='link-image'"
                    for (i = 0; i < post.ListImage.Count; i++)
                    {
                        post.Content = post.Content.Replace("src='filename" + i + "'", "src='" + post.ListImage[i] + "'");
                    }
                    post_details.InnerHtml = post.Content;
                }


                // đọc list comment ra
                CommentOfAPost commentInPost = commentRepository.FindListCommentsOfProduct(product.ID);
                string htmlComment = CommentUtils.HTMLComments(commentInPost);
                //List<CommentLevel2Entity> comments = commentRepository.FindCommentsByIDProduct(product.ID);
                //string htmlComment = CommentUtils.HTMLComments(comments);
                list_comment.InnerHtml = htmlComment;


                // add btn send cmt
                //onclick = "sendCommentLevel1(1)"
                btn_send_lv1.Attributes.Add("onclick", "sendCommentLevel1(" + product.ID + ")");
                btn_send_lv1.Attributes.Add("idxx", product.ID.ToString());
            }
            else
                Response.Redirect("/");
        }
    }
}