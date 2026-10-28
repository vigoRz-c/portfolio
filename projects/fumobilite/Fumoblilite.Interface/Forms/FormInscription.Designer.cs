using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fumoblilite.Interface.Forms
{
    public partial class FormInscription
    {
        private Label lblTitre;
        private Label lblNom;
        private Label lblPrenom;
        private Label lblNomUtilisateur;
        private Label lblMotDePasse;
        private Label lblConfirmationMotDePasse;
        private Label lblEmail;
        private TextBox txtNom;
        private TextBox txtPrenom;
        private TextBox txtNomUtilisateur;
        private TextBox txtMotDePasse;
        private TextBox txtConfirmationMotDePasse;
        private TextBox txtEmail;
        private Button btnInscrire;
        private Button btnAnnuler;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInscription));
            this.lblTitre = new System.Windows.Forms.Label();
            this.lblNom = new System.Windows.Forms.Label();
            this.lblPrenom = new System.Windows.Forms.Label();
            this.lblNomUtilisateur = new System.Windows.Forms.Label();
            this.lblMotDePasse = new System.Windows.Forms.Label();
            this.lblConfirmationMotDePasse = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.txtPrenom = new System.Windows.Forms.TextBox();
            this.txtNomUtilisateur = new System.Windows.Forms.TextBox();
            this.txtMotDePasse = new System.Windows.Forms.TextBox();
            this.txtConfirmationMotDePasse = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnInscrire = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitre
            // 
            this.lblTitre.AutoSize = true;
            this.lblTitre.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.lblTitre.Location = new System.Drawing.Point(180, 20);
            this.lblTitre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(138, 32);
            this.lblTitre.TabIndex = 0;
            this.lblTitre.Text = "Inscription";
            this.lblTitre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(50, 70);
            this.lblNom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(47, 16);
            this.lblNom.TabIndex = 1;
            this.lblNom.Text = "Nom :";
            // 
            // lblPrenom
            // 
            this.lblPrenom.AutoSize = true;
            this.lblPrenom.Location = new System.Drawing.Point(50, 105);
            this.lblPrenom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrenom.Name = "lblPrenom";
            this.lblPrenom.Size = new System.Drawing.Size(65, 16);
            this.lblPrenom.TabIndex = 2;
            this.lblPrenom.Text = "Prénom :";
            // 
            // lblNomUtilisateur
            // 
            this.lblNomUtilisateur.AutoSize = true;
            this.lblNomUtilisateur.Location = new System.Drawing.Point(50, 140);
            this.lblNomUtilisateur.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNomUtilisateur.Name = "lblNomUtilisateur";
            this.lblNomUtilisateur.Size = new System.Drawing.Size(117, 16);
            this.lblNomUtilisateur.TabIndex = 3;
            this.lblNomUtilisateur.Text = "Nom d\'utilisateur :";
            // 
            // lblMotDePasse
            // 
            this.lblMotDePasse.AutoSize = true;
            this.lblMotDePasse.Location = new System.Drawing.Point(50, 175);
            this.lblMotDePasse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMotDePasse.Name = "lblMotDePasse";
            this.lblMotDePasse.Size = new System.Drawing.Size(100, 16);
            this.lblMotDePasse.TabIndex = 4;
            this.lblMotDePasse.Text = "Mot de passe :";
            // 
            // lblConfirmationMotDePasse
            // 
            this.lblConfirmationMotDePasse.AutoSize = true;
            this.lblConfirmationMotDePasse.Location = new System.Drawing.Point(50, 210);
            this.lblConfirmationMotDePasse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConfirmationMotDePasse.Name = "lblConfirmationMotDePasse";
            this.lblConfirmationMotDePasse.Size = new System.Drawing.Size(177, 16);
            this.lblConfirmationMotDePasse.TabIndex = 5;
            this.lblConfirmationMotDePasse.Text = "Confirmation mot de passe :";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(50, 245);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(44, 16);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "Email :";
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(250, 70);
            this.txtNom.Margin = new System.Windows.Forms.Padding(4);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(200, 22);
            this.txtNom.TabIndex = 7;
            // 
            // txtPrenom
            // 
            this.txtPrenom.Location = new System.Drawing.Point(250, 105);
            this.txtPrenom.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrenom.Name = "txtPrenom";
            this.txtPrenom.Size = new System.Drawing.Size(200, 22);
            this.txtPrenom.TabIndex = 8;
            // 
            // txtNomUtilisateur
            // 
            this.txtNomUtilisateur.Location = new System.Drawing.Point(250, 140);
            this.txtNomUtilisateur.Margin = new System.Windows.Forms.Padding(4);
            this.txtNomUtilisateur.Name = "txtNomUtilisateur";
            this.txtNomUtilisateur.Size = new System.Drawing.Size(200, 22);
            this.txtNomUtilisateur.TabIndex = 9;
            // 
            // txtMotDePasse
            // 
            this.txtMotDePasse.Location = new System.Drawing.Point(250, 175);
            this.txtMotDePasse.Margin = new System.Windows.Forms.Padding(4);
            this.txtMotDePasse.Name = "txtMotDePasse";
            this.txtMotDePasse.PasswordChar = '*';
            this.txtMotDePasse.Size = new System.Drawing.Size(200, 22);
            this.txtMotDePasse.TabIndex = 10;
            // 
            // txtConfirmationMotDePasse
            // 
            this.txtConfirmationMotDePasse.Location = new System.Drawing.Point(250, 210);
            this.txtConfirmationMotDePasse.Margin = new System.Windows.Forms.Padding(4);
            this.txtConfirmationMotDePasse.Name = "txtConfirmationMotDePasse";
            this.txtConfirmationMotDePasse.PasswordChar = '*';
            this.txtConfirmationMotDePasse.Size = new System.Drawing.Size(200, 22);
            this.txtConfirmationMotDePasse.TabIndex = 11;
            this.txtConfirmationMotDePasse.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConfirmationMotDePasse_KeyPress);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(250, 245);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 22);
            this.txtEmail.TabIndex = 12;
            // 
            // btnInscrire
            // 
            this.btnInscrire.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnInscrire.FlatAppearance.BorderSize = 0;
            this.btnInscrire.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInscrire.ForeColor = System.Drawing.Color.White;
            this.btnInscrire.Location = new System.Drawing.Point(130, 290);
            this.btnInscrire.Margin = new System.Windows.Forms.Padding(4);
            this.btnInscrire.Name = "btnInscrire";
            this.btnInscrire.Size = new System.Drawing.Size(120, 37);
            this.btnInscrire.TabIndex = 13;
            this.btnInscrire.Text = "S\'inscrire";
            this.btnInscrire.UseVisualStyleBackColor = false;
            this.btnInscrire.Click += new System.EventHandler(this.btnInscrire_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnAnnuler.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnuler.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnAnnuler.Location = new System.Drawing.Point(270, 290);
            this.btnAnnuler.Margin = new System.Windows.Forms.Padding(4);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(120, 37);
            this.btnAnnuler.TabIndex = 14;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = false;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // FormInscription
            // 
            this.AcceptButton = this.btnInscrire;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 350);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnInscrire);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtConfirmationMotDePasse);
            this.Controls.Add(this.txtMotDePasse);
            this.Controls.Add(this.txtNomUtilisateur);
            this.Controls.Add(this.txtPrenom);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblConfirmationMotDePasse);
            this.Controls.Add(this.lblMotDePasse);
            this.Controls.Add(this.lblNomUtilisateur);
            this.Controls.Add(this.lblPrenom);
            this.Controls.Add(this.lblNom);
            this.Controls.Add(this.lblTitre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormInscription";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fumobilité | Inscription";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}