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
    public partial class FrmGiderler : Form
    {
        public FrmGiderler()
        {
            InitializeComponent();
        }



        sqlbaglantisi bgl = new sqlbaglantisi();



        void Listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select *From TBL_GIDERLER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;

        }



        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void FrmGiderler_Load(object sender, EventArgs e)
        {
            Listele();
            temizle();
        }


        void temizle()
        {
            txtID.Text = "";
            cmbAy.Text = "";
            cmbYıl.Text = "";
            txtElektrik.Text = "";
            txtSu.Text = "";
            txtDogalgaz.Text = "";
            txtInternet.Text = "";
            txtMaaslar.Text = "";
            txtEkstra.Text = "";
            txtNotlar.Text = "";
            cmbAy.Focus();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr =gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtID.Text = dr["ID"].ToString();
                cmbAy.Text = dr["AY"].ToString();
                cmbYıl.Text = dr["YIL"].ToString();
                txtElektrik.Text = dr["ELEKTRIK"].ToString();
                txtSu.Text = dr["SU"].ToString();
                txtDogalgaz.Text = dr["DOGALGAZ"].ToString();
                txtInternet.Text = dr["INTERNET"].ToString();
                txtMaaslar.Text = dr["MAASLAR"].ToString();
                txtEkstra.Text = dr["EKSTRA"].ToString();
                txtNotlar.Text= dr["NOTLAR"].ToString();
                
            }

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Insert into TBL_GIDERLER  (AY,YIL,ELEKTRIK,SU,DOGALGAZ,INTERNET,MAASLAR,EKSTRA,NOTLAR)" +
                "values (@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbAy.Text);
            komut.Parameters.AddWithValue("@p2", cmbYıl.Text);
            komut.Parameters.AddWithValue("@p3", decimal.Parse(txtElektrik.Text));
            komut.Parameters.AddWithValue("@p4", decimal.Parse(txtSu.Text));
            komut.Parameters.AddWithValue("@p5", decimal.Parse(txtDogalgaz.Text));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(txtInternet.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(txtMaaslar.Text));
            komut.Parameters.AddWithValue("@p8", decimal.Parse(txtEkstra.Text));
            komut.Parameters.AddWithValue("@p9", txtNotlar.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Giderler Eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            temizle();
            
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("Delete from TBL_GIDERLER where ID=@p1", bgl.baglanti());
            komutsil.Parameters.AddWithValue("@p1", txtID.Text);
            komutsil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Giderler Silindi. ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Listele();
            temizle();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komutguncelle = new SqlCommand("update TBL_GIDERLER set AY=@P1, YIL=@P2, ELEKTRIK=@P3, SU=@P4, DOGALGAZ=@P5, " +
                "INTERNET=@P6, MAASLAR=@P7, EKSTRA=@P8, NOTLAR=@P9 where ID=@p10", bgl.baglanti());
            komutguncelle.Parameters.AddWithValue("@p1", cmbAy.Text);
            komutguncelle.Parameters.AddWithValue("@p2", cmbYıl.Text);
            komutguncelle.Parameters.AddWithValue("@p3", decimal.Parse(txtElektrik.Text));
            komutguncelle.Parameters.AddWithValue("@p4", decimal.Parse(txtSu.Text));
            komutguncelle.Parameters.AddWithValue("@p5", decimal.Parse(txtDogalgaz.Text));
            komutguncelle.Parameters.AddWithValue("@p6", decimal.Parse(txtInternet.Text));
            komutguncelle.Parameters.AddWithValue("@p7", decimal.Parse(txtMaaslar.Text));
            komutguncelle.Parameters.AddWithValue("@p8", decimal.Parse(txtEkstra.Text));
            komutguncelle.Parameters.AddWithValue("@p9", txtNotlar.Text);
            komutguncelle.Parameters.AddWithValue("@p10", txtID.Text);
            komutguncelle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Giderler Güncellendi..", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Listele();
            temizle();
        }
    }
}
