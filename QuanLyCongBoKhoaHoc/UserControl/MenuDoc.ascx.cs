using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyCongBoKhoaHoc.Business;
using QuanLyCongBoKhoaHoc.Entities;
using System.Data;

namespace QuanLyCongBoKhoaHoc.UserControl
{
    public partial class MenuDoc : System.Web.UI.UserControl
    {
        //public static string CodeGiangVien = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadData()
        {
            rptSach.DataSource = BSachXuatBan.SachXuatBan_GiangVien();
            rptSach.DataBind();
        }

        public string LoadGiangVien()
        {
            string code = "";
            DataTable dtGiangVien = new DataTable();
            dtGiangVien = BGiangVien.SelectAll();

            for (int i = 0; i < dtGiangVien.Rows.Count; i++)
            {
                if (i == 0)
                {
                    code += "<div class=\"item active\">";
                }
                else
                {
                    code += "<div class=\"item\">";
                }
             
                   code +=" <div class=\"row\">";
                      code +=" <div class=\"content-client\">";
                      code += "<div style=\"padding-bottom: 0px;\" class=\"mid-content\">";
                              code += "<p style=\"text-align: left;\"> Họ tên :" + dtGiangVien.Rows[i]["TenGiangVien"].ToString() + "</p>";
                              code += "<p style=\"text-align: left;\"> Khoa :" + dtGiangVien.Rows[i]["TenKhoa"].ToString() + "</p>";
                              code += "<p style=\"text-align: left;\"> Năm sinh :" + String.Format("{0:dd/MM/yyyy}", dtGiangVien.Rows[i]["NamSinh"]) + "</p>";
                              code += "<p style=\"text-align: left;\"> Quê quán :" + dtGiangVien.Rows[i]["QueQuan"].ToString() + "</p>";
                              code += "<p style=\"text-align: left;\"> Điện thoại :" + dtGiangVien.Rows[i]["DienThoai"].ToString() + "</p>";
                              code += "<p style=\"text-align: left;\"> Email :" + dtGiangVien.Rows[i]["Email"].ToString() + "</p>";
                           code +="</div>";
                             code +="<hr>";
                           code +="<div class=\"footer-content\">";
                              code +="<div class=\"client-img\">";
                              code += "<img style=\" width:160px;\" src=\"../../images/AnhGiangVien/" + dtGiangVien.Rows[i]["AnhDaiDien"].ToString() + "\" alt=\"client-img\">";
                              code +="</div>";
                             code +=" </div>";
                        code +="</div>";
                        code += "</div>";
                        code += "</div>";
            }
           return code;
        }



    }
}