Feature: User


Scenario: Get users
	Given I have users to get
	When I get all the users from the users endpoint
	Then The status code should be OK


@CreateUser
Scenario Outline: Create a user
	Given I have the following user to add <valid>
	When I send post request to the users endpoint
	Then The status code should be <statusCode>
	And the user should be created successfully
Examples:
	| statusCode          | valid |
	| Created             | true  |
	| UnprocessableEntity | false |

@CreateUser
Scenario: Update a user
	Given I have already created a user
	When I send put request to the users endpoint
	Then The status code should be OK

