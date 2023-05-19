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
    public partial class FrmFirmalar : Form
    {
        public FrmFirmalar()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        void FirmaListele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select *From TBL_FIRMALAR", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        //ŞEHİR LİSTESİ
        void sehirlistesi()
        {
            SqlCommand komutsehir = new SqlCommand("Select *From TBL_ILLER", bgl.baglanti());
            SqlDataReader dr = komutsehir.ExecuteReader();
            while (dr.Read())
            {
                cmbil.Properties.Items.Add(dr[1]);
            }
            bgl.baglanti().Close();
        }

        //ilçeleri yazdırma il'e baglı olarak.
        private void cmbil_SelectedIndexChanged_1(object sender, EventArgs e)
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


        void carikodaciklamalar()
        {
            SqlCommand komut = new SqlCommand("Select FIRMAKOD1 from TBL_KODLAR", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                rchOzelKod1.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();
        }




        private void FrmFirmalar_Load(object sender, EventArgs e)
        {
            FirmaListele();
            sehirlistesi();
            carikodaciklamalar();
        }



        //Firma Kayıt Ekleme
        private void BtnKaydet_Click_1(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Insert into TBL_FIRMALAR (AD,YETKILISTATU,YETKILIADSOYAD,YETKILITC,SEKTOR," +
                "TELEFON1,TELEFON2,TELEFON3,MAIL,FAX,IL,ILCE,VERGIDAIRE,ADRES,OZELKOD1,OZELKOD2,OZELKOD3) values (@p1,@p2,@p3,@p4,@p5,@p6," +
                "@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtYetkiliGorev.Text);
            komut.Parameters.AddWithValue("@p3", txtYetkili.Text);
            komut.Parameters.AddWithValue("@p4", mskTC.Text);
            komut.Parameters.AddWithValue("@p5", txtSektor.Text);
            komut.Parameters.AddWithValue("@p6", mskTel1.Text);
            komut.Parameters.AddWithValue("@p7", mskTel2.Text);
            komut.Parameters.AddWithValue("@p8", mskTel3.Text);
            komut.Parameters.AddWithValue("@p9", txtMail.Text);
            komut.Parameters.AddWithValue("@p10", mskFax.Text);
            komut.Parameters.AddWithValue("@p11", cmbil.Text);
            komut.Parameters.AddWithValue("@p12", cmbilce.Text);
            komut.Parameters.AddWithValue("@p13", txtVergiDai.Text);
            komut.Parameters.AddWithValue("@p14", RchAdres.Text);
            komut.Parameters.AddWithValue("@p15", txtKod1.Text);
            komut.Parameters.AddWithValue("@p16", txtKod2.Text);
            komut.Parameters.AddWithValue("@p17", txtKod3.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Firma Bilgisi Eklenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FirmaListele();
            temizle();
        }



        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("Delete from TBL_FIRMALAR where ID=@p1", bgl.baglanti());
            komutsil.Parameters.AddWithValue("@p1", txtID.Text);
            komutsil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Firma Bilgisi Silinmiştir !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            FirmaListele();
            temizle();
        }


        //grid üstündeki bilgileri araçlara aktarma.
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if(dr != null)
            {
                txtID.Text = dr["ID"].ToString();
                txtAd.Text = dr["AD"].ToString();
                txtYetkiliGorev.Text = dr["YETKILISTATU"].ToString();
                txtYetkili.Text = dr["YETKILIADSOYAD"].ToString();
                mskTC.Text = dr["YETKILITC"].ToString();
                txtSektor.Text = dr["SEKTOR"].ToString();
                mskTel1.Text = dr["TELEFON1"].ToString();
                mskTel2.Text = dr["TELEFON2"].ToString();
                mskTel3.Text = dr["TELEFON3"].ToString();
                txtMail.Text = dr["MAIL"].ToString();
                mskFax.Text = dr["FAX"].ToString();
                cmbil.Text = dr["IL"].ToString();
                cmbilce.Text = dr["ILCE"].ToString();
                txtVergiDai.Text = dr["VERGIDAIRE"].ToString();
                RchAdres.Text = dr["ADRES"].ToString();
                rchOzelKod1.Text = dr["OZELKOD1"].ToString();
                rchOzelKod2.Text = dr["OZELKOD2"].ToString();
                rchOzelKod3.Text = dr["OZELKOD3"].ToString();
            }   
        }


        //Firma Bilgisi Güncelleme
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komutguncelle = new SqlCommand("update TBL_FIRMALAR set AD=@p1, YETKILISTATU=@p2, YETKILIADSOYAD=@p3, YETKILITC=@p4," +
                "SEKTOR=@p5,TELEFON1= @p6, TELEFON2=@p7, TELEFON3=@p8,MAIL= @p9, FAX=@p10,IL= @p11, ILCE=@p12, VERGIDAIRE=@p13, ADRES=@p14," +
                "OZELKOD1=@p15, OZELKOD2=@p16, OZELKOD3=@p17 where ID=@p18", bgl.baglanti());
            komutguncelle.Parameters.AddWithValue("@p1", txtAd.Text);
            komutguncelle.Parameters.AddWithValue("@p2", txtYetkiliGorev.Text);
            komutguncelle.Parameters.AddWithValue("@p3", txtYetkili.Text);
            komutguncelle.Parameters.AddWithValue("@p4", mskTC.Text);
            komutguncelle.Parameters.AddWithValue("@p5", txtSektor.Text);
            komutguncelle.Parameters.AddWithValue("@p6", mskTel1.Text);
            komutguncelle.Parameters.AddWithValue("@p7", mskTel2.Text);
            komutguncelle.Parameters.AddWithValue("@p8", mskTel3.Text);
            komutguncelle.Parameters.AddWithValue("@p9", txtMail.Text);
            komutguncelle.Parameters.AddWithValue("@p10", mskFax.Text);
            komutguncelle.Parameters.AddWithValue("@p11", cmbil.Text);
            komutguncelle.Parameters.AddWithValue("@p12", cmbilce.Text);
            komutguncelle.Parameters.AddWithValue("@p13", txtVergiDai.Text);
            komutguncelle.Parameters.AddWithValue("@p14", RchAdres.Text);
            komutguncelle.Parameters.AddWithValue("@p15", txtKod1.Text);
            komutguncelle.Parameters.AddWithValue("@p16", txtKod2.Text);
            komutguncelle.Parameters.AddWithValue("@p17", txtKod3.Text);
            komutguncelle.Parameters.AddWithValue("@P18", txtID.Text);
            komutguncelle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Firma Bilgileri Güncellenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            FirmaListele();
            temizle();
        }

        void temizle()
        {
            txtID.Text = "";
            txtAd.Text = "";
            txtYetkiliGorev.Text = "";
            txtYetkili.Text = "";
            mskTC.Text = "";
            txtSektor.Text = "";
            mskTel1.Text = "";
            mskTel2.Text = "";
            mskTel3.Text = "";
            txtMail.Text = "";
            mskFax.Text = "";
            cmbil.Text = "";
            cmbilce.Text = "";
            txtVergiDai.Text = "";
            RchAdres.Text = "";
            txtKod1.Text = "";
            txtKod2.Text = "";
            txtKod3.Text = "";
            txtAd.Focus();
        }



        private void simpleButton1_Click(object sender, EventArgs e)
        {
            temizle();
        }
























        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

      



        private void BtnKaydet_Click(object sender, EventArgs e)
        {


        }

      
    }
}
