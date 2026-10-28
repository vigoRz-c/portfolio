using System;

namespace Fumoblilite.Systeme.Modeles
{
    /// <summary>
    /// Représente une action effectuée par un utilisateur dans l'historique du système.
    /// </summary>
    public class ActionHistorique
    {
        public int Id { get; set; }
        public int? UtilisateurId { get; set; }
        public string NomUtilisateur { get; set; }
        public string Action { get; set; }
        public DateTime DateAction { get; set; }
    }
}
