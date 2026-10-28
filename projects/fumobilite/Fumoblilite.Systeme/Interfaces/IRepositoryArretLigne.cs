using System.Collections.Generic;
using Fumoblilite.Systeme.Modeles;

namespace Fumoblilite.Systeme.Interfaces
{
    /// <summary>
    /// Interface pour la gestion des opérations sur les arrêts de ligne.
    /// </summary>
    public interface IRepositoryArretLigne
    {
        /// <summary>
        /// Récupère la liste des arrêts de ligne pour une ligne donnée.
        /// </summary>
        /// <param name="ligneId">Identifiant de la ligne.</param>
        /// <returns>Liste des arrêts de ligne associés à la ligne.</returns>
        List<ArretLigne> ObtenirParLigne(int ligneId);

        /// <summary>
        /// Récupère un arrêt de ligne par son identifiant.
        /// </summary>
        /// <param name="id">Identifiant de l'arrêt de ligne.</param>
        /// <returns>L'arrêt de ligne correspondant ou null si non trouvé.</returns>
        ArretLigne ObtenirParId(int id);

        /// <summary>
        /// Ajoute un nouvel arrêt de ligne.
        /// </summary>
        /// <param name="arretLigne">L'arrêt de ligne à ajouter.</param>
        /// <returns>L'identifiant de l'arrêt de ligne ajouté.</returns>
        int Ajouter(ArretLigne arretLigne);

        /// <summary>
        /// Modifie un arrêt de ligne existant.
        /// </summary>
        /// <param name="arretLigne">L'arrêt de ligne à modifier.</param>
        /// <returns>True si la modification a réussi, sinon false.</returns>
        bool Modifier(ArretLigne arretLigne);

        /// <summary>
        /// Supprime un arrêt de ligne par son identifiant.
        /// </summary>
        /// <param name="id">Identifiant de l'arrêt de ligne à supprimer.</param>
        /// <returns>True si la suppression a réussi, sinon false.</returns>
        bool Supprimer(int id);
    }
}

