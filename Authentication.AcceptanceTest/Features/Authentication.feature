Fonctionnalité: Authentication
	Dans le but de s'assurer que l'authentification
	(élément central s'il en est, de surcroit primordial)
	fonctionne correctement, il est critique de s'assurer
	que l'on ait bien les codes http correctement retournés
	si jamais on s'authentifie correctement (ou pas)
@Authentication
Scénario: Authentification correcte
	Etant donné que l'on a un token avec une date d'expiration au 17/10/2020
	Et que la date du jour est le 17/09/2020
	Quand on vérifie l'authentification
	Alors on recoit un code Http Ok
