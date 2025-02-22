using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit.Export.Doc;
using EduOne.Exts;
using EduOne.Fr.helpers;
using EduOne.Fr.Helpers;
using EduOne.Fr.Models;
using EduOne.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Card;
using DevExpress.XtraBars.Ribbon.Gallery;
using DevExpress.XtraBars.Ribbon;
using System.Threading;

namespace EduOne.Fr.Admins.Students
{
    public partial class fraEditStudent : DevExpress.XtraEditors.XtraForm
    {
        string _email;
        int _id;
        CommonHelpers helper = new CommonHelpers();
        public fraEditStudent(string email, int id)
        {
            InitializeComponent();
            _email = email;
            _id = id;
        }

        private async void fraEditStudent_Load(object sender, EventArgs e)
        {
            txtid.Text = _id.ToString();

            var students = await helper.GetStudentsAsync();
            if (students.Any())
            {
                var student=students.SingleOrDefault(x=> x.Id == _id);
                txtaddress.Text=student.Addresse;
                txtaddresse2.Text = student.Addresse2;
                txtemail.Text = student.Email;
                txtetat.Text = student.État;
                txtfax.Text = student.Fax;
                txtfname.Text = student.Prénom;
                txtid.Text=student.Id.ToString();
                txtlieuxnaissance.Text = student.LieuNaissance;
                txtlname.Text = student.Nom;
                txtnotes.Text = student.Notes;
                txtphone.Text = student.TelePhone;
                txtsname.Text = student.Surnom;
                txtville.Text = student.Ville;

                if (student.Statut)
                {
                    ckstatus.Checked = true;
                }

                drpcountries.Text = student.Pays;
                dtdateinsc.Text=student.Date_Inscription.ToString();
                dtdatenaissance.Text=student.DateNaissance.ToString();
                drpgenders.Text = student.Genre;
            }

            var studentIdentifications = await helper.GetStudentsIdentificationsAsync();

            if (studentIdentifications.Any())
            {
                var studentPhotos=studentIdentifications.Where(x=>x.Id==_id).ToList();

                if (studentPhotos.Any())
                {
                    //  var photos = studentPhotos.Select(x => new { Image = ByteArrayToImage(x.FileData) }).ToList();
                    //   gridControl1.DataSource = photos;

                    LoadGalleryAsync();
                   // SetupCardView();
                }
            }
        }

        private async void LoadGalleryAsync()
        {
            var studentIdentifications = await helper.GetStudentsIdentificationsAsync();
            // Initialize the GalleryControl
            GalleryControl galleryControl = galleryControl1;
            GalleryControlGallery gallery = galleryControl.Gallery;
            GalleryItemGroup group = new GalleryItemGroup();

            // Resize gallery for better view
           gallery.ImageSize = new Size(250, 400); // Adjust as needed
            gallery.ItemImageLayout = DevExpress.Utils.Drawing.ImageLayoutMode.ZoomOutside;
            gallery.ShowItemText = true; // Show names if needed

            // Retrieve student images
            if (studentIdentifications.Any())
            {
                var studentPhotos = studentIdentifications.Where(x => x.Id == _id).ToList();
                var students=await helper.GetStudentsAsync();
                var studentData = (from student in students
                                  join photo in studentPhotos
                                  on student.Id equals photo.Id
                                  select new
                                  {
                                      Id= student.Id,
                                      Nom = student.Nom + " " + student.Prénom,
                                      photo.FileData
                                }).ToList();

                if (studentData.Any())
                {
                    foreach (var student in studentData)
                    {
                        Image studentImage = ByteArrayToImage(student.FileData);
                        if (studentImage != null)
                        {
                            GalleryItem item = new GalleryItem
                            {
                                Image = studentImage,
                                Caption = student.Nom, // Display student name
                                Description = $"{ApplicationHelpers.GetAppDomain()} ID: " + student.Id // Optional
                            };

                            group.Items.Add(item);
                        }
                    }
                }
            }

            // Add group to the gallery
            gallery.Groups.Add(group);
           galleryControl.Dock = DockStyle.Fill;

            // Add GalleryControl to the form
          //  this.Controls.Add(galleryControl1);
        }

