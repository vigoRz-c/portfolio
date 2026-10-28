# 🪐 Portfolio — Loïc RESTOUT

> Portfolio personnel et professionnel d'étudiant en **3ème année de BUT Informatique à l'IUT d'Amiens**.  
> Développeur passionné par le web, le génie logiciel et la modélisation mathématique.

🌐 **Démo en ligne :** [vigoRz-c.github.io/portfolio](https://vigoRz-c.github.io/portfolio)

---

## ✨ Points forts & Fonctionnalités

- 🌌 **Direction artistique Outer Wilds :** Palette cosmique (espace profond, lueur feu de camp `#ff7a00`, cyan/violet quantique `#9b51e0`).
- 🪐 **Simulation Canvas 2D interactive :** Moteur graphique animé du système solaire d'Outer Wilds (`Sablières`, `Âtrebois`, `Cravité`, `Léviathe`, `Sombreronces` et téléportation avec glitch de la `Lune Quantique`).
- 🎓 **Compétences BUT Informatique :** Articulées autour des 6 compétences du Programme National (Réaliser, Optimiser, Administrer, Gérer les données, Conduire, Travailler en équipe).
- 📂 **Fiches projets dynamiques :** Système modulaire généré via JavaScript sans duplication de code HTML (`projects/project.html` et `projects/source.html`).
- 📄 **CV en ligne & format A4 imprimable :** Page dédiée (`cv/cv.html`) avec bouton d'impression/export PDF natif (`window.print()`).
- 📱 **100% Responsive :** Navigation fluide, menu burger mobile et adaptation aux écrans smartphones, tablettes et desktop.
- ⚡ **Zero Dependency :** Développé en HTML5, CSS3 et JavaScript Vanilla pur, ultra léger et sans build process lourd.

---

## 📁 Architecture du projet

```text
portfolio/
├── index.html              # Page d'accueil principale (Hero, Projets, Compétences, Contact)
├── portfolio.html          # Alias compatible
├── README.md               # Présentation du projet
├── .gitignore              # Règles d'exclusion Git
├── cv/
│   ├── cv.html             # CV responsive et format A4 imprimable
│   ├── style.css           # Feuille de style dédiée au CV
│   └── IMG_20251013...     # Photo de profil
├── projects/
│   ├── project.html        # Fiche dynamique de présentation d'un projet (?slug=...)
│   ├── source.html         # Fiche d'accès et téléchargement des sources (?slug=...)
│   ├── fumobilite/         # Code source SAE C# / SQL
│   ├── fumotion/           # Code source SAE Fullstack React / Express / Node.js
│   └── sae-11-12/          # Code source SAE C
└── assets/
    ├── css/
    │   ├── styles.css      # Feuille de style principale (thème Outer Wilds)
    │   └── project-page.css# Style des fiches projets et sources
    ├── js/
    │   ├── outer-wilds.js  # Moteur de rendu Canvas 2D (système solaire)
    │   ├── script.js       # Logique interactive (menu, scroll, filtres, notifications)
    │   ├── projects-data.js# Base de données JSON des projets
    │   └── project-pages.js# Moteur de rendu dynamique des fiches
    ├── images/             # Logos et photographies
    └── downloads/          # Archives ZIP des codes sources
```

---

## 🚀 Lancement en local

Aucune installation de dépendance n'est requise. Vous pouvez lancer le site avec n'importe quel serveur HTTP statique :

### Avec Python :
```bash
python -m http.server 8080
```
Puis ouvrez votre navigateur à l'adresse [http://localhost:8080](http://localhost:8080).

### Avec l'extension VS Code Live Server :
Ouvrez le dossier dans VS Code, faites un clic droit sur `index.html` et sélectionnez **Open with Live Server**.

---

## 📡 Déploiement sur GitHub Pages

1. Créez un dépôt nommé `portfolio` sur votre compte GitHub (`vigoRz-c`).
2. Poussez la branche `main` :
   ```bash
   git remote add origin https://github.com/vigoRz-c/portfolio.git
   git branch -M main
   git push -u origin main
   ```
3. Rendez-vous dans **Settings** > **Pages** sur GitHub.
4. Dans **Build and deployment**, sous **Branch**, sélectionnez `main` et `/ (root)`, puis cliquez sur **Save**.
5. Le site sera automatiquement en ligne sur :  
   👉 `https://vigoRz-c.github.io/portfolio/`

---

## 📬 Contact & Liens

- **Email :** [loic.res67@gmail.com](mailto:loic.res67@gmail.com)
- **LinkedIn :** [Loïc RESTOUT](https://www.linkedin.com/in/lo%C3%AFc-restout-30027933a/)
- **GitHub :** [@vigoRz-c](https://github.com/vigoRz-c)

---

&copy; Loïc RESTOUT — Tous droits réservés.
