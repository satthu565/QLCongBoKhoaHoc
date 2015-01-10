using QuanLyCongBoKhoaHoc.Business;
using QuanLyCongBoKhoaHoc.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLyCongBoKhoaHoc.Admin.AdUserControl
{
    public partial class AdUcSachXuatBan : System.Web.UI.UserControl
    {
        public bool isClick;
        static int idSachXuatBan = 0;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadData()
        {
         
            int MaGiangVien = int.Parse(Session["MaGiangVien"].ToString()) ;
            gvSachXuatBan.AutoGenerateColumns = false;
            gvSachXuatBan.DataSource = BSachXuatBan.SelectByMaGiangVien(MaGiangVien);
            gvSachXuatBan.DataBind();
        }

        protected void GvQuyen_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = int.Parse(e.RowIndex.ToString());
            BQuyen.Delete(int.Parse(gvSachXuatBan.DataKeys[index].Values[0].ToString()));
            LoadData();
            Session["action"] = 3;
        }

        void ThongBao(string Loi)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "Thông báo!", "<script>alert('" + Loi + "')</script>", false);
        }

        protected void btThemMoi_Click(object sender, EventArgs e)
        {
            BSachXuatBan.Insert(new ESachXuatBan
            {
                MaGiangVien= int.Parse(Session["MaGiangVien"].ToString()),
                TenSach = txtTenSach.Text,
                NhaXuatBan =txtNhaXuatBan.Text,
                NamHoanThanh = DateTime.Parse(txtNamXuatBan.Text)
            });
            Session["action"] = 1;
            LoadData();
        }

        protected void btSua_Click(object sender, EventArgs e)
        {
            BSachXuatBan.Update(new ESachXuatBan
            {
                MaSachXuatBan = idSachXuatBan,
                TenSach = txtTenSach.Text,
                NhaXuatBan = txtNhaXuatBan.Text,
                NamHoanThanh=DateTime.Parse(txtNamXuatBan.Text),
                MaGiangVien= int.Parse(Session["MaGiangVien"].ToString()),
            });
            Session["action"] = 2;
            LoadData();

        }

        protected void lbXoaTat_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gvSachXuatBan.Rows.Count; i++)
                {
                    CheckBox cbChon = (CheckBox)gvSachXuatBan.Rows[i].Cells[0].FindControl("cbChon");
                    if (cbChon != null && cbChon.Checked)
                    {
                        BQuyen.Delete(int.Parse(gvSachXuatBan.DataKeys[i].Values[0].ToString()));
                    }
                }
                LoadData();
                Session["action"] = 3;
            }
            catch
            {
                ThongBao("Dữ liệu liên quan đến một số bậc lương vẫn tồn tại, vui lòng kiểm tra lại dữ liệu!");
            }
        }

        protected void gvSachXuatBan_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ChonSua")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                idSachXuatBan = int.Parse(gvSachXuatBan.DataKeys[index].Values["MaSachXuatBan"].ToString());
                txtTenSach.Text = HttpUtility.HtmlDecode(gvSachXuatBan.Rows[index].Cells[2].Text);
                txtNhaXuatBan.Text = HttpUtility.HtmlDecode(gvSachXuatBan.Rows[index].Cells[3].Text);
                txtNamXuatBan.Text = HttpUtility.HtmlDecode(gvSachXuatBan.Rows[index].Cells[4].Text);
                isClick = true;
            }
        }

        protected void gvSachXuatBan_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = int.Parse(e.RowIndex.ToString());
            BSachXuatBan.Delete(int.Parse(gvSachXuatBan.DataKeys[index].Values[0].ToString()));
            LoadData();
            Session["action"] = 3;
        }
    }
}