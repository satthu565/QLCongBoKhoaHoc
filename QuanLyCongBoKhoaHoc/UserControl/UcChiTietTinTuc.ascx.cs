using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyCongBoKhoaHoc.Business;
using QuanLyCongBoKhoaHoc.Entities;

namespace QuanLyCongBoKhoaHoc.UserControl
{
    public partial class UcChiTietTinTuc : System.Web.UI.UserControl
    {
        public ETinTuc TinTuc;

        protected void Page_Load(object sender, EventArgs e)
        {
           int MaTinTuc = int.Parse(Session["MaTinTuc"].ToString());
           TinTuc = BTinTuc.SelectByID(MaTinTuc);
        }
    }
}