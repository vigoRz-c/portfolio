using System;
using System.Windows.Forms;
using Fumoblilite.Systeme.Services;
using Fumoblilite.Systeme.Modeles;
using Fumoblilite.SQL.Repositories;
using System.Text.RegularExpressions;

namespace Fumoblilite.Interface.Forms
{
    public partial class FormInscription : Form
    {
        private readonly string _connectionString;
        private readonly RepositoryUtilisateur _repositoryUtilisateur;
        private readonly ServiceAuthentification _serviceAuthentification;

        public FormInscription(string connectionString)
        {
            _connectionString = connectionString;
            InitializeComponent();

            try
            {
                _repositoryUtilisateur = new RepositoryUtilisateur(_connectionString);
                _serviceAuthentification = new ServiceAuthentification(_repositoryUtilisateur);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'initialisation : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInscrire_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation des champs
                if (!ValiderChamps())
                    return;

                // Vérifier si le nom d'utilisateur existe déjà
                if (_repositoryUtilisateur.ObtenirParNomUtilisateur(txtNomUtilisateur.Text.Trim()) != null)
                {
                    MessageBox.Show("Ce nom d'utilisateur existe déjà. Veuillez en choisir un autre.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNomUtilisateur.Focus();
                    return;
                }

                // Créer le nouvel utilisateur
                Utilisateur nouvelUtilisateur = new Utilisateur
                {
                    Nom = txtNom.Text.Trim(),
                    Prenom = txtPrenom.Text.Trim(),
                    NomUtilisateur = txtNomUtilisateur.Text.Trim(),
                    MotDePasse = _serviceAuthentification.HashMotDePasse(txtMotDePasse.Text),
                    Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                    Role = "Utilisateur", // Par défaut, les nouveaux utilisateurs ont le rôle "Utilisateur"
                    EstActif = true,
                    DateCreation = DateTime.Now
                };

                // Ajouter l'utilisateur à la base de données
                int nouvelId = _repositoryUtilisateur.Ajouter(nouvelUtilisateur);

                if (nouvelId > 0)
                {
                    MessageBox.Show("Inscription réussie !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Erreur lors de l'inscription. Veuillez réessayer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'inscription : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValiderChamps()
        {
            // Vérifier que tous les champs obligatoires sont remplis
            if (string.IsNullOrWhiteSpace(txtNom.Text))
            {
                MessageBox.Show("Le nom est obligatoire.", "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNom.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPrenom.Text))
            {
                MessageBox.Show("Le prénom est obligatoire.", "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrenom.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNomUtilisateur.Text))
            {
                MessageBox.Show("Le nom d'utilisateur est obligatoire.", "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomUtilisateur.Focus();
                return false;
            }

            // Vérifier la longueur du nom d'utilisateur
            if (txtNomUtilisateur.Text.Trim().Length < 3)
            {
                MessageBox.Show("Le nom d'utilisateur doit contenir au moins 3 caractères.", "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomUtilisateur.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMotDePasse.Text))
            {
                MessageBox.Show("Le mot de passe est obligatoire.", "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMotDePasse.Focus();
                return false;
            }

            // Vérifier la longueur du mot de passe
            if (txtMotDePasse.Text.Length < 6)
            {
                MessageBox.Show("Le mot de passe doit contenir au moins 6 caractères.", "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMotDePasse.Focus();
                return false;
            }

            // Vérifier la confirmation du mot de passe
            if (txtMotDePasse.Text != txtConfirmationMotDePasse.Text)
            {
                MessageBox.Show("Les mots de passe ne correspondent pas.", "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmationMotDePasse.Focus();
                return false;
            }

            // Valider l'email s'il est fourni
            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !ValiderEmail(txtEmail.Text.Trim()))
            {
                MessageBox.Show("L'adresse email n'est pas valide.", "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            return true;
        }

        private bool ValiderEmail(string email)
        {
            try
            {
                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                return Regex.IsMatch(email, pattern);
            }
            catch
            {
                return false;
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtConfirmationMotDePasse_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnInscrire_Click(sender, e);
            }
        }
    }
}