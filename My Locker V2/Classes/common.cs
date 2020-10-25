using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace My_Locker_V2.Classes
{
    public class MyCommonUtilities
    {
        public static string Encrypt(string password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            UTF8Encoding encoder = new UTF8Encoding();
            Byte[] originalBytes = encoder.GetBytes(password);
            Byte[] encodedBytes = md5.ComputeHash(originalBytes);
            password = BitConverter.ToString(encodedBytes).Replace("-", "");
            var result = password.ToLower();

            return result;
        }


        public static List<DateTime> GetAllSats(int year)
        {
            List<DateTime> Dates = new List<DateTime>();


            DateTime Date = new DateTime(year, 1, 1);


            while (Date.Year == year)
            {
                if ((Date.DayOfWeek == DayOfWeek.Saturday) && Date.Date > DateTime.Now.Date)
                {
                    Dates.Add(Date);
                    Date = Date.AddDays(1);
                }
                else
                {
                    Date = Date.AddDays(1);
                }
                    

               
            }

            return Dates;
        }

    }
}