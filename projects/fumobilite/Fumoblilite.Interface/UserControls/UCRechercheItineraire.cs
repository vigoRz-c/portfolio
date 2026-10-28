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
    public partial class UCRechercheItineraire : UserControl
    {
        private readonly string _connectionString;
        private readonly ServiceItineraire _serviceItineraire;
        private readonly ServiceArret _serviceArret;
        private readonly ServiceLigne _serviceLigne;
        private Panel _selectedItinerairePanel;

        public UCRechercheItineraire(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;

            // Initialisation des repositories
            IRepositoryArret repositoryArret = new RepositoryArret(_connectionString);
            IRepositoryLigne repositoryLigne = new RepositoryLigne(_connectionString);
            IRepositoryArretLigne repositoryArretLigne = new RepositoryArretLigne(_connectionString, repositoryArret);
            IRepositoryHoraire repositoryHoraire = new RepositoryHoraire(_connectionString);

            // Initialisation des services
            _serviceArret = new ServiceArret(repositoryArret);
            _serviceLigne = new ServiceLigne(repositoryLigne, repositoryArretLigne);
            _serviceItineraire = new ServiceItineraire(repositoryArret, repositoryLigne, repositoryArretLigne, repositoryHoraire);
        }

        private void UCRechercheItineraire_Load(object sender, EventArgs e)
        {
            ChargerArrets();
            dtpDate.Value = DateTime.Today;
            dtpHeure.Value = DateTime.Now;
        }

        private void ChargerArrets()
        {
            try
            {
                List<Arret> arrets = _serviceArret.ObtenirTous();

                // Configuration du ComboBox de départ
                cboArretDepart.DisplayMember = "Nom";
                cboArretDepart.ValueMember = "Id";
                cboArretDepart.DataSource = new List<Arret>(arrets);

                // Configuration du ComboBox d'arrivée
                cboArretArrivee.DisplayMember = "Nom";
                cboArretArrivee.ValueMember = "Id";
                cboArretArrivee.DataSource = new List<Arret>(arrets);

                if (arrets.Count > 1)
                {
                    cboArretArrivee.SelectedIndex = 1; // Sélectionner le deuxième arrêt par défaut
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des arrêts : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboArretDepart.SelectedItem == null || cboArretArrivee.SelectedItem == null)
                {
                    MessageBox.Show("Veuillez sélectionner les arrêts de départ et d'arrivée.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int arretDepartId = (int)cboArretDepart.SelectedValue;
                int arretArriveeId = (int)cboArretArrivee.SelectedValue;

                if (arretDepartId == arretArriveeId)
                {
                    MessageBox.Show("Les arrêts de départ et d'arrivée doivent être différents.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Combiner la date et l'heure
                DateTime dateHeure = dtpDate.Value.Date.Add(dtpHeure.Value.TimeOfDay);
                bool estHeureDepart = rbDepart.Checked;

                // Rechercher les itinéraires
                List<Itineraire> itineraires = _serviceItineraire.RechercherItineraires(arretDepartId, arretArriveeId, dateHeure, estHeureDepart);

                if (itineraires.Count == 0)
                {
                    MessageBox.Show("Aucun itinéraire trouvé pour les critères spécifiés.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    flpItineraires.Controls.Clear();
                    pnlDetailsItineraire.Controls.Clear();
                    Label lblAucun = new Label
                    {
                        Text = "Aucun itinéraire trouvé",
                        AutoSize = true,
                        Location = new Point(10, 10)
                    };
                    pnlDetailsItineraire.Controls.Add(lblAucun);
                    return;
                }

                // Afficher les itinéraires
                AfficherItineraires(itineraires);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la recherche d'itinéraires : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AfficherItineraires(List<Itineraire> itineraires)
        {
            flpItineraires.SuspendLayout();
            flpItineraires.Controls.Clear();
            _selectedItinerairePanel = null;

            foreach (var itineraire in itineraires)
            {
                Panel panel = CreerCarteItineraire(itineraire);
                flpItineraires.Controls.Add(panel);
            }

            flpItineraires.ResumeLayout();

            // Sélectionner le premier itinéraire
            if (flpItineraires.Controls.Count > 0)
            {
                SelectionnerItineraire((Panel)flpItineraires.Controls[0]);
            }
        }

        private Panel CreerCarteItineraire(Itineraire itineraire)
        {
            // Créer un panel pour la carte
            Panel panel = new Panel
            {
                Width = flpItineraires.Width - 25,
                Height = 80,
                Margin = new Padding(5),
                BorderStyle = BorderStyle.FixedSingle,
                Tag = itineraire
            };

            // Ajouter les informations de l'itinéraire
            Label lblHeures = new Label
            {
                Text = $"{itineraire.HeureDepart.ToShortTimeString()} - {itineraire.HeureArrivee.ToShortTimeString()}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(10, 10)
            };
            panel.Controls.Add(lblHeures);

            Label lblDuree = new Label
            {
                Text = $"Durée: {itineraire.DureeMinutes} min",
                Font = new Font("Segoe UI", 9),
                AutoSize = true,
                Location = new Point(10, 35)
            };
            panel.Controls.Add(lblDuree);

            Label lblChangements = new Label
            {
                Text = $"Changements: {itineraire.NombreChangements}",
                Font = new Font("Segoe UI", 9),
                AutoSize = true,
                Location = new Point(10, 55)
            };
            panel.Controls.Add(lblChangements);

            // Ajouter un indicateur visuel pour les changements
            int x = panel.Width - 30;
            for (int i = 0; i < itineraire.Etapes.Count; i++)
            {
                Panel indicateur = new Panel
                {
                    Width = 15,
                    Height = 15,
                    BackColor = ColorTranslator.FromHtml(itineraire.Etapes[i].CouleurLigne ?? "#808080"),
                    Location = new Point(x, 10)
                };
                panel.Controls.Add(indicateur);
                x -= 20;
            }

            // Ajouter un gestionnaire d'événements pour la sélection
            panel.Click += (sender, e) => SelectionnerItineraire(panel);
            foreach (Control control in panel.Controls)
            {
                control.Click += (sender, e) => SelectionnerItineraire(panel);
            }

            return panel;
        }

        private void SelectionnerItineraire(Panel panel)
        {
            // Désélectionner le panel précédemment sélectionné
            if (_selectedItinerairePanel != null)
            {
                _selectedItinerairePanel.BackColor = SystemColors.Control;
            }

            // Sélectionner le nouveau panel
            _selectedItinerairePanel = panel;
            _selectedItinerairePanel.BackColor = Color.FromArgb(230, 240, 250);

            // Récupérer l'itinéraire associé au panel
            Itineraire itineraire = (Itineraire)panel.Tag;

            // Afficher les détails de l'itinéraire
            AfficherDetailsItineraire(itineraire);
        }

        private void AfficherDetailsItineraire(Itineraire itineraire)
        {
            // Créer un contrôle FlowLayoutPanel pour afficher les étapes
            FlowLayoutPanel flpEtapes = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                AutoScroll = true,
                WrapContents = false
            };

            // Ajouter un en-tête
            Panel pnlEnTete = new Panel
            {
                Width = pnlDetailsItineraire.Width - 20,
                Height = 70,
                Margin = new Padding(5),
                BorderStyle = BorderStyle.None
            };

            Label lblEnTete = new Label
            {
                Text = $"Départ : {itineraire.HeureDepart.ToShortTimeString()} - Arrivée : {itineraire.HeureArrivee.ToShortTimeString()}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(5, 5)
            };
            pnlEnTete.Controls.Add(lblEnTete);

            Label lblDuree = new Label
            {
                Text = $"Durée : {itineraire.DureeMinutes} minutes - Changements : {itineraire.NombreChangements}",
                Font = new Font("Segoe UI", 9),
                AutoSize = true,
                Location = new Point(5, 30)
            };
            pnlEnTete.Controls.Add(lblDuree);

            Label lblArrets = new Label
            {
                Text = $"De {itineraire.Etapes.First().NomArretDepart} à {itineraire.Etapes.Last().NomArretArrivee}",
                Font = new Font("Segoe UI", 9),
                AutoSize = true,
                Location = new Point(5, 50)
            };
            pnlEnTete.Controls.Add(lblArrets);

            flpEtapes.Controls.Add(pnlEnTete);

            // Ajouter une ligne de séparation
            Panel pnlSeparator = new Panel
            {
                Height = 1,
                Width = pnlDetailsItineraire.Width - 20,
                BackColor = Color.Gray,
                Margin = new Padding(5)
            };
            flpEtapes.Controls.Add(pnlSeparator);

            // Ajouter chaque étape
            foreach (var etape in itineraire.Etapes)
            {
                // Créer un panel pour l'étape
                Panel pnlEtape = new Panel
                {
                    Width = pnlDetailsItineraire.Width - 30,
                    Height = 100,
                    Margin = new Padding(5),
                    BorderStyle = BorderStyle.FixedSingle
                };

                // Ajouter un indicateur de ligne (couleur)
                Panel pnlLigne = new Panel
                {
                    Width = 10,
                    Height = pnlEtape.Height,
                    Dock = DockStyle.Left,
                    BackColor = ColorTranslator.FromHtml(etape.CouleurLigne ?? "#808080")
                };
                pnlEtape.Controls.Add(pnlLigne);

                // Ajouter les informations de l'étape
                Label lblLigne = new Label
                {
                    Text = $"Ligne {etape.NomLigne}",
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Location = new Point(20, 10),
                    AutoSize = true
                };
                pnlEtape.Controls.Add(lblLigne);

                Label lblArretDepart = new Label
                {
                    Text = $"Départ: {etape.NomArretDepart} à {etape.HeureDepart.ToShortTimeString()}",
                    Font = new Font("Segoe UI", 9),
                    Location = new Point(20, 35),
                    AutoSize = true
                };
                pnlEtape.Controls.Add(lblArretDepart);

                Label lblArretArrivee = new Label
                {
                    Text = $"Arrivée: {etape.NomArretArrivee} à {etape.HeureArrivee.ToShortTimeString()}",
                    Font = new Font("Segoe UI", 9),
                    Location = new Point(20, 55),
                    AutoSize = true
                };
                pnlEtape.Controls.Add(lblArretArrivee);

                Label lblDureeEtape = new Label
                {
                    Text = $"Durée: {etape.DureeMinutes} min",
                    Font = new Font("Segoe UI", 9),
                    Location = new Point(20, 75),
                    AutoSize = true
                };
                pnlEtape.Controls.Add(lblDureeEtape);

                flpEtapes.Controls.Add(pnlEtape);
            }

            // Remplacer le contenu du panel de détails
            pnlDetailsItineraire.Controls.Clear();
            pnlDetailsItineraire.Controls.Add(flpEtapes);
        }
    }
}
