using System;
using System.Collections.Generic;
using System.Linq;
using Fumoblilite.Systeme.Modeles;
using Fumoblilite.Systeme.Interfaces;

namespace Fumoblilite.Systeme.Services
{
    /// <summary>
    /// Service permettant de rechercher des itinéraires entre deux arrêts à une date/heure donnée.
    /// </summary>
    public class ServiceItineraire
    {
        /// <summary>
        /// Référentiel des arrêts.
        /// </summary>
        private readonly IRepositoryArret _repositoryArret;

        /// <summary>
        /// Référentiel des lignes.
        /// </summary>
        private readonly IRepositoryLigne _repositoryLigne;

        /// <summary>
        /// Référentiel des arrêts de ligne.
        /// </summary>
        private readonly IRepositoryArretLigne _repositoryArretLigne;

        /// <summary>
        /// Référentiel des horaires.
        /// </summary>
        private readonly IRepositoryHoraire _repositoryHoraire;

        /// <summary>
        /// Constructeur du service d'itinéraire.
        /// </summary>
        /// <param name="repositoryArret">Référentiel des arrêts</param>
        /// <param name="repositoryLigne">Référentiel des lignes</param>
        /// <param name="repositoryArretLigne">Référentiel des arrêts de ligne</param>
        /// <param name="repositoryHoraire">Référentiel des horaires</param>
        public ServiceItineraire(
            IRepositoryArret repositoryArret,
            IRepositoryLigne repositoryLigne,
            IRepositoryArretLigne repositoryArretLigne,
            IRepositoryHoraire repositoryHoraire)
        {
            _repositoryArret = repositoryArret;
            _repositoryLigne = repositoryLigne;
            _repositoryArretLigne = repositoryArretLigne;
            _repositoryHoraire = repositoryHoraire;
        }

        /// <summary>
        /// Recherche les itinéraires possibles entre deux arrêts à une date/heure donnée.
        /// </summary>
        /// <param name="arretDepartId">Identifiant de l'arrêt de départ</param>
        /// <param name="arretArriveeId">Identifiant de l'arrêt d'arrivée</param>
        /// <param name="dateHeure">Date et heure de recherche</param>
        /// <param name="estHeureDepart">Indique si la recherche se base sur l'heure de départ (true) ou d'arrivée (false)</param>
        /// <returns>Liste des itinéraires trouvés</returns>
        public List<Itineraire> RechercherItineraires(int arretDepartId, int arretArriveeId, DateTime dateHeure, bool estHeureDepart = true)
        {
            List<Itineraire> itineraires = new List<Itineraire>();

            // Obtenir tous les arrêts et lignes pour construire le graphe du réseau
            var tousLesArrets = _repositoryArret.ObtenirTous();
            var toutesLesLignes = _repositoryLigne.ObtenirToutes();

            // Pour chaque ligne, obtenir ses arrêts
            foreach (var ligne in toutesLesLignes)
            {
                ligne.Arrets = _repositoryArretLigne.ObtenirParLigne(ligne.Id);
            }

            // Obtenir les horaires pour le jour de la semaine spécifié
            var horaires = _repositoryHoraire.ObtenirParJour(dateHeure.DayOfWeek);

            // Algorithme simplifié pour trouver des itinéraires
            // Dans une implémentation réelle, on utiliserait un algorithme plus sophistiqué comme Dijkstra

            // Trouver les lignes directes
            var itinerairesDirects = TrouverItinerairesDirects(arretDepartId, arretArriveeId, dateHeure, estHeureDepart, toutesLesLignes, horaires);
            itineraires.AddRange(itinerairesDirects);

            // Trouver les itinéraires avec un changement
            var itinerairesAvecUnChangement = TrouverItinerairesAvecUnChangement(arretDepartId, arretArriveeId, dateHeure, estHeureDepart, toutesLesLignes, horaires);
            itineraires.AddRange(itinerairesAvecUnChangement);

            // Trier les itinéraires par durée
            itineraires = itineraires.OrderBy(i => i.DureeMinutes).ToList();

            return itineraires;
        }

