#language: fr-FR
Fonctionnalité: Authentification.login
	Dans le cas où on n'est pas encore authentifié,
	Si on saisit un login existant avec le bon mot de passe correspondant,
	Alors on reçoit un token valide
@Authentification.login
Scénario: Authentification correcte
	Etant donné un login existant
	Et un mot de passe valide correspondant
	Quand on se connecte
	Alors on recoit un token d'authentification valide
	Et le nombre de connexion est à 0
	Et l'utilisateur a été sauvegardé


Scénario: Authentification incorrecte car login inexistant
	Etant donné un login inexistant
	Et un mot de passe aléatoire
	Quand on se connecte
	Alors on reçoit un NotFound

Scénario: Authentification incorrecte car mot de passe invalide
	Etant donné un login existant
	Et un mot de passe erroné
	Quand on se connecte
	Alors on reçoit un BadRequest Mot de passe erroné
	Et l'utilisateur a été sauvegardé
	Et le nombre de connexion est à 1

Scénario: Compte bloqué au bout de 3 mauvaises authentifications
	Etant donné un login existant
	Et un mot de passe erroné
	Quand on se connecte 3 fois
	Alors on reçoit un BadRequest Mot de passe erroné
	Et le compte est bloqué
	Et l'utilisateur a été sauvegardé
	Et le nombre de connexion est à 3

Scénario: Authentification incorrecte car le login est vide
	Etant donné un login vide
	Et un mot de passe aléatoire
	Quand on se connecte
	Alors on reçoit un BadRequest login obligatoire

Scénario: Authentification incorrecte car le mot de passe est vide
	Etant donné un login existant
	Et un mot de passe vide
	Quand on se connecte
	Alors on reçoit un BadRequest mot de passe obligatoire

Scénario: Authentification incorrecte car compte bloqué
	Etant donné un login existant
	Et un mot de passe valide correspondant
	Mais le compte est bloqué
	Quand on se connecte
	Alors on reçoit un BadRequest compte est bloqué

Scénario: Authentification incorrecte car compte bloqué avec mot de passe erroné
	Etant donné un login existant
	Et un mot de passe erroné
	Mais le compte est bloqué
	Quand on se connecte
	Alors on reçoit un BadRequest compte est bloqué