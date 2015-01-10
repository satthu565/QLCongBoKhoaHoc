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
    public partial class ucAdHocVienCaoHoc : System.Web.UI.UserControl
    {
        public bool isClick = false;
        static int idSauDaiHoc = 0;
        static int idHocVien = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadData()
        {
            int MaGiangVien = int.Parse(Session["MaGiangVien"].ToString());
            gvHocVienCaoHoc.AutoGenerateColumns = false;
            gvHocVienCaoHoc.DataSource = BSauDaiHoc.SelectByMaGiangVienVaLoaiDaoTao(MaGiangVien, "CaoHoc");
            gvHocVienCaoHoc.DataBind();
        }

        protected void lbXoaTat_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gvHocVienCaoHoc.Rows.Count; i++)
                {
                    CheckBox cbChon = (CheckBox)gvHocVienCaoHoc.Rows[i].Cells[0].FindControl("cbChon");
                    if (cbChon != null && cbChon.Checked)
                    {
                        BSauDaiHoc.Delete(int.Parse(gvHocVienCaoHoc.DataKeys[i].Values[0].ToString()));
                    }
                }
                LoadData();
                Session["action"] = 3;
            }
            catch
            {
                ThongBao("Lỗi xóa tất cả");
            }
        }

        void ThongBao(string Loi)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "Thông báo!", "<script>alert('" + Loi + "')</script>", false);
        }

        protected void btThemMoi_Click(object sender, EventArgs e)
        {
            // thêm học viên . kiểm tra tồn tại chưa đã mới thêm 
            int MaHocVien = 0;

            if (BHocVien.SelectBySoCMND(txtCMND.Value).HoTen == null)
	        {
                BHocVien.Insert(new EHocVien { 
                    GioiTinh = bool.Parse(cbbGioiTinh.SelectedValue),
                    HoTen = txtHoTen.Value,
                    NgaySinh = DateTime.Parse(txtNgaySinh.Value),
                    SoCMND = txtCMND.Value
                });
                MaHocVien = BHocVien.SelectTop1(1).MaHocVien;
	        }
            else
            {
                MaHocVien = BHocVien.SelectBySoCMND(txtCMND.Value).MaHocVien;
            }

             int MaGiangVien = int.Parse(Session["MaGiangVien"].ToString());

            // thêm table Sau đại học 
            BSauDaiHoc.Insert(new ESauDaiHoc { 
                LoaiDaoTao="CaoHoc",
                MaGiangVien = MaGiangVien,
                MaHocVien = MaHocVien,
                NoiDaoTao= txtNoiDaoTao.Value,
                TenDeTai = txtTenDeTai.Value,
                ThoiGianBaoVe = DateTime.Parse(txtThoiGianBaoVe.Value),
                ThoiGianBatDau = DateTime.Parse(txtThoiGianBatDau.Value),
                ThoiGianDaoTao = txtThoiGianDaoTao.Value,
                TrangThai = bool.Parse(cbbTrangThai.SelectedValue)
                });
            Session["action"] = 1;
            LoadData();
        }

        protected void btSua_Click(object sender, EventArgs e)
        {
            int MaHocVienMoi = idHocVien;

            if (txtCMND.Value != BHocVien.SelectByID(idHocVien).SoCMND)
            {
                if (BHocVien.SelectBySoCMND(txtCMND.Value).HoTen == null)
                {
                    BHocVien.Insert(new EHocVien
                    {
                        GioiTinh = bool.Parse(cbbGioiTinh.SelectedValue),
                        HoTen = txtHoTen.Value,
                        NgaySinh = DateTime.Parse(txtNgaySinh.Value),
                        SoCMND = txtCMND.Value
                    });
                    MaHocVienMoi = BHocVien.SelectTop1(1).MaHocVien;
                }
                else
                {
                    MaHocVienMoi = BHocVien.SelectBySoCMND(txtCMND.Value).MaHocVien;
                }
            }
            else
            {
                BHocVien.Update(new EHocVien
                {
                    GioiTinh =bool.Parse(cbbGioiTinh.SelectedValue),
                    HoTen = txtHoTen.Value,
                    MaHocVien = MaHocVienMoi,
                    NgaySinh = DateTime.Parse(txtNgaySinh.Value),
                    SoCMND = txtCMND.Value
                });
            }

            BSauDaiHoc.Update(new ESauDaiHoc {
                LoaiDaoTao = cbbLoaiDaoTao.SelectedValue,
                MaGiangVien =  int.Parse(Session["MaGiangVien"].ToString()),
                MaHocVien = MaHocVienMoi,
                MaSauDaiHoc = idSauDaiHoc,
                NoiDaoTao = txtNoiDaoTao.Value,
                TenDeTai = txtTenDeTai.Value,
                ThoiGianBaoVe = DateTime.Parse(txtThoiGianBaoVe.Value),
                ThoiGianBatDau = DateTime.Parse(txtThoiGianBatDau.Value),
                ThoiGianDaoTao = txtThoiGianDaoTao.Value,
                TrangThai = bool.Parse(cbbTrangThai.SelectedValue)
            });

            Session["action"] = 2;
            LoadData();
        }


        protected void gvHocVienCaoHoc_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ChonSua")
            {
                isClick = true;
                int index = int.Parse(e.CommandArgument.ToString());
                idSauDaiHoc = int.Parse(gvHocVienCaoHoc.DataKeys[index].Values["MaSauDaiHoc"].ToString());
             
                string  idHocVien1 = gvHocVienCaoHoc.Rows[index].Cells[1].Text;
                string idHocVien2 = gvHocVienCaoHoc.Rows[index].Cells[2].Text;

                EHocVien HocVien = new EHocVien();
                HocVien = BHocVien.SelectByID(int.Parse(gvHocVienCaoHoc.Rows[index].Cells[1].Text));

                txtCMND.Value = HocVien.SoCMND;
                txtHoTen.Value = HocVien.HoTen;
                txtNgaySinh.Value = HocVien.NgaySinh.ToString("dd/MM/yyyy");
                txtNoiDaoTao.Value = HttpUtility.HtmlDecode(gvHocVienCaoHoc.Rows[index].Cells[5].Text); 
                txtTenDeTai.Value = HttpUtility.HtmlDecode(gvHocVienCaoHoc.Rows[index].Cells[4].Text);
                txtThoiGianBaoVe.Value = HttpUtility.HtmlDecode(gvHocVienCaoHoc.Rows[index].Cells[8].Text); 
                txtThoiGianBatDau.Value = HttpUtility.HtmlDecode(gvHocVienCaoHoc.Rows[index].Cells[7].Text); 
                txtThoiGianDaoTao.Value = HttpUtility.HtmlDecode(gvHocVienCaoHoc.Rows[index].Cells[6].Text); 
            }
        }

        protected void gvHocVienCaoHoc_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            BSauDaiHoc.Delete(int.Parse(gvHocVienCaoHoc.DataKeys[e.RowIndex].Values[0].ToString()));
            LoadData();
            Session["action"] = 3;
        }

        protected void TimKiemTheoLoaiDaoTao_Click(object sender, EventArgs e)
        {
            gvHocVienCaoHoc.DataSource = BSauDaiHoc.SelectByMaGiangVienVaLoaiDaoTao(int.Parse(Session["MaGiangVien"].ToString()), cbbTimLoaiDaoTao.SelectedValue);
            gvHocVienCaoHoc.DataBind();
        }

        protected void gvHocVienCaoHoc_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvHocVienCaoHoc.PageIndex = e.NewPageIndex;
            LoadData();
        }

    }
}