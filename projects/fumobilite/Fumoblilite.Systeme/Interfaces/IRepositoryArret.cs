using System.Collections.Generic;
using Fumoblilite.Systeme.Modeles;

namespace Fumoblilite.Systeme.Interfaces
{
    /// <summary>
    /// Interface pour la gestion des opérations CRUD sur les arrêts.
    /// </summary>
    public interface IRepositoryArret
    {
        /// <summary>
        /// Récupère la liste de tous les arrêts.
        /// </summary>
        /// <returns>Liste de tous les arrêts.</returns>
        List<Arret> ObtenirTous();

        /// <summary>
        /// Récupère un arrêt par son identifiant.
        /// </summary>
        /// <param name="id">Identifiant de l'arrêt.</param>
        /// <returns>L'arrêt correspondant à l'identifiant, ou null si non trouvé.</returns>
        Arret ObtenirParId(int id);

        /// <summary>
        /// Récupère la liste des arrêts associés à une ligne donnée.
        /// </summary>
        /// <param name="ligneId">Identifiant de la ligne.</param>
        /// <returns>Liste des arrêts de la ligne spécifiée.</returns>
        List<Arret> ObtenirParLigne(int ligneId);

        /// <summary>
        /// Ajoute un nouvel arrêt.
        /// </summary>
        /// <param name="arret">L'arrêt à ajouter.</param>
        /// <returns>L'identifiant de l'arrêt ajouté.</returns>
        int Ajouter(Arret arret);

        /// <summary>
        /// Modifie un arrêt existant.
        /// </summary>
        /// <param name="arret">L'arrêt à modifier.</param>
        /// <returns>True si la modification a réussi, sinon false.</returns>
        bool Modifier(Arret arret);

        /// <summary>
        /// Supprime un arrêt par son identifiant.
        /// </summary>
        /// <param name="id">Identifiant de l'arrêt à supprimer.</param>
        /// <returns>True si la suppression a réussi, sinon false.</returns>
        bool Supprimer(int id);
    }
}

