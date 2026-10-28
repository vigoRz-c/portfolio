namespace Fumoblilite.Interface.UserControls
{
    partial class UCConsultationHoraires
    {
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.GroupBox grpFiltres;
        private System.Windows.Forms.Label lblLigne;
        private System.Windows.Forms.ComboBox cboLigne;
        private System.Windows.Forms.Label lblArret;
        private System.Windows.Forms.ComboBox cboArret;
        private System.Windows.Forms.Label lblJour;
        private System.Windows.Forms.ComboBox cboJour;
        private System.Windows.Forms.Label lblHeureDebut;
        private System.Windows.Forms.DateTimePicker dtpHeureDebut;
        private System.Windows.Forms.Label lblHeureFin;
        private System.Windows.Forms.DateTimePicker dtpHeureFin;
        private System.Windows.Forms.Label lblRecherche;
        private System.Windows.Forms.TextBox txtRecherche;
        private System.Windows.Forms.CheckBox chkSeulementActifs;
        private System.Windows.Forms.CheckBox chkProchainsDeparts;
        private System.Windows.Forms.Button btnAfficher;
        private System.Windows.Forms.Button btnExporter;
        private System.Windows.Forms.FlowLayoutPanel flpHoraires;
        private System.Windows.Forms.Label lblStatistiques;
        private System.Windows.Forms.Label lblProchainsDeparts;

        private void InitializeComponent()
        {
            this.lblTitre = new System.Windows.Forms.Label();
            this.grpFiltres = new System.Windows.Forms.GroupBox();
            this.lblLigne = new System.Windows.Forms.Label();
            this.cboLigne = new System.Windows.Forms.ComboBox();
            this.lblArret = new System.Windows.Forms.Label();
            this.cboArret = new System.Windows.Forms.ComboBox();
            this.lblJour = new System.Windows.Forms.Label();
            this.cboJour = new System.Windows.Forms.ComboBox();
            this.lblHeureDebut = new System.Windows.Forms.Label();
            this.dtpHeureDebut = new System.Windows.Forms.DateTimePicker();
            this.lblHeureFin = new System.Windows.Forms.Label();
            this.dtpHeureFin = new System.Windows.Forms.DateTimePicker();
            this.lblRecherche = new System.Windows.Forms.Label();
            this.txtRecherche = new System.Windows.Forms.TextBox();
            this.chkSeulementActifs = new System.Windows.Forms.CheckBox();
            this.chkProchainsDeparts = new System.Windows.Forms.CheckBox();
            this.btnAfficher = new System.Windows.Forms.Button();
            this.btnExporter = new System.Windows.Forms.Button();
            this.flpHoraires = new System.Windows.Forms.FlowLayoutPanel();
            this.lblStatistiques = new System.Windows.Forms.Label();
            this.lblProchainsDeparts = new System.Windows.Forms.Label();
            this.grpFiltres.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitre
            // 
            this.lblTitre.AutoSize = true;
            this.lblTitre.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.lblTitre.Location = new System.Drawing.Point(20, 18);
            this.lblTitre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(342, 32);
            this.lblTitre.TabIndex = 0;
            this.lblTitre.Text = "Consultation des horaires";
            // 
            // grpFiltres
            // 
            this.grpFiltres.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFiltres.Controls.Add(this.lblLigne);
            this.grpFiltres.Controls.Add(this.cboLigne);
            this.grpFiltres.Controls.Add(this.lblArret);
            this.grpFiltres.Controls.Add(this.cboArret);
            this.grpFiltres.Controls.Add(this.lblJour);
            this.grpFiltres.Controls.Add(this.cboJour);
            this.grpFiltres.Controls.Add(this.lblHeureDebut);
            this.grpFiltres.Controls.Add(this.dtpHeureDebut);
            this.grpFiltres.Controls.Add(this.lblHeureFin);
            this.grpFiltres.Controls.Add(this.dtpHeureFin);
            this.grpFiltres.Controls.Add(this.lblRecherche);
            this.grpFiltres.Controls.Add(this.txtRecherche);
            this.grpFiltres.Controls.Add(this.chkSeulementActifs);
            this.grpFiltres.Controls.Add(this.chkProchainsDeparts);
            this.grpFiltres.Controls.Add(this.btnAfficher);
            this.grpFiltres.Controls.Add(this.btnExporter);
            this.grpFiltres.Location = new System.Drawing.Point(20, 62);
            this.grpFiltres.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpFiltres.Name = "grpFiltres";
            this.grpFiltres.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpFiltres.Size = new System.Drawing.Size(1293, 148);
            this.grpFiltres.TabIndex = 1;
            this.grpFiltres.TabStop = false;
            this.grpFiltres.Text = "Filtres de recherche";
            // 
            // lblLigne
            // 
            this.lblLigne.AutoSize = true;
            this.lblLigne.Location = new System.Drawing.Point(27, 37);
            this.lblLigne.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLigne.Name = "lblLigne";
            this.lblLigne.Size = new System.Drawing.Size(46, 16);
            this.lblLigne.TabIndex = 0;
            this.lblLigne.Text = "Ligne :";
            // 
            // cboLigne
            // 
            this.cboLigne.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLigne.FormattingEnabled = true;
            this.cboLigne.Location = new System.Drawing.Point(93, 33);
            this.cboLigne.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboLigne.Name = "cboLigne";
            this.cboLigne.Size = new System.Drawing.Size(199, 24);
            this.cboLigne.TabIndex = 1;
            // 
            // lblArret
            // 
            this.lblArret.AutoSize = true;
            this.lblArret.Location = new System.Drawing.Point(320, 37);
            this.lblArret.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblArret.Name = "lblArret";
            this.lblArret.Size = new System.Drawing.Size(41, 16);
            this.lblArret.TabIndex = 2;
            this.lblArret.Text = "Arrêt :";
            // 
            // cboArret
            // 
            this.cboArret.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboArret.FormattingEnabled = true;
            this.cboArret.Location = new System.Drawing.Point(387, 33);
            this.cboArret.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboArret.Name = "cboArret";
            this.cboArret.Size = new System.Drawing.Size(199, 24);
            this.cboArret.TabIndex = 3;
            // 
            // lblJour
            // 
            this.lblJour.AutoSize = true;
            this.lblJour.Location = new System.Drawing.Point(613, 37);
            this.lblJour.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblJour.Name = "lblJour";
            this.lblJour.Size = new System.Drawing.Size(39, 16);
            this.lblJour.TabIndex = 4;
            this.lblJour.Text = "Jour :";
            // 
            // cboJour
            // 
            this.cboJour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboJour.FormattingEnabled = true;
            this.cboJour.Location = new System.Drawing.Point(680, 33);
            this.cboJour.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboJour.Name = "cboJour";
            this.cboJour.Size = new System.Drawing.Size(159, 24);
            this.cboJour.TabIndex = 5;
            // 
            // lblHeureDebut
            // 
            this.lblHeureDebut.AutoSize = true;
            this.lblHeureDebut.Location = new System.Drawing.Point(27, 74);
            this.lblHeureDebut.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeureDebut.Name = "lblHeureDebut";
            this.lblHeureDebut.Size = new System.Drawing.Size(31, 16);
            this.lblHeureDebut.TabIndex = 6;
            this.lblHeureDebut.Text = "De :";
            // 
            // dtpHeureDebut
            // 
            this.dtpHeureDebut.CustomFormat = "HH:mm";
            this.dtpHeureDebut.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHeureDebut.Location = new System.Drawing.Point(93, 70);
            this.dtpHeureDebut.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpHeureDebut.Name = "dtpHeureDebut";
            this.dtpHeureDebut.ShowUpDown = true;
            this.dtpHeureDebut.Size = new System.Drawing.Size(105, 22);
            this.dtpHeureDebut.TabIndex = 7;
            // 
            // lblHeureFin
            // 
            this.lblHeureFin.AutoSize = true;
            this.lblHeureFin.Location = new System.Drawing.Point(227, 74);
            this.lblHeureFin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeureFin.Name = "lblHeureFin";
            this.lblHeureFin.Size = new System.Drawing.Size(22, 16);
            this.lblHeureFin.TabIndex = 8;
            this.lblHeureFin.Text = "À :";
            // 
            // dtpHeureFin
            // 
            this.dtpHeureFin.CustomFormat = "HH:mm";
            this.dtpHeureFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHeureFin.Location = new System.Drawing.Point(267, 70);
            this.dtpHeureFin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpHeureFin.Name = "dtpHeureFin";
            this.dtpHeureFin.ShowUpDown = true;
            this.dtpHeureFin.Size = new System.Drawing.Size(105, 22);
            this.dtpHeureFin.TabIndex = 9;
            // 
            // lblRecherche
            // 
            this.lblRecherche.AutoSize = true;
            this.lblRecherche.Location = new System.Drawing.Point(400, 74);
            this.lblRecherche.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRecherche.Name = "lblRecherche";
            this.lblRecherche.Size = new System.Drawing.Size(79, 16);
            this.lblRecherche.TabIndex = 10;
            this.lblRecherche.Text = "Recherche :";
            // 
            // txtRecherche
            // 
            this.txtRecherche.Location = new System.Drawing.Point(493, 70);
            this.txtRecherche.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRecherche.Name = "txtRecherche";
            this.txtRecherche.Size = new System.Drawing.Size(265, 22);
            this.txtRecherche.TabIndex = 11;
            this.txtRecherche.TextChanged += new System.EventHandler(this.txtRecherche_TextChanged);
            // 
            // chkSeulementActifs
            // 
            this.chkSeulementActifs.AutoSize = true;
            this.chkSeulementActifs.Location = new System.Drawing.Point(27, 111);
            this.chkSeulementActifs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkSeulementActifs.Name = "chkSeulementActifs";
            this.chkSeulementActifs.Size = new System.Drawing.Size(127, 20);
            this.chkSeulementActifs.TabIndex = 12;
            this.chkSeulementActifs.Text = "Seulement actifs";
            this.chkSeulementActifs.UseVisualStyleBackColor = true;
            // 
            // chkProchainsDeparts
            // 
            this.chkProchainsDeparts.AutoSize = true;
            this.chkProchainsDeparts.Location = new System.Drawing.Point(200, 111);
            this.chkProchainsDeparts.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkProchainsDeparts.Name = "chkProchainsDeparts";
            this.chkProchainsDeparts.Size = new System.Drawing.Size(138, 20);
            this.chkProchainsDeparts.TabIndex = 13;
            this.chkProchainsDeparts.Text = "Prochains départs";
            this.chkProchainsDeparts.UseVisualStyleBackColor = true;
            this.chkProchainsDeparts.CheckedChanged += new System.EventHandler(this.chkProchainsDeparts_CheckedChanged);
            // 
            // btnAfficher
            // 
            this.btnAfficher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnAfficher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAfficher.ForeColor = System.Drawing.Color.White;
            this.btnAfficher.Location = new System.Drawing.Point(800, 105);
            this.btnAfficher.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAfficher.Name = "btnAfficher";
            this.btnAfficher.Size = new System.Drawing.Size(133, 31);
            this.btnAfficher.TabIndex = 14;
            this.btnAfficher.Text = "Afficher";
            this.btnAfficher.UseVisualStyleBackColor = false;
            this.btnAfficher.Click += new System.EventHandler(this.btnAfficher_Click);
            // 
            // btnExporter
            // 
            this.btnExporter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnExporter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExporter.ForeColor = System.Drawing.Color.White;
            this.btnExporter.Location = new System.Drawing.Point(947, 105);
            this.btnExporter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExporter.Name = "btnExporter";
            this.btnExporter.Size = new System.Drawing.Size(107, 31);
            this.btnExporter.TabIndex = 15;
            this.btnExporter.Text = "Exporter";
            this.btnExporter.UseVisualStyleBackColor = false;
            this.btnExporter.Click += new System.EventHandler(this.btnExporter_Click);
            // 
            // flpHoraires
            // 
            this.flpHoraires.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpHoraires.AutoScroll = true;
            this.flpHoraires.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.flpHoraires.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpHoraires.Location = new System.Drawing.Point(20, 246);
            this.flpHoraires.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flpHoraires.Name = "flpHoraires";
            this.flpHoraires.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.flpHoraires.Size = new System.Drawing.Size(1293, 369);
            this.flpHoraires.TabIndex = 17;
            this.flpHoraires.WrapContents = false;
            // 
            // lblStatistiques
            // 
            this.lblStatistiques.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatistiques.AutoSize = true;
            this.lblStatistiques.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblStatistiques.ForeColor = System.Drawing.Color.Gray;
            this.lblStatistiques.Location = new System.Drawing.Point(20, 628);
            this.lblStatistiques.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatistiques.Name = "lblStatistiques";
            this.lblStatistiques.Size = new System.Drawing.Size(0, 17);
            this.lblStatistiques.TabIndex = 18;
            // 
            // lblProchainsDeparts
            // 
            this.lblProchainsDeparts.AutoSize = true;
            this.lblProchainsDeparts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic);
            this.lblProchainsDeparts.Location = new System.Drawing.Point(20, 222);
            this.lblProchainsDeparts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProchainsDeparts.Name = "lblProchainsDeparts";
            this.lblProchainsDeparts.Size = new System.Drawing.Size(0, 18);
            this.lblProchainsDeparts.TabIndex = 16;
            // 
            // UCConsultationHoraires
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblStatistiques);
            this.Controls.Add(this.flpHoraires);
            this.Controls.Add(this.lblProchainsDeparts);
            this.Controls.Add(this.grpFiltres);
            this.Controls.Add(this.lblTitre);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UCConsultationHoraires";
            this.Size = new System.Drawing.Size(1333, 652);
            this.Load += new System.EventHandler(this.UCConsultationHoraires_Load);
            this.grpFiltres.ResumeLayout(false);
            this.grpFiltres.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
