using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyCongBoKhoaHoc.Entities;
using QuanLyCongBoKhoaHoc.Business;
using QuanLyCongBoKhoaHoc.Connection;
using System.Data.SqlClient;

namespace QuanLyCongBoKhoaHoc.Admin
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static EGiangVien[] BindDatatable(string TenGiangVien)
        {
            DataTable dt = new DataTable();
            List<EGiangVien> details = new List<EGiangVien>();

            using (SqlConnection con = new SqlConnection(ConnectionString.Text))
            {
                using (SqlCommand cmd = new SqlCommand("select * from GiangVien where TenGiangVien like N'%"+TenGiangVien+"%'", con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dtrow in dt.Rows)
                    {
                        EGiangVien user = new EGiangVien();
                        user.MaGiangVien = int.Parse(dtrow["MaGiangVien"].ToString());
                        user.TenGiangVien = dtrow["TenGiangVien"].ToString();
                        user.AnhDaiDien = dtrow["AnhDaiDien"].ToString();
                        details.Add(user);
                    }
                }
            }
            return details.ToArray();
        }
    
    }
}