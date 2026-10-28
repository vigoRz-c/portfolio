using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Fumoblilite.Systeme.Modeles;
using Fumoblilite.Systeme.Services;
using Fumoblilite.SQL.Repositories;
using Fumoblilite.Interface.Forms;

namespace Fumoblilite.Interface.UserControls
{
    public partial class UCInviteCommande : UserControl
    {
        private readonly string _connectionString;
        private readonly Utilisateur _utilisateurConnecte;
        private readonly FormPrincipal _formPrincipal;
        private List<string> _historiqueCommandes;
        private int _indexHistorique;



        // Services
        private readonly ServiceArret _serviceArret;
        private readonly ServiceLigne _serviceLigne;
        private readonly ServiceHoraire _serviceHoraire;
        private readonly ServiceAuthentification _serviceAuth;
        private readonly RepositoryActionHistorique _repoHistorique;
        private readonly ServiceItineraire _serviceItineraire;

        public UCInviteCommande(string connectionString, Utilisateur utilisateur, FormPrincipal formPrincipal)
        {
            InitializeComponent();
            _connectionString = connectionString;
            _utilisateurConnecte = utilisateur;
            _formPrincipal = formPrincipal;
            _historiqueCommandes = new List<string>();
            _indexHistorique = -1;

            // Initialiser les services
            var repositoryArret = new RepositoryArret(_connectionString);
            var repositoryLigne = new RepositoryLigne(_connectionString);
            var repositoryArretLigne = new RepositoryArretLigne(_connectionString, repositoryArret);
            var repositoryHoraire = new RepositoryHoraire(_connectionString);
            var repositoryUtilisateur = new RepositoryUtilisateur(_connectionString);

            _serviceArret = new ServiceArret(repositoryArret);
            _serviceLigne = new ServiceLigne(repositoryLigne, repositoryArretLigne);
            _serviceHoraire = new ServiceHoraire(repositoryHoraire);
            _serviceAuth = new ServiceAuthentification(repositoryUtilisateur);
            _repoHistorique = new RepositoryActionHistorique(_connectionString);
            _serviceItineraire = new ServiceItineraire(repositoryArret, repositoryLigne, repositoryArretLigne, repositoryHoraire);

            InitialiserInterface();
        }

        private void InitialiserInterface()
        {
            // Configuration de l'apparence console
            this.BackColor = Color.Black;

            // Message de bienvenue
            string utilisateur = _utilisateurConnecte?.Prenom ?? "Invité";
            string role = _utilisateurConnecte?.Role ?? "Visiteur";

            AjouterTexte($"=== FUMOBILITE CONSOLE ===", Color.Cyan);
            AjouterTexte($"Utilisateur: {utilisateur} ({role})", Color.Yellow);
            AjouterTexte("Console interactive - Toutes les opérations se font ici", Color.Gray);
            AjouterTexte("Tapez 'help' pour voir les commandes disponibles", Color.Gray);
            AjouterTexte("Appuyez sur Échap pour fermer la console", Color.Gray);
            AjouterTexte("", Color.White);

            AfficherPrompt();
        }

        private void AjouterTexte(string texte, Color couleur)
        {
            rtbConsole.SelectionStart = rtbConsole.TextLength;
            rtbConsole.SelectionLength = 0;
            rtbConsole.SelectionColor = couleur;
            rtbConsole.AppendText(texte + Environment.NewLine);
            rtbConsole.SelectionColor = rtbConsole.ForeColor;
            rtbConsole.ScrollToCaret();
        }

        private void AfficherPrompt()
        {
            string utilisateur = _utilisateurConnecte?.Prenom ?? "invité";
            string prompt = $"[{utilisateur}@fumobilite]$ ";

            rtbConsole.SelectionStart = rtbConsole.TextLength;
            rtbConsole.SelectionLength = 0;
            rtbConsole.SelectionColor = Color.Lime;
            rtbConsole.AppendText(prompt);
            rtbConsole.SelectionColor = rtbConsole.ForeColor;
            rtbConsole.ScrollToCaret();
        }

        private void txtCommande_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    ExecuterCommande();
                    e.Handled = true;
                    break;

