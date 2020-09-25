using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ControleEstoque.Helpers
{
    public static class Cryptography
    {

        public static String HashMd5(String val)
        {        
            var bytes  = Encoding.ASCII.GetBytes(val);
            var md5 = MD5.Create();
            //var AES = Aes.Create();                            
            var hash = md5.ComputeHash(bytes);
            string ret = ""; 
            for(int i = 0; i<hash.Length; i++)
            {
             //X2 indica conversão para string hexadecimal 
             ret += hash[i].ToString("X2");
            }
            return ret;
        }
    }
}