using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyCongBoKhoaHoc.Business;
using QuanLyCongBoKhoaHoc.Entities;

namespace QuanLyCongBoKhoaHoc.Admin.AdUserControl
{
    public partial class AdUcBaiBaoKhoaHoc_Sua : System.Web.UI.UserControl
    {
        public static string ChuoiMaGiangVienBaiBao = "-";
        public string[] MaChuNhiem;
        int idMaBaiBao;

        protected void Page_Load(object sender, EventArgs e)
        {   
            if (Session["MaBaiBao"] != null)
            {
                if (!IsPostBack)
                {
                    LoadData();
                } 
                idMaBaiBao = int.Parse(Session["MaBaiBao"].ToString());
                lbTieuDeThemSua.Text = "SỬA BÀI BÁO KHOA HỌC";
                btnThemBaiBao.Visible = false;
                btnSuaBaiBao.Visible = true;
            }
            else
            {
                lbTieuDeThemSua.Text = "THÊM BÀI BÁO KHOA HỌC";
                btnThemBaiBao.Visible = true;
                btnSuaBaiBao.Visible = false;
            }
            if (!IsPostBack)
            {
                ChuoiMaGiangVienBaiBao = ChuoiMaGiangVienBaiBao + Session["MaGiangVien"].ToString() + "-"; 
            }
        }

        void LoadData()
        {
            if (Session["MaBaiBao"] != null)
            {
                idMaBaiBao = int.Parse(Session["MaBaiBao"].ToString());
                EBaiBao BaiBao = BBaiBao.SelectByID(idMaBaiBao);
                txtNoiCongBo.Value = HttpUtility.HtmlDecode(BaiBao.NoiCongBo);
                txtTenBaiBao.Value = HttpUtility.HtmlDecode(BaiBao.TenBaiBao);
                txtNoiDungBaiBaoTomTat.Value = HttpUtility.HtmlDecode(BaiBao.NoiDungTomTat);
                txtTenGiangVienNgoai.Value = HttpUtility.HtmlDecode(BaiBao.TenTacGiaNgoai);
                txtThoiGianXuatBan.Value = BaiBao.ThoiGianXuatBan.ToString("dd/MM/yyyy");
                txtMaSo.Value = HttpUtility.HtmlDecode(BaiBao.MaSo);
                cbbGioiHan.SelectedValue = BaiBao.GioiHan.ToString() ;
                lbDanhSachChon.Text = DanhSachChon(BaiBao.ChuoiMaGiangVienTacGia); // đổi ra tên
                ChuoiMaGiangVienBaiBao = BaiBao.ChuoiMaGiangVienTacGia;
                lbFileMemHienTai.Text = BaiBao.FileMem;
                txtNoiXuatBan.Value = BaiBao.NoiXuatBan;
            }
        }


        protected void btnTimKiemBB_Click(object sender, EventArgs e)
        {     
            int MaGiangVien = int.Parse(Session["MaGiangVien"].ToString());
            gvGiangVien.AutoGenerateColumns = false;
            gvGiangVien.DataSource = BGiangVien.SelectTimKiemByTenGiangVienLoaiMaGiangVien(txtTimKiem.Value,MaGiangVien);
            gvGiangVien.DataBind();
        }


        protected void gvGiangVien_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvGiangVien.PageIndex = e.NewPageIndex;
            LoadGridview(txtTimKiem.Value.Trim());
        }

