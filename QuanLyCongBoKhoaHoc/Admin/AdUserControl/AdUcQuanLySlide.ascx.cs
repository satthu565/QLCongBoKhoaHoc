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
    public partial class AdUcQuanLySlide : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadSlide();
        }
        void LoadSlide()
        {
            grvSlide.DataSource = BSlides.SelectAll();
            grvSlide.DataBind();
        }

        protected void grvSlide_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    LinkButton btDelete = (LinkButton)e.Row.Cells[5].Controls[0];
                    if (btDelete != null)
                    {
                        btDelete.Attributes.Add("OnClick", "javascript:return confirm('Bạn có muốn xóa')");
                    }
                }
                catch { }

                try
                {
                    Image img = e.Row.FindControl("imgAnhSlide") as Image;
                    FileUpload uploadAnhDaiDien = e.Row.FindControl("uploadAnhSlide") as FileUpload;
                    uploadAnhDaiDien.Attributes.Add("onchange", "readURL(this,'#" + img.ClientID + "')");
                    img.Attributes.Add("OnClick", "OpenUpload('#" + uploadAnhDaiDien.ClientID + "')");
                }
                catch { }
            }
        }

        protected void btnThemMoi_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string filename = "";
                foreach (HttpPostedFile uploadedFile in FileUpload1.PostedFiles)
                {
                    filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + uploadedFile.FileName.Replace(" ", "");
                    uploadedFile.SaveAs(Path.Combine(Server.MapPath("~/images/Slides"), filename));
                    BSlides.Insert(new ESlides
                    {
                        TieuDe = txtTieuDe.Text,
                        MoTa = txtMoTa.Text,
                        Anh = filename
                    });
                }
                LoadSlide();
                Session["action"] = 1;
            }
        }

        protected void grvSlide_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            BSlides.Delete(int.Parse(grvSlide.DataKeys[e.RowIndex].Value.ToString()));
            Session["action"] = 3;
            LoadSlide();
        }

        protected void grvSlide_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvSlide.EditIndex = e.NewEditIndex;
            grvSlide.DataBind();
        }

        protected void grvSlide_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = grvSlide.Rows[e.RowIndex];
            FileUpload uploadAnhDaiDien = row.FindControl("uploadAnhSlide") as FileUpload;
            Label imgAnhDaiDienCu = row.FindControl("imgAnhDaiDienCu") as Label;
            string strAnhDaiDien = "";


            if (uploadAnhDaiDien.FileName != "")
            {
                strAnhDaiDien = DateTime.Now.ToString("yyyyMMddHHmmssfff") + uploadAnhDaiDien.FileName.ToString();
                uploadAnhDaiDien.SaveAs(Path.Combine(Server.MapPath("~/images/Slides/"), strAnhDaiDien));
            }
            else
                strAnhDaiDien = imgAnhDaiDienCu.Text;

            byte idSlide = byte.Parse(grvSlide.DataKeys[e.RowIndex].Value.ToString());
            BSlides.Update(new ESlides
            {
                Anh = strAnhDaiDien,
                TieuDe = ((TextBox)grvSlide.Rows[e.RowIndex].FindControl("txtTieuDe")).Text,
                MoTa = ((TextBox)grvSlide.Rows[e.RowIndex].FindControl("txtMoTa")).Text,
                MaSlide = idSlide,
                ThuTu =0
            });

            grvSlide.EditIndex = -1;
            Session["action"] = 2;
            LoadSlide();
        }

        protected void grvSlide_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvSlide.EditIndex = -1;
            grvSlide.DataBind();
        }
    }
}
