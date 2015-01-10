using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using QuanLyCongBoKhoaHoc.Business;

namespace QuanLyCongBoKhoaHoc.UserControl
{
    public partial class UcThongKeBaiBaoKhoaHoc : System.Web.UI.UserControl
    {
        public static DataTable dtGiangVien;

        protected void Page_Load(object sender, EventArgs e)
        {
         
            if (!IsPostBack)
            {
                dtGiangVien = BGiangVien.SelectAll();
                LoadGvBaiBaoKhoaHoc(dtGiangVien,txtNamXuatBan.Text,txtDenNamXuatBan.Text);
            }
            LoadCbbDonViCongTac();
        }

        void LoadCbbDonViCongTac()
        {
            cbbDonViCongTac.DataSource = BKhoa.SelectAll();
            cbbDonViCongTac.DataTextField = "TenKhoa";
            cbbDonViCongTac.DataValueField = "MaKhoa";
            cbbDonViCongTac.DataBind();
            cbbDonViCongTac.Items.Insert(0, "-- Chọn đơn vị công tác --");
        }

        void LoadGvBaiBaoKhoaHoc(DataTable dtGiangVien, string TuNamXuatBan, string DenNamXuatBan)
        { 
                DataTable ThongKeBaiBaoKhoaHoc = new DataTable();
                DataColumn col2 = new DataColumn("TenGiangVien", typeof(string));
                DataColumn col3 = new DataColumn("Khoa", typeof(string));
                DataColumn col4 = new DataColumn("SoLuongTrongNuoc", typeof(int));
                DataColumn col5 = new DataColumn("SoLuongQuocTe", typeof(int));
   
                ThongKeBaiBaoKhoaHoc.Columns.Add(col2);
                ThongKeBaiBaoKhoaHoc.Columns.Add(col3);
                ThongKeBaiBaoKhoaHoc.Columns.Add(col4);
                ThongKeBaiBaoKhoaHoc.Columns.Add(col5);


             
               // trong nuoc = true = 1 
               // quốc tế = false = 0
                
            foreach (DataRow row in dtGiangVien.Rows)
                {
                    int SoLuongTrongNuoc;
                    int SoLuongQuocTe;

                    if (TuNamXuatBan == "" && DenNamXuatBan == "")
                    {
                        SoLuongTrongNuoc = BBaiBao.CountByMaGianVienVaGioiHan(row["MaGiangVien"].ToString(), 1);
                        SoLuongQuocTe = BBaiBao.CountByMaGianVienVaGioiHan(row["MaGiangVien"].ToString(), 0);
                    }
                    else
                    {
                        SoLuongTrongNuoc = BBaiBao.CountByMaGianVienVaGioiHanVaNamXuatBan(row["MaGiangVien"].ToString(), 1, int.Parse(TuNamXuatBan), int.Parse(DenNamXuatBan));
                        SoLuongQuocTe = BBaiBao.CountByMaGianVienVaGioiHanVaNamXuatBan(row["MaGiangVien"].ToString(), 0, int.Parse(TuNamXuatBan), int.Parse(DenNamXuatBan));
                    }
                  
                    DataRow dr;
                    dr = ThongKeBaiBaoKhoaHoc.NewRow();
                    dr[0] = BGiangVien.SelectByID(int.Parse(row["MaGiangVien"].ToString())).TenGiangVien;
                    dr[1] = BKhoa.SelectTenKhoaByMaGiangVien(int.Parse(row["MaGiangVien"].ToString())).TenKhoa;
                    dr[2] = SoLuongTrongNuoc;
                    dr[3] = SoLuongQuocTe;
                   ThongKeBaiBaoKhoaHoc.Rows.Add(dr);
                }
                DataView dv = ThongKeBaiBaoKhoaHoc.DefaultView;
                dv.Sort = "SoLuongTrongNuoc Desc";
                ThongKeBaiBaoKhoaHoc = dv.ToTable();

                gvTTBaiBaoKhoaHoc.AutoGenerateColumns = false;
                gvTTBaiBaoKhoaHoc.DataSource = ThongKeBaiBaoKhoaHoc;
                gvTTBaiBaoKhoaHoc.DataBind();
            }

        protected void gvTTBaiBaoKhoaHoc_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTTBaiBaoKhoaHoc.PageIndex = e.NewPageIndex;
            LoadGvBaiBaoKhoaHoc(dtGiangVien,txtNamXuatBan.Text,txtDenNamXuatBan.Text);
        }


        protected void btnTimKiemThongKeCongBo_Click(object sender, EventArgs e)
        {
            if (cbbDonViCongTac.SelectedValue != "-- Chọn đơn vị công tác --")
            {
                dtGiangVien = BGiangVien.SelectTimKiemByMaKhoaVaTenGiangVien(txtTenTacGia.Text.Trim(), int.Parse(cbbDonViCongTac.SelectedValue));
                LoadGvBaiBaoKhoaHoc(dtGiangVien,txtNamXuatBan.Text,txtDenNamXuatBan.Text);
            }
            else
            {
                if (txtTenTacGia.Text != "")
                {
                    dtGiangVien = BGiangVien.SelectTimKiemByTenGiangVien(txtTenTacGia.Text.Trim());
                    LoadGvBaiBaoKhoaHoc(dtGiangVien,txtNamXuatBan.Text,txtDenNamXuatBan.Text);
                }
                else
                {
                    dtGiangVien = BGiangVien.SelectAll();
                    LoadGvBaiBaoKhoaHoc(dtGiangVien,txtNamXuatBan.Text,txtDenNamXuatBan.Text);
                }
            }
        }


             
    }
}