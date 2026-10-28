using System;
using System.Collections.Generic;
using Fumoblilite.Systeme.Modeles;

namespace Fumoblilite.Systeme.Interfaces
{
    /// <summary>
    /// Interface pour la gestion des horaires dans le système.
    /// </summary>
    public interface IRepositoryHoraire
    {
        /// <summary>
        /// Obtient la liste des horaires pour une ligne donnée.
        /// </summary>
        /// <param name="ligneId">Identifiant de la ligne.</param>
        /// <returns>Liste des horaires.</returns>
        List<Horaire> ObtenirParLigne(int ligneId);

        /// <summary>
        /// Obtient la liste des horaires pour un arrêt donné.
        /// </summary>
        /// <param name="arretId">Identifiant de l'arrêt.</param>
        /// <returns>Liste des horaires.</returns>
        List<Horaire> ObtenirParArret(int arretId);

        /// <summary>
        /// Obtient la liste des horaires pour une ligne et un jour donnés.
        /// </summary>
        /// <param name="ligneId">Identifiant de la ligne.</param>
        /// <param name="jour">Jour de la semaine.</param>
        /// <returns>Liste des horaires.</returns>
        List<Horaire> ObtenirParLigneEtJour(int ligneId, DayOfWeek jour);

        /// <summary>
        /// Obtient la liste des horaires pour un arrêt et un jour donnés.
        /// </summary>
        /// <param name="arretId">Identifiant de l'arrêt.</param>
        /// <param name="jour">Jour de la semaine.</param>
        /// <returns>Liste des horaires.</returns>
        List<Horaire> ObtenirParArretEtJour(int arretId, DayOfWeek jour);

        /// <summary>
        /// Obtient la liste des horaires pour un jour donné.
        /// </summary>
        /// <param name="jour">Jour de la semaine.</param>
        /// <returns>Liste des horaires.</returns>
        List<Horaire> ObtenirParJour(DayOfWeek jour);

        // Nouvelles méthodes optimisées

        /// <summary>
        /// Obtient la liste des horaires selon des critères avancés.
        /// </summary>
        /// <param name="criteres">Critères de recherche.</param>
        /// <returns>Liste des horaires.</returns>
        List<Horaire> ObtenirParCriteres(HoraireCriteres criteres);

        /// <summary>
        /// Obtient les prochains horaires pour un arrêt à partir d'une date/heure donnée.
        /// </summary>
        /// <param name="arretId">Identifiant de l'arrêt.</param>
        /// <param name="dateHeure">Date et heure de référence.</param>
        /// <param name="limite">Nombre maximum de résultats à retourner.</param>
        /// <returns>Liste des horaires.</returns>
        List<Horaire> ObtenirProchains(int arretId, DateTime dateHeure, int limite = 10);

        /// <summary>
        /// Obtient la liste des horaires pour une ligne, un jour et une plage horaire donnés.
        /// </summary>
        /// <param name="ligneId">Identifiant de la ligne.</param>
        /// <param name="jour">Jour de la semaine.</param>
        /// <param name="heureDebut">Heure de début de la plage.</param>
        /// <param name="heureFin">Heure de fin de la plage.</param>
        /// <returns>Liste des horaires.</returns>
        List<Horaire> ObtenirParPlageHoraire(int ligneId, DayOfWeek jour, TimeSpan heureDebut, TimeSpan heureFin);

        /// <summary>
        /// Vérifie l'existence d'un horaire pour une ligne, un arrêt, un jour et une heure donnés.
        /// </summary>
        /// <param name="ligneId">Identifiant de la ligne.</param>
        /// <param name="arretId">Identifiant de l'arrêt.</param>
        /// <param name="jour">Jour de la semaine.</param>
        /// <param name="heure">Heure de départ.</param>
        /// <returns>Vrai si l'horaire existe, sinon faux.</returns>
        bool ExisteHoraire(int ligneId, int arretId, DayOfWeek jour, TimeSpan heure);

        /// <summary>
        /// Ajoute un nouvel horaire.
        /// </summary>
        /// <param name="horaire">Horaire à ajouter.</param>
        /// <returns>Identifiant de l'horaire ajouté.</returns>
        int Ajouter(Horaire horaire);