        /* private void SetupCardView()
         {
             CardView cardView = new CardView(gridControl1);
             gridControl1.MainView = cardView;

             // Create an image column
             GridColumn imageColumn = new GridColumn
             {
                 Caption = "Photo",
                 FieldName = "Image",
                 Visible = true,
                 UnboundType = DevExpress.Data.UnboundColumnType.Object
             };
             cardView.Columns.Add(imageColumn);

             // Create a repository item for image display
             RepositoryItemPictureEdit pictureEdit = new RepositoryItemPictureEdit();
             pictureEdit.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;

             // Assign repository item to column
            // gridControl1.RepositoryItems.Add(pictureEdit);
             imageColumn.ColumnEdit = pictureEdit;
         }*/

        private Image ByteArrayToImage(byte[] byteArray)
        {
            if (byteArray == null || byteArray.Length == 0)
                return null;

            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }

        private void btnbrowse_Click(object sender, EventArgs e)
        {
            var tempUpload = "c:\\temp";
            if (!Directory.Exists(tempUpload))
            {
                Directory.CreateDirectory(tempUpload);
            }
            xtraOpenFileDialog1.Title = "Sélectionnez un fichier image";
            xtraOpenFileDialog1.InitialDirectory = "c:\\temp";
            xtraOpenFileDialog1.Filter = "Image Files|*.png;*.jpg;*.jpeg";

            if (xtraOpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Get the path of specified file.
                string filePath = xtraOpenFileDialog1.FileName;
                txtimagefile.Text = filePath;

                // Read the contents of the file into a stream.
                var fileStream = xtraOpenFileDialog1.OpenFile();
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    pictureEdit1.Image = Image.FromStream(reader.BaseStream);
                    btnupload.Enabled = true;
                }
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnupdate_Click(object sender, EventArgs e)
        {
            var Id = _id;
            var lname = txtlname.Text;
            var fname = txtfname.Text.Trim();
            var surname = txtsname.Text.Trim();
            var lieux = txtlieuxnaissance.Text.Trim();
            var datenaiss = dtdatenaissance.Text.Trim();
            var gender = drpgenders.Text;
            var email = txtemail.Text.Trim();
            var phone = txtphone.Text;
            var fax = txtfax.Text.Trim();
            var address = txtaddress.Text.Trim();
            var address2 = txtaddresse2.Text.Trim();
            var city = txtville.Text.Trim();
            var etat = txtetat.Text.Trim();
            var country = drpcountries.Text;
            var dateinscrib = dtdateinsc.Text.Trim();
            var status = ckstatus.Checked;
            var notes = txtnotes.Text;


            if (lname.Length == 0)
            {
                lname.DisplayErrorFrDialog("Nom");
            }
            else if (fname.Length == 0)
            {
                fname.DisplayErrorFrDialog(" Prénom");
            }
            else if (lieux.Length == 0)
            {
                lieux.DisplayErrorFrDialog(" Lieux Naissance");//
            }
            else if (datenaiss.Length == 0)
            {
                datenaiss.DisplayErrorFrDialog(" Date Naissance");
            }
            else if (gender.Length == 0)
            {
                gender.DisplayErrorFrDialog(" Genre");
            }
            else if (email.Length == 0)
            {
                email.DisplayErrorFrDialog("Email");
            }
            else if (!email.IsEmailValid())
            {
                "".DisplayErrorFrDialog(" Email Valide");
            }
            else if (phone.Length == 0)
            {
                phone.DisplayErrorFrDialog(" Téléphone");
            }
            else if (address.Length == 0)
            {
                phone.DisplayErrorFrDialog(" Adresse");
            }
            else if (city.Length == 0)
            {
                "".DisplayErrorFrDialog(" Ville");
            }
            else if (etat.Length == 0)
            {
                "".DisplayErrorFrDialog(" État");
            }
            else if (country.Length == 0)
            {
                "".DisplayErrorFrDialog(" Pays");//dateinscrib
            }
            else if (dateinscrib.Length == 0)
            {
                "".DisplayErrorFrDialog(" Date d`inscription");//
            }
            else if (notes.Length == 0)
            {
                "".DisplayErrorFrDialog(" Notes");//
            }
            else
            {
                var students =await helper.GetStudentsAsync();
                var edit = students.SingleOrDefault(x => x.Id == _id);
                var data = new
                {
                    Id = Id,
                    Nom = lname,
                    Prénom = fname,
                    Surnom = surname,
                    LieuNaissance = lieux,
                    DateNaissance = DateTime.Parse(dtdatenaissance.EditValue.ToString()),
                    Genre = drpgenders.Text,
                    Email = email,
                    TelePhone = phone,
                    Fax = fax,
                    Addresse = address,
                    Addresse2 = address2,
                    Ville = city,
                    État = etat,
                    Pays = drpcountries.Text,
                    Date_Inscription = DateTime.Parse(dtdateinsc.EditValue.ToString()),
                    Notes = notes,
                    Statut = status,
                    ModifierAu = DateTime.Now,
                    ModifierPar = ApplicationHelpers.GetSystemUser(email),
                    AjouterAu =edit.AjouterAu,
                    AjouterPar =edit.AjouterPar
                };

                string apiUrl = WebServerHelpers.GetApiApplicationUrl(helper.IsAppInProd()) + $"Students/{Id}";
                using (var client = new HttpClient())
                {
                    try
                    {
                        var jsonData = System.Text.Json.JsonSerializer.Serialize(data);

                        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                        var response = await client.PutAsync(apiUrl, content).ConfigureAwait(false);

                        if (response.IsSuccessStatusCode)
                        {
                            var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            Invoke(new Action(() =>
                            {
                                "".DisplayDialog("L`eleve(etudiant) a été mis a jour.");
                                ".".DisplayDialog("Veuillez ajouter la photo ou la pièce d'identité de l'étudiant(eleve)");
                                xtraTabControl1.SelectedTabPageIndex = 1;
                                btnupdate.Enabled = false;
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

        private async void btnupload_Click(object sender, EventArgs e)
        {
            var Id=int.Parse(txtid.Text);
            string filePath = txtimagefile.Text.Trim(); // Full path of selected file
            string fileName = Path.GetFileName(filePath); // Extract only file name

            await UploadFile(filePath, fileName);
        }

        private async Task UploadFile1(string filePath, string fileName)
        {
            string apiUrl = WebServerHelpers.GetApiApplicationUrl(helper.IsAppInProd()) + $"Commons/UploadImage/{_id}";
            using (var client = new HttpClient())
            {
                using (var content = new MultipartFormDataContent())
                {
                    using (var fileStream = File.OpenRead(filePath))
                    {
                        content.Add(new StreamContent(fileStream), "file", fileName);

                        var response = await client.PostAsync(apiUrl, content);
                        var result = await response.Content.ReadAsStringAsync();

                        Invoke(new Action(() =>
                        {
                            ".".DisplayDialog("L'image de l'étudiant a été téléchargée.");
                        }));

                    }
                }
            }
        }

        private async Task UploadFile(string filePath,string fileName)
        {
            string apiUrl = WebServerHelpers.GetApiApplicationUrl(helper.IsAppInProd()) + $"StudentIdentifications";
            using (var client = new HttpClient())
            {

                    using (var fileStream = File.OpenRead(filePath))
                    {
                      //  content.Add(new StreamContent(fileStream), "file", fileName);

                        var data = new
                        {
                            UID = Guid.NewGuid(),
                            Id = _id,
                            FileName = fileName,
                            ContentType = "Text/Image",
                            FileData = File.ReadAllBytes(filePath),
                            AjouterAu = DateTime.Now,
                            AjouterPar = ApplicationHelpers.GetSystemUser(_email)
                        };

                        var jsonData = System.Text.Json.JsonSerializer.Serialize(data);

                        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                        var response = await client.PostAsync(apiUrl, content).ConfigureAwait(false);

                        if (response.IsSuccessStatusCode)
                        {
                            var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                        Invoke(new Action(() =>
                         {
                             "".DisplayDialog("La photo de l'étudiant a été téléchargée.");
                             xtraTabControl1.SelectedTabPageIndex = 2;
                             btnupload.Enabled = false;
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
            }
        }

        private void galleryControl1_Gallery_ItemClick(object sender, GalleryItemClickEventArgs e)
        {
            using(var form=new frGalleryViewer())
            {
                Image selectedImage = e.Item.Image;

                (form.Controls[0] as PictureEdit).Image = selectedImage;

                form.ShowDialog();
            }
        }
    }
}