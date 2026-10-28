using System;
using System.Windows.Forms;
using Fumoblilite.Systeme.Modeles;
using Fumoblilite.Interface.UserControls;
using Fumoblilite.Interface.Properties;
using System.Media;
using System.IO;

namespace Fumoblilite.Interface.Forms
{
    public partial class FormPrincipal : Form
    {
        private readonly string _connectionString;
        private readonly Utilisateur _utilisateurConnecte;
        private bool _modeConsole = false;

        public FormPrincipal(string connectionString, Utilisateur utilisateur)
        {
            InitializeComponent();
            _connectionString = connectionString;
            _utilisateurConnecte = utilisateur;
            this.FormClosing += FormPrincipal_FormClosing;

            // Activer la capture des touches pour l'invite de commande
            this.KeyPreview = true;
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            // Vérifier si un utilisateur est connecté
            if (_utilisateurConnecte != null)
            {
                // Afficher les informations de l'utilisateur connecté
                lblStatusUtilisateur.Text = $"Utilisateur connecté: {_utilisateurConnecte.Prenom} {_utilisateurConnecte.Nom} ({_utilisateurConnecte.Role})";
                menuItemDeconnexion.Visible = true;
                menuItemConnexion.Visible = false; // Masquer le bouton de connexion
                sinscrireToolStripMenuItem.Visible = false; // Masquer le menu S'inscrire
            }
            else
            {
                // Mode invité
                lblStatusUtilisateur.Text = "Mode invité";
                menuItemDeconnexion.Visible = false;
                menuItemConnexion.Visible = true; // Afficher le bouton de connexion
                sinscrireToolStripMenuItem.Visible = true; // Afficher le menu S'inscrire
            }

            // Masquer les éléments de menu de gestion pour les utilisateurs non administrateurs
            if (_utilisateurConnecte == null || _utilisateurConnecte.Role != "Admin")
            {
                menuItemUtilisateurs.Visible = false;
                menuItemArrets.Visible = false;
                menuItemLignes.Visible = false;
                menuItemHoraires.Visible = false;
                menuGestion.Visible = false;
            }

            // Afficher le réseau par défaut
            AfficherReseau();
        }

        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Demander confirmation avant de fermer l'application
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var message = MessageBox.Show("Êtes-vous sûr de vouloir quitter?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (message == DialogResult.No)
                {
                    e.Cancel = true; // Annuler la fermeture
                }
                else
                {
                    Application.Exit(); // Fermer l'application
                }
            }
        }

