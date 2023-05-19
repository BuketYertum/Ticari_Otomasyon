using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ticari_Otomasyon
{
    public partial class FrmRaporlar : Form
    {
        public FrmRaporlar()
        {
            InitializeComponent();
        }

        private void FrmRaporlar_Load(object sender, EventArgs e)
        {

            
        }

        private void FrmRaporlar_Load_1(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'DboTicariOtomasyonDataSet.TBL_BANKALAR' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tBL_BANKALARTableAdapter.Fill(this.DboTicariOtomasyonDataSet.TBL_BANKALAR);
            // TODO: Bu kod satırı 'DboTicariOtomasyonDataSet.TBL_FIRMALAR' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.TBL_FIRMALARTableAdapter.Fill(this.DboTicariOtomasyonDataSet.TBL_FIRMALAR);


           
        }

        private void xtraTabPage1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
