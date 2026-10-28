#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>

#define M_PI 3.14159265358979323846

#define taille_ligne_max 100

// SAE 1.01
// Affichage de l'en-tete du tableau
void afficher_en_tete() {
    printf("+-----------------+-----------------+-------------+-------------+\n");
    printf("| %-15s | %-15s | %-11s | %-11s |\n", "code", "ville", "Latitude", "Longitude");
    printf("+-----------------+-----------------+-------------+-------------+\n");
}

// Fonction pour afficher le contenu du fichier CSV
void afficher_csv(FILE *csv) {
    char ligne[taille_ligne_max];
    char *ptr_chaine;
    char code[10];
    char ville[30];
    double latitude;
    double longitude;
    afficher_en_tete();
    // Ouverture du fichier CSV en mode lecture
    csv = fopen("crd.csv", "r");
    if (csv == NULL) {
        printf("Ouverture fichier impossible !");
        exit(0);
    }

    // Lecture du fichier ligne par ligne
    while (fgets(ligne, taille_ligne_max, csv) != NULL) {
        // Extraction des champs de la ligne lue
        ptr_chaine = strtok(ligne, ";");
        sscanf(ptr_chaine, "%s", code);
        ptr_chaine = strtok(NULL, ";");
        sscanf(ptr_chaine, "%s", ville);
        ptr_chaine = strtok(NULL, ";");
        sscanf(ptr_chaine, "%lf", &latitude);
        ptr_chaine = strtok(NULL, ";");
        sscanf(ptr_chaine, "%lf", &longitude);

        // Affichage des donnees extraites
        printf("| %-15s | %-15s | %11.6f | %11.6f |\n", code, ville, latitude, longitude);
        printf("+-----------------+-----------------+-------------+-------------+\n");
    }

    fclose(csv);
}

// Fonction pour ajouter une nouvelle ville dans le fichier CSV
void ajouter_ville() {
    FILE* csv;
    csv = fopen("crd.csv", "a");
    if (csv == NULL) {
        printf("Erreur d'ouverture du fichier !\n");
        exit(1);
    }

    char ville[30];
    float latitude, longitude;
    char code[10];

    // Saisie des informations de la nouvelle ville
    printf("Saisir le nom de la ville : ");
    scanf("%s", ville);
    printf("Saisir le code INSEE : ");
    scanf("%s", code);
    printf("Saisir la latitude : ");
    scanf("%f", &latitude);
    printf("Saisir la longitude : ");
    scanf("%f", &longitude);

    // Écriture des informations dans le fichier CSV
    fprintf(csv, "%s;%s;%f;%f\n", code, ville, latitude, longitude);
    fclose(csv);
}

// Fonction pour rechercher une ville dans le fichier CSV
void recherche(FILE* csv) {
    char ligne[taille_ligne_max];
    char *ptr_chaine;
    char code[10];
    double latitude;
    double longitude;
    char ville[30];
    char ville_recherchee[30];

    // Saisie du nom de la ville à rechercher
    printf("Saisir le nom de la ville à rechercher : ");
    scanf("%s", ville_recherchee);

    csv = fopen("crd.csv", "r");
    if (csv == NULL) {
        printf("Ouverture fichier impossible !");
        exit(0);
    }

    int ville_trouve = 0; // Variable pour vérifier si la ville a été trouvée

    // Lecture du fichier ligne par ligne
    while (fgets(ligne, taille_ligne_max, csv) != NULL) {
        ptr_chaine = strtok(ligne, ";");
        if (sscanf(ptr_chaine, "%s", code) != 1) {
            continue;
        }
        ptr_chaine = strtok(NULL, ";");
        if (sscanf(ptr_chaine, "%s", ville) != 1) {
            continue;
        }
        ptr_chaine = strtok(NULL, ";");
        if (sscanf(ptr_chaine, "%lf", &latitude) != 1) {
            continue;
        }
        ptr_chaine = strtok(NULL, ",");
        if (sscanf(ptr_chaine, "%lf", &longitude) != 1) {
            continue;
        }

        // Vérification si la ville correspond à la ville recherchée (insensible à la casse)
        if (strcasecmp(ville, ville_recherchee) == 0) {
            afficher_en_tete();
            printf("| %-15s | %-15s | %11.6f | %11.6f |\n", code, ville, latitude, longitude);
            printf("+-----------------+-----------------+-------------+-------------+\n");
            ville_trouve = 1;
            break; // Arrêter la recherche après avoir trouvé la ville
        }
    }

    if (!ville_trouve) {
        printf("Ville non trouvee.\n\n");
    }

    fclose(csv);
}

