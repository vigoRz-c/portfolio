using System;

namespace Fumoblilite.Systeme.Modeles
{
    /// <summary>
    /// Modèle de données pour un arrêt
    /// </summary>
    public class Arret
    {
        public int Id { get; set; } // Identifiant de l'arrêt
        public string Nom { get; set; } // Nom de l'arrêt
        public string Adresse { get; set; } // Adresse de l'arrêt
        public double Latitude { get; set; } // Latitude de l'arrêt
        public double Longitude { get; set; } // Longitude de l'arrêt
        public bool EstAccessible { get; set; } // Accessibilité de l'arrêt
        public DateTime DateCreation { get; set; } // Date de création de l'arrêt
        public DateTime? DateModification { get; set; } // Date de modification de l'arrêt

        /// <summary>
        /// Constructeur par défaut. Initialise la date de création à la date et l'heure actuelles.
        /// </summary>
        public Arret()
        {
            DateCreation = DateTime.Now;
        }

        /// <summary>
        /// Constructeur avec paramètres pour initialiser toutes les propriétés sauf la date de modification.
        /// </summary>
        /// <param name="id">Identifiant de l'arrêt</param>
        /// <param name="nom">Nom de l'arrêt</param>
        /// <param name="adresse">Adresse de l'arrêt</param>
        /// <param name="latitude">Latitude de l'arrêt</param>
        /// <param name="longitude">Longitude de l'arrêt</param>
        /// <param name="estAccessible">Indique si l'arrêt est accessible</param>
        public Arret(int id, string nom, string adresse, double latitude, double longitude, bool estAccessible)
        {
            Id = id;
            Nom = nom;
            Adresse = adresse;
            Latitude = latitude;
            Longitude = longitude;
            EstAccessible = estAccessible;
            DateCreation = DateTime.Now;
        }
    }
}

