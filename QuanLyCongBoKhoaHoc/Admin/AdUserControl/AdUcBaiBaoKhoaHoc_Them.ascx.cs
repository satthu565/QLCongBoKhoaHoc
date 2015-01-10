
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
    public partial class AdUcBaiBaoKhoaHoc_Them : System.Web.UI.UserControl
    {
        public static string ChuoiMaGiangVienBaiBao = "";
        public string[] MaChuNhiem; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ChuoiMaGiangVienBaiBao = "-"+Session["MaGiangVien"].ToString();
                LoadData(txtTimKiem.Value.Trim());
            }
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

            BBaiBao.Insert(new EBaiBao {
                ChuoiMaGiangVienTacGia=ChuoiMaGiangVienBaiBao.Trim()+"-",
                GioiHan=bool.Parse(cbbGioiHan.SelectedValue),
                MaSo=txtMaSo.Value,
                NoiCongBo=txtNoiCongBo.Value,
                TenBaiBao=txtTenBaiBao.Value,
                TenTacGiaNgoai=txtTenGiangVienNgoai.Value,
                ThoiGianXuatBan= DateTime.Parse(txtThoiGianXuatBan.Value),
                FileMem = filename
            });
            Session["action"] = 1;
          //  ThongBao("Thêm thành công .. Tìm cách cho vào trang ad quản lý bài báo");
        }

        protected void btnTimKiemBB_Click(object sender, EventArgs e)
        {
            LoadData(txtTimKiem.Value.Trim());
        }

        void LoadData(string TenGiangVien)
        {
            gvGiangVien.AutoGenerateColumns = false;
            gvGiangVien.DataSource = BGiangVien.SelectTimKiemByTenGiangVien(TenGiangVien);
            gvGiangVien.DataBind();
        }

        protected void gvGiangVien_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvGiangVien.PageIndex = e.NewPageIndex;
            LoadData(txtTimKiem.Value.Trim());
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
                        ChuoiMaGiangVienBaiBao += "-" + gvGiangVien.DataKeys[i].Values[0].ToString();
                    }
                } 
            }
            catch
            {
                ThongBao("Dữ liệu liên quan đến một số bậc lương vẫn tồn tại, vui lòng kiểm tra lại dữ liệu!");
            }
            LoadData(txtTimKiem.Value.Trim());
            lbDanhSachChon.Text = DanhSachChon(ChuoiMaGiangVienBaiBao + "-");
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
                TenTG = BGiangVien.SelectByID(int.Parse(item)).TenGiangVien;
                AnhDaiDien = BGiangVien.SelectByID(int.Parse(item)).AnhDaiDien;
                hienthi += "<img src='/images/" + AnhDaiDien +"' height='50px' width='50px' /> <b> " + TenTG + " </b> "; 
            }
            return hienthi;
        }

        string HamXuLyChuoi(string ChuoiDau)
        {
            string s1 = ChuoiDau.Trim().Remove(0, 1);
            string s2 = s1.Remove(s1.Length - 1, 1);
            return s2;
        }

        protected void btnHuyDanhSach_Click(object sender, EventArgs e)
        {
            ChuoiMaGiangVienBaiBao = "";
        }


    }
}