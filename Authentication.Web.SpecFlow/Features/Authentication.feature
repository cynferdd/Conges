Fonctionnalité: Authentication
	Dans le but de pouvoir s'assurer que l'authentification se passe bien
	il nous faut tester les cas d'authentification réussie et échouée

@Authentication
Scénario: Authentification simple réussie
	Etant donné que le login est renseigné
	Et que le mot de passe est renseigné
	Quand l'authentification est réussie
	Alors le code retour doit être 200