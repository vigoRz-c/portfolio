using System;
using System.Collections.Generic;
using Fumoblilite.Systeme.Modeles;
using Fumoblilite.Systeme.Interfaces;

namespace Fumoblilite.Systeme.Services
{
    /// <summary>
    /// Service pour la gestion des lignes et de leurs arrêts.
    /// </summary>
    public class ServiceLigne
    {
        /// <summary>
        /// Référentiel pour les lignes.
        /// </summary>
        private readonly IRepositoryLigne _repositoryLigne;

        /// <summary>
        /// Référentiel pour les arrêts de ligne.
        /// </summary>
        private readonly IRepositoryArretLigne _repositoryArretLigne;

        /// <summary>
        /// Initialise une nouvelle instance du service de gestion des lignes.
        /// </summary>
        /// <param name="repositoryLigne">Référentiel des lignes.</param>
        /// <param name="repositoryArretLigne">Référentiel des arrêts de ligne.</param>
        public ServiceLigne(IRepositoryLigne repositoryLigne, IRepositoryArretLigne repositoryArretLigne)
        {
            _repositoryLigne = repositoryLigne;
            _repositoryArretLigne = repositoryArretLigne;
        }

        /// <summary>
        /// Récupère toutes les lignes.
        /// </summary>
        /// <returns>Liste de toutes les lignes.</returns>
        public List<Ligne> ObtenirToutes()
        {
            return _repositoryLigne.ObtenirToutes();
        }

        /// <summary>
        /// Récupère une ligne par son identifiant, avec option d'inclure les arrêts.
        /// </summary>
        /// <param name="id">Identifiant de la ligne.</param>
        /// <param name="inclureArrets">Inclure les arrêts de la ligne.</param>
        /// <returns>La ligne correspondante ou null si non trouvée.</returns>
        public Ligne ObtenirParId(int id, bool inclureArrets = false)
        {
            var ligne = _repositoryLigne.ObtenirParId(id);
            if (ligne != null && inclureArrets)
            {
                ligne.Arrets = _repositoryArretLigne.ObtenirParLigne(id);
            }
            return ligne;
        }

        /// <summary>
        /// Ajoute une nouvelle ligne.
        /// </summary>
        /// <param name="ligne">Ligne à ajouter.</param>
        /// <returns>Identifiant de la ligne ajoutée.</returns>
        /// <exception cref="ArgumentException">Si le numéro ou le nom est manquant.</exception>
        public int Ajouter(Ligne ligne)
        {
            if (string.IsNullOrEmpty(ligne.Numero) || string.IsNullOrEmpty(ligne.Nom))
                throw new ArgumentException("Le numéro et le nom de la ligne sont obligatoires");

            return _repositoryLigne.Ajouter(ligne);
        }

        /// <summary>
        /// Modifie une ligne existante.
        /// </summary>
        /// <param name="ligne">Ligne à modifier.</param>
        /// <returns>True si la modification a réussi, sinon false.</returns>
        /// <exception cref="ArgumentException">Si le numéro ou le nom est manquant.</exception>
        public bool Modifier(Ligne ligne)
        {
            if (string.IsNullOrEmpty(ligne.Numero) || string.IsNullOrEmpty(ligne.Nom))
                throw new ArgumentException("Le numéro et le nom de la ligne sont obligatoires");

            ligne.DateModification = DateTime.Now;
            return _repositoryLigne.Modifier(ligne);
        }

        /// <summary>
        /// Supprime une ligne par son identifiant.
        /// </summary>
        /// <param name="id">Identifiant de la ligne à supprimer.</param>
        /// <returns>True si la suppression a réussi, sinon false.</returns>
        public bool Supprimer(int id)
        {
            return _repositoryLigne.Supprimer(id);
        }

        /// <summary>
        /// Ajoute un arrêt à une ligne.
        /// </summary>
        /// <param name="arretLigne">Arrêt de ligne à ajouter.</param>
        /// <returns>True si l'ajout a réussi, sinon false.</returns>
        public bool AjouterArret(ArretLigne arretLigne)
        {
            return _repositoryArretLigne.Ajouter(arretLigne) > 0;
        }

        /// <summary>
        /// Modifie un arrêt de ligne existant.
        /// </summary>
        /// <param name="arretLigne">Arrêt de ligne à modifier.</param>
        /// <returns>True si la modification a réussi, sinon false.</returns>
        public bool ModifierArret(ArretLigne arretLigne)
        {
            arretLigne.DateModification = DateTime.Now;
            return _repositoryArretLigne.Modifier(arretLigne);
        }

        /// <summary>
        /// Supprime un arrêt de ligne par son identifiant.
        /// </summary>
        /// <param name="id">Identifiant de l'arrêt de ligne à supprimer.</param>
        /// <returns>True si la suppression a réussi, sinon false.</returns>
        public bool SupprimerArret(int id)
        {
            return _repositoryArretLigne.Supprimer(id);
        }
    }
}