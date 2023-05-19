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
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();


        void PersonelListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select *From TBL_PERSONELLER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            
        }



        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            PersonelListesi();
            sehirlistesi();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtID.Text = dr["ID"].ToString();
                txtAd.Text = dr["AD"].ToString();
                txtSoyad.Text = dr["SOYAD"].ToString();
                mskTelefon1.Text = dr["TELEFON"].ToString();
                mskTC.Text = dr["TC"].ToString();
                txtMail.Text = dr["MAIL"].ToString();
                cmbil.Text = dr["IL"].ToString();
                cmbilce.Text = dr["ILCE"].ToString();
                RchAdres.Text = dr["ADRES"].ToString();
                txtGorev.Text = dr["GOREV"].ToString();
            }
        }


        void temizle()
        {
            txtID.Text = "";
            txtAd.Text = "";
            txtSoyad.Text = "";
            mskTelefon1.Text = "";
            mskTC.Text = "";
            txtMail.Text = "";
            cmbil.Text = "";
            cmbilce.Text = "";
            RchAdres.Text = "";
            txtGorev.Text = "";
            txtAd.Focus();
        }
         
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_PERSONELLER (AD,SOYAD,TELEFON,TC,MAIL,IL,ILCE,ADRES,GOREV) " +
                "values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskTelefon1.Text);
            komut.Parameters.AddWithValue("@p4", mskTC.Text);
            komut.Parameters.AddWithValue("@p5", txtMail.Text);
            komut.Parameters.AddWithValue("@p6", cmbil.Text);
            komut.Parameters.AddWithValue("@p7", cmbilce.Text);
            komut.Parameters.AddWithValue("@p8", RchAdres.Text);
            komut.Parameters.AddWithValue("@p9", txtGorev.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel Bilgileri Eklenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            PersonelListesi();
            temizle();

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("Delete from TBL_PERSONELLER where ID=@p1", bgl.baglanti());
            komutsil.Parameters.AddWithValue("@p1", txtID.Text);
            komutsil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel Bilgileri Silinmiştir !.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            PersonelListesi();
            temizle();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komutguncelle = new SqlCommand("update TBL_PERSONELLER set AD=@P1, SOYAD=@P2, TELEFON=@P3, TC=@P4," +
                "MAIL=@P5, IL=@P6, ILCE=@P7, ADRES=@P8, GOREV=@P9 where ID=@P10", bgl.baglanti());
            komutguncelle.Parameters.AddWithValue("@p1", txtAd.Text);
            komutguncelle.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komutguncelle.Parameters.AddWithValue("@p3", mskTelefon1.Text);
            komutguncelle.Parameters.AddWithValue("@p4", mskTC.Text);
            komutguncelle.Parameters.AddWithValue("@p5", txtMail.Text);
            komutguncelle.Parameters.AddWithValue("@p6", cmbil.Text);
            komutguncelle.Parameters.AddWithValue("@p7", cmbilce.Text);
            komutguncelle.Parameters.AddWithValue("@p8", RchAdres.Text);
            komutguncelle.Parameters.AddWithValue("@p9", txtGorev.Text);
            komutguncelle.Parameters.AddWithValue("@P10", txtID.Text);
            komutguncelle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel Bilgileri Güncellenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            PersonelListesi();
            temizle();
        }


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









        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void ımageSlider3_Click(object sender, EventArgs e)
        {

        }
    }
}