        public void ExecuterCommande(string commande)
        {
            // En mode console, ne pas charger les UserControls, laisser la console gérer
            if (_modeConsole)
            {
                return; // La console gère tout
            }

            // Mode normal - charger les UserControls
            string[] parties = commande.ToLower().Split(' ');
            string commandePrincipale = parties[0];

            switch (commandePrincipale)
            {
                case "reseau":
                    ChargerUserControl(new UCConsultationReseau(_connectionString));
                    break;
                case "lignes":
                    if (_utilisateurConnecte?.Role == "Admin")
                        ChargerUserControl(new UCGestionLignes(_connectionString));
                    else
                        ChargerUserControl(new UCConsultationLigne(_connectionString));
                    break;
                case "arrets":
                    if (_utilisateurConnecte?.Role == "Admin")
                        ChargerUserControl(new UCGestionArrets(_connectionString));
                    else
                        MessageBox.Show("Accès refusé. Droits administrateur requis.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "horaires":
                    if (_utilisateurConnecte?.Role == "Admin")
                        ChargerUserControl(new UCGestionHoraires(_connectionString));
                    else
                        ChargerUserControl(new UCConsultationHoraires(_connectionString));
                    break;
                case "utilisateurs":
                    if (_utilisateurConnecte?.Role == "Admin")
                        ChargerUserControl(new UCGestionUtilisateurs(_connectionString));
                    else
                        MessageBox.Show("Accès refusé. Droits administrateur requis.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "itineraire":
                    ChargerUserControl(new UCRechercheItineraire(_connectionString));
                    break;
                case "credits":
                    ChargerUserControl(new UCCredits());
                    break;
                case "connexion":
                    if (_utilisateurConnecte == null)
                        menuItemConnexion_Click(null, null);
                    else
                        MessageBox.Show("Vous êtes déjà connecté.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case "deconnexion":
                    if (_utilisateurConnecte != null)
                        menuItemDeconnexion_Click(null, null);
                    else
                        MessageBox.Show("Vous n'êtes pas connecté.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case "quitter":
                    menuItemQuitter_Click(null, null);
                    break;
            }
        }

        public void FermerModeConsole()
        {
            _modeConsole = false;
            AfficherReseau();
        }

        private void AfficherReseau()
        {
            // Afficher le contrôle utilisateur de consultation du réseau
            panelContenu.Controls.Clear();
            UCConsultationReseau ucConsultationReseau = new UCConsultationReseau(_connectionString);
            ucConsultationReseau.Dock = DockStyle.Fill;
            panelContenu.Controls.Add(ucConsultationReseau);
        }

        private void menuItemConnexion_Click(object sender, EventArgs e)
        {
            // Ouvrir le formulaire de connexion
            FormConnexion formConnexion = new FormConnexion(_connectionString);
            formConnexion.FormClosed += (s, args) =>
            {
                // Si un utilisateur s'est connecté, ouvrir une nouvelle instance de FormPrincipal
                if (formConnexion.UtilisateurConnecte != null)
                {
                    this.Hide();
                    FormPrincipal formPrincipal = new FormPrincipal(_connectionString, formConnexion.UtilisateurConnecte);
                    formPrincipal.Show();
                }
            };
            formConnexion.Show();
        }

        private void menuItemDeconnexion_Click(object sender, EventArgs e)
        {
            // Déconnexion de l'utilisateur et ouverture d'une nouvelle instance de FormPrincipal en mode invité
            this.Hide();
            FormPrincipal formPrincipal = new FormPrincipal(_connectionString, null);
            formPrincipal.Show();
        }

        private void menuItemQuitter_Click(object sender, EventArgs e)
        {
            // Quitter l'application
            Application.Exit();
        }

        private void menuItemArrets_Click(object sender, EventArgs e)
        {
            // Charger le contrôle utilisateur de gestion des arrêts
            ChargerUserControl(new UCGestionArrets(_connectionString));
        }

        private void menuItemLignes_Click(object sender, EventArgs e)
        {
            // Charger le contrôle utilisateur de gestion des lignes
            ChargerUserControl(new UCGestionLignes(_connectionString));
        }

        private void menuItemHoraires_Click(object sender, EventArgs e)
        {
            // Charger le contrôle utilisateur de gestion des horaires
            ChargerUserControl(new UCGestionHoraires(_connectionString));
        }

        private void menuItemUtilisateurs_Click(object sender, EventArgs e)
        {
            // Charger le contrôle utilisateur de gestion des utilisateurs
            ChargerUserControl(new UCGestionUtilisateurs(_connectionString));
        }

        private void menuItemReseau_Click(object sender, EventArgs e)
        {
            // Charger le contrôle utilisateur de consultation du réseau
            ChargerUserControl(new UCConsultationReseau(_connectionString));
        }

        private void menuItemLigneDetails_Click(object sender, EventArgs e)
        {
            // Charger le contrôle utilisateur de consultation des détails de ligne
            ChargerUserControl(new UCConsultationLigne(_connectionString));
        }

        private void menuItemHorairesJournee_Click(object sender, EventArgs e)
        {
            // Charger le contrôle utilisateur de consultation des horaires de la journée
            ChargerUserControl(new UCConsultationHoraires(_connectionString));
        }

        private void menuItemItineraire_Click(object sender, EventArgs e)
        {
            // Charger le contrôle utilisateur de recherche d'itinéraire
            ChargerUserControl(new UCRechercheItineraire(_connectionString));
        }

        private void ChargerUserControl(UserControl uc)
        {
            // Charger un contrôle utilisateur dans le panneau de contenu
            panelContenu.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelContenu.Controls.Add(uc);
        }

        private void lblGroupe_Click(object sender, EventArgs e)
        {
            ChargerUserControl(new UCCredits());
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Shift | Keys.C))
            {
                // Charger le contrôle utilisateur d'invite de commande
                _modeConsole = true;
                ChargerUserControl(new UCInviteCommande(_connectionString, _utilisateurConnecte, this));
            }

            // Quitter l'application
            if (keyData == (Keys.Control | Keys.Q))
            {
                Application.Exit();
                return true;
            }

            // Consultation des lignes
            if (keyData == (Keys.Control | Keys.L))
            {
                ChargerUserControl(new UCConsultationLigne(_connectionString));
                return true;
            }
            // Gestion des lignes (admin)
            if (keyData == (Keys.Control | Keys.Shift | Keys.L))
            {
                if (_utilisateurConnecte?.Role == "Admin")
                    ChargerUserControl(new UCGestionLignes(_connectionString));
                return true;
            }

            // Gestion des arrêts (admin)
            if (keyData == (Keys.Control | Keys.Shift | Keys.A))
            {
                if (_utilisateurConnecte?.Role == "Admin")
                    ChargerUserControl(new UCGestionArrets(_connectionString));
                return true;
            }

            // Consultation des horaires
            if (keyData == (Keys.Control | Keys.H))
            {
                ChargerUserControl(new UCConsultationHoraires(_connectionString));
                return true;
            }
            // Gestion des horaires (admin)
            if (keyData == (Keys.Control | Keys.Shift | Keys.H))
            {
                if (_utilisateurConnecte?.Role == "Admin")
                    ChargerUserControl(new UCGestionHoraires(_connectionString));
                return true;
            }

            // Gestion des utilisateurs (admin)
            if (keyData == (Keys.Control | Keys.Shift | Keys.U))
            {
                if (_utilisateurConnecte?.Role == "Admin")
                    ChargerUserControl(new UCGestionUtilisateurs(_connectionString));
                return true;
            }

            // Afficher le réseau
            if (keyData == (Keys.Control | Keys.R))
            {
                AfficherReseau();
                return true;
            }

            // Aide/crédits
            if (keyData == Keys.F1)
            {
                ChargerUserControl(new UCCredits());
                return true;
            }

            // Recherche d'itinéraire
            if (keyData == (Keys.Control | Keys.I))
            {
                ChargerUserControl(new UCRechercheItineraire(_connectionString));
                return true;
            }

            // Form de connexion
            if (keyData == (Keys.Control | Keys.O))
            {
                menuItemConnexion_Click(null, null);
                return true;
            }

            // Form de connexion
            if (keyData == (Keys.Control | Keys.S))
            {
                sinscrireToolStripMenuItem_Click(null, null);
                return true;
            }

            if (keyData == (Keys.Control | Keys.Alt | Keys.C))
            {
                using (var stream = new MemoryStream(Resources.lvlup))
                {
                    SoundPlayer player = new SoundPlayer(stream);
                    player.Play();
                }
            }

            if (keyData == (Keys.Control | Keys.Alt | Keys.V))
            {
                using (var stream = new MemoryStream(Resources.chocobo))
                {
                    SoundPlayer player = new SoundPlayer(stream);
                    player.Play();
                }

            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void sinscrireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Ouvrir le formulaire d'inscription
            FormInscription formInscription = new FormInscription(_connectionString);
            formInscription.ShowDialog();
            // Si l'utilisateur s'inscrit, rafraîchir l'interface
            if (formInscription.DialogResult == DialogResult.OK)
            {
                MessageBox.Show("Inscription réussie ! Vous pouvez maintenant vous connecter.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void terminalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Charger le contrôle utilisateur d'invite de commande
            _modeConsole = true;
            ChargerUserControl(new UCInviteCommande(_connectionString, _utilisateurConnecte, this));

        }
    }
}
