using System.Windows.Forms;
using System.Drawing;

namespace Fumoblilite.Interface.UserControls
{
    partial class UCGestionLignes
    {
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.FlowLayoutPanel flpLignes;
        private System.Windows.Forms.GroupBox grpDetails;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.Label lblCouleur;
        private System.Windows.Forms.TextBox txtCouleur;
        private System.Windows.Forms.Button btnCouleur;
        private System.Windows.Forms.CheckBox chkEstActif;
        private System.Windows.Forms.Button btnNouveau;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.TabControl tabDetails;
        private System.Windows.Forms.TabPage tabInfos;
        private System.Windows.Forms.TabPage tabArrets;
        private System.Windows.Forms.FlowLayoutPanel flpArrets;
        private System.Windows.Forms.GroupBox grpArret;
        private System.Windows.Forms.Label lblArret;
        private System.Windows.Forms.ComboBox cboArret;
        private System.Windows.Forms.Label lblOrdre;
        private System.Windows.Forms.NumericUpDown nudOrdre;
        private System.Windows.Forms.Label lblTempsArret;
        private System.Windows.Forms.NumericUpDown nudTempsArret;
        private System.Windows.Forms.Label lblTempsTrajet;
        private System.Windows.Forms.NumericUpDown nudTempsTrajet;
        private System.Windows.Forms.Button btnAjouterArret;
        private System.Windows.Forms.Button btnSupprimerArret;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button btnExporterCsv;
        private System.Windows.Forms.Button btnExporterJson;