        /// <summary>
        /// Recherche les itinéraires directs (sans changement) entre deux arrêts.
        /// </summary>
        /// <param name="arretDepartId">Identifiant de l'arrêt de départ</param>
        /// <param name="arretArriveeId">Identifiant de l'arrêt d'arrivée</param>
        /// <param name="dateHeure">Date et heure de recherche</param>
        /// <param name="estHeureDepart">Indique si la recherche se base sur l'heure de départ (true) ou d'arrivée (false)</param>
        /// <param name="toutesLesLignes">Liste de toutes les lignes</param>
        /// <param name="horaires">Liste des horaires du jour</param>
        /// <returns>Liste des itinéraires directs trouvés</returns>
        private List<Itineraire> TrouverItinerairesDirects(
            int arretDepartId,
            int arretArriveeId,
            DateTime dateHeure,
            bool estHeureDepart,
            List<Ligne> toutesLesLignes,
            List<Horaire> horaires)
        {
            List<Itineraire> itineraires = new List<Itineraire>();

            // Trouver les lignes qui contiennent à la fois l'arrêt de départ et l'arrêt d'arrivée
            foreach (var ligne in toutesLesLignes)
            {
                var arretDepart = ligne.Arrets.FirstOrDefault(a => a.ArretId == arretDepartId);
                var arretArrivee = ligne.Arrets.FirstOrDefault(a => a.ArretId == arretArriveeId);

                if (arretDepart != null && arretArrivee != null)
                {
                    // Vérifier que l'arrêt de départ est avant l'arrêt d'arrivée dans la séquence
                    if (arretDepart.Ordre < arretArrivee.Ordre)
                    {
                        // Calculer le temps de trajet entre les deux arrêts
                        int tempsTrajetMinutes = CalculerTempsTrajet(ligne.Arrets, arretDepart.Ordre, arretArrivee.Ordre);

                        // Trouver les horaires de départ appropriés
                        var horairesDepartPossibles = horaires
                            .Where(h => h.LigneId == ligne.Id && h.ArretId == arretDepartId)
                            .ToList();

                        foreach (var horaireDepart in horairesDepartPossibles)
                        {
                            DateTime heureDepart = dateHeure.Date.Add(horaireDepart.HeureDepart);

                            // Ajuster en fonction de si on cherche à partir d'une heure de départ ou d'arrivée
                            if (!estHeureDepart)
                            {
                                heureDepart = dateHeure.AddMinutes(-tempsTrajetMinutes);
                            }
                            else if (heureDepart < dateHeure)
                            {
                                continue; // Ignorer les départs antérieurs à l'heure demandée
                            }

                            DateTime heureArrivee = heureDepart.AddMinutes(tempsTrajetMinutes);

                            Itineraire itineraire = new Itineraire
                            {
                                ArretDepartId = arretDepartId,
                                ArretArriveeId = arretArriveeId,
                                HeureDepart = heureDepart,
                                HeureArrivee = heureArrivee,
                                DureeMinutes = tempsTrajetMinutes,
                                NombreChangements = 0,
                                Etapes = new List<EtapeItineraire>
                                    {
                                        new EtapeItineraire
                                        {
                                            LigneId = ligne.Id,
                                            NomLigne = ligne.Nom,
                                            CouleurLigne = ligne.Couleur,
                                            ArretDepartId = arretDepartId,
                                            NomArretDepart = arretDepart.Arret?.Nom,
                                            ArretArriveeId = arretArriveeId,
                                            NomArretArrivee = arretArrivee.Arret?.Nom,
                                            HeureDepart = heureDepart,
                                            HeureArrivee = heureArrivee,
                                            DureeMinutes = tempsTrajetMinutes
                                        }
                                    }
                            };

                            itineraires.Add(itineraire);
                        }
                    }
                }
            }

            return itineraires;
        }

