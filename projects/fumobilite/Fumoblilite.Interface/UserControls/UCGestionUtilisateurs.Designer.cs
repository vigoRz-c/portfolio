using System.Windows.Forms;
using System.Drawing;

namespace Fumoblilite.Interface.UserControls
{
    partial class UCGestionUtilisateurs
    {
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.FlowLayoutPanel flpUtilisateurs;
        private System.Windows.Forms.GroupBox grpDetails;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.Label lblPrenom;
        private System.Windows.Forms.TextBox txtPrenom;
        private System.Windows.Forms.Label lblNomUtilisateur;
        private System.Windows.Forms.TextBox txtNomUtilisateur;
        private System.Windows.Forms.Label lblMotDePasse;
        private System.Windows.Forms.TextBox txtMotDePasse;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cboRole;
        private System.Windows.Forms.CheckBox chkEstActif;
        private System.Windows.Forms.Button btnNouveau;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.TextBox txtRecherche;
        private System.Windows.Forms.Label lblRecherche;
        private System.Windows.Forms.Button btnExporterCsv;
        private System.Windows.Forms.Button btnExporterJson;


        private void InitializeComponent()
        {
            this.lblTitre = new System.Windows.Forms.Label();
            this.flpUtilisateurs = new System.Windows.Forms.FlowLayoutPanel();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.chkEstActif = new System.Windows.Forms.CheckBox();
            this.cboRole = new System.Windows.Forms.ComboBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtMotDePasse = new System.Windows.Forms.TextBox();
            this.lblMotDePasse = new System.Windows.Forms.Label();
            this.txtNomUtilisateur = new System.Windows.Forms.TextBox();
            this.lblNomUtilisateur = new System.Windows.Forms.Label();
            this.txtPrenom = new System.Windows.Forms.TextBox();
            this.lblPrenom = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.lblNom = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.btnNouveau = new System.Windows.Forms.Button();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.txtRecherche = new System.Windows.Forms.TextBox();
            this.lblRecherche = new System.Windows.Forms.Label();
            this.btnExporterCsv = new System.Windows.Forms.Button();
            this.btnExporterJson = new System.Windows.Forms.Button();
            this.grpDetails.SuspendLayout();
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
            this.lblTitre.Size = new System.Drawing.Size(287, 29);
            this.lblTitre.TabIndex = 0;
            this.lblTitre.Text = "Gestion des utilisateurs";
            // 
            // flpUtilisateurs
            // 
            this.flpUtilisateurs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flpUtilisateurs.AutoScroll = true;
            this.flpUtilisateurs.BackColor = System.Drawing.Color.White;
            this.flpUtilisateurs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpUtilisateurs.Location = new System.Drawing.Point(20, 92);
            this.flpUtilisateurs.Margin = new System.Windows.Forms.Padding(4);
            this.flpUtilisateurs.Name = "flpUtilisateurs";
            this.flpUtilisateurs.Size = new System.Drawing.Size(599, 443);
            this.flpUtilisateurs.TabIndex = 3;
            // 
            // grpDetails
            // 
            this.grpDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDetails.Controls.Add(this.chkEstActif);
            this.grpDetails.Controls.Add(this.cboRole);
            this.grpDetails.Controls.Add(this.lblRole);
            this.grpDetails.Controls.Add(this.txtEmail);
            this.grpDetails.Controls.Add(this.lblEmail);
            this.grpDetails.Controls.Add(this.txtMotDePasse);
            this.grpDetails.Controls.Add(this.lblMotDePasse);
            this.grpDetails.Controls.Add(this.txtNomUtilisateur);
            this.grpDetails.Controls.Add(this.lblNomUtilisateur);
            this.grpDetails.Controls.Add(this.txtPrenom);
            this.grpDetails.Controls.Add(this.lblPrenom);
            this.grpDetails.Controls.Add(this.txtNom);
            this.grpDetails.Controls.Add(this.lblNom);
            this.grpDetails.Controls.Add(this.txtId);
            this.grpDetails.Controls.Add(this.lblId);
            this.grpDetails.Location = new System.Drawing.Point(640, 62);
            this.grpDetails.Margin = new System.Windows.Forms.Padding(4);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Padding = new System.Windows.Forms.Padding(4);
            this.grpDetails.Size = new System.Drawing.Size(407, 369);
            this.grpDetails.TabIndex = 4;
            this.grpDetails.TabStop = false;
            this.grpDetails.Text = "Détails de l\'utilisateur";
            // 
            // chkEstActif
            // 
            this.chkEstActif.AutoSize = true;
            this.chkEstActif.Location = new System.Drawing.Point(160, 295);
            this.chkEstActif.Margin = new System.Windows.Forms.Padding(4);
            this.chkEstActif.Name = "chkEstActif";
            this.chkEstActif.Size = new System.Drawing.Size(75, 20);
            this.chkEstActif.TabIndex = 14;
            this.chkEstActif.Text = "Est actif";
            this.chkEstActif.UseVisualStyleBackColor = true;
            // 
            // cboRole
            // 
            this.cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRole.FormattingEnabled = true;
            this.cboRole.Items.AddRange(new object[] {
            "Admin",
            "Utilisateur"});
            this.cboRole.Location = new System.Drawing.Point(160, 255);
            this.cboRole.Margin = new System.Windows.Forms.Padding(4);
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(212, 24);
            this.cboRole.TabIndex = 13;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(27, 258);
            this.lblRole.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(39, 16);
            this.lblRole.TabIndex = 12;
            this.lblRole.Text = "Rôle:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(160, 218);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(212, 22);
            this.txtEmail.TabIndex = 11;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(27, 222);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(44, 16);
            this.lblEmail.TabIndex = 10;
            this.lblEmail.Text = "Email:";
            // 
            // txtMotDePasse
            // 
            this.txtMotDePasse.Location = new System.Drawing.Point(160, 181);
            this.txtMotDePasse.Margin = new System.Windows.Forms.Padding(4);
            this.txtMotDePasse.Name = "txtMotDePasse";
            this.txtMotDePasse.PasswordChar = '*';
            this.txtMotDePasse.Size = new System.Drawing.Size(212, 22);
            this.txtMotDePasse.TabIndex = 9;
            // 
            // lblMotDePasse
            // 
            this.lblMotDePasse.AutoSize = true;
            this.lblMotDePasse.Location = new System.Drawing.Point(27, 185);
            this.lblMotDePasse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMotDePasse.Name = "lblMotDePasse";
            this.lblMotDePasse.Size = new System.Drawing.Size(92, 16);
            this.lblMotDePasse.TabIndex = 8;
            this.lblMotDePasse.Text = "Mot de passe:";
            // 
            // txtNomUtilisateur
            // 
            this.txtNomUtilisateur.Location = new System.Drawing.Point(160, 144);
            this.txtNomUtilisateur.Margin = new System.Windows.Forms.Padding(4);
            this.txtNomUtilisateur.Name = "txtNomUtilisateur";
            this.txtNomUtilisateur.Size = new System.Drawing.Size(212, 22);
            this.txtNomUtilisateur.TabIndex = 7;
            // 
            // lblNomUtilisateur
            // 
            this.lblNomUtilisateur.AutoSize = true;
            this.lblNomUtilisateur.Location = new System.Drawing.Point(27, 148);
            this.lblNomUtilisateur.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNomUtilisateur.Name = "lblNomUtilisateur";
            this.lblNomUtilisateur.Size = new System.Drawing.Size(98, 16);
            this.lblNomUtilisateur.TabIndex = 6;
            this.lblNomUtilisateur.Text = "Nom utilisateur:";
            // 
            // txtPrenom
            // 
            this.txtPrenom.Location = new System.Drawing.Point(160, 107);
            this.txtPrenom.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrenom.Name = "txtPrenom";
            this.txtPrenom.Size = new System.Drawing.Size(212, 22);
            this.txtPrenom.TabIndex = 5;
            // 
            // lblPrenom
            // 
            this.lblPrenom.AutoSize = true;
            this.lblPrenom.Location = new System.Drawing.Point(27, 111);
            this.lblPrenom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrenom.Name = "lblPrenom";
            this.lblPrenom.Size = new System.Drawing.Size(57, 16);
            this.lblPrenom.TabIndex = 4;
            this.lblPrenom.Text = "Prénom:";
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(160, 70);
            this.txtNom.Margin = new System.Windows.Forms.Padding(4);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(212, 22);
            this.txtNom.TabIndex = 3;
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(27, 74);
            this.lblNom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(39, 16);
            this.lblNom.TabIndex = 2;
            this.lblNom.Text = "Nom:";
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
            this.btnNouveau.Location = new System.Drawing.Point(640, 443);
            this.btnNouveau.Margin = new System.Windows.Forms.Padding(4);
            this.btnNouveau.Name = "btnNouveau";
            this.btnNouveau.Size = new System.Drawing.Size(120, 37);
            this.btnNouveau.TabIndex = 5;
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
            this.btnEnregistrer.Location = new System.Drawing.Point(773, 443);
            this.btnEnregistrer.Margin = new System.Windows.Forms.Padding(4);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(120, 37);
            this.btnEnregistrer.TabIndex = 6;
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
            this.btnSupprimer.Location = new System.Drawing.Point(907, 443);
            this.btnSupprimer.Margin = new System.Windows.Forms.Padding(4);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(120, 37);
            this.btnSupprimer.TabIndex = 7;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = false;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // txtRecherche
            // 
            this.txtRecherche.Location = new System.Drawing.Point(123, 58);
            this.txtRecherche.Margin = new System.Windows.Forms.Padding(4);
            this.txtRecherche.Name = "txtRecherche";
            this.txtRecherche.Size = new System.Drawing.Size(265, 22);
            this.txtRecherche.TabIndex = 2;
            this.txtRecherche.TextChanged += new System.EventHandler(this.txtRecherche_TextChanged);
            // 
            // lblRecherche
            // 
            this.lblRecherche.AutoSize = true;
            this.lblRecherche.Location = new System.Drawing.Point(23, 62);
            this.lblRecherche.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRecherche.Name = "lblRecherche";
            this.lblRecherche.Size = new System.Drawing.Size(83, 16);
            this.lblRecherche.TabIndex = 1;
            this.lblRecherche.Text = "Rechercher :";
            // 
            // btnExporterCsv
            // 
            this.btnExporterCsv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnExporterCsv.FlatAppearance.BorderSize = 0;
            this.btnExporterCsv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExporterCsv.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnExporterCsv.ForeColor = System.Drawing.Color.White;
            this.btnExporterCsv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExporterCsv.Location = new System.Drawing.Point(907, 498);
            this.btnExporterCsv.Margin = new System.Windows.Forms.Padding(4);
            this.btnExporterCsv.Name = "btnExporterCsv";
            this.btnExporterCsv.Size = new System.Drawing.Size(120, 37);
            this.btnExporterCsv.TabIndex = 8;
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
            this.btnExporterJson.Location = new System.Drawing.Point(773, 498);
            this.btnExporterJson.Margin = new System.Windows.Forms.Padding(4);
            this.btnExporterJson.Name = "btnExporterJson";
            this.btnExporterJson.Size = new System.Drawing.Size(120, 37);
            this.btnExporterJson.TabIndex = 9;
            this.btnExporterJson.Text = "Exporter JSON";
            this.btnExporterJson.Click += new System.EventHandler(this.btnExporterJson_Click);
            // 
            // UCGestionUtilisateurs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.btnNouveau);
            this.Controls.Add(this.grpDetails);
            this.Controls.Add(this.flpUtilisateurs);
            this.Controls.Add(this.txtRecherche);
            this.Controls.Add(this.lblRecherche);
            this.Controls.Add(this.lblTitre);
            this.Controls.Add(this.btnExporterCsv);
            this.Controls.Add(this.btnExporterJson);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UCGestionUtilisateurs";
            this.Size = new System.Drawing.Size(1067, 554);
            this.Load += new System.EventHandler(this.UCGestionUtilisateurs_Load);
            this.grpDetails.ResumeLayout(false);
            this.grpDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
