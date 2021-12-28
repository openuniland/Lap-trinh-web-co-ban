using System;
using BtlWebForm.Entity;

namespace BtlWebForm.Utils
{
    public class ProductUtil
    {   
        // Hàm ghép html + data, đây là 1 khung html chứa 1 sản phẩm 
        public static string MatchHtmlWithData(ProductEntity product)
        {
            if (product == null)
                return null;

            string name = product.Name;

            string html =
                @"<div class='product'>
                    <div class='product-box'>
                        <div class='product-thumnail'> ";
                if (product.Sale != 0f)
                    html += @"<span class='sale-count'>
                                    - " + product.Sale + @"%
                              </span>";

                    html += @"<a href = '/" + product.Category + "/" + product.Slug + @"' title='" + product.Name + @"' class='title_name_product'>
                                    <img src = '" + product.ListImage[0] + @"' alt='' class='img-thumnail'>
                            </a>
                            <div class='show-option-selection'>
                                <div class='view-details' onclick='btnShowForm(1, " + product.ID + @")' title='Xem nhanh'>
                                    <img src = '/static/img/icon/kinhlup.png' alt='' class='icon'>
                                </div>
                                <div class='add-to-cart' onclick='showNameProClick(this);showFormCartSession(" + product.ID + @", 2);' title='Thêm vào giỏ hàng'>
                                    <img src = '/static/img/icon/cart.png' alt='' class='icon'>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class='product-box khungduoi'>
                        <div class='product-info'>
                            <span class='product-vendor'>
                                " + product.Trademark + @"
                            </span>

                            <h4 class='product-name'>
                                <a href = '/" + product.Category + "/" + product.Slug + @"' class='text-2-line'>
                                    " + product.Name + @"
                                </a>
                            </h4>

                            <div class='product-price'> ";
                if (product.Sale != 0f)
                    html += @"<span class='product-price-old'>
                                    " + String.Format("{0:0,0}", product.Price) + @"₫
                                </span>";

                html +=        @"<span class='product-price-new'>
                                    " + String.Format("{0:0,0}", product.Price * (100 - product.Sale) / 100) + @"₫
                                </span>
                            </div>
                        </div>
                    </div>
                </div>";
            return html;
        }

        public static string MatchHtmlWithProductSession(ProductEntity product, int Quantity)
        {

            float price = product.Price * (100 - product.Sale) / 100;
            string html = @"<div class='view-row-product'>
                            <div class='view-product-info'>
                            <div class='view-img'>
                                <img src = '";

            html += product.ListImage != null ? product.ListImage[0] : "";

            html += @"'>
                            </div>
                            <div class='view-info'>
                                <div class='view-info-name text-2-line'>"
                                    + product.Name + @"
                                </div>
                                <span class='click-remove' onclick='removeProduct(this);changeNumberOrderThenRemove()' num='" + product.ID + @"'>
                                    〤 Xóa
                                </span>
                            </div>
                        </div>
                        <div class='view-product-price'>
                            <span class='red line37'>" + String.Format("{0:0,0}", price) + @"₫</span>
                        </div>
                        <div class='view-product-quantity'>
                            <div class='cha'>
                                <span class='con minus' onclick='minusChangeQuantity(this, " + product.ID + @" , 1)'>–</span>
                                <input type = 'text' value='" + Quantity + @"' onchange='sumOfMoney(this); onchangeAddSession( "+ product.ID + @",this);' oninput='sumOfMoney(this)'>
                                <span class='con add' onclick='addChangeQuantity(this, " + product.ID + @")'>+</span>
                            </div>
                        </div>
                        <div class='view-product-total-money'>
                            <span class='red line37'>" + String.Format("{0:0,0}", price * Quantity) + @"₫</span>
                        </div>
                    </div>";
            return html;
        }
    }
}