// Fonction pour modifier les informations d'une ville dans le fichier CSV
void modifier_ville() {
    FILE* csv;
    FILE* temp;
    char ligne[taille_ligne_max];
    char *ptr_chaine;
    char code[10];
    char ville[30];
    double latitude;
    double longitude;
    char ville_recherchee[30];

    // Saisie du nom de la ville à modifier
    printf("Saisir le nom de la ville à modifier : ");
    scanf("%s", ville_recherchee);

    csv = fopen("crd.csv", "r");
    if (csv == NULL) {
        printf("Ouverture fichier impossible !");
        exit(0);
    }

    temp = fopen("temp.csv", "w");
    if (temp == NULL) {
        printf("Ouverture fichier temporaire impossible !");
        fclose(csv);
        exit(0);
    }

    int ville_trouve = 0; // Variable pour vérifier si la ville a été trouvée

    // Lecture du fichier ligne par ligne
    while (fgets(ligne, taille_ligne_max, csv) != NULL) {
        ptr_chaine = strtok(ligne, ";");
        if (sscanf(ptr_chaine, "%s", code) != 1) {
            continue;
        }
        ptr_chaine = strtok(NULL, ";");
        if (sscanf(ptr_chaine, "%s", ville) != 1) {
            continue;
        }
        ptr_chaine = strtok(NULL, ";");
        if (sscanf(ptr_chaine, "%lf", &latitude) != 1) {
            continue;
        }
        ptr_chaine = strtok(NULL, ";");
        if (sscanf(ptr_chaine, "%lf", &longitude) != 1) {
            continue;
        }

        // Vérification si la ville correspond à la ville recherchée
        if (strcmp(ville, ville_recherchee) == 0) {
            printf("Saisir le nouveau nom de la ville : ");
            scanf("%s", ville);
            printf("Saisir le nouveau code INSEE : ");
            scanf("%s", code);
            printf("Saisir la nouvelle latitude : ");
            scanf("%lf", &latitude);
            printf("Saisir la nouvelle longitude : ");
            scanf("%lf", &longitude);
            ville_trouve = 1;
        }

        // Écriture des informations (modifiées ou non) dans le fichier temporaire
        fprintf(temp, "%s;%s;%lf;%lf\n", code, ville, latitude, longitude);
    }

    fclose(csv);
    fclose(temp);

    // Remplacement du fichier original par le fichier temporaire
    remove("crd.csv");
    rename("temp.csv", "crd.csv");

    if (ville_trouve) {
        printf("Les informations de la ville ont ete modifiees avec succes.\n\n");
    } else {
        printf("Ville non trouvee.\n\n");
    }
}

// Fonction pour supprimer une ville du fichier CSV
void supprimer_ville() {
    FILE* csv;
    FILE* temp;
    char ligne[taille_ligne_max];
    char *ptr_chaine;
    char code[10];
    char ville[30];
    double latitude;
    double longitude;
    char ville_recherchee[30];

    // Saisie du nom de la ville à supprimer
    printf("Saisir le nom de la ville à supprimer : ");
    scanf("%s", ville_recherchee);

    csv = fopen("crd.csv", "r");
    if (csv == NULL) {
        printf("Ouverture fichier impossible !\n");
        exit(0);
    }

    temp = fopen("temp.csv", "w");
    if (temp == NULL) {
        printf("Ouverture fichier temporaire impossible !\n");
        fclose(csv);
        exit(0);
    }

    int ville_trouve = 0; // Variable pour vérifier si la ville a été trouvée

    // Lecture du fichier ligne par ligne
    while (fgets(ligne, taille_ligne_max, csv) != NULL) {
        ptr_chaine = strtok(ligne, ";");
        if (sscanf(ptr_chaine, "%s", code) != 1) {
            continue;
        }
        ptr_chaine = strtok(NULL, ";");
        if (sscanf(ptr_chaine, "%s", ville) != 1) {
            continue;
        }
        ptr_chaine = strtok(NULL, ";");
        if (sscanf(ptr_chaine, "%lf", &latitude) != 1) {
            continue;
        }
        ptr_chaine = strtok(NULL, ";");
        if (sscanf(ptr_chaine, "%lf", &longitude) != 1) {
            continue;
        }

        // Vérification si la ville correspond à la ville recherchée
        if (strcmp(ville, ville_recherchee) == 0) {
            ville_trouve = 1;
            continue; // Ne pas écrire cette ligne dans le fichier temporaire
        }

        // Écriture des informations dans le fichier temporaire
        fprintf(temp, "%s;%s;%lf;%lf\n", code, ville, latitude, longitude);
    }

    fclose(csv);
    fclose(temp);

    // Remplacement du fichier original par le fichier temporaire
    remove("crd.csv");
    rename("temp.csv", "crd.csv");

    if (ville_trouve) {
        printf("La ville a ete supprimee avec succes.\n\n");
    } else {
        printf("Ville non trouvee.\n\n");
    }
}