        private void InitializeComponent()
        {
            this.lblTitre = new System.Windows.Forms.Label();
            this.flpLignes = new System.Windows.Forms.FlowLayoutPanel();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.chkEstActif = new System.Windows.Forms.CheckBox();
            this.btnCouleur = new System.Windows.Forms.Button();
            this.txtCouleur = new System.Windows.Forms.TextBox();
            this.lblCouleur = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.lblNom = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.lblNumero = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.btnNouveau = new System.Windows.Forms.Button();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.tabDetails = new System.Windows.Forms.TabControl();
            this.tabInfos = new System.Windows.Forms.TabPage();
            this.tabArrets = new System.Windows.Forms.TabPage();
            this.btnSupprimerArret = new System.Windows.Forms.Button();
            this.btnAjouterArret = new System.Windows.Forms.Button();
            this.grpArret = new System.Windows.Forms.GroupBox();
            this.nudTempsTrajet = new System.Windows.Forms.NumericUpDown();
            this.lblTempsTrajet = new System.Windows.Forms.Label();
            this.nudTempsArret = new System.Windows.Forms.NumericUpDown();
            this.lblTempsArret = new System.Windows.Forms.Label();
            this.nudOrdre = new System.Windows.Forms.NumericUpDown();
            this.lblOrdre = new System.Windows.Forms.Label();
            this.cboArret = new System.Windows.Forms.ComboBox();
            this.lblArret = new System.Windows.Forms.Label();
            this.flpArrets = new System.Windows.Forms.FlowLayoutPanel();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.btnExporterCsv = new System.Windows.Forms.Button();
            this.btnExporterJson = new System.Windows.Forms.Button();
            this.grpDetails.SuspendLayout();
            this.tabDetails.SuspendLayout();
            this.tabInfos.SuspendLayout();
            this.tabArrets.SuspendLayout();
            this.grpArret.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTempsTrajet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTempsArret)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOrdre)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitre
            // 
            this.lblTitre.AutoSize = true;
            this.lblTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.lblTitre.Location = new System.Drawing.Point(20, 18);
            this.lblTitre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(231, 29);
            this.lblTitre.TabIndex = 0;
            this.lblTitre.Text = "Gestion des lignes";
            // 
            // flpLignes
            // 
            this.flpLignes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flpLignes.AutoScroll = true;
            this.flpLignes.BackColor = System.Drawing.Color.White;
            this.flpLignes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpLignes.Location = new System.Drawing.Point(20, 62);
            this.flpLignes.Margin = new System.Windows.Forms.Padding(4);
            this.flpLignes.Name = "flpLignes";
            this.flpLignes.Size = new System.Drawing.Size(399, 473);
            this.flpLignes.TabIndex = 1;
            // 
            // grpDetails
            // 
            this.grpDetails.Controls.Add(this.chkEstActif);
            this.grpDetails.Controls.Add(this.btnCouleur);
            this.grpDetails.Controls.Add(this.txtCouleur);
            this.grpDetails.Controls.Add(this.lblCouleur);
            this.grpDetails.Controls.Add(this.txtNom);
            this.grpDetails.Controls.Add(this.lblNom);
            this.grpDetails.Controls.Add(this.txtNumero);
            this.grpDetails.Controls.Add(this.lblNumero);
            this.grpDetails.Controls.Add(this.txtId);
            this.grpDetails.Controls.Add(this.lblId);
            this.grpDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDetails.Location = new System.Drawing.Point(4, 4);
            this.grpDetails.Margin = new System.Windows.Forms.Padding(4);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Padding = new System.Windows.Forms.Padding(4);
            this.grpDetails.Size = new System.Drawing.Size(615, 381);
            this.grpDetails.TabIndex = 2;
            this.grpDetails.TabStop = false;
            this.grpDetails.Text = "Détails de la ligne";
            // 
            // chkEstActif
            // 
            this.chkEstActif.AutoSize = true;
            this.chkEstActif.Location = new System.Drawing.Point(160, 176);
            this.chkEstActif.Margin = new System.Windows.Forms.Padding(4);
            this.chkEstActif.Name = "chkEstActif";
            this.chkEstActif.Size = new System.Drawing.Size(75, 20);
            this.chkEstActif.TabIndex = 11;
            this.chkEstActif.Text = "Est actif";
            this.chkEstActif.UseVisualStyleBackColor = true;
            // 
            // btnCouleur
            // 
            this.btnCouleur.Location = new System.Drawing.Point(307, 142);
            this.btnCouleur.Margin = new System.Windows.Forms.Padding(4);
            this.btnCouleur.Name = "btnCouleur";
            this.btnCouleur.Size = new System.Drawing.Size(40, 28);
            this.btnCouleur.TabIndex = 8;
            this.btnCouleur.Text = "...";
            this.btnCouleur.UseVisualStyleBackColor = true;
            this.btnCouleur.Click += new System.EventHandler(this.btnCouleur_Click);
            // 
            // txtCouleur
            // 
            this.txtCouleur.Location = new System.Drawing.Point(160, 144);
            this.txtCouleur.Margin = new System.Windows.Forms.Padding(4);
            this.txtCouleur.Name = "txtCouleur";
            this.txtCouleur.Size = new System.Drawing.Size(132, 22);
            this.txtCouleur.TabIndex = 7;
            // 
            // lblCouleur
            // 
            this.lblCouleur.AutoSize = true;
            this.lblCouleur.Location = new System.Drawing.Point(27, 148);
            this.lblCouleur.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCouleur.Name = "lblCouleur";
            this.lblCouleur.Size = new System.Drawing.Size(56, 16);
            this.lblCouleur.TabIndex = 6;
            this.lblCouleur.Text = "Couleur:";
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(160, 107);
            this.txtNom.Margin = new System.Windows.Forms.Padding(4);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(265, 22);
            this.txtNom.TabIndex = 5;
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(27, 111);
            this.lblNom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(39, 16);
            this.lblNom.TabIndex = 4;
            this.lblNom.Text = "Nom:";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(160, 70);
            this.txtNumero.Margin = new System.Windows.Forms.Padding(4);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(132, 22);
            this.txtNumero.TabIndex = 3;
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(27, 74);
            this.lblNumero.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(58, 16);
            this.lblNumero.TabIndex = 2;
            this.lblNumero.Text = "Numéro:";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(160, 33);
            this.txtId.Margin = new System.Windows.Forms.Padding(4);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(132, 22);
            this.txtId.TabIndex = 1;
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
            // btnNouveau
            // 
            this.btnNouveau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNouveau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnNouveau.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnNouveau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNouveau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnNouveau.Location = new System.Drawing.Point(640, 498);
            this.btnNouveau.Margin = new System.Windows.Forms.Padding(4);
            this.btnNouveau.Name = "btnNouveau";
            this.btnNouveau.Size = new System.Drawing.Size(120, 37);
            this.btnNouveau.TabIndex = 3;
            this.btnNouveau.Text = "Nouveau";
            this.btnNouveau.UseVisualStyleBackColor = false;
            this.btnNouveau.Click += new System.EventHandler(this.btnNouveau_Click);
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnregistrer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnEnregistrer.FlatAppearance.BorderSize = 0;
            this.btnEnregistrer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnregistrer.ForeColor = System.Drawing.Color.White;
            this.btnEnregistrer.Location = new System.Drawing.Point(773, 498);
            this.btnEnregistrer.Margin = new System.Windows.Forms.Padding(4);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(120, 37);
            this.btnEnregistrer.TabIndex = 4;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = false;
            this.btnEnregistrer.Click += new System.EventHandler(this.btnEnregistrer_Click);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSupprimer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.btnSupprimer.FlatAppearance.BorderSize = 0;
            this.btnSupprimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupprimer.ForeColor = System.Drawing.Color.White;
            this.btnSupprimer.Location = new System.Drawing.Point(907, 498);
            this.btnSupprimer.Margin = new System.Windows.Forms.Padding(4);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(120, 37);
            this.btnSupprimer.TabIndex = 5;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = false;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // tabDetails
            // 
            this.tabDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabDetails.Controls.Add(this.tabInfos);
            this.tabDetails.Controls.Add(this.tabArrets);
            this.tabDetails.Location = new System.Drawing.Point(440, 62);
            this.tabDetails.Margin = new System.Windows.Forms.Padding(4);
            this.tabDetails.Name = "tabDetails";
            this.tabDetails.SelectedIndex = 0;
            this.tabDetails.Size = new System.Drawing.Size(631, 418);
            this.tabDetails.TabIndex = 6;
            // 
            // tabInfos
            // 
            this.tabInfos.Controls.Add(this.grpDetails);
            this.tabInfos.Location = new System.Drawing.Point(4, 25);
            this.tabInfos.Margin = new System.Windows.Forms.Padding(4);
            this.tabInfos.Name = "tabInfos";
            this.tabInfos.Padding = new System.Windows.Forms.Padding(4);
            this.tabInfos.Size = new System.Drawing.Size(623, 389);
            this.tabInfos.TabIndex = 0;
            this.tabInfos.Text = "Informations";
            this.tabInfos.UseVisualStyleBackColor = true;
            // 
            // tabArrets
            // 
            this.tabArrets.Controls.Add(this.btnSupprimerArret);
            this.tabArrets.Controls.Add(this.btnAjouterArret);
            this.tabArrets.Controls.Add(this.grpArret);
            this.tabArrets.Controls.Add(this.flpArrets);
            this.tabArrets.Location = new System.Drawing.Point(4, 25);
            this.tabArrets.Margin = new System.Windows.Forms.Padding(4);
            this.tabArrets.Name = "tabArrets";
            this.tabArrets.Padding = new System.Windows.Forms.Padding(4);
            this.tabArrets.Size = new System.Drawing.Size(623, 389);
            this.tabArrets.TabIndex = 1;
            this.tabArrets.Text = "Arrêts";
            this.tabArrets.UseVisualStyleBackColor = true;
            // 
            // btnSupprimerArret
            // 
            this.btnSupprimerArret.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSupprimerArret.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.btnSupprimerArret.FlatAppearance.BorderSize = 0;
            this.btnSupprimerArret.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupprimerArret.ForeColor = System.Drawing.Color.White;
            this.btnSupprimerArret.Location = new System.Drawing.Point(333, 342);
            this.btnSupprimerArret.Margin = new System.Windows.Forms.Padding(4);
            this.btnSupprimerArret.Name = "btnSupprimerArret";
            this.btnSupprimerArret.Size = new System.Drawing.Size(160, 37);
            this.btnSupprimerArret.TabIndex = 3;
            this.btnSupprimerArret.Text = "Supprimer l\'arrêt";
            this.btnSupprimerArret.UseVisualStyleBackColor = false;
            this.btnSupprimerArret.Click += new System.EventHandler(this.btnSupprimerArret_Click);
            // 
            // btnAjouterArret
            // 
            this.btnAjouterArret.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAjouterArret.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnAjouterArret.FlatAppearance.BorderSize = 0;
            this.btnAjouterArret.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjouterArret.ForeColor = System.Drawing.Color.White;
            this.btnAjouterArret.Location = new System.Drawing.Point(133, 342);
            this.btnAjouterArret.Margin = new System.Windows.Forms.Padding(4);
            this.btnAjouterArret.Name = "btnAjouterArret";
            this.btnAjouterArret.Size = new System.Drawing.Size(160, 37);
            this.btnAjouterArret.TabIndex = 2;
            this.btnAjouterArret.Text = "Ajouter l\'arrêt";
            this.btnAjouterArret.UseVisualStyleBackColor = false;
            this.btnAjouterArret.Click += new System.EventHandler(this.btnAjouterArret_Click);
            // 
            // grpArret
            // 
            this.grpArret.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpArret.Controls.Add(this.nudTempsTrajet);
            this.grpArret.Controls.Add(this.lblTempsTrajet);
            this.grpArret.Controls.Add(this.nudTempsArret);
            this.grpArret.Controls.Add(this.lblTempsArret);
            this.grpArret.Controls.Add(this.nudOrdre);
            this.grpArret.Controls.Add(this.lblOrdre);
            this.grpArret.Controls.Add(this.cboArret);
            this.grpArret.Controls.Add(this.lblArret);
            this.grpArret.Location = new System.Drawing.Point(8, 199);
            this.grpArret.Margin = new System.Windows.Forms.Padding(4);
            this.grpArret.Name = "grpArret";
            this.grpArret.Padding = new System.Windows.Forms.Padding(4);
            this.grpArret.Size = new System.Drawing.Size(604, 135);
            this.grpArret.TabIndex = 1;
            this.grpArret.TabStop = false;
            this.grpArret.Text = "Ajouter un arrêt";
            // 
            // nudTempsTrajet
            // 
            this.nudTempsTrajet.Location = new System.Drawing.Point(427, 102);
            this.nudTempsTrajet.Margin = new System.Windows.Forms.Padding(4);
            this.nudTempsTrajet.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudTempsTrajet.Name = "nudTempsTrajet";
            this.nudTempsTrajet.Size = new System.Drawing.Size(80, 22);
            this.nudTempsTrajet.TabIndex = 7;
            this.nudTempsTrajet.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // lblTempsTrajet
            // 
            this.lblTempsTrajet.AutoSize = true;
            this.lblTempsTrajet.Location = new System.Drawing.Point(267, 105);
            this.lblTempsTrajet.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTempsTrajet.Name = "lblTempsTrajet";
            this.lblTempsTrajet.Size = new System.Drawing.Size(120, 16);
            this.lblTempsTrajet.TabIndex = 6;
            this.lblTempsTrajet.Text = "Temps trajet (min) :";
            // 
            // nudTempsArret
            // 
            this.nudTempsArret.Location = new System.Drawing.Point(173, 102);
            this.nudTempsArret.Margin = new System.Windows.Forms.Padding(4);
            this.nudTempsArret.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudTempsArret.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTempsArret.Name = "nudTempsArret";
            this.nudTempsArret.Size = new System.Drawing.Size(80, 22);
            this.nudTempsArret.TabIndex = 5;
            this.nudTempsArret.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblTempsArret
            // 
            this.lblTempsArret.AutoSize = true;
            this.lblTempsArret.Location = new System.Drawing.Point(20, 105);
            this.lblTempsArret.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTempsArret.Name = "lblTempsArret";
            this.lblTempsArret.Size = new System.Drawing.Size(129, 16);
            this.lblTempsArret.TabIndex = 4;
            this.lblTempsArret.Text = "Temps d\'arrêt (min) :";
            // 
            // nudOrdre
            // 
            this.nudOrdre.Location = new System.Drawing.Point(80, 65);
            this.nudOrdre.Margin = new System.Windows.Forms.Padding(4);
            this.nudOrdre.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudOrdre.Name = "nudOrdre";
            this.nudOrdre.Size = new System.Drawing.Size(80, 22);
            this.nudOrdre.TabIndex = 3;
            this.nudOrdre.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblOrdre
            // 
            this.lblOrdre.AutoSize = true;
            this.lblOrdre.Location = new System.Drawing.Point(20, 68);
            this.lblOrdre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOrdre.Name = "lblOrdre";
            this.lblOrdre.Size = new System.Drawing.Size(47, 16);
            this.lblOrdre.TabIndex = 2;
            this.lblOrdre.Text = "Ordre :";
            // 
            // cboArret
            // 
            this.cboArret.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboArret.FormattingEnabled = true;
            this.cboArret.Location = new System.Drawing.Point(80, 27);
            this.cboArret.Margin = new System.Windows.Forms.Padding(4);
            this.cboArret.Name = "cboArret";
            this.cboArret.Size = new System.Drawing.Size(265, 24);
            this.cboArret.TabIndex = 1;
            // 
            // lblArret
            // 
            this.lblArret.AutoSize = true;
            this.lblArret.Location = new System.Drawing.Point(20, 31);
            this.lblArret.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblArret.Name = "lblArret";
            this.lblArret.Size = new System.Drawing.Size(41, 16);
            this.lblArret.TabIndex = 0;
            this.lblArret.Text = "Arrêt :";
            // 
            // flpArrets
            // 
            this.flpArrets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpArrets.AutoScroll = true;
            this.flpArrets.BackColor = System.Drawing.Color.White;
            this.flpArrets.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpArrets.Location = new System.Drawing.Point(8, 7);
            this.flpArrets.Margin = new System.Windows.Forms.Padding(4);
            this.flpArrets.Name = "flpArrets";
            this.flpArrets.Size = new System.Drawing.Size(603, 184);
            this.flpArrets.TabIndex = 0;
            // 
            // btnExporterCsv
            // 
            this.btnExporterCsv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnExporterCsv.FlatAppearance.BorderSize = 0;
            this.btnExporterCsv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExporterCsv.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnExporterCsv.ForeColor = System.Drawing.Color.White;
            this.btnExporterCsv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExporterCsv.Location = new System.Drawing.Point(344, 498);
            this.btnExporterCsv.Margin = new System.Windows.Forms.Padding(4);
            this.btnExporterCsv.Name = "btnExporterCsv";
            this.btnExporterCsv.Size = new System.Drawing.Size(120, 37);
            this.btnExporterCsv.TabIndex = 7;
            this.btnExporterCsv.Text = "Exporter CSV";
            this.btnExporterCsv.Click += new System.EventHandler(this.btnExporterCsv_Click);
            // 
            // btnExporterJson
            // 
            this.btnExporterJson.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnExporterJson.FlatAppearance.BorderSize = 0;
            this.btnExporterJson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExporterJson.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnExporterJson.ForeColor = System.Drawing.Color.White;
            this.btnExporterJson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExporterJson.Location = new System.Drawing.Point(472, 498);
            this.btnExporterJson.Margin = new System.Windows.Forms.Padding(4);
            this.btnExporterJson.Name = "btnExporterJson";
            this.btnExporterJson.Size = new System.Drawing.Size(120, 37);
            this.btnExporterJson.TabIndex = 8;
            this.btnExporterJson.Text = "Exporter JSON";
            this.btnExporterJson.Click += new System.EventHandler(this.btnExporterJson_Click);
            // 
            // UCGestionLignes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabDetails);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.btnNouveau);
            this.Controls.Add(this.flpLignes);
            this.Controls.Add(this.lblTitre);
            this.Controls.Add(this.btnExporterCsv);
            this.Controls.Add(this.btnExporterJson);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UCGestionLignes";
            this.Size = new System.Drawing.Size(1067, 554);
            this.Load += new System.EventHandler(this.UCGestionLignes_Load);
            this.grpDetails.ResumeLayout(false);
            this.grpDetails.PerformLayout();
            this.tabDetails.ResumeLayout(false);
            this.tabInfos.ResumeLayout(false);
            this.tabArrets.ResumeLayout(false);
            this.grpArret.ResumeLayout(false);
            this.grpArret.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTempsTrajet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTempsArret)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOrdre)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
