Feature: HooksExample

[BeforeTestRun / AfterTestRun] 

@AuthenticateAsAlex
Scenario: Example hooks
	Given I want to show the hooks
	When I execute the scenario
	Then Everyone will see the hook

	
@Authenticate
Scenario: Example hooks2
	Given I want to show the hooks
	When I execute the scenario
	Then Everyone will see the hook