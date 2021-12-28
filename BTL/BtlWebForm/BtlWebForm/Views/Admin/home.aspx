<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/WebAdmin.Master" CodeBehind="home.aspx.cs" Inherits="BtlWebForm.Views.Admin.home" %>
<asp:Content ContentPlaceHolderID="AdminBody" runat="server">
        
   

        <div class="right-admin-container">
            <a href="admin/add-product">Thêm sản phẩm</a>


            <h3>Danh sách sản phẩm</h3>

            <table id="table-product">
                <thead>
                    <tr>
                        <td class="name-pro">Tên sản phẩm</td>
                        <td class="price-pro ">Giá</td>
                        <td class="quantity-pro ">Số lượng</td>
                        <td class="image-pro ">Hình ảnh</td>
                        <td class="sale-pro">Mức giảm giá</td>
                        <td class="link-pro ">Link</td>
                        <td class="edit-pro ">Chỉnh sửa</td>
                    </tr>
                </thead>
                <tbody id="list_pro">
                </tbody>
            </table>
        </div>


        <!-- form user -->
        <div class="right-admin-container" style="display: none;">
            <h3>Danh sách nguời dùng trong hệ thống</h3>
            <table id="table-user" border="1">
                <thead>
                    <tr>
                        <td>ID</td>
                        <td >Tên đăng nhập</td>
                        <td >Họ tên</td>
                        <td >Số điện thoai</td>
                        <td >Địa chỉ</td>
                        <td >Quyền</td>
                    </tr>
                </thead>
                <tbody id="list_user">
                    
                </tbody>
            </table>
        </div>


        <!-- form order -->
        <div class="right-admin-container" style="display: none;">
            <h3>Danh sách đơn hàng</h3>
            <table id="table-order" border="1">
                <thead>
                    <tr>
                        <td >Mã đơn</td>
                        <td >Mã khách hàng</td>
                        <td >Sản phẩm mua</td>
                        <td >Tổng tiền sản phẩm</td>
                        <td >Số tiền được giảm</td>
                        <td >Tổng tiền đơn hàng</td>
                        <td>Ngày đặt</td>
                        <td >Ghi chú</td>
                    </tr>
                </thead>
                <tbody id="list_order">
                    
                </tbody>
            </table>
        </div>
  
 
</asp:Content>