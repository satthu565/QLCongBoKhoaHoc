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
    public partial class Slides : System.Web.UI.UserControl
    {
        public DataTable TbSlide;
        protected void Page_Load(object sender, EventArgs e)
        {
            TbSlide = BSlides.SelectAll();
        }
    }
}