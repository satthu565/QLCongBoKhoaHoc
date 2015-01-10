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
    public partial class UcDeTaiCongTrinhKhoaHoc : System.Web.UI.UserControl
    {
         string [] MaChuNhiem ;
         string [] MaThanhVien;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadCongTrinhKhoaHoc();
        }

        void LoadCongTrinhKhoaHoc()
        {
            string MaGiangVien = Session["MaGiangVien"].ToString();
            string CapTruong = "";
            string CapBo = "";
            string CapCoSo = "";
            string CapThanhPho = "";
            string CapNhaNuoc = "";
            string CapQuocGia = "";
            string Code="";

            DataTable dt = new DataTable();
            dt = BDanhSachCongBoKhoaHoc.SelectMaGiangVien2Cot(MaGiangVien);
            foreach (DataRow row in dt.Rows)
            {
                string TenChuNhiem = "";
                string TenThanhVien = "";
                string TenCN = "";
                string MaChuNhiemChuan = HamXuLyChuoi(row["ChuoiMaGiangVienChuNhiem"].ToString());  // ko con day '-' o dau va cuoi
                MaChuNhiem = MaChuNhiemChuan.Split('-');

                foreach (var item1 in MaChuNhiem)
                {
                    TenCN = BGiangVien.SelectByID(int.Parse(item1)).TenGiangVien;
                    TenChuNhiem += TenCN + ",";
                }

                string MaThanhVienChuan = HamXuLyChuoi(row["ChuoiMaThanhVienThamGia"].ToString());  // ko con day '-' o dau va cuoi
                MaThanhVien = MaThanhVienChuan.Split('-');

                foreach (var item2 in MaThanhVien)
                {
                    string TenTV = BGiangVien.SelectByID(int.Parse(item2)).TenGiangVien;
                    TenThanhVien += TenTV + ",";
                }
                // cấp trường
                if (row["TenCapDeTai"].ToString() == "Cấp trường")
               {
                   CapTruong += " <a href=\"/CV-Giang-Vien/YKienTraoDoi/CongBo/" + row["MaCongTrinhKhoaHoc"] + "\">  <b>" + row["TenCongTrinh"] + " </b> </a> .<b> Chủ nhiệm: </b>" + TenChuNhiem + ", Tên chủ nhiêm ngoài: " + row["TenChuNhiemNgoai"] + ".<b> Thành viên: </b>" + TenThanhVien + "" + row["TenThanhVienNgoai"] + " <b>  Số: </b>" + row["MaSo"] + " <b> Năm: </b>" + String.Format("{0:dd/MM/yyyy}", row["NamCongBo"]) + ". <br/>";
               }

                if (row["TenCapDeTai"].ToString() == "Cấp bộ")
                {
                    CapBo += " <a href=\"/CV-Giang-Vien/YKienTraoDoi/CongBo/" + row["MaCongTrinhKhoaHoc"] + "\">  <b>" + row["TenCongTrinh"] + " </b> </a> .<b> Chủ nhiệm: </b>" + TenChuNhiem + ", Tên chủ nhiêm ngoài: " + row["TenChuNhiemNgoai"] + ".<b> Thành viên: </b>" + TenThanhVien + "" + row["TenThanhVienNgoai"] + " <b>  Số: </b>" + row["MaSo"] + "  <b> Năm: </b> " + String.Format("{0:dd/MM/yyyy}", row["NamCongBo"]) + ". <br/>";
                }
                if (row["TenCapDeTai"].ToString() == "Cấp cơ sở")
                {
                    CapCoSo += " <a href=\"/CV-Giang-Vien/YKienTraoDoi/CongBo/" + row["MaCongTrinhKhoaHoc"] + "\">  <b>" + row["TenCongTrinh"] + " </b> </a> .<b> Chủ nhiệm: </b>" + TenChuNhiem + ", Tên chủ nhiêm ngoài: " + row["TenChuNhiemNgoai"] + ".<b> Thành viên: </b>" + TenThanhVien + "" + row["TenThanhVienNgoai"] + " <b>  Số: </b>" + row["MaSo"] + " <b> Năm: </b>" + String.Format("{0:dd/MM/yyyy}", row["NamCongBo"]) + ". <br/>";
                }
                if (row["TenCapDeTai"].ToString() == "Cấp thành phố")
                {
                    CapThanhPho += " <a href=\"/CV-Giang-Vien/YKienTraoDoi/CongBo/" + row["MaCongTrinhKhoaHoc"] + "\">  <b>" + row["TenCongTrinh"] + " </b> </a> .<b> Chủ nhiệm: </b>" + TenChuNhiem + ", Tên chủ nhiêm ngoài: " + row["TenChuNhiemNgoai"] + ".<b> Thành viên: </b>" + TenThanhVien + "" + row["TenThanhVienNgoai"] + " <b>  Số: </b>" + row["MaSo"] + " <b> Năm: </b>" + String.Format("{0:dd/MM/yyyy}", row["NamCongBo"]) + ". <br/>";
                }
                if (row["TenCapDeTai"].ToString() == "Cấp nhà nước")
                {
                    CapNhaNuoc += " <a href=\"/CV-Giang-Vien/YKienTraoDoi/CongBo/" + row["MaCongTrinhKhoaHoc"] + "\">  <b>" + row["TenCongTrinh"] + " </b> </a> .<b> Chủ nhiệm: </b>" + TenChuNhiem + ", Tên chủ nhiêm ngoài: " + row["TenChuNhiemNgoai"] + ".<b> Thành viên: </b>" + TenThanhVien + "" + row["TenThanhVienNgoai"] + " <b>  Số: </b>" + row["MaSo"] + "  <b> Năm: </b>" + String.Format("{0:dd/MM/yyyy}", row["NamCongBo"]) + ". <br/>";
                }
                if (row["TenCapDeTai"].ToString() == "Cấp quốc gia")
                {
                    CapQuocGia += " <a href=\"/CV-Giang-Vien/YKienTraoDoi/CongBo/" + row["MaCongTrinhKhoaHoc"] + "\">  <b>" + row["TenCongTrinh"] + "  </b> </a> .<b> Chủ nhiệm: </b>" + TenChuNhiem + ", Tên chủ nhiêm ngoài: " + row["TenChuNhiemNgoai"] + ".<b> Thành viên: </b>" + TenThanhVien + "" + row["TenThanhVienNgoai"] + " <b>  Số: </b>" + row["MaSo"] + " <b> Năm: </b>" + String.Format("{0:dd/MM/yyyy}", row["NamCongBo"]) + ". <br/>";
                }

            }
            if (CapTruong !="")
            {
                Code += "<h4> Cấp trường </h4>" + CapTruong;
            }
            if (CapBo != "")
            {
                Code += "<h4> Cấp bộ </h4>" + CapTruong;
            }
            if (CapCoSo != "")
            {
                Code += "<h4> Cấp cơ sở </h4>" + CapTruong;
            }
            if (CapThanhPho != "")
            {
                Code += "<h4> Cấp thành phố </h4>" + CapTruong;
            }
            if (CapNhaNuoc != "")
            {
                Code += "<h4> Cấp nhà nước </h4>" + CapTruong;
            }
            if (CapQuocGia != "")
            {
                Code += "<h4> Cấp quốc gia </h4>" + CapTruong;
            }  
            LbCongTrinhKhoaHoc.Text = Code; 
        }

        //xoa ky tu dau va cuoi '-' 
        string HamXuLyChuoi(string ChuoiDau)
        {        
            string s1 = ChuoiDau.Trim().Remove(0, 1);
            string s2 = s1.Remove(s1.Length - 1, 1);
            return s2;
        }

    }
}