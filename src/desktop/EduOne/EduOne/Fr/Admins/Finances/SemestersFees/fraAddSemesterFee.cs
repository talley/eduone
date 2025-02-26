using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using EduOne.Fr.Helpers;
using EduOne.Exts;
using EduOne.Helpers;
using System.Net.Http;
using EduOne.Fr.helpers;
using EduOne.Fr.Models;
using DevExpress.XtraGrid.Views.Grid;
using System.Diagnostics;
using System.IO;

namespace EduOne.Fr.Admins.Finances.SemestersFees
{
	public partial class fraAddSemesterFee: DevExpress.XtraEditors.XtraForm
	{
        readonly string _email;
        readonly CommonHelpers helper = new CommonHelpers();
        public fraAddSemesterFee(string email)
		{
            InitializeComponent();
            _email = email;
		}

        private async void fraAddSemesterFee_Load(object sender, EventArgs e)
        {
            var semesters = await helper.GetSemestersAsync();

            var semestersfees = await helper.GetSemestersFeesAsync();

            var semesters_in_fees = semestersfees.Select(x => x.SemestreId).ToList();
            var result = new List<SemesestersFees>();

            if (semestersfees.Any())
            {
                foreach (var item in semestersfees)
                {
                    foreach (var x in semesters_in_fees)
                    {
                        if (item.SemestreId == x)
                        {
                            //SemestreId is in the list ,remove it from the list
                            var find = semesters.SingleOrDefault(y=> y.ID == item.SemestreId);
                            semesters.Remove(find);
                        }
                    }
                }

                Invoke(new Action(() =>
                {
                    var needed = semesters.Where(x=>x.Statut).Select(x => new
                    {
                        x.ID,x.Semestre,x.Statut
                    }).ToList();

                    drpsemesters.Properties.DataSource = needed;
                    drpsemesters.Properties.DisplayMember = "Semestre";
                    drpsemesters.Properties.ValueMember = "ID";
                    drpsemesters.Properties.BestFit();
                }));
                var xresult = await Task.WhenAll(semestersfees.Select(async x => new
                {
                    x.Id,
                    Semestre = await GetSemesterAsync(x.SemestreId), // Await inside Select
                    x.Frais,
                    x.Notes,
                    x.AjouterAu,
                    x.AjouterPar,
                    x.ModifierAu,
                    x.ModifierPar
                }));

                var resultList = xresult.ToList();


                gridControl1.DataSource = resultList;
                gridView1.BestFitColumns();

            }
            else
            {
                lblmsg.Text = "IL N'Y A RIEN À FAIRE ICI";
                if (semesters != null)
                {
                    var needed = semesters.Select(x => new
                    {
                        x.ID,
                        x.Semestre,
                        x.Statut,
                        x.Année
                    }).ToList();

                    Invoke(new Action(() =>
                    {
                        drpsemesters.Properties.DataSource = needed;
                        drpsemesters.Properties.DisplayMember = "Semestre";
                        drpsemesters.Properties.ValueMember = "ID";
                        drpsemesters.Properties.BestFit();
                    }));

                }

                var semesterfees = await helper.GetSemestersFeesAsync();
                gridControl1.DataSource = semesterfees;
                gridView1.BestFitColumns();
            }
            //var x2 = drpsemesters.
            //if (x2 == null)
            //{
            //    lblmsg.Text = "Tous les semestres ont des frais.";
            //}

        }

        private async Task<string> GetSemesterAsync(int semestreId)
        {
           var semesters=await helper.GetSemestersAsync();
            var semester = semesters.SingleOrDefault(x => x.ID == semestreId);
            return semester.Semestre;
        }

        private   void drpsemesters_EditValueChanged(object sender, EventArgs e)
        {
            //var editvalue = drpsemesters.EditValue.ToString();
            //if (editvalue != null)
            //{
            //    var ivalue = int.Parse(editvalue);
            //    var semesterfees = await helper.GetSemestersFeesAsync();
            //    if (semesterfees != null)
            //    {
            //        var semesterFee = semesterfees.SingleOrDefault(x => x.SemestreId == ivalue);
            //        txtfees.Text = semesterFee.Frais.ToString();
            //    }
            //}
        }

