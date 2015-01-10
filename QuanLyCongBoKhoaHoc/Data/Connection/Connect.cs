//DevNETCoder 
//CopyRight By DevNET Group
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
//using System.Web;
//using System.Web.Security;

namespace QuanLyCongBoKhoaHoc.Connection
{
	 public static class ConnectionString
	 {
         private static string strconnection = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
         public static string Text
         {
             get { return strconnection; }
             set { strconnection = value; }
         }
	 }
}