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
    public partial class AdUcChucVu : System.Web.UI.UserControl
    {
        public bool isClick = false;
        static int idChucVu = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadData()
        {
            gvChucVu.AutoGenerateColumns = false;
            gvChucVu.DataSource = BChucVu.SelectAll();
            gvChucVu.DataBind();
        }
        protected void lbXoaTat_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gvChucVu.Rows.Count; i++)
                {
                    CheckBox cbChon = (CheckBox)gvChucVu.Rows[i].Cells[0].FindControl("cbChon");
                    if (cbChon != null && cbChon.Checked)
                    {
                        BChucVu.Delete(int.Parse(gvChucVu.DataKeys[i].Values[0].ToString()));
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
            BChucVu.Insert(new EChucVu
            {
                TenChucVu = txtTenChucVu.Text
            });
            LoadData();
            Session["action"] = 1;

        }

        protected void btSua_Click(object sender, EventArgs e)
        {
            BChucVu.Update(new EChucVu
            {
                MaChucVu = idChucVu,
                TenChucVu = txtTenChucVu.Text
            });
            LoadData();
            Session["action"] = 2;
        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {
            txtTenChucVu.Text = "";
        }

  
        protected void gvChucVu_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            BChucVu.Delete(int.Parse(gvChucVu.DataKeys[e.RowIndex].Values[0].ToString()));
            LoadData();
            Session["action"] = 3;
        }

        protected void gvChucVu_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ChonSua")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                idChucVu = int.Parse(gvChucVu.DataKeys[index].Values[0].ToString());
                txtTenChucVu.Text = HttpUtility.HtmlDecode(gvChucVu.Rows[index].Cells[2].Text);
                isClick = true;
            }
        }
    }
}