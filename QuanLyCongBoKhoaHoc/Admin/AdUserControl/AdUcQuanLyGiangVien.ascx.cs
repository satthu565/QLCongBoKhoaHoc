using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyCongBoKhoaHoc.Business;
using QuanLyCongBoKhoaHoc.Entities;
using System.IO;

namespace QuanLyCongBoKhoaHoc.Admin.AdUserControl
{
    public partial class AdUcQuanLyGiangVien : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
                LoadData();
                CbbQuyen();
        }

        void LoadData()
        {
            grvGiangVien.AutoGenerateColumns = false;
            grvGiangVien.DataSource = BGiangVien.SelectToanBoThongTin();
            grvGiangVien.DataBind();
        }

        void CbbQuyen()
        {
            cbbQuyen.DataSource = BQuyen.SelectAll();
            cbbQuyen.DataTextField =  "TenQuyen" ;
            cbbQuyen.DataValueField = "MaQuyen" ;
            cbbQuyen.DataBind();
        }

        public string GioiTinh(bool kt)
        {
            if (kt == true)
            {
                return "Nam";
            }
            else
            {
                return "Nữ";
            }
        }

        protected void grvGiangVien_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            BGiangVien.Delete(int.Parse(grvGiangVien.DataKeys[e.RowIndex].Value.ToString()));
            Session["action"] = 3;
            LoadData();

        }
        
        protected void grvGiangVien_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvGiangVien.EditIndex = e.NewEditIndex;
            grvGiangVien.DataBind();
        }

        protected void grvGiangVien_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DropDownList dd = grvGiangVien.Rows[e.RowIndex].FindControl("cbbQuyen") as DropDownList;
            BGiangVien.ADUpdateQuyen(new EGiangVien
            {
               MaGiangVien = int.Parse(grvGiangVien.DataKeys[e.RowIndex].Value.ToString()),
               MaQuyen = int.Parse(dd.SelectedValue.ToString())
            });
            grvGiangVien.EditIndex = -1;
            Session["action"] = 2;
            LoadData();
        }

        protected void grvGiangVien_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvGiangVien.PageIndex = e.NewPageIndex;
            LoadData();
        }

        protected void grvGiangVien_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvGiangVien.EditIndex = -1;
            grvGiangVien.DataBind();
        }

        protected void grvGiangVien_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    DropDownList cbbQuyen = (DropDownList)e.Row.FindControl("cbbQuyen");
                    if (cbbQuyen != null)
                    {
                        cbbQuyen.DataSource = BQuyen.SelectAll();
                        cbbQuyen.DataTextField = "TenQuyen";
                        cbbQuyen.DataValueField = "MaQuyen";
                        cbbQuyen.DataBind();
                    }

                    LinkButton btDelete = (LinkButton)e.Row.Cells[10].Controls[0];
                    if (btDelete != null)
                    {
                        btDelete.Attributes.Add("OnClick", "javascript:return confirm('Bạn có muốn xóa')");
                    }
                }
                catch { }
            }
        }

        protected void btnTimKiemGiangVien_Click(object sender, EventArgs e)
        {
            string TenGiangVien = txtTimTenGiangVien.Value.Trim();
            grvGiangVien.AutoGenerateColumns = false;
            grvGiangVien.DataSource = BGiangVien.AdTimKiemGiangVienTheoTen(TenGiangVien);
            grvGiangVien.DataBind();
        }

        protected void grvGiangVien_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ChonXem")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                Session["MaGiangVien"] = int.Parse(grvGiangVien.DataKeys[index].Value.ToString());
                Response.Redirect("~/CVGiangVien.aspx", true);
            }
        }

        protected void btnThemMoi_Click(object sender, EventArgs e)
        {

            if (FileUpload1.HasFile)
            {
                string filename = "";
                foreach (HttpPostedFile uploadedFile in FileUpload1.PostedFiles)
                {
                    filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + uploadedFile.FileName;
                    uploadedFile.SaveAs(Path.Combine(Server.MapPath("~/images/AnhGiangVien/"), filename));
                    BGiangVien.DangKyGiangVien(new EGiangVien
                    {
                        AnhDaiDien = filename,
                        GioiTinh = bool.Parse(cbbGioiTinh.SelectedValue.ToString()),
                        MaQuyen = int.Parse(cbbQuyen.SelectedValue.ToString()),
                        MatKhau = Router.MaHoaMD5(txtMatKhau.Text.Trim()),     
                        TenDangNhap = txtTaiKhoan.Text.Trim(),
                        TenGiangVien = txtTaiKhoan.Text.Trim(),
                    });
                }      
            }
            else
           {
                     BGiangVien.DangKyGiangVien(new EGiangVien
                      {
                        AnhDaiDien = "",
                        GioiTinh = bool.Parse(cbbGioiTinh.SelectedValue.ToString()),
                        MaQuyen = int.Parse(cbbQuyen.SelectedValue.ToString()),
                        MatKhau = Router.MaHoaMD5(txtMatKhau.Text.Trim()),     
                        TenDangNhap = txtTaiKhoan.Text.Trim(),
                        TenGiangVien = txtTaiKhoan.Text.Trim(),
                    });       
            }
              LoadData();
              Session["action"] = 1; 
        }



    }
}