        /// <summary>
        /// Ajoute une liste d'horaires en lot.
        /// </summary>
        /// <param name="horaires">Liste des horaires à ajouter.</param>
        /// <returns>Nombre d'horaires ajoutés.</returns>
        int AjouterEnLot(List<Horaire> horaires);

        /// <summary>
        /// Modifie un horaire existant.
        /// </summary>
        /// <param name="horaire">Horaire à modifier.</param>
        /// <returns>Vrai si la modification a réussi, sinon faux.</returns>
        bool Modifier(Horaire horaire);

        /// <summary>
        /// Supprime un horaire par son identifiant.
        /// </summary>
        /// <param name="id">Identifiant de l'horaire à supprimer.</param>
        /// <returns>Vrai si la suppression a réussi, sinon faux.</returns>
        bool Supprimer(int id);

        /// <summary>
        /// Supprime les horaires correspondant à des critères donnés.
        /// </summary>
        /// <param name="criteres">Critères de suppression.</param>
        /// <returns>Vrai si la suppression a réussi, sinon faux.</returns>
        bool SupprimerParCriteres(HoraireCriteres criteres);

        // Méthodes de statistiques

        /// <summary>
        /// Obtient des statistiques du nombre d'horaires par jour pour une ligne donnée.
        /// </summary>
        /// <param name="ligneId">Identifiant de la ligne.</param>
        /// <returns>Dictionnaire des jours et du nombre d'horaires.</returns>
        Dictionary<DayOfWeek, int> ObtenirStatistiquesParJour(int ligneId);

        /// <summary>
        /// Obtient des statistiques globales par ligne.
        /// </summary>
        /// <returns>Liste des statistiques par ligne.</returns>
        List<HoraireStatistique> ObtenirStatistiquesParLigne();
    }

    /// <summary>
    /// Représente les critères de recherche pour les horaires.
    /// </summary>
    public class HoraireCriteres
    {
        /// <summary>
        /// Identifiant de la ligne.
        /// </summary>
        public int? LigneId { get; set; }

        /// <summary>
        /// Identifiant de l'arrêt.
        /// </summary>
        public int? ArretId { get; set; }

        /// <summary>
        /// Jour de la semaine.
        /// </summary>
        public DayOfWeek? JourSemaine { get; set; }

        /// <summary>
        /// Heure de début de la plage.
        /// </summary>
        public TimeSpan? HeureDebut { get; set; }

        /// <summary>
        /// Heure de fin de la plage.
        /// </summary>
        public TimeSpan? HeureFin { get; set; }

        /// <summary>
        /// Indique si l'horaire est actif.
        /// </summary>
        public bool? EstActif { get; set; }

        /// <summary>
        /// Date de création minimale.
        /// </summary>
        public DateTime? DateCreationDebut { get; set; }

        /// <summary>
        /// Date de création maximale.
        /// </summary>
        public DateTime? DateCreationFin { get; set; }

        /// <summary>
        /// Champ de tri.
        /// </summary>
        public string TrierPar { get; set; } = "HeureDepart";

        /// <summary>
        /// Indique si le tri est décroissant.
        /// </summary>
        public bool OrdreDecroissant { get; set; } = false;

        /// <summary>
        /// Limite du nombre de résultats.
        /// </summary>
        public int? Limite { get; set; }

        /// <summary>
        /// Décalage pour la pagination.
        /// </summary>
        public int? Offset { get; set; }
    }

    /// <summary>
    /// Représente les statistiques d'horaires pour une ligne.
    /// </summary>
    public class HoraireStatistique
    {
        /// <summary>
        /// Identifiant de la ligne.
        /// </summary>
        public int LigneId { get; set; }

        /// <summary>
        /// Nom de la ligne.
        /// </summary>
        public string LigneNom { get; set; }

        /// <summary>
        /// Nombre total d'horaires.
        /// </summary>
        public int NombreHoraires { get; set; }

        /// <summary>
        /// Nombre d'horaires actifs.
        /// </summary>
        public int NombreHorairesActifs { get; set; }

        /// <summary>
        /// Premier horaire de la journée.
        /// </summary>
        public TimeSpan? PremierHoraire { get; set; }

        /// <summary>
        /// Dernier horaire de la journée.
        /// </summary>
        public TimeSpan? DernierHoraire { get; set; }

        /// <summary>
        /// Fréquence moyenne des horaires.
        /// </summary>
        public double FrequenceMoyenne { get; set; }
    }
}
