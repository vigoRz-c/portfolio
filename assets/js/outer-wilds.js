/**
 * Animation HTML5 Canvas du Système Solaire d'Outer Wilds
 * Refonte avec tri Z-Index global et graphismes avancés
 */
const canvas = document.getElementById('solarSystemCanvas');
const ctx = canvas.getContext('2d');

const starsCanvas = document.getElementById('starsCanvas');
const starsCtx = starsCanvas ? starsCanvas.getContext('2d') : null;

let width = 0, height = 0;
let starsWidth = 0, starsHeight = 0;

function resize() {
    // Solar System Canvas
    if (canvas && canvas.parentElement) {
        const container = canvas.parentElement;
        width = container.clientWidth;
        height = container.clientHeight;
        canvas.width = width;
        canvas.height = height;
    }

    // Stars Canvas (Full Hero Section)
    if (starsCanvas && starsCanvas.parentElement) {
        const heroSection = starsCanvas.parentElement;
        starsWidth = heroSection.clientWidth;
        starsHeight = heroSection.clientHeight;
        starsCanvas.width = starsWidth;
        starsCanvas.height = starsHeight;
    }
}
window.addEventListener('resize', resize);
resize();

// Génération des étoiles
const stars = [];
// Plus d'étoiles vu qu'elles couvrent tout l'écran
for (let i = 0; i < 600; i++) {
    stars.push({
        x: Math.random(),
        y: Math.random(),
        size: Math.random() * 1.5,
        alpha: Math.random(),
        speed: (Math.random() * 0.01) + 0.005
    });
}

let time = 0;

// État de la Lune Quantique
const quantumMoon = {
    state: 'visible', // 'visible', 'glitch_out', 'hidden', 'glitch_in'
    targetIndex: 1, 
    timer: 0,
    orbitAngle: 0
};

function updateQuantumMoon() {
    quantumMoon.timer++;
    if (quantumMoon.state === 'visible' && quantumMoon.timer > 240) {
        quantumMoon.state = 'glitch_out';
        quantumMoon.timer = 0;
    } else if (quantumMoon.state === 'glitch_out' && quantumMoon.timer > 15) {
        quantumMoon.state = 'hidden';
        quantumMoon.timer = 0;
        // Téléportation vers un nouvel astre (0 à 4)
        quantumMoon.targetIndex = Math.floor(Math.random() * 5);
        quantumMoon.orbitAngle = Math.random() * Math.PI * 2;
    } else if (quantumMoon.state === 'hidden' && quantumMoon.timer > 60) {
        quantumMoon.state = 'glitch_in';
        quantumMoon.timer = 0;
    } else if (quantumMoon.state === 'glitch_in' && quantumMoon.timer > 15) {
        quantumMoon.state = 'visible';
        quantumMoon.timer = 0;
    }
}

