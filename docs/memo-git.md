# Mémo Git — PR & Gestion des conflits

## Workflow standard par feature

```bash
# 1. Toujours partir de develop à jour
git checkout develop
git fetch origin
git pull origin develop

# 2. Créer une branche dédiée
git checkout -b feat/nom-de-la-feature

# Renommer la branche locale
git branch -m ancien-nom nouveau-nom

# 3. Travailler, commiter en liant l'issue
git add .
git commit -m "feat(scope): description courte #NUMERO_ISSUE"

# 4. Pusher la branche
git push origin feat/nom-de-la-feature

# 5. Créer la PR sur GitHub
# → Base : develop
# → Compare : feat/nom-de-la-feature
# → Description : Closes #NUMERO_ISSUE
```

---

## Convention de nommage des branches

| Type | Format | Exemple |
|---|---|---|
| Feature | `feat/nom-feature` | `feat/product-detail-page` |
| Fix | `fix/nom-fix` | `fix/cart-add-bug` |
| Refacto | `refactor/nom` | `refactor/archi-refacto` |
| Style | `style/nom` | `style/cards-responsive` |

---

## Convention des messages de commit

```
type(scope): description courte #NUMERO_ISSUE

# Types : feat, fix, refactor, style, chore, merge
# Scope : composant ou module concerné

# Exemples :
feat(product): detail page route & header cart badge #20
fix(cart): correct addToCart condition #35
refactor(archi): migrate pipes and models to shared #9
merge(develop): resolve conflicts - routes & products component #20
```

---

## Résoudre des conflits en local

```bash
# 1. Se placer sur sa branche feature
git checkout ma-branche

# 2. Récupérer le dernier état du remote
git fetch origin

# 3. Merger develop dans sa branche
git merge origin/develop

# 4. Git indique les fichiers en conflit
# Ouvrir chaque fichier et résoudre manuellement
# (supprimer les marqueurs <<<<<<, =======, >>>>>>>)

# 5. Supprimer les fichiers inutiles (rename/delete conflicts)
git rm chemin/du/fichier.ts

# 6. Ajouter les fichiers résolus
git add .

# 7. Commiter le merge
git commit -m "merge(develop): resolve conflicts - description #ISSUE"

# 8. Pusher
git push origin ma-branche
```

---

## Cas spéciaux

### Historique divergent après --force
```bash
# Si le push est rejeté (non-fast-forward)
git push origin ma-branche --force-with-lease
# ⚠️ Utiliser uniquement sur SA propre branche, jamais sur develop ou main
```

### Récupérer des fichiers depuis une autre branche
```bash
# Cherry-pick d'un commit spécifique
git cherry-pick HASH_COMMIT

# Récupérer uniquement certains fichiers d'une branche
git checkout nom-branche -- src/app/chemin/du/dossier/
```

### Créer une branche propre depuis develop (reset propre)
```bash
git checkout origin/develop
git checkout -b feat/nouvelle-branche-propre

# Récupérer uniquement les fichiers voulus
git checkout ancienne-branche -- src/app/chemin/
git add .
git commit -m "feat(scope): description #ISSUE"
git push origin feat/nouvelle-branche-propre
```

---

## Commandes utiles de diagnostic

```bash
# Voir l'historique d'une branche
git log nom-branche --oneline

# Voir ce que develop a que ma branche n'a pas
git log ma-branche..origin/develop --oneline

# Voir ce que ma branche a que develop n'a pas
git log origin/develop..ma-branche --oneline

# Lister les fichiers d'une branche
git ls-tree -r nom-branche --name-only

# Voir les fichiers modifiés dans un commit
git show HASH --stat

# État actuel du dépôt
git status
```

---

## Workflow résumé en image

```
main
 │
 └── develop  ← branche d'intégration
      │
      ├── feat/feature-1  → PR → develop
      ├── feat/feature-2  → PR → develop
      └── feat/feature-3  → PR → develop
                                    │
                                    └── PR → main (release)
```

---

## Tips PowerShell (Windows)

```powershell
# grep n'existe pas sur PowerShell → utiliser Select-String
git show nom-branche --stat | Select-String "mot-clé"

# Lister les fichiers d'un dossier
dir src\app\features\
```
