using System;

namespace Fumoblilite.Systeme.Modeles
{
    /// <summary>
    /// Modèle de données pour un utilisateur.
    /// </summary>
    public class Utilisateur
    {
        /// <summary>
        /// Identifiant de l'utilisateur.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nom de l'utilisateur.
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Prénom de l'utilisateur.
        /// </summary>
        public string Prenom { get; set; }

        /// <summary>
        /// Pseudo de l'utilisateur.
        /// </summary>
        public string NomUtilisateur { get; set; }

        /// <summary>
        /// Mot de passe de l'utilisateur.
        /// </summary>
        public string MotDePasse { get; set; }

        /// <summary>
        /// Email de l'utilisateur.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Rôle de l'utilisateur (Admin ou Utilisateur).
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Statut de l'utilisateur (actif ou non).
        /// </summary>
        public bool EstActif { get; set; }

        /// <summary>
        /// Date de création de l'utilisateur.
        /// </summary>
        public DateTime DateCreation { get; set; }

        /// <summary>
        /// Date de modification de l'utilisateur.
        /// </summary>
        public DateTime? DateModification { get; set; }

        /// <summary>
        /// Constructeur par défaut. Initialise la date de création et le statut actif.
        /// </summary>
        public Utilisateur()
        {
            DateCreation = DateTime.Now;
            EstActif = true;
        }

        /// <summary>
        /// Constructeur avec paramètres pour initialiser toutes les propriétés principales.
        /// </summary>
        /// <param name="id">Identifiant de l'utilisateur.</param>
        /// <param name="nom">Nom de l'utilisateur.</param>
        /// <param name="prenom">Prénom de l'utilisateur.</param>
        /// <param name="nomUtilisateur">Pseudo de l'utilisateur.</param>
        /// <param name="motDePasse">Mot de passe de l'utilisateur.</param>
        /// <param name="email">Email de l'utilisateur.</param>
        /// <param name="role">Rôle de l'utilisateur.</param>
        public Utilisateur(int id, string nom, string prenom, string nomUtilisateur, string motDePasse, string email, string role)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            NomUtilisateur = nomUtilisateur;
            MotDePasse = motDePasse;
            Email = email;
            Role = role;
            EstActif = true;
            DateCreation = DateTime.Now;
        }
    }
}

