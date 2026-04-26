# Mémo Git — Workflow Feature Branch

## Vue d'ensemble

```
develop ──────────────────────────────────────── develop
    │                                                 ▲
    └── feat/ma-feature ── commits ── PR ────────────┘
```

---

## 1. Créer une branche liée à une US

```bash
# Toujours partir d'un develop à jour
git checkout develop
git pull origin develop

# Créer la branche (convention : feat/nom-feature)
git checkout -b feat/nom-de-la-feature

# Types de préfixes
# feat/     → nouvelle fonctionnalité
# fix/      → correction de bug
# refactor/ → refactorisation
# style/    → CSS / mise en forme
# docs/     → documentation
# chore/    → config, dépendances
```

> 💡 Le lien avec l'US se fait dans le message de commit (pas dans le nom de branche)

---

## 2. Commit & Push avec convention

```bash
# Ajouter les fichiers
git add .

# Commiter en liant l'issue GitHub avec #NUMERO
git commit -m "feat(scope): description courte #NUMERO_ISSUE"

# Pusher la branche
git push origin feat/nom-de-la-feature

# Exemples de commits
feat(product): add detail page route #20
fix(cart): correct addToCart null check #35
refactor(archi): migrate pipes to shared/pipes #9
style(products): responsive card layout #17
docs(git): add workflow memo
chore(config): add provideHttpClient to app.config #9
```

---

## 3. Merger develop dans sa branche

> À faire régulièrement pour rester à jour avec develop

```bash
# Récupérer le dernier état du remote
git fetch origin

# Merger develop dans sa branche courante
git merge origin/develop

# En cas de conflits :
# → Ouvrir les fichiers en conflit
# → Supprimer les marqueurs <<<<<<, =======, >>>>>>>
# → Garder le bon code

# Supprimer les fichiers spec renommés/supprimés si besoin
git rm chemin/du/fichier.spec.ts

# Finaliser le merge
git add .
git commit -m "merge(develop): resolve conflicts - description"
git push origin feat/nom-de-la-feature

# Si push rejeté (historique divergent)
git push origin feat/nom-de-la-feature --force-with-lease
# ⚠️ Uniquement sur SA propre branche, jamais sur develop ou main
```

---

## 4. Mettre à disposition sur develop (PR)

```bash
# S'assurer que tout est pushé
git push origin feat/nom-de-la-feature
```

**Sur GitHub :**
1. Aller sur le repo → onglet **Pull requests**
2. Cliquer **New pull request**
3. Configurer :
   - **Base** : `develop`
   - **Compare** : `feat/nom-de-la-feature`
   - **Titre** : `feat(scope): description courte`
   - **Description** : `Closes #NUMERO_ISSUE`
4. Cliquer **Create pull request**
5. Vérifier qu'il n'y a pas de conflits
6. Cliquer **Merge pull request** → **Confirm merge**

> 💡 `Closes #XX` ferme automatiquement l'issue GitHub au moment du merge

---

## 5. Contrôle & suppression des branches

```bash
# Voir toutes les branches (local + remote)
git branch -a

# Vérifier qu'une branche est bien mergée dans develop
git log origin/develop..nom-branche --oneline
# → Si rien ne s'affiche = déjà mergée ✅

# Supprimer en LOCAL
git branch -d feat/nom-de-la-feature      # sûr (vérifie si mergée)
git branch -D feat/nom-de-la-feature      # force (même si non mergée)

# Supprimer sur le REMOTE
git push origin --delete feat/nom-de-la-feature

# Nettoyer les références remote obsolètes en local
git fetch --prune
```

---

## Récap commandes rapides

| Action | Commande |
|---|---|
| Mettre develop à jour | `git pull origin develop` |
| Créer une branche | `git checkout -b feat/nom` |
| Voir l'état | `git status` |
| Ajouter tout | `git add .` |
| Commiter | `git commit -m "feat(scope): desc #XX"` |
| Pusher | `git push origin feat/nom` |
| Merger develop | `git merge origin/develop` |
| Voir l'historique | `git log --oneline` |
| Supprimer local | `git branch -d feat/nom` |
| Supprimer remote | `git push origin --delete feat/nom` |

---

## Tips PowerShell (Windows)

```powershell
# grep → Select-String
git log --oneline | Select-String "feat"

# Lister les fichiers d'une branche
git ls-tree -r nom-branche --name-only

# Lister les fichiers d'une branche filtrés
git ls-tree -r nom-branche --name-only | Select-String "cart"
```
