using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using EduOne.Fr.helpers;

namespace EduOne.Exts
{
    public static class StringExtensions
    {
        public static void DisplayErrorFrDialog(this string field,string message)
        {
            XtraMessageBox.Show($"Veuillez entrer ou choisir :{message}", ApplicationHelpers.AppName);
        }

        public static void DisplayDialog(this string field, string message)
        {
            XtraMessageBox.Show($"{message}", ApplicationHelpers.AppName);
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
    }
}
