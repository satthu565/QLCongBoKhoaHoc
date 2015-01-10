using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyCongBoKhoaHoc.Business;

namespace QuanLyCongBoKhoaHoc.UserControl
{
    public partial class UcThongKeHocVi : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadCbbHocVi();
            LoadData();
        }

        void LoadData()
        {
            int MaHocVi = int.Parse(cbbHocVi.SelectedValue.ToString());
            gvThongKeHocVi.AutoGenerateColumns = false;
            gvThongKeHocVi.DataSource = BGiangVien.SelectByMaHocVi(MaHocVi);
            gvThongKeHocVi.DataBind();
            TenHocVi.Text = "DANH SÁCH "+ BHocVi.SelectByID(MaHocVi).TenHocVi;
        }

        void LoadCbbHocVi()
        {
            cbbHocVi.DataSource = BHocVi.SelectAll();
            cbbHocVi.DataTextField = "TenHocVi";
            cbbHocVi.DataValueField = "MaHocVi";
            cbbHocVi.DataBind();
        }

        protected void cbbHocVi_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

    }
}