// SAE 1.02
// Fonction pour convertir les degrés en radians
// Cette fonction prend un angle en degrés et le convertit en radians.
// Paramètre:
// - degres: l'angle en degrés à convertir
// Retourne:
// - L'angle en radians
double degres_en_radians(double degres) {
    return degres * M_PI / 180.0;
}

// Fonction pour calculer la distance entre deux points géographiques
// Cette fonction utilise la formule demander pour calculer la distance entre deux points
// sur la surface de la Terre, spécifiés par leurs latitudes et longitudes.
// Paramètres:
// - lat1: latitude du premier point en degrés
// - lon1: longitude du premier point en degrés
// - lat2: latitude du deuxième point en degrés
// - lon2: longitude du deuxième point en degrés
double calculer_distance(double lat1, double lon1, double lat2, double lon2) {
    double R = 6378137; // Rayon de la Terre en mètres
    double dLat = degres_en_radians(lat2 - lat1); // Différence de latitude en radians
    double dLon = degres_en_radians(lon1 - lon2); // Différence de longitude en radians
    // Calcul de la distance en utilisant la formule vu en cours
    double distance = 2 * R * asin(sqrt(pow(sin(dLat / 2), 2) + cos(degres_en_radians(lat1)) * cos(degres_en_radians(lat2)) * pow(sin(dLon / 2), 2)));
        return distance;
    }

// Fonction pour calculer la distance entre deux villes
// la fonction demande à l'utilisateur de saisir les noms de deux villes, puis recherche
// leurs coordonnées géographiques dans le fichier CSV et calcule la distance entre elles.
// Si l'une des villes n'est pas trouvée, un message d'erreur est affiché.
void calculer_distance_entre_villes() {
    FILE* csv;
    char ligne[taille_ligne_max];
    char *ptr_chaine;
    char code[10], ville[30];
    double latitude, longitude;
    char ville1[30], ville2[30];
    double lat1 = 0, long1 = 0, lat2 = 0, long2 = 0;
    int ville1_trouve = 0, ville2_trouve = 0;

    // Saisie des noms des deux villes
    printf("Saisir le nom de la premiere ville : ");
    scanf("%s", ville1);
    printf("Saisir le nom de la deuxieme ville : ");
    scanf("%s", ville2);

    // Ouverture du fichier CSV en mode lecture
    csv = fopen("crd.csv", "r");
    if (csv == NULL) {
        printf("Ouverture fichier impossible !\n");
        exit(0);
    }

    // Lecture du fichier ligne par ligne
    while (fgets(ligne, taille_ligne_max, csv) != NULL) {
        // Extraction des champs de la ligne lue
        ptr_chaine = strtok(ligne, ";");
        sscanf(ptr_chaine, "%s", code);
        ptr_chaine = strtok(NULL, ";");
        sscanf(ptr_chaine, "%s", ville);
        ptr_chaine = strtok(NULL, ";");
        sscanf(ptr_chaine, "%lf", &latitude);
        ptr_chaine = strtok(NULL, ";");
        sscanf(ptr_chaine, "%lf", &longitude);

        // Vérification si la ville correspond à la première ou deuxième ville recherchée
        if (strcmp(ville, ville1) == 0) {
            lat1 = latitude;
            long1 = longitude;
            ville1_trouve = 1;
        }
        if (strcmp(ville, ville2) == 0) {
            lat2 = latitude;
            long2 = longitude;
            ville2_trouve = 1;
        }

        // Si les deux villes ont été trouvées, arrêter la lecture
        if (ville1_trouve && ville2_trouve) {
            break;
        }
    }

    fclose(csv);

    // Vérification si les deux villes ont été trouvées
    if (!ville1_trouve || !ville2_trouve) {
        printf("Une ou les deux villes n'ont pas ete trouvees dans le fichier.\n");
        return;
    }

    // Calcul de la distance entre les deux villes
    double distance = calculer_distance(lat1, long1, lat2, long2) / 1000; // Conversion en km
    printf("La distance entre %s et %s est de %.2f km.\n", ville1, ville2, distance);
}


