#language: fr-FR
Fonctionnalité: Authentification
  Quand un compte n'est plus désiré, on doit pouvoir l'archiver
@ArchivageCompte
Scénario: Archivage de compte inexistant
  Etant donné un compte qui n'existe pas
  Quand on l'archive
  Alors on recoit un code Http NotFound

Scénario: Archivage de compte déjà archivé
	Etant donné un compte qui existe
	Et ce compte est déjà archivé
	Quand on l'archive
	Alors on recoit un code Http Ok
	Et Le compte est archivé
	Et la date d'archivage reste la même

Scénario: Archivage de compte non archivé
	Etant donné un compte qui existe
	Et ce compte n'est pas archivé
	Quand on l'archive
	Alors on recoit un code Http Ok
	Et le compte est archivé
	Et la date d'archivage est la date du jour et l'heure actuelle