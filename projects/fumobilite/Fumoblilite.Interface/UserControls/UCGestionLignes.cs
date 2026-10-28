using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using Fumoblilite.Systeme.Modeles;
using Fumoblilite.Systeme.Services;
using Fumoblilite.SQL.Repositories;
using Fumoblilite.Systeme.Interfaces;
using System.Linq;
using System.Text.Json;
using System.Text;
using System.IO;

namespace Fumoblilite.Interface.UserControls
{
    public partial class UCGestionLignes : UserControl
    {
        private readonly string _connectionString;
        private readonly ServiceLigne _serviceLigne;
        private readonly ServiceArret _serviceArret;
        private Ligne _ligneSelectionnee;
        private Panel _selectedLignePanel;
        private Panel _selectedArretPanel;
        private List<dynamic> _arretsAffichage;

        public UCGestionLignes(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;

            // Initialisation des repositories
            IRepositoryLigne repositoryLigne = new RepositoryLigne(_connectionString);
            IRepositoryArret repositoryArret = new RepositoryArret(_connectionString);
            IRepositoryArretLigne repositoryArretLigne = new RepositoryArretLigne(_connectionString, repositoryArret);

            // Initialisation des services
            _serviceLigne = new ServiceLigne(repositoryLigne, repositoryArretLigne);
            _serviceArret = new ServiceArret(repositoryArret);
        }

        private void UCGestionLignes_Load(object sender, EventArgs e)
        {
            ChargerLignes();
            ChargerArrets();
        }