// Configurations et Updates des planètes
const planets = [
    {
        name: 'Hourglass Twins',
        orbitRadius: 100,
        speed: 0.008,
        update(time, allObjects) {
            const bx = Math.cos(time * this.speed) * this.orbitRadius;
            const by = Math.sin(time * this.speed) * this.orbitRadius;
            
            const innerAngle = time * 0.04;
            const dist = 14;
            
            // Asymétrie : Ember Twin est partiellement remplie, Ash Twin s'est partiellement vidée
            const emberRadius = 6;
            const ashRadius = 4;
            
            const emberX = bx + Math.cos(innerAngle) * dist;
            const emberY = by + Math.sin(innerAngle) * dist;
            const ashX = bx + Math.cos(innerAngle + Math.PI) * dist;
            const ashY = by + Math.sin(innerAngle + Math.PI) * dist;
            
            // Sablière Rouge (Ember Twin)
            allObjects.push({
                x: emberX, y: emberY,
                render(ctx) {
                    ctx.fillStyle = '#b85d19';
                    ctx.beginPath(); ctx.arc(0, 0, emberRadius, 0, Math.PI * 2); ctx.fill();
                    
                    // Canyons profonds (lignes brisées)
                    ctx.strokeStyle = '#4a2105';
                    ctx.lineWidth = 1;
                    ctx.beginPath(); 
                    ctx.moveTo(-3, -2); ctx.lineTo(-1, 1); ctx.lineTo(2, -1); ctx.lineTo(4, 2);
                    ctx.stroke();
                    ctx.beginPath();
                    ctx.moveTo(-4, 2); ctx.lineTo(-2, 4);
                    ctx.stroke();
                }
            });
            
            // Sablière Noire (Ash Twin)
            allObjects.push({
                x: ashX, y: ashY,
                render(ctx) {
                    ctx.fillStyle = '#e8c37b';
                    ctx.beginPath(); ctx.arc(0, 0, ashRadius, 0, Math.PI * 2); ctx.fill();
                }
            });

            // Flux de sable (de Ash Twin vers Ember Twin)
            allObjects.push({
                x: bx, y: by, // Attaché au barycentre pour le tri
                render(ctx) {
                    ctx.strokeStyle = 'rgba(232, 195, 123, 0.6)';
                    ctx.lineWidth = 2.5;
                    
                    // Effet d'écoulement du sable avec lineDash
                    ctx.setLineDash([4, 3]);
                    ctx.lineDashOffset = -time * 0.5; 
                    
                    ctx.beginPath();
                    const startX = Math.cos(innerAngle + Math.PI) * dist;
                    const startY = Math.sin(innerAngle + Math.PI) * dist;
                    const endX = Math.cos(innerAngle) * dist;
                    const endY = Math.sin(innerAngle) * dist;
                    ctx.moveTo(startX, startY);
                    
                    // Point de contrôle pour courber le flux
                    const cpX = Math.cos(innerAngle + Math.PI/2) * 8;
                    const cpY = Math.sin(innerAngle + Math.PI/2) * 8;
                    ctx.quadraticCurveTo(cpX, cpY, endX, endY);
                    ctx.stroke();
                    
                    // Réinitialisation du Line Dash pour ne pas affecter les autres objets
                    ctx.setLineDash([]);
                }
            });
            
            return { x: bx, y: by };
        }
    },
    {
        name: 'Timber Hearth',
        orbitRadius: 170,
        speed: 0.005,
        update(time, allObjects) {
            const px = Math.cos(time * this.speed) * this.orbitRadius;
            const py = Math.sin(time * this.speed) * this.orbitRadius;
            
            allObjects.push({
                x: px, y: py,
                render(ctx) {
                    ctx.fillStyle = '#2f8e40';
                    ctx.shadowBlur = 10; ctx.shadowColor = 'rgba(47, 142, 64, 0.6)';
                    ctx.beginPath(); ctx.arc(0, 0, 11, 0, Math.PI * 2); ctx.fill();
                    ctx.shadowBlur = 0;
                    
                    // Cratères/forêts
                    ctx.fillStyle = '#5c4033';
                    ctx.beginPath(); ctx.arc(-4, -3, 3, 0, Math.PI * 2); ctx.fill();
                    ctx.beginPath(); ctx.arc(3, 4, 2, 0, Math.PI * 2); ctx.fill();
                }
            });
            
            // La Rocaille
            const mx = px + Math.cos(time * 0.03) * 20;
            const my = py + Math.sin(time * 0.03) * 20;
            allObjects.push({
                x: mx, y: my,
                render(ctx) {
                    ctx.fillStyle = '#a0a0a0';
                    ctx.beginPath(); ctx.arc(0, 0, 3, 0, Math.PI * 2); ctx.fill();
                }
            });
            
            return { x: px, y: py };
        }
    },
    {
        name: 'Brittle Hollow',
        orbitRadius: 240,
        speed: 0.0035,
        update(time, allObjects) {
            const px = Math.cos(time * this.speed) * this.orbitRadius;
            const py = Math.sin(time * this.speed) * this.orbitRadius;
            
            allObjects.push({
                x: px, y: py,
                render(ctx) {
                    // Trou noir central
                    ctx.fillStyle = '#000000';
                    ctx.beginPath(); ctx.arc(0, 0, 13, 0, Math.PI * 2); ctx.fill();
                    
                    // Fragments de croûte
                    ctx.fillStyle = '#6b5c92';
                    const numFragments = 6;
                    for (let i = 0; i < numFragments; i++) {
                        const aStart = i * (Math.PI*2 / numFragments) + (time * 0.002);
                        const aEnd = aStart + (Math.PI*2 / numFragments) - 0.2; // -0.2 crée la faille
                        const outerR = 13 + Math.sin(time * 0.02 + i) * 1.5; // Oscillation d'effondrement
                        
                        ctx.beginPath();
                        ctx.arc(0, 0, 7, aStart, aEnd);
                        ctx.arc(0, 0, outerR, aEnd, aStart, true);
                        ctx.closePath();
                        ctx.fill();
                    }
                }
            });
            
            // Lanterne
            const mx = px + Math.cos(time * 0.04) * 24;
            const my = py + Math.sin(time * 0.04) * 24;
            allObjects.push({
                x: mx, y: my,
                render(ctx) {
                    ctx.fillStyle = '#ff3300';
                    ctx.shadowBlur = 10; ctx.shadowColor = '#ff0000';
                    ctx.beginPath(); ctx.arc(0, 0, 4, 0, Math.PI * 2); ctx.fill();
                    ctx.shadowBlur = 0;
                }
            });
            
            return { x: px, y: py };
        }
    },
    {
        name: 'Giant\'s Deep',
        orbitRadius: 330,
        speed: 0.002,
        update(time, allObjects) {
            const px = Math.cos(time * this.speed) * this.orbitRadius;
            const py = Math.sin(time * this.speed) * this.orbitRadius;
            
            allObjects.push({
                x: px, y: py,
                render(ctx) {
                    const gradient = ctx.createRadialGradient(0, 0, 5, 0, 0, 18);
                    gradient.addColorStop(0, '#00ffff');
                    gradient.addColorStop(0.6, '#008b8b');
                    gradient.addColorStop(1, '#002222');
                    
                    ctx.fillStyle = gradient;
                    ctx.shadowBlur = 15; ctx.shadowColor = 'rgba(0, 255, 255, 0.6)';
                    ctx.beginPath(); ctx.arc(0, 0, 18, 0, Math.PI * 2); ctx.fill();
                    ctx.shadowBlur = 0;
                    
                    // Cyclones géants
                    ctx.fillStyle = 'rgba(255, 255, 255, 0.4)';
                    for (let i = 0; i < 4; i++) {
                        const cAngle = time * 0.015 + (i * Math.PI / 2);
                        const cx = Math.cos(cAngle) * 10;
                        const cy = Math.sin(cAngle) * 10;
                        
                        ctx.save();
                        ctx.translate(cx, cy);
                        ctx.rotate(time * -0.05);
                        ctx.beginPath();
                        ctx.arc(0, 0, 4, 0, Math.PI, false);
                        ctx.arc(0, 0, 2, Math.PI, Math.PI*2, false);
                        ctx.fill();
                        ctx.restore();
                    }
                }
            });
            
            return { x: px, y: py };
        }
    },
    {
        name: 'Dark Bramble',
        orbitRadius: 430,
        speed: 0.0012,
        update(time, allObjects) {
            const px = Math.cos(time * this.speed) * this.orbitRadius;
            const py = Math.sin(time * this.speed) * this.orbitRadius;
            
            allObjects.push({
                x: px, y: py,
                render(ctx) {
                    // Noyau blanc brumeux
                    const grad = ctx.createRadialGradient(0,0,2, 0,0,16);
                    grad.addColorStop(0, '#ffffff');
                    grad.addColorStop(0.4, '#dcdcdc');
                    grad.addColorStop(1, 'rgba(220,220,220,0)');
                    ctx.fillStyle = grad;
                    ctx.beginPath(); ctx.arc(0, 0, 16, 0, Math.PI * 2); ctx.fill();
                    
                    // Lianes
                    ctx.strokeStyle = '#4a3d30';
                    ctx.lineWidth = 2.5;
                    ctx.lineCap = 'round';
                    for (let i = 0; i < 6; i++) {
                        ctx.save();
                        ctx.rotate((i * Math.PI / 3) + (time * 0.003));
                        ctx.beginPath();
                        ctx.moveTo(8, 0);
                        // Courbes de bezier pour des lianes organiques
                        ctx.bezierCurveTo(15, 12, 22, -8, 28, 4);
                        ctx.stroke();
                        // Petites ramifications
                        ctx.lineWidth = 1;
                        ctx.beginPath(); ctx.moveTo(16, 2); ctx.bezierCurveTo(18, 8, 22, 10, 20, 12); ctx.stroke();
                        ctx.restore();
                    }
                }
            });
            
            return { x: px, y: py };
        }
    }
];

