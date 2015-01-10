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
    public partial class AdUcGiaiThuongKhoaHoc : System.Web.UI.UserControl
    {
        public bool isClick = false;
        static int idGiaiThuongKhoaHoc = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        void LoadData()
        {
            int MaGiangVien = int.Parse(Session["MaGiangVien"].ToString());
            gvGiaiThuongKhoaHoc.AutoGenerateColumns = false;
            gvGiaiThuongKhoaHoc.DataSource = BGiaiThuongKhoaHoc.SelectByMaGiangVien(MaGiangVien);
            gvGiaiThuongKhoaHoc.DataBind();
        }

        protected void lbXoaTat_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gvGiaiThuongKhoaHoc.Rows.Count; i++)
                {
                    CheckBox cbChon = (CheckBox)gvGiaiThuongKhoaHoc.Rows[i].Cells[0].FindControl("cbChon");
                    if (cbChon != null && cbChon.Checked)
                    {
                        BGiaiThuongKhoaHoc.Delete(int.Parse(gvGiaiThuongKhoaHoc.DataKeys[i].Values[0].ToString()));
                    }
                }
                LoadData();
                Session["action"] = 3;
            }
            catch
            {
                ThongBao("Xem lại phần admin giải thưởng khoa học");
            }
        }

        void ThongBao(string Loi)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "Thông báo!", "<script>alert('" + Loi + "')</script>", false);
        }

        protected void btThemMoi_Click(object sender, EventArgs e)
        {
            BGiaiThuongKhoaHoc.Insert(new EGiaiThuongKhoaHoc
            {
               LinhVuc=txtLinhVuc.Text,
               MaGiangVien = int.Parse(Session["MaGiangVien"].ToString()),
               NamNhan=DateTime.Parse(txtThoiGianNhan.Text),
               NoiCap=txtNoiNhan.Text,
               So= txtMaSoGiaiThuong.Text,
               TenGiaiThuong= txtTenGiaiThuong.Text
            });
            LoadData();
            Session["action"] = 1;
        }

        protected void btSua_Click(object sender, EventArgs e)
        {
            BGiaiThuongKhoaHoc.Update(new EGiaiThuongKhoaHoc
            {
                LinhVuc= txtLinhVuc.Text,
                MaGiaiThuongKhoaHoc= idGiaiThuongKhoaHoc,
                MaGiangVien= int.Parse(Session["MaGiangVien"].ToString()),
                NamNhan= DateTime.Parse(txtThoiGianNhan.Text),
                NoiCap= txtNoiNhan.Text,
                So=txtMaSoGiaiThuong.Text,
                TenGiaiThuong= txtTenGiaiThuong.Text
            });
            LoadData();
            Session["action"] = 2;
        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {
                txtLinhVuc.Text = "";
                txtMaSoGiaiThuong.Text = "";
                txtNoiNhan.Text ="";
                txtTenGiaiThuong.Text = "";
                txtThoiGianNhan.Text = "";
        }

        protected void gvGiaiThuongKhoaHoc_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ChonSua")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                idGiaiThuongKhoaHoc = int.Parse(gvGiaiThuongKhoaHoc.DataKeys[index].Values[0].ToString());
                txtLinhVuc.Text = HttpUtility.HtmlDecode(gvGiaiThuongKhoaHoc.Rows[index].Cells[2].Text);
                txtMaSoGiaiThuong.Text = HttpUtility.HtmlDecode(gvGiaiThuongKhoaHoc.Rows[index].Cells[4].Text);
                txtNoiNhan.Text = HttpUtility.HtmlDecode(gvGiaiThuongKhoaHoc.Rows[index].Cells[3].Text);
                txtTenGiaiThuong.Text = HttpUtility.HtmlDecode(gvGiaiThuongKhoaHoc.Rows[index].Cells[1].Text);
                txtThoiGianNhan.Text = HttpUtility.HtmlDecode(gvGiaiThuongKhoaHoc.Rows[index].Cells[5].Text);
                isClick = true;
            }
        }

        protected void gvGiaiThuongKhoaHoc_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            BGiaiThuongKhoaHoc.Delete(int.Parse(gvGiaiThuongKhoaHoc.DataKeys[e.RowIndex].Values[0].ToString()) );
            LoadData();
            Session["action"] = 3;
        }

    }
}