        void ThongBao(string Loi)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "Thông báo!", "<script>alert('" + Loi + "')</script>", false);
        }

        protected void btnThemDanhSach_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gvGiangVien.Rows.Count; i++)
                {
                    CheckBox cbChon = (CheckBox)gvGiangVien.Rows[i].Cells[0].FindControl("cbChon");
                    if (cbChon != null && cbChon.Checked)
                    {
                        ChuoiMaGiangVienBaiBao += gvGiangVien.DataKeys[i].Values[0].ToString() + "-";
                    }
                }  
            }
            catch
            {
                ThongBao("Kiểm tra lại phần admin bài báo");
            }
            lbDanhSachChon.Text = DanhSachChon(ChuoiMaGiangVienBaiBao);
        }

        void LoadGridview(string TenGiangVien)
        {
            int MaGiangVien = int.Parse(Session["MaGiangVien"].ToString());
            gvGiangVien.AutoGenerateColumns = false;
            gvGiangVien.DataSource = BGiangVien.SelectTimKiemByTenGiangVienLoaiMaGiangVien(txtTimKiem.Value, MaGiangVien);
            gvGiangVien.DataBind();
        }

        protected void btnHuyDanhSach_Click(object sender, EventArgs e)
        {
            ChuoiMaGiangVienBaiBao = "-"+ Session["MaGiangVien"].ToString() + "-";
            lbDanhSachChon.Text = "";
        }

        public string DanhSachChon(string chuoi)
        {
            string hienthi = "";
            string TenTG = "";
            string AnhDaiDien = "";
            string MaChuNhiemChuan = HamXuLyChuoi(chuoi);  // ko con day '-' o dau va cuoi
            MaChuNhiem = MaChuNhiemChuan.Split('-');
            foreach (var item in MaChuNhiem)
            {
                string kt = item.ToString();
                TenTG = BGiangVien.SelectByID(int.Parse(item)).TenGiangVien;
                AnhDaiDien = BGiangVien.SelectByID(int.Parse(item)).AnhDaiDien;
                hienthi += "<img src='/images/AnhGiangVien/" + AnhDaiDien + "' height='50px' width='50px' /> <b> " + TenTG + " </b> ";
            }
            return hienthi;
        }

        string HamXuLyChuoi(string ChuoiDau)
        {
            string s1 = ChuoiDau.Trim().Remove(0, 1);
            string s2 = s1.Remove(s1.Length - 1, 1);
            return s2;
        }


        protected void btnThemBaiBao_Click(object sender, EventArgs e)
        {
            string filename;
            if (FileUpload1.HasFile == false)
            {
                filename = "";
            }
            else
            {
                filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + FileUpload1.FileName;
                string path = Server.MapPath("~/FileMem/" + filename);
                FileUpload1.SaveAs(path);
            }

            BBaiBao.Insert(new EBaiBao
            {
                ChuoiMaGiangVienTacGia = ChuoiMaGiangVienBaiBao.Trim(),
                GioiHan = bool.Parse(cbbGioiHan.SelectedValue),
                MaSo = txtMaSo.Value,
                NoiCongBo = txtNoiCongBo.Value,
                TenBaiBao = txtTenBaiBao.Value,
                TenTacGiaNgoai = txtTenGiangVienNgoai.Value,
                ThoiGianXuatBan = DateTime.Parse(txtThoiGianXuatBan.Value),
                NoiDungTomTat = txtNoiDungBaiBaoTomTat.Value,
                FileMem = filename,
                NoiXuatBan = txtNoiXuatBan.Value
            });
            Session["action"] = 1 ;
        }

        protected void btnSuaBaiBao_Click(object sender, EventArgs e)
        {

            if (FileUpload1.HasFile == false)
            {
                BBaiBao.Update(new EBaiBao
                {
                    ChuoiMaGiangVienTacGia = ChuoiMaGiangVienBaiBao,
                    GioiHan = bool.Parse(cbbGioiHan.SelectedValue),
                    MaBaiBao = idMaBaiBao,
                    MaSo = txtMaSo.Value,
                    NoiCongBo = txtNoiCongBo.Value,
                    TenBaiBao = txtTenBaiBao.Value,
                    TenTacGiaNgoai = txtTenGiangVienNgoai.Value,
                    ThoiGianXuatBan = DateTime.Parse(txtThoiGianXuatBan.Value),
                    NoiDungTomTat = txtNoiDungBaiBaoTomTat.Value,
                    FileMem = lbFileMemHienTai.Text,
                    NoiXuatBan = txtNoiXuatBan.Value
                });
            }
            else
            {
                string filename = "";
                filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + FileUpload1.FileName;
                string path = Server.MapPath("~/FileMem/" + filename);
                FileUpload1.SaveAs(path);

                BBaiBao.Update(new EBaiBao
                {
                    ChuoiMaGiangVienTacGia = ChuoiMaGiangVienBaiBao,
                    GioiHan = bool.Parse(cbbGioiHan.SelectedValue),
                    MaBaiBao = idMaBaiBao,
                    MaSo = txtMaSo.Value,
                    NoiCongBo = txtNoiCongBo.Value,
                    TenBaiBao = txtTenBaiBao.Value,
                    TenTacGiaNgoai = txtTenGiangVienNgoai.Value,
                    ThoiGianXuatBan = DateTime.Parse(txtThoiGianXuatBan.Value),
                    NoiDungTomTat = txtNoiDungBaiBaoTomTat.Value,
                    FileMem = filename,
                    NoiXuatBan = txtNoiXuatBan.Value
                });
            }
            Session["action"] = 2;
        }

    }
}