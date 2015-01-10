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
    public partial class AdUcMenu : System.Web.UI.UserControl
    {
        public bool isClick = false;
        static int idMenu = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            thutu.Visible = false;
            LoadData();
        }

        void LoadData()
        {
            gvMenu.AutoGenerateColumns = false;
            gvMenu.DataSource = BMenu.SelectAll();
            gvMenu.DataBind();
        }

        //void LoadThuTu(int MaMenu)
        //{
        //    ddThuTu.DataSource = BMenu.SelectThuTu(MaMenu);
        //    ddThuTu.DataTextField = "ThuTu";
        //    ddThuTu.DataValueField = "ThuTu";
        //    ddThuTu.DataBind();
        //}

        void ThongBao(string Loi)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "Thông báo!", "<script>alert('" + Loi + "')</script>", false);
        }

        protected void lbXoaTat_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gvMenu.Rows.Count; i++)
                {
                    CheckBox cbChon = (CheckBox)gvMenu.Rows[i].Cells[0].FindControl("cbChon");
                    if (cbChon != null && cbChon.Checked)
                    {
                        BMenu.Delete(int.Parse(gvMenu.DataKeys[i].Values[0].ToString()));
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            BMenu.Insert(new EMenu
            {
                //DuongDan = ddKieuHienThi.SelectedValue,
                //TenTheLoai = txtTheLoai.Text,
                //idTheLoaiCha = ddTheLoaiCha.SelectedValue,
                //Title = txtTieuDe.Text,
                //Description = txtMoTa.Text,
                //Keyword = txtTuKhoa.Text,
                //ThuTu = 0,
                //TrangThai = ddTrangThai.SelectedValue == "1" ? true : false
            });

            LoadData();
            Session["action"] = 1;
        }

        protected void btSua_Click(object sender, EventArgs e)
        {
            BMenu.Update(new EMenu
            {
                //idTheLoai = idTheLoai,
                //DuongDan = ddKieuHienThi.SelectedValue,
                //TenTheLoai = txtTheLoai.Text,
                //idTheLoaiCha = ddTheLoaiCha.SelectedValue,
                //Title = txtTieuDe.Text,
                //Description = txtMoTa.Text,
                //Keyword = txtTuKhoa.Text,
                //TrangThai = ddTrangThai.SelectedValue == "1" ? true : false
            });

            //BTheLoai.UpdateThuTu(new ETheLoai
            //{
            //    idTheLoai = idTheLoai,
            //    ThuTu = byte.Parse(ddThuTu.SelectedValue)
            //});

            LoadData();
            Session["action"] = 2;
        }

        protected void gvMenu_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ChonSua")
            {
            //    int index = int.Parse(e.CommandArgument.ToString());
            //    idMenu = int.Parse(gvMenu.DataKeys[index].Values[0].ToString());

            //    thutu.Visible = true;
            ////    LoadThuTu(idMenu);
            //    txtTheLoai.Text = HttpUtility.HtmlDecode(gvMenu.Rows[index].Cells[1].Text);
            //    ddKieuHienThi.SelectedValue = gvMenu.Rows[index].Cells[2].Text;
            //    ddThuTu.SelectedValue = gvMenu.Rows[index].Cells[3].Text;
            //    txtTieuDe.Text = HttpUtility.HtmlDecode(gvMenu.Rows[index].Cells[4].Text);
            //    txtMoTa.Text = HttpUtility.HtmlDecode(gvMenu.Rows[index].Cells[5].Text);
            //    txtTuKhoa.Text = HttpUtility.HtmlDecode(gvMenu.Rows[index].Cells[6].Text);
            //    ddTheLoaiCha.SelectedValue = gvMenu.DataKeys[index].Values[1].ToString();
            //    ddTrangThai.SelectedValue = gvMenu.Rows[index].Cells[8].Text == "True" ? "1" : "0";
                isClick = true;
            }
        }

        protected void gvMenu_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = int.Parse(e.RowIndex.ToString());
            BMenu.Delete(int.Parse(gvMenu.DataKeys[index].Values[0].ToString()));
            LoadData();
            Session["action"] = 3;
        }

        protected void gvMenu_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMenu.PageIndex = e.NewPageIndex;
            gvMenu.DataBind();
        }
    }
}