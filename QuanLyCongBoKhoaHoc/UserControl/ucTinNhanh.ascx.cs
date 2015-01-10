using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyCongBoKhoaHoc.Business;
using QuanLyCongBoKhoaHoc.Entities;
using System.Data;


namespace QuanLyCongBoKhoaHoc.UserControl
{
    public partial class ucTinNhanh : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TinNhanh();
        }

        void TinNhanh()
        {
            string tin = "";
            DataTable dtTinNhanh = new DataTable();
            dtTinNhanh = BTinTuc.SelectTinTucByMaMenu(28);

            for (int i = 0; i < dtTinNhanh.Rows.Count ; i++)
            {
                tin += "<a style=\"color:#382A7F\"href=\"/Tin-tuc/" + ChuanHoaTieuDe(dtTinNhanh.Rows[i]["TieuDe"].ToString()) + "/" + dtTinNhanh.Rows[i]["idTinTuc"].ToString() + "\">" + dtTinNhanh.Rows[i]["TieuDe"].ToString() + "</a>" + "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ";
            }
            lbTinMoi.Text = tin;
        }

        public string ChuanHoaTieuDe(string chuoi)
        {
            if (chuoi != "")
            {
                string ChuoiMoi = chuoi.Replace(" ", "-");
                       ChuoiMoi = ChuoiMoi.Replace("\"", "'");
                       ChuoiMoi = ChuoiMoi.Replace("?", "");
                return ChuoiMoi;
            }
            return "";
        }

    }
}