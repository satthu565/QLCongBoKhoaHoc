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
    public partial class UcGiaiThuongKhoaHoc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGiaiThuongKhoaHoc();
        }

        void LoadGiaiThuongKhoaHoc()
        {
            int MaGiangVien = int.Parse(Session["MaGiangVien"].ToString());
            string Code = "";
            DataTable dt = new DataTable();

            dt = BGiaiThuongKhoaHoc.SelectByMaGiangVien(MaGiangVien);

            foreach (DataRow row in dt.Rows)
            {
                Code += "<p> <b> Tên giải thưởng :</b>" + row["TenGiaiThuong"] +"<b>Lĩnh vực : </b>"+row["LinhVuc"]+"<b>Nơi cấp : </b>"+row["NoiCap"]+"<b> Mã Số :</b> " + row["So"] + " <b> Năm nhận :</b>" + string.Format("{0:dd/MM/yyyy}", row["NamNhan"]) + "<p></br>";
            }
            if (Code == "")
            {
                Code += "Chưa nhập dữ liệu vào";
            }
            LbGiaiThuongKhoaHoc.Text = Code;
        }


        void ThongBao(string Loi)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "Thông báo!", "<script>alert('" + Loi + "')</script>", false);
        } 
    }
}