using System.Collections.Generic;
using Fumoblilite.Systeme.Modeles;

namespace Fumoblilite.Systeme.Interfaces
{
    /// <summary>
    /// Interface pour la gestion des opérations sur les utilisateurs.
    /// </summary>
    public interface IRepositoryUtilisateur
    {
        /// <summary>
        /// Récupère la liste de tous les utilisateurs.
        /// </summary>
        /// <returns>Liste de tous les utilisateurs.</returns>
        List<Utilisateur> ObtenirTous();

        /// <summary>
        /// Récupère un utilisateur par son identifiant unique.
        /// </summary>
        /// <param name="id">Identifiant de l'utilisateur.</param>
        /// <returns>L'utilisateur correspondant ou null si non trouvé.</returns>
        Utilisateur ObtenirParId(int id);

        /// <summary>
        /// Récupère un utilisateur par son nom d'utilisateur (pseudo).
        /// </summary>
        /// <param name="nomUtilisateur">Nom d'utilisateur (pseudo).</param>
        /// <returns>L'utilisateur correspondant ou null si non trouvé.</returns>
        Utilisateur ObtenirParNomUtilisateur(string nomUtilisateur);

        /// <summary>
        /// Ajoute un nouvel utilisateur.
        /// </summary>
        /// <param name="utilisateur">Utilisateur à ajouter.</param>
        /// <returns>L'identifiant du nouvel utilisateur ajouté.</returns>
        int Ajouter(Utilisateur utilisateur);

        /// <summary>
        /// Modifie les informations d'un utilisateur existant.
        /// </summary>
        /// <param name="utilisateur">Utilisateur avec les nouvelles informations.</param>
        /// <returns>True si la modification a réussi, sinon false.</returns>
        bool Modifier(Utilisateur utilisateur);

        /// <summary>
        /// Modifie le mot de passe d'un utilisateur.
        /// </summary>
        /// <param name="id">Identifiant de l'utilisateur.</param>
        /// <param name="motDePasse">Nouveau mot de passe.</param>
        /// <returns>True si la modification a réussi, sinon false.</returns>
        bool ModifierMotDePasse(int id, string motDePasse);

        /// <summary>
        /// Supprime un utilisateur par son identifiant.
        /// </summary>
        /// <param name="id">Identifiant de l'utilisateur à supprimer.</param>
        /// <returns>True si la suppression a réussi, sinon false.</returns>
        bool Supprimer(int id);
    }
}

