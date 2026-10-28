using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Fumoblilite.Systeme.Modeles;
using Fumoblilite.Systeme.Interfaces;

namespace Fumoblilite.SQL.Repositories
{
    /// <summary>
    /// Repository pour la gestion des entités Ligne dans la base de données MySQL.
    /// </summary>
    public class RepositoryLigne : IRepositoryLigne
    {
        /// <summary>
        /// Chaîne de connexion à la base de données.
        /// </summary>
        private readonly string _connectionString;

        /// <summary>
        /// Initialise une nouvelle instance de RepositoryLigne avec la chaîne de connexion spécifiée.
        /// </summary>
        /// <param name="connectionString">Chaîne de connexion MySQL.</param>
        public RepositoryLigne(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Récupère toutes les lignes non supprimées de la base de données.
        /// </summary>
        /// <returns>Liste de toutes les lignes actives.</returns>
        public List<Ligne> ObtenirToutes()
        {
            List<Ligne> lignes = new List<Ligne>();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Lignes WHERE EstSupprime = FALSE ORDER BY Numero";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lignes.Add(MapFromReader(reader));
                        }
                    }
                }
            }

            return lignes;
        }

        /// <summary>
        /// Récupère une ligne par son identifiant.
        /// </summary>
        /// <param name="id">Identifiant de la ligne.</param>
        /// <returns>La ligne correspondante ou null si non trouvée.</returns>
        public Ligne ObtenirParId(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Lignes WHERE Id = @Id AND EstSupprime = FALSE";

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
        /// Ajoute une nouvelle ligne dans la base de données.
        /// </summary>
        /// <param name="ligne">Ligne à ajouter.</param>
        /// <returns>Identifiant de la ligne ajoutée.</returns>
        public int Ajouter(Ligne ligne)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"
                        INSERT INTO Lignes (Numero, Nom, Couleur, EstActif, DateCreation, EstSupprime)
                        VALUES (@Numero, @Nom, @Couleur, @EstActif, @DateCreation, FALSE);
                        SELECT LAST_INSERT_ID();";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Numero", ligne.Numero);
                    command.Parameters.AddWithValue("@Nom", ligne.Nom);
                    command.Parameters.AddWithValue("@Couleur", ligne.Couleur);
                    command.Parameters.AddWithValue("@EstActif", ligne.EstActif);
                    command.Parameters.AddWithValue("@DateCreation", ligne.DateCreation);

                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        /// <summary>
        /// Modifie une ligne existante dans la base de données.
        /// </summary>
        /// <param name="ligne">Ligne à modifier.</param>
        /// <returns>True si la modification a réussi, sinon false.</returns>
        public bool Modifier(Ligne ligne)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"
                        UPDATE Lignes 
                        SET Numero = @Numero, 
                            Nom = @Nom, 
                            Couleur = @Couleur, 
                            EstActif = @EstActif, 
                            DateModification = @DateModification
                        WHERE Id = @Id";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", ligne.Id);
                    command.Parameters.AddWithValue("@Numero", ligne.Numero);
                    command.Parameters.AddWithValue("@Nom", ligne.Nom);
                    command.Parameters.AddWithValue("@Couleur", ligne.Couleur);
                    command.Parameters.AddWithValue("@EstActif", ligne.EstActif);
                    command.Parameters.AddWithValue("@DateModification", ligne.DateModification ?? DateTime.Now);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        /// <summary>
        /// Supprime logiquement une ligne (passe EstSupprime à TRUE).
        /// </summary>
        /// <param name="id">Identifiant de la ligne à supprimer.</param>
        /// <returns>True si la suppression a réussi, sinon false.</returns>
        public bool Supprimer(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "UPDATE Lignes SET EstSupprime = TRUE, DateModification = NOW() WHERE Id = @Id";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        /// <summary>
        /// Crée une instance de Ligne à partir d'un MySqlDataReader.
        /// </summary>
        /// <param name="reader">Lecteur de données MySQL.</param>
        /// <returns>Instance de Ligne.</returns>
        private Ligne MapFromReader(MySqlDataReader reader)
        {
            return new Ligne
            {
                Id = Convert.ToInt32(reader["Id"]),
                Numero = reader["Numero"].ToString(),
                Nom = reader["Nom"].ToString(),
                Couleur = reader["Couleur"] != DBNull.Value ? reader["Couleur"].ToString() : null,
                EstActif = Convert.ToBoolean(reader["EstActif"]),
                DateCreation = Convert.ToDateTime(reader["DateCreation"]),
                DateModification = reader["DateModification"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["DateModification"]) : null,
                Arrets = new List<ArretLigne>()
            };
        }
    }
}
