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
    public partial class FrmUrunler : Form
    {
        public FrmUrunler()
        {
            InitializeComponent();
        }


        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()//urunlere tıklayınca urunlerin menu kısmını getiriyor sırasıyla.
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select  *From TBL_URUNLER", bgl.baglanti());
            da.Fill(dt);  //dt nin içini da ile doldur demek.
            gridControl1.DataSource = dt;//dt yi gridcontrolde yazdır.
        }

        private void FrmUrunler_Load(object sender, EventArgs e)
        {
            listele();
            temizle();
        }
   


        private void BtnKaydet_Click(object sender, EventArgs e) //Ürün ekleme işlemi.
        {
            SqlCommand komut = new SqlCommand("insert into TBL_URUNLER (URUNAD,MARKA,MODEL,YIL,ADET,ALISFIYAT,SATISFIYAT,DETAY) values " +
                "(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@P2", txtmarka.Text);
            komut.Parameters.AddWithValue("@p3", txtmodel.Text);
            komut.Parameters.AddWithValue("@p4", MskYil.Text);
            komut.Parameters.AddWithValue("@p5", int.Parse((NudAdet.Value).ToString()));
            komut.Parameters.AddWithValue("@p6", decimal.Parse((txtAlisFiyat.Text).ToString()));
            komut.Parameters.AddWithValue("@p7", decimal.Parse((txtSatisFiyat.Text).ToString()));
            komut.Parameters.AddWithValue("@p8", RchDetay.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün sisteme eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //ekledikten sonrada listeleme ile liste halinde yazdır.
            listele();
            temizle();
        }


        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("Delete from TBL_URUNLER where ID=@p1", bgl.baglanti());
            komutsil.Parameters.AddWithValue("@p1", txtid.Text); //TXTİD YE göre o ürünü bulup silecek.
            komutsil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün silindi !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            listele(); //son halini listelemesi için.
            temizle();
        }


        //GÜNCELLEME ÖNCESİ BUNU YAPMAM LAZIM.TXT LERE BİLGİLERE DÜŞMESİ İÇİN !
        //ÜRÜNLERİ GRİDDEN ALIP ARAÇLARA YANİ TXTLERE TAŞINMA İŞLEMİ
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //datarow bizim veri satırımız.
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);    //FARE İLE ÜZERİNE TIKLADIGIM YERİ AL DR YE AT
            if (dr != null)
            {
                txtid.Text = dr["ID"].ToString();                                //dr YE ALDIĞIM DEGERLERİ TEXTLERE YAZDIRMA İŞLEMİ.
                txtad.Text = dr["URUNAD"].ToString();
                txtmarka.Text = dr["MARKA"].ToString();
                txtmodel.Text = dr["MODEL"].ToString();
                MskYil.Text = dr["YIL"].ToString();
                NudAdet.Value = decimal.Parse(dr["ADET"].ToString());
                txtAlisFiyat.Text = dr["ALISFIYAT"].ToString();
                txtSatisFiyat.Text = dr["SATISFIYAT"].ToString();
                RchDetay.Text = dr["DETAY"].ToString();
            }
        }

        //verileri güncelleme 
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {

            SqlCommand komutguncelle = new SqlCommand("update TBL_URUNLER set URUNAD=@P1, MARKA=@P2," +  //id ye göre güncelleme yapıcam.
                "MODEL=@P3, YIL=@P4, ADET=@P5, ALISFIYAT=@P6, SATISFIYAT=@P7, DETAY=@P8 where ID=@P9", bgl.baglanti());
            komutguncelle.Parameters.AddWithValue("@p1", txtad.Text);
            komutguncelle.Parameters.AddWithValue("@P2", txtmarka.Text);
            komutguncelle.Parameters.AddWithValue("@p3", txtmodel.Text);
            komutguncelle.Parameters.AddWithValue("@p4", MskYil.Text);
            komutguncelle.Parameters.AddWithValue("@p5", int.Parse((NudAdet.Value).ToString()));
            komutguncelle.Parameters.AddWithValue("@p6", decimal.Parse((txtAlisFiyat.Text).ToString()));
            komutguncelle.Parameters.AddWithValue("@p7", decimal.Parse((txtSatisFiyat.Text).ToString()));
            komutguncelle.Parameters.AddWithValue("@p8", RchDetay.Text);
            komutguncelle.Parameters.AddWithValue("@p9", txtid.Text);
            komutguncelle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Bilgisi Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
            temizle();
        }

        void temizle()
        {
            txtid.Text = "";
            txtad.Text = "";
            txtmarka.Text = "";
            txtmodel.Text = "";
            MskYil.Text = "";
            NudAdet.Value = 0;
            txtAlisFiyat.Text = "";
            txtSatisFiyat.Text = "";
            RchDetay.Text = "";
            txtad.Focus();
        }


        //araçların içini temizleme komutu.
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            temizle();
        }






        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
        private void gridView3_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) { }
    }
}
