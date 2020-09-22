#language: fr-FR
Fonctionnalité: Authentification
	Dans le but de s'assurer que l'authentification
	(élément central s'il en est, de surcroit primordial)
	fonctionne correctement, il est critique de s'assurer
	que l'on ait bien les codes http correctement retournés
	si jamais on s'authentifie correctement (ou pas)
@Authentification
Scénario: Authentification correcte
	Etant donné un token avec une date d'expiration au 17/10/2020
	Et la date du jour est le 17/09/2020
	Quand on vérifie l'authentification
	Alors on recoit un code Http Ok

Scénario: Authentification incorrecte
	Etant donné un token avec une date d'expiration au 17/09/2020
	Et la date du jour est le 17/10/2020
	Quand on vérifie l'authentification
	Alors on recoit un code Http Non Autorisé