﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.Charts;


namespace Ticari_Otomasyon
{
    public partial class FrmKasa : Form
    {
        public FrmKasa()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        //--------------------------------------------------------GİRİŞ HAREKETLERİ--------------------------------------------------------------------


        void musterihareket()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Execute MusteriHareketler", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void firmahareket()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Execute FirmaHareketler", bgl.baglanti());
            da2.Fill(dt2);
            gridControl3.DataSource = dt2;
        }



        public string ad;
        private void FrmKasa_Load(object sender, EventArgs e)
        {
            lblAktifKullanici.Text = ad;//Burada ise ad'ı yazdırıyoruz.
            musterihareket();
            firmahareket();


            //Toplam Tutarı Hesaplama
            SqlCommand komut1 = new SqlCommand("Select Sum(Tutar) From TBL_FATURADETAY", bgl.baglanti());
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                lblToplamTutar.Text = dr1[0].ToString() + " TL";
            }
            bgl.baglanti().Close();


            //Son Ayın Fatura Ödemeleri
            SqlCommand komut2 = new SqlCommand("Select (ELEKTRIK+SU+DOGALGAZ+INTERNET+EKSTRA) FROM TBL_GIDERLER order by ID asc", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                lblOdemeler.Text = dr2[0].ToString();
            }
            bgl.baglanti().Close();


            //Son Ayın Personel Maasları
            SqlCommand komut3 = new SqlCommand("Select (MAASLAR) From TBL_GIDERLER", bgl.baglanti());
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                lblPersonelMaaslari.Text = dr3[0].ToString();
            }
            bgl.baglanti().Close();



            //personel Sayısı Hesaplama
            SqlCommand komut4 = new SqlCommand("Select Count(*) From TBL_PERSONELLER", bgl.baglanti());
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                lblPersonelSayisi.Text = dr4[0].ToString();
            }
            bgl.baglanti().Close();



            //Müşteri Sayısı Hesaplama
            SqlCommand komut5 = new SqlCommand("Select ID From TBL_MUSTERILER", bgl.baglanti());
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                lblMusteriSayisi.Text = dr5[0].ToString();
            }
            bgl.baglanti().Close();



            //Firma Sayısı Hesaplama
            SqlCommand komut6 = new SqlCommand("Select ID From TBL_FIRMALAR", bgl.baglanti());
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                lblFirmaSayisi.Text = dr6[0].ToString();
            }
            bgl.baglanti().Close();



            //Firma Şehir Sayısı Hesaplama
            SqlCommand komut7 = new SqlCommand("Select Count(Distinct(IL)) From TBL_FIRMALAR", bgl.baglanti()); //şEHİRLERİ TEKRARSIZ OLARAK SAY.
            SqlDataReader dr7 = komut7.ExecuteReader();
            while (dr7.Read())
            {
                lblSehirSayisi.Text = dr7[0].ToString();
            }
            bgl.baglanti().Close();


            //Müşteri Şehir Sayısı Hesaplama
            SqlCommand komut8 = new SqlCommand("Select Count(Distinct(IL)) From TBL_MUSTERILER", bgl.baglanti()); //şEHİRLERİ TEKRARSIZ OLARAK SAY.
            SqlDataReader dr8 = komut8.ExecuteReader();
            while (dr8.Read())
            {
                lblMsehirsayisi.Text = dr8[0].ToString();
            }
            bgl.baglanti().Close();


            //Stok Sayısı Hesaplama
            SqlCommand komut9 = new SqlCommand("Select Sum(ADET) From TBL_URUNLER", bgl.baglanti()); //şEHİRLERİ TEKRARSIZ OLARAK SAY.
            SqlDataReader dr9 = komut9.ExecuteReader();
            while (dr9.Read())
            {
                lblStokSayisi.Text = dr9[0].ToString();
            }
            bgl.baglanti().Close();




            //---------------------------------------------------ÇIKIŞ HAREKETLERİ-----------------------------------------------------------

            DataTable dt12 = new DataTable();
            SqlDataAdapter da12 = new SqlDataAdapter("Select *From TBL_GIDERLER", bgl.baglanti());
            da12.Fill(dt12);
            gridControl2.DataSource = dt12;
            bgl.baglanti().Close();

        }



        int sayac = 0;

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            sayac++;

            //Elektirik
            if (sayac > 0 && sayac <= 5)
            {
                groupControl11.Text = "ELEKTRİK";
                chartControl1.Series["Aylar"].Points.Clear();
                //1.Chart controle elektrik faturası son 4 ay çekme
                SqlCommand komut10 = new SqlCommand("Select top 4 AY,ELEKTRIK From TBL_GIDERLER order by ID Desc", bgl.baglanti());
                SqlDataReader dr10 = komut10.ExecuteReader();
                while (dr10.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr10[0], dr10[1]));
                }
                bgl.baglanti().Close();

            }
            //Su
            if (sayac > 5 && sayac <= 10)
            {
                groupControl11.Text = "SU";
                chartControl1.Series["Aylar"].Points.Clear(); //önce cartcontrol1 i temizle sonra bunu yap.
                //2.Chart controle su faturası son 4 ay çekme
                SqlCommand komut11 = new SqlCommand("Select top 4 AY,SU From TBL_GIDERLER order by ID Desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close();
            }

            //Doğalgaz
            if (sayac > 11 && sayac <= 15)
            {
                groupControl11.Text = "DOĞALGAZ";
                chartControl1.Series["Aylar"].Points.Clear(); //önce cartcontrol1 i temizle sonra bunu yap.
                //2.Chart controle su faturası son 4 ay çekme
                SqlCommand komut11 = new SqlCommand("Select top 4 AY,DOGALGAZ From TBL_GIDERLER order by ID Desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close();
            }


            //İnternet
            if (sayac > 16 && sayac <= 20)
            {
                groupControl11.Text = "INTERNET";
                chartControl1.Series["Aylar"].Points.Clear(); //önce cartcontrol1 i temizle sonra bunu yap.
                //2.Chart controle su faturası son 4 ay çekme
                SqlCommand komut11 = new SqlCommand("Select top 4 AY,INTERNET From TBL_GIDERLER order by ID Desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close();
            }


            //Ekstra
            if (sayac > 21 && sayac <= 25)
            {
                groupControl11.Text = "EKSTRA";
                chartControl1.Series["Aylar"].Points.Clear(); //önce cartcontrol1 i temizle sonra bunu yap.
                //2.Chart controle su faturası son 4 ay çekme
                SqlCommand komut11 = new SqlCommand("Select top 4 AY,EKSTRA From TBL_GIDERLER order by ID Desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close();
            }
            if(sayac == 26)
            {
                sayac = 0;
            }
        }














       



        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void xtraTabPage1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupControl6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }

        private void gridControl2_Click(object sender, EventArgs e)
        {

        }

        private void groupControl12_Paint(object sender, PaintEventArgs e)
        {

        }


        int sayac2 = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            sayac2++;

            //Elektirik
            if (sayac2 > 0 && sayac2 <= 5)
            {
                groupControl12.Text = "ELEKTRİK";
                chartControl2.Series["Aylar"].Points.Clear();
                //1.Chart controle elektrik faturası son 4 ay çekme
                SqlCommand komut10 = new SqlCommand("Select top 4 AY,ELEKTRIK From TBL_GIDERLER order by ID Desc", bgl.baglanti());
                SqlDataReader dr10 = komut10.ExecuteReader();
                while (dr10.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr10[0], dr10[1]));
                }
                bgl.baglanti().Close();

            }
            //Su
            if (sayac2 > 5 && sayac2 <= 10)
            {
                groupControl12.Text = "SU";
                chartControl2.Series["Aylar"].Points.Clear(); //önce cartcontrol1 i temizle sonra bunu yap.
                //2.Chart controle su faturası son 4 ay çekme
                SqlCommand komut11 = new SqlCommand("Select top 4 AY,SU From TBL_GIDERLER order by ID Desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close();
            }

            //Doğalgaz
            if (sayac2 > 11 && sayac2 <= 15)
            {
                groupControl12.Text = "DOĞALGAZ";
                chartControl2.Series["Aylar"].Points.Clear(); //önce cartcontrol1 i temizle sonra bunu yap.
                //2.Chart controle su faturası son 4 ay çekme
                SqlCommand komut11 = new SqlCommand("Select top 4 AY,DOGALGAZ From TBL_GIDERLER order by ID Desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close();
            }


            //İnternet
            if (sayac2 > 16 && sayac2 <= 20)
            {
                groupControl12.Text = "INTERNET";
                chartControl2.Series["Aylar"].Points.Clear(); //önce cartcontrol1 i temizle sonra bunu yap.
                //2.Chart controle su faturası son 4 ay çekme
                SqlCommand komut11 = new SqlCommand("Select top 4 AY,INTERNET From TBL_GIDERLER order by ID Desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close();
            }


            //Ekstra
            if (sayac2 > 21 && sayac2 <= 25)
            {
                groupControl12.Text = "EKSTRA";
                chartControl2.Series["Aylar"].Points.Clear(); //önce cartcontrol1 i temizle sonra bunu yap.
                //2.Chart controle su faturası son 4 ay çekme
                SqlCommand komut11 = new SqlCommand("Select top 4 AY,EKSTRA From TBL_GIDERLER order by ID Desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close();
            }
            if (sayac2 == 26)
            {
                sayac2 = 0;
            }
        }
    }
}