void distance_de_moi() {
    FILE* csv;
    char ligne[taille_ligne_max];
    char *ptr_chaine;
    char ville_chercher[30];
    char code[10], ville[30];
    double latitude, longitude;
    double lat1, long1,lat2,long2;
    int ville_trouve = 0;

    //mes coordonnées
    printf("quel est votre latitude? ");
    scanf("%lf",&lat1);
    printf("quel est votre longitude? ");
    scanf("%lf",&long1);
    printf("de quel ville voulez vous calculer la distance? ");
    scanf("%s", ville_chercher);


    csv = fopen("crd.csv", "r");
    if (csv == NULL) {
        printf("Ouverture fichier impossible !\n");
        exit(0);
    }

    // Lecture du fichier ligne par ligne
    while (fgets(ligne, taille_ligne_max, csv) != NULL) {
        // Extraction des champs de la ligne lue
        ptr_chaine = strtok(ligne, ";");
        sscanf(ptr_chaine, "%s", code);
        ptr_chaine = strtok(NULL, ";");
        sscanf(ptr_chaine, "%s", ville);
        ptr_chaine = strtok(NULL, ";");
        sscanf(ptr_chaine, "%lf", &latitude);
        ptr_chaine = strtok(NULL, ";");
        sscanf(ptr_chaine, "%lf", &longitude);

    // Vérification si la ville correspond à la ville recherchée
        if (strcmp(ville, ville_chercher) == 0) {
            lat2 = latitude;
            long2 = longitude;
            ville_trouve = 1;
        }
    }

    fclose(csv);
    // Vérification si la ville a été trouvées
    if (!ville_trouve) {
        printf("Une ou les deux villes n'ont pas ete trouvees dans le fichier.\n");
        return;
    }
    // Calcul de la distance entre les deux villes
    double distance = calculer_distance(lat1, long1, lat2, long2) / 1000; // Conversion en km
    printf("La distance entre vous et %s est de %.2f km.\n", ville_chercher, distance);
}
typedef struct {
    char ville[30];
    double distance;
} VilleDistance;

void distance_du_pere_noel(VilleDistance** villes, int* taille) {
    FILE* csv;
    char ligne[taille_ligne_max];
    char *ptr_chaine;
    char code[10], ville[30];
    double latitude, longitude;
    double pole_nord_lat = 90.0, pole_nord_lon = 0.0;
    *villes = NULL;
    *taille = 0;

    csv = fopen("crd.csv", "r");
    if (csv == NULL) {
        printf("Ouverture fichier impossible !\n");
        exit(0);
    }

    printf("+-----------------+-----------------------+\n");
    printf("| %-15s | %-15s |\n", "ville","distance du pole nord");
    printf("+-----------------+-----------------------+\n");
    while (fgets(ligne, taille_ligne_max, csv) != NULL) {
        ptr_chaine = strtok(ligne, ";");
        sscanf(ptr_chaine, "%s", code);
        ptr_chaine = strtok(NULL, ";");
        sscanf(ptr_chaine, "%s", ville);
        ptr_chaine = strtok(NULL, ";");
        sscanf(ptr_chaine, "%lf", &latitude);
        ptr_chaine = strtok(NULL, ";");
        sscanf(ptr_chaine, "%lf", &longitude);

        double distance = calculer_distance(pole_nord_lat, pole_nord_lon, latitude, longitude) / 1000; // Conversion en km
        printf("| %-15s | %14.2f km     |\n", ville, distance);
        printf("+-----------------+-----------------------+\n");

        /**
         * Réalloue la mémoire pour le tableau de structures VilleDistance pour accueillir un élément supplémentaire,
         * copie le nom de la ville fourni dans le nouvel élément, définit la distance pour le nouvel élément,
         * et incrémente la taille du tableau.
          */
        VilleDistance* temp = realloc(*villes, (*taille + 1) * sizeof(VilleDistance));
        if (temp == NULL) {
            printf("Erreur d'allocation memoire !\n");
            exit(1);
        }
        *villes = temp;
        strcpy((*villes)[*taille].ville, ville);
        (*villes)[*taille].distance = distance;
        (*taille)++;

    }

    fclose(csv);
}