        /// <summary>
        /// Recherche les itinéraires avec un changement entre deux arrêts.
        /// </summary>
        /// <param name="arretDepartId">Identifiant de l'arrêt de départ</param>
        /// <param name="arretArriveeId">Identifiant de l'arrêt d'arrivée</param>
        /// <param name="dateHeure">Date et heure de recherche</param>
        /// <param name="estHeureDepart">Indique si la recherche se base sur l'heure de départ (true) ou d'arrivée (false)</param>
        /// <param name="toutesLesLignes">Liste de toutes les lignes</param>
        /// <param name="horaires">Liste des horaires du jour</param>
        /// <returns>Liste des itinéraires avec un changement trouvés</returns>
        private List<Itineraire> TrouverItinerairesAvecUnChangement(
            int arretDepartId,
            int arretArriveeId,
            DateTime dateHeure,
            bool estHeureDepart,
            List<Ligne> toutesLesLignes,
            List<Horaire> horaires)
        {
            List<Itineraire> itineraires = new List<Itineraire>();

            // Trouver les lignes qui contiennent l'arrêt de départ
            var lignesAvecArretDepart = toutesLesLignes
                .Where(l => l.Arrets.Any(a => a.ArretId == arretDepartId))
                .ToList();

            // Trouver les lignes qui contiennent l'arrêt d'arrivée
            var lignesAvecArretArrivee = toutesLesLignes
                .Where(l => l.Arrets.Any(a => a.ArretId == arretArriveeId))
                .ToList();

            // Pour chaque ligne avec l'arrêt de départ
            foreach (var ligneDepart in lignesAvecArretDepart)
            {
                var arretDepart = ligneDepart.Arrets.First(a => a.ArretId == arretDepartId);

                // Pour chaque ligne avec l'arrêt d'arrivée
                foreach (var ligneArrivee in lignesAvecArretArrivee)
                {
                    // Ignorer si c'est la même ligne (déjà traité dans les itinéraires directs)
                    if (ligneDepart.Id == ligneArrivee.Id)
                        continue;

                    var arretArrivee = ligneArrivee.Arrets.First(a => a.ArretId == arretArriveeId);

                    // Trouver les arrêts communs entre les deux lignes (points de correspondance)
                    var arretsCommuns = ligneDepart.Arrets
                        .Select(a => a.ArretId)
                        .Intersect(ligneArrivee.Arrets.Select(a => a.ArretId))
                        .ToList();

                    foreach (var arretCommunId in arretsCommuns)
                    {
                        var arretCommunLigneDepart = ligneDepart.Arrets.First(a => a.ArretId == arretCommunId);
                        var arretCommunLigneArrivee = ligneArrivee.Arrets.First(a => a.ArretId == arretCommunId);

                        // Vérifier que l'arrêt de départ est avant l'arrêt commun dans la première ligne
                        if (arretDepart.Ordre < arretCommunLigneDepart.Ordre)
                        {
                            // Vérifier que l'arrêt commun est avant l'arrêt d'arrivée dans la deuxième ligne
                            if (arretCommunLigneArrivee.Ordre < arretArrivee.Ordre)
                            {
                                // Calculer les temps de trajet
                                int tempsTrajet1 = CalculerTempsTrajet(ligneDepart.Arrets, arretDepart.Ordre, arretCommunLigneDepart.Ordre);
                                int tempsTrajet2 = CalculerTempsTrajet(ligneArrivee.Arrets, arretCommunLigneArrivee.Ordre, arretArrivee.Ordre);
                                int tempsCorrespondance = 5; // Temps de correspondance en minutes

                                // Trouver les horaires de départ appropriés
                                var horairesDepartPossibles = horaires
                                    .Where(h => h.LigneId == ligneDepart.Id && h.ArretId == arretDepartId)
                                    .ToList();

                                foreach (var horaireDepart in horairesDepartPossibles)
                                {
                                    DateTime heureDepart = dateHeure.Date.Add(horaireDepart.HeureDepart);

                                    // Ajuster en fonction de si on cherche à partir d'une heure de départ ou d'arrivée
                                    if (!estHeureDepart)
                                    {
                                        heureDepart = dateHeure.AddMinutes(-(tempsTrajet1 + tempsCorrespondance + tempsTrajet2));
                                    }
                                    else if (heureDepart < dateHeure)
                                    {
                                        continue; // Ignorer les départs antérieurs à l'heure demandée
                                    }

                                    DateTime heureArriveeCorrespondance = heureDepart.AddMinutes(tempsTrajet1);
                                    DateTime heureDepartCorrespondance = heureArriveeCorrespondance.AddMinutes(tempsCorrespondance);
                                    DateTime heureArrivee = heureDepartCorrespondance.AddMinutes(tempsTrajet2);

                                    Itineraire itineraire = new Itineraire
                                    {
                                        ArretDepartId = arretDepartId,
                                        ArretArriveeId = arretArriveeId,
                                        HeureDepart = heureDepart,
                                        HeureArrivee = heureArrivee,
                                        DureeMinutes = tempsTrajet1 + tempsCorrespondance + tempsTrajet2,
                                        NombreChangements = 1,
                                        Etapes = new List<EtapeItineraire>
                                            {
                                                new EtapeItineraire
                                                {
                                                    LigneId = ligneDepart.Id,
                                                    NomLigne = ligneDepart.Nom,
                                                    CouleurLigne = ligneDepart.Couleur,
                                                    ArretDepartId = arretDepartId,
                                                    NomArretDepart = arretDepart.Arret?.Nom,
                                                    ArretArriveeId = arretCommunId,
                                                    NomArretArrivee = arretCommunLigneDepart.Arret?.Nom,
                                                    HeureDepart = heureDepart,
                                                    HeureArrivee = heureArriveeCorrespondance,
                                                    DureeMinutes = tempsTrajet1
                                                },
                                                new EtapeItineraire
                                                {
                                                    LigneId = ligneArrivee.Id,
                                                    NomLigne = ligneArrivee.Nom,
                                                    CouleurLigne = ligneArrivee.Couleur,
                                                    ArretDepartId = arretCommunId,
                                                    NomArretDepart = arretCommunLigneArrivee.Arret?.Nom,
                                                    ArretArriveeId = arretArriveeId,
                                                    NomArretArrivee = arretArrivee.Arret?.Nom,
                                                    HeureDepart = heureDepartCorrespondance,
                                                    HeureArrivee = heureArrivee,
                                                    DureeMinutes = tempsTrajet2
                                                }
                                            }
                                    };

                                    itineraires.Add(itineraire);
                                }
                            }
                        }
                    }
                }
            }

            return itineraires;
        }

        /// <summary>
        /// Calcule le temps de trajet total entre deux arrêts d'une ligne.
        /// </summary>
        /// <param name="arrets">Liste des arrêts de la ligne</param>
        /// <param name="ordreDepart">Ordre de l'arrêt de départ</param>
        /// <param name="ordreArrivee">Ordre de l'arrêt d'arrivée</param>
        /// <returns>Temps total de trajet en minutes</returns>
        private int CalculerTempsTrajet(List<ArretLigne> arrets, int ordreDepart, int ordreArrivee)
        {
            int tempsTotal = 0;

            for (int i = ordreDepart; i < ordreArrivee; i++)
            {
                var arretCourant = arrets.FirstOrDefault(a => a.Ordre == i);
                if (arretCourant != null)
                {
                    tempsTotal += arretCourant.TempsArretMinutes + arretCourant.TempsTrajetSuivantMinutes;
                }
            }

            return tempsTotal;
        }
    }
}

