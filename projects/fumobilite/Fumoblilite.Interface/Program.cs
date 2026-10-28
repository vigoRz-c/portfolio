using System;
using System.Windows.Forms;
using Fumoblilite.Interface.Forms;
using Fumoblilite.SQL;


/*
* Temps passé sur le projet : 
* LEMAIRE Clément: 83 heures de développement, tests, intégration de la base de données, rédaction de la documentation et de conception de l'interface utilisateur.
* LEPEUVE Maxence: 53 heures de développement, tests, intégration de la base de données et de conception de l'interface utilisateur.
* CARPENTIER Louka: 21 heures de développement, tests, rédaction de la documentation.
* BASIN Léanne: 25 heures de développement, rédaction de la documentation et de conception de l'interface utilisateur.
* Noa Arnould: 24 heures de développement, tests, rédaction de la documentation.
* Loïc Restout: 24 heures de développement, tests, rédaction de la documentation.
*/

namespace Fumoblilite.Interface
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Configuration de la base de données MySQL
            string serveur = "10.1.139.236";
            string login = "a6";
            string mdp = "fumo";
            string bd = "basea6";

            // Initialiser la base de données
            GestionBaseDonnees gestionBD = new GestionBaseDonnees(serveur, login, mdp, bd);

            // Tester la connexion
            if (!gestionBD.TesterConnexion())
            {
                MessageBox.Show("Impossible de se connecter à la base de données. Vérifiez les paramètres de connexion.",
                               "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Créer les tables si nécessaire
            try
            {
                bool nouvelleBase = gestionBD.CreerBaseDonneesSiNonExistante();
                if (nouvelleBase)
                {
                    MessageBox.Show("Base de données initialisée avec succès!",
                                   "Initialisation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'initialisation de la base de données : {ex.Message}",
                               "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.Run(new FormPrincipal(gestionBD.ConnectionString, null));
        }
    }
}
