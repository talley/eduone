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
using EduOne.Fr.Models;

namespace EduOne.Fr.Admins.Enrollments
{
	public partial class fraEnrollmentNotes: DevExpress.XtraEditors.XtraForm
	{
        readonly string _email;
        readonly int _Id;
        readonly CommonHelpers helper = new CommonHelpers();
        public fraEnrollmentNotes(string email, int Id)
        {
            InitializeComponent();
            _email = email;
            _Id =Id;
        }

        private async void fraEnrollmentNotes_Load(object sender, EventArgs e)
        {
            var result1 = new List<Models.EnrollmentNotes>();
            var result2 = new List<Models.EnrollmentNotes>();

            var enrollments = await helper.GetEnrollmentsAsync();

            if (enrollments.Any())
            {
                var enrollment1 = enrollments.SingleOrDefault(x => x.InscriptionID == _Id);
                var yy1 = new Models.EnrollmentNotes { Notes = enrollment1.Notes,AjouterAu=enrollment1.AjouterAu };
                result1.Add(yy1);
            }

            var notes = await helper.GetEnrollmentNotesAsync();
            var final = new List<Data>();


            if (notes.Any())
            {
                var xx = notes.OrderByDescending(x=>x.AjouterAu).Where(x=>x.Id==_Id).ToList();
                result2 = xx;
                result1.AddRange(result2);

                foreach (var item in result1.OrderByDescending(x => x.AjouterAu).ToList())
                {
                    final.Add(new Data { Notes = item.Notes });
                }
                gridControl1.DataSource = final;


            }
            else
            {
                foreach (var item in result1.OrderByDescending(x => x.AjouterAu).ToList())
                {
                    final.Add(new Data { Notes = item.Notes });
                }
                gridControl1.DataSource = final;
            }
        }

       public struct Data
        {
            public string Notes { get; set; }
        }
    }
}