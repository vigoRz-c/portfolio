// ============================================
// Configuration et Initialisation
// ============================================
document.addEventListener('DOMContentLoaded', () => {
  renderProjects();
  initYearFooter();
  initSmoothScroll();
  initMobileMenu();
  initProjectFilters();
  initScrollEffects();
  initFormValidation();
  initProfileImageFallback();
  
  // Ajouter classe loaded pour transitions
  setTimeout(() => document.body.classList.add('loaded'), 100);
  initQuantumMoon(); 
});

function renderProjects() {
  const projectsList = document.getElementById('projects-list');
  const projects = Array.isArray(window.PROJECTS_DATA) ? window.PROJECTS_DATA : [];
  if (!projectsList) return;

  const html = projects
    .filter((project) => project.showOnHome !== false)
    .map((project) => buildProjectCard(project))
    .join('');
  projectsList.innerHTML = html;
}

function buildProjectCard(project) {
  const imageClass = project.image.className ? ` class="${project.image.className}"` : '';
  const overlayHref = `projects/project.html?slug=${encodeURIComponent(project.slug)}`;
  const tagsHtml = project.tags.map((tag) => `<span class="tag">${tag}</span>`).join('');
  const linksHtml = Array.isArray(project.links) && project.links.length > 0
    ? `<div class="project-links">${project.links.map((link) => buildProjectLink(link)).join('')}</div>`
    : '';

  return `
        <article class="project-card" data-category="${project.category}">
          <div class="project-image">
            <img src="${project.image.src}" alt="${project.image.alt}" loading="lazy" decoding="async" fetchpriority="low" width="${project.image.width}" height="${project.image.height}"${imageClass} />
            <div class="project-overlay">
              <a href="${overlayHref}" class="project-link">Voir la fiche</a>
            </div>
          </div>
          <div class="project-content">
            <h4>${project.title}</h4>
            <p class="project-desc">${project.cardDescription}</p>
            <div class="project-tags">${tagsHtml}</div>
            ${linksHtml}
          </div>
        </article>`;
}

function buildProjectLink(link) {
  const externalAttrs = link.external ? ' target="_blank" rel="noopener noreferrer"' : '';
  return `<a href="${link.href}"${externalAttrs} class="link-icon" title="${link.title}">
                <svg width="20" height="20" fill="currentColor"><use href="#${link.icon}"/></svg>
              </a>`;
}

// ============================================
// Année du footer (copyright)
// ============================================
function initYearFooter() {
  const yearEl = document.getElementById('year');
  if (yearEl) {
    yearEl.textContent = new Date().getFullYear();
  }
}

// ============================================
// Smooth Scroll pour navigation
// ============================================
function initSmoothScroll() {
  document.querySelectorAll('a[href^="#"]').forEach(anchor => {
    anchor.addEventListener('click', function(e) {
      const href = this.getAttribute('href');
      if (href === '#') return;
      
      e.preventDefault();
      const target = document.querySelector(href);
      if (target) {
        const headerOffset = 80;
        const elementPosition = target.getBoundingClientRect().top;
        const offsetPosition = elementPosition + window.pageYOffset - headerOffset;
        
        window.scrollTo({
          top: offsetPosition,
          behavior: 'smooth'
        });
        
        // Fermer le menu mobile si ouvert
        const navList = document.querySelector('.nav-list');
        if (navList) navList.classList.remove('active');
      }
    });
  });
}

// ============================================
// Menu Mobile Toggle
// ============================================
function initMobileMenu() {
  const toggle = document.getElementById('mobile-toggle');
  const navList = document.querySelector('.nav-list');
  const setMenuState = (isOpen) => {
    navList.classList.toggle('active', isOpen);
    toggle.classList.toggle('active', isOpen);
    toggle.setAttribute('aria-expanded', String(isOpen));
    document.body.classList.toggle('menu-open', isOpen);
  };
  
  if (toggle && navList) {
    setMenuState(false);

    toggle.addEventListener('click', () => {
      const isOpen = !navList.classList.contains('active');
      setMenuState(isOpen);
    });
    
    // Fermer le menu si on clique en dehors
    document.addEventListener('click', (e) => {
      if (!toggle.contains(e.target) && !navList.contains(e.target)) {
        setMenuState(false);
      }
    });

    document.addEventListener('keydown', (e) => {
      if (e.key === 'Escape') {
        setMenuState(false);
      }
    });
  }
}

