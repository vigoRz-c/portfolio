using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Drawing;
using Fumoblilite.Systeme.Modeles;
using Fumoblilite.Systeme.Services;
using Fumoblilite.SQL.Repositories;
using Fumoblilite.Systeme.Interfaces;
using System.Text.Json;
using System.Text;
using System.IO;

namespace Fumoblilite.Interface.UserControls
{
    public partial class UCGestionHoraires : UserControl
    {
        private readonly string _connectionString;
        private readonly ServiceHoraire _serviceHoraire;
        private readonly ServiceLigne _serviceLigne;
        private readonly ServiceArret _serviceArret;
        private Horaire _horaireSelectionne;
        private List<dynamic> _horairesAffichage;
        private Panel _selectedPanel;

        public UCGestionHoraires(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;

            // Initialisation des repositories
            IRepositoryHoraire repositoryHoraire = new RepositoryHoraire(_connectionString);
            IRepositoryLigne repositoryLigne = new RepositoryLigne(_connectionString);
            IRepositoryArret repositoryArret = new RepositoryArret(_connectionString);
            IRepositoryArretLigne repositoryArretLigne = new RepositoryArretLigne(_connectionString, repositoryArret);

            // Initialisation des services
            _serviceHoraire = new ServiceHoraire(repositoryHoraire);
            _serviceLigne = new ServiceLigne(repositoryLigne, repositoryArretLigne);
            _serviceArret = new ServiceArret(repositoryArret);
        }

        private void UCGestionHoraires_Load(object sender, EventArgs e)
        {
            ChargerLignes();
            ChargerJours();
            InitialiserInterface();
            dtpHeure.Value = DateTime.Now;
        }

        private void InitialiserInterface()
        {
            // Initialiser les contrôles de génération récurrente
            nudIntervalle.Value = 30; // 30 minutes par défaut
            nudNombreHoraires.Value = 10; // 10 horaires par défaut
            dtpHeureDebut.Value = DateTime.Today.AddHours(6); // 6h00
            dtpHeureFin.Value = DateTime.Today.AddHours(22); // 22h00

            // Initialiser les jours de la semaine pour la génération
            clbJours.Items.Clear();
            clbJours.Items.Add("Lundi", true);
            clbJours.Items.Add("Mardi", true);
            clbJours.Items.Add("Mercredi", true);
            clbJours.Items.Add("Jeudi", true);
            clbJours.Items.Add("Vendredi", true);
            clbJours.Items.Add("Samedi", false);
            clbJours.Items.Add("Dimanche", false);
        }

