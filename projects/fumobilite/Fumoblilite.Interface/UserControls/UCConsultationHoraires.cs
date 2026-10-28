using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Drawing;
using Fumoblilite.Systeme.Modeles;
using Fumoblilite.Systeme.Services;
using Fumoblilite.SQL.Repositories;
using Fumoblilite.Systeme.Interfaces;

namespace Fumoblilite.Interface.UserControls
{
    public partial class UCConsultationHoraires : UserControl
    {
        private readonly string _connectionString;
        private readonly ServiceLigne _serviceLigne;
        private readonly ServiceArret _serviceArret;
        private readonly ServiceHoraire _serviceHoraire;
        private Timer _searchTimer;
        private Timer _refreshTimer;

        public UCConsultationHoraires(string connectionString)
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

            // Timer pour la recherche en temps réel
            _searchTimer = new Timer { Interval = 500 };
            _searchTimer.Tick += (s, e) => { _searchTimer.Stop(); btnAfficher_Click(s, e); };

            // Timer pour rafraîchir les prochains départs
            _refreshTimer = new Timer { Interval = 60000 }; // 1 minute
            _refreshTimer.Tick += (s, e) => AfficherProchainsDeparts();
        }

        private void UCConsultationHoraires_Load(object sender, EventArgs e)
        {
            ChargerLignes();
            ChargerArrets();
            ChargerJours();
            InitialiserFiltres();
            _refreshTimer.Start();
        }

        private void InitialiserFiltres()
        {
            // Initialiser les heures
            dtpHeureDebut.Value = DateTime.Today.AddHours(6); // 6h00
            dtpHeureFin.Value = DateTime.Today.AddHours(22);  // 22h00

            chkSeulementActifs.Checked = true;
            chkProchainsDeparts.Checked = false;
        }