// ============================================
// Filtres de projets
// ============================================
function initProjectFilters() {
  const filterBtns = document.querySelectorAll('.filter-btn');
  const projectCards = document.querySelectorAll('.project-card');
  const projectsList = document.getElementById('projects-list');
  
  if (filterBtns.length === 0 || projectCards.length === 0) return;
  
  filterBtns.forEach(btn => {
    btn.addEventListener('click', () => {
      const filter = btn.dataset.filter;
      
      // Mise à jour des boutons actifs
      filterBtns.forEach(b => b.classList.remove('active'));
      btn.classList.add('active');
      
      let visibleCount = 0;

      // Filtrage des projets avec animation
      projectCards.forEach(card => {
        const category = card.dataset.category;
        
        if (filter === 'all' || category === filter) {
          visibleCount++;
          card.style.display = 'flex';
          setTimeout(() => {
            card.style.opacity = '1';
            card.style.transform = 'scale(1)';
          }, 10);
        } else {
          card.style.opacity = '0';
          card.style.transform = 'scale(0.8)';
          setTimeout(() => {
            card.style.display = 'none';
          }, 300);
        }
      });

      // Gestion du message textuel si aucun projet ne correspond au filtre
      let emptyMsg = document.getElementById('no-projects-message');
      if (visibleCount === 0) {
        const filterNames = {
          'mobile': 'mobile',
          'web': 'web',
          'sae': 'SAE'
        };
        const categoryName = filterNames[filter] || filter;
        const msgText = `Aucun projet ${categoryName} pour le moment.`;

        if (!emptyMsg && projectsList) {
          emptyMsg = document.createElement('div');
          emptyMsg.id = 'no-projects-message';
          emptyMsg.className = 'no-projects-message';
          emptyMsg.textContent = msgText;
          projectsList.appendChild(emptyMsg);
        } else if (emptyMsg) {
          emptyMsg.textContent = msgText;
          emptyMsg.style.display = 'block';
        }
      } else if (emptyMsg) {
        emptyMsg.style.display = 'none';
      }
    });
  });
}

// ============================================
// Effets au scroll (header, animations)
// ============================================
function initScrollEffects() {
  const header = document.getElementById('header');
  let lastScroll = 0;
  
  window.addEventListener('scroll', () => {
    const currentScroll = window.pageYOffset;
    
    // Header sticky avec effet
    if (header) {
      if (currentScroll > 100) {
        header.classList.add('scrolled');
      } else {
        header.classList.remove('scrolled');
      }
    }
    
    // Animation au scroll pour les sections
    const sections = document.querySelectorAll('section');
    sections.forEach(section => {
      const sectionTop = section.getBoundingClientRect().top;
      const windowHeight = window.innerHeight;
      
      if (sectionTop < windowHeight * 0.8) {
        section.classList.add('fade-in');
      }
    });
    
    lastScroll = currentScroll;
  });
}

// ============================================
// Validation du formulaire de contact
// ============================================
function initFormValidation() {
  const form = document.getElementById('contact-form');
  
  if (!form) return;
  
  form.addEventListener('submit', async (e) => {
    e.preventDefault();
    
    const name = document.getElementById('name').value.trim();
    const email = document.getElementById('email').value.trim();
    const message = document.getElementById('message').value.trim();
    
    // Validation basique
    if (!name || !email || !message) {
      showNotification('Veuillez remplir tous les champs.', 'error');
      return;
    }
    
    if (!isValidEmail(email)) {
      showNotification('Email invalide.', 'error');
      return;
    }
    
    // Si le formulaire utilise Formspree ou un autre service
    const formAction = form.getAttribute('action');
    
    if (formAction && formAction.includes('formspree') && !formAction.includes('YOUR_FORM_ID')) {
      // Envoi via Formspree configuré
      try {
        const response = await fetch(formAction, {
          method: 'POST',
          body: new FormData(form),
          headers: { 'Accept': 'application/json' }
        });
        
        if (response.ok) {
          showNotification('Message envoyé avec succès ! 🎉', 'success');
          form.reset();
        } else {
          showNotification("Erreur lors de l'envoi. Réessayez.", 'error');
        }
      } catch (error) {
        showNotification('Erreur réseau. Vérifiez votre connexion.', 'error');
      }
    } else {
      // Si pas encore configuré (ex: YOUR_FORM_ID encore présent)
      showNotification('⚠️ Configurez votre ID Formspree réel dans le HTML pour activer le formulaire.', 'warning');
      console.log('Form data:', { name, email, message });
    }
  });
}

