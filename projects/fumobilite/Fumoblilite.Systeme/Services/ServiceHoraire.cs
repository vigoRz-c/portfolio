using System;
using System.Collections.Generic;
using System.Linq;
using Fumoblilite.Systeme.Modeles;
using Fumoblilite.Systeme.Interfaces;

namespace Fumoblilite.Systeme.Services
{
    /// <summary>
    /// Service de gestion des horaires pour les lignes et arrêts.
    /// </summary>
    public class ServiceHoraire
    {
        /// <summary>
        /// Référence au dépôt d'horaires.
        /// </summary>
        private readonly IRepositoryHoraire _repositoryHoraire;

        /// <summary>
        /// Initialise une nouvelle instance du service avec le dépôt spécifié.
        /// </summary>
        /// <param name="repositoryHoraire">Le dépôt d'horaires à utiliser.</param>
        public ServiceHoraire(IRepositoryHoraire repositoryHoraire)
        {
            _repositoryHoraire = repositoryHoraire;
        }

        /// <summary>
        /// Obtient la liste des horaires pour une ligne donnée.
        /// </summary>
        /// <param name="ligneId">Identifiant de la ligne.</param>
        /// <returns>Liste des horaires.</returns>
        public List<Horaire> ObtenirParLigne(int ligneId)
        {
            return _repositoryHoraire.ObtenirParLigne(ligneId);
        }

        /// <summary>
        /// Obtient la liste des horaires pour un arrêt donné.
        /// </summary>
        /// <param name="arretId">Identifiant de l'arrêt.</param>
        /// <returns>Liste des horaires.</returns>
        public List<Horaire> ObtenirParArret(int arretId)
        {
            return _repositoryHoraire.ObtenirParArret(arretId);
        }

        /// <summary>
        /// Obtient la liste des horaires pour une ligne et un jour donnés.
        /// </summary>
        /// <param name="ligneId">Identifiant de la ligne.</param>
        /// <param name="jour">Jour de la semaine.</param>
        /// <returns>Liste des horaires.</returns>
        public List<Horaire> ObtenirParLigneEtJour(int ligneId, DayOfWeek jour)
        {
            return _repositoryHoraire.ObtenirParLigneEtJour(ligneId, jour);
        }

        /// <summary>
        /// Obtient la liste des horaires pour un jour donné.
        /// </summary>
        /// <param name="jour">Jour de la semaine.</param>
        /// <returns>Liste des horaires.</returns>
        public List<Horaire> ObtenirParJour(DayOfWeek jour)
        {
            return _repositoryHoraire.ObtenirParJour(jour);
        }

        /// <summary>
        /// Obtient la liste des horaires pour un arrêt et un jour donnés.
        /// </summary>
        /// <param name="arretId">Identifiant de l'arrêt.</param>
        /// <param name="jour">Jour de la semaine.</param>
        /// <returns>Liste des horaires.</returns>
        public List<Horaire> ObtenirParArretEtJour(int arretId, DayOfWeek jour)
        {
            return _repositoryHoraire.ObtenirParArretEtJour(arretId, jour);
        }

        /// <summary>
        /// Obtient la liste des horaires selon des critères avancés.
        /// </summary>
        /// <param name="criteres">Critères de recherche.</param>
        /// <returns>Liste des horaires.</returns>
        public List<Horaire> ObtenirParCriteres(HoraireCriteres criteres)
        {
            return _repositoryHoraire.ObtenirParCriteres(criteres);
        }

        /// <summary>
        /// Obtient les prochains horaires pour un arrêt à partir d'une date/heure donnée.
        /// </summary>
        /// <param name="arretId">Identifiant de l'arrêt.</param>
        /// <param name="dateHeure">Date et heure de référence.</param>
        /// <param name="limite">Nombre maximum de résultats.</param>
        /// <returns>Liste des prochains horaires.</returns>
        public List<Horaire> ObtenirProchains(int arretId, DateTime dateHeure, int limite = 10)
        {
            return _repositoryHoraire.ObtenirProchains(arretId, dateHeure, limite);
        }

        /// <summary>
        /// Obtient la liste des horaires pour une plage horaire donnée.
        /// </summary>
        /// <param name="ligneId">Identifiant de la ligne.</param>
        /// <param name="jour">Jour de la semaine.</param>
        /// <param name="heureDebut">Heure de début.</param>
        /// <param name="heureFin">Heure de fin.</param>
        /// <returns>Liste des horaires.</returns>
        public List<Horaire> ObtenirParPlageHoraire(int ligneId, DayOfWeek jour, TimeSpan heureDebut, TimeSpan heureFin)
        {
            return _repositoryHoraire.ObtenirParPlageHoraire(ligneId, jour, heureDebut, heureFin);
        }

        /// <summary>
        /// Vérifie l'existence d'un horaire pour une ligne, un arrêt, un jour et une heure donnés.
        /// </summary>
        /// <param name="ligneId">Identifiant de la ligne.</param>
        /// <param name="arretId">Identifiant de l'arrêt.</param>
        /// <param name="jour">Jour de la semaine.</param>
        /// <param name="heure">Heure de départ.</param>
        /// <returns>Vrai si l'horaire existe, sinon faux.</returns>
        public bool ExisteHoraire(int ligneId, int arretId, DayOfWeek jour, TimeSpan heure)
        {
            return _repositoryHoraire.ExisteHoraire(ligneId, arretId, jour, heure);
        }

