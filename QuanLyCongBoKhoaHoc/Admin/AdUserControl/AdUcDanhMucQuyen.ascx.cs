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
    public partial class AdUcDanhMucQuyen : System.Web.UI.UserControl
    {
        public bool isClick = false;
   

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadDaTa();
        }

        protected void btnThemMoi_Click(object sender, EventArgs e)
        {
            BDanhMucQuyen.Insert(new EDanhMucQuyen
            {
                TenDanhMucQuyen = txtTenQuyen.Text
            });
            LoadDaTa();
            Session["action"] = 1;
        }


        void LoadDaTa()
        {
            grvDanhMucQuyen.AutoGenerateColumns = false;
            grvDanhMucQuyen.DataSource = BDanhMucQuyen.SelectAll();
            grvDanhMucQuyen.DataBind();
        }

        protected void grvQuyen_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvDanhMucQuyen.EditIndex = e.NewEditIndex;
            grvDanhMucQuyen.DataBind();
        }


        protected void grvQuyen_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            BDanhMucQuyen.Delete(int.Parse(grvDanhMucQuyen.DataKeys[e.RowIndex].Value.ToString()));
            Session["action"] = 3;
            LoadDaTa();
        }

        protected void grvQuyen_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    LinkButton btDelete = (LinkButton)e.Row.Cells[3].Controls[0];
                    if (btDelete != null)
                    {
                        btDelete.Attributes.Add("OnClick", "javascript:return confirm('Bạn có muốn xóa')");
                    }
                }
                catch { }
            }
        }

        protected void grvQuyen_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            BDanhMucQuyen.Update(new EDanhMucQuyen
            {
                MaDanhMucQuyen = int.Parse(grvDanhMucQuyen.DataKeys[e.RowIndex].Value.ToString()),
                TenDanhMucQuyen = ((TextBox)grvDanhMucQuyen.Rows[e.RowIndex].FindControl("txtTenDanhMucQuyen")).Text,
            });
            grvDanhMucQuyen.EditIndex = -1;
            LoadDaTa();
            Session["action"] = 2;
            LoadDaTa();
        }

        protected void grvQuyen_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvDanhMucQuyen.EditIndex = -1;
            grvDanhMucQuyen.DataBind();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            BDanhMucQuyen.Reset();
            LoadDaTa();
            Session["action"] = 3;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["action"] = 2;
        }


    }
}