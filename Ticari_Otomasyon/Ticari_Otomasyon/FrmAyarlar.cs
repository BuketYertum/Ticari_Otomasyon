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
    public partial class FrmAyarlar : Form
    {
        public FrmAyarlar()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();


        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select *From TBL_ADMIN", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }


        private void FrmAyarlar_Load(object sender, EventArgs e)
        {
            listele();
            txtKullaniciAd.Text = "";
            txtSifre.Text = "";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            if (simpleButton1.Text == "KAYDET")
            {
                SqlCommand komut = new SqlCommand("insert into TBL_ADMIN values (@p1,@p2)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txtKullaniciAd.Text);
                komut.Parameters.AddWithValue("@p2", txtSifre.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Yeni Admin Sisteme Kaydedildi.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }

            if (simpleButton1.Text == "GÜNCELLE")
            {
                SqlCommand komutguncelle = new SqlCommand("update TBL_ADMIN set SIFRE=@P2 where KULLANICIAD=@P1", bgl.baglanti());
                komutguncelle.Parameters.AddWithValue("@P1", txtKullaniciAd.Text);
                komutguncelle.Parameters.AddWithValue("@P2", txtSifre.Text);
                komutguncelle.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Bilgiler güncellendi.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
                    
            }


          
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if(dr != null)
            {
                txtKullaniciAd.Text = dr["KULLANICIAD"].ToString();
                txtSifre.Text = dr["SIFRE"].ToString();
            }
        }

        private void txtKullaniciAd_TextChanged(object sender, EventArgs e)
        {
            if(txtKullaniciAd.Text != "")
            {
                simpleButton1.Text = "GÜNCELLE";
                simpleButton1.BackColor = Color.AliceBlue;
            }
            else
            {
                simpleButton1.Text = "KAYDET";
                simpleButton1.BackColor = Color.Aqua;
            }
        }
    }
}
