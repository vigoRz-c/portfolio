using System.Windows.Forms;
using System.Drawing;

namespace Fumoblilite.Interface.UserControls
{
    partial class UCRechercheItineraire
    {
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.GroupBox grpRecherche;
        private System.Windows.Forms.Label lblArretDepart;
        private System.Windows.Forms.ComboBox cboArretDepart;
        private System.Windows.Forms.Label lblArretArrivee;
        private System.Windows.Forms.ComboBox cboArretArrivee;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblHeure;
        private System.Windows.Forms.DateTimePicker dtpHeure;
        private System.Windows.Forms.RadioButton rbDepart;
        private System.Windows.Forms.RadioButton rbArrivee;
        private System.Windows.Forms.Button btnRechercher;
        private System.Windows.Forms.FlowLayoutPanel flpItineraires;
        private System.Windows.Forms.Panel pnlDetailsItineraire;

        private void InitializeComponent()
        {
            this.lblTitre = new System.Windows.Forms.Label();
            this.grpRecherche = new System.Windows.Forms.GroupBox();
            this.lblArretDepart = new System.Windows.Forms.Label();
            this.cboArretDepart = new System.Windows.Forms.ComboBox();
            this.lblArretArrivee = new System.Windows.Forms.Label();
            this.cboArretArrivee = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblHeure = new System.Windows.Forms.Label();
            this.dtpHeure = new System.Windows.Forms.DateTimePicker();
            this.rbDepart = new System.Windows.Forms.RadioButton();
            this.rbArrivee = new System.Windows.Forms.RadioButton();
            this.btnRechercher = new System.Windows.Forms.Button();
            this.flpItineraires = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlDetailsItineraire = new System.Windows.Forms.Panel();
            this.grpRecherche.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitre
            // 
            this.lblTitre.AutoSize = true;
            this.lblTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitre.Location = new System.Drawing.Point(15, 15);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(196, 24);
            this.lblTitre.TabIndex = 0;
            this.lblTitre.Text = "Recherche d\'itinéraire";
            this.lblTitre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            // 
            // grpRecherche
            // 
            this.grpRecherche.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRecherche.Controls.Add(this.btnRechercher);
            this.grpRecherche.Controls.Add(this.rbArrivee);
            this.grpRecherche.Controls.Add(this.rbDepart);
            this.grpRecherche.Controls.Add(this.dtpHeure);
            this.grpRecherche.Controls.Add(this.lblHeure);
            this.grpRecherche.Controls.Add(this.dtpDate);
            this.grpRecherche.Controls.Add(this.lblDate);
            this.grpRecherche.Controls.Add(this.cboArretArrivee);
            this.grpRecherche.Controls.Add(this.lblArretArrivee);
            this.grpRecherche.Controls.Add(this.cboArretDepart);
            this.grpRecherche.Controls.Add(this.lblArretDepart);
            this.grpRecherche.Location = new System.Drawing.Point(15, 50);
            this.grpRecherche.Name = "grpRecherche";
            this.grpRecherche.Size = new System.Drawing.Size(770, 150);
            this.grpRecherche.TabIndex = 1;
            this.grpRecherche.TabStop = false;
            this.grpRecherche.Text = "Critères de recherche";
            // 
            // lblArretDepart
            // 
            this.lblArretDepart.AutoSize = true;
            this.lblArretDepart.Location = new System.Drawing.Point(20, 30);
            this.lblArretDepart.Name = "lblArretDepart";
            this.lblArretDepart.Size = new System.Drawing.Size(83, 13);
            this.lblArretDepart.TabIndex = 0;
            this.lblArretDepart.Text = "Arrêt de départ :";
            // 
            // cboArretDepart
            // 
            this.cboArretDepart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboArretDepart.FormattingEnabled = true;
            this.cboArretDepart.Location = new System.Drawing.Point(120, 27);
            this.cboArretDepart.Name = "cboArretDepart";
            this.cboArretDepart.Size = new System.Drawing.Size(250, 21);
            this.cboArretDepart.TabIndex = 1;
            // 
            // lblArretArrivee
            // 
            this.lblArretArrivee.AutoSize = true;
            this.lblArretArrivee.Location = new System.Drawing.Point(20, 60);
            this.lblArretArrivee.Name = "lblArretArrivee";
            this.lblArretArrivee.Size = new System.Drawing.Size(82, 13);
            this.lblArretArrivee.TabIndex = 2;
            this.lblArretArrivee.Text = "Arrêt d\'arrivée :";
            // 
            // cboArretArrivee
            // 
            this.cboArretArrivee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboArretArrivee.FormattingEnabled = true;
            this.cboArretArrivee.Location = new System.Drawing.Point(120, 57);
            this.cboArretArrivee.Name = "cboArretArrivee";
            this.cboArretArrivee.Size = new System.Drawing.Size(250, 21);
            this.cboArretArrivee.TabIndex = 3;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(400, 30);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(36, 13);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "Date :";
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(450, 27);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(120, 20);
            this.dtpDate.TabIndex = 5;
            // 
            // lblHeure
            // 
            this.lblHeure.AutoSize = true;
            this.lblHeure.Location = new System.Drawing.Point(400, 60);
            this.lblHeure.Name = "lblHeure";
            this.lblHeure.Size = new System.Drawing.Size(42, 13);
            this.lblHeure.TabIndex = 6;
            this.lblHeure.Text = "Heure :";
            // 
            // dtpHeure
            // 
            this.dtpHeure.CustomFormat = "HH:mm";
            this.dtpHeure.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHeure.Location = new System.Drawing.Point(450, 57);
            this.dtpHeure.Name = "dtpHeure";
            this.dtpHeure.ShowUpDown = true;
            this.dtpHeure.Size = new System.Drawing.Size(120, 20);
            this.dtpHeure.TabIndex = 7;
            // 
            // rbDepart
            // 
            this.rbDepart.AutoSize = true;
            this.rbDepart.Checked = true;
            this.rbDepart.Location = new System.Drawing.Point(120, 90);
            this.rbDepart.Name = "rbDepart";
            this.rbDepart.Size = new System.Drawing.Size(102, 17);
            this.rbDepart.TabIndex = 8;
            this.rbDepart.TabStop = true;
            this.rbDepart.Text = "Heure de départ";
            this.rbDepart.UseVisualStyleBackColor = true;
            // 
            // rbArrivee
            // 
            this.rbArrivee.AutoSize = true;
            this.rbArrivee.Location = new System.Drawing.Point(250, 90);
            this.rbArrivee.Name = "rbArrivee";
            this.rbArrivee.Size = new System.Drawing.Size(101, 17);
            this.rbArrivee.TabIndex = 9;
            this.rbArrivee.Text = "Heure d\'arrivée";
            this.rbArrivee.UseVisualStyleBackColor = true;
            // 
            // btnRechercher
            // 
            this.btnRechercher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnRechercher.FlatAppearance.BorderSize = 0;
            this.btnRechercher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRechercher.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRechercher.ForeColor = System.Drawing.Color.White;
            this.btnRechercher.Location = new System.Drawing.Point(450, 90);
            this.btnRechercher.Name = "btnRechercher";
            this.btnRechercher.Size = new System.Drawing.Size(120, 30);
            this.btnRechercher.TabIndex = 10;
            this.btnRechercher.Text = "Rechercher";
            this.btnRechercher.UseVisualStyleBackColor = false;
            this.btnRechercher.Click += new System.EventHandler(this.btnRechercher_Click);
            // 
            // flpItineraires
            // 
            this.flpItineraires.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpItineraires.AutoScroll = true;
            this.flpItineraires.BackColor = System.Drawing.Color.White;
            this.flpItineraires.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpItineraires.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpItineraires.Location = new System.Drawing.Point(15, 210);
            this.flpItineraires.Name = "flpItineraires";
            this.flpItineraires.Size = new System.Drawing.Size(400, 225);
            this.flpItineraires.TabIndex = 2;
            this.flpItineraires.WrapContents = false;
            // 
            // pnlDetailsItineraire
            // 
            this.pnlDetailsItineraire.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDetailsItineraire.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetailsItineraire.Location = new System.Drawing.Point(430, 210);
            this.pnlDetailsItineraire.Name = "pnlDetailsItineraire";
            this.pnlDetailsItineraire.Size = new System.Drawing.Size(355, 225);
            this.pnlDetailsItineraire.TabIndex = 3;
            // 
            // UCRechercheItineraire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlDetailsItineraire);
            this.Controls.Add(this.flpItineraires);
            this.Controls.Add(this.grpRecherche);
            this.Controls.Add(this.lblTitre);
            this.Name = "UCRechercheItineraire";
            this.Size = new System.Drawing.Size(800, 450);
            this.Load += new System.EventHandler(this.UCRechercheItineraire_Load);
            this.grpRecherche.ResumeLayout(false);
            this.grpRecherche.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
