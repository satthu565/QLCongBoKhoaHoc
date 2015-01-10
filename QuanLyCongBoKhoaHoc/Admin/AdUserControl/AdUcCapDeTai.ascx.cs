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
    public partial class AdUcCapDeTai : System.Web.UI.UserControl
    {
        public bool isClick = false;
        static int idCapDeTai = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadData()
        {
            gvCapDeTai.AutoGenerateColumns = false;
            gvCapDeTai.DataSource = BCapDeTai.SelectAll();
            gvCapDeTai.DataBind();
        }

        protected void lbXoaTat_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gvCapDeTai.Rows.Count; i++)
                {
                    CheckBox cbChon = (CheckBox)gvCapDeTai.Rows[i].Cells[0].FindControl("cbChon");
                    if (cbChon != null && cbChon.Checked)
                    {
                        BCapDeTai.Delete(int.Parse(gvCapDeTai.DataKeys[i].Values[0].ToString()));
                    }
                }
                LoadData();
                Session["action"] = 3;
            }
            catch
            {
                ThongBao("Dữ liệu liên quan vẫn tồn tại, vui lòng kiểm tra lại dữ liệu!");
            }
        }

        void ThongBao(string Loi)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "Thông báo!", "<script>alert('" + Loi + "')</script>", false);
        }

        protected void btThemMoi_Click(object sender, EventArgs e)
        {
            BCapDeTai.Insert(new ECapDeTai
            {
                TenCapDeTai = txtTenCapDeTai.Text
            });
            LoadData();
            Session["action"] = 1;

        }

        protected void btSua_Click(object sender, EventArgs e)
        {
            BCapDeTai.Update(new ECapDeTai
            {
                MaCapDeTai = idCapDeTai,
                TenCapDeTai = txtTenCapDeTai.Text
            });
            LoadData();
            Session["action"] = 2;
        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {
            txtTenCapDeTai.Text = "";
        }

        protected void gvCapDeTai_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ChonSua")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                idCapDeTai = int.Parse(gvCapDeTai.DataKeys[index].Values[0].ToString());
                txtTenCapDeTai.Text = HttpUtility.HtmlDecode(gvCapDeTai.Rows[index].Cells[2].Text);
                isClick = true;
            }
        }

        protected void gvCapDeTai_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            BCapDeTai.Delete(int.Parse(gvCapDeTai.DataKeys[e.RowIndex].Values[0].ToString()));
            LoadData();
            Session["action"] = 3;
        }

    }
}