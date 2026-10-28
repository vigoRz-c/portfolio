using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Fumoblilite.Systeme.Modeles;
using Fumoblilite.Systeme.Interfaces;

namespace Fumoblilite.SQL.Repositories
{
    /// <summary>
    /// Repository pour la gestion des arrêts dans la base de données MySQL.
    /// </summary>
    public class RepositoryArret : IRepositoryArret
    {
        private readonly string _connectionString;

        /// <summary>
        /// Initialise une nouvelle instance de RepositoryArret avec la chaîne de connexion spécifiée.
        /// </summary>
        /// <param name="connectionString">Chaîne de connexion à la base de données.</param>
        public RepositoryArret(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Récupère la liste de tous les arrêts non supprimés, triés par nom.
        /// </summary>
        /// <returns>Liste des arrêts.</returns>
        public List<Arret> ObtenirTous()
        {
            List<Arret> arrets = new List<Arret>();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Arrets WHERE EstSupprime = FALSE ORDER BY Nom";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            arrets.Add(MapFromReader(reader));
                        }
                    }
                }
            }

            return arrets;
        }

        /// <summary>
        /// Récupère un arrêt par son identifiant s'il n'est pas supprimé.
        /// </summary>
        /// <param name="id">Identifiant de l'arrêt.</param>
        /// <returns>L'arrêt correspondant ou null si non trouvé.</returns>
        public Arret ObtenirParId(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Arrets WHERE Id = @Id AND EstSupprime = FALSE";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapFromReader(reader);
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Récupère la liste des arrêts associés à une ligne donnée.
        /// </summary>
        /// <param name="ligneId">Identifiant de la ligne.</param>
        /// <returns>Liste des arrêts de la ligne spécifiée.</returns>
        public List<Arret> ObtenirParLigne(int ligneId)
        {
            List<Arret> arrets = new List<Arret>();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"
                        SELECT a.* 
                        FROM Arrets a
                        INNER JOIN ArretsLignes al ON a.Id = al.ArretId
                        WHERE al.LigneId = @LigneId AND a.EstSupprime = FALSE AND al.EstSupprime = FALSE
                        ORDER BY al.Ordre";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LigneId", ligneId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            arrets.Add(MapFromReader(reader));
                        }
                    }
                }
            }

            return arrets;
        }

        /// <summary>
        /// Ajoute un nouvel arrêt à la base de données.
        /// </summary>
        /// <param name="arret">L'arrêt à ajouter.</param>
        /// <returns>L'identifiant de l'arrêt ajouté.</returns>
        public int Ajouter(Arret arret)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"
                        INSERT INTO Arrets (Nom, Adresse, Latitude, Longitude, EstAccessible, DateCreation, EstSupprime)
                        VALUES (@Nom, @Adresse, @Latitude, @Longitude, @EstAccessible, @DateCreation, FALSE);
                        SELECT LAST_INSERT_ID();";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nom", arret.Nom);
                    command.Parameters.AddWithValue("@Adresse", arret.Adresse);
                    command.Parameters.AddWithValue("@Latitude", arret.Latitude);
                    command.Parameters.AddWithValue("@Longitude", arret.Longitude);
                    command.Parameters.AddWithValue("@EstAccessible", arret.EstAccessible);
                    command.Parameters.AddWithValue("@DateCreation", arret.DateCreation);

                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        /// <summary>
        /// Modifie un arrêt existant dans la base de données.
        /// </summary>
        /// <param name="arret">L'arrêt à modifier.</param>
        /// <returns>True si la modification a réussi, sinon false.</returns>
        public bool Modifier(Arret arret)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"
                        UPDATE Arrets 
                        SET Nom = @Nom, 
                            Adresse = @Adresse, 
                            Latitude = @Latitude, 
                            Longitude = @Longitude, 
                            EstAccessible = @EstAccessible, 
                            DateModification = @DateModification
                        WHERE Id = @Id";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", arret.Id);
                    command.Parameters.AddWithValue("@Nom", arret.Nom);
                    command.Parameters.AddWithValue("@Adresse", arret.Adresse);
                    command.Parameters.AddWithValue("@Latitude", arret.Latitude);
                    command.Parameters.AddWithValue("@Longitude", arret.Longitude);
                    command.Parameters.AddWithValue("@EstAccessible", arret.EstAccessible);
                    command.Parameters.AddWithValue("@DateModification", arret.DateModification ?? DateTime.Now);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        /// <summary>
        /// Marque un arrêt comme supprimé dans la base de données.
        /// </summary>
        /// <param name="id">Identifiant de l'arrêt à supprimer.</param>
        /// <returns>True si la suppression a réussi, sinon false.</returns>
        public bool Supprimer(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "UPDATE Arrets SET EstSupprime = TRUE, DateModification = NOW() WHERE Id = @Id";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        /// <summary>
        /// Crée un objet Arret à partir d'un MySqlDataReader.
        /// </summary>
        /// <param name="reader">Le lecteur de données MySQL.</param>
        /// <returns>Un objet Arret initialisé.</returns>
        private Arret MapFromReader(MySqlDataReader reader)
        {
            return new Arret
            {
                Id = Convert.ToInt32(reader["Id"]),
                Nom = reader["Nom"].ToString(),
                Adresse = reader["Adresse"] != DBNull.Value ? reader["Adresse"].ToString() : null,
                Latitude = Convert.ToDouble(reader["Latitude"]),
                Longitude = Convert.ToDouble(reader["Longitude"]),
                EstAccessible = Convert.ToBoolean(reader["EstAccessible"]),
                DateCreation = Convert.ToDateTime(reader["DateCreation"]),
                DateModification = reader["DateModification"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["DateModification"]) : null
            };
        }
    }
}
