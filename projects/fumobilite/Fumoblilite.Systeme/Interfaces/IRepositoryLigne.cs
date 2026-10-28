using System.Collections.Generic;
using Fumoblilite.Systeme.Modeles;

namespace Fumoblilite.Systeme.Interfaces
{
    /// <summary>
    /// Interface pour la gestion des opérations CRUD sur les entités Ligne.
    /// </summary>
    public interface IRepositoryLigne
    {
        /// <summary>
        /// Récupère la liste de toutes les lignes.
        /// </summary>
        /// <returns>Liste de toutes les lignes.</returns>
        List<Ligne> ObtenirToutes();

        /// <summary>
        /// Récupère une ligne par son identifiant.
        /// </summary>
        /// <param name="id">Identifiant de la ligne.</param>
        /// <returns>La ligne correspondante ou null si non trouvée.</returns>
        Ligne ObtenirParId(int id);

        /// <summary>
        /// Ajoute une nouvelle ligne.
        /// </summary>
        /// <param name="ligne">Ligne à ajouter.</param>
        /// <returns>Identifiant de la ligne ajoutée.</returns>
        int Ajouter(Ligne ligne);

        /// <summary>
        /// Modifie une ligne existante.
        /// </summary>
        /// <param name="ligne">Ligne à modifier.</param>
        /// <returns>True si la modification a réussi, sinon false.</returns>
        bool Modifier(Ligne ligne);

        /// <summary>
        /// Supprime une ligne par son identifiant.
        /// </summary>
        /// <param name="id">Identifiant de la ligne à supprimer.</param>
        /// <returns>True si la suppression a réussi, sinon false.</returns>
        bool Supprimer(int id);
    }
}

