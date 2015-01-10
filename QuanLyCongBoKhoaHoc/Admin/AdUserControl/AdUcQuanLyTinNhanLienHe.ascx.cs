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
    public partial class AdUcQuanLyTinNhanLienHe : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadData()
        {
            int MagiangVien = int.Parse(Session["MaGiangVien"].ToString());
            grvLienHe.AutoGenerateColumns = false;
            grvLienHe.DataSource = BLienHe.SelectByMaGiangVienNhan(MagiangVien);
            grvLienHe.DataBind();
        }

        protected void lbXoaTat_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < grvLienHe.Rows.Count; i++)
                {
                    CheckBox cbChon = (CheckBox)grvLienHe.Rows[i].Cells[0].FindControl("cbChon");
                    if (cbChon != null && cbChon.Checked)
                    {
                        BQuaTrinhCongTac.Delete(int.Parse(grvLienHe.DataKeys[i].Values[0].ToString()));
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

        protected void grvLienHe_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ChonXem")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                Session["MaTinNhan"] = int.Parse(grvLienHe.DataKeys[index].Value.ToString());
                Response.Redirect("~/Admin/AdHome.aspx?url=XTNLH", true);
            }
        }

        protected void grvLienHe_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = int.Parse(e.RowIndex.ToString());
            BLienHe.Delete(int.Parse(grvLienHe.DataKeys[index].Values[0].ToString()));
            LoadData();
            Session["action"] = 3;
        }

        protected void btnTimKiemNguoiLienHe_Click(object sender, EventArgs e)
        {
            string TimNguoiGui = txtTimHoTenLienHe.Value.Trim();
            grvLienHe.AutoGenerateColumns = false;
            grvLienHe.DataSource = BLienHe.TimKiemNguoiGui(TimNguoiGui);
            grvLienHe.DataBind();
        }

        protected void grvLienHe_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvLienHe.PageIndex = e.NewPageIndex;
            LoadData();
        }


    }
}