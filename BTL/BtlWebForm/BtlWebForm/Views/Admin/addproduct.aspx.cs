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
    public partial class addproduct : System.Web.UI.Page
    {
        ProductRepository productRepository = new ProductRepository();
        PostRepository postRepository = new PostRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            UserEntity user = (UserEntity)Session.Contents[Constant.USER_SESSION];

            if (user == null || user.Role != Constant.ROLE_ADMIN)
                Response.Redirect("/access-denied");

            string name_pro = Request.Form.Get("ctl00$AdminBody$name_pro");


            // POST
            if (name_pro != null)
            {
                string price_pro = Request.Form.Get("ctl00$AdminBody$price_pro");
                string quantity_pro = Request.Form.Get("ctl00$AdminBody$quantity_pro");
                string sale_pro = Request.Form.Get("ctl00$AdminBody$sale_pro");
                string info_pro = Request.Form.Get("ctl00$AdminBody$info_pro");
                string url_pro = Request.Form.Get("ctl00$AdminBody$url_pro");
                string trademark = Request.Form.Get("ctl00$AdminBody$thuong_hieu");
                string category = Request.Form.Get("category_pro");
                string htmlPost = Request.Unvalidated.Form.Get("html");


                if ("".Equals(name_pro) || "".Equals(price_pro) || "".Equals(quantity_pro) || "".Equals(sale_pro)
                     || "".Equals(url_pro))
                    Response.Redirect("/admin?msg=false-field-null");

                List<string> listImageProduct = new List<string>();
                List<string> listImagePost = new List<string>();

                // đọc list file
                var file = Request.Files;
                for (int i = 0; i < file.AllKeys.Length; i++)
                {
                    // file ko có giá trị thì sẽ ko có tên file
                    if ("".Equals(file[i].FileName))
                        continue;

                    // chuẩn hóa lại tên file
                    string filename = "f" + DateTime.Now + file[i].FileName;
                    filename = filename.Replace('/', '_');
                    filename = filename.Replace(' ', '_');
                    filename = filename.Replace(':', '_');
                    filename = Constant.PATH_PRODUCT + filename;
                    file[i].SaveAs(MapPath(filename));

                    if (file.Keys[i].Equals("file")) // name "file" is param of the product
                        listImageProduct.Add(filename);
                    else
                        listImagePost.Add(filename);
                }

                ProductEntity product = new ProductEntity();

                // id được tự động tăng trong hàm save rồi

                product.Name = name_pro;
                price_pro = price_pro.Replace(".", "");
                price_pro = price_pro.Replace(",", "");

                product.Price = Int32.Parse(price_pro);
                product.Quantity = Int32.Parse(quantity_pro);
                product.Sale = Int32.Parse(sale_pro);
                product.Info = info_pro;
                product.Slug = url_pro;
                product.Category = category;
                product.ListImage = listImageProduct;
                product.Trademark = trademark;
                // save product
                productRepository.SaveProduct(product);

                PostEntity post = new PostEntity(product.ID, htmlPost, listImagePost);
                postRepository.SavePost(post);
                Response.Redirect("/admin");

            }

        }
    }
}