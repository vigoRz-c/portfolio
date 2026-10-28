using System;
using System.Collections.Generic;

namespace Fumoblilite.Systeme.Modeles
{
    /// <summary>
    /// Représente un itinéraire entre deux arrêts, incluant les étapes, horaires et informations de trajet.
    /// </summary>
    public class Itineraire
    {
        public int ArretDepartId { get; set; }
        public int ArretArriveeId { get; set; }
        public DateTime HeureDepart { get; set; }
        public DateTime HeureArrivee { get; set; }
        public int DureeMinutes { get; set; }
        public int NombreChangements { get; set; }
        public List<EtapeItineraire> Etapes { get; set; }

        public Itineraire()
        {
            Etapes = new List<EtapeItineraire>();
        }
    }

    /// <summary>
    /// Représente une étape d'un itinéraire, correspondant à un trajet sur une ligne entre deux arrêts.
    /// </summary>
    public class EtapeItineraire
    {
        public int LigneId { get; set; }
        public string NomLigne { get; set; }
        public string CouleurLigne { get; set; }
        public int ArretDepartId { get; set; }
        public string NomArretDepart { get; set; }
        public int ArretArriveeId { get; set; }
        public string NomArretArrivee { get; set; }
        public DateTime HeureDepart { get; set; }
        public DateTime HeureArrivee { get; set; }
        public int DureeMinutes { get; set; }
    }
}