        private async void btnadd_Click(object sender, EventArgs e)
        {
            var s_semester = drpsemesters.Text;
            var s_fees = txtfees.Text;
            var s_notes = txtnotes.Text;
            if (s_semester.Length == 0)
            {
                "".DisplayErrorFrDialog("Semestre");
            }
            else if (s_fees.Length == 0 || s_fees=="0")
            {
                "".DisplayErrorFrDialog("Frais");
            }
            else if (s_notes.Length == 0)
            {
                "".DisplayErrorFrDialog("Notes");
            }
            else
            {

                string apiUrl = WebServerHelpers.GetApiApplicationUrl(helper.IsAppInProd()) + "SemesestersFees";

                using (var client = new HttpClient())
                {
                    try
                    {
                        var data = new
                        {
                            Id=0,
                            SemestreId=int.Parse(drpsemesters.EditValue.ToString()),
                            Frais=decimal.Parse(s_fees),
                            Notes=s_notes,
                            AjouterAu=DateTime.Now,
                            AjouterPar=ApplicationHelpers.GetSystemUser(_email)
                        };

                        var jsonData = System.Text.Json.JsonSerializer.Serialize(data);

                        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                        var response = await client.PostAsync(apiUrl, content).ConfigureAwait(false);

                        if (response.IsSuccessStatusCode)
                        {
                            var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            Invoke(new Action(() =>
                            {
                                "".DisplayDialog($"Ce cours ({s_semester} ) a été créé");
                                fraAddSemesterFee_Load(null, null);
                                btnadd.Enabled = false;
                            }));
                        }
                        else
                        {
                            Invoke(new Action(() =>
                            {
                                XtraMessageBox.Show($"Failed to call the web service. Status code: {response.StatusCode}");
                            }));
                        }
                    }
                    catch (ArgumentNullException ex)
                    {
                        Invoke(new Action(() =>
                        {
                            XtraMessageBox.Show($"An error occurred: {ex.Message}");
                        }));
                    }
                    catch (HttpRequestException ex)
                    {
                        Invoke(new Action(() =>
                        {
                            XtraMessageBox.Show($"An error occurred: {ex.Message}");
                        }));
                    }
                    catch (Exception ex)
                    {
                        Invoke(new Action(() =>
                        {
                            XtraMessageBox.Show($"An error occurred: {ex.Message}");
                        }));
                    }
                }
            }
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var view = gridView1;

            if (gridControl1.MainView is GridView)
            {
                DialogResult ds = XtraMessageBox.Show(this, "Êtes-vous sûr de vouloir mettre à jour les informations du frais de ce semestre?", ApplicationHelpers.AppName, MessageBoxButtons.YesNo);
                if (ds == DialogResult.Yes)
                {
                    var oid = view.GetRowCellValue(view.FocusedRowHandle, "Id");
                    var id = int.Parse(oid.ToString());
                    var edit_user_form = new fraEditSemesterFee("test@test.com", id);
                    edit_user_form.ShowDialog();

                }
                else
                {
                    "".DisplayDialog("La transaction a été annulée.");
                }
            }
        }

        private void btnexcel_Click(object sender, EventArgs e)
        {
            try
            {
                var xlsx_file = Path.Combine(Path.GetTempPath(), "FraiSemestres.xlsx");
                if (File.Exists(xlsx_file))
                {
                    File.Delete(xlsx_file);
                }
                if (gridView1.RowCount > 0)
                {

                    gridControl1.ExportToXlsx(xlsx_file);
                    Process.Start(xlsx_file);
                }
            }
            catch (Exception ex)
            {

                ".".DisplayDialog("Ce fichier est ouvert dans Excel Veuillez le fermer.");
            }
        }

        private void btnpdf_Click(object sender, EventArgs e)
        {

            try
            {
                var pdf_file = Path.Combine(Path.GetTempPath(), "FraiSemestres.pdf");
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
            catch (Exception ex)
            {

                ".".DisplayDialog("Ce fichier est ouvert dans Adobe Reader. Veuillez le fermer.");
            }
        }

        private void btnhtml_Click(object sender, EventArgs e)
        {
            try
            {
                var html_file = Path.Combine(Path.GetTempPath(), "FraiSemestres.html");
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
            catch (Exception ex)
            {

                ".".DisplayDialog("Ce fichier est ouvert dans Internet browser. Veuillez le fermer.");
            }
        }
    }
}