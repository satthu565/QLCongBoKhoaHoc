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
    public partial class UcThongKeSachGiaoTrinh : System.Web.UI.UserControl
    {
        
        public static DataTable dtGiangVien;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dtGiangVien = BGiangVien.SelectAll();
                LoadGvSachXuatBan(dtGiangVien,txtTuNamHoanThanh.Text,txtDenNamHoanThanh.Text);
            }
            LoadCbbDonViCongTac();
        }

        void LoadGvSachXuatBan(DataTable dt,string TuNam , string DenNam)
        {
            DataTable ThongKeSachXuatBan = new DataTable();
            DataColumn col2 = new DataColumn("TenGiangVien", typeof(string));
            DataColumn col3 = new DataColumn("TenKhoa", typeof(string));
            DataColumn col4 = new DataColumn("SoLuong", typeof(int));


            ThongKeSachXuatBan.Columns.Add(col2);
            ThongKeSachXuatBan.Columns.Add(col3);
            ThongKeSachXuatBan.Columns.Add(col4);
         

            foreach (DataRow row in dtGiangVien.Rows)
            {
                int SoSach;
            

                if (txtTuNamHoanThanh.Text == "" || txtDenNamHoanThanh.Text == "")
                {
                    SoSach = BSachXuatBan.DemSachTheoMaGiangVien(int.Parse(row["MaGiangVien"].ToString()));
                   
                }
                else
                {
                    SoSach = BSachXuatBan.DemTheoMaGiangVienVaNamHoanThanh(int.Parse(row["MaGiangVien"].ToString()),int.Parse(TuNam),int.Parse(DenNam));
                }

                DataRow dr;

                dr = ThongKeSachXuatBan.NewRow();
                dr[0] = BGiangVien.SelectByID(int.Parse(row["MaGiangVien"].ToString())).TenGiangVien;
                dr[1] = BKhoa.SelectTenKhoaByMaGiangVien(int.Parse(row["MaGiangVien"].ToString())).TenKhoa;
                dr[2] = SoSach;
                ThongKeSachXuatBan.Rows.Add(dr);
            }
            DataView dv = ThongKeSachXuatBan.DefaultView;
            dv.Sort = "SoLuong Desc";
            ThongKeSachXuatBan = dv.ToTable();

            gvTKSachXuatBan.AutoGenerateColumns = false;
            gvTKSachXuatBan.DataSource = ThongKeSachXuatBan;
            gvTKSachXuatBan.DataBind();
        }

        protected void gvTKSachXuatBan_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTKSachXuatBan.PageIndex = e.NewPageIndex;
            LoadGvSachXuatBan(dtGiangVien,txtTuNamHoanThanh.Text,txtDenNamHoanThanh.Text);
        }

        protected void btnTimKiemThongKeSachGiaoTrinh_Click(object sender, EventArgs e)
        {
            if (cbbDonViCongTac.SelectedValue != "-- Chọn đơn vị công tác --")
            {
                dtGiangVien = BGiangVien.SelectTimKiemByMaKhoaVaTenGiangVien(txtTenGiangVien.Text.Trim(), int.Parse(cbbDonViCongTac.SelectedValue));
                LoadGvSachXuatBan(dtGiangVien, txtTuNamHoanThanh.Text, txtDenNamHoanThanh.Text);
            }
            else
            {
                if (txtTenGiangVien.Text != "")
                {
                    dtGiangVien = BGiangVien.SelectTimKiemByTenGiangVien(txtTenGiangVien.Text.Trim());
                    LoadGvSachXuatBan(dtGiangVien, txtTuNamHoanThanh.Text, txtDenNamHoanThanh.Text);
                }
                else
                {
                    dtGiangVien = BGiangVien.SelectAll();
                    LoadGvSachXuatBan(dtGiangVien, txtTuNamHoanThanh.Text, txtDenNamHoanThanh.Text);
                }
            }
        }

        void LoadCbbDonViCongTac()
        {
            cbbDonViCongTac.DataSource = BKhoa.SelectAll();
            cbbDonViCongTac.DataTextField = "TenKhoa";
            cbbDonViCongTac.DataValueField = "MaKhoa";
            cbbDonViCongTac.DataBind();
            cbbDonViCongTac.Items.Insert(0, "-- Chọn đơn vị công tác --");
        }

    }
}