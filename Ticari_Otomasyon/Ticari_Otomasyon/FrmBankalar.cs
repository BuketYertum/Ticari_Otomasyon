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
    public partial class FrmBankalar : Form
    {
        public FrmBankalar()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        void Listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Execute BankaBilgileri", bgl.baglanti()); //SQLSERVERDA YAZDIĞIMIZ İNNER JOİN BURAYA YAZILABİLİR EK SECENEEKOLARAK.
            da.Fill(dt);
            gridControl1.DataSource = dt;

        }
       

        void SehirListesi()
        {
            SqlCommand komut = new SqlCommand("Select *From TBL_ILLER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbil.Properties.Items.Add(dr[1]);
            }
            bgl.baglanti().Close();
        }

        //Look Up Edit ile veri çektim.
        //BAnka sekmesinde firma id ve adı cekmek ve kaydetmek için lazım.
        void FirmaListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select ID,AD From TBL_FIRMALAR", bgl.baglanti());
            da.Fill(dt);
            lueFirmalar.Properties.ValueMember = "ID";
            lueFirmalar.Properties.DisplayMember = "AD"; //bize gözüken yer.
            lueFirmalar.Properties.DataSource = dt;
        }

        private void FrmBankalar_Load(object sender, EventArgs e)
        {
         
            Listele();
            temizle();
            SehirListesi();
            FirmaListesi();
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



        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtID.Text = dr["ID"].ToString();
            txtBankaAdı.Text = dr["BANKAADI"].ToString();
            cmbil.Text = dr["IL"].ToString();
            cmbilce.Text = dr["ILCE"].ToString();
            txtSube.Text = dr["SUBE"].ToString();
            mskIban.Text = dr["IBAN"].ToString();
            mskHesapno.Text = dr["HESAPNO"].ToString();
            txtYetkili.Text = dr["YETKILI"].ToString();
            mskTelefon.Text = dr["TELEFON"].ToString();
            mskTarih.Text = dr["TARIH"].ToString();
            txtHesapTürü.Text = dr["HESAPTURU"].ToString();
           // txtFirmaID.Text = dr["FIRMAID"].ToString();  //SERVERDAN ÇEKİYORUZ GEREK KALMADI.firmaidsi çekiyoruz.


        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Insert into TBL_BANKALAR  (BANKAADI,IL,ILCE,SUBE,IBAN,HESAPNO,YETKILI," +
                "TELEFON,TARIH,HESAPTURU,FIRMAID) values (@p1, @p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtBankaAdı.Text);
            komut.Parameters.AddWithValue("@p2", cmbil.Text);
            komut.Parameters.AddWithValue("@p3", cmbilce.Text);
            komut.Parameters.AddWithValue("@p4", txtSube.Text);
            komut.Parameters.AddWithValue("@p5", mskIban.Text);
            komut.Parameters.AddWithValue("@p6", mskHesapno.Text);
            komut.Parameters.AddWithValue("@p7", txtYetkili.Text);
            komut.Parameters.AddWithValue("@p8", mskTelefon.Text);
            komut.Parameters.AddWithValue("@p9", mskTarih.Text);
            komut.Parameters.AddWithValue("@p10", txtHesapTürü.Text);
            komut.Parameters.AddWithValue("@p11", lueFirmalar.EditValue); //ValueMemberdaki ID bu.
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Banka Bilgisi Eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            temizle();
            
        }

        void temizle()
        {
            txtID.Text = "";
            txtBankaAdı.Text = "";
            cmbil.Text = "";
            cmbilce.Text = "";
            txtSube.Text = "";
            mskIban.Text = "";
            mskHesapno.Text = "";
            txtYetkili.Text = "";
            mskTelefon.Text = "";
            mskTarih.Text = "";
            txtHesapTürü.Text = "";
            lueFirmalar.Text = "";
            txtBankaAdı.Focus();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("Delete from TBL_BANKALAR where ID=@P1", bgl.baglanti());
            komutsil.Parameters.AddWithValue("@p1", txtID.Text);
            komutsil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Banka bilgileri silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Listele();
            temizle();

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komutguncelle = new SqlCommand("update TBL_BANKALAR set BANKAADI=@P1, IL=@P2, ILCE=@P3, SUBE=@P4," +
                "IBAN=@P5 , HESAPNO=@P6, YETKILI=@P7, TELEFON=@P8, TARIH=@P9, HESAPTURU=@P10, FIRMAID=@P11 where ID=@P12", bgl.baglanti());
            komutguncelle.Parameters.AddWithValue("@p1", txtBankaAdı.Text);
            komutguncelle.Parameters.AddWithValue("@p2", cmbil.Text);
            komutguncelle.Parameters.AddWithValue("@p3", cmbilce.Text);
            komutguncelle.Parameters.AddWithValue("@p4", txtSube.Text);
            komutguncelle.Parameters.AddWithValue("@p5", mskIban.Text);
            komutguncelle.Parameters.AddWithValue("@p6", mskHesapno.Text);
            komutguncelle.Parameters.AddWithValue("@p7", txtYetkili.Text);
            komutguncelle.Parameters.AddWithValue("@p8", mskTelefon.Text);
            komutguncelle.Parameters.AddWithValue("@p9", mskTarih.Text);
            komutguncelle.Parameters.AddWithValue("@p10", txtHesapTürü.Text);
            komutguncelle.Parameters.AddWithValue("@p11", lueFirmalar.EditValue);
            komutguncelle.Parameters.AddWithValue("@p12", txtID.Text);
            komutguncelle.ExecuteNonQuery();
            Listele();
            bgl.baglanti().Close();
            MessageBox.Show("Banka Bilgisi Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            temizle();
        }


















        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