        /// <summary>
        /// Ajoute un nouvel horaire après validation.
        /// </summary>
        /// <param name="horaire">Horaire à ajouter.</param>
        /// <returns>Identifiant de l'horaire ajouté.</returns>
        public int Ajouter(Horaire horaire)
        {
            ValiderHoraire(horaire);
            return _repositoryHoraire.Ajouter(horaire);
        }

        /// <summary>
        /// Ajoute une liste d'horaires après validation.
        /// </summary>
        /// <param name="horaires">Liste des horaires à ajouter.</param>
        /// <returns>Nombre d'horaires ajoutés.</returns>
        public int AjouterEnLot(List<Horaire> horaires)
        {
            foreach (var horaire in horaires)
            {
                ValiderHoraire(horaire);
            }
            return _repositoryHoraire.AjouterEnLot(horaires);
        }

        /// <summary>
        /// Modifie un horaire existant après validation.
        /// </summary>
        /// <param name="horaire">Horaire à modifier.</param>
        /// <returns>Vrai si la modification a réussi, sinon faux.</returns>
        public bool Modifier(Horaire horaire)
        {
            ValiderHoraire(horaire);
            horaire.DateModification = DateTime.Now;
            return _repositoryHoraire.Modifier(horaire);
        }

        /// <summary>
        /// Supprime un horaire par son identifiant.
        /// </summary>
        /// <param name="id">Identifiant de l'horaire à supprimer.</param>
        /// <returns>Vrai si la suppression a réussi, sinon faux.</returns>
        public bool Supprimer(int id)
        {
            return _repositoryHoraire.Supprimer(id);
        }

        /// <summary>
        /// Supprime les horaires correspondant à des critères donnés.
        /// </summary>
        /// <param name="criteres">Critères de suppression.</param>
        /// <returns>Vrai si la suppression a réussi, sinon faux.</returns>
        public bool SupprimerParCriteres(HoraireCriteres criteres)
        {
            return _repositoryHoraire.SupprimerParCriteres(criteres);
        }

        /// <summary>
        /// Obtient des statistiques du nombre d'horaires par jour pour une ligne.
        /// </summary>
        /// <param name="ligneId">Identifiant de la ligne.</param>
        /// <returns>Dictionnaire des jours et du nombre d'horaires.</returns>
        public Dictionary<DayOfWeek, int> ObtenirStatistiquesParJour(int ligneId)
        {
            return _repositoryHoraire.ObtenirStatistiquesParJour(ligneId);
        }

        /// <summary>
        /// Obtient des statistiques globales par ligne.
        /// </summary>
        /// <returns>Liste des statistiques par ligne.</returns>
        public List<HoraireStatistique> ObtenirStatistiquesParLigne()
        {
            return _repositoryHoraire.ObtenirStatistiquesParLigne();
        }

        /// <summary>
        /// Génère des horaires récurrents pour une ligne, un arrêt, des jours et une plage horaire donnés.
        /// </summary>
        /// <param name="ligneId">Identifiant de la ligne.</param>
        /// <param name="arretId">Identifiant de l'arrêt.</param>
        /// <param name="jours">Liste des jours de la semaine.</param>
        /// <param name="heureDebut">Heure de début.</param>
        /// <param name="heureFin">Heure de fin.</param>
        /// <param name="intervalle">Intervalle entre chaque horaire.</param>
        /// <returns>Liste des horaires générés.</returns>
        public List<Horaire> GenererHorairesRecurrents(int ligneId, int arretId, List<DayOfWeek> jours,
            TimeSpan heureDebut, TimeSpan heureFin, TimeSpan intervalle)
        {
            var horaires = new List<Horaire>();

            foreach (var jour in jours)
            {
                var heureActuelle = heureDebut;
                while (heureActuelle <= heureFin)
                {
                    if (!ExisteHoraire(ligneId, arretId, jour, heureActuelle))
                    {
                        horaires.Add(new Horaire
                        {
                            LigneId = ligneId,
                            ArretId = arretId,
                            JourSemaine = jour,
                            HeureDepart = heureActuelle,
                            EstActif = true
                        });
                    }
                    heureActuelle = heureActuelle.Add(intervalle);
                }
            }

            return horaires;
        }