        private void ChargerLignes()
        {
            try
            {
                List<Ligne> lignes = _serviceLigne.ObtenirToutes();
                lignes.Insert(0, new Ligne { Id = 0, Numero = "Toutes", Nom = "Toutes les lignes" });

                cboLigne.DisplayMember = "Nom";
                cboLigne.ValueMember = "Id";
                cboLigne.DataSource = lignes;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des lignes : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChargerArrets()
        {
            try
            {
                List<Arret> arrets = _serviceArret.ObtenirTous();
                arrets.Insert(0, new Arret { Id = 0, Nom = "Tous les arrêts" });

                cboArret.DisplayMember = "Nom";
                cboArret.ValueMember = "Id";
                cboArret.DataSource = arrets;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des arrêts : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChargerJours()
        {
            try
            {
                var jours = new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(-1, "Tous les jours"),
                    new KeyValuePair<int, string>((int)DayOfWeek.Monday, "Lundi"),
                    new KeyValuePair<int, string>((int)DayOfWeek.Tuesday, "Mardi"),
                    new KeyValuePair<int, string>((int)DayOfWeek.Wednesday, "Mercredi"),
                    new KeyValuePair<int, string>((int)DayOfWeek.Thursday, "Jeudi"),
                    new KeyValuePair<int, string>((int)DayOfWeek.Friday, "Vendredi"),
                    new KeyValuePair<int, string>((int)DayOfWeek.Saturday, "Samedi"),
                    new KeyValuePair<int, string>((int)DayOfWeek.Sunday, "Dimanche")
                };

                cboJour.DisplayMember = "Value";
                cboJour.ValueMember = "Key";
                cboJour.DataSource = jours;
                cboJour.SelectedValue = (int)DateTime.Today.DayOfWeek;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des jours : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AfficherProchainsDeparts()
        {
            try
            {
                if (!chkProchainsDeparts.Checked) return;

                var maintenant = DateTime.Now;
                var horairesAujourdhui = _serviceHoraire.ObtenirParJour(maintenant.DayOfWeek)
                    .Where(h => h.EstActif && h.HeureDepart > maintenant.TimeOfDay)
                    .OrderBy(h => h.HeureDepart)
                    .Take(3)
                    .ToList();

                if (horairesAujourdhui.Any())
                {
                    lblProchainsDeparts.Text = $"Prochains départs : {string.Join(", ", horairesAujourdhui.Select(h => h.HeureDepart.ToString(@"hh\:mm")))}";
                    lblProchainsDeparts.ForeColor = Color.Green;
                }
                else
                {
                    lblProchainsDeparts.Text = "Aucun départ prévu aujourd'hui";
                    lblProchainsDeparts.ForeColor = Color.Gray;
                }
            }
            catch (Exception ex)
            {
                lblProchainsDeparts.Text = "Erreur lors du chargement";
                lblProchainsDeparts.ForeColor = Color.Red;
            }
        }

        private void btnAfficher_Click(object sender, EventArgs e)
        {
            try
            {
                int ligneId = (int)cboLigne.SelectedValue;
                int arretId = (int)cboArret.SelectedValue;
                int jourValue = (int)cboJour.SelectedValue;

                List<Horaire> horaires;

                if (jourValue == -1) // Tous les jours
                {
                    horaires = _serviceHoraire.ObtenirParCriteres(new HoraireCriteres());
                }
                else
                {
                    DayOfWeek jour = (DayOfWeek)jourValue;
                    if (ligneId == 0) // Toutes les lignes
                    {
                        horaires = _serviceHoraire.ObtenirParJour(jour);
                    }
                    else
                    {
                        horaires = _serviceHoraire.ObtenirParLigneEtJour(ligneId, jour);
                    }
                }

                // Filtrer par arrêt si spécifié
                if (arretId != 0)
                {
                    horaires = horaires.Where(h => h.ArretId == arretId).ToList();
                }

                // Filtrer par plage horaire
                var heureDebut = dtpHeureDebut.Value.TimeOfDay;
                var heureFin = dtpHeureFin.Value.TimeOfDay;
                horaires = horaires.Where(h => h.HeureDepart >= heureDebut && h.HeureDepart <= heureFin).ToList();

                // Filtrer par statut actif si demandé
                if (chkSeulementActifs.Checked)
                {
                    horaires = horaires.Where(h => h.EstActif).ToList();
                }

                // Filtrer par recherche textuelle si spécifiée
                if (!string.IsNullOrWhiteSpace(txtRecherche.Text))
                {
                    var recherche = txtRecherche.Text.ToLower();
                    var lignes = _serviceLigne.ObtenirToutes().ToDictionary(l => l.Id);
                    var arrets = _serviceArret.ObtenirTous().ToDictionary(a => a.Id);

                    horaires = horaires.Where(h =>
                        (lignes.ContainsKey(h.LigneId) && lignes[h.LigneId].Nom.ToLower().Contains(recherche)) ||
                        (arrets.ContainsKey(h.ArretId) && arrets[h.ArretId].Nom.ToLower().Contains(recherche)) ||
                        h.HeureDepart.ToString(@"hh\:mm").Contains(recherche)
                    ).ToList();
                }

                if (horaires.Count == 0)
                {
                    MessageBox.Show("Aucun horaire trouvé pour les critères spécifiés.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    flpHoraires.Controls.Clear();
                    lblStatistiques.Text = "Aucun résultat";
                    return;
                }

                AfficherHoraires(horaires);
                AfficherStatistiques(horaires.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'affichage des horaires : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void AfficherHoraires(List<Horaire> horaires)
        {
            flpHoraires.SuspendLayout();
            flpHoraires.Controls.Clear();

            // Récupérer les informations des lignes et des arrêts pour l'affichage
            var lignes = _serviceLigne.ObtenirToutes().ToDictionary(l => l.Id);
            var arrets = _serviceArret.ObtenirTous().ToDictionary(a => a.Id);

            // Préparer les données pour l'affichage
            var horairesAffichage = horaires.Select(h => new
            {
                Horaire = h,
                Ligne = lignes.ContainsKey(h.LigneId) ? $"{lignes[h.LigneId].Numero} - {lignes[h.LigneId].Nom}" : $"Ligne {h.LigneId}",
                LigneCouleur = lignes.ContainsKey(h.LigneId) ? lignes[h.LigneId].Couleur : "#808080",
                Arret = arrets.ContainsKey(h.ArretId) ? arrets[h.ArretId].Nom : $"Arrêt {h.ArretId}",
                Heure = h.HeureDepart.ToString(@"hh\:mm"),
                Jour = GetNomJour(h.JourSemaine),
                Actif = h.EstActif
            }).OrderBy(h => h.Ligne).ThenBy(h => h.Arret).ThenBy(h => h.Heure).ToList();

            foreach (var horaire in horairesAffichage)
            {
                Panel panel = CreerCarteHoraire(horaire);
                flpHoraires.Controls.Add(panel);
            }

            flpHoraires.ResumeLayout();
        }

        private Panel CreerCarteHoraire(dynamic horaire)
        {
            var panel = new Panel
            {
                Width = flpHoraires.Width - 30,
                Height = 80,
                BackColor = horaire.Actif ? Color.White : Color.FromArgb(245, 245, 245),
                Margin = new Padding(5),
                BorderStyle = BorderStyle.FixedSingle
            };

            // Bordure colorée selon la ligne
            var bordure = new Panel
            {
                Width = 5,
                Height = panel.Height,
                Dock = DockStyle.Left,
                BackColor = !string.IsNullOrEmpty(horaire.LigneCouleur)
                    ? ColorTranslator.FromHtml(horaire.LigneCouleur)
                    : Color.Gray
            };
            panel.Controls.Add(bordure);

            // Informations principales
            var lblLigne = new Label
            {
                Text = horaire.Ligne,
                Font = new Font(Font.FontFamily, 10, FontStyle.Bold),
                Location = new Point(15, 10),
                AutoSize = true
            };
            panel.Controls.Add(lblLigne);

            var lblArret = new Label
            {
                Text = horaire.Arret,
                Location = new Point(15, 30),
                AutoSize = true
            };
            panel.Controls.Add(lblArret);

            var lblJour = new Label
            {
                Text = horaire.Jour,
                Location = new Point(15, 50),
                AutoSize = true,
                ForeColor = Color.Gray,
                Font = new Font(Font.FontFamily, 8)
            };
            panel.Controls.Add(lblJour);

            var lblHeure = new Label
            {
                Text = horaire.Heure,
                Font = new Font(Font.FontFamily, 12, FontStyle.Bold),
                Location = new Point(panel.Width - 80, 20),
                AutoSize = true,
                ForeColor = horaire.Actif ? Color.Green : Color.Gray
            };
            panel.Controls.Add(lblHeure);

            // Indicateur temps réel
            if (horaire.Horaire.JourSemaine == DateTime.Now.DayOfWeek && horaire.Horaire.HeureDepart > DateTime.Now.TimeOfDay)
            {
                var tempsRestant = horaire.Horaire.HeureDepart - DateTime.Now.TimeOfDay;
                var lblTemps = new Label
                {
                    Text = $"Dans {tempsRestant.Hours}h{tempsRestant.Minutes:00}",
                    Location = new Point(panel.Width - 100, 50),
                    AutoSize = true,
                    ForeColor = Color.Blue,
                    Font = new Font(Font.FontFamily, 8, FontStyle.Italic)
                };
                panel.Controls.Add(lblTemps);
            }

            return panel;
        }

        private void AfficherStatistiques(int total)
        {
            lblStatistiques.Text = $"Total: {total} horaires trouvés";
        }

        private string GetNomJour(DayOfWeek jour)
        {
            switch (jour)
            {
                case DayOfWeek.Monday:
                    return "Lundi";
                case DayOfWeek.Tuesday:
                    return "Mardi";
                case DayOfWeek.Wednesday:
                    return "Mercredi";
                case DayOfWeek.Thursday:
                    return "Jeudi";
                case DayOfWeek.Friday:
                    return "Vendredi";
                case DayOfWeek.Saturday:
                    return "Samedi";
                case DayOfWeek.Sunday:
                    return "Dimanche";
                default:
                    return jour.ToString();
            }
        }


        // Gestionnaires d'événements
        private void txtRecherche_TextChanged(object sender, EventArgs e)
        {
            _searchTimer.Stop();
            _searchTimer.Start();
        }

        private void chkProchainsDeparts_CheckedChanged(object sender, EventArgs e)
        {
            if (chkProchainsDeparts.Checked)
            {
                AfficherProchainsDeparts();
                _refreshTimer.Start();
            }
            else
            {
                _refreshTimer.Stop();
                lblProchainsDeparts.Text = "";
            }
        }

        private void btnExporter_Click(object sender, EventArgs e)
        {
            try
            {
                var saveDialog = new SaveFileDialog
                {
                    Filter = "Fichiers CSV (*.csv)|*.csv",
                    DefaultExt = "csv",
                    FileName = $"horaires_{DateTime.Now:yyyyMMdd}.csv"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    // Récupérer les horaires actuellement affichés
                    btnAfficher_Click(null, null);
                    MessageBox.Show("Export réalisé avec succès !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'export : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _searchTimer?.Dispose();
                _refreshTimer?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
