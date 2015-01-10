using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyCongBoKhoaHoc.Business;

namespace QuanLyCongBoKhoaHoc.UserControl
{
    public partial class UcBaiBaoKhoaHoc : System.Web.UI.UserControl
    {
        string[] MaTacGia;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadBaiBaoKhoaHoc();
        }


        void LoadBaiBaoKhoaHoc()
        {
            string MaGiangVien = Session["MaGiangVien"].ToString();
            string TrongNuoc = "";
            string QuocTe = "";
            string Code = "";
            DataTable dt = new DataTable();
            dt = BBaiBao.SelectByChuoiMaTacGia(MaGiangVien);

                    foreach (DataRow row in dt.Rows)
                    {
                        string TenTacGia = "";
                        string TenTG = "";
                        string ChuoiMaTacGiaChuan = HamXuLyChuoi(row["ChuoiMaGiangVienTacGia"].ToString());  // ko con day '-' o dau va cuoi
                        MaTacGia = ChuoiMaTacGiaChuan.Split('-');

                        foreach (var item in MaTacGia)
                        {
                            TenTG = BGiangVien.SelectByID(int.Parse(item)).TenGiangVien;
                            TenTacGia += TenTG + ",";
                        }     

                        // xuất   mặc định giới hạn =0 trong nước , =1 quốc tế .
                        if (row["GioiHan"].ToString() == "True")
                        {
                            TrongNuoc += "<a href=\"/CV-Giang-Vien/YKienTraoDoi/BaiBao/" + row["MaBaiBao"] + "\">" + row["TenBaiBao"] + " </a>  .<b> Tác giả: </b>" + TenTacGia + row["TenTacGiaNgoai"] + ". <b> Nơi công bố: </b>" + row["NoiCongBo"] + "<b>  Số: </b>" + row["MaSo"] + "  <b>  Năm: </b> " + String.Format("{0:dd/MM/yyyy}", row["ThoiGianXuatBan"]) + ". <br/>";
                        }
                        else
                        {
                            QuocTe = "<a href=\"/CV-Giang-Vien/YKienTraoDoi/BaiBao/" + row["MaBaiBao"] + "\" >" + row["TenBaiBao"] + " </a> .<b> Tác giả: </b>" + TenTacGia + row["TenTacGiaNgoai"] + ". <b> Nơi công bố: </b>" + row["NoiCongBo"] + "<b>  Số: </b>" + row["MaSo"] + "  <b> Năm: </b>" + String.Format("{0:dd/MM/yyyy}", row["ThoiGianXuatBan"]) + ". <br/>";
                        }
                      }
                    if (TrongNuoc=="")
                    {
                        TrongNuoc += "Chưa có dữ liệu trong nước";
                    }
                    if (QuocTe =="")
                    {
                        QuocTe += "Chưa có dữ liệu quốc tế";
                    }

              Code += "<h4> Trong Nước </h4>"+ TrongNuoc +"<h4> Quốc tế </h4>"+ QuocTe + "<br>";
              LbBaiBaoKhoaHoc.Text = Code; 
            }
        

        //xoa ky tu dau va cuoi '-' 
        string HamXuLyChuoi(string ChuoiDau)
        {
            string s1 = ChuoiDau.Trim().Remove(0, 1);
            string s2 = s1.Remove(s1.Length - 1, 1);
            return s2;
        }

        void ThongBao(string Loi)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "Thông báo!", "<script>alert('" + Loi + "')</script>", false);
        } 


    }
}