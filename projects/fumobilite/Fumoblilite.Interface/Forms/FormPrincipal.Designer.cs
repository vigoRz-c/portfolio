using System.Windows.Forms;

namespace Fumoblilite.Interface.Forms
{
    partial class FormPrincipal
    {
        private MenuStrip menuStrip;
        private ToolStripMenuItem menuFichier, menuItemDeconnexion, menuItemQuitter;
        private ToolStripMenuItem menuGestion, menuItemArrets, menuItemLignes, menuItemHoraires, menuItemUtilisateurs;
        private ToolStripMenuItem menuConsultation, menuItemReseau, menuItemLigneDetails, menuItemHorairesJournee;
        private ToolStripMenuItem menuRecherche, menuItemItineraire;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblStatusUtilisateur;
        private Panel panelContenu;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuFichier = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemConnexion = new System.Windows.Forms.ToolStripMenuItem();
            this.sinscrireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDeconnexion = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemQuitter = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGestion = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemArrets = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLignes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHoraires = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemUtilisateurs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConsultation = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemReseau = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLigneDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHorairesJournee = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRecherche = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemItineraire = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatusUtilisateur = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelContenu = new System.Windows.Forms.Panel();
            this.lblGroupe = new System.Windows.Forms.Label();
            this.terminalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.menuStrip.ForeColor = System.Drawing.Color.White;
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFichier,
            this.menuGestion,
            this.menuConsultation,
            this.menuRecherche});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(567, 30);
            this.menuStrip.TabIndex = 2;
            // 
            // menuFichier
            // 
            this.menuFichier.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemConnexion,
            this.sinscrireToolStripMenuItem,
            this.menuItemDeconnexion,
            this.terminalToolStripMenuItem,
            this.menuItemQuitter});
            this.menuFichier.ForeColor = System.Drawing.Color.White;
            this.menuFichier.Name = "menuFichier";
            this.menuFichier.Size = new System.Drawing.Size(72, 26);
            this.menuFichier.Text = "Session";
            // 
            // menuItemConnexion
            // 
            this.menuItemConnexion.Name = "menuItemConnexion";
            this.menuItemConnexion.Size = new System.Drawing.Size(224, 26);
            this.menuItemConnexion.Text = "Connexion";
            this.menuItemConnexion.Click += new System.EventHandler(this.menuItemConnexion_Click);
            // 
            // sinscrireToolStripMenuItem
            // 
            this.sinscrireToolStripMenuItem.Name = "sinscrireToolStripMenuItem";
            this.sinscrireToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.sinscrireToolStripMenuItem.Text = "S\'inscrire";
            this.sinscrireToolStripMenuItem.Click += new System.EventHandler(this.sinscrireToolStripMenuItem_Click);
            // 
            // menuItemDeconnexion
            // 
            this.menuItemDeconnexion.Name = "menuItemDeconnexion";
            this.menuItemDeconnexion.Size = new System.Drawing.Size(224, 26);
            this.menuItemDeconnexion.Text = "Déconnexion";
            this.menuItemDeconnexion.Click += new System.EventHandler(this.menuItemDeconnexion_Click);
            // 
            // menuItemQuitter
            // 
            this.menuItemQuitter.Name = "menuItemQuitter";
            this.menuItemQuitter.Size = new System.Drawing.Size(224, 26);
            this.menuItemQuitter.Text = "Quitter";
            this.menuItemQuitter.Click += new System.EventHandler(this.menuItemQuitter_Click);
            // 
            // menuGestion
            // 
            this.menuGestion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemArrets,
            this.menuItemLignes,
            this.menuItemHoraires,
            this.menuItemUtilisateurs});
            this.menuGestion.ForeColor = System.Drawing.Color.White;
            this.menuGestion.Name = "menuGestion";
            this.menuGestion.Size = new System.Drawing.Size(73, 26);
            this.menuGestion.Text = "Gestion";
            // 
            // menuItemArrets
            // 
            this.menuItemArrets.Name = "menuItemArrets";
            this.menuItemArrets.Size = new System.Drawing.Size(165, 26);
            this.menuItemArrets.Text = "Arrêt";
            this.menuItemArrets.Click += new System.EventHandler(this.menuItemArrets_Click);
            // 
            // menuItemLignes
            // 
            this.menuItemLignes.Name = "menuItemLignes";
            this.menuItemLignes.Size = new System.Drawing.Size(165, 26);
            this.menuItemLignes.Text = "Lignes";
            this.menuItemLignes.Click += new System.EventHandler(this.menuItemLignes_Click);
            // 
            // menuItemHoraires
            // 
            this.menuItemHoraires.Name = "menuItemHoraires";
            this.menuItemHoraires.Size = new System.Drawing.Size(165, 26);
            this.menuItemHoraires.Text = "Horaires";
            this.menuItemHoraires.Click += new System.EventHandler(this.menuItemHoraires_Click);
            // 
            // menuItemUtilisateurs
            // 
            this.menuItemUtilisateurs.Name = "menuItemUtilisateurs";
            this.menuItemUtilisateurs.Size = new System.Drawing.Size(165, 26);
            this.menuItemUtilisateurs.Text = "Utilisateurs";
            this.menuItemUtilisateurs.Click += new System.EventHandler(this.menuItemUtilisateurs_Click);
            // 
            // menuConsultation
            // 
            this.menuConsultation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemReseau,
            this.menuItemLigneDetails,
            this.menuItemHorairesJournee});
            this.menuConsultation.ForeColor = System.Drawing.Color.White;
            this.menuConsultation.Name = "menuConsultation";
            this.menuConsultation.Size = new System.Drawing.Size(106, 26);
            this.menuConsultation.Text = "Consultation";
            // 
            // menuItemReseau
            // 
            this.menuItemReseau.Name = "menuItemReseau";
            this.menuItemReseau.Size = new System.Drawing.Size(215, 26);
            this.menuItemReseau.Text = "Réseau complet";
            this.menuItemReseau.Click += new System.EventHandler(this.menuItemReseau_Click);
            // 
            // menuItemLigneDetails
            // 
            this.menuItemLigneDetails.Name = "menuItemLigneDetails";
            this.menuItemLigneDetails.Size = new System.Drawing.Size(215, 26);
            this.menuItemLigneDetails.Text = "Détails d\'une ligne";
            this.menuItemLigneDetails.Click += new System.EventHandler(this.menuItemLigneDetails_Click);
            // 
            // menuItemHorairesJournee
            // 
            this.menuItemHorairesJournee.Name = "menuItemHorairesJournee";
            this.menuItemHorairesJournee.Size = new System.Drawing.Size(215, 26);
            this.menuItemHorairesJournee.Text = "Horaires du jour";
            this.menuItemHorairesJournee.Click += new System.EventHandler(this.menuItemHorairesJournee_Click);
            // 
            // menuRecherche
            // 
            this.menuRecherche.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemItineraire});
            this.menuRecherche.ForeColor = System.Drawing.Color.White;
            this.menuRecherche.Name = "menuRecherche";
            this.menuRecherche.Size = new System.Drawing.Size(91, 26);
            this.menuRecherche.Text = "Recherche";
            // 
            // menuItemItineraire
            // 
            this.menuItemItineraire.Name = "menuItemItineraire";
            this.menuItemItineraire.Size = new System.Drawing.Size(151, 26);
            this.menuItemItineraire.Text = "Itinéraire";
            this.menuItemItineraire.Click += new System.EventHandler(this.menuItemItineraire_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusUtilisateur});
            this.statusStrip.Location = new System.Drawing.Point(0, 384);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(567, 26);
            this.statusStrip.TabIndex = 1;
            // 
            // lblStatusUtilisateur
            // 
            this.lblStatusUtilisateur.ForeColor = System.Drawing.Color.White;
            this.lblStatusUtilisateur.Name = "lblStatusUtilisateur";
            this.lblStatusUtilisateur.Size = new System.Drawing.Size(151, 20);
            this.lblStatusUtilisateur.Text = "Utilisateur connecté : ";
            // 
            // panelContenu
            // 
            this.panelContenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenu.Location = new System.Drawing.Point(0, 30);
            this.panelContenu.Name = "panelContenu";
            this.panelContenu.Size = new System.Drawing.Size(567, 354);
            this.panelContenu.TabIndex = 0;
            // 
            // lblGroupe
            // 
            this.lblGroupe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGroupe.AutoSize = true;
            this.lblGroupe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.lblGroupe.ForeColor = System.Drawing.Color.White;
            this.lblGroupe.Location = new System.Drawing.Point(505, 392);
            this.lblGroupe.Name = "lblGroupe";
            this.lblGroupe.Size = new System.Drawing.Size(75, 16);
            this.lblGroupe.TabIndex = 3;
            this.lblGroupe.Text = "Groupe A-6";
            this.lblGroupe.Click += new System.EventHandler(this.lblGroupe_Click);
            // 
            // terminalToolStripMenuItem
            // 
            this.terminalToolStripMenuItem.Name = "terminalToolStripMenuItem";
            this.terminalToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.terminalToolStripMenuItem.Text = "Terminal";
            this.terminalToolStripMenuItem.Click += new System.EventHandler(this.terminalToolStripMenuItem_Click);
            // 
            // FormPrincipal
            // 
            this.ClientSize = new System.Drawing.Size(567, 410);
            this.Controls.Add(this.lblGroupe);
            this.Controls.Add(this.panelContenu);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fumobilité";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private ToolStripMenuItem menuItemConnexion;
        private Label lblGroupe;
        private ToolStripMenuItem sinscrireToolStripMenuItem;
        private ToolStripMenuItem terminalToolStripMenuItem;
    }
}
