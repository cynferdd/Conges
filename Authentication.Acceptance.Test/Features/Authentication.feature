Feature: Authentication
	In order to check if the authentication is correctly made
	we must assert if the token validation is well done

@Authentication
Scenario: Correct Authentication
	Given the token has an expiration date set to 17/10/2020
	And today's date is 17/09/2020
	When we check the authentication
	Then we receive an Ok http code