void triFusion(int i, int j, VilleDistance tab[], VilleDistance tmp[]) {
    if (j <= i) {
        return;
    }

    int m = (i + j) / 2;

    // On trie récursivement la partie gauche et la partie droite des tableaux
    triFusion(i, m, tab, tmp);
    triFusion(m + 1, j, tab, tmp);

    // On fusionne les deux moitiés des deux tableaux
    int gauche = i, droite = m + 1, compt;
    for (compt = i; compt <= j; compt++) {
        if (gauche == m + 1) {
            tmp[compt] = tab[droite++];
        } else if (droite == j + 1) {
            tmp[compt] = tab[gauche++];
        } else if (tab[gauche].distance < tab[droite].distance) {
            tmp[compt] = tab[gauche++];
        } else {
            tmp[compt] = tab[droite++];
        }
    }

    // On recopie les tableaux temporaires dans les tableaux originels
    for (compt = i; compt <= j; compt++) {
        tab[compt] = tmp[compt];
    }
}

void triInsertion(VilleDistance tab[], int taille) {
    VilleDistance temp;
    for (int i = 1; i < taille; i++) {
        int j = i;
        while (j > 0 && tab[j].distance < tab[j-1].distance) {
            // Échange des valeurs des distances et des noms de ville
            temp = tab[j];
            tab[j] = tab[j-1];
            tab[j-1] = temp;
            j--;
        }
    }
}

// Fonction pour afficher les villes triées par distance au Pôle Nord en utilisant le tri fusion
void afficher_villes_tri_fusion(VilleDistance villes[], int taille) {
    VilleDistance* tmp = malloc(taille * sizeof(VilleDistance));
    if (tmp == NULL) {
        printf("Erreur d'allocation memoire !\n");
        exit(1);
    }
    triFusion(0, taille - 1, villes, tmp);
    free(tmp);

    printf("+-----------------+-----------------------+\n");
    printf("| %-15s | %-15s |\n", "ville", "distance du pole nord");
    printf("+-----------------+-----------------------+\n");
    for (int i = 0; i < taille; i++) {
        printf("| %-15s | %14.2f km     |\n", villes[i].ville, villes[i].distance);
        printf("+-----------------+-----------------------+\n");
    }
}

// Fonction pour afficher les villes triées par distance au Pôle Nord en utilisant le tri par insertion
void afficher_villes_tri_insertion(VilleDistance villes[], int taille) {
    triInsertion(villes, taille);

    printf("+-----------------+-----------------------+\n");
    printf("| %-15s | %-15s |\n", "ville", "distance du pole nord");
    printf("+-----------------+-----------------------+\n");
    for (int i = 0; i < taille; i++) {
        printf("| %-15s | %14.2f km     |\n", villes[i].ville, villes[i].distance);
        printf("+-----------------+-----------------------+\n");
    }
}

// Fonction pour afficher les villes sous la forme "les 10 villes les plus proches sont: v1, v2, v3"
void afficher_villes_proches(VilleDistance villes[], int taille) {
    printf("Les 10 villes les plus proches sont: ");
    for (int i = 0; i < taille && i < 10; i++) {
        if (i > 0) {
            printf(", ");
        }
        printf("%s", villes[i].ville);
    }
    printf(".\n");
}

