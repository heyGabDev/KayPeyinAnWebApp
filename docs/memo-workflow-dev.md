# Mémo Workflow Développement — KayPeyinAnWebApp

## Vue d'ensemble

```
Sprint Planning → Démarrage → Développement → Livraison → Review → Done
```

---

## 1. Démarrage d'une US

```bash
# 1. Mettre develop à jour
git checkout develop
git pull origin develop

# 2. Créer la branche (convention feat/nom-feature)
git checkout -b feat/nom-feature

# 3. Lancer Toggl
# → Projet : KayPeyinAnWebApp
# → Nom du timer : "#NUMERO - Titre de l'US"
# → Tag : front / back / fullstack
```

**Sur GitHub :**
- Passer l'issue → `In Progress` dans le Project board

---

## 2. Pendant le développement

### Commits
```bash
# Convention de commit
git commit -m "type(scope): description courte #NUMERO_ISSUE"

# Types
feat      → nouvelle fonctionnalité
fix       → correction de bug
refactor  → refactorisation
style     → CSS / mise en forme
docs      → documentation
chore     → config, dépendances
merge     → résolution de conflits

# Exemples
feat(product): add detail page route #20
fix(cart): correct addToCart null check #35
style(home): apply Montserrat font globally #17
```

### Bonnes pratiques
- Commiter **régulièrement** — pas tout en un seul commit
- Un commit = **une modification logique**
- Lancer `ng lint` avant chaque commit
- Rester à jour avec develop régulièrement :

```bash
git fetch origin
git merge origin/develop
```

### Toggl
- **Pause** → Stop Toggl
- **Reprise** → Relance Toggl sur la même entrée
- Changer d'US → Stop + nouvelle entrée Toggl

---

## 3. Livraison (PR)

### Avant de créer la PR
```bash
# 1. Lint — zéro erreur obligatoire
ng lint

# 2. Build — vérifier que ça compile
ng build

# 3. Merge develop pour être à jour
git fetch origin
git merge origin/develop

# 4. Résoudre les conflits si nécessaire
git add .
git commit -m "merge(develop): resolve conflicts #NUMERO"
git push origin feat/nom-feature

# Si push rejeté (historique divergent)
git push origin feat/nom-feature --force-with-lease
# ⚠️ Uniquement sur SA propre branche
```

### Créer la PR sur GitHub
1. **Base** : `develop`
2. **Compare** : `feat/nom-feature`
3. **Titre** : `feat(scope): description courte`
4. **Description** : `Closes #NUMERO_ISSUE`
5. Vérifier **0 conflits** avant de merger

### Si conflits sur GitHub
```bash
# Recréer une branche propre
git checkout origin/develop
git checkout -b feat/nom-feature-clean

# Récupérer uniquement les fichiers voulus
git checkout feat/nom-feature -- src/app/chemin/

# Commiter et pusher
git add .
git commit -m "feat(scope): description #NUMERO"
git push origin feat/nom-feature-clean
```

### Après le merge
```bash
# Supprimer les branches
git branch -d feat/nom-feature
git push origin --delete feat/nom-feature
```

---

## 4. Review

### ESLint (analyse statique)
```bash
ng lint
# → 0 erreur avant tout merge
# → Lancer avant chaque commit idéalement
```

### Code review (checklist)
| Critère | Vérification |
|---|---|
| 🟢 Convention de nommage | Fichiers en `*.component.ts`, services en `*.service.ts` |
| 🟢 `inject()` | Pas de constructeur pour injection |
| 🟢 Typage | Pas de `any` |
| 🟢 Imports | Pas d'imports inutilisés |
| 🟢 Console.log | Supprimés avant merge |
| 🟢 Commentaires | TODO bien identifiés |
| 🟢 Responsive | Testé mobile / tablette / desktop |

### Sur GitHub
- Passer l'issue → `Done` dans le Project board
- Noter le temps Toggl en commentaire sur l'issue
- Fermer l'issue si pas de `Closes #XX` dans la PR

---

## 5. Fin de sprint

### Toggl
- Exporter le rapport du sprint
- Comparer **temps réel vs points estimés**
- Calculer la **vélocité** : nombre de points livrés

### GitHub
- Vérifier que toutes les issues sont à jour
- Nettoyer les branches mergées
- Préparer les issues du sprint suivant

### Sprint Planning (vendredi)
- Vélocité du sprint écoulé
- Sélection des US pour le prochain sprint
- Ré-estimation si nécessaire (en fonction du temps réel Toggl)

---

## 6. Commandes utiles

```bash
# ─── Git ──────────────────────────────────────────────
git status                          # État du dépôt
git log --oneline                   # Historique commits
git branch -a                       # Toutes les branches
git fetch --prune                   # Nettoyer refs obsolètes

# Vérifier si branche mergée dans develop
git log origin/develop..ma-branche --oneline
# → Vide = déjà mergée ✅

# Lister fichiers d'une branche
git ls-tree -r nom-branche --name-only

# ─── Angular ──────────────────────────────────────────
ng serve                            # Lancer le serveur dev
ng build                            # Build production
ng lint                             # Analyse statique
ng g c chemin/nom --type=component  # Générer un composant
ng g s chemin/nom                   # Générer un service

# ─── PowerShell (Windows) ─────────────────────────────
# grep → Select-String
git log --oneline | Select-String "feat"
```

---

## 7. Conventions de nommage

| Type | Convention | Exemple |
|---|---|---|
| Branche feature | `feat/nom` | `feat/home-page` |
| Branche fix | `fix/nom` | `fix/cart-badge` |
| Composant | `nom.component.ts` | `header.component.ts` |
| Service | `nom.service.ts` | `cart.service.ts` |
| Pipe | `nom.pipe.ts` | `category.pipe.ts` |
| Modèle | `nom.model.ts` | `product.model.ts` |
| Guard | `nom.guard.ts` | `auth.guard.ts` |

---

## 8. Architecture du projet

```
src/app/
├── core/
│   ├── cart/           → types et utils du panier
│   ├── guards/         → guards Angular (auth, admin)
│   ├── interceptors/   → intercepteurs HTTP
│   └── services/       → services singleton
│       ├── cart/
│       ├── notification/
│       └── product/
├── features/           → un dossier par feature métier
│   ├── basket/
│   ├── home/
│   ├── product/
│   └── products/
├── models/             → interfaces et classes métier
└── shared/             → réutilisable partout
    ├── components/     → composants génériques
    │   ├── confirm.dialog/
    │   ├── footer/
    │   └── header/
    └── pipes/          → pipes partagés
```
