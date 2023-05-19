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
    public partial class FrmFaturalar : Form
    {
        public FrmFaturalar()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();


        void temizle()
        {
            txtFaturaBilgiID.Text = "";
            txtSeriNo.Text = "";
            txtSiraNo.Text = "";
            mskTarih.Text = "";
            mskSaat.Text = "";
            txtVergiDaire.Text = "";
            txtAlici.Text = "";
            txtTeslimEden.Text = "";
            txtTeslimAlan.Text = "";
            txtFaturaDetayID.Text = "";
            txtUrunAD.Text = "";
            txtMiktar.Text = "";
            txtFİyat.Text = "";
            txtTutar.Text = "";
            txtPersonel.Text = "";
            txtSeriNo.Focus();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            temizle();
        }


        void Listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select *From TBL_FATURABILGI", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }



        private void FrmFaturalar_Load(object sender, EventArgs e)
        {
            temizle();
            Listele();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
    
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtFaturaBilgiID.Text = dr["FATURABILGIID"].ToString();
                txtSeriNo.Text = dr["SERI"].ToString();
                txtSiraNo.Text = dr["SIRANO"].ToString();
                mskTarih.Text = dr["TARIH"].ToString();
                mskSaat.Text = dr["SAAT"].ToString();
                txtVergiDaire.Text = dr["VERGIDAIRE"].ToString();
                txtAlici.Text = dr["ALICI"].ToString();
                txtTeslimEden.Text = dr["TESLIMEDEN"].ToString();
                txtTeslimAlan.Text = dr["TESLIMALAN"].ToString();
            }
        }

        private void BtnGuncelle_Click_1(object sender, EventArgs e)
        {
            SqlCommand komutguncelle = new SqlCommand("update TBL_FATURABILGI set SERI=@P1, SIRANO=@P2,TARIH=@P3, SAAT=@P4," +
                "VERGIDAIRE=@P5, ALICI=@P6, TESLIMEDEN=@P7,TESLIMALAN=@P8 where FATURABILGIID=@p9", bgl.baglanti());
            komutguncelle.Parameters.AddWithValue("@p1", txtSeriNo.Text);
            komutguncelle.Parameters.AddWithValue("@p2", txtSiraNo.Text);
            komutguncelle.Parameters.AddWithValue("@p3", mskTarih.Text);
            komutguncelle.Parameters.AddWithValue("@p4", mskSaat.Text);
            komutguncelle.Parameters.AddWithValue("@p5", txtVergiDaire.Text);
            komutguncelle.Parameters.AddWithValue("@p6", txtAlici.Text);
            komutguncelle.Parameters.AddWithValue("@p7", txtTeslimEden.Text);
            komutguncelle.Parameters.AddWithValue("@p8", txtTeslimAlan.Text);
            komutguncelle.Parameters.AddWithValue("@p9", txtFaturaBilgiID.Text);
            komutguncelle.ExecuteNonQuery();
            bgl.baglanti();
            MessageBox.Show("Fatura Bilgisi Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Listele();
            temizle();
        }

        private void BtnKaydet_Click_1(object sender, EventArgs e)
        {

            if (txtFaturaBilgiID.Text == "") //Faturadetaydaki faturaid boş ise faturabilgiyi kaydedicek.
            {
                SqlCommand komut = new SqlCommand("Insert into TBL_FATURABILGI (SERI,SIRANO,TARIH,SAAT,VERGIDAIRE,ALICI,TESLIMEDEN,TESLIMALAN) " +
                    "values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txtSeriNo.Text);
                komut.Parameters.AddWithValue("@p2", txtSiraNo.Text);
                komut.Parameters.AddWithValue("@p3", mskTarih.Text);
                komut.Parameters.AddWithValue("@p4", mskSaat.Text);
                komut.Parameters.AddWithValue("@p5", txtVergiDaire.Text);
                komut.Parameters.AddWithValue("@p6", txtAlici.Text);
                komut.Parameters.AddWithValue("@p7", txtTeslimEden.Text);
                komut.Parameters.AddWithValue("@p8", txtTeslimAlan.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti();
                MessageBox.Show("Fatura Bilgisi Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
                temizle();
            }
            //Firma Carisi
            if (txtFaturaBilgiID.Text != "" && cmbCariTür.Text == "Firma")
            {
                double miktar, tutar, fiyat;
                miktar = Convert.ToDouble(txtMiktar.Text);
                fiyat = Convert.ToDouble(txtFİyat.Text);
                tutar = miktar * fiyat;
                txtTutar.Text = tutar.ToString();

                SqlCommand komut2 = new SqlCommand("Insert into TBL_FATURADETAY (URUNAD, MIKTAR, FIYAT, TUTAR, FATURAID ) values" +
                    " (@p1,@p2,@p3,@p4,@p5)", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", txtUrunAD.Text);
                komut2.Parameters.AddWithValue("@p2", txtMiktar.Text);
                komut2.Parameters.AddWithValue("@p3", decimal.Parse( txtFİyat.Text));
                komut2.Parameters.AddWithValue("@p4", decimal.Parse( txtTutar.Text));
                komut2.Parameters.AddWithValue("@p5", txtPersonel.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti();


                //Hareket Tablosuna Veri Girişi
                SqlCommand komut3 = new SqlCommand("Insert into TBL_FIRMAHAREKETLER (URUNID,ADET,PERSONEL,FIRMA,FIYAT,TOPLAM,FATURAID,TARIH)" +
                    "values(@h1,@h2,@h3,@h4,@h5,@h6,@h7,@h8)", bgl.baglanti());
                komut3.Parameters.AddWithValue("@h1", txtFaturaDetayID.Text);
                komut3.Parameters.AddWithValue("@h2", txtMiktar.Text);
                komut3.Parameters.AddWithValue("@h3", txtPersonel.Text);
                komut3.Parameters.AddWithValue("@h4", txtFirma.Text);
                komut3.Parameters.AddWithValue("@h5", decimal.Parse( txtFİyat.Text));
                komut3.Parameters.AddWithValue("@h6", decimal.Parse( txtTutar.Text));
                komut3.Parameters.AddWithValue("@h7", txtFaturaBilgiID.Text);
                komut3.Parameters.AddWithValue("@h8", mskTarih.Text);
                komut3.ExecuteNonQuery();
                bgl.baglanti().Close();


                //stok sayıını azaltma
                SqlCommand komut4 = new SqlCommand("update TBL_URUNLER set ADET=ADET-@s1 where ID=@s2", bgl.baglanti());
                komut4.Parameters.AddWithValue("@s1", txtMiktar.Text);
                komut4.Parameters.AddWithValue("@s2", txtFaturaDetayID.Text);
                komut4.ExecuteNonQuery();
                bgl.baglanti().Close();


                MessageBox.Show("Fatura ait ürün eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
                temizle();
            }





            
            //if (txtFaturaBilgiID.Text == "" ) //Faturadetaydaki faturaid boş ise faturabilgiyi kaydedicek.
            //{
            //    SqlCommand komut = new SqlCommand("Insert into TBL_FATURABILGI (SERI,SIRANO,TARIH,SAAT,VERGIDAIRE,ALICI,TESLIMEDEN,TESLIMALAN) " +
            //        "values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());
            //    komut.Parameters.AddWithValue("@p1", txtSeriNo.Text);
            //    komut.Parameters.AddWithValue("@p2", txtSiraNo.Text);
            //    komut.Parameters.AddWithValue("@p3", mskTarih.Text);
            //    komut.Parameters.AddWithValue("@p4", mskSaat.Text);
            //    komut.Parameters.AddWithValue("@p5", txtVergiDaire.Text);
            //    komut.Parameters.AddWithValue("@p6", txtAlici.Text);
            //    komut.Parameters.AddWithValue("@p7", txtTeslimEden.Text);
            //    komut.Parameters.AddWithValue("@p8", txtTeslimAlan.Text);
            //    komut.ExecuteNonQuery();
            //    bgl.baglanti();
            //    MessageBox.Show("Fatura Bilgisi Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    Listele();
            //    temizle();
            //}
            //Müşteri Carisi
            if (txtFaturaBilgiID.Text != "" && cmbCariTür.Text == "Müşteri")
            {
                double miktar, tutar, fiyat;
                miktar = Convert.ToDouble(txtMiktar.Text);
                fiyat = Convert.ToDouble(txtFİyat.Text);
                tutar = miktar * fiyat;
                txtTutar.Text = tutar.ToString();

                SqlCommand komut2 = new SqlCommand("Insert into TBL_FATURADETAY (URUNAD, MIKTAR, FIYAT, TUTAR, FATURAID ) values" +
                    " (@p1,@p2,@p3,@p4,@p5)", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", txtUrunAD.Text);
                komut2.Parameters.AddWithValue("@p2", txtMiktar.Text);
                komut2.Parameters.AddWithValue("@p3", decimal.Parse(txtFİyat.Text));
                komut2.Parameters.AddWithValue("@p4", decimal.Parse(txtTutar.Text));
                komut2.Parameters.AddWithValue("@p5", txtFaturaBilgiID.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti();


                //Hareket Tablosuna Veri Girişi
                SqlCommand komut3 = new SqlCommand("Insert into TBL_MUSTERIHAREKETLER (URUNID,ADET,PERSONEL,MUSTERI,FIYAT,TOPLAM,FATURAID,TARIH)" +
                    "values(@h1,@h2,@h3,@h4,@h5,@h6,@h7,@h8)", bgl.baglanti());
                komut3.Parameters.AddWithValue("@h1", txtFaturaDetayID.Text);
                komut3.Parameters.AddWithValue("@h2", txtMiktar.Text);
                komut3.Parameters.AddWithValue("@h3", txtPersonel.Text);
                komut3.Parameters.AddWithValue("@h4", txtFirma.Text);
                komut3.Parameters.AddWithValue("@h5", decimal.Parse(txtFİyat.Text));
                komut3.Parameters.AddWithValue("@h6", decimal.Parse(txtTutar.Text));
                komut3.Parameters.AddWithValue("@h7", txtFaturaBilgiID.Text);
                komut3.Parameters.AddWithValue("@h8", mskTarih.Text);
                komut3.ExecuteNonQuery();
                bgl.baglanti().Close();


                //stok sayıını azaltma
                SqlCommand komut4 = new SqlCommand("update TBL_URUNLER set ADET=ADET-@s1 where ID=@s2", bgl.baglanti());
                komut4.Parameters.AddWithValue("@s1", txtMiktar.Text);
                komut4.Parameters.AddWithValue("@s2", txtFaturaDetayID.Text);
                komut4.ExecuteNonQuery();
                bgl.baglanti().Close();


                MessageBox.Show("Fatura ait ürün eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
                temizle();
            }


        }

        private void BtnSil_Click_1(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("Delete from TBL_FATURABILGI where FATURABILGIID=@p1", bgl.baglanti());
            komutsil.Parameters.AddWithValue("@P1", txtFaturaBilgiID.Text);
            komutsil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Fatura Bilgisi Silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Listele();
            temizle();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmFaturaUrunDetay fr = new FrmFaturaUrunDetay(); //bu forma git.
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                fr.id = dr["FATURABILGIID"].ToString();
            }
            fr.Show();
        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select URUNAD,SATISFIYAT From TBL_URUNLER where ID=@P1", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", txtFaturaDetayID.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtUrunAD.Text = dr[0].ToString();
                txtFİyat.Text = dr[1].ToString();
            }
            bgl.baglanti().Close();
        }
    }
}
