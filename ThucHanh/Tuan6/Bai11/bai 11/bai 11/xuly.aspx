<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="xuly.aspx.cs" Inherits="bai_11.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
          background-color: #ccc;
          font-size: 16px;
          font-weight: 400;
        }

        div.table-title {
          display: block;
          margin: auto;
          max-width: 600px;
          padding:5px;
          width: 100%;
        }

        .table-title h3 {
           color: #fafafa;
           font-size: 30px;
           font-weight: 400;
           font-style:normal;
           text-transform:uppercase;
        }


        /*** Table Styles **/

        .table-fill {
          background: white;
          border-radius:3px;
          border-collapse: collapse;
          min-height: 300px;
          margin: auto;
          max-width: 600px;
          padding:5px;
          width: 100%;
          box-shadow: 0 5px 10px rgba(0, 0, 0, 0.1);
          animation: float 5s infinite;
        }
 
        th {
          color:#D5DDE5;;
          background:#1b1e24;
          border-bottom:4px solid #9ea7af;
          border-right: 1px solid #343a45;
          font-size:23px;
          font-weight: 100;
          padding:24px;
          text-align:left;
          text-shadow: 0 1px 1px rgba(0, 0, 0, 0.1);
          vertical-align:middle;
        }

        th:first-child {
          border-top-left-radius:3px;
        }
 
        th:last-child {
          border-top-right-radius:3px;
          border-right:none;
        }
  
        tr {
          border-top: 1px solid #C1C3D1;
          border-bottom-: 1px solid #C1C3D1;
          color:#666B85;
          font-size:16px;
          font-weight:normal;
          text-shadow: 0 1px 1px rgba(256, 256, 256, 0.1);
        }
 
        tr:hover td {
          background:#4E5066;
          color:#FFFFFF;
          border-top: 1px solid #22262e;
        }
 
        tr:first-child {
          border-top:none;
        }

        tr:last-child {
          border-bottom:none;
        }
 
        tr:nth-child(odd) td {
          background:#EBEBEB;
        }
 
        tr:nth-child(odd):hover td {
          background: hotpink;
        }

        tr:last-child td:first-child {
          border-bottom-left-radius:3px;
        }
 
        tr:last-child td:last-child {
          border-bottom-right-radius:3px;
        }
 
        td {
          background:#FFFFFF;
          padding:20px;
          text-align:left;
          vertical-align:middle;
          font-weight:300;
          font-size:18px;
          text-shadow: -1px -1px 1px rgba(0, 0, 0, 0.1);
          border-right: 1px solid #C1C3D1;
        }

        td:last-child {
          border-right: 0px;
        }

        th.text-left {
          text-align: left;
        }

        th.text-center {
          text-align: center;
        }

        th.text-right {
          text-align: right;
        }

        td.text-left {
          text-align: left;
        }

        td.text-center {
          text-align: center;
        }

        td.text-right {
          text-align: right;
        }

        form a{
            text-decoration: none;
            padding: 10px 20px;
            background-color: hotpink;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="table-title">
        <h3>Danh sách</h3>
        </div>
        <table class="table-fill">
            <thead>
                <tr>
                    <th class="text-left">Họ tên</th>
                    <th class="text-left text-left-namsinh">Nam sinh</th>
                </tr>
            </thead>
            <tbody class="table-hover" id="viewDanhSach" runat="server">
            </tbody>
        </table>
        <a href="Myform.html">BackForm</a>
    </form>
</body>
</html>
