using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Fumoblilite.Systeme.Modeles;

namespace Fumoblilite.SQL.Repositories
{
    /// <summary>
    /// Fournit des méthodes pour gérer l'historique des actions des utilisateurs dans la base de données.
    /// </summary>
    public class RepositoryActionHistorique
    {
        private readonly string _connectionString;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="RepositoryActionHistorique"/> avec la chaîne de connexion spécifiée.
        /// </summary>
        /// <param name="connectionString">Chaîne de connexion à la base de données MySQL.</param>
        public RepositoryActionHistorique(string connectionString) { _connectionString = connectionString; }

        /// <summary>
        /// Ajoute une nouvelle action à l'historique dans la base de données.
        /// </summary>
        /// <param name="action">L'action à ajouter à l'historique.</param>
        public void Ajouter(ActionHistorique action)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string q = "INSERT INTO ActionsHistoriques (UtilisateurId, NomUtilisateur, Action, DateAction) VALUES (@uid, @nom, @action, @date)";
                using (var cmd = new MySqlCommand(q, conn))
                {
                    cmd.Parameters.AddWithValue("@uid", (object)action.UtilisateurId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@nom", action.NomUtilisateur ?? "");
                    cmd.Parameters.AddWithValue("@action", action.Action);
                    cmd.Parameters.AddWithValue("@date", action.DateAction);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Récupère la liste des actions historiques pour un utilisateur donné.
        /// </summary>
        /// <param name="utilisateurId">L'identifiant de l'utilisateur, ou null pour les actions sans utilisateur associé.</param>
        /// <returns>Une liste d'actions historiques correspondant à l'utilisateur.</returns>
        public List<ActionHistorique> ObtenirParUtilisateur(int? utilisateurId)
        {
            var list = new List<ActionHistorique>();
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string q = "SELECT * FROM ActionsHistoriques WHERE UtilisateurId = @uid OR (@uid IS NULL AND UtilisateurId IS NULL) ORDER BY DateAction DESC";
                using (var cmd = new MySqlCommand(q, conn))
                {
                    cmd.Parameters.AddWithValue("@uid", (object)utilisateurId ?? DBNull.Value);
                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            list.Add(new ActionHistorique
                            {
                                Id = Convert.ToInt32(r["Id"]),
                                UtilisateurId = r["UtilisateurId"] != DBNull.Value ? (int?)Convert.ToInt32(r["UtilisateurId"]) : null,
                                NomUtilisateur = r["NomUtilisateur"].ToString(),
                                Action = r["Action"].ToString(),
                                DateAction = Convert.ToDateTime(r["DateAction"])
                            });
                        }
                    }
                }
            }
            return list;
        }
    }
}