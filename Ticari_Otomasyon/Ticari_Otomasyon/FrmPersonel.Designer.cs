
namespace Ticari_Otomasyon
{
    partial class FrmPersonel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPersonel));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cardView1 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutView1 = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            this.cmbilce = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbil = new DevExpress.XtraEditors.ComboBoxEdit();
            this.mskTC = new System.Windows.Forms.MaskedTextBox();
            this.mskTelefon1 = new System.Windows.Forms.MaskedTextBox();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.txtGorev = new DevExpress.XtraEditors.TextEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.BtnGuncelle = new DevExpress.XtraEditors.SimpleButton();
            this.BtnSil = new DevExpress.XtraEditors.SimpleButton();
            this.BtnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.RchAdres = new System.Windows.Forms.RichTextBox();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtMail = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtAd = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtID = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtSoyad = new DevExpress.XtraEditors.TextEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.ımageSlider1 = new DevExpress.XtraEditors.Controls.ImageSlider();
            this.ımageSlider2 = new DevExpress.XtraEditors.Controls.ImageSlider();
            this.ımageSlider3 = new DevExpress.XtraEditors.Controls.ImageSlider();
            this.ımageSlider4 = new DevExpress.XtraEditors.Controls.ImageSlider();
            this.ımageSlider5 = new DevExpress.XtraEditors.Controls.ImageSlider();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbilce.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbil.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGorev.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoyad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ımageSlider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ımageSlider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ımageSlider3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ımageSlider4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ımageSlider5)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(800, 371);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView3,
            this.cardView1,
            this.gridView2,
            this.layoutView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gridView1.Appearance.Row.BackColor2 = System.Drawing.Color.Teal;
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // gridView3
            // 
            this.gridView3.GridControl = this.gridControl1;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // cardView1
            // 
            this.cardView1.GridControl = this.gridControl1;
            this.cardView1.Name = "cardView1";
            this.cardView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridControl1;
            this.gridView2.Name = "gridView2";
            // 
            // layoutView1
            // 
            this.layoutView1.GridControl = this.gridControl1;
            this.layoutView1.Name = "layoutView1";
            this.layoutView1.TemplateCard = this.layoutViewCard1;
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.Name = "layoutViewTemplateCard";
            // 
            // cmbilce
            // 
            this.cmbilce.Location = new System.Drawing.Point(109, 262);
            this.cmbilce.Name = "cmbilce";
            this.cmbilce.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.cmbilce.Properties.Appearance.Options.UseFont = true;
            this.cmbilce.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbilce.Size = new System.Drawing.Size(180, 24);
            this.cmbilce.TabIndex = 7;
            // 
            // cmbil
            // 
            this.cmbil.Location = new System.Drawing.Point(109, 232);
            this.cmbil.Name = "cmbil";
            this.cmbil.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.cmbil.Properties.Appearance.Options.UseFont = true;
            this.cmbil.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbil.Size = new System.Drawing.Size(180, 24);
            this.cmbil.TabIndex = 6;
            this.cmbil.SelectedIndexChanged += new System.EventHandler(this.cmbil_SelectedIndexChanged);
            // 
            // mskTC
            // 
            this.mskTC.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.mskTC.Location = new System.Drawing.Point(109, 171);
            this.mskTC.Mask = "00000000000";
            this.mskTC.Name = "mskTC";
            this.mskTC.Size = new System.Drawing.Size(180, 26);
            this.mskTC.TabIndex = 4;
            this.mskTC.ValidatingType = typeof(int);
            // 
            // mskTelefon1
            // 
            this.mskTelefon1.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.mskTelefon1.Location = new System.Drawing.Point(109, 139);
            this.mskTelefon1.Mask = "(999) 000-0000";
            this.mskTelefon1.Name = "mskTelefon1";
            this.mskTelefon1.Size = new System.Drawing.Size(180, 26);
            this.mskTelefon1.TabIndex = 3;
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl11.Appearance.Options.UseFont = true;
            this.labelControl11.Location = new System.Drawing.Point(35, 383);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(57, 18);
            this.labelControl11.TabIndex = 27;
            this.labelControl11.Text = "GÖREV :";
            // 
            // txtGorev
            // 
            this.txtGorev.Location = new System.Drawing.Point(109, 377);
            this.txtGorev.Name = "txtGorev";
            this.txtGorev.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtGorev.Properties.Appearance.Options.UseFont = true;
            this.txtGorev.Size = new System.Drawing.Size(180, 24);
            this.txtGorev.TabIndex = 9;
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl10.Appearance.Options.UseFont = true;
            this.labelControl10.Location = new System.Drawing.Point(52, 268);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(40, 18);
            this.labelControl10.TabIndex = 25;
            this.labelControl10.Text = "İLÇE :";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(8, 30);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(44, 41);
            this.simpleButton1.TabIndex = 101;
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // BtnGuncelle
            // 
            this.BtnGuncelle.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnGuncelle.Appearance.Options.UseFont = true;
            this.BtnGuncelle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnGuncelle.ImageOptions.Image")));
            this.BtnGuncelle.Location = new System.Drawing.Point(228, 433);
            this.BtnGuncelle.Name = "BtnGuncelle";
            this.BtnGuncelle.Size = new System.Drawing.Size(40, 41);
            this.BtnGuncelle.TabIndex = 22;
            this.BtnGuncelle.Click += new System.EventHandler(this.BtnGuncelle_Click);
            // 
            // BtnSil
            // 
            this.BtnSil.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnSil.Appearance.Options.UseFont = true;
            this.BtnSil.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnSil.ImageOptions.Image")));
            this.BtnSil.Location = new System.Drawing.Point(184, 433);
            this.BtnSil.Name = "BtnSil";
            this.BtnSil.Size = new System.Drawing.Size(38, 40);
            this.BtnSil.TabIndex = 21;
            this.BtnSil.Click += new System.EventHandler(this.BtnSil_Click);
            // 
            // BtnKaydet
            // 
            this.BtnKaydet.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnKaydet.Appearance.Options.UseFont = true;
            this.BtnKaydet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnKaydet.ImageOptions.Image")));
            this.BtnKaydet.Location = new System.Drawing.Point(133, 433);
            this.BtnKaydet.Name = "BtnKaydet";
            this.BtnKaydet.Size = new System.Drawing.Size(45, 41);
            this.BtnKaydet.TabIndex = 20;
            this.BtnKaydet.Click += new System.EventHandler(this.BtnKaydet_Click);
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Location = new System.Drawing.Point(33, 292);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(59, 18);
            this.labelControl9.TabIndex = 18;
            this.labelControl9.Text = " ADRES :";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(69, 238);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(23, 18);
            this.labelControl8.TabIndex = 15;
            this.labelControl8.Text = "İL :";
            // 
            // RchAdres
            // 
            this.RchAdres.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.RchAdres.Location = new System.Drawing.Point(109, 292);
            this.RchAdres.Name = "RchAdres";
            this.RchAdres.Size = new System.Drawing.Size(180, 79);
            this.RchAdres.TabIndex = 8;
            this.RchAdres.Text = "";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(48, 209);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(44, 18);
            this.labelControl7.TabIndex = 13;
            this.labelControl7.Text = "MAIL :";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(53, 174);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(39, 18);
            this.labelControl6.TabIndex = 11;
            this.labelControl6.Text = "T.C. :";
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(109, 203);
            this.txtMail.Name = "txtMail";
            this.txtMail.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtMail.Properties.Appearance.Options.UseFont = true;
            this.txtMail.Size = new System.Drawing.Size(180, 24);
            this.txtMail.TabIndex = 5;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(20, 142);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(72, 18);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "TELEFON :";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(34, 112);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(58, 18);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "SOYAD :";
            // 
            // txtAd
            // 
            this.txtAd.Location = new System.Drawing.Point(109, 76);
            this.txtAd.Name = "txtAd";
            this.txtAd.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAd.Properties.Appearance.Options.UseFont = true;
            this.txtAd.Size = new System.Drawing.Size(180, 24);
            this.txtAd.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(63, 82);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(29, 18);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "AD :";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(109, 46);
            this.txtID.Name = "txtID";
            this.txtID.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtID.Properties.Appearance.Options.UseFont = true;
            this.txtID.Size = new System.Drawing.Size(180, 24);
            this.txtID.TabIndex = 100;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(66, 52);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(26, 18);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "ID :";
            // 
            // txtSoyad
            // 
            this.txtSoyad.Location = new System.Drawing.Point(109, 106);
            this.txtSoyad.Name = "txtSoyad";
            this.txtSoyad.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSoyad.Properties.Appearance.Options.UseFont = true;
            this.txtSoyad.Size = new System.Drawing.Size(180, 24);
            this.txtSoyad.TabIndex = 2;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.cmbilce);
            this.groupControl1.Controls.Add(this.cmbil);
            this.groupControl1.Controls.Add(this.mskTC);
            this.groupControl1.Controls.Add(this.mskTelefon1);
            this.groupControl1.Controls.Add(this.labelControl11);
            this.groupControl1.Controls.Add(this.txtGorev);
            this.groupControl1.Controls.Add(this.labelControl10);
            this.groupControl1.Controls.Add(this.simpleButton1);
            this.groupControl1.Controls.Add(this.BtnGuncelle);
            this.groupControl1.Controls.Add(this.BtnSil);
            this.groupControl1.Controls.Add(this.BtnKaydet);
            this.groupControl1.Controls.Add(this.RchAdres);
            this.groupControl1.Controls.Add(this.labelControl9);
            this.groupControl1.Controls.Add(this.labelControl8);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.txtMail);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.txtSoyad);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.txtAd);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.txtID);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(799, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(305, 516);
            this.groupControl1.TabIndex = 5;
            this.groupControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControl1_Paint);
            // 
            // ımageSlider1
            // 
            this.ımageSlider1.AnimationTime = 200;
            this.ımageSlider1.CurrentImageIndex = 0;
            this.ımageSlider1.Images.Add(((System.Drawing.Image)(resources.GetObject("ımageSlider1.Images"))));
            this.ımageSlider1.Images.Add(((System.Drawing.Image)(resources.GetObject("ımageSlider1.Images1"))));
            this.ımageSlider1.Images.Add(((System.Drawing.Image)(resources.GetObject("ımageSlider1.Images2"))));
            this.ımageSlider1.Images.Add(((System.Drawing.Image)(resources.GetObject("ımageSlider1.Images3"))));
            this.ımageSlider1.Images.Add(((System.Drawing.Image)(resources.GetObject("ımageSlider1.Images4"))));
            this.ımageSlider1.Images.Add(((System.Drawing.Image)(resources.GetObject("ımageSlider1.Images5"))));
            this.ımageSlider1.Location = new System.Drawing.Point(324, 377);
            this.ımageSlider1.Name = "ımageSlider1";
            this.ımageSlider1.Size = new System.Drawing.Size(160, 119);
            this.ımageSlider1.TabIndex = 8;
            this.ımageSlider1.Text = "ımageSlider1";
            // 
            // ımageSlider2
            // 
            this.ımageSlider2.AnimationTime = 400;
            this.ımageSlider2.CurrentImageIndex = 0;
            this.ımageSlider2.Images.Add(((System.Drawing.Image)(resources.GetObject("ımageSlider2.Images"))));
            this.ımageSlider2.Images.Add(((System.Drawing.Image)(resources.GetObject("ımageSlider2.Images1"))));
            this.ımageSlider2.Images.Add(((System.Drawing.Image)(resources.GetObject("ımageSlider2.Images2"))));
            this.ımageSlider2.Images.Add(((System.Drawing.Image)(resources.GetObject("ımageSlider2.Images3"))));
            this.ımageSlider2.Images.Add(((System.Drawing.Image)(resources.GetObject("ımageSlider2.Images4"))));
            this.ımageSlider2.Location = new System.Drawing.Point(12, 380);
            this.ımageSlider2.Name = "ımageSlider2";
            this.ımageSlider2.Size = new System.Drawing.Size(148, 119);
            this.ımageSlider2.TabIndex = 9;
            this.ımageSlider2.Text = "ımageSlider2";
            // 
            // ımageSlider3
            // 
            this.ımageSlider3.AnimationTime = 100;
            this.ımageSlider3.CurrentImageIndex = 0;
            this.ımageSlider3.Images.Add(((System.Drawing.Image)(resources.GetObject("ımageSlider3.Images"))));
            this.ımageSlider3.Images.Add(((System.Drawing.Image)(resources.GetObject("ımageSlider3.Images1"))));
            this.ımageSlider3.Images.Add(((System.Drawing.Image)(resources.GetObject("ımageSlider3.Images2"))));
            this.ımageSlider3.Images.Add(((System.Drawing.Image)(resources.GetObject("ımageSlider3.Images3"))));
            this.ımageSlider3.Location = new System.Drawing.Point(166, 377);
            this.ımageSlider3.Name = "ımageSlider3";
            this.ımageSlider3.Size = new System.Drawing.Size(152, 119);
            this.ımageSlider3.TabIndex = 10;
            this.ımageSlider3.Text = "ımageSlider3";
            this.ımageSlider3.Click += new System.EventHandler(this.ımageSlider3_Click);
            // 
            // ımageSlider4
            // 
            this.ımageSlider4.AnimationTime = 500;
            this.ımageSlider4.CurrentImageIndex = 0;
            this.ımageSlider4.Images.Add(((System.Drawing.Image)(resources.GetObject("ımageSlider4.Images"))));
            this.ımageSlider4.Images.Add(((System.Drawing.Image)(resources.GetObject("ımageSlider4.Images1"))));
            this.ımageSlider4.Images.Add(((System.Drawing.Image)(resources.GetObject("ımageSlider4.Images2"))));
            this.ımageSlider4.Location = new System.Drawing.Point(490, 377);
            this.ımageSlider4.Name = "ımageSlider4";
            this.ımageSlider4.Size = new System.Drawing.Size(148, 119);
            this.ımageSlider4.TabIndex = 11;
            this.ımageSlider4.Text = "ımageSlider4";
            // 
            // ımageSlider5
            // 
            this.ımageSlider5.AnimationTime = 250;
            this.ımageSlider5.CurrentImageIndex = 0;
            this.ımageSlider5.Images.Add(((System.Drawing.Image)(resources.GetObject("ımageSlider5.Images"))));
            this.ımageSlider5.Images.Add(((System.Drawing.Image)(resources.GetObject("ımageSlider5.Images1"))));
            this.ımageSlider5.Location = new System.Drawing.Point(644, 377);
            this.ımageSlider5.Name = "ımageSlider5";
            this.ımageSlider5.ScrollButtonVisibility = DevExpress.Utils.DefaultBoolean.False;
            this.ımageSlider5.Size = new System.Drawing.Size(149, 119);
            this.ımageSlider5.TabIndex = 12;
            this.ımageSlider5.Text = "ımageSlider5";
            // 
            // FrmPersonel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 511);
            this.Controls.Add(this.ımageSlider5);
            this.Controls.Add(this.ımageSlider4);
            this.Controls.Add(this.ımageSlider3);
            this.Controls.Add(this.ımageSlider2);
            this.Controls.Add(this.ımageSlider1);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.groupControl1);
            this.Name = "FrmPersonel";
            this.Text = "PERSONEL";
            this.Load += new System.EventHandler(this.FrmPersonel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbilce.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbil.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGorev.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoyad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ımageSlider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ımageSlider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ımageSlider3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ımageSlider4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ımageSlider5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Views.Card.CardView cardView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
        private DevExpress.XtraEditors.ComboBoxEdit cmbilce;
        private DevExpress.XtraEditors.ComboBoxEdit cmbil;
        private System.Windows.Forms.MaskedTextBox mskTC;
        private System.Windows.Forms.MaskedTextBox mskTelefon1;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.TextEdit txtGorev;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton BtnGuncelle;
        private DevExpress.XtraEditors.SimpleButton BtnSil;
        private DevExpress.XtraEditors.SimpleButton BtnKaydet;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private System.Windows.Forms.RichTextBox RchAdres;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtMail;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtAd;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtID;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtSoyad;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.Controls.ImageSlider ımageSlider1;
        private DevExpress.XtraEditors.Controls.ImageSlider ımageSlider2;
        private DevExpress.XtraEditors.Controls.ImageSlider ımageSlider3;
        private DevExpress.XtraEditors.Controls.ImageSlider ımageSlider4;
        private DevExpress.XtraEditors.Controls.ImageSlider ımageSlider5;
    }
}