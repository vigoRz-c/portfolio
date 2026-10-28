using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using Fumoblilite.Systeme.Modeles;
using Fumoblilite.Systeme.Services;
using Fumoblilite.SQL.Repositories;
using System.Text.Json;
using System.Text;
using System.IO;

namespace Fumoblilite.Interface.UserControls
{
    public partial class UCGestionArrets : UserControl
    {
        private readonly string _connectionString;
        private readonly ServiceArret _serviceArret;
        private Arret _arretSelectionne;
        private List<Arret> _arrets;

        private readonly Color _couleurPrimaire = Color.FromArgb(0, 120, 215);
        private readonly Color _couleurSecondaire = Color.FromArgb(0, 99, 177);
        private readonly Color _couleurAccent = Color.FromArgb(255, 185, 0);
        private readonly Color _couleurTexte = Color.FromArgb(51, 51, 51);
        private readonly Color _couleurFond = Color.White;
        private readonly Color _couleurFondAlterne = Color.FromArgb(245, 245, 245);
        private readonly Color _couleurBordure = Color.FromArgb(200, 200, 200);

        public UCGestionArrets(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;

            var repositoryArret = new RepositoryArret(_connectionString);
            _serviceArret = new ServiceArret(repositoryArret);
        }

        private void UCGestionArrets_Load(object sender, EventArgs e)
        {
            // Appliquer le style moderne
            StyleModerne();

            ChargerArrets();
        }

        private void StyleModerne()
        {
            // Style du titre
            lblTitre.ForeColor = _couleurPrimaire;
            lblTitre.Font = new Font("Segoe UI", 16, FontStyle.Bold);

            // Style des labels dans le groupe de détails
            foreach (Control ctrl in grpDetails.Controls)
            {
                if (ctrl is Label)
                {
                    ctrl.Font = new Font("Segoe UI", 9);
                    ctrl.ForeColor = _couleurTexte;
                }
                else if (ctrl is TextBox)
                {
                    ctrl.Font = new Font("Segoe UI", 9);
                    ((TextBox)ctrl).BorderStyle = BorderStyle.FixedSingle;
                }
            }

            // Style du groupe de détails
            grpDetails.Font = new Font("Segoe UI", 9);
            grpDetails.ForeColor = _couleurTexte;

            // Style des boutons
            btnNouveau.FlatStyle = FlatStyle.Flat;
            btnNouveau.BackColor = Color.FromArgb(240, 240, 240);
            btnNouveau.ForeColor = _couleurTexte;
            btnNouveau.Font = new Font("Segoe UI", 9);
            btnNouveau.FlatAppearance.BorderColor = _couleurBordure;
            btnNouveau.Cursor = Cursors.Hand;

            btnEnregistrer.FlatStyle = FlatStyle.Flat;
            btnEnregistrer.BackColor = _couleurPrimaire;
            btnEnregistrer.ForeColor = Color.White;
            btnEnregistrer.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btnEnregistrer.FlatAppearance.BorderSize = 0;
            btnEnregistrer.Cursor = Cursors.Hand;

            btnSupprimer.FlatStyle = FlatStyle.Flat;
            btnSupprimer.BackColor = Color.FromArgb(232, 17, 35);
            btnSupprimer.ForeColor = Color.White;
            btnSupprimer.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btnSupprimer.FlatAppearance.BorderSize = 0;
            btnSupprimer.Cursor = Cursors.Hand;

            // Style du panel d'en-tête
            pnlHeader.BackColor = _couleurPrimaire;

            foreach (Label lbl in pnlHeader.Controls)
            {
                lbl.ForeColor = Color.White;
                lbl.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            }

            // Style du FlowLayoutPanel
            flpArrets.BackColor = _couleurFond;
        }

