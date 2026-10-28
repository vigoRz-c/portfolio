(function () {
  function getProjectBySlug() {
    const params = new URLSearchParams(window.location.search);
    const slug = params.get('slug') || '';
    const list = Array.isArray(window.PROJECTS_DATA) ? window.PROJECTS_DATA : [];
    return list.find((item) => item.slug === slug);
  }

  function extAttrs(external) {
    return external ? ' target="_blank" rel="noopener noreferrer"' : '';
  }

  function renderNotFound() {
    const main = document.getElementById('page-main');
    if (!main) return;
    main.innerHTML = '<section class="content"><h1>Projet introuvable</h1><p class="note">Le lien de fiche est invalide.</p></section>';
  }

  function renderDetail(project) {
    const main = document.getElementById('page-main');
    const title = document.getElementById('page-title');
    const back = document.getElementById('back-link');
    if (!main || !title || !back) return;

    title.textContent = project.title;
    back.href = '../index.html#projects';
    back.textContent = 'Retour aux projets';

    const tags = project.tags.map((tag) => `<span class="tag">${tag}</span>`).join('');
    const sections = project.detail.sections
      .map((section) => `<h2 class="section-title">${section.title}</h2><p>${section.text}</p>`)
      .join('');

    const sourceAction = `<a class="btn btn-secondary" href="./source.html?slug=${encodeURIComponent(project.slug)}">Code source</a>`;
    const extraActions = Array.isArray(project.detail.actions)
      ? project.detail.actions
          .map((action) => `<a class="btn ${action.className || 'btn-secondary'}" href="${action.href}"${extAttrs(action.external)}>${action.label}</a>`)
          .join('')
      : '';

    const imageClass = project.image.className ? ` class="${project.image.className}"` : '';

    main.innerHTML = `
      <section class="hero">
        <img src="../${project.image.src}" alt="${project.image.alt}" width="${project.image.width}" height="${project.image.height}"${imageClass} />
        <div>
          <h1>${project.title}</h1>
          <p class="subtitle">${project.detail.subtitle}</p>
          <div class="tags">${tags}</div>
          <div class="actions">${sourceAction}${extraActions}</div>
        </div>
      </section>
      <section class="content">${sections}</section>`;
  }

  function renderSource(project) {
    const main = document.getElementById('page-main');
    const title = document.getElementById('page-title');
    const back = document.getElementById('back-link');
    if (!main || !title || !back) return;

    title.textContent = `Code source - ${project.title}`;
    back.href = `./project.html?slug=${encodeURIComponent(project.slug)}`;
    back.textContent = 'Retour a la fiche';

    const files = Array.isArray(project.source.files)
      ? project.source.files.map((file) => `<li><a href="${file.href}">${file.label}</a></li>`).join('')
      : '';

    const zipButton = project.source.available && project.source.zipHref
      ? `<a class="btn btn-primary" href="${project.source.zipHref}" download>Télécharger le ZIP</a>`
      : '<a class="btn btn-secondary btn-disabled" href="#" aria-disabled="true">Télécharger le ZIP</a>';

    const sourceBody = files
      ? `<ul class="file-list">${files}</ul>`
      : `<p class="note">${project.source.note}</p>`;

    main.innerHTML = `
      <section class="content">
        <h1>Code source - ${project.title}</h1>
        <p class="subtitle">Acces direct aux fichiers du projet</p>
        <div class="source-box">
          <div class="source-status">${project.source.available ? 'Etat: disponible dans le workspace' : 'Etat: non disponible dans le workspace'}</div>
          ${sourceBody}
          <div class="actions">${zipButton}</div>
        </div>
      </section>`;
  }

  document.addEventListener('DOMContentLoaded', function () {
    const project = getProjectBySlug();
    if (!project) {
      renderNotFound();
      return;
    }

    if (window.location.pathname.endsWith('/source.html')) {
      renderSource(project);
      return;
    }

    renderDetail(project);
  });
})();
