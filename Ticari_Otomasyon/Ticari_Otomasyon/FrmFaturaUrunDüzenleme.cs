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
    public partial class FrmFaturaUrunDüzenleme : Form
    {
        public FrmFaturaUrunDüzenleme()
        {
            InitializeComponent();
        }


        sqlbaglantisi bgl = new sqlbaglantisi();

        private void BtnGuncelle_Click_1(object sender, EventArgs e)
        {

        }

        private void BtnSil_Click_1(object sender, EventArgs e)
        {

        }

        private void BtnKaydet_Click_1(object sender, EventArgs e)
        {

        }


        //verileri araclara yazdırdık.
        public string urunid;
        private void FrmFaturaUrunDüzenleme_Load(object sender, EventArgs e)
        {
            txtFaturaDetayID.Text = urunid;

            SqlCommand komut = new SqlCommand("Select *From TBL_FATURADETAY where FATURAURUNID=@P1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", urunid);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtUrunAD.Text = dr[1].ToString();
                txtMiktar.Text = dr[2].ToString();
                txtFİyat.Text = dr[3].ToString();             
                txtTutar.Text = dr[4].ToString();


                bgl.baglanti().Close();
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komutguncelle = new SqlCommand("update TBL_FATURADETAY set URUNAD=@P1,MIKTAR=@P2,FIYAT=@P3,TUTAR=@P4 where FATURAURUNID=@P5", bgl.baglanti());
            komutguncelle.Parameters.AddWithValue("@p1", txtUrunAD.Text);
            komutguncelle.Parameters.AddWithValue("@p2", txtMiktar.Text);
            komutguncelle.Parameters.AddWithValue("@p3", decimal.Parse(txtFİyat.Text));
            komutguncelle.Parameters.AddWithValue("@p4", decimal.Parse(txtTutar.Text));
            komutguncelle.Parameters.AddWithValue("@p5", txtFaturaDetayID.Text);
            komutguncelle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Değişiklikler kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete TBL_FATURADETAY where FATURAURUNID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtFaturaDetayID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Silme işlemi gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
