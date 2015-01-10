using QuanLyCongBoKhoaHoc.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLyCongBoKhoaHoc.Admin.AdUserControl
{
    public partial class AdUserCongBoKhoaHoc : System.Web.UI.UserControl
    {
        string[] MaChuNhiem;
        string[] MaThanhVien;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
            Session["MaCongBo"] = "";
        }
        void LoadData()
        {
            string MaGiangVien = Session["MaGiangVien"].ToString();
            gvCongBoKhoaHoc.AutoGenerateColumns = false;
            gvCongBoKhoaHoc.DataSource = BDanhSachCongBoKhoaHoc.SelectMaGiangVien2Cot(MaGiangVien);
            gvCongBoKhoaHoc.DataBind();
        }
 
        public string ChuoiTacGiaChuNhiem(string chuoi,string ChuoiNgoai)
        {
            string TenChuNhiem = "";
            string TenCN = "";
            string MaChuNhiemChuan = HamXuLyChuoi(chuoi);  // ko con day '-' o dau va cuoi
            MaChuNhiem = MaChuNhiemChuan.Split('-');
            foreach (var item1 in MaChuNhiem)
            {
                TenCN = BGiangVien.SelectByID(int.Parse(item1)).TenGiangVien;
                TenChuNhiem += TenCN + ",";
            }
            TenChuNhiem += ChuoiNgoai;
            return TenChuNhiem;
        }

        public string ChuoiTacGiaThanhVien(string chuoi,string ChuoiNgoai)
        {
            string TenThanhVien = "";
            string MaThanhVienChuan = HamXuLyChuoi(chuoi);  // ko con day '-' o dau va cuoi
            MaThanhVien = MaThanhVienChuan.Split('-');

            foreach (var item2 in MaThanhVien)
            {
                string TenTV = BGiangVien.SelectByID(int.Parse(item2)).TenGiangVien;
                TenThanhVien += TenTV + ",";
            }
            TenThanhVien += ChuoiNgoai;
            return TenThanhVien;
        }

        string HamXuLyChuoi(string ChuoiDau)
        {
            string s1 = ChuoiDau.Trim().Remove(0, 1);
            string s2 = s1.Remove(s1.Length - 1, 1);
            return s2;
        }

        protected void gvCongBoKhoaHoc_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            if (e.CommandName == "ChonSua")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                string MaCongTrinhKhoaHoc = gvCongBoKhoaHoc.DataKeys[index].Value.ToString();
                Session["MaCongBo"] = MaCongTrinhKhoaHoc;
                Response.Redirect("~/Admin/AdHome.aspx?url=SCBKH", true);
            }
            if (e.CommandName == "ChonTai")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                int MaCongTrinhKhoaHoc = int.Parse(gvCongBoKhoaHoc.DataKeys[index].Value.ToString());
                string FileMem = BDanhSachCongBoKhoaHoc.SelectByID(MaCongTrinhKhoaHoc).LinkFileMem;
                FileDownload(FileMem);
            }
        }

        private void FileDownload(string filename)
        {
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
            Response.TransmitFile("~/FileMem/" + filename);
        }

        protected void btThemCongBo_Click(object sender, EventArgs e)
        {
            Session["MaCongBo"] = null;
            Response.Redirect("~/Admin/AdHome.aspx?url=SCBKH", true);
        }

        protected void gvCongBoKhoaHoc_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCongBoKhoaHoc.PageIndex = e.NewPageIndex;
            LoadData();
        }

        protected void gvCongBoKhoaHoc_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            BDanhSachCongBoKhoaHoc.Delete(int.Parse(gvCongBoKhoaHoc.DataKeys[e.RowIndex].Values[0].ToString()));
            LoadData();
            Session["action"] = 3;
        }


    }
}