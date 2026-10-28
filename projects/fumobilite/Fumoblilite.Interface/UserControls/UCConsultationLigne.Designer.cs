namespace Fumoblilite.Interface.UserControls
{
    partial class UCConsultationLigne
    {
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Label lblLigne;
        private System.Windows.Forms.ComboBox cboLigne;
        private System.Windows.Forms.Button btnAfficher;
        private System.Windows.Forms.TabControl tabDetails;
        private System.Windows.Forms.TabPage tabArrets;
        private System.Windows.Forms.TabPage tabHoraires;
        private System.Windows.Forms.Label lblJour;
        private System.Windows.Forms.ComboBox cboJour;
        private System.Windows.Forms.FlowLayoutPanel flpArrets;
        private System.Windows.Forms.FlowLayoutPanel flpHoraires;
        private System.Windows.Forms.Panel pnlHeaderArrets;
        private System.Windows.Forms.Label lblOrdre;
        private System.Windows.Forms.Label lblNomArret;
        private System.Windows.Forms.Label lblAdresse;
        private System.Windows.Forms.Label lblTempsArret;
        private System.Windows.Forms.Label lblTempsTrajet;
        private System.Windows.Forms.Label lblAccessible;
        private System.Windows.Forms.Panel pnlHeaderHoraires;
        private System.Windows.Forms.Label lblArret;
        private System.Windows.Forms.Label lblHeure;
        private System.Windows.Forms.Label lblActif;

        private void InitializeComponent()
        {
            this.lblTitre = new System.Windows.Forms.Label();
            this.lblLigne = new System.Windows.Forms.Label();
            this.cboLigne = new System.Windows.Forms.ComboBox();
            this.btnAfficher = new System.Windows.Forms.Button();
            this.tabDetails = new System.Windows.Forms.TabControl();
            this.tabArrets = new System.Windows.Forms.TabPage();
            this.flpArrets = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlHeaderArrets = new System.Windows.Forms.Panel();
            this.lblAccessible = new System.Windows.Forms.Label();
            this.lblTempsTrajet = new System.Windows.Forms.Label();
            this.lblTempsArret = new System.Windows.Forms.Label();
            this.lblAdresse = new System.Windows.Forms.Label();
            this.lblNomArret = new System.Windows.Forms.Label();
            this.lblOrdre = new System.Windows.Forms.Label();
            this.tabHoraires = new System.Windows.Forms.TabPage();
            this.flpHoraires = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlHeaderHoraires = new System.Windows.Forms.Panel();
            this.lblActif = new System.Windows.Forms.Label();
            this.lblHeure = new System.Windows.Forms.Label();
            this.lblArret = new System.Windows.Forms.Label();
            this.cboJour = new System.Windows.Forms.ComboBox();
            this.lblJour = new System.Windows.Forms.Label();
            this.tabDetails.SuspendLayout();
            this.tabArrets.SuspendLayout();
            this.pnlHeaderArrets.SuspendLayout();
            this.tabHoraires.SuspendLayout();
            this.pnlHeaderHoraires.SuspendLayout();
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
            this.lblTitre.Size = new System.Drawing.Size(252, 32);
            this.lblTitre.TabIndex = 0;
            this.lblTitre.Text = "Détails d\'une ligne";
            // 
            // lblLigne
            // 
            this.lblLigne.AutoSize = true;
            this.lblLigne.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLigne.Location = new System.Drawing.Point(20, 68);
            this.lblLigne.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLigne.Name = "lblLigne";
            this.lblLigne.Size = new System.Drawing.Size(52, 20);
            this.lblLigne.TabIndex = 1;
            this.lblLigne.Text = "Ligne :";
            // 
            // cboLigne
            // 
            this.cboLigne.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLigne.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboLigne.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLigne.FormattingEnabled = true;
            this.cboLigne.Location = new System.Drawing.Point(80, 64);
            this.cboLigne.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboLigne.Name = "cboLigne";
            this.cboLigne.Size = new System.Drawing.Size(332, 28);
            this.cboLigne.TabIndex = 2;
            // 
            // btnAfficher
            // 
            this.btnAfficher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnAfficher.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAfficher.FlatAppearance.BorderSize = 0;
            this.btnAfficher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAfficher.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAfficher.ForeColor = System.Drawing.Color.White;
            this.btnAfficher.Location = new System.Drawing.Point(427, 62);
            this.btnAfficher.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAfficher.Name = "btnAfficher";
            this.btnAfficher.Size = new System.Drawing.Size(133, 34);
            this.btnAfficher.TabIndex = 3;
            this.btnAfficher.Text = "Afficher";
            this.btnAfficher.UseVisualStyleBackColor = false;
            this.btnAfficher.Click += new System.EventHandler(this.btnAfficher_Click);
            // 
            // tabDetails
            // 
            this.tabDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabDetails.Controls.Add(this.tabArrets);
            this.tabDetails.Controls.Add(this.tabHoraires);
            this.tabDetails.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabDetails.Location = new System.Drawing.Point(20, 111);
            this.tabDetails.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabDetails.Name = "tabDetails";
            this.tabDetails.SelectedIndex = 0;
            this.tabDetails.Size = new System.Drawing.Size(1027, 425);
            this.tabDetails.TabIndex = 4;
            // 
            // tabArrets
            // 
            this.tabArrets.Controls.Add(this.flpArrets);
            this.tabArrets.Controls.Add(this.pnlHeaderArrets);
            this.tabArrets.Location = new System.Drawing.Point(4, 29);
            this.tabArrets.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabArrets.Name = "tabArrets";
            this.tabArrets.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabArrets.Size = new System.Drawing.Size(1019, 392);
            this.tabArrets.TabIndex = 0;
            this.tabArrets.Text = "Arrêts";
            this.tabArrets.UseVisualStyleBackColor = true;
            // 
            // flpArrets
            // 
            this.flpArrets.AutoScroll = true;
            this.flpArrets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpArrets.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpArrets.Location = new System.Drawing.Point(4, 53);
            this.flpArrets.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flpArrets.Name = "flpArrets";
            this.flpArrets.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.flpArrets.Size = new System.Drawing.Size(1011, 335);
            this.flpArrets.TabIndex = 1;
            this.flpArrets.WrapContents = false;
            // 
            // pnlHeaderArrets
            // 
            this.pnlHeaderArrets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.pnlHeaderArrets.Controls.Add(this.lblAccessible);
            this.pnlHeaderArrets.Controls.Add(this.lblTempsTrajet);
            this.pnlHeaderArrets.Controls.Add(this.lblTempsArret);
            this.pnlHeaderArrets.Controls.Add(this.lblAdresse);
            this.pnlHeaderArrets.Controls.Add(this.lblNomArret);
            this.pnlHeaderArrets.Controls.Add(this.lblOrdre);
            this.pnlHeaderArrets.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderArrets.Location = new System.Drawing.Point(4, 4);
            this.pnlHeaderArrets.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlHeaderArrets.Name = "pnlHeaderArrets";
            this.pnlHeaderArrets.Size = new System.Drawing.Size(1011, 49);
            this.pnlHeaderArrets.TabIndex = 0;
            // 
            // lblAccessible
            // 
            this.lblAccessible.AutoSize = true;
            this.lblAccessible.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccessible.ForeColor = System.Drawing.Color.White;
            this.lblAccessible.Location = new System.Drawing.Point(867, 16);
            this.lblAccessible.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAccessible.Name = "lblAccessible";
            this.lblAccessible.Size = new System.Drawing.Size(81, 20);
            this.lblAccessible.TabIndex = 5;
            this.lblAccessible.Text = "Accessible";
            // 
            // lblTempsTrajet
            // 
            this.lblTempsTrajet.AutoSize = true;
            this.lblTempsTrajet.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTempsTrajet.ForeColor = System.Drawing.Color.White;
            this.lblTempsTrajet.Location = new System.Drawing.Point(693, 16);
            this.lblTempsTrajet.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTempsTrajet.Name = "lblTempsTrajet";
            this.lblTempsTrajet.Size = new System.Drawing.Size(97, 20);
            this.lblTempsTrajet.TabIndex = 4;
            this.lblTempsTrajet.Text = "Temps trajet";
            // 
            // lblTempsArret
            // 
            this.lblTempsArret.AutoSize = true;
            this.lblTempsArret.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTempsArret.ForeColor = System.Drawing.Color.White;
            this.lblTempsArret.Location = new System.Drawing.Point(533, 16);
            this.lblTempsArret.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTempsArret.Name = "lblTempsArret";
            this.lblTempsArret.Size = new System.Drawing.Size(106, 20);
            this.lblTempsArret.TabIndex = 3;
            this.lblTempsArret.Text = "Temps d\'arrêt";
            // 
            // lblAdresse
            // 
            this.lblAdresse.AutoSize = true;
            this.lblAdresse.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdresse.ForeColor = System.Drawing.Color.White;
            this.lblAdresse.Location = new System.Drawing.Point(267, 16);
            this.lblAdresse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAdresse.Name = "lblAdresse";
            this.lblAdresse.Size = new System.Drawing.Size(65, 20);
            this.lblAdresse.TabIndex = 2;
            this.lblAdresse.Text = "Adresse";
            // 
            // lblNomArret
            // 
            this.lblNomArret.AutoSize = true;
            this.lblNomArret.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomArret.ForeColor = System.Drawing.Color.White;
            this.lblNomArret.Location = new System.Drawing.Point(93, 16);
            this.lblNomArret.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNomArret.Name = "lblNomArret";
            this.lblNomArret.Size = new System.Drawing.Size(44, 20);
            this.lblNomArret.TabIndex = 1;
            this.lblNomArret.Text = "Nom";
            // 
            // lblOrdre
            // 
            this.lblOrdre.AutoSize = true;
            this.lblOrdre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrdre.ForeColor = System.Drawing.Color.White;
            this.lblOrdre.Location = new System.Drawing.Point(20, 16);
            this.lblOrdre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOrdre.Name = "lblOrdre";
            this.lblOrdre.Size = new System.Drawing.Size(49, 20);
            this.lblOrdre.TabIndex = 0;
            this.lblOrdre.Text = "Ordre";
            // 
            // tabHoraires
            // 
            this.tabHoraires.Controls.Add(this.flpHoraires);
            this.tabHoraires.Controls.Add(this.pnlHeaderHoraires);
            this.tabHoraires.Controls.Add(this.cboJour);
            this.tabHoraires.Controls.Add(this.lblJour);
            this.tabHoraires.Location = new System.Drawing.Point(4, 29);
            this.tabHoraires.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabHoraires.Name = "tabHoraires";
            this.tabHoraires.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabHoraires.Size = new System.Drawing.Size(1019, 392);
            this.tabHoraires.TabIndex = 1;
            this.tabHoraires.Text = "Horaires";
            this.tabHoraires.UseVisualStyleBackColor = true;
            // 
            // flpHoraires
            // 
            this.flpHoraires.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpHoraires.AutoScroll = true;
            this.flpHoraires.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpHoraires.Location = new System.Drawing.Point(8, 102);
            this.flpHoraires.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flpHoraires.Name = "flpHoraires";
            this.flpHoraires.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.flpHoraires.Size = new System.Drawing.Size(1000, 281);
            this.flpHoraires.TabIndex = 3;
            this.flpHoraires.WrapContents = false;
            // 
            // pnlHeaderHoraires
            // 
            this.pnlHeaderHoraires.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHeaderHoraires.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.pnlHeaderHoraires.Controls.Add(this.lblActif);
            this.pnlHeaderHoraires.Controls.Add(this.lblHeure);
            this.pnlHeaderHoraires.Controls.Add(this.lblArret);
            this.pnlHeaderHoraires.Location = new System.Drawing.Point(8, 53);
            this.pnlHeaderHoraires.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlHeaderHoraires.Name = "pnlHeaderHoraires";
            this.pnlHeaderHoraires.Size = new System.Drawing.Size(1000, 49);
            this.pnlHeaderHoraires.TabIndex = 2;
            // 
            // lblActif
            // 
            this.lblActif.AutoSize = true;
            this.lblActif.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActif.ForeColor = System.Drawing.Color.White;
            this.lblActif.Location = new System.Drawing.Point(867, 16);
            this.lblActif.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblActif.Name = "lblActif";
            this.lblActif.Size = new System.Drawing.Size(43, 20);
            this.lblActif.TabIndex = 2;
            this.lblActif.Text = "Actif";
            // 
            // lblHeure
            // 
            this.lblHeure.AutoSize = true;
            this.lblHeure.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeure.ForeColor = System.Drawing.Color.White;
            this.lblHeure.Location = new System.Drawing.Point(267, 16);
            this.lblHeure.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeure.Name = "lblHeure";
            this.lblHeure.Size = new System.Drawing.Size(51, 20);
            this.lblHeure.TabIndex = 1;
            this.lblHeure.Text = "Heure";
            // 
            // lblArret
            // 
            this.lblArret.AutoSize = true;
            this.lblArret.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArret.ForeColor = System.Drawing.Color.White;
            this.lblArret.Location = new System.Drawing.Point(20, 16);
            this.lblArret.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblArret.Name = "lblArret";
            this.lblArret.Size = new System.Drawing.Size(46, 20);
            this.lblArret.TabIndex = 0;
            this.lblArret.Text = "Arrêt";
            // 
            // cboJour
            // 
            this.cboJour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboJour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboJour.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboJour.FormattingEnabled = true;
            this.cboJour.Location = new System.Drawing.Point(67, 15);
            this.cboJour.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboJour.Name = "cboJour";
            this.cboJour.Size = new System.Drawing.Size(265, 28);
            this.cboJour.TabIndex = 1;
            this.cboJour.SelectedIndexChanged += new System.EventHandler(this.cboJour_SelectedIndexChanged);
            // 
            // lblJour
            // 
            this.lblJour.AutoSize = true;
            this.lblJour.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJour.Location = new System.Drawing.Point(13, 18);
            this.lblJour.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblJour.Name = "lblJour";
            this.lblJour.Size = new System.Drawing.Size(43, 20);
            this.lblJour.TabIndex = 0;
            this.lblJour.Text = "Jour :";
            // 
            // UCConsultationLigne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabDetails);
            this.Controls.Add(this.btnAfficher);
            this.Controls.Add(this.cboLigne);
            this.Controls.Add(this.lblLigne);
            this.Controls.Add(this.lblTitre);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UCConsultationLigne";
            this.Size = new System.Drawing.Size(1067, 554);
            this.Load += new System.EventHandler(this.UCConsultationLigne_Load);
            this.tabDetails.ResumeLayout(false);
            this.tabArrets.ResumeLayout(false);
            this.pnlHeaderArrets.ResumeLayout(false);
            this.pnlHeaderArrets.PerformLayout();
            this.tabHoraires.ResumeLayout(false);
            this.tabHoraires.PerformLayout();
            this.pnlHeaderHoraires.ResumeLayout(false);
            this.pnlHeaderHoraires.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
