using System;
using System.Windows.Forms;
using Fumoblilite.Systeme.Services;
using Fumoblilite.Systeme.Modeles;
using Fumoblilite.SQL.Repositories;

namespace Fumoblilite.Interface.Forms
{
    public partial class FormConnexion : Form
    {
        private readonly string _connectionString;
        private readonly ServiceAuthentification _serviceAuthentification;
        public Utilisateur UtilisateurConnecte { get; private set; }

        // Constructeur de la classe FormConnexion
        public FormConnexion(string connectionString)
        {
            _connectionString = connectionString;
            InitializeComponent();

            // Initialisation du service d'authentification avec le repository utilisateur
            try
            {
                var repositoryUtilisateur = new RepositoryUtilisateur(_connectionString);
                _serviceAuthentification = new ServiceAuthentification(repositoryUtilisateur);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'initialisation : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Gestionnaire d'événements pour le clic sur le bouton de connexion
        private void btnConnexion_Click(object sender, EventArgs e)
        {
            try
            {
                string nomUtilisateur = txtNomUtilisateur.Text.Trim();
                string motDePasse = txtMotDePasse.Text;

                // Vérification si les champs nom d'utilisateur et mot de passe sont remplis
                if (string.IsNullOrEmpty(nomUtilisateur) || string.IsNullOrEmpty(motDePasse))
                {
                    MessageBox.Show("Veuillez saisir un nom d'utilisateur et un mot de passe.", "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Vérification que le service d'authentification est initialisé
                if (_serviceAuthentification == null)
                {
                    MessageBox.Show("Erreur de connexion à la base de données.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Authentification de l'utilisateur
                Utilisateur utilisateur = _serviceAuthentification.Authentifier(nomUtilisateur, motDePasse);
                if (utilisateur != null)
                {
                    UtilisateurConnecte = utilisateur;
                    this.DialogResult = DialogResult.OK;
                    this.Close(); // Fermer le formulaire de connexion si l'authentification réussit
                }
                else
                {
                    // Afficher un message d'erreur si l'authentification échoue
                    MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.", "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMotDePasse.Clear();
                    txtMotDePasse.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la connexion : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Gestionnaire d'événements pour le clic sur le bouton retour
        private void btnRetour_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Gestionnaire pour la touche Entrée dans le champ mot de passe
        private void txtMotDePasse_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnConnexion_Click(sender, e);
            }
        }

        // Gestionnaire d'événements pour le clic sur le bouton d'inscription
        private void btnInscription_Click(object sender, EventArgs e)
        {
            try
            {
                FormInscription formInscription = new FormInscription(_connectionString);
                if (formInscription.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Inscription réussie ! Vous pouvez maintenant vous connecter.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ouverture du formulaire d'inscription : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
