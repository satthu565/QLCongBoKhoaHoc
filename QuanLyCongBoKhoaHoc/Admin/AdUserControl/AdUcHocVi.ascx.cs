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
    public partial class AdUcHocVi : System.Web.UI.UserControl
    {
        public bool isClick = false;
        static int idMaHocVi = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadData()
        {
            gvHocVi.AutoGenerateColumns = false;
            gvHocVi.DataSource = BHocVi.SelectAll();
            gvHocVi.DataBind();
        }

        protected void lbXoaTat_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gvHocVi.Rows.Count; i++)
                {
                    CheckBox cbChon = (CheckBox)gvHocVi.Rows[i].Cells[0].FindControl("cbChon");
                    if (cbChon != null && cbChon.Checked)
                    {
                        BKhoa.Delete(int.Parse(gvHocVi.DataKeys[i].Values[0].ToString()));
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
            BHocVi.Insert(new EHocVi
            {
                TenHocVi = txtTenHocVi.Text
            });
            LoadData();
            Session["action"] = 1;

        }

        protected void btSua_Click(object sender, EventArgs e)
        {
            BHocVi.Update(new EHocVi
            {
                MaHocVi = idMaHocVi,
                TenHocVi = txtTenHocVi.Text
            });
            LoadData();
            Session["action"] = 2;
        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {
            txtTenHocVi.Text = "";
        }

        protected void gvHocVi_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ChonSua")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                idMaHocVi = int.Parse(gvHocVi.DataKeys[index].Values[0].ToString());
                txtTenHocVi.Text = HttpUtility.HtmlDecode(gvHocVi.Rows[index].Cells[2].Text);
                isClick = true;
            }
        }

        protected void gvHocVi_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            BHocVi.Delete(int.Parse(gvHocVi.DataKeys[e.RowIndex].Values[0].ToString()));
            LoadData();
            Session["action"] = 3;
        }

    }
}