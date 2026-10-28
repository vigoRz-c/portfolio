import { useState } from "react"
import { useNavigate } from "react-router-dom"
import "../styles/HomePage.css"

export default function HomePage() {
  const navigate = useNavigate()
  const [searchData, setSearchData] = useState({
    departure: "",
    arrival: "",
    date: "",
    passengers: 1,
  })

  const handleSearch = (e) => {
    e.preventDefault()
    console.log("Recherche:", searchData)
    // TODO: Navigate to search results
  }

  return (
    <div className="homepage">
      <nav className="navbar">
        <div className="navbar-container">
          <div className="navbar-brand" onClick={() => navigate("/")}>
            <span className="brand-logo"></span>
            <span className="brand-name">Fumotion</span>
          </div>

          <div className="navbar-menu">
            <a href="#how-it-works" className="navbar-link">
              Comment ça marche
            </a>
            <a href="#pricing" className="navbar-link">
              Tarifs
            </a>
            <button onClick={() => navigate("/login")} className="navbar-btn-secondary">
              Connexion
            </button>
            <button onClick={() => navigate("/register")} className="navbar-btn-primary">
              Inscription
            </button>
          </div>
        </div>
      </nav>

      <section className="hero-section">
        <div className="hero-container">
          <div className="hero-content">
            <h1 className="hero-title">
              Voyagez moins cher
              <br />
              entre étudiants
            </h1>
            <p className="hero-subtitle">
              Partagez vos trajets universitaires et économisez jusqu'à 70% sur vos déplacements
            </p>

            <div className="search-card">
              <div className="search-tabs">
                <button className="search-tab active">
                  <span className="tab-icon"></span>
                  Trouver un trajet
                </button>
                <button className="search-tab">
                  <span className="tab-icon"></span>
                  Proposer un trajet
                </button>
              </div>

              <form onSubmit={handleSearch} className="search-form">
                <div className="form-row">
                  <div className="form-group">
                    <label className="form-label">
                      <span className="label-icon"></span>
                      Départ
                    </label>
                    <input
                      type="text"
                      placeholder="Paris, Gare de Lyon"
                      className="form-input"
                      value={searchData.departure}
                      onChange={(e) => setSearchData({ ...searchData, departure: e.target.value })}
                    />
                  </div>

                  <div className="form-group">
                    <label className="form-label">
                      <span className="label-icon"></span>
                      Arrivée
                    </label>
                    <input
                      type="text"
                      placeholder="Lyon, Part-Dieu"
                      className="form-input"
                      value={searchData.arrival}
                      onChange={(e) => setSearchData({ ...searchData, arrival: e.target.value })}
                    />
                  </div>

                  <div className="form-group">
                    <label className="form-label">
                      <span className="label-icon"></span>
                      Date
                    </label>
                    <input
                      type="date"
                      className="form-input"
                      value={searchData.date}
                      onChange={(e) => setSearchData({ ...searchData, date: e.target.value })}
                    />
                  </div>

                  <div className="form-group">
                    <label className="form-label">
                      <span className="label-icon"></span>
                      Passagers
                    </label>
                    <select
                      className="form-input"
                      value={searchData.passengers}
                      onChange={(e) => setSearchData({ ...searchData, passengers: e.target.value })}
                    >
                      <option value="1">1</option>
                      <option value="2">2</option>
                      <option value="3">3</option>
                      <option value="4">4+</option>
                    </select>
                  </div>
                </div>

                <button type="submit" className="search-button">
                  Rechercher
                </button>
              </form>
            </div>

            <div className="trust-indicators">
              <div className="trust-item">
                <span className="trust-number">50K+</span>
                <span className="trust-label">Étudiants inscrits</span>
              </div>
              <div className="trust-item">
                <span className="trust-number">4.8/5</span>
                <span className="trust-label">Note moyenne</span>
              </div>
              <div className="trust-item">
                <span className="trust-number">100K+</span>
                <span className="trust-label">Trajets partagés</span>
              </div>
            </div>
          </div>
        </div>
      </section>

      <section className="benefits-section">
        <div className="benefits-container">
          <h2 className="section-title">Pourquoi choisir Fumotion ?</h2>

          <div className="benefits-grid">
            <div className="benefit-card">
              <div className="benefit-illustration">
                <img src="/placeholder.svg?height=200&width=300" alt="Économies" />
              </div>
              <h3 className="benefit-title">Économisez sur vos trajets</h3>
              <p className="benefit-description">
                Partagez les frais d'essence et de péage. Économisez jusqu'à 70% par rapport aux transports
                traditionnels.
              </p>
            </div>

            <div className="benefit-card">
              <div className="benefit-illustration">
                <img src="/placeholder.svg?height=200&width=300" alt="Réservation facile" />
              </div>
              <h3 className="benefit-title">Réservation en quelques clics</h3>
              <p className="benefit-description">
                Trouvez et réservez votre trajet en moins de 2 minutes. Paiement sécurisé et confirmation instantanée.
              </p>
            </div>

            <div className="benefit-card">
              <div className="benefit-illustration">
                <img src="/placeholder.svg?height=200&width=300" alt="Flexibilité" />
              </div>
              <h3 className="benefit-title">Flexibilité totale</h3>
              <p className="benefit-description">
                Annulation gratuite jusqu'à 24h avant le départ. Modifiez votre réservation à tout moment.
              </p>
            </div>
          </div>
        </div>
      </section>

      <section id="how-it-works" className="how-it-works-section">
        <div className="how-it-works-container">
          <h2 className="section-title">Comment ça marche ?</h2>

          <div className="steps-grid">
            <div className="step-card">
              <div className="step-number">1</div>
              <div className="step-icon"></div>
              <h3 className="step-title">Recherchez votre trajet</h3>
              <p className="step-description">Entrez votre point de départ, destination et date de voyage</p>
            </div>

            <div className="step-card">
              <div className="step-number">2</div>
              <div className="step-icon"></div>
              <h3 className="step-title">Réservez votre place</h3>
              <p className="step-description">Choisissez parmi les conducteurs vérifiés et réservez en ligne</p>
            </div>

            <div className="step-card">
              <div className="step-number">3</div>
              <div className="step-icon"></div>
              <h3 className="step-title">Voyagez sereinement</h3>
              <p className="step-description">Rencontrez votre conducteur et profitez de votre trajet</p>
            </div>
          </div>
        </div>
      </section>

      <footer className="footer">
        <div className="footer-container">
          <div className="footer-grid">
            <div className="footer-column">
              <div className="footer-brand">
                <span className="footer-logo"></span>
                <span className="footer-name">Fumotion</span>
              </div>
              <p className="footer-tagline">
                La plateforme de covoiturage
                <br />
                dédiée aux étudiants
              </p>
            </div>

            <div className="footer-column">
              <h4 className="footer-heading">À propos</h4>
              <ul className="footer-links">
                <li>
                  <a href="#how-it-works">Comment ça marche</a>
                </li>
                <li>
                  <a href="#pricing">Tarifs</a>
                </li>
                <li>
                  <a href="/about">Qui sommes-nous</a>
                </li>
                <li>
                  <a href="/blog">Blog</a>
                </li>
              </ul>
            </div>

            <div className="footer-column">
              <h4 className="footer-heading">Support</h4>
              <ul className="footer-links">
                <li>
                  <a href="/help">Centre d'aide</a>
                </li>
                <li>
                  <a href="/contact">Nous contacter</a>
                </li>
                <li>
                  <a href="/security">Sécurité</a>
                </li>
                <li>
                  <a href="/insurance">Assurance</a>
                </li>
              </ul>
            </div>

            <div className="footer-column">
              <h4 className="footer-heading">Légal</h4>
              <ul className="footer-links">
                <li>
                  <a href="/terms">Conditions générales</a>
                </li>
                <li>
                  <a href="/privacy">Politique de confidentialité</a>
                </li>
                <li>
                  <a href="/legal">Mentions légales</a>
                </li>
                <li>
                  <a href="/cookies">Cookies</a>
                </li>
              </ul>
            </div>
          </div>

          <div className="footer-bottom">
            <p>&copy; 2025 Fumotion. Tous droits réservés.</p>
            <div className="footer-social">
              <a href="https://facebook.com" className="social-link" target="_blank" rel="noopener noreferrer">
                temp
              </a>
              <a href="https://twitter.com" className="social-link" target="_blank" rel="noopener noreferrer">
                temp
              </a>
              <a href="https://instagram.com" className="social-link" target="_blank" rel="noopener noreferrer">
                temp
              </a>
            </div>
          </div>
        </div>
      </footer>
    </div>
  )
}