        /// <summary>
        /// Duplique les horaires d'une ligne source vers une ligne destination, éventuellement pour certains jours.
        /// </summary>
        /// <param name="ligneSourceId">Identifiant de la ligne source.</param>
        /// <param name="ligneDestinationId">Identifiant de la ligne destination.</param>
        /// <param name="jours">Liste optionnelle des jours à dupliquer.</param>
        /// <returns>Liste des nouveaux horaires à ajouter.</returns>
        public List<Horaire> DupliquerHoraires(int ligneSourceId, int ligneDestinationId, List<DayOfWeek> jours = null)
        {
            var horairesSource = ObtenirParLigne(ligneSourceId);
            var nouveauxHoraires = new List<Horaire>();

            foreach (var horaireSource in horairesSource)
            {
                if (jours == null || jours.Contains(horaireSource.JourSemaine))
                {
                    if (!ExisteHoraire(ligneDestinationId, horaireSource.ArretId, horaireSource.JourSemaine, horaireSource.HeureDepart))
                    {
                        nouveauxHoraires.Add(new Horaire
                        {
                            LigneId = ligneDestinationId,
                            ArretId = horaireSource.ArretId,
                            JourSemaine = horaireSource.JourSemaine,
                            HeureDepart = horaireSource.HeureDepart,
                            EstActif = horaireSource.EstActif
                        });
                    }
                }
            }

            return nouveauxHoraires;
        }

        /// <summary>
        /// Optimise les horaires d'une ligne pour un jour donné en supprimant les doublons et les horaires trop rapprochés.
        /// </summary>
        /// <param name="ligneId">Identifiant de la ligne.</param>
        /// <param name="jour">Jour de la semaine.</param>
        public void OptimiserHoraires(int ligneId, DayOfWeek jour)
        {
            var horaires = ObtenirParLigneEtJour(ligneId, jour).OrderBy(h => h.HeureDepart).ToList();

            // Supprimer les doublons exacts
            for (int i = horaires.Count - 1; i > 0; i--)
            {
                if (horaires[i].HeureDepart == horaires[i - 1].HeureDepart &&
                    horaires[i].ArretId == horaires[i - 1].ArretId)
                {
                    Supprimer(horaires[i].Id);
                }
            }

            // Identifier les horaires trop rapprochés (moins de 2 minutes)
            var horairesASupprimer = new List<int>();
            for (int i = 1; i < horaires.Count; i++)
            {
                if (horaires[i].ArretId == horaires[i - 1].ArretId)
                {
                    var ecart = horaires[i].HeureDepart - horaires[i - 1].HeureDepart;
                    if (ecart.TotalMinutes < 2)
                    {
                        horairesASupprimer.Add(horaires[i].Id);
                    }
                }
            }

            foreach (var id in horairesASupprimer)
            {
                Supprimer(id);
            }
        }

        /// <summary>
        /// Valide la cohérence des horaires d'une ligne (trous, heures de pointe...).
        /// </summary>
        /// <param name="ligneId">Identifiant de la ligne.</param>
        /// <returns>Liste des messages d'erreur de cohérence.</returns>
        public List<string> ValiderCoherenceHoraires(int ligneId)
        {
            var erreurs = new List<string>();
            var horaires = ObtenirParLigne(ligneId);

            // Vérifier les horaires par jour
            foreach (DayOfWeek jour in Enum.GetValues(typeof(DayOfWeek)))
            {
                var horairesJour = horaires.Where(h => h.JourSemaine == jour).OrderBy(h => h.HeureDepart).ToList();

                // Vérifier qu'il n'y a pas de trous importants (plus de 2 heures sans service)
                for (int i = 1; i < horairesJour.Count; i++)
                {
                    var ecart = horairesJour[i].HeureDepart - horairesJour[i - 1].HeureDepart;
                    if (ecart.TotalHours > 2)
                    {
                        erreurs.Add($"{jour}: Écart important entre {horairesJour[i - 1].HeureDepart:hh\\:mm} et {horairesJour[i].HeureDepart:hh\\:mm}");
                    }
                }

                // Vérifier les heures de pointe (7h-9h et 17h-19h)
                var heuresPointe1 = horairesJour.Where(h => h.HeureDepart >= TimeSpan.FromHours(7) && h.HeureDepart <= TimeSpan.FromHours(9)).Count();
                var heuresPointe2 = horairesJour.Where(h => h.HeureDepart >= TimeSpan.FromHours(17) && h.HeureDepart <= TimeSpan.FromHours(19)).Count();

                if (heuresPointe1 < 3)
                    erreurs.Add($"{jour}: Peu de services en heure de pointe matinale (7h-9h): {heuresPointe1}");

                if (heuresPointe2 < 3)
                    erreurs.Add($"{jour}: Peu de services en heure de pointe vespérale (17h-19h): {heuresPointe2}");
            }

            return erreurs;
        }

        /// <summary>
        /// Valide les propriétés d'un horaire avant ajout ou modification.
        /// </summary>
        /// <param name="horaire">Horaire à valider.</param>
        private void ValiderHoraire(Horaire horaire)
        {
            if (horaire.LigneId <= 0)
                throw new ArgumentException("L'ID de la ligne doit être positif.");

            if (horaire.ArretId <= 0)
                throw new ArgumentException("L'ID de l'arrêt doit être positif.");

            if (horaire.HeureDepart < TimeSpan.Zero || horaire.HeureDepart >= TimeSpan.FromDays(1))
                throw new ArgumentException("L'heure de départ doit être comprise entre 00:00 et 23:59.");

            if (!Enum.IsDefined(typeof(DayOfWeek), horaire.JourSemaine))
                throw new ArgumentException("Le jour de la semaine n'est pas valide.");
        }
    }
}