function drawSystem() {
    if (width === 0 || starsWidth === 0) resize();

    // Nettoyage transparent pour fusionner avec le fond du site
    ctx.clearRect(0, 0, width, height);
    if (starsCtx) {
        starsCtx.clearRect(0, 0, starsWidth, starsHeight);
    }
    
    // Rendu du grand champ d'étoiles (sur le canvas pleine page)
    stars.forEach(star => {
        star.alpha += star.speed;
        if (star.alpha > 1 || star.alpha < 0) star.speed *= -1;
        
        const finalAlpha = Math.abs(star.alpha);
        if (finalAlpha > 0.01 && starsCtx) {
            starsCtx.fillStyle = `rgba(255, 255, 255, ${finalAlpha})`;
            starsCtx.beginPath(); 
            starsCtx.arc(star.x * starsWidth, star.y * starsHeight, star.size, 0, Math.PI * 2); 
            starsCtx.fill();
        }
    });

    // Échelle logique réduite pour éviter le rendu "trop dézoomé". 
    // La comète sera peut-être légèrement rognée sur les très petits écrans, mais les planètes seront plus grandes et lisibles.
    const logicalWidth = 1000; 
    const baseScale = width < logicalWidth ? width / logicalWidth : 1;

    ctx.save();
    ctx.translate(width / 2, height / 2);
    ctx.scale(baseScale, baseScale * 0.45);
    
    // Tracé des orbites planétaires
    ctx.lineWidth = 1;
    planets.forEach(p => {
        ctx.strokeStyle = 'rgba(255, 255, 255, 0.05)';
        ctx.beginPath(); ctx.arc(0, 0, p.orbitRadius, 0, Math.PI * 2); ctx.stroke();
    });

    // Orbite de l'Intrus
    const cometA = 550;
    const cometB = 200;
    const cometFocusOffset = -300;
    const cometRotation = Math.PI / 6;
    
    ctx.save();
    ctx.rotate(cometRotation);
    ctx.strokeStyle = 'rgba(200, 255, 255, 0.03)';
    ctx.beginPath(); ctx.ellipse(cometFocusOffset, 0, cometA, cometB, 0, 0, Math.PI * 2); ctx.stroke();
    ctx.restore();

    // Collecte de tous les objets pour le tri Z-Index
    let allObjects = [];

    // Soleil
    allObjects.push({
        x: 0, y: 0,
        render(ctx) {
            ctx.fillStyle = '#ffdf00';
            ctx.shadowBlur = 40; ctx.shadowColor = '#ff8c00';
            ctx.beginPath(); ctx.arc(0, 0, 35, 0, Math.PI * 2); ctx.fill();
            ctx.shadowBlur = 0;
        }
    });

    // Station Solaire
    const sX = Math.cos(time * 0.02) * 50;
    const sY = Math.sin(time * 0.02) * 50;
    allObjects.push({
        x: sX, y: sY,
        render(ctx) {
            ctx.fillStyle = '#ffd700';
            ctx.beginPath(); ctx.rect(-3, -5, 6, 10); ctx.fill();
        }
    });

    // Planètes et Lunes classiques
    const planetPositions = [];
    planets.forEach(p => {
        planetPositions.push(p.update(time, allObjects));
    });

    // Comète (Intrus)
    const cometAngle = time * 0.003;
    let cx = cometFocusOffset + Math.cos(cometAngle) * cometA;
    let cy = Math.sin(cometAngle) * cometB;
    const finalCx = cx * Math.cos(cometRotation) - cy * Math.sin(cometRotation);
    const finalCy = cx * Math.sin(cometRotation) + cy * Math.cos(cometRotation);

    allObjects.push({
        x: finalCx, y: finalCy,
        render(ctx) {
            const dist = Math.sqrt(finalCx*finalCx + finalCy*finalCy);
            const tailX = (finalCx / dist) * 50; 
            const tailY = (finalCy / dist) * 50;
            
            ctx.strokeStyle = 'rgba(200, 255, 255, 0.6)';
            ctx.lineWidth = 2;
            ctx.beginPath(); ctx.moveTo(0, 0); ctx.lineTo(tailX, tailY); ctx.stroke();
            
            ctx.fillStyle = '#ffffff';
            ctx.shadowBlur = 10; ctx.shadowColor = '#00ffff';
            ctx.beginPath(); ctx.arc(0, 0, 4, 0, Math.PI * 2); ctx.fill();
            ctx.shadowBlur = 0;
        }
    });

    // Lune Quantique
    if (quantumMoon.state !== 'hidden') {
        const targetPos = planetPositions[quantumMoon.targetIndex];
        quantumMoon.orbitAngle += 0.015;
        let qDist = (quantumMoon.targetIndex === 0) ? 32 : ((quantumMoon.targetIndex === 3) ? 36 : 24);
        
        const qx = targetPos.x + Math.cos(quantumMoon.orbitAngle) * qDist;
        const qy = targetPos.y + Math.sin(quantumMoon.orbitAngle) * qDist;
        
        allObjects.push({
            x: qx, y: qy,
            render(ctx) {
                if (quantumMoon.state === 'visible') {
                    ctx.fillStyle = '#dcdcdc';
                    ctx.shadowBlur = 15; ctx.shadowColor = 'rgba(200, 200, 220, 0.7)';
                    ctx.beginPath(); ctx.arc(0, 0, 5.5, 0, Math.PI * 2); ctx.fill();
                    ctx.shadowBlur = 0;
                } else {
                    // Effet de glitch statique
                    ctx.fillStyle = 'rgba(220, 220, 220, 0.8)';
                    const offset1 = (Math.random() - 0.5) * 6;
                    const offset2 = (Math.random() - 0.5) * 6;
                    ctx.beginPath(); ctx.arc(offset1, 0, 5.5, 0, Math.PI); ctx.fill();
                    
                    ctx.fillStyle = 'rgba(150, 150, 150, 0.8)';
                    ctx.beginPath(); ctx.arc(offset2, 0, 5.5, Math.PI, Math.PI * 2); ctx.fill();
                    
                    // Lignes statiques (static noise)
                    ctx.strokeStyle = 'rgba(255, 255, 255, 0.9)';
                    ctx.lineWidth = 1;
                    ctx.beginPath();
                    ctx.moveTo(-8, (Math.random()-0.5)*8);
                    ctx.lineTo(8, (Math.random()-0.5)*8);
                    ctx.stroke();
                }
            }
        });
    }

    // Tri Z-Index Global (de l'arrière vers l'avant selon Y)
    allObjects.sort((a, b) => a.y - b.y);

    // Rendu
    allObjects.forEach(obj => {
        ctx.save();
        ctx.translate(obj.x, obj.y);
        ctx.scale(1, 1/0.45); // Annule l'aplatissement sur les objets eux-mêmes
        obj.render(ctx);
        ctx.restore();
    });

    ctx.restore();
}

function animate() {
    time += 1;
    updateQuantumMoon();
    drawSystem();
    requestAnimationFrame(animate);
}

setTimeout(() => {
    resize();
    animate();
}, 100);