                case Keys.Escape:
                    FermerConsole();
                    e.Handled = true;
                    break;

                case Keys.Up:
                    NaviguerHistorique(-1);
                    e.Handled = true;
                    break;

                case Keys.Down:
                    NaviguerHistorique(1);
                    e.Handled = true;
                    break;

                case Keys.Tab:
                    AutoCompleter();
                    e.Handled = true;
                    break;
            }
        }

        private void ExecuterCommande()
        {
            string commande = txtCommande.Text.Trim();

            if (string.IsNullOrEmpty(commande))
            {
                AfficherPrompt();
                return;
            }

            _repoHistorique.Ajouter(new ActionHistorique
            {
                UtilisateurId = _utilisateurConnecte?.Id,
                NomUtilisateur = _utilisateurConnecte?.NomUtilisateur ?? "Invité",
                Action = commande,
                DateAction = DateTime.Now
            });


            // Afficher la commande dans la console
            AjouterTexte(commande, Color.White);

            // Ajouter à l'historique
            if (!string.IsNullOrEmpty(commande) && (_historiqueCommandes.Count == 0 || _historiqueCommandes.Last() != commande))
            {
                _historiqueCommandes.Add(commande);
            }
            _indexHistorique = _historiqueCommandes.Count;

            // Traiter la commande
            TraiterCommande(commande);

            // Réinitialiser le champ de saisie
            txtCommande.Clear();

            // Afficher le nouveau prompt
            AfficherPrompt();
        }

        private void TraiterCommande(string commande)
        {
            try
            {
                string[] parties = commande.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (parties.Length == 0) return;

                string commandePrincipale = parties[0].ToLower();

                switch (commandePrincipale)
                {
                    case "help":
                        AfficherAide();
                        break;

                    case "clear":
                        rtbConsole.Clear();
                        InitialiserInterface();
                        return;

                    case "status":
                        AfficherStatus();
                        break;

                    case "exit":
                    case "fermer":
                        FermerConsole();
                        return;

                    case "quitter":
                        Application.Exit();
                        return;

                    // === COMMANDES ARRÊTS ===
                    case "arrets":
                        TraiterCommandeArrets(parties);
                        break;

                    case "arret":
                        TraiterCommandeArret(parties);
                        break;

                    // === COMMANDES LIGNES ===
                    case "lignes":
                        TraiterCommandeLignes(parties);
                        break;

                    case "ligne":
                        TraiterCommandeLigne(parties);
                        break;

                    // === COMMANDES HORAIRES ===
                    case "horaires":
                        TraiterCommandeHoraires(parties);
                        break;

                    // === COMMANDES RÉSEAU ===
                    case "reseau":
                        AfficherReseau();
                        break;

                    // === COMMANDES ITINÉRAIRE ===
                    case "itineraire":
                        TraiterCommandeItineraire(parties);
                        break;

                    // === COMMANDES UTILISATEURS ===
                    case "utilisateurs":
                        TraiterCommandeUtilisateurs(parties);
                        break;

                    case "historique":
                        AfficherHistorique(parties);
                        break;


                    default:
                        AjouterTexte($"Commande '{commandePrincipale}' non reconnue. Tapez 'help' pour voir les commandes disponibles.", Color.Red);
                        break;
                }
            }
            catch (Exception ex)
            {
                AjouterTexte($"Erreur lors de l'exécution: {ex.Message}", Color.Red);
            }
        }

        private void TraiterCommandeArrets(string[] parties)
        {
            if (_utilisateurConnecte?.Role != "Admin")
            {
                AjouterTexte("Accès refusé. Droits administrateur requis.", Color.Red);
                return;
            }

            if (parties.Length == 1)
            {
                // Lister tous les arrêts
                var arrets = _serviceArret.ObtenirTous();
                AjouterTexte("=== LISTE DES ARRÊTS ===", Color.Cyan);
                AjouterTexte($"{"ID",-5} {"Nom",-25} {"Adresse",-30} {"Accessible",-10}", Color.Yellow);
                AjouterTexte(new string('-', 75), Color.Gray);

                foreach (var arret in arrets)
                {
                    string accessible = arret.EstAccessible ? "Oui" : "Non";
                    AjouterTexte($"{arret.Id,-5} {arret.Nom,-25} {arret.Adresse,-30} {accessible,-10}", Color.White);
                }
                AjouterTexte($"\nTotal: {arrets.Count} arrêts", Color.Green);
            }
            else
            {
                string sousCommande = parties[1].ToLower();
                switch (sousCommande)
                {
                    case "add":
                    case "ajouter":
                        AjouterTexte("Usage: arret add <nom> <adresse> <latitude> <longitude> [accessible:true/false]", Color.Yellow);
                        AjouterTexte("Exemple: arret add \"Gare Centrale\" \"Place de la Gare\" 46.5197 6.6323 true", Color.Gray);
                        break;
                    default:
                        AjouterTexte("Sous-commandes disponibles: add, ajouter", Color.Yellow);
                        break;
                }
            }
        }

        private void AfficherHistorique(string[] parties)
        {
            var historique = _repoHistorique.ObtenirParUtilisateur(_utilisateurConnecte?.Id);
            AjouterTexte("=== HISTORIQUE DES COMMANDES ===", Color.Cyan);
            foreach (var h in historique)
                AjouterTexte($"{h.DateAction:dd/MM/yyyy HH:mm:ss} - {h.Action}", Color.White);

            if (parties.Length > 1 && parties[1].ToLower() == "export")
            {
                using (var sfd = new SaveFileDialog { Filter = "CSV (*.csv)|*.csv", FileName = "historique.csv" })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        var sb = new System.Text.StringBuilder();
                        sb.AppendLine("Date,Action");
                        foreach (var h in historique)
                            sb.AppendLine($"{h.DateAction:yyyy-MM-dd HH:mm:ss},{h.Action.Replace(",", " ")}");
                        System.IO.File.WriteAllText(sfd.FileName, sb.ToString(), System.Text.Encoding.UTF8);
                        AjouterTexte("Export CSV effectué.", Color.Green);
                    }
                }
            }
        }


        private void TraiterCommandeArret(string[] parties)
        {
            if (_utilisateurConnecte?.Role != "Admin")
            {
                AjouterTexte("Accès refusé. Droits administrateur requis.", Color.Red);
                return;
            }

            if (parties.Length < 2)
            {
                AjouterTexte("Usage: arret <action> [paramètres]", Color.Yellow);
                AjouterTexte("Actions: add, edit, delete, info", Color.Gray);
                return;
            }

            string action = parties[1].ToLower();

            switch (action)
            {
                case "add":
                case "ajouter":
                    if (parties.Length >= 6)
                    {
                        try
                        {
                            string nom = parties[2].Trim('"');
                            string adresse = parties[3].Trim('"');
                            double latitude = double.Parse(parties[4]);
                            double longitude = double.Parse(parties[5]);
                            bool accessible = parties.Length > 6 ? bool.Parse(parties[6]) : false;

                            var nouvelArret = new Arret
                            {
                                Nom = nom,
                                Adresse = adresse,
                                Latitude = latitude,
                                Longitude = longitude,
                                EstAccessible = accessible,
                                DateCreation = DateTime.Now
                            };

                            int id = _serviceArret.Ajouter(nouvelArret);
                            AjouterTexte($"Arrêt créé avec succès (ID: {id})", Color.Green);
                            AjouterTexte($"Nom: {nom}", Color.White);
                            AjouterTexte($"Adresse: {adresse}", Color.White);
                            AjouterTexte($"Coordonnées: {latitude}, {longitude}", Color.White);
                            AjouterTexte($"Accessible: {(accessible ? "Oui" : "Non")}", Color.White);
                        }
                        catch (Exception ex)
                        {
                            AjouterTexte($"Erreur lors de la création: {ex.Message}", Color.Red);
                        }
                    }
                    else
                    {
                        AjouterTexte("Usage: arret add <nom> <adresse> <latitude> <longitude> [accessible]", Color.Yellow);
                        AjouterTexte("Exemple: arret add \"Gare Centrale\" \"Place de la Gare\" 46.5197 6.6323 true", Color.Gray);
                    }
                    break;

                case "info":
                    if (parties.Length >= 3)
                    {
                        if (int.TryParse(parties[2], out int id))
                        {
                            var arret = _serviceArret.ObtenirParId(id);
                            if (arret != null)
                            {
                                AjouterTexte($"=== INFORMATIONS ARRÊT {id} ===", Color.Cyan);
                                AjouterTexte($"Nom: {arret.Nom}", Color.White);
                                AjouterTexte($"Adresse: {arret.Adresse}", Color.White);
                                AjouterTexte($"Coordonnées: {arret.Latitude}, {arret.Longitude}", Color.White);
                                AjouterTexte($"Accessible: {(arret.EstAccessible ? "Oui" : "Non")}", Color.White);
                                AjouterTexte($"Créé le: {arret.DateCreation:dd/MM/yyyy HH:mm}", Color.Gray);
                                if (arret.DateModification.HasValue)
                                    AjouterTexte($"Modifié le: {arret.DateModification:dd/MM/yyyy HH:mm}", Color.Gray);
                            }
                            else
                            {
                                AjouterTexte($"Arrêt avec l'ID {id} non trouvé.", Color.Red);
                            }
                        }
                        else
                        {
                            AjouterTexte("ID invalide. Utilisez un nombre entier.", Color.Red);
                        }
                    }
                    else
                    {
                        AjouterTexte("Usage: arret info <id>", Color.Yellow);
                    }
                    break;

                case "delete":
                case "supprimer":
                    if (parties.Length >= 3)
                    {
                        if (int.TryParse(parties[2], out int id))
                        {
                            var arret = _serviceArret.ObtenirParId(id);
                            if (arret != null)
                            {
                                bool resultat = _serviceArret.Supprimer(id);
                                if (resultat)
                                {
                                    AjouterTexte($"Arrêt '{arret.Nom}' (ID: {id}) supprimé avec succès.", Color.Green);
                                }
                                else
                                {
                                    AjouterTexte($"Erreur lors de la suppression de l'arrêt {id}.", Color.Red);
                                }
                            }
                            else
                            {
                                AjouterTexte($"Arrêt avec l'ID {id} non trouvé.", Color.Red);
                            }
                        }
                        else
                        {
                            AjouterTexte("ID invalide. Utilisez un nombre entier.", Color.Red);
                        }
                    }
                    else
                    {
                        AjouterTexte("Usage: arret delete <id>", Color.Yellow);
                    }
                    break;

                default:
                    AjouterTexte("Actions disponibles: add, info, delete", Color.Yellow);
                    break;
            }
        }

        private void TraiterCommandeLignes(string[] parties)
        {
            if (parties.Length == 1)
            {
                // Lister toutes les lignes
                var lignes = _serviceLigne.ObtenirToutes();
                AjouterTexte("=== LISTE DES LIGNES ===", Color.Cyan);
                AjouterTexte($"{"ID",-5} {"Numéro",-8} {"Nom",-20} {"Couleur",-10} {"Active",-8}", Color.Yellow);
                AjouterTexte(new string('-', 55), Color.Gray);

                foreach (var ligne in lignes)
                {
                    string active = ligne.EstActif ? "Oui" : "Non";
                    AjouterTexte($"{ligne.Id,-5} {ligne.Numero,-8} {ligne.Nom,-20} {ligne.Couleur,-10} {active,-8}", Color.White);
                }
                AjouterTexte($"\nTotal: {lignes.Count} lignes", Color.Green);
            }
        }

        private void TraiterCommandeLigne(string[] parties)
        {
            if (parties.Length < 2)
            {
                AjouterTexte("Usage: ligne <action> [paramètres]", Color.Yellow);
                AjouterTexte("Actions: add, info, delete, arrets", Color.Gray);
                return;
            }

            string action = parties[1].ToLower();

            switch (action)
            {
                case "info":
                    if (parties.Length >= 3)
                    {
                        if (int.TryParse(parties[2], out int id))
                        {
                            var ligne = _serviceLigne.ObtenirParId(id);
                            if (ligne != null)
                            {
                                AjouterTexte($"=== INFORMATIONS LIGNE {id} ===", Color.Cyan);
                                AjouterTexte($"Numéro: {ligne.Numero}", Color.White);
                                AjouterTexte($"Nom: {ligne.Nom}", Color.White);
                                AjouterTexte($"Couleur: {ligne.Couleur}", Color.White);
                                AjouterTexte($"Active: {(ligne.EstActif ? "Oui" : "Non")}", Color.White);
                                AjouterTexte($"Créée le: {ligne.DateCreation:dd/MM/yyyy HH:mm}", Color.Gray);
                                if (ligne.DateModification.HasValue)
                                    AjouterTexte($"Modifiée le: {ligne.DateModification:dd/MM/yyyy HH:mm}", Color.Gray);
                            }
                            else
                            {
                                AjouterTexte($"Ligne avec l'ID {id} non trouvée.", Color.Red);
                            }
                        }
                    }
                    else
                    {
                        AjouterTexte("Usage: ligne info <id>", Color.Yellow);
                    }
                    break;

                case "arrets":
                    if (parties.Length >= 3)
                    {
                        if (int.TryParse(parties[2], out int id))
                        {
                            var ligne = _serviceLigne.ObtenirParId(id, true); // Inclure les arrêts

                            if (ligne != null)
                            {
                                AjouterTexte($"=== ARRÊTS DE LA LIGNE {ligne.Nom} ===", Color.Cyan);
                                AjouterTexte($"{"Ordre",-6} {"ID",-5} {"Nom",-25} {"Adresse",-30}", Color.Yellow);
                                AjouterTexte(new string('-', 70), Color.Gray);

                                for (int i = 0; i < ligne.Arrets.Count; i++)
                                {
                                    var arretLigne = ligne.Arrets[i];
                                    // Utiliser ArretId au lieu de IdArret
                                    var arret = _serviceArret.ObtenirParId(arretLigne.ArretId);
                                    if (arret != null)
                                    {
                                        AjouterTexte($"{arretLigne.Ordre,-6} {arret.Id,-5} {arret.Nom,-25} {arret.Adresse,-30}", Color.White);
                                    }
                                }
                                AjouterTexte($"\nTotal: {ligne.Arrets.Count} arrêts", Color.Green);
                            }
                            else
                            {
                                AjouterTexte($"Ligne avec l'ID {id} non trouvée.", Color.Red);
                            }
                        }
                    }
                    else
                    {
                        AjouterTexte("Usage: ligne arrets <id>", Color.Yellow);
                    }
                    break;

                default:
                    AjouterTexte("Actions disponibles: info, arrets", Color.Yellow);
                    break;
            }
        }

        private void TraiterCommandeHoraires(string[] parties)
        {
            AjouterTexte("=== GESTION DES HORAIRES ===", Color.Cyan);
            AjouterTexte("Fonctionnalité en cours de développement...", Color.Yellow);
        }

        private void TraiterCommandeItineraire(string[] parties)
        {
            if (parties.Length < 3)
            {
                AjouterTexte("Usage: itineraire <arret_depart> <arret_arrivee>", Color.Yellow);
                AjouterTexte("Vous pouvez utiliser:", Color.Gray);
                AjouterTexte("- L'ID de l'arrêt: itineraire 1 5", Color.Gray);
                AjouterTexte("- Le nom de l'arrêt: itineraire \"Gare Centrale\" \"Place du Marché\"", Color.Gray);
                return;
            }

            try
            {
                Arret arretDepart = null;
                Arret arretArrivee = null;

                // Récupérer l'arrêt de départ
                string departParam = parties[1].Trim('"');
                if (int.TryParse(departParam, out int idDepart))
                {
                    arretDepart = _serviceArret.ObtenirParId(idDepart);
                }
                else
                {
                    var arrets = _serviceArret.ObtenirTous();
                    arretDepart = arrets.FirstOrDefault(a => a.Nom.ToLower().Contains(departParam.ToLower()));
                }

                // Récupérer l'arrêt d'arrivée
                string arriveeParam = parties[2].Trim('"');
                if (int.TryParse(arriveeParam, out int idArrivee))
                {
                    arretArrivee = _serviceArret.ObtenirParId(idArrivee);
                }
                else
                {
                    var arrets = _serviceArret.ObtenirTous();
                    arretArrivee = arrets.FirstOrDefault(a => a.Nom.ToLower().Contains(arriveeParam.ToLower()));
                }

                // Vérifier que les arrêts existent
                if (arretDepart == null)
                {
                    AjouterTexte($"Arrêt de départ '{departParam}' non trouvé.", Color.Red);
                    AfficherArretsSuggeres(departParam);
                    return;
                }

                if (arretArrivee == null)
                {
                    AjouterTexte($"Arrêt d'arrivée '{arriveeParam}' non trouvé.", Color.Red);
                    AfficherArretsSuggeres(arriveeParam);
                    return;
                }

                if (arretDepart.Id == arretArrivee.Id)
                {
                    AjouterTexte("L'arrêt de départ et d'arrivée sont identiques.", Color.Yellow);
                    return;
                }

                AjouterTexte("=== RECHERCHE D'ITINÉRAIRE ===", Color.Cyan);
                AjouterTexte($"De: {arretDepart.Nom} (ID: {arretDepart.Id})", Color.White);
                AjouterTexte($"Vers: {arretArrivee.Nom} (ID: {arretArrivee.Id})", Color.White);
                AjouterTexte("", Color.White);

                // Rechercher l'itinéraire
                var itineraires = _serviceItineraire.RechercherItineraires(arretDepart.Id, arretArrivee.Id, DateTime.Now, true);

                if (itineraires == null || !itineraires.Any())
                {
                    AjouterTexte("Aucun itinéraire trouvé entre ces deux arrêts.", Color.Red);
                    AjouterTexte("Vérifiez que les arrêts sont bien connectés par le réseau de transport.", Color.Yellow);
                    return;
                }

                AjouterTexte($"Itinéraires trouvés: {itineraires.Count()}", Color.Green);
                AjouterTexte("", Color.White);

                for (int i = 0; i < itineraires.Count(); i++)
                {
                    var itineraire = itineraires[i];
                    AjouterTexte($"=== ITINÉRAIRE {i + 1} ===", Color.Cyan);

                    if (itineraire.Etapes != null && itineraire.Etapes.Any())
                    {
                        AjouterTexte($"Durée estimée: {itineraire.DureeMinutes} minutes", Color.Yellow);
                        AjouterTexte($"Nombre de correspondances: {itineraire.NombreChangements}", Color.Yellow);
                        AjouterTexte("", Color.White);

                        foreach (var etape in itineraire.Etapes)
                        {
                            var ligne = _serviceLigne.ObtenirParId(etape.LigneId);
                            var arretDep = _serviceArret.ObtenirParId(etape.ArretDepartId);
                            var arretArr = _serviceArret.ObtenirParId(etape.ArretArriveeId);

                            if (ligne != null && arretDep != null && arretArr != null)
                            {
                                AjouterTexte($"🚌 Ligne {ligne.Numero} ({ligne.Nom})", Color.Magenta);
                                AjouterTexte($"   📍 {arretDep.Nom} → {arretArr.Nom}", Color.White);
                                AjouterTexte($"   ⏱️ {etape.DureeMinutes} min", Color.Gray);

                                if (etape.HeureDepart != default)
                                {
                                    AjouterTexte($"   🕐 Départ: {etape.HeureDepart:HH:mm}", Color.Gray);
                                }
                                if (etape.HeureArrivee != default)
                                {
                                    AjouterTexte($"   🕐 Arrivée: {etape.HeureArrivee:HH:mm}", Color.Gray);
                                }
                                AjouterTexte("", Color.White);
                            }
                        }
                    }
                    else
                    {
                        AjouterTexte("Détails de l'itinéraire non disponibles.", Color.Yellow);
                    }

                    if (i < itineraires.Count() - 1)
                    {
                        AjouterTexte(new string('-', 50), Color.Gray);
                        AjouterTexte("", Color.White);
                    }
                }
            }
            catch (Exception ex)
            {
                AjouterTexte($"Erreur lors de la recherche d'itinéraire: {ex.Message}", Color.Red);
            }
        }

        private void AfficherArretsSuggeres(string recherche)
        {
            try
            {
                var arrets = _serviceArret.ObtenirTous();
                var suggestions = arrets
                    .Where(a => a.Nom.ToLower().Contains(recherche.ToLower()))
                    .Take(5)
                    .ToList();

                if (suggestions.Any())
                {
                    AjouterTexte("Arrêts similaires:", Color.Yellow);
                    foreach (var arret in suggestions)
                    {
                        AjouterTexte($"  {arret.Id}: {arret.Nom}", Color.Gray);
                    }
                }
                else
                {
                    AjouterTexte("Utilisez 'arrets' pour voir tous les arrêts disponibles.", Color.Gray);
                }
            }
            catch (Exception ex)
            {
                AjouterTexte($"Erreur lors de la recherche de suggestions: {ex.Message}", Color.Red);
            }
        }

        private void TraiterCommandeUtilisateurs(string[] parties)
        {
            if (_utilisateurConnecte?.Role != "Admin")
            {
                AjouterTexte("Accès refusé. Droits administrateur requis.", Color.Red);
                return;
            }

            AjouterTexte("=== GESTION DES UTILISATEURS ===", Color.Cyan);
            AjouterTexte("Fonctionnalité en cours de développement...", Color.Yellow);
        }

        private void AfficherReseau()
        {
            AjouterTexte("=== RÉSEAU DE TRANSPORT FUMOBILITE ===", Color.Cyan);

            try
            {
                var lignes = _serviceLigne.ObtenirToutes();
                var arrets = _serviceArret.ObtenirTous();

                AjouterTexte($"Statistiques du réseau:", Color.Yellow);
                AjouterTexte($"- Lignes actives: {lignes.Where(l => l.EstActif).Count()}", Color.White);
                AjouterTexte($"- Total lignes: {lignes.Count}", Color.White);
                AjouterTexte($"- Arrêts accessibles: {arrets.Where(a => a.EstAccessible).Count()}", Color.White);
                AjouterTexte($"- Total arrêts: {arrets.Count}", Color.White);
                AjouterTexte("", Color.White);

                AjouterTexte("Lignes disponibles:", Color.Yellow);
                foreach (var ligne in lignes.Where(l => l.EstActif))
                {
                    var arretsLigne = ligne.Arrets; // Utiliser la propriété Arrets de la ligne
                    AjouterTexte($"- {ligne.Nom} (#{ligne.Numero}, {ligne.Couleur}) - {arretsLigne.Count} arrêts", Color.White);
                }
            }
            catch (Exception ex)
            {
                AjouterTexte($"Erreur lors du chargement du réseau: {ex.Message}", Color.Red);
            }
        }

        private void AfficherAide()
        {
            AjouterTexte("=== COMMANDES DISPONIBLES ===", Color.Cyan);
            AjouterTexte("", Color.White);

            AjouterTexte("CONSULTATION:", Color.Yellow);
            AjouterTexte("  reseau                    - Afficher le réseau de transport", Color.White);
            AjouterTexte("  lignes                    - Lister toutes les lignes", Color.White);
            AjouterTexte("  ligne info <id>           - Informations sur une ligne", Color.White);
            AjouterTexte("  ligne arrets <id>         - Arrêts d'une ligne", Color.White);
            AjouterTexte("  itineraire <dep> <arr>    - Rechercher un itinéraire", Color.White);
            AjouterTexte("", Color.White);

            if (_utilisateurConnecte?.Role == "Admin")
            {
                AjouterTexte("ADMINISTRATION:", Color.Yellow);
                AjouterTexte("  arrets                    - Lister tous les arrêts", Color.White);
                AjouterTexte("  arret add <nom> <adr> <lat> <lng> [acc] - Créer un arrêt", Color.White);
                AjouterTexte("  arret info <id>           - Informations sur un arrêt", Color.White);
                AjouterTexte("  arret delete <id>         - Supprimer un arrêt", Color.White);
                AjouterTexte("  utilisateurs              - Gestion des utilisateurs", Color.White);
                AjouterTexte("", Color.White);
            }

            AjouterTexte("SYSTÈME:", Color.Yellow);
            AjouterTexte("  status                    - Afficher le statut", Color.White);
            AjouterTexte("  help                      - Afficher cette aide", Color.White);
            AjouterTexte("  clear                     - Effacer la console", Color.White);
            AjouterTexte("  historique                - Voir l'historique de vos commandes", Color.White);
            AjouterTexte("  historique export         - Exporter l'historique en CSV", Color.White);
            AjouterTexte("  exit/fermer               - Fermer la console", Color.White);
            AjouterTexte("  quitter                   - Quitter l'application", Color.White);
            AjouterTexte("", Color.White);

            AjouterTexte("RACCOURCIS:", Color.Yellow);
            AjouterTexte("  ↑/↓                       - Naviguer dans l'historique", Color.White);
            AjouterTexte("  Tab                       - Auto-complétion", Color.White);
            AjouterTexte("  Échap                     - Fermer la console", Color.White);
        }

        private void AfficherStatus()
        {
            AjouterTexte("=== STATUT SYSTÈME ===", Color.Cyan);

            if (_utilisateurConnecte != null)
            {
                AjouterTexte($"Utilisateur: {_utilisateurConnecte.Prenom} {_utilisateurConnecte.Nom}", Color.Green);
                AjouterTexte($"Rôle: {_utilisateurConnecte.Role}", Color.Green);
                AjouterTexte("Statut: Connecté", Color.Green);
            }
            else
            {
                AjouterTexte("Utilisateur: Non connecté", Color.Yellow);
                AjouterTexte("Statut: Mode invité", Color.Yellow);
            }

            try
            {
                var arrets = _serviceArret.ObtenirTous();
                var lignes = _serviceLigne.ObtenirToutes();

                AjouterTexte($"Base de données: Connectée", Color.Green);
                AjouterTexte($"Arrêts en base: {arrets.Count}", Color.White);
                AjouterTexte($"Lignes en base: {lignes.Count}", Color.White);
            }
            catch
            {
                AjouterTexte($"Base de données: Erreur de connexion", Color.Red);
            }

            AjouterTexte($"Heure: {DateTime.Now:HH:mm:ss}", Color.White);
            AjouterTexte($"Date: {DateTime.Now:dd/MM/yyyy}", Color.White);
        }

        private void NaviguerHistorique(int direction)
        {
            if (_historiqueCommandes.Count == 0) return;

            _indexHistorique += direction;

            if (_indexHistorique < 0)
                _indexHistorique = 0;
            else if (_indexHistorique >= _historiqueCommandes.Count)
            {
                _indexHistorique = _historiqueCommandes.Count;
                txtCommande.Text = "";
                return;
            }

            txtCommande.Text = _historiqueCommandes[_indexHistorique];
            txtCommande.SelectionStart = txtCommande.Text.Length;
        }

        private void AutoCompleter()
        {
            string textePartiel = txtCommande.Text.ToLower();

            if (string.IsNullOrEmpty(textePartiel)) return;

            List<string> commandesBase = new List<string>
            {
                "help", "clear", "status", "exit", "fermer", "quitter",
                "reseau", "lignes", "ligne", "itineraire", "horaires"
            };

            if (_utilisateurConnecte?.Role == "Admin")
            {
                commandesBase.AddRange(new[] { "arrets", "arret", "utilisateurs" });
            }

            var commandesCorrespondantes = commandesBase
                .Where(cmd => cmd.StartsWith(textePartiel))
                .ToList();

            if (commandesCorrespondantes.Count == 1)
            {
                txtCommande.Text = commandesCorrespondantes[0];
                txtCommande.SelectionStart = txtCommande.Text.Length;
            }
            else if (commandesCorrespondantes.Count > 1)
            {
                AjouterTexte($"Suggestions: {string.Join(", ", commandesCorrespondantes)}", Color.Cyan);
                AfficherPrompt();
            }
        }

        private void FermerConsole()
        {
            // Retourner au mode normal
            _formPrincipal.FermerModeConsole();
        }

        private void UCInviteCommande_Load(object sender, EventArgs e)
        {
            // Donner le focus au champ de saisie
            txtCommande.Focus();
        }
    }
}
