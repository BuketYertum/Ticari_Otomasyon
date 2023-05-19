using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Ticari_Otomasyon
{
    public partial class FrmMusteriler : Form
    {
        public FrmMusteriler()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();


        void listele()//urunlere tıklayınca urunlerin menu kısmını getiriyor sırasıyla.
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select  *From TBL_MUSTERILER", bgl.baglanti());
            da.Fill(dt);  //dt nin içini da ile doldur demek.
            gridControl1.DataSource = dt;//dt yi gridcontrolde yazdır.
        }


        //illeri yazdırma
        void sehirlistesi()
        {
            SqlCommand komut = new SqlCommand("Select *From TBL_ILLER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbil.Properties.Items.Add(dr[1]);
            }         
            bgl.baglanti().Close();
        }

       
        //ilçeleri yazdırma il'e baglı olarak.
        private void cmbil_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbilce.Properties.Items.Clear();
            SqlCommand komut2 = new SqlCommand("Select ILCE From TBL_ILCELER where SEHIR=@p1", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", cmbil.SelectedIndex + 1); //baslangıcta index degeri 0 oldugu için bizimkide 1 ile basladıgı için +1 yaptık.
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbilce.Properties.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();
        }



        private void FrmMusteriler_Load(object sender, EventArgs e)
        {
            listele();
            sehirlistesi();
            temizle();
           
        }

        //Müşteri Ekleme
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_MUSTERILER (AD,SOYAD,TELEFON,TELEFON2,TC,MAIL,IL,ILCE,ADRES,VERGIDAIRE) values" +
                "(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskTelefon1.Text);
            komut.Parameters.AddWithValue("@p4", mskTelefon2.Text);
            komut.Parameters.AddWithValue("@p5", mskTC.Text);
            komut.Parameters.AddWithValue("@p6", txtMail.Text);
            komut.Parameters.AddWithValue("@p7", cmbil.Text);
            komut.Parameters.AddWithValue("@p8", cmbilce.Text);
            komut.Parameters.AddWithValue("@p9", RchAdres.Text);
            komut.Parameters.AddWithValue("@p10", txtVergiDai.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Müşteri Bilgileri Eklenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
           
        }


        //Müşteri Silme
        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("Delete from TBL_MUSTERILER where ID=@p1", bgl.baglanti());
            komutsil.Parameters.AddWithValue("@p1", txtID.Text);                                           //txtid ye göre o müşteriyi bulup silecek.
            komutsil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("MÜŞTERİ SİLİNDİ !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            listele();//son hallini gride listele...
            temizle();
        }


        //Grid üstünde seçilen satırı txtlere yazdırma, düşürme.
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);//üstüne tıkladığımızveriyi seç. dr ye at.
            if (dr != null)
            {
                txtID.Text = dr["ID"].ToString();
                txtAd.Text = dr["AD"].ToString();
                txtSoyad.Text = dr["SOYAD"].ToString();
                mskTelefon1.Text = dr["TELEFON"].ToString();
                mskTelefon2.Text = dr["TELEFON2"].ToString();
                mskTC.Text = dr["TC"].ToString();
                txtMail.Text = dr["MAIL"].ToString();
                cmbil.Text = dr["IL"].ToString();
                cmbilce.Text = dr["ILCE"].ToString();
                RchAdres.Text = dr["ADRES"].ToString();
                txtVergiDai.Text = dr["VERGIDAIRE"].ToString();
            }
        }


        //Müşteri bilgisi güncelleme
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komutguncelle = new SqlCommand("update TBL_MUSTERILER set AD=@p1, SOYAD=@p2, TELEFON=@p3, TELEFON2=@p4, TC=@p5," +
               "MAIL=@p6, IL=@p7, ILCE=@p8, ADRES=@p9, VERGIDAIRE=@p10 where ID=@p11", bgl.baglanti());
            komutguncelle.Parameters.AddWithValue("@p1", txtAd.Text);
            komutguncelle.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komutguncelle.Parameters.AddWithValue("@p3", mskTelefon1.Text);
            komutguncelle.Parameters.AddWithValue("@p4", mskTelefon2.Text);
            komutguncelle.Parameters.AddWithValue("@p5", mskTC.Text);
            komutguncelle.Parameters.AddWithValue("@p6", txtMail.Text);
            komutguncelle.Parameters.AddWithValue("@p7", cmbil.Text);
            komutguncelle.Parameters.AddWithValue("@p8", cmbilce.Text);
            komutguncelle.Parameters.AddWithValue("@p9", RchAdres.Text);
            komutguncelle.Parameters.AddWithValue("@p10", txtVergiDai.Text);
            komutguncelle.Parameters.AddWithValue("@p11", txtID.Text);
            komutguncelle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Müşteri Bilgileri Güncellendi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
            temizle();
        }


        void temizle()
        {
            txtID.Text = "";
            txtAd.Text = "";
            txtSoyad.Text = "";
            mskTelefon1.Text = "";
            mskTelefon2.Text = "";
            mskTC.Text = "";
            txtMail.Text = "";
            cmbil.Text = "";
            cmbilce.Text = "";
            RchAdres.Text = "";
            txtVergiDai.Text = "";
            txtAd.Focus();

        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            temizle();
        }































        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void cmbilce_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
