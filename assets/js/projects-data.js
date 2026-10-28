window.PROJECTS_DATA = [
  {
    slug: 'sae-11-12-how-far-from-me',
    showOnHome: true,
    category: 'sae',
    title: 'SAE 1.1 / 1.2 - How Far From Me',
    cardDescription: 'Projet de première année orienté résolution de problème et mise en pratique des bases informatiques.',
    tags: ['SAE', 'Groupe', 'Méthodologie'],
    image: {
      src: 'assets/images/sae-placeholder.svg',
      alt: 'Illustration SAE 1.1 et 1.2',
      width: 1200,
      height: 700
    },
    detail: {
      subtitle: 'Projet academique de premiere annee',
      sections: [
        {
          title: 'Presentation',
          text: 'Ce projet de SAE introduit la demarche de realisation d une solution informatique en equipe avec cadrage du besoin, organisation du travail et restitution technique.'
        },
        {
          title: 'Travail realise',
          text: 'Definition du probleme, decomposition des taches, production des livrables et communication des resultats dans un format attendu en BUT Informatique.'
        }
      ]
    },
    source: {
      available: true,
      note: 'Etat: disponible dans le workspace',
      files: [
        { href: '../projects/sae-11-12/SAE%201.02%20FINAL.c', label: 'SAE 1.02 FINAL.c' },
        { href: '../projects/sae-11-12/crd.csv', label: 'crd.csv' },
        { href: '../projects/sae-11-12/SAE%201.02%20FINAL.exe', label: 'SAE 1.02 FINAL.exe' }
      ],
      zipHref: '../assets/downloads/sae-11-12-source.zip'
    }
  },
  {
    slug: 'sae-fumotion',
    showOnHome: true,
    category: 'sae',
    title: 'SAE S3 - Fumotion',
    cardDescription: 'Application web de gestion de voyages avec frontend React, backend Express et API REST.',
    tags: ['SAE', 'Groupe', 'React', 'Node.js', 'JWT'],
    image: {
      src: 'assets/images/fumotion-logo.png',
      alt: 'Logo du projet SAE Fumotion',
      width: 512,
      height: 512,
      className: 'project-img-contain'
    },
    detail: {
      subtitle: 'Application web de gestion de voyages',
      sections: [
        {
          title: 'Presentation',
          text: 'Projet full stack avec frontend React, backend Express et API REST pour gerer des voyages, reservations et profils utilisateurs.'
        },
        {
          title: 'Points techniques',
          text: 'Architecture modulaire, authentification JWT, organisation en routes backend et composants frontend.'
        }
      ]
    },
    source: {
      available: true,
      note: 'Etat: disponible dans le workspace',
      files: [
        { href: '../projects/fumotion/README.md', label: 'README.md' },
        { href: '../projects/fumotion/package.json', label: 'package.json' },
        { href: '../projects/fumotion/app/backend/server.js', label: 'app/backend/server.js' },
        { href: '../projects/fumotion/app/frontend/package.json', label: 'app/frontend/package.json' }
      ],
      zipHref: '../assets/downloads/fumotion-source.zip'
    }
  },
  {
    slug: 'sae-fumobilite',
    showOnHome: true,
    category: 'sae',
    title: 'SAE S2 - Fumobilite',
    cardDescription: 'Application conçue en architecture modulaire avec interface, logique système et composant SQL.',
    tags: ['SAE', 'Groupe', 'C#', 'SQL'],
    image: {
      src: 'assets/images/fumobilite-logo.png',
      alt: 'Logo du projet SAE Fumobilite',
      width: 1280,
      height: 1280,
      className: 'project-img-contain'
    },
    detail: {
      subtitle: 'Projet de second semestre en architecture modulaire',
      sections: [
        {
          title: 'Presentation',
          text: 'Application structuree en plusieurs composants avec une partie interface, une partie systeme et une partie SQL.'
        },
        {
          title: 'Objectifs',
          text: 'Concevoir une application maintenable, separer les responsabilites techniques et produire des livrables de semestre coherents.'
        }
      ]
    },
    source: {
      available: true,
      note: 'Etat: disponible dans le workspace',
      files: [
        { href: '../projects/fumobilite/README.md', label: 'README.md' },
        { href: '../projects/fumobilite/Fumobilite.sln', label: 'Fumobilite.sln' },
        { href: '../projects/fumobilite/Fumoblilite.Interface/Fumoblilite.Interface.csproj', label: 'Fumoblilite.Interface.csproj' },
        { href: '../projects/fumobilite/Fumoblilite.Systeme/Fumoblilite.Systeme.csproj', label: 'Fumoblilite.Systeme.csproj' }
      ],
      zipHref: '../assets/downloads/fumobilite-source.zip'
    }
  },
  {
    slug: 'lestroischats',
    showOnHome: true,
    category: 'web',
    title: 'LesTroisChats.net',
    cardDescription: 'Création et maintenance complète d un site e-commerce avec Wix Studio (été 2025).',
    tags: ['Professionnel', 'Wix Studio', 'CMS', 'Velo'],
    image: {
      src: 'assets/images/lestroischats_en_noir.webp',
      alt: 'Site e-commerce LesTroisChats.net',
      width: 381,
      height: 185,
      className: 'project-img-contain project-img-light'
    },
    detail: {
      subtitle: 'Creation et maintenance d un site e commerce',
      sections: [
        {
          title: 'Presentation',
          text: 'Projet professionnel realise en 2025 avec gestion complete du cycle de vie du site, de la conception a la maintenance.'
        },
        {
          title: 'Responsabilites',
          text: 'Integration, personnalisation, optimisation de contenu et suivi technique continu.'
        }
      ],
      actions: [
        {
          href: 'https://lestroischats.net',
          label: 'Visiter le site',
          className: 'btn-primary',
          external: true
        }
      ]
    },
    links: [
      {
        href: 'https://lestroischats.net',
        title: 'Voir le site',
        icon: 'icon-external',
        external: true
      }
    ],
    source: {
      available: false,
      note: 'Le code source de ce projet web n est pas stocke localement dans but-projects.',
      files: [],
      zipHref: ''
    }
  },
  {
    slug: 'portfolio-personnel',
    showOnHome: true,
    category: 'web',
    title: 'Portfolio Personnel',
    cardDescription: 'Site portfolio moderne et responsive pour présenter mes projets et compétences.',
    tags: ['Personnel', 'HTML/CSS',  'JavaScript'],
    image: {
      src: 'assets/images/portfolio-placeholder.svg',
      alt: 'Illustration du projet portfolio personnel',
      width: 1200,
      height: 700,
      className: 'project-img-contain'
    },
    detail: {
      subtitle: 'Site vitrine pour presenter mes projets et competences',
      sections: [
        {
          title: 'Presentation',
          text: 'Ce portfolio est concu comme un site rapide et lisible pour centraliser les projets web, SAE et informations de parcours.'
        },
        {
          title: 'Points cles',
          text: 'Navigation fluide, filtres de projets, structure simple et adaptation mobile.'
        }
      ],
      actions: [
        {
          href: 'https://github.com/vigoRz-c/portfolio',
          label: 'Code source',
          className: 'btn-secondary',
          external: true
        },
        {
          href: 'https://vigoRz-c.github.io/portfolio',
          label: 'Voir la demo',
          className: 'btn-primary',
          external: true
        }
      ]
    },
    links: [
      {
        href: 'https://github.com/vigoRz-c/portfolio',
        title: 'Code source',
        icon: 'icon-github',
        external: true
      },
      {
        href: 'https://vigoRz-c.github.io/portfolio',
        title: 'Démo live',
        icon: 'icon-external',
        external: true
      }
    ],
    source: {
      available: false,
      note: 'Le code source principal de ce site est le repository courant.',
      files: [
        { href: '../index.html', label: 'index.html' },
        { href: '../assets/css/styles.css', label: 'assets/css/styles.css' },
        { href: '../assets/js/script.js', label: 'assets/js/script.js' }
      ],
      zipHref: ''
    }
  }
];
