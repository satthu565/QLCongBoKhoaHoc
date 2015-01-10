using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Routing;

namespace QuanLyCongBoKhoaHoc
{
    public class Router
    {
        public static string NonUnicode(string text)
        {
            string[] arr1 = new string[] { "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",  
                    "đ",  
                    "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",  
                    "í","ì","ỉ","ĩ","ị",  
                    "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",  
                    "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",  
                    "ý","ỳ","ỷ","ỹ","ỵ",};
            string[] arr2 = new string[] { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",  
                    "d",  
                    "e","e","e","e","e","e","e","e","e","e","e",  
                    "i","i","i","i","i",  
                    "o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",  
                    "u","u","u","u","u","u","u","u","u","u","u",  
                    "y","y","y","y","y",};
            for (int i = 0; i < arr1.Length; i++)
            {
                text = text.Replace(arr1[i], arr2[i]);
                text = text.Replace(arr1[i].ToUpper(), arr2[i].ToUpper());
            }
            return text.Replace(" ", "-");
        }
        
        public static string MaHoaMD5(string str)
        {
            Byte[] dauvao = ASCIIEncoding.Default.GetBytes(str);
            using (MD5 md5 = new MD5CryptoServiceProvider())
            {
                var daura = md5.ComputeHash(dauvao);
                return BitConverter.ToString(daura).Replace("-","").ToLower();
            }
        }
    }
}