        private void ChargerLignes()
        {
            try
            {
                List<Ligne> lignes = _serviceLigne.ObtenirToutes();

                // Configuration du ComboBox de filtre
                var lignesFiltres = new List<Ligne>(lignes);
                lignesFiltres.Insert(0, new Ligne { Id = 0, Numero = "Toutes", Nom = "Toutes les lignes" });

                cboLigne.DisplayMember = "Nom";
                cboLigne.ValueMember = "Id";
                cboLigne.DataSource = lignesFiltres;

                // Configuration des ComboBox de détail et duplication
                cboLigneDetail.DisplayMember = "Nom";
                cboLigneDetail.ValueMember = "Id";
                cboLigneDetail.DataSource = new List<Ligne>(lignes);

                cboLigneSource.DisplayMember = "Nom";
                cboLigneSource.ValueMember = "Id";
                cboLigneSource.DataSource = new List<Ligne>(lignes);

                cboLigneDestination.DisplayMember = "Nom";
                cboLigneDestination.ValueMember = "Id";
                cboLigneDestination.DataSource = new List<Ligne>(lignes);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des lignes : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChargerJours()
        {
            try
            {
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

                // Configuration des ComboBox
                cboJour.DisplayMember = "Value";
                cboJour.ValueMember = "Key";
                cboJour.DataSource = new List<KeyValuePair<DayOfWeek, string>>(jours);

                cboJourDetail.DisplayMember = "Value";
                cboJourDetail.ValueMember = "Key";
                cboJourDetail.DataSource = new List<KeyValuePair<DayOfWeek, string>>(jours);

                // Sélectionner le jour actuel
                cboJour.SelectedValue = DateTime.Today.DayOfWeek;
                cboJourDetail.SelectedValue = DateTime.Today.DayOfWeek;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des jours : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChargerArrets(int ligneId)
        {
            try
            {
                if (ligneId <= 0)
                {
                    cboArret.DataSource = null;
                    return;
                }

                var ligne = _serviceLigne.ObtenirParId(ligneId, true);
                if (ligne?.Arrets == null || ligne.Arrets.Count == 0)
                {
                    cboArret.DataSource = null;
                    return;
                }

                var arrets = _serviceArret.ObtenirTous().ToDictionary(a => a.Id);
                var arretsAffichage = ligne.Arrets
                    .Where(al => arrets.ContainsKey(al.ArretId))
                    .Select(al => new { Id = al.ArretId, Nom = arrets[al.ArretId].Nom })
                    .OrderBy(a => a.Nom)
                    .ToList();

                cboArret.DisplayMember = "Nom";
                cboArret.ValueMember = "Id";
                cboArret.DataSource = arretsAffichage;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des arrêts : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAfficher_Click(object sender, EventArgs e)
        {
            try
            {
                int ligneId = (int)cboLigne.SelectedValue;
                DayOfWeek jour = (DayOfWeek)cboJour.SelectedValue;

                List<Horaire> horaires;

                if (ligneId == 0) // Toutes les lignes
                {
                    horaires = _serviceHoraire.ObtenirParJour(jour);
                }
                else
                {
                    horaires = _serviceHoraire.ObtenirParLigneEtJour(ligneId, jour);
                }

                if (horaires.Count == 0)
                {
                    MessageBox.Show("Aucun horaire trouvé pour les critères spécifiés.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    flpHoraires.Controls.Clear();
                    _horairesAffichage = null;
                    return;
                }

                AfficherHoraires(horaires);
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
            _selectedPanel = null;

            if (!horaires.Any())
            {
                var lblAucun = new Label
                {
                    Text = "Aucun horaire trouvé",
                    Font = new Font(Font.FontFamily, 10),
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    Margin = new Padding(20)
                };
                flpHoraires.Controls.Add(lblAucun);
                flpHoraires.ResumeLayout();
                return;
            }

            var lignes = _serviceLigne.ObtenirToutes().ToDictionary(l => l.Id);
            var arrets = _serviceArret.ObtenirTous().ToDictionary(a => a.Id);

            _horairesAffichage = horaires.Select(h => (dynamic)new
            {
                Id = h.Id,
                Ligne = lignes.ContainsKey(h.LigneId) ? $"{lignes[h.LigneId].Numero} - {lignes[h.LigneId].Nom}" : $"Ligne {h.LigneId}",
                LigneCouleur = lignes.ContainsKey(h.LigneId) ? lignes[h.LigneId].Couleur : "#808080",
                Arret = arrets.ContainsKey(h.ArretId) ? arrets[h.ArretId].Nom : $"Arrêt {h.ArretId}",
                Jour = GetJourSemaine(h.JourSemaine),
                Heure = h.HeureDepart.ToString(@"hh\:mm"),
                Actif = h.EstActif,
                HoraireComplet = h
            }).ToList();

            foreach (var horaire in _horairesAffichage)
            {
                Panel panel = CreerCarteHoraire(horaire);
                flpHoraires.Controls.Add(panel);
            }

            flpHoraires.ResumeLayout();
        }

        // Modifier la méthode CreerCarteHoraire pour ajouter un bouton de suppression rapide
        private Panel CreerCarteHoraire(dynamic horaire)
        {
            bool estActif = horaire.Actif;
            var panel = new Panel
            {
                Width = 400,
                Height = 90,
                Margin = new Padding(5),
                BorderStyle = BorderStyle.FixedSingle,
                Tag = horaire,
                BackColor = estActif ? Color.White : Color.FromArgb(245, 245, 245)
            };

            // Bordure colorée
            var bordure = new Panel
            {
                Width = 8,
                Height = panel.Height,
                Dock = DockStyle.Left,
                BackColor = !string.IsNullOrEmpty(horaire.LigneCouleur)
                    ? ColorTranslator.FromHtml(horaire.LigneCouleur)
                    : Color.Gray
            };
            panel.Controls.Add(bordure);

            // Informations
            var lblLigne = new Label
            {
                Text = horaire.Ligne,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Location = new Point(15, 8),
                AutoSize = true
            };
            panel.Controls.Add(lblLigne);

            var lblArret = new Label
            {
                Text = $"Arrêt: {horaire.Arret}",
                Location = new Point(15, 28),
                AutoSize = true
            };
            panel.Controls.Add(lblArret);

            var lblJour = new Label
            {
                Text = $"Jour: {horaire.Jour}",
                Location = new Point(15, 48),
                AutoSize = true
            };
            panel.Controls.Add(lblJour);

            var lblHeure = new Label
            {
                Text = horaire.Heure,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(panel.Width - 80, 25),
                AutoSize = true,
                ForeColor = estActif ? Color.Green : Color.Gray
            };
            panel.Controls.Add(lblHeure);

            var lblStatut = new Label
            {
                Text = estActif ? "●" : "○",
                Font = new Font("Segoe UI", 16),
                Location = new Point(panel.Width - 25, 20),
                AutoSize = true,
                ForeColor = estActif ? Color.Green : Color.Red
            };
            panel.Controls.Add(lblStatut);

            // Ajout du bouton de suppression rapide
            var btnSupprimerRapide = new Button
            {
                Text = "✕",
                Font = new Font("Segoe UI", 8, FontStyle.Bold),
                Size = new Size(24, 24),
                Location = new Point(panel.Width - 30, panel.Height - 30),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(232, 17, 35),
                ForeColor = Color.White,
                Cursor = Cursors.Hand,
                Tag = horaire.HoraireComplet
            };
            btnSupprimerRapide.FlatAppearance.BorderSize = 0;
            btnSupprimerRapide.Click += BtnSupprimerRapide_Click;
            panel.Controls.Add(btnSupprimerRapide);

            // Gestionnaires d'événements
            panel.Click += (s, e) => SelectionnerHoraire(panel);
            foreach (Control control in panel.Controls)
            {
                if (control != btnSupprimerRapide) // Ne pas ajouter l'événement au bouton de suppression
                {
                    control.Click += (s, e) => SelectionnerHoraire(panel);
                }
            }

            return panel;
        }

        // Ajouter cette nouvelle méthode pour gérer le clic sur le bouton de suppression rapide
        private void BtnSupprimerRapide_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Horaire horaire = (Horaire)btn.Tag;

            DialogResult result = MessageBox.Show(
                $"Êtes-vous sûr de vouloir supprimer l'horaire de {horaire.HeureDepart.ToString(@"hh\:mm")} ?",
                "Confirmation de suppression",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool resultat = _serviceHoraire.Supprimer(horaire.Id);
                    if (resultat)
                    {
                        MessageBox.Show("Horaire supprimé avec succès.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnAfficher_Click(sender, e); // Rafraîchir la liste
                        ViderChamps();
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de la suppression de l'horaire.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Ajouter cette méthode pour gérer le clic sur le bouton "Supprimer tout"
        private void btnSupprimerTout_Click(object sender, EventArgs e)
        {
            if (_horairesAffichage == null || _horairesAffichage.Count == 0)
            {
                MessageBox.Show("Aucun horaire à supprimer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Êtes-vous sûr de vouloir supprimer tous les {_horairesAffichage.Count} horaires affichés ?",
                "Confirmation de suppression massive",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    int nombreSupprimes = 0;
                    int nombreEchecs = 0;

                    foreach (var item in _horairesAffichage)
                    {
                        try
                        {
                            bool resultat = _serviceHoraire.Supprimer(item.Id);
                            if (resultat)
                                nombreSupprimes++;
                            else
                                nombreEchecs++;
                        }
                        catch
                        {
                            nombreEchecs++;
                        }
                    }

                    if (nombreSupprimes > 0)
                    {
                        MessageBox.Show($"{nombreSupprimes} horaires supprimés avec succès.\n{nombreEchecs} échecs.",
                            "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnAfficher_Click(sender, e); // Rafraîchir la liste
                        ViderChamps();
                    }
                    else
                    {
                        MessageBox.Show("Aucun horaire n'a pu être supprimé.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SelectionnerHoraire(Panel panel)
        {
            if (_selectedPanel != null)
            {
                dynamic selectedItem = _selectedPanel.Tag;
                _selectedPanel.BackColor = selectedItem.Actif ? Color.White : Color.FromArgb(245, 245, 245);
            }

            _selectedPanel = panel;
            _selectedPanel.BackColor = Color.FromArgb(230, 240, 250);

            dynamic item = panel.Tag;
            _horaireSelectionne = item.HoraireComplet;

            if (_horaireSelectionne != null)
            {
                txtId.Text = _horaireSelectionne.Id.ToString();
                cboLigneDetail.SelectedValue = _horaireSelectionne.LigneId;
                ChargerArrets(_horaireSelectionne.LigneId);
                cboArret.SelectedValue = _horaireSelectionne.ArretId;
                cboJourDetail.SelectedValue = _horaireSelectionne.JourSemaine;
                dtpHeure.Value = DateTime.Today.Add(_horaireSelectionne.HeureDepart);
                chkEstActif.Checked = _horaireSelectionne.EstActif;
                btnSupprimer.Enabled = true;
                btnDupliquer.Enabled = true;
            }
        }

        private string GetJourSemaine(DayOfWeek jour)
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


        // Gestionnaires d'événements pour les nouvelles fonctionnalités
        private void btnGenererRecurrent_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboLigneDetail.SelectedItem == null || cboArret.SelectedItem == null)
                {
                    MessageBox.Show("Veuillez sélectionner une ligne et un arrêt.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var joursSelectionnes = new List<DayOfWeek>();
                for (int i = 0; i < clbJours.Items.Count; i++)
                {
                    if (clbJours.GetItemChecked(i))
                    {
                        joursSelectionnes.Add((DayOfWeek)(i + 1)); // +1 car DayOfWeek commence à 0 = Dimanche
                    }
                }

                if (!joursSelectionnes.Any())
                {
                    MessageBox.Show("Veuillez sélectionner au moins un jour.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int ligneId = (int)cboLigneDetail.SelectedValue;
                int arretId = (int)cboArret.SelectedValue;
                TimeSpan heureDebut = dtpHeureDebut.Value.TimeOfDay;
                TimeSpan heureFin = dtpHeureFin.Value.TimeOfDay;
                int intervalleMinutes = (int)nudIntervalle.Value;
                int nombreMax = (int)nudNombreHoraires.Value;

                int nombreCrees = 0;
                foreach (var jour in joursSelectionnes)
                {
                    TimeSpan heureCourante = heureDebut;
                    int compteur = 0;

                    while (heureCourante <= heureFin && compteur < nombreMax)
                    {
                        var nouvelHoraire = new Horaire
                        {
                            LigneId = ligneId,
                            ArretId = arretId,
                            JourSemaine = jour,
                            HeureDepart = heureCourante,
                            EstActif = true
                        };

                        try
                        {
                            _serviceHoraire.Ajouter(nouvelHoraire);
                            nombreCrees++;
                        }
                        catch
                        {
                            // Ignorer les doublons
                        }

                        heureCourante = heureCourante.Add(TimeSpan.FromMinutes(intervalleMinutes));
                        compteur++;
                    }
                }

                MessageBox.Show($"{nombreCrees} horaires créés avec succès.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnAfficher_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la génération : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDupliquerLigne_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboLigneSource.SelectedItem == null || cboLigneDestination.SelectedItem == null)
                {
                    MessageBox.Show("Veuillez sélectionner les lignes source et destination.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int ligneSourceId = (int)cboLigneSource.SelectedValue;
                int ligneDestinationId = (int)cboLigneDestination.SelectedValue;

                if (ligneSourceId == ligneDestinationId)
                {
                    MessageBox.Show("Les lignes source et destination doivent être différentes.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var horairesSource = _serviceHoraire.ObtenirParLigne(ligneSourceId);
                var ligneDestination = _serviceLigne.ObtenirParId(ligneDestinationId, true);

                if (ligneDestination?.Arrets == null || !ligneDestination.Arrets.Any())
                {
                    MessageBox.Show("La ligne de destination n'a pas d'arrêts configurés.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int nombreDupliques = 0;
                var premierArretDestination = ligneDestination.Arrets.First().ArretId;

                foreach (var horaire in horairesSource)
                {
                    var nouvelHoraire = new Horaire
                    {
                        LigneId = ligneDestinationId,
                        ArretId = premierArretDestination,
                        JourSemaine = horaire.JourSemaine,
                        HeureDepart = horaire.HeureDepart,
                        EstActif = horaire.EstActif
                    };

                    try
                    {
                        _serviceHoraire.Ajouter(nouvelHoraire);
                        nombreDupliques++;
                    }
                    catch
                    {
                        // Ignorer les doublons
                    }
                }

                MessageBox.Show($"{nombreDupliques} horaires dupliqués avec succès.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnAfficher_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la duplication : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Gestionnaires d'événements existants
        private void cboLigneDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLigneDetail.SelectedItem != null)
            {
                int ligneId = (int)cboLigneDetail.SelectedValue;
                ChargerArrets(ligneId);
            }
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            ViderChamps();
        }

        private void ViderChamps()
        {
            txtId.Text = string.Empty;
            if (cboLigneDetail.Items.Count > 0)
                cboLigneDetail.SelectedIndex = 0;
            if (cboJourDetail.Items.Count > 0)
                cboJourDetail.SelectedValue = DateTime.Today.DayOfWeek;
            dtpHeure.Value = DateTime.Now;
            chkEstActif.Checked = true;
            _horaireSelectionne = null;
            btnSupprimer.Enabled = false;
            btnDupliquer.Enabled = false;

            if (_selectedPanel != null)
            {
                _selectedPanel.BackColor = SystemColors.Control;
                _selectedPanel = null;
            }
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboLigneDetail.SelectedItem == null || cboArret.SelectedItem == null)
                {
                    MessageBox.Show("Veuillez sélectionner une ligne et un arrêt.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int ligneId = (int)cboLigneDetail.SelectedValue;
                int arretId = (int)cboArret.SelectedValue;
                DayOfWeek jour = (DayOfWeek)cboJourDetail.SelectedValue;
                TimeSpan heure = dtpHeure.Value.TimeOfDay;
                bool estActif = chkEstActif.Checked;

                if (_horaireSelectionne == null)
                {
                    var nouvelHoraire = new Horaire
                    {
                        LigneId = ligneId,
                        ArretId = arretId,
                        JourSemaine = jour,
                        HeureDepart = heure,
                        EstActif = estActif
                    };

                    int id = _serviceHoraire.Ajouter(nouvelHoraire);
                    MessageBox.Show("Horaire ajouté avec succès.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _horaireSelectionne.LigneId = ligneId;
                    _horaireSelectionne.ArretId = arretId;
                    _horaireSelectionne.JourSemaine = jour;
                    _horaireSelectionne.HeureDepart = heure;
                    _horaireSelectionne.EstActif = estActif;

                    bool resultat = _serviceHoraire.Modifier(_horaireSelectionne);
                    if (resultat)
                    {
                        MessageBox.Show("Horaire modifié avec succès.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de la modification de l'horaire.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                btnAfficher_Click(sender, e);
                ViderChamps();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (_horaireSelectionne != null)
            {
                DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet horaire ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        bool resultat = _serviceHoraire.Supprimer(_horaireSelectionne.Id);
                        if (resultat)
                        {
                            MessageBox.Show("Horaire supprimé avec succès.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnAfficher_Click(sender, e);
                            ViderChamps();
                        }
                        else
                        {
                            MessageBox.Show("Erreur lors de la suppression de l'horaire.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnDupliquer_Click(object sender, EventArgs e)
        {
            if (_horaireSelectionne != null)
            {
                try
                {
                    var nouvelHoraire = new Horaire
                    {
                        LigneId = _horaireSelectionne.LigneId,
                        ArretId = _horaireSelectionne.ArretId,
                        JourSemaine = _horaireSelectionne.JourSemaine,
                        HeureDepart = _horaireSelectionne.HeureDepart.Add(TimeSpan.FromMinutes(30)), // +30 minutes
                        EstActif = _horaireSelectionne.EstActif
                    };

                    int id = _serviceHoraire.Ajouter(nouvelHoraire);
                    MessageBox.Show("Horaire dupliqué avec succès.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnAfficher_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la duplication : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExporterCsv_Click(object sender, EventArgs e)
        {
            try
            {
                int ligneId = (int)cboLigne.SelectedValue;
                int arretId = (int)cboArret.SelectedValue;
                int jourValue = (int)cboJour.SelectedValue;

                List<Horaire> horaires;
                if (jourValue == -1)
                    horaires = _serviceHoraire.ObtenirParCriteres(new HoraireCriteres());
                else
                {
                    DayOfWeek jour = (DayOfWeek)jourValue;
                    if (ligneId == 0)
                        horaires = _serviceHoraire.ObtenirParJour(jour);
                    else
                        horaires = _serviceHoraire.ObtenirParLigneEtJour(ligneId, jour);
                }
                if (arretId != 0)
                    horaires = horaires.Where(h => h.ArretId == arretId).ToList();

                var heureDebut = dtpHeureDebut.Value.TimeOfDay;
                var heureFin = dtpHeureFin.Value.TimeOfDay;
                horaires = horaires.Where(h => h.HeureDepart >= heureDebut && h.HeureDepart <= heureFin).ToList();

                var sb = new StringBuilder();
                sb.AppendLine("Id,LigneId,ArretId,JourSemaine,HeureDepart,EstActif,DateCreation,DateModification");
                foreach (var h in horaires)
                    sb.AppendLine($"{h.Id},{h.LigneId},{h.ArretId},{h.JourSemaine},{h.HeureDepart},{h.EstActif},{h.DateCreation:yyyy-MM-dd HH:mm:ss},{(h.DateModification.HasValue ? h.DateModification.Value.ToString("yyyy-MM-dd HH:mm:ss") : "")}");

                using (var sfd = new SaveFileDialog { Filter = "CSV (*.csv)|*.csv", FileName = "horaires.csv" })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                        File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'export CSV : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExporterJson_Click(object sender, EventArgs e)
        {
            try
            {
                int ligneId = (int)cboLigne.SelectedValue;
                int arretId = (int)cboArret.SelectedValue;
                int jourValue = (int)cboJour.SelectedValue;

                List<Horaire> horaires;
                if (jourValue == -1)
                    horaires = _serviceHoraire.ObtenirParCriteres(new HoraireCriteres());
                else
                {
                    DayOfWeek jour = (DayOfWeek)jourValue;
                    if (ligneId == 0)
                        horaires = _serviceHoraire.ObtenirParJour(jour);
                    else
                        horaires = _serviceHoraire.ObtenirParLigneEtJour(ligneId, jour);
                }
                if (arretId != 0)
                    horaires = horaires.Where(h => h.ArretId == arretId).ToList();

                var heureDebut = dtpHeureDebut.Value.TimeOfDay;
                var heureFin = dtpHeureFin.Value.TimeOfDay;
                horaires = horaires.Where(h => h.HeureDepart >= heureDebut && h.HeureDepart <= heureFin).ToList();

                using (var sfd = new SaveFileDialog { Filter = "JSON (*.json)|*.json", FileName = "horaires.json" })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                        File.WriteAllText(sfd.FileName, JsonSerializer.Serialize(horaires, new JsonSerializerOptions { WriteIndented = true }), Encoding.UTF8);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'export JSON : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
