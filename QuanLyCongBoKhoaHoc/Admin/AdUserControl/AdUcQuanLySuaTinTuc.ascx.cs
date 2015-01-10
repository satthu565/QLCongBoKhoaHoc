
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyCongBoKhoaHoc.Entities;
using QuanLyCongBoKhoaHoc.Business;

namespace QuanLyCongBoKhoaHoc.Admin.AdUserControl
{
    public partial class AdUcQuanLySuaTinTuc : System.Web.UI.UserControl
    {
        static int idTinTuc;

        protected void Page_Load(object sender, EventArgs e)
        {
            loadCBBTenMenu();
            LoadData();  
        }

        void LoadData()
        {
            idTinTuc = int.Parse(Session["MaTinSua"].ToString());
            ETinTuc tintuc = BTinTuc.SelectByID(idTinTuc);
            if (tintuc.AnhDaiDien == "")
                AnhDaiDien.ImageUrl = "~/Images/default.png";
            else
                AnhDaiDien.ImageUrl = "~/Images/TinTuc/" + tintuc.AnhDaiDien;

            txtMoTa.InnerText = HttpUtility.HtmlDecode(tintuc.MoTa);
            txtNoiDung.Text = HttpUtility.HtmlDecode(tintuc.NoiDung);
            txtTieuDe.Value = HttpUtility.HtmlDecode(tintuc.TieuDe);
            cbbTheLoai.SelectedValue = tintuc.MaMenu.ToString();
        }
        void loadCBBTenMenu()
        {
            cbbTheLoai.DataSource = BMenu.SelectTenMenuTinTuc();
            cbbTheLoai.DataTextField = "TenMenu";
            cbbTheLoai.DataValueField = "MaMenu";
            cbbTheLoai.DataBind();
        }

        protected void btnSua_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile == false)
            {
                if (AnhDaiDien.ImageUrl != "")
                {
                    string AnhDaiDien1 = BTinTuc.SelectByID(idTinTuc).AnhDaiDien;
                    BTinTuc.Update(new ETinTuc
                    {
                        AnhDaiDien = AnhDaiDien1,
                        MaGiangVien = int.Parse(Session["MaGiangVien"].ToString()),
                        MaMenu = int.Parse(cbbTheLoai.SelectedValue.ToString()),
                        idTinTuc = idTinTuc,
                        MoTa = txtMoTa.Value,
                        NgayDang = DateTime.Now,
                        NoiDung = txtNoiDung.Text,
                        TieuDe = txtTieuDe.Value
                    });
                    Session["action"] = 2;
                }

            }
            else
            {
                try
                {
                    if (KiemTra() == true)
                    {
                        string filename = "";
                        filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + FileUpload1.FileName;
                        string path = Server.MapPath("~/images/TinTuc/" + filename);
                        FileUpload1.SaveAs(path);
                        BTinTuc.Update(new ETinTuc
                        {
                            AnhDaiDien = filename,
                            MaGiangVien = int.Parse(Session["MaGiangVien"].ToString()),
                            MaMenu = int.Parse(cbbTheLoai.SelectedValue.ToString()),
                            idTinTuc = idTinTuc,
                            MoTa = txtMoTa.Value,
                            NgayDang = DateTime.Now,
                            NoiDung = txtNoiDung.Text,
                            TieuDe = txtTieuDe.Value
                        });
                        Session["action"] = 2;
                    }
                }
                catch
                {
                }
            }
            Response.Redirect("~/Admin/Default.aspx?idpage=qltt");
        }

        void ThongBao(string Loi)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "Thông báo!", "<script>alert('" + Loi + "')</script>", false);
        }

        private bool KiemTra()
        {

            if (txtTieuDe.Value == "")
            {
                ThongBao("không được để trống tiêu đề");
                return false;
            }
            else if (txtMoTa.Value == "")
            {
                ThongBao("Không được để trống mô tả");
            }
            return true;
        }


    }
}