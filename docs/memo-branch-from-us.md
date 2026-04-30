# Mémo — Créer une branche depuis une US

## Les 2 étapes

```bash
# 1. Mettre develop à jour
git checkout develop
git pull origin develop

# 2. Créer la branche
git checkout -b feat/nom-feature
```
---

## Convention de nommage

| US | Issue | Branche |
|---|---|---|
| NotificationService | #45 | `feat/notification-service` |
| Page d'accueil | #17 | `feat/home-page` |
| Démarrer back .NET | #10 | `feat/back-dotnet-setup` |
| API REST produits | #11 | `feat/api-products` |

---

## Le lien avec l'US → dans le premier commit

```bash
git commit -m "feat(scope): description #NUMERO_ISSUE"

# Exemples
feat(notification): add notification service #45
feat(home): create home page layout #17
feat(back): setup dotnet core 8 project #10
feat(api): create products REST API #11
```

> ⚠️ Le `#NUMERO_ISSUE` dans le commit crée le lien automatique sur GitHub
