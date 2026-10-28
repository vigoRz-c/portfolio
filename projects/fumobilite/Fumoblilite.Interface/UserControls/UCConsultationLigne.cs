using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using Fumoblilite.Systeme.Modeles;
using Fumoblilite.Systeme.Services;
using Fumoblilite.SQL.Repositories;
using Fumoblilite.Systeme.Interfaces;
using System.Linq;

namespace Fumoblilite.Interface.UserControls
{
    public partial class UCConsultationLigne : UserControl
    {
        private readonly string _connectionString;
        private readonly ServiceLigne _serviceLigne;
        private readonly ServiceArret _serviceArret;
        private readonly ServiceHoraire _serviceHoraire;

        private Ligne _ligneSelectionnee;
        private List<ArretLigne> _arretsAffiches;
        private List<Horaire> _horairesAffiches;

        // Couleurs pour le design moderne
        private readonly Color _couleurPrimaire = Color.FromArgb(0, 120, 215);
        private readonly Color _couleurSecondaire = Color.FromArgb(0, 99, 177);
        private readonly Color _couleurAccent = Color.FromArgb(255, 185, 0);
        private readonly Color _couleurTexte = Color.FromArgb(51, 51, 51);
        private readonly Color _couleurFond = Color.White;
        private readonly Color _couleurFondAlterne = Color.FromArgb(245, 245, 245);
        private readonly Color _couleurBordure = Color.FromArgb(200, 200, 200);

        public UCConsultationLigne(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;

            // Initialisation des repositories
            IRepositoryLigne repositoryLigne = new RepositoryLigne(_connectionString);
            IRepositoryArret repositoryArret = new RepositoryArret(_connectionString);
            IRepositoryArretLigne repositoryArretLigne = new RepositoryArretLigne(_connectionString, repositoryArret);
            IRepositoryHoraire repositoryHoraire = new RepositoryHoraire(_connectionString);

            // Initialisation des services
            _serviceLigne = new ServiceLigne(repositoryLigne, repositoryArretLigne);
            _serviceArret = new ServiceArret(repositoryArret);
            _serviceHoraire = new ServiceHoraire(repositoryHoraire);
        }

        private void UCConsultationLigne_Load(object sender, EventArgs e)
        {
            // Appliquer le style moderne
            StyleModerne();

            // Charger les lignes et les jours lors du chargement du contrôle
            ChargerLignes();
            ChargerJours();
        }

        private void StyleModerne()
        {
            // Style du titre
            lblTitre.ForeColor = _couleurPrimaire;
            lblTitre.Font = new Font("Segoe UI", 16, FontStyle.Bold);

            // Style des labels
            lblLigne.Font = new Font("Segoe UI", 9);
            lblLigne.ForeColor = _couleurTexte;

            // Style du combobox
            cboLigne.Font = new Font("Segoe UI", 9);
            cboLigne.FlatStyle = FlatStyle.Flat;

            // Style du bouton
            btnAfficher.FlatStyle = FlatStyle.Flat;
            btnAfficher.BackColor = _couleurPrimaire;
            btnAfficher.ForeColor = Color.White;
            btnAfficher.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btnAfficher.FlatAppearance.BorderSize = 0;
            btnAfficher.Cursor = Cursors.Hand;

            // Style des onglets
            tabDetails.Font = new Font("Segoe UI", 9);

            // Style des panneaux d'en-tête
            pnlHeaderArrets.BackColor = _couleurPrimaire;
            pnlHeaderHoraires.BackColor = _couleurPrimaire;

            foreach (Label lbl in pnlHeaderArrets.Controls.OfType<Label>())
            {
                lbl.ForeColor = Color.White;
                lbl.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            }

            foreach (Label lbl in pnlHeaderHoraires.Controls.OfType<Label>())
            {
                lbl.ForeColor = Color.White;
                lbl.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            }

            // Style des FlowLayoutPanels
            flpArrets.BackColor = _couleurFond;
            flpHoraires.BackColor = _couleurFond;

            // Style du combobox de jour
            cboJour.Font = new Font("Segoe UI", 9);
            cboJour.FlatStyle = FlatStyle.Flat;
            lblJour.Font = new Font("Segoe UI", 9);
            lblJour.ForeColor = _couleurTexte;
        }

