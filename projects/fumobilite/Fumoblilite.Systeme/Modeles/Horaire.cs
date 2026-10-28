using System;

namespace Fumoblilite.Systeme.Modeles
{
    /// <summary>
    /// Représente un horaire pour une ligne et un arrêt donnés.
    /// </summary>
    public class Horaire
    {
        public int Id { get; set; }
        public int LigneId { get; set; }
        public int ArretId { get; set; }
        public DayOfWeek JourSemaine { get; set; }
        public TimeSpan HeureDepart { get; set; }
        public bool EstActif { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime? DateModification { get; set; }

        /// <summary>
        /// Initialise une nouvelle instance de la classe Horaire avec les valeurs par défaut.
        /// </summary>
        public Horaire()
        {
            DateCreation = DateTime.Now;
            EstActif = true;
        }

        /// <summary>
        /// Initialise une nouvelle instance de la classe Horaire avec les valeurs spécifiées.
        /// </summary>
        /// <param name="id">Identifiant de l'horaire.</param>
        /// <param name="ligneId">Identifiant de la ligne.</param>
        /// <param name="arretId">Identifiant de l'arrêt.</param>
        /// <param name="jourSemaine">Jour de la semaine.</param>
        /// <param name="heureDepart">Heure de départ.</param>
        public Horaire(int id, int ligneId, int arretId, DayOfWeek jourSemaine, TimeSpan heureDepart)
        {
            Id = id;
            LigneId = ligneId;
            ArretId = arretId;
            JourSemaine = jourSemaine;
            HeureDepart = heureDepart;
            EstActif = true;
            DateCreation = DateTime.Now;
        }
    }
}

