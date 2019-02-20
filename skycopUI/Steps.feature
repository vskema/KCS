Feature: SkycopSteps

Scenario: Open Skycop claims page	
	Given I navigate to claims
	Then I set Kaunas as departure airport
	Then I set London as destination airport
	Then I go to select direct or not flight
	Then I select connecting airport
	Then I select which flight was with issues
	Then I enter airlines name
	Then I enter flight number
	Then I enter flight date
	Then I choose problem
	Then I enter time delayed
	Then I choose the reason for delay