using BtlWebForm.Entity;
using BtlWebForm.Repository;
using BtlWebForm.Utils;
using System;
namespace BtlWebForm.Views.Common
{
    public partial class home : System.Web.UI.Page
    {
        ProductRepository productRepository = new ProductRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            // làm đẹp url
            if (!Request.Url.AbsolutePath.Equals("/"))
                Response.Redirect("/");

            // list quần áo
            string HTML = @"<div class='banner_cate width33'>
                                <a href='/QUAN_AO'>
                                     <img class='img' src='/static/img/banner/collection_module_2_banner.png' alt=''>
                                </a>
                            </div>"; 

            foreach (ProductEntity product in productRepository.FindProductCategory(Constant.QUAN_AO))
            {
                HTML += ProductUtil.MatchHtmlWithData(product);
            }
            quanao.InnerHtml = HTML;

            // list váy nữ
            HTML = @"<div class='banner_cate width33'>
                        <a href='/VAY_NU'>
                                <img class='img' src='/static/img/banner/collection_module_3_banner.png' alt=''>
                        </a>
                    </div>";

            foreach (ProductEntity product in productRepository.FindProductCategory(Constant.VAY_NU))
            {
                HTML += ProductUtil.MatchHtmlWithData(product);
            }
            vaynu.InnerHtml = HTML;

        }
    }
}