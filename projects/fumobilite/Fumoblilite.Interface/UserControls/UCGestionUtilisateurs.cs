using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using Fumoblilite.Systeme.Modeles;
using Fumoblilite.Systeme.Services;
using Fumoblilite.SQL.Repositories;
using Fumoblilite.Systeme.Interfaces;
using System.IO;
using System.Text;
using System.Text.Json;


namespace Fumoblilite.Interface.UserControls
{
    public partial class UCGestionUtilisateurs : UserControl
    {
        private readonly string _connectionString;
        private readonly ServiceAuthentification _serviceAuthentification;
        private readonly IRepositoryUtilisateur _repositoryUtilisateur;
        private Utilisateur _utilisateurSelectionne;
        private Panel _selectedUserPanel;

        public UCGestionUtilisateurs(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;

            _repositoryUtilisateur = new RepositoryUtilisateur(_connectionString);
            _serviceAuthentification = new ServiceAuthentification(_repositoryUtilisateur);
        }

        private void UCGestionUtilisateurs_Load(object sender, EventArgs e)
        {
            ChargerUtilisateurs();
            cboRole.SelectedIndex = 1; // Sélectionner "Utilisateur" par défaut
        }

        private void ChargerUtilisateurs()
        {
            try
            {
                List<Utilisateur> utilisateurs = _repositoryUtilisateur.ObtenirTous();

                flpUtilisateurs.SuspendLayout();
                flpUtilisateurs.Controls.Clear();
                _selectedUserPanel = null;

                foreach (var utilisateur in utilisateurs)
                {
                    Panel panel = CreerCarteUtilisateur(utilisateur);
                    flpUtilisateurs.Controls.Add(panel);
                }

                flpUtilisateurs.ResumeLayout();
                ViderChamps();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des utilisateurs : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Panel CreerCarteUtilisateur(Utilisateur utilisateur)
        {
            // Créer un panel pour la carte
            Panel panel = new Panel
            {
                Width = 430,
                Height = 80,
                Margin = new Padding(5),
                BorderStyle = BorderStyle.FixedSingle,
                Tag = utilisateur
            };

            // Ajouter une bordure colorée à gauche selon le rôle
            Panel bordureGauche = new Panel
            {
                Width = 10,
                Height = panel.Height,
                Dock = DockStyle.Left,
                BackColor = utilisateur.Role == "Admin" ? Color.DarkRed : Color.DarkBlue
            };
            panel.Controls.Add(bordureGauche);

            // Ajouter les informations de l'utilisateur
            Label lblNomComplet = new Label
            {
                Text = $"{utilisateur.Prenom} {utilisateur.Nom}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 10)
            };
            panel.Controls.Add(lblNomComplet);

            Label lblNomUtilisateur = new Label
            {
                Text = $"Nom d'utilisateur: {utilisateur.NomUtilisateur}",
                Font = new Font("Segoe UI", 9),
                AutoSize = true,
                Location = new Point(20, 35)
            };
            panel.Controls.Add(lblNomUtilisateur);

            Label lblEmail = new Label
            {
                Text = $"Email: {utilisateur.Email}",
                Font = new Font("Segoe UI", 9),
                AutoSize = true,
                Location = new Point(20, 55)
            };
            panel.Controls.Add(lblEmail);

            // Indicateur de rôle
            Label lblRole = new Label
            {
                Text = utilisateur.Role,
                Font = new Font("Segoe UI", 8, FontStyle.Bold),
                AutoSize = true,
                ForeColor = utilisateur.Role == "Admin" ? Color.DarkRed : Color.DarkBlue,
                Location = new Point(panel.Width - 100, 10)
            };
            panel.Controls.Add(lblRole);

            // Indicateur d'état actif/inactif
            Panel indicateurActif = new Panel
            {
                Width = 15,
                Height = 15,
                BackColor = utilisateur.EstActif ? Color.Green : Color.Red,
                Location = new Point(panel.Width - 25, 10)
            };
            panel.Controls.Add(indicateurActif);

            Label lblActif = new Label
            {
                Text = utilisateur.EstActif ? "Actif" : "Inactif",
                Font = new Font("Segoe UI", 8),
                AutoSize = true,
                Location = new Point(panel.Width - 70, 35)
            };
            panel.Controls.Add(lblActif);

            // Ajouter un gestionnaire d'événements pour la sélection
            panel.Click += (sender, e) => SelectionnerUtilisateur(panel);
            foreach (Control control in panel.Controls)
            {
                control.Click += (sender, e) => SelectionnerUtilisateur(panel);
            }

            return panel;
        }

        private void SelectionnerUtilisateur(Panel panel)
        {
            // Désélectionner le panel précédemment sélectionné
            if (_selectedUserPanel != null)
            {
                _selectedUserPanel.BackColor = SystemColors.Control;
            }

            // Sélectionner le nouveau panel
            _selectedUserPanel = panel;
            _selectedUserPanel.BackColor = Color.FromArgb(230, 240, 250);

            // Récupérer l'utilisateur associé au panel
            _utilisateurSelectionne = (Utilisateur)panel.Tag;

            if (_utilisateurSelectionne != null)
            {
                txtId.Text = _utilisateurSelectionne.Id.ToString();
                txtNom.Text = _utilisateurSelectionne.Nom;
                txtPrenom.Text = _utilisateurSelectionne.Prenom;
                txtNomUtilisateur.Text = _utilisateurSelectionne.NomUtilisateur;
                txtMotDePasse.Text = string.Empty; // Ne pas afficher le mot de passe
                txtEmail.Text = _utilisateurSelectionne.Email;
                cboRole.SelectedItem = _utilisateurSelectionne.Role;
                chkEstActif.Checked = _utilisateurSelectionne.EstActif;
                btnSupprimer.Enabled = true;
            }
        }

        private void ViderChamps()
        {
            txtId.Text = string.Empty;
            txtNom.Text = string.Empty;
            txtPrenom.Text = string.Empty;
            txtNomUtilisateur.Text = string.Empty;
            txtMotDePasse.Text = string.Empty;
            txtEmail.Text = string.Empty;
            cboRole.SelectedIndex = 1; // "Utilisateur" par défaut
            chkEstActif.Checked = true;
            _utilisateurSelectionne = null;
            btnSupprimer.Enabled = false;

            // Désélectionner le panel
            if (_selectedUserPanel != null)
            {
                _selectedUserPanel.BackColor = SystemColors.Control;
                _selectedUserPanel = null;
            }
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            ViderChamps();
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNom.Text) || string.IsNullOrWhiteSpace(txtPrenom.Text) ||
                    string.IsNullOrWhiteSpace(txtNomUtilisateur.Text))
                {
                    MessageBox.Show("Le nom, le prénom et le nom d'utilisateur sont obligatoires.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_utilisateurSelectionne == null && string.IsNullOrWhiteSpace(txtMotDePasse.Text))
                {
                    MessageBox.Show("Le mot de passe est obligatoire pour un nouvel utilisateur.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_utilisateurSelectionne == null)
                {
                    // Nouvel utilisateur
                    Utilisateur nouvelUtilisateur = new Utilisateur
                    {
                        Nom = txtNom.Text,
                        Prenom = txtPrenom.Text,
                        NomUtilisateur = txtNomUtilisateur.Text,
                        MotDePasse = _serviceAuthentification.HashMotDePasse(txtMotDePasse.Text),
                        Email = txtEmail.Text,
                        Role = cboRole.SelectedItem.ToString(),
                        EstActif = chkEstActif.Checked
                    };

                    int id = _repositoryUtilisateur.Ajouter(nouvelUtilisateur);
                    MessageBox.Show("Utilisateur ajouté avec succès.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Modification d'un utilisateur existant
                    _utilisateurSelectionne.Nom = txtNom.Text;
                    _utilisateurSelectionne.Prenom = txtPrenom.Text;
                    _utilisateurSelectionne.NomUtilisateur = txtNomUtilisateur.Text;
                    _utilisateurSelectionne.Email = txtEmail.Text;
                    _utilisateurSelectionne.Role = cboRole.SelectedItem.ToString();
                    _utilisateurSelectionne.EstActif = chkEstActif.Checked;

                    bool resultat = _repositoryUtilisateur.Modifier(_utilisateurSelectionne);

                    // Si un nouveau mot de passe a été saisi, le mettre à jour
                    if (!string.IsNullOrWhiteSpace(txtMotDePasse.Text))
                    {
                        string motDePasseHash = _serviceAuthentification.HashMotDePasse(txtMotDePasse.Text);
                        resultat = _repositoryUtilisateur.ModifierMotDePasse(_utilisateurSelectionne.Id, motDePasseHash);
                    }

                    if (resultat)
                    {
                        MessageBox.Show("Utilisateur modifié avec succès.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de la modification de l'utilisateur.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                ChargerUtilisateurs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (_utilisateurSelectionne != null)
            {
                DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet utilisateur ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        bool resultat = _repositoryUtilisateur.Supprimer(_utilisateurSelectionne.Id);
                        if (resultat)
                        {
                            MessageBox.Show("Utilisateur supprimé avec succès.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ChargerUtilisateurs();
                        }
                        else
                        {
                            MessageBox.Show("Erreur lors de la suppression de l'utilisateur.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtRecherche_TextChanged(object sender, EventArgs e)
        {
            FiltrerUtilisateurs();
        }

        private void FiltrerUtilisateurs()
        {
            string recherche = txtRecherche.Text.ToLower();

            foreach (Control control in flpUtilisateurs.Controls)
            {
                if (control is Panel panel && panel.Tag is Utilisateur utilisateur)
                {
                    bool visible = string.IsNullOrEmpty(recherche) ||
                                  utilisateur.Nom.ToLower().Contains(recherche) ||
                                  utilisateur.Prenom.ToLower().Contains(recherche) ||
                                  utilisateur.NomUtilisateur.ToLower().Contains(recherche) ||
                                  utilisateur.Email.ToLower().Contains(recherche);

                    panel.Visible = visible;
                }
            }
        }

        private void btnExporterCsv_Click(object sender, EventArgs e)
        {
            var utilisateurs = _repositoryUtilisateur.ObtenirTous();
            var sb = new StringBuilder();
            sb.AppendLine("Id,Nom,Prenom,NomUtilisateur,Email,Role,EstActif");
            foreach (var u in utilisateurs)
                sb.AppendLine($"{u.Id},{u.Nom},{u.Prenom},{u.NomUtilisateur},{u.Email},{u.Role},{u.EstActif}");
            using (var sfd = new SaveFileDialog { Filter = "CSV (*.csv)|*.csv", FileName = "utilisateurs.csv" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
            }
        }

        private void btnExporterJson_Click(object sender, EventArgs e)
        {
            var utilisateurs = _repositoryUtilisateur.ObtenirTous();
            using (var sfd = new SaveFileDialog { Filter = "JSON (*.json)|*.json", FileName = "utilisateurs.json" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                    File.WriteAllText(sfd.FileName, JsonSerializer.Serialize(utilisateurs, new JsonSerializerOptions { WriteIndented = true }), Encoding.UTF8);
            }
        }

    }
}
