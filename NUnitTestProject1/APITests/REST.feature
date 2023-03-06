Feature: REST

Background: 
	Given I intend to access the API located at "https://petstore.swagger.io/v2"

@Positive @APITest
Scenario: Get the details of a user
	When I have inserted a user "Behemoth"
	Then I get the info for user "Behemoth"
	And I delete the information for that user "Behemoth"
