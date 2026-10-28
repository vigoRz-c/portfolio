namespace Fumoblilite.Interface.UserControls
{
    partial class UCGestionHoraires
    {
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.GroupBox grpFiltres;
        private System.Windows.Forms.Label lblLigne;
        private System.Windows.Forms.ComboBox cboLigne;
        private System.Windows.Forms.Label lblJour;
        private System.Windows.Forms.ComboBox cboJour;
        private System.Windows.Forms.Button btnAfficher;
        private System.Windows.Forms.FlowLayoutPanel flpHoraires;
        private System.Windows.Forms.GroupBox grpDetails;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblLigneDetail;
        private System.Windows.Forms.ComboBox cboLigneDetail;
        private System.Windows.Forms.Label lblArret;
        private System.Windows.Forms.ComboBox cboArret;
        private System.Windows.Forms.Label lblJourDetail;
        private System.Windows.Forms.ComboBox cboJourDetail;
        private System.Windows.Forms.Label lblHeure;
        private System.Windows.Forms.DateTimePicker dtpHeure;
        private System.Windows.Forms.CheckBox chkEstActif;
        private System.Windows.Forms.Button btnNouveau;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnDupliquer;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabGestion;
        private System.Windows.Forms.TabPage tabRecurrent;
        private System.Windows.Forms.TabPage tabDuplication;
        private System.Windows.Forms.GroupBox grpRecurrent;
        private System.Windows.Forms.Label lblHeureDebut;
        private System.Windows.Forms.DateTimePicker dtpHeureDebut;
        private System.Windows.Forms.Label lblHeureFin;
        private System.Windows.Forms.DateTimePicker dtpHeureFin;
        private System.Windows.Forms.Label lblIntervalle;
        private System.Windows.Forms.NumericUpDown nudIntervalle;
        private System.Windows.Forms.Label lblNombreHoraires;
        private System.Windows.Forms.NumericUpDown nudNombreHoraires;
        private System.Windows.Forms.Label lblJoursRecurrent;
        private System.Windows.Forms.CheckedListBox clbJours;
        private System.Windows.Forms.Button btnGenererRecurrent;
        private System.Windows.Forms.GroupBox grpDuplication;
        private System.Windows.Forms.Label lblLigneSource;
        private System.Windows.Forms.ComboBox cboLigneSource;
        private System.Windows.Forms.Label lblLigneDestination;
        private System.Windows.Forms.ComboBox cboLigneDestination;
        private System.Windows.Forms.Button btnDupliquerLigne;
        private System.Windows.Forms.Button btnExporterCsv;
        private System.Windows.Forms.Button btnExporterJson;
        // Ajouter un bouton pour supprimer tous les horaires affichés
        private System.Windows.Forms.Button btnSupprimerTout;
        private void InitializeComponent()
        {
            this.lblTitre = new System.Windows.Forms.Label();
            this.grpFiltres = new System.Windows.Forms.GroupBox();
            this.lblLigne = new System.Windows.Forms.Label();
            this.cboLigne = new System.Windows.Forms.ComboBox();
            this.lblJour = new System.Windows.Forms.Label();
            this.cboJour = new System.Windows.Forms.ComboBox();
            this.btnAfficher = new System.Windows.Forms.Button();
            this.flpHoraires = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabGestion = new System.Windows.Forms.TabPage();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblLigneDetail = new System.Windows.Forms.Label();
            this.cboLigneDetail = new System.Windows.Forms.ComboBox();
            this.lblArret = new System.Windows.Forms.Label();
            this.cboArret = new System.Windows.Forms.ComboBox();
            this.lblJourDetail = new System.Windows.Forms.Label();
            this.cboJourDetail = new System.Windows.Forms.ComboBox();
            this.lblHeure = new System.Windows.Forms.Label();
            this.dtpHeure = new System.Windows.Forms.DateTimePicker();
            this.chkEstActif = new System.Windows.Forms.CheckBox();
            this.btnNouveau = new System.Windows.Forms.Button();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnDupliquer = new System.Windows.Forms.Button();
            this.tabRecurrent = new System.Windows.Forms.TabPage();
            this.grpRecurrent = new System.Windows.Forms.GroupBox();
            this.lblHeureDebut = new System.Windows.Forms.Label();
            this.dtpHeureDebut = new System.Windows.Forms.DateTimePicker();
            this.lblHeureFin = new System.Windows.Forms.Label();
            this.dtpHeureFin = new System.Windows.Forms.DateTimePicker();
            this.lblIntervalle = new System.Windows.Forms.Label();
            this.nudIntervalle = new System.Windows.Forms.NumericUpDown();
            this.lblNombreHoraires = new System.Windows.Forms.Label();
            this.nudNombreHoraires = new System.Windows.Forms.NumericUpDown();
            this.lblJoursRecurrent = new System.Windows.Forms.Label();
            this.clbJours = new System.Windows.Forms.CheckedListBox();
            this.btnGenererRecurrent = new System.Windows.Forms.Button();
            this.tabDuplication = new System.Windows.Forms.TabPage();
            this.grpDuplication = new System.Windows.Forms.GroupBox();
            this.lblLigneSource = new System.Windows.Forms.Label();
            this.cboLigneSource = new System.Windows.Forms.ComboBox();
            this.lblLigneDestination = new System.Windows.Forms.Label();
            this.cboLigneDestination = new System.Windows.Forms.ComboBox();
            this.btnDupliquerLigne = new System.Windows.Forms.Button();
            this.btnExporterCsv = new System.Windows.Forms.Button();
            this.btnExporterJson = new System.Windows.Forms.Button();
            // Ajouter cette déclaration après les autres déclarations de boutons
            this.btnSupprimerTout = new System.Windows.Forms.Button();
            this.grpFiltres.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabGestion.SuspendLayout();
            this.grpDetails.SuspendLayout();
            this.tabRecurrent.SuspendLayout();
            this.grpRecurrent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIntervalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNombreHoraires)).BeginInit();
            this.tabDuplication.SuspendLayout();
            this.grpDuplication.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitre
            // 
            this.lblTitre.AutoSize = true;
            this.lblTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.lblTitre.Location = new System.Drawing.Point(20, 18);
            this.lblTitre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(284, 31);
            this.lblTitre.TabIndex = 0;
            this.lblTitre.Text = "Gestion des horaires";
            // 
            // grpFiltres
            // 
            this.grpFiltres.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFiltres.Controls.Add(this.lblLigne);
            this.grpFiltres.Controls.Add(this.cboLigne);
            this.grpFiltres.Controls.Add(this.lblJour);
            this.grpFiltres.Controls.Add(this.cboJour);
            this.grpFiltres.Controls.Add(this.btnAfficher);
            this.grpFiltres.Location = new System.Drawing.Point(20, 62);
            this.grpFiltres.Margin = new System.Windows.Forms.Padding(4);
            this.grpFiltres.Name = "grpFiltres";
            this.grpFiltres.Padding = new System.Windows.Forms.Padding(4);
            this.grpFiltres.Size = new System.Drawing.Size(1293, 86);
            this.grpFiltres.TabIndex = 1;
            this.grpFiltres.TabStop = false;
            this.grpFiltres.Text = "Filtres";
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
            this.cboLigne.Margin = new System.Windows.Forms.Padding(4);
            this.cboLigne.Name = "cboLigne";
            this.cboLigne.Size = new System.Drawing.Size(265, 24);
            this.cboLigne.TabIndex = 1;
            // 
            // lblJour
            // 
            this.lblJour.AutoSize = true;
            this.lblJour.Location = new System.Drawing.Point(400, 37);
            this.lblJour.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblJour.Name = "lblJour";
            this.lblJour.Size = new System.Drawing.Size(39, 16);
            this.lblJour.TabIndex = 2;
            this.lblJour.Text = "Jour :";
            // 
            // cboJour
            // 
            this.cboJour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboJour.FormattingEnabled = true;
            this.cboJour.Location = new System.Drawing.Point(467, 33);
            this.cboJour.Margin = new System.Windows.Forms.Padding(4);
            this.cboJour.Name = "cboJour";
            this.cboJour.Size = new System.Drawing.Size(199, 24);
            this.cboJour.TabIndex = 3;
            // 
            // btnAfficher
            // 
            this.btnAfficher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnAfficher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAfficher.ForeColor = System.Drawing.Color.White;
            this.btnAfficher.Location = new System.Drawing.Point(733, 31);
            this.btnAfficher.Margin = new System.Windows.Forms.Padding(4);
            this.btnAfficher.Name = "btnAfficher";
            this.btnAfficher.Size = new System.Drawing.Size(133, 31);
            this.btnAfficher.TabIndex = 4;
            this.btnAfficher.Text = "Afficher";
            this.btnAfficher.UseVisualStyleBackColor = false;
            this.btnAfficher.Click += new System.EventHandler(this.btnAfficher_Click);
            // 
            // flpHoraires
            // 
            this.flpHoraires.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpHoraires.AutoScroll = true;
            this.flpHoraires.BackColor = System.Drawing.Color.White;
            this.flpHoraires.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpHoraires.Location = new System.Drawing.Point(20, 160);
            this.flpHoraires.Margin = new System.Windows.Forms.Padding(4);
            this.flpHoraires.Name = "flpHoraires";
            this.flpHoraires.Size = new System.Drawing.Size(599, 430);
            this.flpHoraires.TabIndex = 2;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabGestion);
            this.tabControl.Controls.Add(this.tabRecurrent);
            this.tabControl.Controls.Add(this.tabDuplication);
            this.tabControl.Location = new System.Drawing.Point(640, 160);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(636, 283);
            this.tabControl.TabIndex = 3;
            // 
            // tabGestion
            // 
            this.tabGestion.Controls.Add(this.grpDetails);
            this.tabGestion.Controls.Add(this.btnNouveau);
            this.tabGestion.Controls.Add(this.btnEnregistrer);
            this.tabGestion.Controls.Add(this.btnSupprimer);
            this.tabGestion.Controls.Add(this.btnDupliquer);
            this.tabGestion.Location = new System.Drawing.Point(4, 25);
            this.tabGestion.Margin = new System.Windows.Forms.Padding(4);
            this.tabGestion.Name = "tabGestion";
            this.tabGestion.Padding = new System.Windows.Forms.Padding(4);
            this.tabGestion.Size = new System.Drawing.Size(628, 254);
            this.tabGestion.TabIndex = 0;
            this.tabGestion.Text = "Gestion";
            this.tabGestion.UseVisualStyleBackColor = true;
            // 
            // grpDetails
            // 
            this.grpDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDetails.Controls.Add(this.lblId);
            this.grpDetails.Controls.Add(this.txtId);
            this.grpDetails.Controls.Add(this.lblLigneDetail);
            this.grpDetails.Controls.Add(this.cboLigneDetail);
            this.grpDetails.Controls.Add(this.lblArret);
            this.grpDetails.Controls.Add(this.cboArret);
            this.grpDetails.Controls.Add(this.lblJourDetail);
            this.grpDetails.Controls.Add(this.cboJourDetail);
            this.grpDetails.Controls.Add(this.lblHeure);
            this.grpDetails.Controls.Add(this.dtpHeure);
            this.grpDetails.Controls.Add(this.chkEstActif);
            this.grpDetails.Location = new System.Drawing.Point(13, 12);
            this.grpDetails.Margin = new System.Windows.Forms.Padding(4);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Padding = new System.Windows.Forms.Padding(4);
            this.grpDetails.Size = new System.Drawing.Size(599, 135);
            this.grpDetails.TabIndex = 0;
            this.grpDetails.TabStop = false;
            this.grpDetails.Text = "Détails de l\'horaire";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(27, 37);
            this.lblId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(21, 16);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "Id:";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(160, 33);
            this.txtId.Margin = new System.Windows.Forms.Padding(4);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(212, 22);
            this.txtId.TabIndex = 1;
            // 
            // lblLigneDetail
            // 
            this.lblLigneDetail.AutoSize = true;
            this.lblLigneDetail.Location = new System.Drawing.Point(27, 74);
            this.lblLigneDetail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLigneDetail.Name = "lblLigneDetail";
            this.lblLigneDetail.Size = new System.Drawing.Size(46, 16);
            this.lblLigneDetail.TabIndex = 2;
            this.lblLigneDetail.Text = "Ligne :";
            // 
            // cboLigneDetail
            // 
            this.cboLigneDetail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLigneDetail.FormattingEnabled = true;
            this.cboLigneDetail.Location = new System.Drawing.Point(160, 70);
            this.cboLigneDetail.Margin = new System.Windows.Forms.Padding(4);
            this.cboLigneDetail.Name = "cboLigneDetail";
            this.cboLigneDetail.Size = new System.Drawing.Size(212, 24);
            this.cboLigneDetail.TabIndex = 3;
            this.cboLigneDetail.SelectedIndexChanged += new System.EventHandler(this.cboLigneDetail_SelectedIndexChanged);
            // 
            // lblArret
            // 
            this.lblArret.AutoSize = true;
            this.lblArret.Location = new System.Drawing.Point(27, 111);
            this.lblArret.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblArret.Name = "lblArret";
            this.lblArret.Size = new System.Drawing.Size(41, 16);
            this.lblArret.TabIndex = 4;
            this.lblArret.Text = "Arrêt :";
            // 
            // cboArret
            // 
            this.cboArret.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboArret.FormattingEnabled = true;
            this.cboArret.Location = new System.Drawing.Point(160, 107);
            this.cboArret.Margin = new System.Windows.Forms.Padding(4);
            this.cboArret.Name = "cboArret";
            this.cboArret.Size = new System.Drawing.Size(212, 24);
            this.cboArret.TabIndex = 5;
            // 
            // lblJourDetail
            // 
            this.lblJourDetail.AutoSize = true;
            this.lblJourDetail.Location = new System.Drawing.Point(27, 148);
            this.lblJourDetail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblJourDetail.Name = "lblJourDetail";
            this.lblJourDetail.Size = new System.Drawing.Size(39, 16);
            this.lblJourDetail.TabIndex = 6;
            this.lblJourDetail.Text = "Jour :";
            // 
            // cboJourDetail
            // 
            this.cboJourDetail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboJourDetail.FormattingEnabled = true;
            this.cboJourDetail.Location = new System.Drawing.Point(160, 144);
            this.cboJourDetail.Margin = new System.Windows.Forms.Padding(4);
            this.cboJourDetail.Name = "cboJourDetail";
            this.cboJourDetail.Size = new System.Drawing.Size(212, 24);
            this.cboJourDetail.TabIndex = 7;
            // 
            // lblHeure
            // 
            this.lblHeure.AutoSize = true;
            this.lblHeure.Location = new System.Drawing.Point(27, 185);
            this.lblHeure.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeure.Name = "lblHeure";
            this.lblHeure.Size = new System.Drawing.Size(50, 16);
            this.lblHeure.TabIndex = 8;
            this.lblHeure.Text = "Heure :";
            // 
            // dtpHeure
            // 
            this.dtpHeure.CustomFormat = "HH:mm";
            this.dtpHeure.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHeure.Location = new System.Drawing.Point(160, 181);
            this.dtpHeure.Margin = new System.Windows.Forms.Padding(4);
            this.dtpHeure.Name = "dtpHeure";
            this.dtpHeure.ShowUpDown = true;
            this.dtpHeure.Size = new System.Drawing.Size(212, 22);
            this.dtpHeure.TabIndex = 9;
            // 
            // chkEstActif
            // 
            this.chkEstActif.AutoSize = true;
            this.chkEstActif.Location = new System.Drawing.Point(160, 222);
            this.chkEstActif.Margin = new System.Windows.Forms.Padding(4);
            this.chkEstActif.Name = "chkEstActif";
            this.chkEstActif.Size = new System.Drawing.Size(75, 20);
            this.chkEstActif.TabIndex = 10;
            this.chkEstActif.Text = "Est actif";
            this.chkEstActif.UseVisualStyleBackColor = true;
            // 
            // btnNouveau
            // 
            this.btnNouveau.Location = new System.Drawing.Point(13, 308);
            this.btnNouveau.Margin = new System.Windows.Forms.Padding(4);
            this.btnNouveau.Name = "btnNouveau";
            this.btnNouveau.Size = new System.Drawing.Size(120, 37);
            this.btnNouveau.TabIndex = 1;
            this.btnNouveau.Text = "Nouveau";
            this.btnNouveau.UseVisualStyleBackColor = true;
            this.btnNouveau.Click += new System.EventHandler(this.btnNouveau_Click);
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnEnregistrer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnregistrer.ForeColor = System.Drawing.Color.White;
            this.btnEnregistrer.Location = new System.Drawing.Point(147, 308);
            this.btnEnregistrer.Margin = new System.Windows.Forms.Padding(4);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(120, 37);
            this.btnEnregistrer.TabIndex = 2;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = false;
            this.btnEnregistrer.Click += new System.EventHandler(this.btnEnregistrer_Click);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.btnSupprimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupprimer.ForeColor = System.Drawing.Color.White;
            this.btnSupprimer.Location = new System.Drawing.Point(280, 308);
            this.btnSupprimer.Margin = new System.Windows.Forms.Padding(4);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(120, 37);
            this.btnSupprimer.TabIndex = 3;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = false;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // btnDupliquer
            // 
            this.btnDupliquer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnDupliquer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDupliquer.ForeColor = System.Drawing.Color.White;
            this.btnDupliquer.Location = new System.Drawing.Point(413, 308);
            this.btnDupliquer.Margin = new System.Windows.Forms.Padding(4);
            this.btnDupliquer.Name = "btnDupliquer";
            this.btnDupliquer.Size = new System.Drawing.Size(120, 37);
            this.btnDupliquer.TabIndex = 4;
            this.btnDupliquer.Text = "Dupliquer";
            this.btnDupliquer.UseVisualStyleBackColor = false;
            this.btnDupliquer.Click += new System.EventHandler(this.btnDupliquer_Click);
            // 
            // tabRecurrent
            // 
            this.tabRecurrent.Controls.Add(this.grpRecurrent);
            this.tabRecurrent.Location = new System.Drawing.Point(4, 25);
            this.tabRecurrent.Margin = new System.Windows.Forms.Padding(4);
            this.tabRecurrent.Name = "tabRecurrent";
            this.tabRecurrent.Size = new System.Drawing.Size(628, 254);
            this.tabRecurrent.TabIndex = 1;
            this.tabRecurrent.Text = "Horaires récurrents";
            this.tabRecurrent.UseVisualStyleBackColor = true;
            // 
            // grpRecurrent
            // 
            this.grpRecurrent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRecurrent.Controls.Add(this.lblHeureDebut);
            this.grpRecurrent.Controls.Add(this.dtpHeureDebut);
            this.grpRecurrent.Controls.Add(this.lblHeureFin);
            this.grpRecurrent.Controls.Add(this.dtpHeureFin);
            this.grpRecurrent.Controls.Add(this.lblIntervalle);
            this.grpRecurrent.Controls.Add(this.nudIntervalle);
            this.grpRecurrent.Controls.Add(this.lblNombreHoraires);
            this.grpRecurrent.Controls.Add(this.nudNombreHoraires);
            this.grpRecurrent.Controls.Add(this.lblJoursRecurrent);
            this.grpRecurrent.Controls.Add(this.clbJours);
            this.grpRecurrent.Controls.Add(this.btnGenererRecurrent);
            this.grpRecurrent.Location = new System.Drawing.Point(13, 12);
            this.grpRecurrent.Margin = new System.Windows.Forms.Padding(4);
            this.grpRecurrent.Name = "grpRecurrent";
            this.grpRecurrent.Padding = new System.Windows.Forms.Padding(4);
            this.grpRecurrent.Size = new System.Drawing.Size(599, 226);
            this.grpRecurrent.TabIndex = 0;
            this.grpRecurrent.TabStop = false;
            this.grpRecurrent.Text = "Génération d\'horaires récurrents";
            // 
            // lblHeureDebut
            // 
            this.lblHeureDebut.AutoSize = true;
            this.lblHeureDebut.Location = new System.Drawing.Point(27, 37);
            this.lblHeureDebut.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeureDebut.Name = "lblHeureDebut";
            this.lblHeureDebut.Size = new System.Drawing.Size(106, 16);
            this.lblHeureDebut.TabIndex = 0;
            this.lblHeureDebut.Text = "Heure de début :";
            // 
            // dtpHeureDebut
            // 
            this.dtpHeureDebut.CustomFormat = "HH:mm";
            this.dtpHeureDebut.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHeureDebut.Location = new System.Drawing.Point(160, 33);
            this.dtpHeureDebut.Margin = new System.Windows.Forms.Padding(4);
            this.dtpHeureDebut.Name = "dtpHeureDebut";
            this.dtpHeureDebut.ShowUpDown = true;
            this.dtpHeureDebut.Size = new System.Drawing.Size(105, 22);
            this.dtpHeureDebut.TabIndex = 1;
            // 
            // lblHeureFin
            // 
            this.lblHeureFin.AutoSize = true;
            this.lblHeureFin.Location = new System.Drawing.Point(293, 37);
            this.lblHeureFin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeureFin.Name = "lblHeureFin";
            this.lblHeureFin.Size = new System.Drawing.Size(85, 16);
            this.lblHeureFin.TabIndex = 2;
            this.lblHeureFin.Text = "Heure de fin :";
            // 
            // dtpHeureFin
            // 
            this.dtpHeureFin.CustomFormat = "HH:mm";
            this.dtpHeureFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHeureFin.Location = new System.Drawing.Point(413, 33);
            this.dtpHeureFin.Margin = new System.Windows.Forms.Padding(4);
            this.dtpHeureFin.Name = "dtpHeureFin";
            this.dtpHeureFin.ShowUpDown = true;
            this.dtpHeureFin.Size = new System.Drawing.Size(105, 22);
            this.dtpHeureFin.TabIndex = 3;
            // 
            // lblIntervalle
            // 
            this.lblIntervalle.AutoSize = true;
            this.lblIntervalle.Location = new System.Drawing.Point(27, 74);
            this.lblIntervalle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIntervalle.Name = "lblIntervalle";
            this.lblIntervalle.Size = new System.Drawing.Size(99, 16);
            this.lblIntervalle.TabIndex = 4;
            this.lblIntervalle.Text = "Intervalle (min) :";
            // 
            // nudIntervalle
            // 
            this.nudIntervalle.Location = new System.Drawing.Point(160, 70);
            this.nudIntervalle.Margin = new System.Windows.Forms.Padding(4);
            this.nudIntervalle.Maximum = new decimal(new int[] {
            480,
            0,
            0,
            0});
            this.nudIntervalle.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudIntervalle.Name = "nudIntervalle";
            this.nudIntervalle.Size = new System.Drawing.Size(107, 22);
            this.nudIntervalle.TabIndex = 5;
            this.nudIntervalle.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // lblNombreHoraires
            // 
            this.lblNombreHoraires.AutoSize = true;
            this.lblNombreHoraires.Location = new System.Drawing.Point(293, 74);
            this.lblNombreHoraires.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombreHoraires.Name = "lblNombreHoraires";
            this.lblNombreHoraires.Size = new System.Drawing.Size(90, 16);
            this.lblNombreHoraires.TabIndex = 6;
            this.lblNombreHoraires.Text = "Nombre max :";
            // 
            // nudNombreHoraires
            // 
            this.nudNombreHoraires.Location = new System.Drawing.Point(413, 70);
            this.nudNombreHoraires.Margin = new System.Windows.Forms.Padding(4);
            this.nudNombreHoraires.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNombreHoraires.Name = "nudNombreHoraires";
            this.nudNombreHoraires.Size = new System.Drawing.Size(107, 22);
            this.nudNombreHoraires.TabIndex = 7;
            this.nudNombreHoraires.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblJoursRecurrent
            // 
            this.lblJoursRecurrent.AutoSize = true;
            this.lblJoursRecurrent.Location = new System.Drawing.Point(27, 111);
            this.lblJoursRecurrent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblJoursRecurrent.Name = "lblJoursRecurrent";
            this.lblJoursRecurrent.Size = new System.Drawing.Size(134, 16);
            this.lblJoursRecurrent.TabIndex = 8;
            this.lblJoursRecurrent.Text = "Jours de la semaine :";
            // 
            // clbJours
            // 
            this.clbJours.CheckOnClick = true;
            this.clbJours.FormattingEnabled = true;
            this.clbJours.Location = new System.Drawing.Point(27, 135);
            this.clbJours.Margin = new System.Windows.Forms.Padding(4);
            this.clbJours.Name = "clbJours";
            this.clbJours.Size = new System.Drawing.Size(265, 123);
            this.clbJours.TabIndex = 9;
            // 
            // btnGenererRecurrent
            // 
            this.btnGenererRecurrent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnGenererRecurrent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenererRecurrent.ForeColor = System.Drawing.Color.White;
            this.btnGenererRecurrent.Location = new System.Drawing.Point(27, 295);
            this.btnGenererRecurrent.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenererRecurrent.Name = "btnGenererRecurrent";
            this.btnGenererRecurrent.Size = new System.Drawing.Size(200, 43);
            this.btnGenererRecurrent.TabIndex = 10;
            this.btnGenererRecurrent.Text = "Générer horaires";
            this.btnGenererRecurrent.UseVisualStyleBackColor = false;
            this.btnGenererRecurrent.Click += new System.EventHandler(this.btnGenererRecurrent_Click);
            // 
            // tabDuplication
            // 
            this.tabDuplication.Controls.Add(this.grpDuplication);
            this.tabDuplication.Location = new System.Drawing.Point(4, 25);
            this.tabDuplication.Margin = new System.Windows.Forms.Padding(4);
            this.tabDuplication.Name = "tabDuplication";
            this.tabDuplication.Size = new System.Drawing.Size(628, 254);
            this.tabDuplication.TabIndex = 2;
            this.tabDuplication.Text = "Duplication";
            this.tabDuplication.UseVisualStyleBackColor = true;
            // 
            // grpDuplication
            // 
            this.grpDuplication.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDuplication.Controls.Add(this.lblLigneSource);
            this.grpDuplication.Controls.Add(this.cboLigneSource);
            this.grpDuplication.Controls.Add(this.lblLigneDestination);
            this.grpDuplication.Controls.Add(this.cboLigneDestination);
            this.grpDuplication.Controls.Add(this.btnDupliquerLigne);
            this.grpDuplication.Location = new System.Drawing.Point(13, 12);
            this.grpDuplication.Margin = new System.Windows.Forms.Padding(4);
            this.grpDuplication.Name = "grpDuplication";
            this.grpDuplication.Padding = new System.Windows.Forms.Padding(4);
            this.grpDuplication.Size = new System.Drawing.Size(599, 226);
            this.grpDuplication.TabIndex = 0;
            this.grpDuplication.TabStop = false;
            this.grpDuplication.Text = "Duplication d\'horaires entre lignes";
            // 
            // lblLigneSource
            // 
            this.lblLigneSource.AutoSize = true;
            this.lblLigneSource.Location = new System.Drawing.Point(27, 49);
            this.lblLigneSource.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLigneSource.Name = "lblLigneSource";
            this.lblLigneSource.Size = new System.Drawing.Size(90, 16);
            this.lblLigneSource.TabIndex = 0;
            this.lblLigneSource.Text = "Ligne source :";
            // 
            // cboLigneSource
            // 
            this.cboLigneSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLigneSource.FormattingEnabled = true;
            this.cboLigneSource.Location = new System.Drawing.Point(160, 46);
            this.cboLigneSource.Margin = new System.Windows.Forms.Padding(4);
            this.cboLigneSource.Name = "cboLigneSource";
            this.cboLigneSource.Size = new System.Drawing.Size(265, 24);
            this.cboLigneSource.TabIndex = 1;
            // 
            // lblLigneDestination
            // 
            this.lblLigneDestination.AutoSize = true;
            this.lblLigneDestination.Location = new System.Drawing.Point(27, 98);
            this.lblLigneDestination.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLigneDestination.Name = "lblLigneDestination";
            this.lblLigneDestination.Size = new System.Drawing.Size(114, 16);
            this.lblLigneDestination.TabIndex = 2;
            this.lblLigneDestination.Text = "Ligne destination :";
            // 
            // cboLigneDestination
            // 
            this.cboLigneDestination.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLigneDestination.FormattingEnabled = true;
            this.cboLigneDestination.Location = new System.Drawing.Point(160, 95);
            this.cboLigneDestination.Margin = new System.Windows.Forms.Padding(4);
            this.cboLigneDestination.Name = "cboLigneDestination";
            this.cboLigneDestination.Size = new System.Drawing.Size(265, 24);
            this.cboLigneDestination.TabIndex = 3;
            // 
            // btnDupliquerLigne
            // 
            this.btnDupliquerLigne.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnDupliquerLigne.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDupliquerLigne.ForeColor = System.Drawing.Color.Black;
            this.btnDupliquerLigne.Location = new System.Drawing.Point(27, 148);
            this.btnDupliquerLigne.Margin = new System.Windows.Forms.Padding(4);
            this.btnDupliquerLigne.Name = "btnDupliquerLigne";
            this.btnDupliquerLigne.Size = new System.Drawing.Size(200, 43);
            this.btnDupliquerLigne.TabIndex = 4;
            this.btnDupliquerLigne.Text = "Dupliquer horaires";
            this.btnDupliquerLigne.UseVisualStyleBackColor = false;
            this.btnDupliquerLigne.Click += new System.EventHandler(this.btnDupliquerLigne_Click);
            // 
            // btnExporterCsv
            // 
            this.btnExporterCsv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExporterCsv.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnExporterCsv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExporterCsv.Location = new System.Drawing.Point(1002, 544);
            this.btnExporterCsv.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnExporterCsv.Name = "btnExporterCsv";
            this.btnExporterCsv.Size = new System.Drawing.Size(120, 37);
            this.btnExporterCsv.TabIndex = 8;
            this.btnExporterCsv.Text = "Exporter CSV";
            this.btnExporterCsv.Click += new System.EventHandler(this.btnExporterCsv_Click);
            // 
            // btnExporterJson
            // 
            this.btnExporterJson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExporterJson.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnExporterJson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExporterJson.Location = new System.Drawing.Point(1136, 544);
            this.btnExporterJson.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnExporterJson.Name = "btnExporterJson";
            this.btnExporterJson.Size = new System.Drawing.Size(120, 37);
            this.btnExporterJson.TabIndex = 9;
            this.btnExporterJson.Text = "Exporter JSON";
            this.btnExporterJson.Click += new System.EventHandler(this.btnExporterJson_Click);
            // 
            // btnSupprimerTout
            // 
            this.btnSupprimerTout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSupprimerTout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.btnSupprimerTout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupprimerTout.ForeColor = System.Drawing.Color.White;
            this.btnSupprimerTout.Location = new System.Drawing.Point(868, 544);
            this.btnSupprimerTout.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnSupprimerTout.Name = "btnSupprimerTout";
            this.btnSupprimerTout.Size = new System.Drawing.Size(120, 37);
            this.btnSupprimerTout.TabIndex = 7;
            this.btnSupprimerTout.Text = "Supprimer tout";
            this.btnSupprimerTout.UseVisualStyleBackColor = false;
            this.btnSupprimerTout.Click += new System.EventHandler(this.btnSupprimerTout_Click);
            // 
            // UCGestionHoraires
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.flpHoraires);
            this.Controls.Add(this.grpFiltres);
            this.Controls.Add(this.lblTitre);
            this.Controls.Add(this.btnSupprimerTout);
            this.Controls.Add(this.btnExporterCsv);
            this.Controls.Add(this.btnExporterJson);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UCGestionHoraires";
            this.Size = new System.Drawing.Size(1333, 603);
            this.Load += new System.EventHandler(this.UCGestionHoraires_Load);
            this.grpFiltres.ResumeLayout(false);
            this.grpFiltres.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabGestion.ResumeLayout(false);
            this.grpDetails.ResumeLayout(false);
            this.grpDetails.PerformLayout();
            this.tabRecurrent.ResumeLayout(false);
            this.grpRecurrent.ResumeLayout(false);
            this.grpRecurrent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIntervalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNombreHoraires)).EndInit();
            this.tabDuplication.ResumeLayout(false);
            this.grpDuplication.ResumeLayout(false);
            this.grpDuplication.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
