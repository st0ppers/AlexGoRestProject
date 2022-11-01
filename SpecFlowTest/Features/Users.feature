Feature: Users
#
#Scenario: Get all users
#	Given I want to prepaer a request
#	When I get all users from the users endpoint
#	Then The response status code should be OK
#	And the response should contain a list of users

@AuthenticateAsAlex
Scenario: Create a new user
	Given I have the following user date
		| Name      | Gender | Email          | Status |
		| ImeNaAlex | male   | asd3dfgsf5f12@brakus.co | active |
	When I send a request to the users endpoint
	Then The response status code should be Created
	And the user should be created successfully

@AuthenticateAsIco
Scenario: Create a new user as Ico
	Given I have the following user date for Ico
		| Name     | Gender | Email           | Status |
		| ImeNaIco | male   | aersdffgg53e12@brakus.co | active |
	When I send a request to the users endpoint as Ico
	Then The response status code should be Created
	And the user should be created successfully as Ico

#Scenario: Update an existing user
#	Given I have a created user already
#		| Id   | Name     | Gender | Email                   | Status |
#		| 5433 | testName | male   | novotoimenqma@brakus.co | active |
#	When I send an update request to the users endpoint
#	Then The response status code should be OK
#
###
#Scenario: Delete an existin user
#	Given I have a created user already
#		| Id   | Name     | Gender | Email                   | Status |
#		| 5433 | testName | male   | novotoimenqma@brakus.co | active |
#	When I send a delete request to the users endpoint
#	Then The response status code should be NoContent