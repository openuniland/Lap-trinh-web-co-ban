<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowDetailProduct.aspx.cs" Inherits="BtlWebForm.Views.Ajax.ShowDetailProduct" %>
<a href="javascript:;" class="btn-close" onclick="btnClose(1)">x</a>
        <div class="flex-layout">
            <div class="left-frame">
                <div id="big-img">
                    <asp:Image ID="bigImg" ImageUrl="/static/img/vr3.jpg" runat="server"></asp:Image>
                </div>
                <div class="list-img" id="PIC" runat="server">

                </div>
            </div>
            <div class="right-frame">
                <h3 id="name-product-current">
                    <a href="" id="NAME" runat="server"></a>
                </h3>
                <div class="thongtin">
                    <span>Thương hiệu: </span>
                    <span id="TRADEMARK" runat="server"></span>
                    <span> | </span>
                    <span>Tình trạng: </span>
                    <span class="status" id="QUANTITY_X" runat="server"></span>
                </div>
                <hr class="line">
                <div class="product-price" style="text-align: center;">

                    <span class="product-price-new" id="GIA_MOI" runat="server">
                        
                    </span>

                    <span class="product-price-old" id="GIA_CU" runat="server">
                        
                    </span>
                </div>
                <hr class="line">
                <div class="description">
                    <div class="text-2-line" id="INFO" runat="server">
                        
                    </div>
                    <a href="#" id="LINK_PRODUCT" runat="server">Xem chi tiết</a>
                </div>

                <div class="muahang" >
                    <div class="quantity cha">
                            <span class="con minus" onclick="minusQuantity(this)">–</span>
                            <input type="text" value="1" onchange="checkInput(this)" id="_quantity_">
                            <span class="con add" onclick="addQuantity(this)">+</span>
                    </div>
                    <div class="btn-add-to-cart" id="btn_server" runat="server">
                        
                    </div>
                </div>
            </div>

        </div>