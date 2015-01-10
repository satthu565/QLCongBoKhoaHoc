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
    public partial class AdUserThongTinCaNhan : System.Web.UI.UserControl
    {

        static int MaGiangVien;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MaGiangVien"] != null)
            {
                MaGiangVien = int.Parse(Session["MaGiangVien"].ToString());
                LoadThongTinCaNhan(MaGiangVien);
                LoadCacCBB();
          
                if (!IsPostBack)
                {
                    LoadTextbox(MaGiangVien);
                }
                
            }
        }

        public string GioiTinh (bool GioiTinh)
        {
            if (GioiTinh == true)
            {
                return "Nam";
            }
            return "Nữ";
        }
        void LoadThongTinCaNhan(int MaGiangVien)
        {
            rpThongTinCaNhan.DataSource = BGiangVien.SelectLyLichByMaGiangVien(MaGiangVien);
            rpThongTinCaNhan.DataBind();
        }

        void LoadTextbox(int MaGiangVien)
        {
            EGiangVien Giangvien = BGiangVien.SelectByID(MaGiangVien);
            AnhDaiDien.ImageUrl = "~/images/AnhGiangVien/" + Giangvien.AnhDaiDien;
            txtHoTen.Value = Giangvien.TenGiangVien;
            txtNgaySinh.Value = String.Format("{0:dd/MM/yyyy}", Giangvien.NamSinh.ToString());
            if(Giangvien.GioiTinh == true)
            {
                RbNam.Checked = true;
            }
            else if (Giangvien.GioiTinh == false)
            {
                RbNu.Checked = true;
            }
            txtDanToc.Value = Giangvien.DanToc;
            txtQueQuan.Value = Giangvien.QueQuan;
            txtSoDienThoai.Value = Giangvien.DienThoai;
            txtDayChuyenNganh.Value = Giangvien.DayCN;
            txtLinhVucNghienCuu.Value = Giangvien.LinhVucNC;
            txtEmail.Value = Giangvien.Email;

            if (Giangvien.MaChucVu.ToString() !=null)
            {
                cbbChucVu.SelectedValue = Giangvien.MaChucVu.ToString();
            }
            if (Giangvien.MaHocVi.ToString() != null)
            {
                cbbHocVi.SelectedValue = Giangvien.MaHocVi.ToString();
            }
            if (Giangvien.MaKhoa.ToString() != null)
            {
                cbbKhoa.SelectedValue = Giangvien.MaKhoa.ToString();
            }
           
            txtChuyenNganhDaiHoc.Value = Giangvien.ChuyenNganhDaiHoc;
            if (Giangvien.NamTotNghiepDaiHoc.ToString() !=null)
            {
            txtNamTotNghiepDaiHoc.Value = Giangvien.NamTotNghiepDaiHoc.ToString("dd/MM/yyyy");
            }
            txtTruongDaiHoc.Value = Giangvien.TruongDaiHoc;
            txtChuyenNganhHocVi.Value = Giangvien.ChuyenNganhHocVi;
            if (Giangvien.NamTotNghiepHocVi.ToString() !=null)
            {
                txtNamTotNghiepHocVi.Value = Giangvien.NamTotNghiepHocVi.ToString("dd/MM/yyyy");
            } 
            txtTruongHocVi.Value = Giangvien.TruongHocVi;
        }


        // load các dropdow list nhá
        void LoadCacCBB()
        { 
            // Chức vụ
            cbbChucVu.DataSource = BChucVu.SelectAll();
            cbbChucVu.DataTextField="TenChucVu";
            cbbChucVu.DataValueField ="MaChucVu";
            cbbChucVu.DataBind();
            // Học vị
            cbbHocVi.DataSource = BHocVi.SelectAll();
            cbbHocVi.DataTextField="TenHocVi";
            cbbHocVi.DataValueField="MaHocVi";
            cbbHocVi.DataBind();
            // Khoa
            cbbKhoa.DataSource = BKhoa.SelectAll();
            cbbKhoa.DataTextField="TenKhoa";
            cbbKhoa.DataValueField="MaKhoa";
            cbbKhoa.DataBind();
        }
      

        void ThongBao(string Loi)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "Thông báo!", "<script>alert('" + Loi + "')</script>", false);
        }

        private bool KiemTra()
        {
            if (txtHoTen.Value == "")
            {
                ThongBao("không được để trống họ têm");
                return false;
            }
      
            return true;
        }

        bool GioiTinh()
        {
            if (RbNam.Checked) 
              return true;
            else 
              return false;
        }

        protected void btnSua_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile == false)
            {
                if (AnhDaiDien.ImageUrl != "")
                {
                    string AnhDaiDienCu = BGiangVien.SelectByID(MaGiangVien).AnhDaiDien;
                    BGiangVien.Update(new EGiangVien
                    {
                       AnhDaiDien = AnhDaiDienCu,
                       DanToc=txtDanToc.Value,
                       DayCN=txtDayChuyenNganh.Value,
                       DienThoai=txtSoDienThoai.Value,
                       Email=txtEmail.Value,
                       GioiTinh= GioiTinh(),
                       MaChucVu=int.Parse(cbbChucVu.SelectedValue.ToString()),
                       MaGiangVien=MaGiangVien,
                       MaHocVi=int.Parse(cbbHocVi.SelectedValue.ToString()),
                       MaKhoa=int.Parse(cbbKhoa.SelectedValue.ToString()),
                       NamSinh=DateTime.Parse(txtNgaySinh.Value),
                       NoiSinh=txtNoiSinh.Value,
                       QueQuan=txtQueQuan.Value,
                       TenGiangVien=txtHoTen.Value,
                       LinhVucNC = txtLinhVucNghienCuu.Value
                    });
                    Session["action"] = 2;
                }

            }
            else
            {
                try
                {
                    if (KiemTra() == true)
                    {
                        string filename = "";
                        filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + FileUpload1.FileName;
                        string path = Server.MapPath("~/images/AnhGiangVien/" + filename);
                        FileUpload1.SaveAs(path);
                        
                        BGiangVien.Update(new EGiangVien
                        {
                            AnhDaiDien = filename,
                            DanToc = txtDanToc.Value,
                            DayCN = txtDayChuyenNganh.Value,
                            DienThoai = txtSoDienThoai.Value,
                            Email = txtEmail.Value,
                            GioiTinh = GioiTinh(),
                            MaChucVu = int.Parse(cbbChucVu.SelectedValue.ToString()),
                            MaGiangVien = MaGiangVien,
                            MaHocVi = int.Parse(cbbHocVi.SelectedValue.ToString()),
                            MaKhoa = int.Parse(cbbKhoa.SelectedValue.ToString()),
                            NamSinh = DateTime.Parse(txtNgaySinh.Value),
                            NoiSinh = txtNoiSinh.Value,
                            QueQuan = txtQueQuan.Value,
                            TenGiangVien = txtHoTen.Value,
                            LinhVucNC = txtLinhVucNghienCuu.Value
                        });
                        Session["action"] = 2;
                    }
                }
                catch
                {
                }
            }
            MaGiangVien = int.Parse(Session["MaGiangVien"].ToString());
            LoadTextbox(MaGiangVien);
            LoadThongTinCaNhan(MaGiangVien);
        }

        // xóa trắng các ôtext
        protected void btnHuy_Click(object sender, EventArgs e)
        {

        }

        protected void btnSuaThongTinCongTac_Click(object sender, EventArgs e)
        {
            BGiangVien.UpdateHoc(new EGiangVien
            {
                NamTotNghiepDaiHoc= DateTime.Parse(txtNamTotNghiepDaiHoc.Value),
                ChuyenNganhDaiHoc = txtChuyenNganhDaiHoc.Value,
                TruongDaiHoc = txtTruongDaiHoc.Value,
                NamTotNghiepHocVi = DateTime.Parse(txtNamTotNghiepHocVi.Value),
                ChuyenNganhHocVi = txtChuyenNganhHocVi.Value,
                TruongHocVi = txtTruongHocVi.Value,
                MaGiangVien = int.Parse(Session["MaGiangVien"].ToString())
            });
            Session["action"] = 2;
        }

        protected void btnHuyThongTinCongTac_Click(object sender, EventArgs e)
        {

        }




    }
}