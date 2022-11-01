Feature: UserBadPath

@Authorize

Scenario: Get users bad path
	Given I have users to get from wrong url
	When I get all the users from bad path user endpoint
	Then The bad path status code should be NotFound

