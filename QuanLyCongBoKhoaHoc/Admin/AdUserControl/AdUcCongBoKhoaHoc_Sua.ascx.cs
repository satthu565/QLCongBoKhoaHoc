using QuanLyCongBoKhoaHoc.Business;
using QuanLyCongBoKhoaHoc.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLyCongBoKhoaHoc.Admin.AdUserControl
{
    public partial class AdUcCongBoKhoaHoc_Sua : System.Web.UI.UserControl
    {
        public static string ChuoiMaChuNhiemCongBo = "-";
        public static string ChuoiMaThanhVienCongBo = "-";
        public string[] MaChuNhiem;
        public string[] MaThanhVien;
        int idMaCongBoKhoaHoc;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MaCongBo"] != null)
            {
                if (!IsPostBack)
                {
                    LoadData();
                } 
                LoadCbbCapDeTai();
                lbTieuDeThemSua.Text = "SỬA CÔNG BỐ KHOA HỌC";
                idMaCongBoKhoaHoc = int.Parse(Session["MaCongBo"].ToString()); 
                btnThemCongBoKhoaHoc.Visible = false;
                BtnSuaCongBoKhoaHoc.Visible = true;
              
            }
            else
            {
                LoadCbbCapDeTai();
                lbTieuDeThemSua.Text = "THÊM CÔNG BỐ KHOA HỌC";
                btnThemCongBoKhoaHoc.Visible = true;
                BtnSuaCongBoKhoaHoc.Visible = false;
            }
            if (!IsPostBack)
            {
                ChuoiMaChuNhiemCongBo = ChuoiMaChuNhiemCongBo + Session["MaGiangVien"].ToString() + "-";
            }
        }

        void LoadCbbCapDeTai()
        {
            cbbCapDeTai.DataSource = BCapDeTai.SelectAll();
            cbbCapDeTai.DataTextField = "TenCapDeTai";
            cbbCapDeTai.DataValueField = "MaCapDeTai";
            cbbCapDeTai.DataBind();
        }

        void LoadData()
        {
            if (Session["MaCongBo"] != null)
            {
                idMaCongBoKhoaHoc = int.Parse(Session["MaCongBo"].ToString());
                EDanhSachCongBoKhoaHoc CongBo = BDanhSachCongBoKhoaHoc.SelectByID(idMaCongBoKhoaHoc);
                cbbCapDeTai.SelectedValue = CongBo.MaCapDeTai.ToString();
                txtMaSo.Value = HttpUtility.HtmlDecode(CongBo.MaSo);
                txtNamCongBo.Value = CongBo.NamCongBo.ToString("dd/MM/yyyy");
                txtNoiCongBo.Value = HttpUtility.HtmlDecode(CongBo.NoiCongBo);
                txtTenCongBo.Value = HttpUtility.HtmlDecode(CongBo.TenCongTrinh);
                cbbCapDeTai.SelectedValue = CongBo.MaCapDeTai.ToString();
                lbDanhSachChuNhiem.Text =  DanhSachChon(CongBo.ChuoiMaGiangVienChuNhiem);
                lbDanhSachThanhVien.Text = DanhSachChon(CongBo.ChuoiMaThanhVienThamGia);
                txtTenThanhVienNgoai.Value = HttpUtility.HtmlDecode(CongBo.TenThanhVienNgoai);
                txtTenChuNhiemNgoai.Value = HttpUtility.HtmlDecode(CongBo.TenChuNhiemNgoai);
                lbFileMemHienTai.Text = HttpUtility.HtmlDecode(CongBo.LinkFileMem);
                ChuoiMaChuNhiemCongBo = CongBo.ChuoiMaGiangVienChuNhiem;
                ChuoiMaThanhVienCongBo = CongBo.ChuoiMaThanhVienThamGia;
            }
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
                        if (RBChuNhiemCongBo.Checked)
                        {
                            ChuoiMaChuNhiemCongBo += gvGiangVien.DataKeys[i].Values[0].ToString()+"-";
                        }
                        else if (RBThanhVienCongBo.Checked)
                        {
                            ChuoiMaThanhVienCongBo += gvGiangVien.DataKeys[i].Values[0].ToString()+"-";
                        }
                        else
                        {
                            lbThongBaoChon.Text = "Phải chọn đối tượng danh sách";
                        }
                    }
                }
                if (ChuoiMaChuNhiemCongBo !="-")
                {
                    lbDanhSachChuNhiem.Text = DanhSachChon(ChuoiMaChuNhiemCongBo);
                }

                if (ChuoiMaThanhVienCongBo != "-")
                {
                    lbDanhSachThanhVien.Text = DanhSachChon(ChuoiMaThanhVienCongBo);
                }
            }
            catch
            {
                ThongBao("Dữ liệu liên quan đến một số bậc lương vẫn tồn tại, vui lòng kiểm tra lại dữ liệu!");
            }               
       }

        void ThongBao(string Loi)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "Thông báo!", "<script>alert('" + Loi + "')</script>", false);
        }

        void LoadGridview(string TenGiangVien)
        {
            int MaGiangVien = int.Parse(Session["MaGiangVien"].ToString());
            gvGiangVien.AutoGenerateColumns = false;
            gvGiangVien.DataSource = BGiangVien.SelectTimKiemByTenGiangVienLoaiMaGiangVien(txtTimKiemTenGiangVien.Value, MaGiangVien);
            gvGiangVien.DataBind();
        }

        protected void btnHuyDanhSach_Click(object sender, EventArgs e)
        {
            if (RBThanhVienCongBo.Checked==true)
            {
                ChuoiMaChuNhiemCongBo ="-"+ Session["MaGiangVien"].ToString() + "-";
            }
            else if (RBThanhVienCongBo.Checked == true)
            {
                ChuoiMaThanhVienCongBo = "-";
            }
            else
            {
                ChuoiMaChuNhiemCongBo = "-" + Session["MaGiangVien"].ToString() + "-";
                ChuoiMaThanhVienCongBo="-";
            }
           
        }

        public string DanhSachChon(string chuoi)
        {
            try
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
                    hienthi += "<img src=\"/images/AnhGiangVien/" + AnhDaiDien + " height='50px' width='50px' /> <b> " + TenTG + " </b> ";
                }
                return hienthi;
            }
            catch (Exception)
            {
                ThongBao("lỗi chuyển chuỗi sang html");
                return "";        
            }
        }

        string HamXuLyChuoi(string ChuoiDau)
        {
            string s1 = ChuoiDau.Trim().Remove(0, 1);
            string s2 = s1.Remove(s1.Length - 1, 1);
            return s2;
        }

        protected void gvGiangVien_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvGiangVien.PageIndex = e.NewPageIndex;
            LoadGridview(txtTimKiemTenGiangVien.Value.Trim());
        }

        protected void btnTimKiemTacGiaCongBo_Click(object sender, EventArgs e)
        {
            int MaGiangVien = int.Parse(Session["MaGiangVien"].ToString());
            gvGiangVien.AutoGenerateColumns = false;
            gvGiangVien.DataSource = BGiangVien.SelectTimKiemByTenGiangVienLoaiMaGiangVien(txtTimKiemTenGiangVien.Value,MaGiangVien);
            gvGiangVien.DataBind();
        }

        protected void btnThemCongBoKhoaHoc_Click(object sender, EventArgs e)
        {
            string filename;
            if (FileUpload1.HasFile == false)
	        {
		        filename ="";
	        }
            else
            {
                filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + FileUpload1.FileName;
                string path = Server.MapPath("~/FileMem/" + filename);
                FileUpload1.SaveAs(path);
            }

            BDanhSachCongBoKhoaHoc.Insert(new EDanhSachCongBoKhoaHoc
            {
             ChuoiMaGiangVienChuNhiem=ChuoiMaChuNhiemCongBo,
             ChuoiMaThanhVienThamGia=ChuoiMaThanhVienCongBo,
             LinkFileMem = filename,
             MaCapDeTai= int.Parse(cbbCapDeTai.SelectedValue.ToString()),
             MaSo=txtMaSo.Value,
             NamCongBo=DateTime.Parse(txtNamCongBo.Value),
             NoiCongBo=txtNoiCongBo.Value, 
             TenChuNhiemNgoai=txtTenChuNhiemNgoai.Value,
             TenCongTrinh=txtTenCongBo.Value,
             TenThanhVienNgoai=txtTenThanhVienNgoai.Value
            });
            Session["action"] = 1;
        }

        protected void BtnSuaCongBoKhoaHoc_Click(object sender, EventArgs e)
        {
           
            if (FileUpload1.HasFile == false)
            {
                BDanhSachCongBoKhoaHoc.Update(new EDanhSachCongBoKhoaHoc
                {
                    ChuoiMaGiangVienChuNhiem = ChuoiMaChuNhiemCongBo,
                    ChuoiMaThanhVienThamGia = ChuoiMaThanhVienCongBo,
                    LinkFileMem = lbFileMemHienTai.Text,
                    MaCapDeTai = int.Parse(cbbCapDeTai.SelectedValue),
                    MaCongTrinhKhoaHoc = idMaCongBoKhoaHoc,
                    MaSo = txtMaSo.Value,
                    NamCongBo = DateTime.Parse(txtNamCongBo.Value),
                    NoiCongBo = txtNoiCongBo.Value,
                    TenChuNhiemNgoai = txtTenChuNhiemNgoai.Value,
                    TenCongTrinh = txtTenCongBo.Value,
                    TenThanhVienNgoai = txtTenThanhVienNgoai.Value,
                });
            }
            else
            {
                    string filename = "";
                    filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + FileUpload1.FileName;
                    string path = Server.MapPath("~/FileMem/" + filename);
                    FileUpload1.SaveAs(path);
                    string dd = txtNamCongBo.Value.ToString(); 
                    BDanhSachCongBoKhoaHoc.Update(new EDanhSachCongBoKhoaHoc
                    {
                        ChuoiMaGiangVienChuNhiem = ChuoiMaChuNhiemCongBo,
                        ChuoiMaThanhVienThamGia = ChuoiMaThanhVienCongBo,
                        LinkFileMem = filename,
                        MaCapDeTai = int.Parse(cbbCapDeTai.SelectedValue),
                        MaCongTrinhKhoaHoc = idMaCongBoKhoaHoc,
                        MaSo = txtMaSo.Value,
                        NamCongBo = DateTime.Parse(txtNamCongBo.Value),
                        NoiCongBo = txtNoiCongBo.Value,
                        TenChuNhiemNgoai = txtTenChuNhiemNgoai.Value,
                        TenCongTrinh = txtTenCongBo.Value,
                        TenThanhVienNgoai = txtTenThanhVienNgoai.Value,
                     });
            }
            Session["action"] = 2;
        }



    }
}