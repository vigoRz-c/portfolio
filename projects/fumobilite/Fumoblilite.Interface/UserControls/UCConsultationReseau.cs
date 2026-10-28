using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using Fumoblilite.Systeme.Modeles;
using Fumoblilite.Systeme.Services;
using Fumoblilite.SQL.Repositories;
using Fumoblilite.Systeme.Interfaces;
using System.Drawing.Drawing2D;

namespace Fumoblilite.Interface.UserControls
{
    public partial class UCConsultationReseau : UserControl
    {
        private readonly string _connectionString;
        private readonly ServiceLigne _serviceLigne;
        private readonly ServiceArret _serviceArret;

        private List<Ligne> _lignes;
        private List<Arret> _arrets;
        private Dictionary<int, bool> _lignesVisibles = new Dictionary<int, bool>();
        private Dictionary<int, Panel> _cartesLignes = new Dictionary<int, Panel>();
        private Dictionary<int, Point> _coordonneesArrets;
        private float _zoomFactor = 1.0f;
        private Point _panOffset = new Point(0, 0);
        private Point _lastMousePosition;
        private bool _isPanning = false;

        public UCConsultationReseau(string connectionString)
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

        private void UCConsultationReseau_Load(object sender, EventArgs e)
        {
            // Configurer les contrôles
            ConfigurerControles();

            // Charger les données
            ChargerDonnees();

            // Appliquer un zoom initial
            _zoomFactor = 1.4f;

            // Rafraîchir l'affichage
            pnlReseau.Invalidate();
        }

        private void ConfigurerControles()
        {
            // Configurer le panel de réseau pour le zoom et le pan
            pnlReseau.MouseWheel += PnlReseau_MouseWheel;
            pnlReseau.MouseDown += PnlReseau_MouseDown;
            pnlReseau.MouseMove += PnlReseau_MouseMove;
            pnlReseau.MouseUp += PnlReseau_MouseUp;

            // Ajouter des boutons de zoom
            btnZoomIn.Click += (s, e) => {
                _zoomFactor *= 1.2f;
                pnlReseau.Invalidate();
            };

            btnZoomOut.Click += (s, e) => {
                _zoomFactor /= 1.2f;
                if (_zoomFactor < 0.1f) _zoomFactor = 0.1f;
                pnlReseau.Invalidate();
            };

            btnResetZoom.Click += (s, e) => {
                _zoomFactor = 1.0f;
                _panOffset = new Point(0, 0);
                pnlReseau.Invalidate();
            };
        }

        private void PnlReseau_MouseWheel(object sender, MouseEventArgs e)
        {
            float oldZoom = _zoomFactor;

            // Ajuster le facteur de zoom
            if (e.Delta > 0)
                _zoomFactor *= 1.1f;
            else
                _zoomFactor /= 1.1f;

            // Limiter le zoom minimum
            if (_zoomFactor < 0.1f) _zoomFactor = 0.1f;

            // Ajuster le décalage pour zoomer vers le curseur
            Point mousePos = e.Location;
            _panOffset.X = mousePos.X - (int)((mousePos.X - _panOffset.X) * (_zoomFactor / oldZoom));
            _panOffset.Y = mousePos.Y - (int)((mousePos.Y - _panOffset.Y) * (_zoomFactor / oldZoom));

            pnlReseau.Invalidate();
        }

