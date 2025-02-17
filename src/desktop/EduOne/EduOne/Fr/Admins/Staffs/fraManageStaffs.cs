using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.Office.Utils;
using DevExpress.XtraEditors;
using EduOne.Exts;
using EduOne.Fr.Helpers;
using EduOne.Fr.Models;
using EduOne.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EduOne.Fr.Admins.Staffs
{
    public partial class fraManageStaffs : DevExpress.XtraEditors.XtraForm
    {
        string _email;
        CommonHelpers helpers=new CommonHelpers();
        public fraManageStaffs(string email)
        {
            InitializeComponent();
            _email = email;
        }

        private async void fraManageStaffs_Load(object sender, EventArgs e)
        {
            var staffs=await GetStaffsAsync();
            gridControl1.DataSource = staffs;
            gridView1.BestFitColumns();
        }

        private async Task<List<Models.Staffs>> GetStaffsAsync()
        {
            var result=new List<Models.Staffs>();

            string apiUrl = WebServerHelpers.GetApiApplicationUrl(helpers.IsAppInProd()) + "Staffs";

            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(apiUrl).ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                         result=JsonConvert.DeserializeObject<List<Models.Staffs>>(responseData);
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"An error occurred: {ex.Message}");

                }
            }
            return result;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                var pdf_file = Path.Combine(Path.GetTempPath(), "Staffs.pdf");
                if (File.Exists(pdf_file))
                {
                    File.Delete(pdf_file);
                }

                if (gridView1.RowCount > 0)
                {

                 gridControl1.ExportToPdf(pdf_file);
                    Process.Start(pdf_file);
                }
            }
            catch (Exception)
            {
               " ".DisplayExportErrorDialog(" Adobe Reader");
            }
        }

        private void btnexcel_Click(object sender, EventArgs e)
        {
            try
            {
                var excel_file = Path.Combine(Path.GetTempPath(), "Staffs.xlsx");
                if (File.Exists(excel_file))
                {
                    File.Delete(excel_file);
                }

                if (gridView1.RowCount > 0)
                {

                    gridControl1.ExportToXlsx(excel_file);
                    Process.Start(excel_file);
                }
            }
            catch (Exception)
            {
                " ".DisplayExportErrorDialog(" Adobe Reader");
            }
        }

        private void btnhtml_Click(object sender, EventArgs e)
        {
            try
            {
                var html_file = Path.Combine(Path.GetTempPath(), "Staffs.html");
                if (File.Exists(html_file))
                {
                    File.Delete(html_file);
                }

                if (gridView1.RowCount > 0)
                {

                    gridControl1.ExportToHtml(html_file);
                    Process.Start(html_file);
                }
            }
            catch (Exception)
            {
                " ".DisplayExportErrorDialog(" Adobe Reader");
            }
        }
    }

}