#language: fr-FR
Fonctionnalité: Create
  On doit pouvoir créer un compte de type "leave" ou "no leave", 
  tant qu'il n'existe pas déjà un autre compte avec le même Id ou le même nom
@CreationCompte
Scénario: Creation de compte déjà existant (id)
  Etant donné un compte que l on souhaite créer avec un id 1
  Et un autre compte déjà existant avec un id 1
  Quand on veut créer le compte
  Alors on recoit un code Http BadRequest

Scénario: Création de compte déjà existant (nom)
	Etant donné un compte que l on souhaite créer avec pour nom 'congé'
	Et un autre compte déjà existant avec pour nom 'congé'
	Quand on veut créer le compte
	Alors on recoit un code Http BadRequest

Scénario: Création de compte NoLeave non existant
	Etant donné un compte NoLeave non existant
	Quand on veut créer le compte
	Alors il est bien enregistré
	Et on recoit un code Http Ok pour la creation

Scénario: Création de compte Leave non existant
	Etant donné un compte Leave non existant
	Quand on veut créer le compte
	Alors il est bien enregistré
	Et on recoit un code Http Ok pour la creation