// Fonction pour calculer les 10 villes les plus proches de l'utilisateur
// qui entre ses coordonnées géographiques (latitude et longitude),
// et les trier par distance en utilisant le tri fusion et le tri insertion
void dix_villes_proches() {
    FILE* csv;
    char ligne[taille_ligne_max];
    char *ptr_chaine;
    char code[10], ville[30];
    double latitude, longitude;
    double lat1, long1;
    VilleDistance* villes = NULL;
    int taille = 0;

    // Mes coordonnées
    printf("Quel est votre latitude? ");
    scanf("%lf", &lat1);
    printf("Quel est votre longitude? ");
    scanf("%lf", &long1);

    csv = fopen("crd.csv", "r");
    if (csv == NULL) {
        printf("Ouverture fichier impossible !\n");
        exit(0);
    }

    // Lecture du fichier ligne par ligne
    while (fgets(ligne, taille_ligne_max, csv) != NULL) {
        // Extraction des champs de la ligne lue
        ptr_chaine = strtok(ligne, ";");
        sscanf(ptr_chaine, "%s", code);
        ptr_chaine = strtok(NULL, ";");
        sscanf(ptr_chaine, "%s", ville);
        ptr_chaine = strtok(NULL, ";");
        sscanf(ptr_chaine, "%lf", &latitude);
        ptr_chaine = strtok(NULL, ";");
        sscanf(ptr_chaine, "%lf", &longitude);

        double distance = calculer_distance(lat1, long1, latitude, longitude) / 1000; // Conversion en km

        // Réalloue la mémoire pour le tableau de structures VilleDistance pour accueillir un élément supplémentaire
        VilleDistance* temp = realloc(villes, (taille + 1) * sizeof(VilleDistance));
        if (temp == NULL) {
            printf("Erreur d'allocation memoire !\n");
            exit(1);
        }
        villes = temp;
        strcpy(villes[taille].ville, ville);
        villes[taille].distance = distance;
        taille++;
    }

    fclose(csv);

    // Vérification si des villes ont été trouvées
    if (taille == 0) {
        printf("Aucune ville n'a ete trouvee dans le fichier.\n");
        return;
    }

    // Tri des villes par distance en utilisant le tri fusion
    VilleDistance* tmp = malloc(taille * sizeof(VilleDistance));
    if (tmp == NULL) {
        printf("Erreur d'allocation memoire !\n");
        exit(1);
    }
    triFusion(0, taille - 1, villes, tmp);
    free(tmp);

    // Affichage des 10 villes les plus proches avec tri fusion
    printf("\nTri fusion\n");
    afficher_villes_proches(villes, taille);

    // Tri des villes par distance en utilisant le tri par insertion
    triInsertion(villes, taille);

    // Affichage des 10 villes les plus proches avec tri par insertion
    printf("\nTri insertion\n");
    afficher_villes_proches(villes, taille);

    free(villes);
}

int main() {
    char choix; // Variable pour stocker le choix de l'utilisateur
    VilleDistance* villes = NULL; // Déclaration de la variable villes
    int taille = 0; // Déclaration de la variable taille

    // Affichage du menu principal
    printf("\n");
    printf("sae 1.01\n");
    printf("+------------------+------------------+------------------+------------------+------------------+------------------+\n");
    printf("| L. Afficher      | S. Supprimer     | M. Modifier      | A. Ajouter       | R. Rechercher    | Q. Quitter       |\n");
    printf("+------------------+------------------+------------------+------------------+------------------+------------------+\n");
    printf("\n");
    printf("sae 1.02\n");
    printf("+------------------------+-------------------------+-------------------------+-------------------------+\n");
    printf("| 1. DistanceEntre2Ville | 2. DistanceDeMoi        | 3. DistancePereNoel     | 4. 10VilleProche        |\n");
    printf("+------------------------+-------------------------+-------------------------+-------------------------+\n");

    // Boucle principale pour gérer les choix
    do {
        printf("\nVeuillez entrer une option: ");
        scanf(" %c", &choix); // Lecture de l'entrée utilisateur

        // Gestion des choix avec switch-case
        switch (choix) {
            case 'L':
            case 'l':
                printf("\n");
                afficher_csv(NULL);
                break;

            case 'S':
            case 's':
                printf("\n");
                supprimer_ville();
                afficher_csv(NULL);
                break;

            case 'M':
            case 'm':
                printf("\n");
                modifier_ville();
                afficher_csv(NULL);
                break;

            case 'A':
            case 'a':
                printf("\n");
                ajouter_ville();
                afficher_csv(NULL);
                break;

            case 'R':
            case 'r':
                printf("\n");
                recherche(NULL);
                break;

            case 'Q':
            case 'q':
                break;

            case '1':
                printf("\n");
                calculer_distance_entre_villes();
                break;

            case '2':
                printf("\n");
                distance_de_moi();
                break;

            case '3':
                printf("\n\n affichage sans tri\n");
                distance_du_pere_noel(&villes, &taille);
                printf("\nTri fusion\n");
                afficher_villes_tri_fusion(villes, taille);
                printf("\nTri insertion\n");
                afficher_villes_tri_insertion(villes, taille);
                break;

            case '4':
                printf("\n");
                dix_villes_proches();
                break;

            default:
                printf("\n");
                printf("Option invalide, veuillez reessayer.\n");
                break;
        }

    } while (choix != 'Q' && choix != 'q'); // Quitte la boucle si l'utilisateur choisit 'Q' ou 'q'

    return 0;
}

