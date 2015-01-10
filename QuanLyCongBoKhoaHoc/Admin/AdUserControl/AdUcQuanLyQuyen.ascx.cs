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
    public partial class AdUcQuanLyQuyen : System.Web.UI.UserControl
    {
        public bool isClick = false;
        static int idQuyen = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadDaTa();
            if (!IsPostBack)
            {
                LoadQuyen();
            }
        }

        protected void btnThemMoi_Click(object sender, EventArgs e)
        {
            string chon = "";
            for (int i = 0; i < CheckBoxQuyen.Items.Count; i++)
            {
                if (CheckBoxQuyen.Items[i].Selected)
                {
                    chon += CheckBoxQuyen.Items[i].Value + " ";
                }
            }
            BQuyen.Insert(new EQuyen
            {
                TenQuyen = txtTenQuyen.Text,
                ChuoiDanhMucQuyen = chon.Trim()
            });
            LoadDaTa();
        }

        protected void btnSua_Click(object sender, EventArgs e)
        {
            string chon1 = "";
            for (int i = 0; i < CheckBoxQuyen.Items.Count; i++)
            {
                if (CheckBoxQuyen.Items[i].Selected)
                {
                    chon1 += CheckBoxQuyen.Items[i].Value + " ";
                }
            }

            BQuyen.Update(new EQuyen
            {
                MaQuyen = idQuyen,
                TenQuyen = txtTenQuyen.Text,
                ChuoiDanhMucQuyen = chon1.Trim()
            });
            BoCheckbox();
            LoadDaTa();
            Session["action"] = 2;
        }

        void ThongBao(string Loi)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "Thông báo!", "<script>alert('" + Loi + "')</script>", false);
        }

        void LoadDaTa()
        {
            grvQuanLyQuyen.AutoGenerateColumns = false;
            grvQuanLyQuyen.DataSource = BQuyen.SelectAll();
            grvQuanLyQuyen.DataBind();
        }

        void LoadQuyen()
        {
            CheckBoxQuyen.DataSource = BDanhMucQuyen.SelectAll();
            CheckBoxQuyen.DataTextField = "TenDanhMucQuyen";
            CheckBoxQuyen.DataValueField = "MaDanhMucQuyen";
            CheckBoxQuyen.DataBind();
        }

        void BoCheckbox()
        {
            for (int i = 0; i < CheckBoxQuyen.Items.Count; i++)
            {
                CheckBoxQuyen.Items[i].Selected = false;
            }
            txtTenQuyen.Text = "";
        }

        

        protected void grvQuanLyQuyen_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ChonSua")
            {
                // găn checknen
                BoCheckbox();
                int index = int.Parse(e.CommandArgument.ToString());
                idQuyen = int.Parse(grvQuanLyQuyen.Rows[index].Cells[0].Text);
                string chon = grvQuanLyQuyen.Rows[index].Cells[2].Text;
                //ThongBao(chon);
                string[] mang = chon.Split(' ');
                if (mang != null && mang[0].ToString() != "&nbsp;")
                {
                    foreach (var item in mang)
                    {
                        int vitri = int.Parse(item);
                        for (int i = 0; i < CheckBoxQuyen.Items.Count; i++)
                        {
                            if (CheckBoxQuyen.Items[i].Value == item)
                            {
                                CheckBoxQuyen.Items[i].Selected = true;
                            }
                        }
                    }
                }
                txtTenQuyen.Text = HttpUtility.HtmlDecode(grvQuanLyQuyen.Rows[index].Cells[1].Text);
                isClick = true;
            }
        }

        protected void grvQuanLyQuyen_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    LinkButton btDelete = (LinkButton)e.Row.Cells[4].Controls[0];
                    if (btDelete != null)
                    {
                        btDelete.Attributes.Add("OnClick", "javascript:return confirm('Bạn có muốn xóa')");
                    }
                }
                catch { }
            }
        }

        protected void grvQuanLyQuyen_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            BQuyen.Delete(int.Parse(grvQuanLyQuyen.DataKeys[e.RowIndex].Value.ToString()));
            Session["action"] = 3;
            LoadDaTa();
        }
    }
}