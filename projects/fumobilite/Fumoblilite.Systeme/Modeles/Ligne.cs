using System;
using System.Collections.Generic;

namespace Fumoblilite.Systeme.Modeles
{
    /// <summary>
    /// Modèle de données pour une ligne de transport.
    /// </summary>
    public class Ligne
    {
        /// <summary>
        /// Identifiant de la ligne.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Numéro de la ligne.
        /// </summary>
        public string Numero { get; set; }

        /// <summary>
        /// Nom de la ligne.
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Couleur de la ligne.
        /// </summary>
        public string Couleur { get; set; }

        /// <summary>
        /// Statut de la ligne (active ou non).
        /// </summary>
        public bool EstActif { get; set; }

        /// <summary>
        /// Date de création de la ligne.
        /// </summary>
        public DateTime DateCreation { get; set; }

        /// <summary>
        /// Date de modification de la ligne.
        /// </summary>
        public DateTime? DateModification { get; set; }

        /// <summary>
        /// Liste des arrêts de la ligne.
        /// </summary>
        public List<ArretLigne> Arrets { get; set; }

        /// <summary>
        /// Constructeur par défaut. Initialise la liste des arrêts, la date de création et le statut actif.
        /// </summary>
        public Ligne()
        {
            Arrets = new List<ArretLigne>();
            DateCreation = DateTime.Now;
            EstActif = true;
        }

        /// <summary>
        /// Constructeur avec paramètres principaux.
        /// </summary>
        /// <param name="id">Identifiant de la ligne.</param>
        /// <param name="numero">Numéro de la ligne.</param>
        /// <param name="nom">Nom de la ligne.</param>
        /// <param name="couleur">Couleur de la ligne.</param>
        public Ligne(int id, string numero, string nom, string couleur)
        {
            Id = id;
            Numero = numero;
            Nom = nom;
            Couleur = couleur;
            EstActif = true;
            Arrets = new List<ArretLigne>();
            DateCreation = DateTime.Now;
        }
    }
}

