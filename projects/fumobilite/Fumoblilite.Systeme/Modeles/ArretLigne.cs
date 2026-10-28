using System;

namespace Fumoblilite.Systeme.Modeles
{
    /// <summary>
    /// Modèle de données pour un arrêt de ligne.
    /// </summary>
    public class ArretLigne
    {
        public int Id { get; set; } // Identifiant de l'arrêt de ligne
        public int LigneId { get; set; } // Identifiant de la ligne
        public int ArretId { get; set; } // Identifiant de l'arrêt
        public int Ordre { get; set; } // Ordre de l'arrêt sur la ligne
        public int TempsArretMinutes { get; set; } // Temps d'arrêt en minutes
        public int TempsTrajetSuivantMinutes { get; set; } // Temps de trajet jusqu'au prochain arrêt en minutes
        public Arret Arret { get; set; } // Détails de l'arrêt
        public DateTime DateCreation { get; set; } // Date de création de l'arrêt de ligne
        public DateTime? DateModification { get; set; } // Date de modification de l'arrêt de ligne

        /// <summary>
        /// Constructeur par défaut.
        /// Initialise la date de création à la date et l'heure actuelles.
        /// </summary>
        public ArretLigne()
        {
            DateCreation = DateTime.Now;
        }

        /// <summary>
        /// Constructeur avec paramètres.
        /// Initialise les propriétés de l'arrêt de ligne avec les valeurs fournies.
        /// </summary>
        /// <param name="id">Identifiant de l'arrêt de ligne.</param>
        /// <param name="ligneId">Identifiant de la ligne.</param>
        /// <param name="arretId">Identifiant de l'arrêt.</param>
        /// <param name="ordre">Ordre de l'arrêt sur la ligne.</param>
        /// <param name="tempsArretMinutes">Temps d'arrêt en minutes.</param>
        /// <param name="tempsTrajetSuivantMinutes">Temps de trajet jusqu'au prochain arrêt en minutes.</param>
        public ArretLigne(int id, int ligneId, int arretId, int ordre, int tempsArretMinutes, int tempsTrajetSuivantMinutes)
        {
            Id = id;
            LigneId = ligneId;
            ArretId = arretId;
            Ordre = ordre;
            TempsArretMinutes = tempsArretMinutes;
            TempsTrajetSuivantMinutes = tempsTrajetSuivantMinutes;
            DateCreation = DateTime.Now;
        }
    }
}

