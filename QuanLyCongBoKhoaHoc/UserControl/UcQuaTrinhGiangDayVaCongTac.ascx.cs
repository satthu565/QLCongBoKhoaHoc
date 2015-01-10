using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using QuanLyCongBoKhoaHoc.Business;

namespace QuanLyCongBoKhoaHoc.UserControl
{
    public partial class UcQuaTrinhGiangDayVaCongTac : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadQuaTrinhCongTac();
        }

        void LoadQuaTrinhCongTac()
        {
            int MaGiangVien = int.Parse(Session["MaGiangVien"].ToString());
            string code = "";
            DataTable dt = new DataTable();
            dt = BQuaTrinhCongTac.SelectByMaGiangVien(MaGiangVien);
            foreach (DataRow row in dt.Rows)
            {
                code += "<p>" + row["NamCongTac"] + "." + row["MoTaCongTac"] + "</p>" ;
            }
            if (code =="")
            {
                code += "<b> Quá trình công tác của giảng viên chưa được nhập </b>";
            }
            LbQuaTrinhCongTac.Text = code;
        }


    }
}