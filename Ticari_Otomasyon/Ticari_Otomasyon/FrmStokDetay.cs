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
    public partial class FrmStokDetay : Form
    {
        public FrmStokDetay()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele() //Ürün adına göre detay sayfasına çekiyor. Aynı ürünleri
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select *From TBL_URUNLER where URUNAD='" + ad + "'", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }


        private void gridControl1_Click(object sender, EventArgs e)
        {

        }


        public string ad;
        private void FrmStokDetay_Load(object sender, EventArgs e)
        {
            listele();
        }
    }
}
