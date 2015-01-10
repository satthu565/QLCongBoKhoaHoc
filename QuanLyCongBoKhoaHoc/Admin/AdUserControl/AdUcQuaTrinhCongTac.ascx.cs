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
  
    public partial class AdUserQuaTrinhCongTac : System.Web.UI.UserControl
    {
        public bool isClick = false;
        static int idQuaTrinhCongTac = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadData()
        {
            int MaGiangVien = int.Parse(Session["MaGiangVien"].ToString());
            gvQuaTrinhCongTac.AutoGenerateColumns = false;
            gvQuaTrinhCongTac.DataSource = BQuaTrinhCongTac.SelectByMaGiangVien(MaGiangVien);
            gvQuaTrinhCongTac.DataBind();
        }

        protected void lbXoaTat_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gvQuaTrinhCongTac.Rows.Count; i++)
                {
                    CheckBox cbChon = (CheckBox)gvQuaTrinhCongTac.Rows[i].Cells[0].FindControl("cbChon");
                    if (cbChon != null && cbChon.Checked)
                    {
                        BQuaTrinhCongTac.Delete(int.Parse(gvQuaTrinhCongTac.DataKeys[i].Values[0].ToString()));
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

        protected void btThemMoi_Click(object sender, EventArgs e)
        {
            BQuaTrinhCongTac.Insert(new EQuaTrinhCongTac {
                MaCongTac=idQuaTrinhCongTac,
                MaGiangVien= int.Parse(Session["MaGiangVien"].ToString()),
                MoTaCongTac= txtMoTaCongTac.Text,
                NamcongTac  = txtNamCongTac.Text,
                ThuTuHienThi=int.Parse(txtThuTuHienThi.Text),
            });
            Session["action"] = 1;
            LoadData();
        }

        protected void btSua_Click(object sender, EventArgs e)
        {
            BQuaTrinhCongTac.Update(new EQuaTrinhCongTac { 
                    MaCongTac=idQuaTrinhCongTac,
                    MaGiangVien=int.Parse(Session["MaGiangVien"].ToString()),
                    MoTaCongTac=txtMoTaCongTac.Text,
                    NamcongTac= txtNamCongTac.Text,
                    ThuTuHienThi= int.Parse(txtThuTuHienThi.Text),
            });
            Session["action"] = 2;
            LoadData();
        }

        protected void gvQuaTrinhCongTac_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ChonSua")
            {            
                isClick = true;
                int index = int.Parse(e.CommandArgument.ToString());
                idQuaTrinhCongTac = int.Parse(gvQuaTrinhCongTac.DataKeys[index].Values["MaCongTac"].ToString());
                txtMoTaCongTac.Text = HttpUtility.HtmlDecode(gvQuaTrinhCongTac.Rows[index].Cells[2].Text); ;
                txtNamCongTac.Text = HttpUtility.HtmlDecode(gvQuaTrinhCongTac.Rows[index].Cells[1].Text); ;
                txtThuTuHienThi.Text = HttpUtility.HtmlDecode(gvQuaTrinhCongTac.Rows[index].Cells[3].Text); ;
            }
        }

        protected void gvQuaTrinhCongTac_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            BQuaTrinhCongTac.Delete(int.Parse(gvQuaTrinhCongTac.DataKeys[e.RowIndex].Values[0].ToString()));
            LoadData();
            Session["action"] = 3;
        }


    }
}