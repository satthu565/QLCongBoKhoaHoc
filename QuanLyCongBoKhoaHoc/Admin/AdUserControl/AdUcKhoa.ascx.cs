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
    public partial class AdUcKhoa : System.Web.UI.UserControl
    {
        public bool isClick = false;
        static int idKhoa = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadData()
        {
            gvKhoa.AutoGenerateColumns = false;
            gvKhoa.DataSource = BKhoa.SelectAll();
            gvKhoa.DataBind();
        }

        protected void lbXoaTat_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gvKhoa.Rows.Count; i++)
                {
                    CheckBox cbChon = (CheckBox)gvKhoa.Rows[i].Cells[0].FindControl("cbChon");
                    if (cbChon != null && cbChon.Checked)
                    {
                        BKhoa.Delete(int.Parse(gvKhoa.DataKeys[i].Values[0].ToString()));
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
            BKhoa.Insert(new EKhoa {
                TenKhoa=txtTenKhoa.Text
            });
            LoadData();
            Session["action"] = 1;

        }

        protected void btSua_Click(object sender, EventArgs e)
        {
            BKhoa.Update(new EKhoa
            {
                 MaKhoa = idKhoa,
                TenKhoa = txtTenKhoa.Text
            });
            LoadData();
            Session["action"] = 2;
        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {
            txtTenKhoa.Text = "";
        }

        protected void gvKhoa_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ChonSua")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                idKhoa = int.Parse(gvKhoa.DataKeys[index].Values[0].ToString());
                txtTenKhoa.Text = HttpUtility.HtmlDecode(gvKhoa.Rows[index].Cells[2].Text);
                isClick = true;
            }
        }

        protected void gvKhoa_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            BKhoa.Delete(int.Parse(gvKhoa.DataKeys[e.RowIndex].Values[0].ToString()));
            LoadData();
            Session["action"] = 3;
        }


    }
}