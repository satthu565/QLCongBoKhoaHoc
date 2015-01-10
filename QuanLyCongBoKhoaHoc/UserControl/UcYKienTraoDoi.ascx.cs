using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyCongBoKhoaHoc.Entities;
using QuanLyCongBoKhoaHoc.Business;

namespace QuanLyCongBoKhoaHoc.UserControl
{
    public partial class UcYKienTraoDoi : System.Web.UI.UserControl
    {
        string[] MaTacGia;
        public int kt = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadData()
        {
            string DoiTuong ="";

            if (Session["DoiTuong"] != null)
            {
                DoiTuong = Session["DoiTuong"].ToString();
            }
            if (DoiTuong == "BaiBao")
            {
                int MaBaiBao = int.Parse(Session["MaTieuDeYKien"].ToString());
                EBaiBao BaiBao = BBaiBao.SelectByID(MaBaiBao);
                lbTenTieuDe.Text = BaiBao.TenBaiBao;
                lbTenTacGia.Text = DoiChuoiMaTacGia(BaiBao.ChuoiMaGiangVienTacGia) + BaiBao.TenTacGiaNgoai;
                lbMaSo.Text = BaiBao.MaSo;
                lbNoiDang.Text = BaiBao.NoiCongBo;
                lbNam.Text = BaiBao.ThoiGianXuatBan.ToString("dd/MM/yyyy");
                string tomt = BaiBao.NoiDungTomTat; ;
                lbTomTat.Text = BaiBao.NoiDungTomTat;
            }
            if (DoiTuong == "CongBo")
            {
                int MaCongBo = int.Parse(Session["MaTieuDeYKien"].ToString());
                EDanhSachCongBoKhoaHoc CongBo = BDanhSachCongBoKhoaHoc.SelectByID(MaCongBo);
                lbTenTieuDe.Text = CongBo.TenCongTrinh;
                lbTenTacGia.Text = DoiChuoiMaTacGia(CongBo.ChuoiMaGiangVienChuNhiem) + CongBo.TenChuNhiemNgoai;
                lbMaSo.Text = CongBo.MaSo;
                lbNoiDang.Text = CongBo.NoiCongBo;
                lbNam.Text = CongBo.NamCongBo.ToString("dd/MM/yyyy");
                TomTat.Visible = false;
                lbTomTat.Visible = false;
            }
            if (DoiTuong == "TinNhanRieng")
            {
                kt = 1;
                lbTenTieuDe.Text = "Tin nhắn riêng";
            } 
        }
        

      //xoa ky tu dau va cuoi '-' 
        string HamXuLyChuoi(string ChuoiDau)
        {
            string s1 = ChuoiDau.Trim().Remove(0, 1);
            string s2 = s1.Remove(s1.Length - 1, 1);
            return s2;
        }

        string DoiChuoiMaTacGia(string ChuoiMaTacGia)
        {
            string TenTG = "";
            string TenTacGia = "";
            string ChuoiMaTacGiaChuan = HamXuLyChuoi(ChuoiMaTacGia);  // ko con day '-' o dau va cuoi
            MaTacGia = ChuoiMaTacGiaChuan.Split('-');

            foreach (var item in MaTacGia)
            {
                TenTG = BGiangVien.SelectByID(int.Parse(item)).TenGiangVien;
                TenTacGia += TenTG + ",";
            }
            return TenTacGia;
        }

        protected void btnGuiYKien_Click(object sender, EventArgs e)
        {

            if (KiemTraLapTin() == true)
            {
                BLienHe.Insert(new ELienHe
                {
                    EmailNguoiGui = txtEmail.Value,
                    HoTenNguoiGui = txtHoTen.Value,
                    MaGiangVienNhan = int.Parse(Session["MaGiangVien"].ToString()),
                    NoiDung = txtNoiDungBinhLuan.Value,
                    TieuDe = txtTieuDeBinhLuan.Value,
                    TrangThai = false,
                    TieuDeBai= lbTenTieuDe.Text,
                    DoiTuong=Session["DoiTuong"].ToString(),
                    ThoiGian = DateTime.Now
                });
                ThongBao.Text = "Ý kiến của bạn đã được gửi thành công";
            }
            else
            {
                ThongBao.Text = "Ý kiến đã được gửi đi hoặc nhập thiếu trường";  
            }

        }

        // viết thêm các kiểm tra điều kiện
        bool KiemTraLapTin()
        {
            return true;
        }



    }
}