        private void ChargerLignes()
        {
            try
            {
                List<Ligne> lignes = _serviceLigne.ObtenirToutes();

                flpLignes.SuspendLayout();
                flpLignes.Controls.Clear();
                _selectedLignePanel = null;

                foreach (var ligne in lignes)
                {
                    Panel panel = CreerCarteLigne(ligne);
                    flpLignes.Controls.Add(panel);
                }

                flpLignes.ResumeLayout();
                ViderChamps();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des lignes : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Panel CreerCarteLigne(Ligne ligne)
        {
            // Créer un panel pour la carte
            Panel panel = new Panel
            {
                Width = 280,
                Height = 80,
                Margin = new Padding(5),
                BorderStyle = BorderStyle.FixedSingle,
                Tag = ligne
            };

            // Ajouter une bordure colorée à gauche selon la couleur de la ligne
            Panel bordureGauche = new Panel
            {
                Width = 10,
                Height = panel.Height,
                Dock = DockStyle.Left
            };

            try
            {
                if (!string.IsNullOrEmpty(ligne.Couleur))
                {
                    string hexColor = ligne.Couleur.TrimStart('#');
                    if (hexColor.Length == 6)
                    {
                        int r = Convert.ToInt32(hexColor.Substring(0, 2), 16);
                        int g = Convert.ToInt32(hexColor.Substring(2, 2), 16);
                        int b = Convert.ToInt32(hexColor.Substring(4, 2), 16);
                        bordureGauche.BackColor = Color.FromArgb(r, g, b);
                    }
                    else
                    {
                        bordureGauche.BackColor = Color.Gray;
                    }
                }
                else
                {
                    bordureGauche.BackColor = Color.Gray;
                }
            }
            catch
            {
                bordureGauche.BackColor = Color.Gray;
            }

            panel.Controls.Add(bordureGauche);

            // Ajouter les informations de la ligne
            Label lblNumero = new Label
            {
                Text = ligne.Numero,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 10)
            };
            panel.Controls.Add(lblNumero);

            Label lblNom = new Label
            {
                Text = ligne.Nom,
                Font = new Font("Segoe UI", 10),
                AutoSize = true,
                Location = new Point(20, 35)
            };
            panel.Controls.Add(lblNom);

            // Indicateur d'état actif/inactif
            Panel indicateurActif = new Panel
            {
                Width = 15,
                Height = 15,
                BackColor = ligne.EstActif ? Color.Green : Color.Red,
                Location = new Point(panel.Width - 25, 10)
            };
            panel.Controls.Add(indicateurActif);

            Label lblActif = new Label
            {
                Text = ligne.EstActif ? "Actif" : "Inactif",
                Font = new Font("Segoe UI", 8),
                AutoSize = true,
                Location = new Point(panel.Width - 70, 10)
            };
            panel.Controls.Add(lblActif);

            // Ajouter un gestionnaire d'événements pour la sélection
            panel.Click += (sender, e) => SelectionnerLigne(panel);
            foreach (Control control in panel.Controls)
            {
                control.Click += (sender, e) => SelectionnerLigne(panel);
            }

            return panel;
        }

        private void SelectionnerLigne(Panel panel)
        {
            // Désélectionner le panel précédemment sélectionné
            if (_selectedLignePanel != null)
            {
                _selectedLignePanel.BackColor = SystemColors.Control;
            }

            // Sélectionner le nouveau panel
            _selectedLignePanel = panel;
            _selectedLignePanel.BackColor = Color.FromArgb(230, 240, 250);

            // Récupérer la ligne associée au panel
            _ligneSelectionnee = (Ligne)panel.Tag;

            if (_ligneSelectionnee != null)
            {
                txtId.Text = _ligneSelectionnee.Id.ToString();
                txtNumero.Text = _ligneSelectionnee.Numero;
                txtNom.Text = _ligneSelectionnee.Nom;
                txtCouleur.Text = _ligneSelectionnee.Couleur ?? "#FF0000";
                chkEstActif.Checked = _ligneSelectionnee.EstActif;
                btnSupprimer.Enabled = true;

                // Recharger la ligne avec ses arrêts depuis la base de données
                _ligneSelectionnee = _serviceLigne.ObtenirParId(_ligneSelectionnee.Id, true);
                AfficherArrets();
            }
        }

        private void ChargerArrets()
        {
            try
            {
                List<Arret> arrets = _serviceArret.ObtenirTous();

                cboArret.DisplayMember = "Nom";
                cboArret.ValueMember = "Id";
                cboArret.DataSource = arrets;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des arrêts : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AfficherArrets()
        {
            try
            {
                flpArrets.SuspendLayout();
                flpArrets.Controls.Clear();
                _selectedArretPanel = null;

                if (_ligneSelectionnee == null)
                {
                    flpArrets.ResumeLayout();
                    return;
                }

                // Recharger la ligne avec ses arrêts depuis la base de données
                _ligneSelectionnee = _serviceLigne.ObtenirParId(_ligneSelectionnee.Id, true);

                if (_ligneSelectionnee.Arrets == null || _ligneSelectionnee.Arrets.Count == 0)
                {
                    // Afficher un message si aucun arrêt
                    Label lblAucunArret = new Label
                    {
                        Text = "Aucun arrêt configuré pour cette ligne",
                        Font = new Font("Segoe UI", 10, FontStyle.Italic),
                        ForeColor = Color.Gray,
                        AutoSize = true,
                        Margin = new Padding(10)
                    };
                    flpArrets.Controls.Add(lblAucunArret);
                    flpArrets.ResumeLayout();
                    return;
                }

                // Récupérer tous les arrêts pour avoir les noms
                var tousLesArrets = _serviceArret.ObtenirTous().ToDictionary(a => a.Id, a => a);

                // Préparer les données pour l'affichage
                _arretsAffichage = _ligneSelectionnee.Arrets
                    .Where(al => tousLesArrets.ContainsKey(al.ArretId))
                    .Select(al => (dynamic)new
                    {
                        Id = al.Id,
                        Ordre = al.Ordre,
                        Nom = tousLesArrets[al.ArretId].Nom,
                        TempsArret = al.TempsArretMinutes,
                        TempsTrajet = al.TempsTrajetSuivantMinutes,
                        ArretLigneComplet = al
                    })
                    .OrderBy(a => a.Ordre)
                    .ToList();

                foreach (var arret in _arretsAffichage)
                {
                    Panel panel = CreerCarteArret(arret);
                    flpArrets.Controls.Add(panel);
                }

                flpArrets.ResumeLayout();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'affichage des arrêts : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                flpArrets.ResumeLayout();
            }
        }

        private Panel CreerCarteArret(dynamic arret)
        {
            // Créer un panel pour la carte
            Panel panel = new Panel
            {
                Width = 430,
                Height = 80,
                Margin = new Padding(5),
                BorderStyle = BorderStyle.FixedSingle,
                Tag = arret
            };

            // Ajouter les informations de l'arrêt
            Label lblOrdre = new Label
            {
                Text = $"#{arret.Ordre}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(10, 10)
            };
            panel.Controls.Add(lblOrdre);

            Label lblNom = new Label
            {
                Text = arret.Nom,
                Font = new Font("Segoe UI", 10),
                AutoSize = true,
                Location = new Point(50, 10)
            };
            panel.Controls.Add(lblNom);

            Label lblTempsArret = new Label
            {
                Text = $"Temps d'arrêt: {arret.TempsArret} min",
                Font = new Font("Segoe UI", 9),
                AutoSize = true,
                Location = new Point(50, 35)
            };
            panel.Controls.Add(lblTempsArret);

            Label lblTempsTrajet = new Label
            {
                Text = $"Temps de trajet: {arret.TempsTrajet} min",
                Font = new Font("Segoe UI", 9),
                AutoSize = true,
                Location = new Point(50, 55)
            };
            panel.Controls.Add(lblTempsTrajet);

            // Ajouter un gestionnaire d'événements pour la sélection
            panel.Click += (sender, e) => SelectionnerArret(panel);
            foreach (Control control in panel.Controls)
            {
                control.Click += (sender, e) => SelectionnerArret(panel);
            }

            return panel;
        }

        private void SelectionnerArret(Panel panel)
        {
            // Désélectionner le panel précédemment sélectionné
            if (_selectedArretPanel != null)
            {
                _selectedArretPanel.BackColor = SystemColors.Control;
            }

            // Sélectionner le nouveau panel
            _selectedArretPanel = panel;
            _selectedArretPanel.BackColor = Color.FromArgb(230, 240, 250);
        }

        private void ViderChamps()
        {
            txtId.Text = string.Empty;
            txtNumero.Text = string.Empty;
            txtNom.Text = string.Empty;
            txtCouleur.Text = "#FF0000"; // Rouge par défaut
            chkEstActif.Checked = true;
            _ligneSelectionnee = null;
            btnSupprimer.Enabled = false;
            flpArrets.Controls.Clear();

            // Désélectionner les panels
            if (_selectedLignePanel != null)
            {
                _selectedLignePanel.BackColor = SystemColors.Control;
                _selectedLignePanel = null;
            }

            if (_selectedArretPanel != null)
            {
                _selectedArretPanel.BackColor = SystemColors.Control;
                _selectedArretPanel = null;
            }
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            ViderChamps();
            tabDetails.SelectedIndex = 0; // Afficher l'onglet "Informations"
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNumero.Text) || string.IsNullOrWhiteSpace(txtNom.Text))
                {
                    MessageBox.Show("Le numéro et le nom de la ligne sont obligatoires.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_ligneSelectionnee == null)
                {
                    // Nouvelle ligne
                    Ligne nouvelleLigne = new Ligne
                    {
                        Numero = txtNumero.Text,
                        Nom = txtNom.Text,
                        Couleur = txtCouleur.Text,
                        EstActif = chkEstActif.Checked
                    };

                    int id = _serviceLigne.Ajouter(nouvelleLigne);
                    MessageBox.Show("Ligne ajoutée avec succès.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Modification d'une ligne existante
                    _ligneSelectionnee.Numero = txtNumero.Text;
                    _ligneSelectionnee.Nom = txtNom.Text;
                    _ligneSelectionnee.Couleur = txtCouleur.Text;
                    _ligneSelectionnee.EstActif = chkEstActif.Checked;

                    bool resultat = _serviceLigne.Modifier(_ligneSelectionnee);
                    if (resultat)
                    {
                        MessageBox.Show("Ligne modifiée avec succès.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de la modification de la ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                ChargerLignes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (_ligneSelectionnee != null)
            {
                DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cette ligne ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        bool resultat = _serviceLigne.Supprimer(_ligneSelectionnee.Id);
                        if (resultat)
                        {
                            MessageBox.Show("Ligne supprimée avec succès.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ChargerLignes();
                        }
                        else
                        {
                            MessageBox.Show("Erreur lors de la suppression de la ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnCouleur_Click(object sender, EventArgs e)
        {
            try
            {
                // Initialiser la boîte de dialogue avec la couleur actuelle
                if (!string.IsNullOrEmpty(txtCouleur.Text) && txtCouleur.Text.StartsWith("#"))
                {
                    string hexColor = txtCouleur.Text.TrimStart('#');
                    if (hexColor.Length == 6)
                    {
                        int r = Convert.ToInt32(hexColor.Substring(0, 2), 16);
                        int g = Convert.ToInt32(hexColor.Substring(2, 2), 16);
                        int b = Convert.ToInt32(hexColor.Substring(4, 2), 16);
                        colorDialog.Color = Color.FromArgb(r, g, b);
                    }
                }

                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    Color color = colorDialog.Color;
                    txtCouleur.Text = $"#{color.R:X2}{color.G:X2}{color.B:X2}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la sélection de la couleur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAjouterArret_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ligneSelectionnee == null)
                {
                    MessageBox.Show("Veuillez d'abord sélectionner ou créer une ligne.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cboArret.SelectedItem == null)
                {
                    MessageBox.Show("Veuillez sélectionner un arrêt.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int arretId = (int)cboArret.SelectedValue;
                int ordre = (int)nudOrdre.Value;
                int tempsArretMinutes = (int)nudTempsArret.Value;
                int tempsTrajetSuivantMinutes = (int)nudTempsTrajet.Value;

                // Vérifier si l'arrêt est déjà dans la ligne
                if (_ligneSelectionnee.Arrets.Any(a => a.ArretId == arretId))
                {
                    MessageBox.Show("Cet arrêt est déjà dans la ligne.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Créer un nouvel arrêt de ligne
                ArretLigne arretLigne = new ArretLigne
                {
                    LigneId = _ligneSelectionnee.Id,
                    ArretId = arretId,
                    Ordre = ordre,
                    TempsArretMinutes = tempsArretMinutes,
                    TempsTrajetSuivantMinutes = tempsTrajetSuivantMinutes
                };

                // Ajouter l'arrêt à la ligne
                bool resultat = _serviceLigne.AjouterArret(arretLigne);
                if (resultat)
                {
                    MessageBox.Show("Arrêt ajouté à la ligne avec succès.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Rafraîchir la ligne sélectionnée
                    _ligneSelectionnee = _serviceLigne.ObtenirParId(_ligneSelectionnee.Id, true);
                    AfficherArrets();
                }
                else
                {
                    MessageBox.Show("Erreur lors de l'ajout de l'arrêt à la ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSupprimerArret_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedArretPanel == null)
                {
                    MessageBox.Show("Veuillez sélectionner un arrêt à supprimer.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dynamic arret = _selectedArretPanel.Tag;
                int arretLigneId = arret.Id;

                DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet arrêt de la ligne ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    bool resultat = _serviceLigne.SupprimerArret(arretLigneId);
                    if (resultat)
                    {
                        MessageBox.Show("Arrêt supprimé de la ligne avec succès.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //  "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Rafraîchir la ligne sélectionnée
                        _ligneSelectionnee = _serviceLigne.ObtenirParId(_ligneSelectionnee.Id, true);
                        AfficherArrets();
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de la suppression de l'arrêt de la ligne.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DebugAffichageArrets()
        {
            if (_ligneSelectionnee == null)
            {
                MessageBox.Show("Aucune ligne sélectionnée", "Debug");
                return;
            }

            string debug = $"Ligne ID: {_ligneSelectionnee.Id}\n";
            debug += $"Ligne Nom: {_ligneSelectionnee.Nom}\n";
            debug += $"Nombre d'arrêts: {(_ligneSelectionnee.Arrets?.Count ?? 0)}\n";

            if (_ligneSelectionnee.Arrets != null)
            {
                foreach (var arret in _ligneSelectionnee.Arrets)
                {
                    debug += $"- Arrêt ID: {arret.ArretId}, Ordre: {arret.Ordre}\n";
                }
            }

            MessageBox.Show(debug, "Debug Arrêts");
        }

        private void btnExporterCsv_Click(object sender, EventArgs e)
        {
            var lignes = _serviceLigne.ObtenirToutes();
            var sb = new StringBuilder();
            sb.AppendLine("Id,Numero,Nom,Couleur");
            foreach (var l in lignes)
                sb.AppendLine($"{l.Id},{l.Numero},{l.Nom},{l.Couleur}");
            using (var sfd = new SaveFileDialog { Filter = "CSV (*.csv)|*.csv", FileName = "lignes.csv" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
            }
        }

        private void btnExporterJson_Click(object sender, EventArgs e)
        {
            var lignes = _serviceLigne.ObtenirToutes();
            using (var sfd = new SaveFileDialog { Filter = "JSON (*.json)|*.json", FileName = "lignes.json" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                    File.WriteAllText(sfd.FileName, JsonSerializer.Serialize(lignes, new JsonSerializerOptions { WriteIndented = true }), Encoding.UTF8);
            }
        }

    }
}
