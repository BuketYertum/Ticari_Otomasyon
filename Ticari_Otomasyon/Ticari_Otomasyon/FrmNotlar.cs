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
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();


        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select *From TBL_NOTLAR", bgl.baglanti()); //SqlDataAdapter verileri almak vekaydetmek için veSQL Server arasında bir DataSet köprü görevi görür.
            da.Fill(dt);
            gridControl1.DataSource = dt;

        }

        void temizle()
        {
            txtID.Text = "";
            txtBaslik.Text = "";
            txtHitap.Text = "";
            txtOlusturan.Text = "";
            mskTarih.Text = "";
            mskSaat.Text = "";
            RchDetay.Text = "";
            mskTarih.Focus();
        }


        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

       

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtID.Text = dr["NOTID"].ToString();
                mskTarih.Text = dr["NOTTARIH"].ToString();
                mskSaat.Text = dr["NOTSAAT"].ToString();
                txtBaslik.Text = dr["NOTBASLIK"].ToString(); 
                txtOlusturan.Text = dr["NOTOLUSTURAN"].ToString();
                txtHitap.Text = dr["NOTHITAP"].ToString();
                RchDetay.Text = dr["NOTDETAY"].ToString();
                
            }
            
        }

        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            listele();
            temizle();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Insert into TBL_NOTLAR (NOTTARIH,NOTSAAT,NOTBASLIK,NOTDETAY,NOTOLUSTURAN,NOTHITAP) values" +
                "(@p1,@p2,@p3,@p4,@p5,@p6)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mskTarih.Text);
            komut.Parameters.AddWithValue("@p2", mskSaat.Text);
            komut.Parameters.AddWithValue("@p3", txtBaslik.Text);
            komut.Parameters.AddWithValue("@p4", RchDetay.Text);
            komut.Parameters.AddWithValue("@p5", txtOlusturan.Text);
            komut.Parameters.AddWithValue("@p6", txtHitap.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Not Eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("Delete from TBL_NOTLAR where NOTID=@P1", bgl.baglanti());
            komutsil.Parameters.AddWithValue("@p1", txtID.Text);
            komutsil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Not Silindi !.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            listele();
            temizle();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komutguncelle=new SqlCommand("Update TBL_NOTLAR set NOTTARIH=@P1,NOTSAAT=@P2,NOTBASLIK=@P3,NOTDETAY=@P4," +
                "NOTOLUSTURAN=@P5,NOTHITAP=@P6 where NOTID=@P7", bgl.baglanti());
            komutguncelle.Parameters.AddWithValue("@p1", mskTarih.Text);
            komutguncelle.Parameters.AddWithValue("@p2", mskSaat.Text);
            komutguncelle.Parameters.AddWithValue("@p3", txtBaslik.Text);
            komutguncelle.Parameters.AddWithValue("@p4", RchDetay.Text);
            komutguncelle.Parameters.AddWithValue("@p5", txtOlusturan.Text);
            komutguncelle.Parameters.AddWithValue("@p6", txtHitap.Text);
            komutguncelle.Parameters.AddWithValue("@p7", txtID.Text);
            komutguncelle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Not Bilgisi Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
            temizle();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)//not ustune cift tıklayınca detay sayfası geliyor.
        {
            FrmNotDetay fr = new FrmNotDetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                fr.metin = dr["NOTDETAY"].ToString();
            }
            fr.Show();
        }
    }
}
