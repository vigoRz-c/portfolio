using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fumoblilite.Interface.Forms
{
    public partial class FormConnexion
    {
        private Label lblTitre;
        private Label lblNomUtilisateur;
        private Label lblMotDePasse;
        private TextBox txtNomUtilisateur;
        private TextBox txtMotDePasse;
        private Button btnConnexion;
        private Button btnRetour;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConnexion));
            this.lblTitre = new System.Windows.Forms.Label();
            this.lblNomUtilisateur = new System.Windows.Forms.Label();
            this.lblMotDePasse = new System.Windows.Forms.Label();
            this.txtNomUtilisateur = new System.Windows.Forms.TextBox();
            this.txtMotDePasse = new System.Windows.Forms.TextBox();
            this.btnConnexion = new System.Windows.Forms.Button();
            this.btnRetour = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitre
            // 
            this.lblTitre.AutoSize = true;
            this.lblTitre.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.lblTitre.Location = new System.Drawing.Point(67, 37);
            this.lblTitre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(400, 32);
            this.lblTitre.TabIndex = 0;
            this.lblTitre.Text = "Gestion de Transport en Commun";
            this.lblTitre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNomUtilisateur
            // 
            this.lblNomUtilisateur.AutoSize = true;
            this.lblNomUtilisateur.Location = new System.Drawing.Point(67, 98);
            this.lblNomUtilisateur.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNomUtilisateur.Name = "lblNomUtilisateur";
            this.lblNomUtilisateur.Size = new System.Drawing.Size(109, 16);
            this.lblNomUtilisateur.TabIndex = 1;
            this.lblNomUtilisateur.Text = "Nom d\'utilisateur:";
            // 
            // lblMotDePasse
            // 
            this.lblMotDePasse.AutoSize = true;
            this.lblMotDePasse.Location = new System.Drawing.Point(67, 148);
            this.lblMotDePasse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMotDePasse.Name = "lblMotDePasse";
            this.lblMotDePasse.Size = new System.Drawing.Size(92, 16);
            this.lblMotDePasse.TabIndex = 2;
            this.lblMotDePasse.Text = "Mot de passe:";
            // 
            // txtNomUtilisateur
            // 
            this.txtNomUtilisateur.Location = new System.Drawing.Point(200, 98);
            this.txtNomUtilisateur.Margin = new System.Windows.Forms.Padding(4);
            this.txtNomUtilisateur.Name = "txtNomUtilisateur";
            this.txtNomUtilisateur.Size = new System.Drawing.Size(265, 22);
            this.txtNomUtilisateur.TabIndex = 3;
            // 
            // txtMotDePasse
            // 
            this.txtMotDePasse.Location = new System.Drawing.Point(200, 148);
            this.txtMotDePasse.Margin = new System.Windows.Forms.Padding(4);
            this.txtMotDePasse.Name = "txtMotDePasse";
            this.txtMotDePasse.PasswordChar = '*';
            this.txtMotDePasse.Size = new System.Drawing.Size(265, 22);
            this.txtMotDePasse.TabIndex = 4;
            // 
            // btnConnexion
            // 
            this.btnConnexion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnConnexion.FlatAppearance.BorderSize = 0;
            this.btnConnexion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnexion.ForeColor = System.Drawing.Color.White;
            this.btnConnexion.Location = new System.Drawing.Point(129, 197);
            this.btnConnexion.Margin = new System.Windows.Forms.Padding(4);
            this.btnConnexion.Name = "btnConnexion";
            this.btnConnexion.Size = new System.Drawing.Size(120, 37);
            this.btnConnexion.TabIndex = 5;
            this.btnConnexion.Text = "Connexion";
            this.btnConnexion.UseVisualStyleBackColor = false;
            this.btnConnexion.Click += new System.EventHandler(this.btnConnexion_Click);
            // 
            // btnRetour
            // 
            this.btnRetour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnRetour.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnRetour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetour.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnRetour.Location = new System.Drawing.Point(271, 197);
            this.btnRetour.Margin = new System.Windows.Forms.Padding(4);
            this.btnRetour.Name = "btnRetour";
            this.btnRetour.Size = new System.Drawing.Size(120, 37);
            this.btnRetour.TabIndex = 6;
            this.btnRetour.Text = "Retour";
            this.btnRetour.UseVisualStyleBackColor = false;
            this.btnRetour.Click += new System.EventHandler(this.btnRetour_Click);
            // 
            // FormConnexion
            // 
            this.AcceptButton = this.btnConnexion;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 276);
            this.Controls.Add(this.btnRetour);
            this.Controls.Add(this.btnConnexion);
            this.Controls.Add(this.txtMotDePasse);
            this.Controls.Add(this.txtNomUtilisateur);
            this.Controls.Add(this.lblMotDePasse);
            this.Controls.Add(this.lblNomUtilisateur);
            this.Controls.Add(this.lblTitre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConnexion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fumobilité | Connexion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
