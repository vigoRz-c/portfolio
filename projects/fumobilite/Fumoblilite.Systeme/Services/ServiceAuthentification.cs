using System;
using System.Security.Cryptography;
using System.Text;
using Fumoblilite.Systeme.Modeles;
using Fumoblilite.Systeme.Interfaces;

namespace Fumoblilite.Systeme.Services
{
    /// <summary>
    /// Service gérant l'authentification des utilisateurs.
    /// </summary>
    public class ServiceAuthentification
    {
        /// <summary>
        /// Référence au dépôt des utilisateurs.
        /// </summary>
        private readonly IRepositoryUtilisateur _repositoryUtilisateur;

        /// <summary>
        /// Initialise une nouvelle instance du service d'authentification.
        /// </summary>
        /// <param name="repositoryUtilisateur">Dépôt des utilisateurs.</param>
        public ServiceAuthentification(IRepositoryUtilisateur repositoryUtilisateur)
        {
            _repositoryUtilisateur = repositoryUtilisateur;
        }

        /// <summary>
        /// Authentifie un utilisateur à partir de son nom d'utilisateur et de son mot de passe.
        /// </summary>
        /// <param name="nomUtilisateur">Nom d'utilisateur.</param>
        /// <param name="motDePasse">Mot de passe en clair.</param>
        /// <returns>L'utilisateur authentifié ou null si l'authentification échoue.</returns>
        public Utilisateur Authentifier(string nomUtilisateur, string motDePasse)
        {
            if (string.IsNullOrEmpty(nomUtilisateur) || string.IsNullOrEmpty(motDePasse))
                return null;

            var utilisateur = _repositoryUtilisateur.ObtenirParNomUtilisateur(nomUtilisateur);
            if (utilisateur == null || !utilisateur.EstActif)
                return null;

            string motDePasseHash = HashMotDePasse(motDePasse);
            if (utilisateur.MotDePasse != motDePasseHash)
                return null;

            return utilisateur;
        }

        /// <summary>
        /// Calcule le hash SHA256 d'un mot de passe.
        /// </summary>
        /// <param name="motDePasse">Mot de passe en clair.</param>
        /// <returns>Hash du mot de passe sous forme de chaîne hexadécimale.</returns>
        public string HashMotDePasse(string motDePasse)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(motDePasse));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}

