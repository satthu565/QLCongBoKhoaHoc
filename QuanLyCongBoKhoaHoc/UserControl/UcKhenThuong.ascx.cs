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
    public partial class UcKhenThuong : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadKhenThuong();
        }

        void LoadKhenThuong()
        {
            int MaGiangVien = int.Parse(Session["MaGiangVien"].ToString());
            string Code = "";
            DataTable dt = new DataTable();

            dt = BKhenThuong.SelectByMaGiangVien(MaGiangVien);

            foreach (DataRow row in dt.Rows)
            {
                Code += "<p> <b> Tên khen thưởng :</b>" + row["TenKhenThuong"] + "<b> Số :</b> " + row["So"] + " <b> Năm nhân :</b>" + string.Format("{0:dd/MM/yyyy}", row["NamNhan"]) + "<p></br>";
            }
            if (Code =="")
            {
                Code += "Chưa nhập dữ liệu vào";
            }
            LbKhenThuong.Text = Code;
        }


        void ThongBao(string Loi)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "Thông báo!", "<script>alert('" + Loi + "')</script>", false);
        } 
    }
}