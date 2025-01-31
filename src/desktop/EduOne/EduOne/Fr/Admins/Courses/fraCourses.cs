using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.XtraEditors;
using EduOne.Exts;
using EduOne.Fr.Models;
using EduOne.Helpers;
using EduOne.Fr.Models;

using Config = System.Configuration.ConfigurationManager;
using Newtonsoft.Json;

namespace EduOne.Fr.Admins.Courses
{
    public partial class fraCourses : DevExpress.XtraEditors.XtraForm
    {
        string _email;
        public fraCourses(string email)
        {
            InitializeComponent();
            _email = email;
        }

        private async void fraCourses_Load(object sender, EventArgs e)
        {
            var courses=await GetCoursesAsync();
            gridControl1.DataSource=courses;
            gridView1.BestFitColumns();
        }

        private bool IsAppInProd()
        {
            bool isAppInProd = bool.Parse(Config.AppSettings["IS_PROD"]);
            return isAppInProd;
        }

        private async Task<List<EduOne.Fr.Models.Courses>> GetCoursesAsync()
        {
            var courses=new List<Models.Courses>();

            string apiUrl = WebServerHelpers.GetApiApplicationUrl(IsAppInProd()) + "Courses";

            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(apiUrl).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        courses=JsonConvert.DeserializeObject<List<Models.Courses>>(responseData);
                    }
                    else
                    {
                        XtraMessageBox.Show($"Failed to call the web service. Status code: {response.StatusCode}");
                    }
                }
                catch (ArgumentNullException ex)
                {
                    XtraMessageBox.Show($"An error occurred: {ex.Message}");
                }
                catch (HttpRequestException ex)
                {
                    XtraMessageBox.Show($"An error occurred: {ex.Message}");
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"An error occurred: {ex.Message}");
                }
            }

            return courses;
        }
    }
}