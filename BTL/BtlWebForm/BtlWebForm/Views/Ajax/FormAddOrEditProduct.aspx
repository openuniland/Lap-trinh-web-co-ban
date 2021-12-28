<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormAddOrEditProduct.aspx.cs" Inherits="BtlWebForm.Views.Ajax.FormAddOrEditProduct" %>


    <div class="form-add-product frame">
        <a href="javascript:;" class="btn-close" onclick="btnClose(1)">x</a>
        <p class="title-p" id="type_form" runat="server"></p>
        <form action="/api/addproduct" method="post" enctype="multipart/form-data" class="form_edit_overflow">
        <table id="table-add">
            <tr>
                <td width="120px">Tên sản phẩm</td>
                <td width="600px">
                    <input type="text" id="name_pro" name="name_pro" oninput="gen()" runat="server" class="input-add">

                </td>
            </tr>
            <tr>
                <td width="120px">Thương hiệu</td>
                <td width="600px">
                    <input type="text" id="thuong_hieu" name="thuong_hieu" runat="server" class="input-add">

                </td>
            </tr>
            <tr>
                <td>Giá</td>
                <td><input type="text" id="price_pro" name="price_pro" runat="server" class="input-add"></td>
            </tr>
            <tr>
                <td>Số Lượng</td>
                <td><input type="text" id="quantity_pro" name="quantity_pro"  runat="server" class="input-add"></td>
            </tr>
            <tr>
                <td>Hình Ảnh</td>
                <td id="image_sss" runat="server">
                    <button onclick="addFileImage()" type="button"
                        style="background-color: chartreuse; cursor: pointer; margin-bottom: 3px;">Thêm ảnh
                        nữa</button><br>
                    <input type="file" class="add-img" class="input-add" name="file0">
                    <div id="list_img_product" runat="server">
                        
                        
                    </div>
                    
                </td>
            </tr>
            <tr>
                <td>Mức Giảm Giá</td>
                <td><input type="text" id="sale_pro" runat="server" class="input-add"></td>
            </tr>
            <tr>
                <td>Loại sản phẩm</td>
                <td>
                    <select id="category_pro" name="category_pro">
                        <option value="QUAN_AO">Quần áo</option>
                        <option value="VAY_NU">Váy nữ</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>Mô tả ngắn</td>
                <td><textarea id="info_pro" runat="server" class="input-add"></textarea></td>
            </tr>
            <tr>
                <td>URL Sản Phẩm</td>
                <td><input type="text" id="url_pro" runat="server" class="input-add" ></td>
            </tr>
            <tr>
                <td></td>
                <td style="text-align: right;">
                    <button type="reset">Reset</button>
                    <button id="save" type="submit">Lưu</button>
                </td>
            </tr>
        </table>
    </form>

    </div>
    <div class="fade" onclick="btnClose(1)">
            </div>

