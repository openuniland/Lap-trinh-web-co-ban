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
    public partial class TableProducts : System.Web.UI.Page
    {
        ProductRepository productRepository = new ProductRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            List<ProductEntity> products = productRepository.FindAllProducts();
            string html = "";
            if (products != null)
            {
                foreach (ProductEntity product in products)
                {
                    html += @"<tr>
                                    <td class='text-2-line-ver2'>" + product.Name + @"</td>
                                    <td class='red'>" + String.Format("{0:0,0}", product.Price) + @" ₫</td>
                                    <td>" + product.Quantity + @"</td>
                                    <td><img src='" + (product.ListImage.Count != 0 ? product.ListImage[0] : "") + @"'></td>
                                    <td class='red'>" + product.Sale + @" %</td>
                                    <td><a target='_blank' href='/" + product.Category + "/"+ product.Slug + @"' > Xem chi tiết</a></td>
                                    <td>
                                        <button class='btn-change' type='button' onclick='editProduct(this)'>Sửa</button>
                                        <button class='btn-delete' type='button'>Xóa</button>
                                    </td>
                            </tr>";
                }    
            }
            Response.Write(html);
        }
    }
}