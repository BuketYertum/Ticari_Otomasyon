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
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        void stoklar()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select urunad,sum(Adet) as 'Adet' From TBL_URUNLER group by URUNAD having sum(adet)<=20 order by sum(adet)", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }


        void ajanda()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select TOP 10 NOTTARIH,NOTSAAT,NOTBASLIK From TBL_NOTLAR ORDER BY NOTID DESC", bgl.baglanti());
            da2.Fill(dt2);
            gridControl2.DataSource = dt2;
        }


        void listeleFirmaHareket()
        {
            DataTable dt3 = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter("Exec FirmaHareketler2", bgl.baglanti()); //sqlseerverda oluşturdugumuz (new quary deki komutları bu şekilde cağırıyoruz.)
            da3.Fill(dt3);
            gridControl3.DataSource = dt3;
        }


        void fihrist()
        {
            DataTable dt4 = new DataTable();
            SqlDataAdapter da4 = new SqlDataAdapter("Select AD,TELEFON1 From TBL_FIRMALAR", bgl.baglanti()); //sqlseerverda oluşturdugumuz (new quary deki komutları bu şekilde cağırıyoruz.)
            da4.Fill(dt4);
            gridControl4.DataSource = dt4;

        }


        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {
            stoklar();
            ajanda();
            listeleFirmaHareket();
            fihrist();

            webBrowser2.Navigate("http://www.youtube.com/");
            webBrowser1.Navigate("http://www.tcmb.gov.tr/kurlar/kur2022_tr.html");
            //webBrowser2.Navigate("http://www.trthaber.com/");

        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }

        private void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
