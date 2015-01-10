using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyCongBoKhoaHoc.Business;

namespace QuanLyCongBoKhoaHoc.UserControl
{
    public partial class UcSachVaGiaoTrinh : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadSachVaGiaoTrinh();
        }

        void LoadSachVaGiaoTrinh()
        {
            int MaGiangVien = int.Parse(Session["MaGiangVien"].ToString());
            string Code = "";
            DataTable dt = new DataTable();

            dt = BSachXuatBan.SelectByMaGiangVien(MaGiangVien);

            foreach (DataRow row in dt.Rows)
            {
                Code += "<p> <b> Tên sách :</b>" + row["TenSach"] + "<b> Nhà xuất bản :</b> " + row["NhaXuatBan"] + " <b> Năm :</b>" + string.Format("{0:dd/MM/yyyy}", row["NamHoanThanh"]) + "<p></br>";
            }
            if (Code =="")
            {
                Code = "Chưa có giá trị sách và giáo trình";
            }
            LbSachVaGiaoTrinh.Text = Code;
        }


    }
}