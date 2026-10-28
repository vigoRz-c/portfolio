using System;
using System.Collections.Generic;
using Fumoblilite.Systeme.Modeles;
using Fumoblilite.Systeme.Interfaces;

namespace Fumoblilite.Systeme.Services
{
    /// <summary>
    /// Service pour la gestion des arrêts.
    /// </summary>
    public class ServiceArret
    {
        /// <summary>
        /// Référence au dépôt d'arrêts.
        /// </summary>
        private readonly IRepositoryArret _repositoryArret;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="ServiceArret"/>.
        /// </summary>
        /// <param name="repositoryArret">Le dépôt d'arrêts à utiliser.</param>
        public ServiceArret(IRepositoryArret repositoryArret)
        {
            _repositoryArret = repositoryArret;
        }

        /// <summary>
        /// Récupère la liste de tous les arrêts.
        /// </summary>
        /// <returns>Liste de tous les arrêts.</returns>
        public List<Arret> ObtenirTous()
        {
            return _repositoryArret.ObtenirTous();
        }

        /// <summary>
        /// Récupère un arrêt par son identifiant.
        /// </summary>
        /// <param name="id">Identifiant de l'arrêt.</param>
        /// <returns>L'arrêt correspondant ou null si non trouvé.</returns>
        public Arret ObtenirParId(int id)
        {
            return _repositoryArret.ObtenirParId(id);
        }

        /// <summary>
        /// Récupère la liste des arrêts pour une ligne donnée.
        /// </summary>
        /// <param name="ligneId">Identifiant de la ligne.</param>
        /// <returns>Liste des arrêts de la ligne.</returns>
        public List<Arret> ObtenirParLigne(int ligneId)
        {
            return _repositoryArret.ObtenirParLigne(ligneId);
        }

        /// <summary>
        /// Ajoute un nouvel arrêt.
        /// </summary>
        /// <param name="arret">L'arrêt à ajouter.</param>
        /// <returns>L'identifiant de l'arrêt ajouté.</returns>
        /// <exception cref="ArgumentException">Si le nom de l'arrêt est vide ou nul.</exception>
        public int Ajouter(Arret arret)
        {
            if (string.IsNullOrEmpty(arret.Nom))
                throw new ArgumentException("Le nom de l'arrêt est obligatoire");

            return _repositoryArret.Ajouter(arret);
        }

        /// <summary>
        /// Modifie un arrêt existant.
        /// </summary>
        /// <param name="arret">L'arrêt à modifier.</param>
        /// <returns>True si la modification a réussi, sinon false.</returns>
        /// <exception cref="ArgumentException">Si le nom de l'arrêt est vide ou nul.</exception>
        public bool Modifier(Arret arret)
        {
            if (string.IsNullOrEmpty(arret.Nom))
                throw new ArgumentException("Le nom de l'arrêt est obligatoire");

            arret.DateModification = DateTime.Now;
            return _repositoryArret.Modifier(arret);
        }

        /// <summary>
        /// Supprime un arrêt par son identifiant.
        /// </summary>
        /// <param name="id">Identifiant de l'arrêt à supprimer.</param>
        /// <returns>True si la suppression a réussi, sinon false.</returns>
        public bool Supprimer(int id)
        {
            return _repositoryArret.Supprimer(id);
        }
    }
}

