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
    public partial class AdUserBaiBaoKhoaHoc : System.Web.UI.UserControl
    {
        string[] MaChuNhiem;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
            Session["MaBaiBao"] = null;
        }

        void LoadData()
        {
            string MaGiangVien = Session["MaGiangVien"].ToString();
            gvBaiBaoKhoaHoc.AutoGenerateColumns = false;
            gvBaiBaoKhoaHoc.DataSource = BBaiBao.SelectByChuoiMaTacGia(MaGiangVien);
            gvBaiBaoKhoaHoc.DataBind();
        }

        public string ChuoiTacGia(string TacGia,string TacGiaNgoai)
        {
            string TenChuNhiem = "";
            string TenCN = "";
            string MaChuNhiemChuan = HamXuLyChuoi(TacGia);  // ko con day '-' o dau va cuoi
            MaChuNhiem = MaChuNhiemChuan.Split('-');
            foreach (var item1 in MaChuNhiem)
            {
                TenCN = BGiangVien.SelectByID(int.Parse(item1)).TenGiangVien;
                TenChuNhiem += TenCN + ",";
            }
            return TenChuNhiem + TacGiaNgoai ;
        }

        string HamXuLyChuoi(string ChuoiDau)
        {
            string s1 = ChuoiDau.Trim().Remove(0, 1);
            string s2 = s1.Remove(s1.Length - 1, 1);
            return s2;
        }

        protected void gvBaiBaoKhoaHoc_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName== "ChonSua")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                string MaBaiBao = gvBaiBaoKhoaHoc.DataKeys[index].Value.ToString();
                Session["MaBaiBao"] = MaBaiBao;
                Response.Redirect("~/Admin/AdHome.aspx?url=SBBKH",true);
            }

            if (e.CommandName == "ChonTai")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                int MaBaiBao = int.Parse(gvBaiBaoKhoaHoc.DataKeys[index].Value.ToString());
                string FileMem = BBaiBao.SelectByID(MaBaiBao).FileMem;
                FileDownload(FileMem);
            }

        }

        private void FileDownload(string filename)
        {
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
            Response.TransmitFile("~/FileMem/" + filename);
        }




        protected void gvBaiBaoKhoaHoc_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            BBaiBao.Delete(int.Parse(gvBaiBaoKhoaHoc.DataKeys[e.RowIndex].Values[0].ToString()));
            LoadData();
            Session["action"] = 3;
        }

        protected void btnThemBaiBao_Click(object sender, EventArgs e)
        {
            Session["MaBaiBao"] = null;
            Response.Redirect("~/Admin/AdHome.aspx?url=SBBKH", true);
        }

        protected void gvBaiBaoKhoaHoc_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBaiBaoKhoaHoc.PageIndex = e.NewPageIndex;
            LoadData();
        }
    }
}