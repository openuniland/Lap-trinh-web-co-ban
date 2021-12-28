<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/WebAdmin.Master" CodeBehind="addproduct.aspx.cs" Inherits="BtlWebForm.Views.Common.addproduct" %>
<asp:Content ContentPlaceHolderID="head" runat="server">
    <style>
    body{
            overflow-y: hidden;
        }
        </style>
</asp:Content>
<asp:Content ContentPlaceHolderID="AdminBody" runat="server">
  
<div class="right-admin-container">

            <div class="post">
                <form action="/admin/add-product" method="POST" enctype="multipart/form-data" class="form_edit_overflow">
                    <h2>Phần thông tin sản phẩm</h2>

                    <table id="table-add">
                        <tr>
                            <td width="120px">Tên sản phẩm</td>
                            <td width="600px">
                                <input type="text" id="name_pro" name="name_pro" oninput="gen()" runat="server"
                                    class="input-add">

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
                            <td><input type="text" id="price_pro" name="price_pro" runat="server" class="input-add">
                            </td>
                        </tr>
                        <tr>
                            <td>Số Lượng</td>
                            <td><input type="text" id="quantity_pro" name="quantity_pro" runat="server"
                                    class="input-add"></td>
                        </tr>
                        <tr>
                            <td>Các hình ảnh</td>
                            <td id="image_sss" runat="server">
                                <input type="file" title="Bạn có thể chọn nhiều file" name="file" multiple class="add-img"
                                    class="input-add">
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
                                    <option value="QUAN_AO" selected>Quần áo</option>
                                    <option value="VAY_NU">Váy nữ</option>
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td>Thông tin sản phẩm / Mô tả ngắn</td>
                            <td><textarea id="info_pro" runat="server" class="input-add" rows="5"></textarea></td>
                        </tr>
                        <tr>
                            <td>URL Sản Phẩm</td>
                            <td><input type="text" id="url_pro" runat="server" class="input-add"></td>
                        </tr>

                    </table>

                    <!-- post -->
                    <h2>Phần bài viết</h2>

                    <div id="post" name="a">
                        <button type="button" onclick="addParagraph()" id="btn-add-para">Thêm đoạn văn</button>
                        <fieldset class="paragraph">
                            <legend class="index">
                                <button type="button" onclick="removeParagraph(this)">Xóa đoạn văn
                                    này</button>
                            </legend>
                            <br><br>
                            <input type="text" placeholder="Nhập tiêu đề đoạn văn" class="paragraph_title">
                            <textarea name="paragraph1" id="" cols="30" rows="10" class="paragraph_content" placeholder="
                                Nội dung đoạn văn"></textarea><br>
                            Chọn ảnh hiển thị trong đoạn văn: <input type="file" name="imgPost1" class="paragraph_file">
                        </fieldset>

                    </div>
                    <div class="btn_form">
                        <button type="button" onclick="resetForm()">Reset</button>
                        <button id="save" type="button" onclick="saveProduct()">Lưu</button>
                    </div>
                    <div id="ak">

                    </div>
                </form>

            </div>

        </div>
    </asp:Content>