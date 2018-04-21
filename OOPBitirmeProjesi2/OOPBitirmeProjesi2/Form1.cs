using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPBitirmeProjesi2
{
    /*
       1. Form ilk açıldığında Resim Seç ve EKLE butonları aktif, Güncelle ve Sil butonları pasif olacak. Ünvanları içinde bulunduran ComboBox dolu olacak. 
       2. Ünvanlar: Müdür, Yönetici, CEO, Temizlikçi, Danışman
       3. ListView'a, Ekle butonuna tıklanıp kaydı yapılabilen tüm personellerin ilgili bilgileri yazdırılacak.
       4. ListView'dan herhangi bir satır seçildiği zaman SİL butonu aktif, EKLE butonu pasif hale gelecek.
       5. SİL'e tıklandığı zaman seçili olan satır ListView'dan silinecek; SİL pasif, EKLE aktif hale gelecek.
       6. ListView'dan herhangi bir satıra çift tıklandığı zaman GÜNCELLE aktif, EKLE pasif hale gelecek. Çift tıklanan satırdaki kayıtlı bilgilerle "Personel Bilgileri" paneli doldurulacak.
       7. GÜNCELLE'ye tıklandığında seçili olan satırdaki tüm bilgiler güncellenecek. GÜNCELLE butonu pasif, EKLE aktif hale gelecek.
       8. EKLE butonuna tıklandığında "Personel Bilgileri" paneli temizlenecek ve yeni kayıt ListView'a eklenecek.
     */

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnResimSec.Enabled = true;
            btnEkle.Enabled = true;
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
            cmbUnvan.Items.Add("Müdür");
            cmbUnvan.Items.Add("Yönetici");
            cmbUnvan.Items.Add("CEO");
            cmbUnvan.Items.Add("Temizlikçi");
            cmbUnvan.Items.Add("Danışman");
            lstPersonel.GridLines = true;
            


        }

        private void lstPersonel_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            
            
            

        }
        
        OpenFileDialog openFileDialog = new OpenFileDialog();
        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (cmbUnvan.Text == "")
                MessageBox.Show("Lütfen bir ünvan seçiniz!");
            else
            {
                Personel psnl = new Personel();
                psnl.Name = txtAd.Text;
                psnl.Lastname = txtSoyad.Text;
                psnl.TCID = txtTcNo.Text;
                psnl.Position = cmbUnvan.Text;
                psnl.PhoneNo = txtTelefon.Text;
                psnl.Email = txtMail.Text;
                psnl.Adress = txtAdres.Text;
                psnl.Birthday = dtDogumTarihi.Value;
                psnl.JobStartDate = dtIseGirisTarihi.Value;
                psnl.Image = pbResim.ImageLocation;
                





                ListViewItem item1 = new ListViewItem(psnl.TCID);
                item1.Tag = psnl;
                item1.SubItems.Add(psnl.Name);
                item1.SubItems.Add(psnl.Lastname);
                item1.SubItems.Add(Convert.ToString(psnl.JobStartDate.Date));
                item1.SubItems.Add(psnl.PhoneNo);
                item1.SubItems.Add(psnl.Email);

                lstPersonel.Items.AddRange(new ListViewItem[] { item1 });

            }
            
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            btnGuncelle.Enabled = false;
            btnEkle.Enabled = true;
            temp.Name = txtAd.Text;
            temp.Lastname = txtSoyad.Text;
            temp.TCID = txtTcNo.Text;
            temp.Position = cmbUnvan.Text;
            temp.PhoneNo = txtTelefon.Text;
            temp.Email = txtMail.Text;
            temp.Adress = txtAdres.Text;
            temp.Birthday = dtDogumTarihi.Value;
            temp.JobStartDate = dtIseGirisTarihi.Value;
            temp.Image = pbResim.ImageLocation;

            ListViewItem item1 = new ListViewItem();
            item1.Tag = temp;
            item1.Text = txtTcNo.Text;
            item1.SubItems.Add(temp.Name);
            item1.SubItems.Add(temp.Lastname);
            item1.SubItems.Add(Convert.ToString(temp.JobStartDate.Date));
            item1.SubItems.Add(temp.PhoneNo);
            item1.SubItems.Add(temp.Email);

            

            int indexid = lstPersonel.SelectedItems[0].Index;
            lstPersonel.Items.RemoveAt(indexid);
            lstPersonel.Items.Insert(indexid, item1);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (lstPersonel.SelectedItems.Count <= 0)
                return;
            lstPersonel.Items.Remove(lstPersonel.SelectedItems[0]);
        }

        Personel temp;
        private void lstPersonel_DoubleClick(object sender, EventArgs e)
        {
            if (lstPersonel.SelectedItems.Count <= 0)
                return;

            btnGuncelle.Enabled = true;
            btnSil.Enabled = false;
            temp = lstPersonel.SelectedItems[0].Tag as Personel;
            txtAd.Text = temp.Name;
            txtTcNo.Text = temp.TCID;
            txtSoyad.Text = temp.Lastname;
            txtMail.Text = temp.Email;
            txtTelefon.Text = temp.PhoneNo;
            txtAdres.Text = temp.Adress;
            dtDogumTarihi.Value = temp.Birthday;
            dtIseGirisTarihi.Value = temp.JobStartDate;
            cmbUnvan.Text = temp.Position;
            pbResim.ImageLocation = temp.Image;





        }

        private void btnResimSec_Click(object sender, EventArgs e)
        {
            {

                OpenFileDialog dlg = new OpenFileDialog();

                dlg.Title = "Open Image";
                

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    
                    pbResim.Image = Image.FromFile(dlg.FileName);
                    
                }

                dlg.Dispose();

            }
        }

        private void lstPersonel_Click(object sender, EventArgs e)
        {
            btnEkle.Enabled = false;
            btnSil.Enabled = true;
        }
    }
}
