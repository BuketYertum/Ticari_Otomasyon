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
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select *From TBL_ADMIN where KULLANICIAD=@P1 and SIFRE=@P2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtKullaniciAdi.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Form1 fr = new Form1();
                fr.kullanici = txtKullaniciAdi.Text;//kullanıcıadı burada oluşturduk ve aldık kullanıcı içine.->from1 gittim.
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            bgl.baglanti().Close();
         }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.Yellow;

        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.MediumAquamarine;

        }
    }
}
