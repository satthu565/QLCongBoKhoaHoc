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
    public partial class AdUcQuanLyTinTuc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadData();
        }

        void loadData()
        {
            int MaGiangVien = int.Parse(Session["MaGiangVien"].ToString());
            gvTinTuc.DataSource = BTinTuc.SelectByMaGiangVien(MaGiangVien);
            gvTinTuc.DataBind();
        }

        protected void gvTinTuc_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //qlstt
            if (e.CommandName == "ChonSua")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                Session["MaTinSua"] = gvTinTuc.DataKeys[index].Value;
                Response.Redirect("~/Admin/AdHome.aspx?url=STT", true);
            }
        }

        protected void gvTinTuc_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            BTinTuc.Delete(int.Parse(gvTinTuc.DataKeys[e.RowIndex].Value.ToString()));
            loadData();
            Session["action"] = 3;
        }

        protected void gvTinTuc_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTinTuc.PageIndex = e.NewPageIndex;
            gvTinTuc.DataBind();
        }

        protected void lbXoaTat_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gvTinTuc.Rows.Count; i++)
                {
                    CheckBox cbChon = (CheckBox)gvTinTuc.Rows[i].Cells[0].FindControl("cbChon");
                    if (cbChon != null && cbChon.Checked)
                    {
                        BTinTuc.Delete(int.Parse(gvTinTuc.DataKeys[i].Values[0].ToString()));
                    }
                }

                loadData();
                Session["action"] = 3;
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


    }
}