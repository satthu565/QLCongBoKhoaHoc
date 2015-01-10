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
    public partial class UcThongKeCongTrinhKhoaHoc : System.Web.UI.UserControl
    {
        public static DataTable dtGiangVien;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dtGiangVien = BGiangVien.SelectAll();
                LoadThongKeTheoTacGia(dtGiangVien,txtTuNamCongBo.Text,txtDenNamCongBo.Text);
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

        void LoadThongKeTheoTacGia(DataTable dtGiangVien , string TuNamCongBo, string DenNamCongBo)
         {
                DataTable ThongKeCongTrinhKhoaHoc = new DataTable();
                DataColumn col2 = new DataColumn("TenGiangVien", typeof(string));
                DataColumn col3 = new DataColumn("Khoa", typeof(string));
                DataColumn col4 = new DataColumn("CapTruong", typeof(int));
                DataColumn col5 = new DataColumn("CapBo", typeof(int));
                DataColumn col6 = new DataColumn("CapCoSo", typeof(int));
                DataColumn col7 = new DataColumn("CapThanhPho", typeof(int));
                DataColumn col8 = new DataColumn("CapNhaNuoc", typeof(int));
                DataColumn col9 = new DataColumn("CapQuocGia", typeof(int));

   
                ThongKeCongTrinhKhoaHoc.Columns.Add(col2);
                ThongKeCongTrinhKhoaHoc.Columns.Add(col3);
                ThongKeCongTrinhKhoaHoc.Columns.Add(col4);
                ThongKeCongTrinhKhoaHoc.Columns.Add(col5);
                ThongKeCongTrinhKhoaHoc.Columns.Add(col6);
                ThongKeCongTrinhKhoaHoc.Columns.Add(col7);
                ThongKeCongTrinhKhoaHoc.Columns.Add(col8);
                ThongKeCongTrinhKhoaHoc.Columns.Add(col9);
            
                foreach (DataRow row in dtGiangVien.Rows)
                {
                    int CapTruong;
                    int CapBo;
                    int CapCoSo;
                    int CapThanhPho;
                    int CapNhaNuoc;
                    int CapQuocGia;

                    if (txtTuNamCongBo.Text =="" || txtDenNamCongBo.Text =="")
                    {
                         CapTruong = BDanhSachCongBoKhoaHoc.CountByMaGianVienVaCapDeTai(row["MaGiangVien"].ToString(), 1);
                         CapBo = BDanhSachCongBoKhoaHoc.CountByMaGianVienVaCapDeTai(row["MaGiangVien"].ToString(), 2);
                         CapCoSo = BDanhSachCongBoKhoaHoc.CountByMaGianVienVaCapDeTai(row["MaGiangVien"].ToString(), 3);
                         CapThanhPho = BDanhSachCongBoKhoaHoc.CountByMaGianVienVaCapDeTai(row["MaGiangVien"].ToString(), 4);
                         CapNhaNuoc = BDanhSachCongBoKhoaHoc.CountByMaGianVienVaCapDeTai(row["MaGiangVien"].ToString(), 5);
                         CapQuocGia = BDanhSachCongBoKhoaHoc.CountByMaGianVienVaCapDeTai(row["MaGiangVien"].ToString(), 6);
                    }
                    else
                    {
                        CapTruong = BDanhSachCongBoKhoaHoc.CountByMaGianVienVaCapDeTaiVaNamCongBo(row["MaGiangVien"].ToString(), 1, int.Parse(TuNamCongBo), int.Parse(DenNamCongBo));
                        CapBo = BDanhSachCongBoKhoaHoc.CountByMaGianVienVaCapDeTaiVaNamCongBo(row["MaGiangVien"].ToString(), 2, int.Parse(TuNamCongBo), int.Parse(DenNamCongBo));
                        CapCoSo = BDanhSachCongBoKhoaHoc.CountByMaGianVienVaCapDeTaiVaNamCongBo(row["MaGiangVien"].ToString(), 3, int.Parse(TuNamCongBo), int.Parse(DenNamCongBo) );
                        CapThanhPho = BDanhSachCongBoKhoaHoc.CountByMaGianVienVaCapDeTaiVaNamCongBo(row["MaGiangVien"].ToString(), 4, int.Parse(TuNamCongBo), int.Parse(DenNamCongBo));
                        CapNhaNuoc = BDanhSachCongBoKhoaHoc.CountByMaGianVienVaCapDeTaiVaNamCongBo(row["MaGiangVien"].ToString(), 5, int.Parse(TuNamCongBo), int.Parse(DenNamCongBo));
                        CapQuocGia = BDanhSachCongBoKhoaHoc.CountByMaGianVienVaCapDeTaiVaNamCongBo(row["MaGiangVien"].ToString(), 6, int.Parse(TuNamCongBo), int.Parse(DenNamCongBo));
                    }
                 
                   DataRow dr;
 
                    dr = ThongKeCongTrinhKhoaHoc.NewRow();
                    dr[0] = BGiangVien.SelectByID(int.Parse(row["MaGiangVien"].ToString())).TenGiangVien;
                    dr[1] = BKhoa.SelectTenKhoaByMaGiangVien(int.Parse(row["MaGiangVien"].ToString())).TenKhoa;
                    dr[2] = CapTruong;
                    dr[3] = CapBo;
                    dr[4] = CapCoSo;
                    dr[5] = CapThanhPho;
                    dr[6] = CapNhaNuoc;
                    dr[7] = CapQuocGia;
                   ThongKeCongTrinhKhoaHoc.Rows.Add(dr);
                }
                DataView dv = ThongKeCongTrinhKhoaHoc.DefaultView;
                dv.Sort = "CapTruong Desc";
                ThongKeCongTrinhKhoaHoc = dv.ToTable();

                gvTTCongTrinhKhoaHoc.AutoGenerateColumns = false;
                gvTTCongTrinhKhoaHoc.DataSource = ThongKeCongTrinhKhoaHoc;
                gvTTCongTrinhKhoaHoc.DataBind();
            }

          protected void gvTTCongTrinhKhoaHoc_PageIndexChanging(object sender, GridViewPageEventArgs e)
          {
              gvTTCongTrinhKhoaHoc.PageIndex = e.NewPageIndex;
              LoadThongKeTheoTacGia(dtGiangVien,txtTuNamCongBo.Text,txtDenNamCongBo.Text);
          }

          protected void btnTimKiemThongKeCongBo_Click(object sender, EventArgs e)
          {
              if (cbbDonViCongTac.SelectedValue != "-- Chọn đơn vị công tác --")
              {
                  dtGiangVien = BGiangVien.SelectTimKiemByMaKhoaVaTenGiangVien(txtTenTacGia.Text.Trim(), int.Parse(cbbDonViCongTac.SelectedValue));
                  LoadThongKeTheoTacGia(dtGiangVien,txtTuNamCongBo.Text,txtDenNamCongBo.Text);
              }
              else
              {
                  if (txtTenTacGia.Text !="")
                  {
                      dtGiangVien = BGiangVien.SelectTimKiemByTenGiangVien(txtTenTacGia.Text.Trim());
                      LoadThongKeTheoTacGia(dtGiangVien,txtTuNamCongBo.Text,txtDenNamCongBo.Text);
                  }
                  else
                  {
                      dtGiangVien = BGiangVien.SelectAll();
                      LoadThongKeTheoTacGia(dtGiangVien,txtTuNamCongBo.Text,txtDenNamCongBo.Text);
                  }
              }

          }

    }
}