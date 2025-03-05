using System;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using EduOne.Fr.helpers;
using EduOne.Fr.Helpers;

namespace EduOne.Exts
{
    public static class StringExtensions
    {
        readonly static CommonHelpers helper = new CommonHelpers();

       public static bool IsNull(this string s)
        {
            return s.Length == 0;
        }

       public static bool IsNull(this object o)
        {
            return o==null;
        }
        public static async Task<string> GetAppInfo()
        {
            string result = "";
            var appsettings = await helper.GetApplicationSettings();
            var setting1 = appsettings.SingleOrDefault(x => x.AppKey == "APPLICATION.NAME");
            var setting2= appsettings.SingleOrDefault(x => x.AppKey == "APPLICATION.VERSION");

            result = setting1.AppValue + ":" + setting2.AppValue;
            return result;
        }
        public static async void DisplayErrorFrDialog(this string field,string message)
        {
            var result = await GetAppInfo();
            XtraMessageBox.Show($"Veuillez entrer ou choisir :{message}", result);
        }

        public static async void DisplayDialog(this string field, string message)
        {
            var result = await GetAppInfo();
            XtraMessageBox.Show($"{message}", result);
        }

        public static async void DisplayExportErrorDialog(this string field, string program)
        {
            var result = await GetAppInfo();
            XtraMessageBox.Show($"Ce fichier est ouvert dans {program}. Veuillez d'abord le fermer.", result);
        }
        public static bool IsEmailValid(this string email)
        {
            return IsValidEmail(email);
        }

        static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                Regex regex = new Regex(pattern);
                return regex.IsMatch(email);
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Returns the left part of this string instance.
        /// </summary>
        /// <param name="count">Number of characters to return.</param>
        public static string Left(this string input, int count)
        {
            return input.Substring(0, Math.Min(input.Length, count));
        }

        /// <summary>
        /// Returns the right part of the string instance.
        /// </summary>
        /// <param name="count">Number of characters to return.</param>
        public static string Right(this string input, int count)
        {
            return input.Substring(Math.Max(input.Length - count, 0), Math.Min(count, input.Length));
        }

        /// <summary>
        /// Returns the mid part of this string instance.
        /// </summary>
        /// <param name="start">Character index to start return the midstring from.</param>
        /// <returns>Substring or empty string when start is outside range.</returns>
        public static string Mid(this string input, int start)
        {
            return input.Substring(Math.Min(start, input.Length));
        }

        /// <summary>
        /// Returns the mid part of this string instance.
        /// </summary>
        /// <param name="start">Starting character index number.</param>
        /// <param name="count">Number of characters to return.</param>
        /// <returns>Substring or empty string when out of range.</returns>
        public static string Mid(this string input, int start, int count)
        {
            return input.Substring(Math.Min(start, input.Length), Math.Min(count, Math.Max(input.Length - start, 0)));
        }
    }
}