        private void ChargerArrets()
        {
            try
            {
                _arrets = _serviceArret.ObtenirTous();
                AfficherArrets();
                ViderChamps();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des arrêts : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AfficherArrets()
        {
            flpArrets.Controls.Clear();

            if (_arrets == null || _arrets.Count == 0)
            {
                Label lblAucunArret = new Label
                {
                    Text = "Aucun arrêt disponible.",
                    Font = new Font("Segoe UI", 10),
                    ForeColor = _couleurTexte,
                    AutoSize = true,
                    Margin = new Padding(10)
                };
                flpArrets.Controls.Add(lblAucunArret);
                return;
            }

            bool alternerCouleur = false;

            foreach (var arret in _arrets)
            {
                // Créer un panel pour l'arrêt
                Panel pnlArret = new Panel
                {
                    Width = flpArrets.Width - 25,
                    Height = 80,
                    Margin = new Padding(0, 0, 0, 5),
                    BackColor = alternerCouleur ? _couleurFondAlterne : _couleurFond,
                    Padding = new Padding(10),
                    Tag = arret // Stocker l'objet arret pour la sélection
                };

                // Ajouter une bordure colorée à gauche
                Panel pnlBordure = new Panel
                {
                    Width = 5,
                    Height = 80,
                    BackColor = arret.EstAccessible ? _couleurPrimaire : _couleurBordure,
                    Dock = DockStyle.Left
                };
                pnlArret.Controls.Add(pnlBordure);

                // Ajouter l'ID
                Label lblId = new Label
                {
                    Text = arret.Id.ToString(),
                    Font = new Font("Segoe UI", 9),
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    Location = new Point(15, 10)
                };
                pnlArret.Controls.Add(lblId);

                // Ajouter le nom de l'arrêt
                Label lblNom = new Label
                {
                    Text = arret.Nom,
                    Font = new Font("Segoe UI", 11, FontStyle.Bold),
                    ForeColor = _couleurTexte,
                    AutoSize = true,
                    Location = new Point(50, 8)
                };
                pnlArret.Controls.Add(lblNom);

                // Ajouter l'adresse
                Label lblAdresse = new Label
                {
                    Text = arret.Adresse,
                    Font = new Font("Segoe UI", 8),
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    Location = new Point(50, 30)
                };
                pnlArret.Controls.Add(lblAdresse);

                // Ajouter les coordonnées
                Label lblCoords = new Label
                {
                    Text = $"Lat: {arret.Latitude}, Long: {arret.Longitude}",
                    Font = new Font("Segoe UI", 8),
                    ForeColor = Color.DarkGray,
                    AutoSize = true,
                    Location = new Point(50, 50)
                };
                pnlArret.Controls.Add(lblCoords);

                // Ajouter un indicateur d'accessibilité
                if (arret.EstAccessible)
                {
                    Label lblAccessible = new Label
                    {
                        Text = "♿",
                        Font = new Font("Segoe UI", 12),
                        ForeColor = _couleurPrimaire,
                        AutoSize = true,
                        Location = new Point(pnlArret.Width - 40, 10)
                    };
                    pnlArret.Controls.Add(lblAccessible);
                }

                // Ajouter des effets de survol
                pnlArret.MouseEnter += (s, ev) => {
                    ((Panel)s).BackColor = Color.FromArgb(240, 240, 250);
                };
                pnlArret.MouseLeave += (s, ev) => {
                    if (_arretSelectionne != null && _arretSelectionne.Id == ((Arret)((Panel)s).Tag).Id)
                    {
                        ((Panel)s).BackColor = _couleurPrimaire.GetBrightness() > 0.5 ? Color.FromArgb(230, 240, 250) : Color.FromArgb(0, 120, 215, 40);
                    }
                    else
                    {
                        ((Panel)s).BackColor = alternerCouleur ? _couleurFondAlterne : _couleurFond;
                    }
                };

                // Ajouter un événement de clic pour la sélection
                pnlArret.Click += (s, ev) => {
                    SelectionnerArret((Arret)((Panel)s).Tag);

                    // Mettre à jour l'apparence de tous les panneaux
                    foreach (Panel p in flpArrets.Controls)
                    {
                        if (p.Tag != null && p.Tag is Arret)
                        {
                            bool isSelected = _arretSelectionne != null && _arretSelectionne.Id == ((Arret)p.Tag).Id;
                            p.BackColor = isSelected
                                ? _couleurPrimaire.GetBrightness() > 0.5 ? Color.FromArgb(230, 240, 250) : Color.FromArgb(0, 120, 215, 40)
                                : (p == s) ? Color.FromArgb(240, 240, 250) : (flpArrets.Controls.IndexOf(p) % 2 == 1) ? _couleurFondAlterne : _couleurFond;
                        }
                    }
                };

                flpArrets.Controls.Add(pnlArret);
                alternerCouleur = !alternerCouleur;
            }
        }

        private void SelectionnerArret(Arret arret)
        {
            _arretSelectionne = arret;
            if (_arretSelectionne != null)
            {
                txtId.Text = _arretSelectionne.Id.ToString();
                txtNom.Text = _arretSelectionne.Nom;
                txtAdresse.Text = _arretSelectionne.Adresse;
                txtLatitude.Text = _arretSelectionne.Latitude.ToString();
                txtLongitude.Text = _arretSelectionne.Longitude.ToString();
                chkEstAccessible.Checked = _arretSelectionne.EstAccessible;
                btnSupprimer.Enabled = true;
            }
        }

        private void ViderChamps()
        {
            txtId.Text = string.Empty;
            txtNom.Text = string.Empty;
            txtAdresse.Text = string.Empty;
            txtLatitude.Text = string.Empty;
            txtLongitude.Text = string.Empty;
            chkEstAccessible.Checked = false;
            _arretSelectionne = null;
            btnSupprimer.Enabled = false;

            // Réinitialiser l'apparence des panneaux
            foreach (Panel p in flpArrets.Controls)
            {
                if (p.Tag != null && p.Tag is Arret)
                {
                    p.BackColor = (flpArrets.Controls.IndexOf(p) % 2 == 1) ? _couleurFondAlterne : _couleurFond;
                }
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
                if (string.IsNullOrWhiteSpace(txtNom.Text))
                {
                    MessageBox.Show("Le nom de l'arrêt est obligatoire.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                double latitude, longitude;
                if (!double.TryParse(txtLatitude.Text, out latitude) || !double.TryParse(txtLongitude.Text, out longitude))
                {
                    MessageBox.Show("Les coordonnées doivent être des nombres valides.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_arretSelectionne == null)
                {
                    // Nouvel arrêt
                    Arret nouvelArret = new Arret
                    {
                        Nom = txtNom.Text,
                        Adresse = txtAdresse.Text,
                        Latitude = latitude,
                        Longitude = longitude,
                        EstAccessible = chkEstAccessible.Checked
                    };

                    int id = _serviceArret.Ajouter(nouvelArret);
                    MessageBox.Show("Arrêt ajouté avec succès.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Modification d'un arrêt existant
                    _arretSelectionne.Nom = txtNom.Text;
                    _arretSelectionne.Adresse = txtAdresse.Text;
                    _arretSelectionne.Latitude = latitude;
                    _arretSelectionne.Longitude = longitude;
                    _arretSelectionne.EstAccessible = chkEstAccessible.Checked;

                    bool resultat = _serviceArret.Modifier(_arretSelectionne);
                    if (resultat)
                    {
                        MessageBox.Show("Arrêt modifié avec succès.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de la modification de l'arrêt.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                ChargerArrets();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (_arretSelectionne != null)
            {
                DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet arrêt ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        bool resultat = _serviceArret.Supprimer(_arretSelectionne.Id);
                        if (resultat)
                        {
                            MessageBox.Show("Arrêt supprimé avec succès.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ChargerArrets();
                        }
                        else
                        {
                            MessageBox.Show("Erreur lors de la suppression de l'arrêt.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnExporterCsv_Click(object sender, EventArgs e)
        {
            var arrets = _serviceArret.ObtenirTous();
            var sb = new StringBuilder();
            sb.AppendLine("Id,Nom,Adresse,Latitude,Longitude,EstAccessible,DateCreation,DateModification");
            foreach (var a in arrets)
                sb.AppendLine($"{a.Id},{a.Nom},{a.Adresse},{a.Latitude},{a.Longitude},{a.EstAccessible},{a.DateCreation:yyyy-MM-dd HH:mm:ss},{(a.DateModification.HasValue ? a.DateModification.Value.ToString("yyyy-MM-dd HH:mm:ss") : "")}");
            using (var sfd = new SaveFileDialog { Filter = "CSV (*.csv)|*.csv", FileName = "arrets.csv" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
            }
        }

        private void btnExporterJson_Click(object sender, EventArgs e)
        {
            var arrets = _serviceArret.ObtenirTous();
            using (var sfd = new SaveFileDialog { Filter = "JSON (*.json)|*.json", FileName = "arrets.json" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                    File.WriteAllText(sfd.FileName, JsonSerializer.Serialize(arrets, new JsonSerializerOptions { WriteIndented = true }), Encoding.UTF8);
            }
        }

    }
}
