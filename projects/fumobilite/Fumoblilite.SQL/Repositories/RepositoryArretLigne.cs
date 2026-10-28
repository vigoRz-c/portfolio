using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Fumoblilite.Systeme.Modeles;
using Fumoblilite.Systeme.Interfaces;

namespace Fumoblilite.SQL.Repositories
{
    /// <summary>
    /// Repository pour la gestion des arrêts de ligne (ArretLigne) en base de données MySQL.
    /// </summary>
    public class RepositoryArretLigne : IRepositoryArretLigne
    {
        private readonly string _connectionString;
        private readonly IRepositoryArret _repositoryArret;

        /// <summary>
        /// Initialise une nouvelle instance de RepositoryArretLigne.
        /// </summary>
        /// <param name="connectionString">Chaîne de connexion à la base de données.</param>
        /// <param name="repositoryArret">Dépendance vers le repository des arrêts.</param>
        public RepositoryArretLigne(string connectionString, IRepositoryArret repositoryArret)
        {
            _connectionString = connectionString;
            _repositoryArret = repositoryArret;
        }

        /// <summary>
        /// Récupère la liste des arrêts de ligne pour une ligne donnée.
        /// </summary>
        /// <param name="ligneId">Identifiant de la ligne.</param>
        /// <returns>Liste des arrêts de ligne associés à la ligne.</returns>
        public List<ArretLigne> ObtenirParLigne(int ligneId)
        {
            List<ArretLigne> arretsLigne = new List<ArretLigne>();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM ArretsLignes WHERE LigneId = @LigneId AND EstSupprime = FALSE ORDER BY Ordre";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LigneId", ligneId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var arretLigne = MapFromReader(reader);
                            arretLigne.Arret = _repositoryArret.ObtenirParId(arretLigne.ArretId);
                            arretsLigne.Add(arretLigne);
                        }
                    }
                }
            }

            return arretsLigne;
        }

        /// <summary>
        /// Récupère un arrêt de ligne par son identifiant.
        /// </summary>
        /// <param name="id">Identifiant de l'arrêt de ligne.</param>
        /// <returns>L'arrêt de ligne correspondant ou null si non trouvé.</returns>
        public ArretLigne ObtenirParId(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM ArretsLignes WHERE Id = @Id AND EstSupprime = FALSE";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var arretLigne = MapFromReader(reader);
                            arretLigne.Arret = _repositoryArret.ObtenirParId(arretLigne.ArretId);
                            return arretLigne;
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Ajoute un nouvel arrêt de ligne.
        /// </summary>
        /// <param name="arretLigne">L'arrêt de ligne à ajouter.</param>
        /// <returns>L'identifiant de l'arrêt de ligne ajouté.</returns>
        public int Ajouter(ArretLigne arretLigne)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"
                        INSERT INTO ArretsLignes (LigneId, ArretId, Ordre, TempsArretMinutes, TempsTrajetSuivantMinutes, DateCreation, EstSupprime)
                        VALUES (@LigneId, @ArretId, @Ordre, @TempsArretMinutes, @TempsTrajetSuivantMinutes, @DateCreation, FALSE);
                        SELECT LAST_INSERT_ID();";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LigneId", arretLigne.LigneId);
                    command.Parameters.AddWithValue("@ArretId", arretLigne.ArretId);
                    command.Parameters.AddWithValue("@Ordre", arretLigne.Ordre);
                    command.Parameters.AddWithValue("@TempsArretMinutes", arretLigne.TempsArretMinutes);
                    command.Parameters.AddWithValue("@TempsTrajetSuivantMinutes", arretLigne.TempsTrajetSuivantMinutes);
                    command.Parameters.AddWithValue("@DateCreation", arretLigne.DateCreation);

                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        /// <summary>
        /// Modifie un arrêt de ligne existant.
        /// </summary>
        /// <param name="arretLigne">L'arrêt de ligne à modifier.</param>
        /// <returns>True si la modification a réussi, sinon false.</returns>
        public bool Modifier(ArretLigne arretLigne)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"
                        UPDATE ArretsLignes 
                        SET LigneId = @LigneId, 
                            ArretId = @ArretId, 
                            Ordre = @Ordre, 
                            TempsArretMinutes = @TempsArretMinutes, 
                            TempsTrajetSuivantMinutes = @TempsTrajetSuivantMinutes, 
                            DateModification = @DateModification
                        WHERE Id = @Id";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", arretLigne.Id);
                    command.Parameters.AddWithValue("@LigneId", arretLigne.LigneId);
                    command.Parameters.AddWithValue("@ArretId", arretLigne.ArretId);
                    command.Parameters.AddWithValue("@Ordre", arretLigne.Ordre);
                    command.Parameters.AddWithValue("@TempsArretMinutes", arretLigne.TempsArretMinutes);
                    command.Parameters.AddWithValue("@TempsTrajetSuivantMinutes", arretLigne.TempsTrajetSuivantMinutes);
                    command.Parameters.AddWithValue("@DateModification", arretLigne.DateModification ?? DateTime.Now);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        /// <summary>
        /// Supprime (logiquement) un arrêt de ligne par son identifiant.
        /// </summary>
        /// <param name="id">Identifiant de l'arrêt de ligne à supprimer.</param>
        /// <returns>True si la suppression a réussi, sinon false.</returns>
        public bool Supprimer(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "UPDATE ArretsLignes SET EstSupprime = TRUE, DateModification = NOW() WHERE Id = @Id";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        /// <summary>
        /// Crée un objet ArretLigne à partir d'un MySqlDataReader.
        /// </summary>
        /// <param name="reader">Le lecteur de données MySQL.</param>
        /// <returns>Un objet ArretLigne initialisé.</returns>
        private ArretLigne MapFromReader(MySqlDataReader reader)
        {
            return new ArretLigne
            {
                Id = Convert.ToInt32(reader["Id"]),
                LigneId = Convert.ToInt32(reader["LigneId"]),
                ArretId = Convert.ToInt32(reader["ArretId"]),
                Ordre = Convert.ToInt32(reader["Ordre"]),
                TempsArretMinutes = Convert.ToInt32(reader["TempsArretMinutes"]),
                TempsTrajetSuivantMinutes = Convert.ToInt32(reader["TempsTrajetSuivantMinutes"]),
                DateCreation = Convert.ToDateTime(reader["DateCreation"]),
                DateModification = reader["DateModification"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["DateModification"]) : null
            };
        }
    }
}