        private void ChargerLignes()
        {
            try
            {
                // Obtenir toutes les lignes et les assigner à la source de données du comboBox
                List<Ligne> lignes = _serviceLigne.ObtenirToutes();

                cboLigne.DisplayMember = "Nom";
                cboLigne.ValueMember = "Id";
                cboLigne.DataSource = lignes;
            }
            catch (Exception ex)
            {
                // Afficher un message d'erreur en cas d'exception
                MessageBox.Show($"Erreur lors du chargement des lignes : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChargerJours()
        {
            try
            {
                // Créer une liste des jours de la semaine
                var jours = new List<KeyValuePair<DayOfWeek, string>>
                    {
                        new KeyValuePair<DayOfWeek, string>(DayOfWeek.Monday, "Lundi"),
                        new KeyValuePair<DayOfWeek, string>(DayOfWeek.Tuesday, "Mardi"),
                        new KeyValuePair<DayOfWeek, string>(DayOfWeek.Wednesday, "Mercredi"),
                        new KeyValuePair<DayOfWeek, string>(DayOfWeek.Thursday, "Jeudi"),
                        new KeyValuePair<DayOfWeek, string>(DayOfWeek.Friday, "Vendredi"),
                        new KeyValuePair<DayOfWeek, string>(DayOfWeek.Saturday, "Samedi"),
                        new KeyValuePair<DayOfWeek, string>(DayOfWeek.Sunday, "Dimanche")
                    };

                cboJour.DisplayMember = "Value";
                cboJour.ValueMember = "Key";
                cboJour.DataSource = jours;

                // Sélectionner le jour actuel
                cboJour.SelectedValue = DateTime.Today.DayOfWeek;
            }
            catch (Exception ex)
            {
                // Afficher un message d'erreur en cas d'exception
                MessageBox.Show($"Erreur lors du chargement des jours : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAfficher_Click(object sender, EventArgs e)
        {
            if (cboLigne.SelectedItem == null)
            {
                // Afficher un message d'avertissement si aucune ligne n'est sélectionnée
                MessageBox.Show("Veuillez sélectionner une ligne.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Obtenir l'ID de la ligne sélectionnée et charger ses détails
                int ligneId = (int)cboLigne.SelectedValue;
                _ligneSelectionnee = _serviceLigne.ObtenirParId(ligneId, true);

                if (_ligneSelectionnee == null)
                {
                    // Afficher un message d'erreur si la ligne sélectionnée n'existe pas
                    MessageBox.Show("La ligne sélectionnée n'existe pas.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Afficher les arrêts et les horaires de la ligne sélectionnée
                AfficherArrets();
                AfficherHoraires();
            }
            catch (Exception ex)
            {
                // Afficher un message d'erreur en cas d'exception
                MessageBox.Show($"Erreur lors de l'affichage des détails de la ligne : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AfficherArrets()
        {
            try
            {
                flpArrets.Controls.Clear();

                if (_ligneSelectionnee == null || _ligneSelectionnee.Arrets == null)
                {
                    return;
                }

                // Récupérer les informations des arrêts
                var arrets = _serviceArret.ObtenirTous().ToDictionary(a => a.Id);

                // Préparer les données pour l'affichage
                _arretsAffiches = _ligneSelectionnee.Arrets.OrderBy(al => al.Ordre).ToList();

                bool alternerCouleur = false;

                foreach (var arretLigne in _arretsAffiches)
                {
                    if (!arrets.ContainsKey(arretLigne.ArretId))
                        continue;

                    var arret = arrets[arretLigne.ArretId];

                    // Créer un panel pour l'arrêt
                    Panel pnlArret = new Panel
                    {
                        Width = flpArrets.Width - 25,
                        Height = 80,
                        Margin = new Padding(0, 0, 0, 5),
                        BackColor = alternerCouleur ? _couleurFondAlterne : _couleurFond,
                        Padding = new Padding(10)
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

                    // Ajouter l'ordre
                    Label lblOrdre = new Label
                    {
                        Text = arretLigne.Ordre.ToString(),
                        Font = new Font("Segoe UI", 12, FontStyle.Bold),
                        ForeColor = _couleurPrimaire,
                        AutoSize = true,
                        Location = new Point(15, 10)
                    };
                    pnlArret.Controls.Add(lblOrdre);

                    // Ajouter le nom de l'arrêt
                    Label lblNom = new Label
                    {
                        Text = arret.Nom,
                        Font = new Font("Segoe UI", 10, FontStyle.Bold),
                        ForeColor = _couleurTexte,
                        AutoSize = true,
                        Location = new Point(50, 10)
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

                    // Ajouter les temps
                    Label lblTemps = new Label
                    {
                        Text = $"Temps d'arrêt: {arretLigne.TempsArretMinutes} min | Temps vers prochain: {arretLigne.TempsTrajetSuivantMinutes} min",
                        Font = new Font("Segoe UI", 8),
                        ForeColor = Color.DarkGray,
                        AutoSize = true,
                        Location = new Point(50, 50)
                    };
                    pnlArret.Controls.Add(lblTemps);

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
                        ((Panel)s).BackColor = alternerCouleur ? _couleurFondAlterne : _couleurFond;
                    };

                    flpArrets.Controls.Add(pnlArret);
                    alternerCouleur = !alternerCouleur;
                }
            }
            catch (Exception ex)
            {
                // Afficher un message d'erreur en cas d'exception
                MessageBox.Show($"Erreur lors de l'affichage des arrêts : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AfficherHoraires()
        {
            try
            {
                flpHoraires.Controls.Clear();

                if (_ligneSelectionnee == null)
                {
                    return;
                }

                // Obtenir le jour sélectionné
                DayOfWeek jour = (DayOfWeek)cboJour.SelectedValue;

                // Récupérer les horaires de la ligne pour le jour sélectionné
                _horairesAffiches = _serviceHoraire.ObtenirParLigneEtJour(_ligneSelectionnee.Id, jour);

                if (_horairesAffiches.Count == 0)
                {
                    Label lblAucunHoraire = new Label
                    {
                        Text = "Aucun horaire disponible pour ce jour.",
                        Font = new Font("Segoe UI", 10),
                        ForeColor = _couleurTexte,
                        AutoSize = true,
                        Margin = new Padding(10)
                    };
                    flpHoraires.Controls.Add(lblAucunHoraire);
                    return;
                }

                // Récupérer les informations des arrêts
                var arrets = _serviceArret.ObtenirTous().ToDictionary(a => a.Id);

                // Regrouper les horaires par arrêt
                var horairesParArret = _horairesAffiches
                    .GroupBy(h => h.ArretId)
                    .OrderBy(g => g.Key);

                bool alternerCouleur = false;

                foreach (var groupe in horairesParArret)
                {
                    if (!arrets.ContainsKey(groupe.Key))
                        continue;

                    var arret = arrets[groupe.Key];

                    // Créer un panel pour l'arrêt
                    Panel pnlArret = new Panel
                    {
                        Width = flpHoraires.Width - 25,
                        Height = 100,
                        Margin = new Padding(0, 0, 0, 10),
                        BackColor = alternerCouleur ? _couleurFondAlterne : _couleurFond,
                        Padding = new Padding(10)
                    };

                    // Ajouter une bordure colorée à gauche
                    Panel pnlBordure = new Panel
                    {
                        Width = 5,
                        Height = 100,
                        BackColor = _couleurPrimaire,
                        Dock = DockStyle.Left
                    };
                    pnlArret.Controls.Add(pnlBordure);

                    // Ajouter le nom de l'arrêt
                    Label lblNom = new Label
                    {
                        Text = arret.Nom,
                        Font = new Font("Segoe UI", 11, FontStyle.Bold),
                        ForeColor = _couleurTexte,
                        AutoSize = true,
                        Location = new Point(15, 10)
                    };
                    pnlArret.Controls.Add(lblNom);

                    // Ajouter un FlowLayoutPanel pour les heures
                    FlowLayoutPanel flpHeures = new FlowLayoutPanel
                    {
                        FlowDirection = FlowDirection.LeftToRight,
                        WrapContents = true,
                        Width = pnlArret.Width - 30,
                        Height = 50,
                        Location = new Point(15, 40),
                        BackColor = Color.Transparent
                    };
                    pnlArret.Controls.Add(flpHeures);

                    // Ajouter les heures
                    foreach (var horaire in groupe.OrderBy(h => h.HeureDepart))
                    {
                        Panel pnlHeure = new Panel
                        {
                            Width = 70,
                            Height = 30,
                            Margin = new Padding(0, 0, 5, 5),
                            BackColor = horaire.EstActif ? Color.FromArgb(240, 240, 250) : Color.FromArgb(245, 245, 245),
                            BorderStyle = BorderStyle.FixedSingle
                        };

                        Label lblHeure = new Label
                        {
                            Text = horaire.HeureDepart.ToString(@"hh\:mm"),
                            Font = new Font("Segoe UI", 9, horaire.EstActif ? FontStyle.Bold : FontStyle.Regular),
                            ForeColor = horaire.EstActif ? _couleurPrimaire : Color.Gray,
                            TextAlign = ContentAlignment.MiddleCenter,
                            Dock = DockStyle.Fill
                        };
                        pnlHeure.Controls.Add(lblHeure);

                        flpHeures.Controls.Add(pnlHeure);
                    }

                    // Ajouter des effets de survol
                    pnlArret.MouseEnter += (s, ev) => {
                        ((Panel)s).BackColor = Color.FromArgb(240, 240, 250);
                    };
                    pnlArret.MouseLeave += (s, ev) => {
                        ((Panel)s).BackColor = alternerCouleur ? _couleurFondAlterne : _couleurFond;
                    };

                    flpHoraires.Controls.Add(pnlArret);
                    alternerCouleur = !alternerCouleur;
                }
            }
            catch (Exception ex)
            {
                // Afficher un message d'erreur en cas d'exception
                MessageBox.Show($"Erreur lors de l'affichage des horaires : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboJour_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_ligneSelectionnee != null)
            {
                // Afficher les horaires lorsque le jour sélectionné change
                AfficherHoraires();
            }
        }
    }
}