        private void PnlReseau_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isPanning = true;
                _lastMousePosition = e.Location;
                pnlReseau.Cursor = Cursors.Hand;
            }
        }

        private void PnlReseau_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isPanning)
            {
                _panOffset.X += e.X - _lastMousePosition.X;
                _panOffset.Y += e.Y - _lastMousePosition.Y;
                _lastMousePosition = e.Location;
                pnlReseau.Invalidate();
            }
        }

        private void PnlReseau_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isPanning = false;
                pnlReseau.Cursor = Cursors.Default;
            }
        }

        private void ChargerDonnees()
        {
            try
            {
                // Charger les lignes et les arrêts
                _lignes = _serviceLigne.ObtenirToutes();
                _arrets = _serviceArret.ObtenirTous();

                // Initialiser la liste des lignes visibles
                foreach (var ligne in _lignes)
                {
                    // Décoche la ligne Noct 1 (id:10) au démarrage
                    if (ligne.Id == 10)
                        _lignesVisibles[ligne.Id] = false;
                    else
                        _lignesVisibles[ligne.Id] = true;
                }

                // Remplir le FlowLayoutPanel des lignes
                flpLignes.Controls.Clear();
                _cartesLignes.Clear();

                foreach (var ligne in _lignes)
                {
                    Panel carteLigne = CreerCarteLigne(ligne);
                    flpLignes.Controls.Add(carteLigne);
                    _cartesLignes[ligne.Id] = carteLigne;
                }

                // Calculer les coordonnées des arrêts
                _coordonneesArrets = CalculerCoordonneesArrets();

                // Rafraîchir l'affichage du réseau
                pnlReseau.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des données : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Panel CreerCarteLigne(Ligne ligne)
        {
            // Créer un panel pour la carte
            Panel panel = new Panel
            {
                Width = flpLignes.Width - 25,
                Height = 50,
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
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 5)
            };
            panel.Controls.Add(lblNumero);

            Label lblNom = new Label
            {
                Text = ligne.Nom,
                Font = new Font("Segoe UI", 9),
                AutoSize = true,
                Location = new Point(20, 25)
            };
            panel.Controls.Add(lblNom);

            // Ajouter une case à cocher pour la visibilité
            CheckBox chkVisible = new CheckBox
            {
                Checked = _lignesVisibles[ligne.Id],
                Text = "",
                Location = new Point(panel.Width - 30, 15),
                Width = 20,
                Height = 20
            };

            chkVisible.CheckedChanged += (sender, e) => {
                _lignesVisibles[ligne.Id] = chkVisible.Checked;
                pnlReseau.Invalidate();
            };

            panel.Controls.Add(chkVisible);

            return panel;
        }

        private Dictionary<int, Point> CalculerCoordonneesArrets()
        {
            Dictionary<int, Point> coordonnees = new Dictionary<int, Point>();

            // Trouver les limites des coordonnées géographiques
            double minLat = _arrets.Min(a => a.Latitude);
            double maxLat = _arrets.Max(a => a.Latitude);
            double minLon = _arrets.Min(a => a.Longitude);
            double maxLon = _arrets.Max(a => a.Longitude);

            // Ajouter une marge
            double margeLatitude = (maxLat - minLat) * 0.1;
            double margeLongitude = (maxLon - minLon) * 0.1;
            minLat -= margeLatitude;
            maxLat += margeLatitude;
            minLon -= margeLongitude;
            maxLon += margeLongitude;

            // Calculer les coordonnées de chaque arrêt sur le panel
            int marge = 30; // Marge en pixels
            int largeurUtile = pnlReseau.Width - 2 * marge;
            int hauteurUtile = pnlReseau.Height - 2 * marge;

            foreach (var arret in _arrets)
            {
                // Normaliser les coordonnées géographiques
                double x = (arret.Longitude - minLon) / (maxLon - minLon);
                double y = 1 - (arret.Latitude - minLat) / (maxLat - minLat); // Inverser l'axe Y

                // Convertir en coordonnées du panel
                int pixelX = marge + (int)(x * largeurUtile);
                int pixelY = marge + (int)(y * hauteurUtile);

                coordonnees[arret.Id] = new Point(pixelX, pixelY);
            }

            return coordonnees;
        }

        private void pnlReseau_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if (_lignes == null || _arrets == null || _coordonneesArrets == null)
                    return;

                Graphics g = e.Graphics;
                g.Clear(Color.White);

                // Activer l'antialiasing pour un rendu plus lisse
                g.SmoothingMode = SmoothingMode.AntiAlias;

                // Appliquer le zoom et le décalage
                g.TranslateTransform(_panOffset.X, _panOffset.Y);
                g.ScaleTransform(_zoomFactor, _zoomFactor);

                // Dessiner les lignes
                DessinerLignes(g);

                // Dessiner les arrêts
                DessinerArrets(g);

                // Afficher le facteur de zoom
                g.ResetTransform();
                g.DrawString($"Zoom: {_zoomFactor:F1}x", new Font("Arial", 8), Brushes.Black, 10, 10);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'affichage du réseau : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DessinerLignes(Graphics g)
        {
            foreach (var ligne in _lignes)
            {
                // Vérifier si la ligne est visible
                if (!_lignesVisibles[ligne.Id])
                    continue;

                // Récupérer les arrêts de la ligne
                var arretsLigne = _serviceLigne.ObtenirParId(ligne.Id, true)?.Arrets;
                if (arretsLigne == null || arretsLigne.Count == 0)
                    continue;

                // Créer un stylo pour dessiner la ligne
                Color couleurLigne = ColorTranslator.FromHtml(ligne.Couleur ?? "#808080");
                Pen styloLigne = new Pen(couleurLigne, 3);

                // Trier les arrêts par ordre
                var arretsOrdonnes = arretsLigne.OrderBy(al => al.Ordre).ToList();

                // Dessiner les segments de la ligne
                for (int i = 0; i < arretsOrdonnes.Count - 1; i++)
                {
                    int arretId1 = arretsOrdonnes[i].ArretId;
                    int arretId2 = arretsOrdonnes[i + 1].ArretId;

                    if (_coordonneesArrets.ContainsKey(arretId1) && _coordonneesArrets.ContainsKey(arretId2))
                    {
                        Point p1 = _coordonneesArrets[arretId1];
                        Point p2 = _coordonneesArrets[arretId2];

                        g.DrawLine(styloLigne, p1, p2);
                    }
                }

                styloLigne.Dispose();
            }
        }

        private void DessinerArrets(Graphics g)
        {
            // Créer un stylo et une brosse pour dessiner les arrêts
            Pen styloArret = new Pen(Color.Black, 1);
            Brush brosseArret = new SolidBrush(Color.White);
            Brush brosseArretAccessible = new SolidBrush(Color.LightGreen);
            Font policeNom = new Font("Arial", 8);
            Brush brosseTexte = new SolidBrush(Color.Black);

            foreach (var arret in _arrets)
            {
                if (_coordonneesArrets.ContainsKey(arret.Id))
                {
                    Point p = _coordonneesArrets[arret.Id];

                    // Dessiner le cercle de l'arrêt
                    g.FillEllipse(arret.EstAccessible ? brosseArretAccessible : brosseArret, p.X - 5, p.Y - 5, 10, 10);
                    g.DrawEllipse(styloArret, p.X - 5, p.Y - 5, 10, 10);

                    // Dessiner le nom de l'arrêt
                    g.DrawString(arret.Nom, policeNom, brosseTexte, p.X + 7, p.Y - 7);
                }
            }

            styloArret.Dispose();
            brosseArret.Dispose();
            brosseArretAccessible.Dispose();
            policeNom.Dispose();
            brosseTexte.Dispose();
        }
    }
}
