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
    public partial class AdUcVietTin : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadTheLoai();
        }

        void loadTheLoai()
        {
            cbbTheLoai.DataSource = BMenu.SelectTenMenuTinTuc();
            cbbTheLoai.DataTextField = "TenMenu";
            cbbTheLoai.DataValueField = "MaMenu";
            cbbTheLoai.DataBind();
        }

        void ThongBao(string Loi)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "Thông báo!", "<script>alert('" + Loi + "')</script>", false);
        }

        protected void btnThemTinTuc_Click(object sender, EventArgs e)
        {
            string path = "", filename = "";
            if (FileUpload1.HasFile)
            {
                filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + FileUpload1.FileName;
                path = Server.MapPath("~/images/TinTuc/" + filename);
                FileUpload1.SaveAs(path);
            }

            BTinTuc.Insert(new ETinTuc
            {
                AnhDaiDien = filename,
                MaGiangVien = int.Parse(Session["MaGiangVien"].ToString()),
                MaMenu = int.Parse(cbbTheLoai.SelectedValue),
                MoTa = txtMoTa.Value,
                NgayDang = DateTime.Now,
                NoiDung = txtNoiDung.Text,
                TieuDe = LoaiBoKyTu(txtTieuDe.Value.Trim()),
            });
            Session["action"] = 1;
        }

      public string LoaiBoKyTu(string Chuoi)
        {
            string chinh = Chuoi ;
            string[] kitu = { ":", ".", "?", "<", ">",";" };
            for (int i = 0; i < kitu.Length-1; i++)
            {
                chinh = chinh.Replace(kitu[i], "");
            } 
            return chinh;
        }
        

    }
}