function isValidEmail(email) {
  const re = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
  return re.test(email);
}

function showNotification(message, type = 'info') {
  // Créer une notification simple
  const notification = document.createElement('div');
  notification.className = `notification notification-${type}`;
  notification.textContent = message;
  notification.style.cssText = `
    position: fixed;
    top: 20px;
    right: 20px;
    padding: 16px 24px;
    background: ${type === 'success' ? '#3fb950' : type === 'error' ? '#f85149' : '#d29922'};
    color: white;
    border-radius: 8px;
    box-shadow: 0 4px 12px rgba(0,0,0,0.3);
    z-index: 10000;
    animation: slideIn 0.3s ease-out;
    max-width: 300px;
  `;
  
  document.body.appendChild(notification);
  
  setTimeout(() => {
    notification.style.animation = 'slideOut 0.3s ease-out';
    setTimeout(() => notification.remove(), 300);
  }, 4000);
}

// Ajouter les keyframes pour les notifications
const style = document.createElement('style');
style.textContent = `
  @keyframes slideIn {
    from { transform: translateX(400px); opacity: 0; }
    to { transform: translateX(0); opacity: 1; }
  }
  @keyframes slideOut {
    from { transform: translateX(0); opacity: 1; }
    to { transform: translateX(400px); opacity: 0; }
  }
`;
document.head.appendChild(style);

function initProfileImageFallback() {
  const profileImg = document.querySelector('.profile-img');
  if (!profileImg) return;

  const showPlaceholder = () => {
    profileImg.style.display = 'none';

    const wrapper = profileImg.parentElement;
    if (!wrapper) return;

    const existing = wrapper.querySelector('.image-placeholder');
    if (existing) return;

    const placeholder = document.createElement('div');
    placeholder.className = 'image-placeholder';
    placeholder.textContent = 'Photo indisponible pour le moment';
    wrapper.appendChild(placeholder);
  };

  if (!profileImg.getAttribute('src')) {
    showPlaceholder();
    return;
  }

  profileImg.addEventListener('error', showPlaceholder);
}

// ============================================
// Easter Egg : Konami Code (optionnel et fun)
// ============================================
let konamiCode = [];
const konamiSequence = ['ArrowUp', 'ArrowUp', 'ArrowDown', 'ArrowDown', 'ArrowLeft', 'ArrowRight', 'ArrowLeft', 'ArrowRight', 'b', 'a'];

document.addEventListener('keydown', (e) => {
  konamiCode.push(e.key);
  konamiCode = konamiCode.slice(-10);
  
  if (konamiCode.join(',') === konamiSequence.join(',')) {
    document.body.style.animation = 'rainbow 2s linear infinite';
    showNotification('🎮 Konami Code activé ! 🌈', 'success');
    
    setTimeout(() => {
      document.body.style.animation = '';
    }, 5000);
  }
});

const rainbowStyle = document.createElement('style');
rainbowStyle.textContent = `
  @keyframes rainbow {
    0% { filter: hue-rotate(0deg); }
    100% { filter: hue-rotate(360deg); }
  }
`;
document.head.appendChild(rainbowStyle);

function initQuantumMoon() {
  const planets = [
    ".planet-th",
    ".planet-bh",
    ".planet-gd",
    ".planet-db",
    ".planet-ash-twin",
    ".planet-ember-twin"
  ];
  const targetPlanetClass = planets[Math.floor(Math.random() * planets.length)];
  const targetPlanet = document.querySelector(targetPlanetClass);

  if (targetPlanet) {
    const isTwin = targetPlanetClass.includes("twin");
    const orbitSize = isTwin ? 18 : 28;
    const moonSize = 5;
    
    const quantumMoonHTML = "<div class=\"moon-orbit quantum-orbit\" style=\"width: " + orbitSize + "px; height: " + orbitSize + "px; top: -" + (orbitSize / 2) + "px; left: -" + (orbitSize / 2) + "px; border: 1px dashed rgba(170,170,187,0.5); animation: spin " + (Math.random() * 2 + 2) + "s linear infinite; z-index: -1;\">" +
      "<div class=\"planet-quantum\" style=\"width: " + moonSize + "px; height: " + moonSize + "px; top: -" + (moonSize/2) + "px; left: calc(50% - " + (moonSize/2) + "px);\"></div>" +
    "</div>";
    
    targetPlanet.insertAdjacentHTML("beforeend", quantumMoonHTML);
  }
}
