Feature: Swag Labs Store UI Testing

Background: 
	Given I navigate to the Sauce Demo page

@Positive @UITest
Scenario Outline: Login with valid user credentials
	When I enter the username "<username>" and password "secret_sauce" and hit the login button
	Then I should be logged successfully on the virtual store
	Examples:
	| username                |
	| standard_user           |
	| problem_user            |
	| performance_glitch_user |

@Negative @UITest
Scenario: User with locked account cannot log in
	When I enter the username "locked_out_user" and password "secret_sauce" and hit the login button
	Then I see the error message "Sorry, this user has been locked out"

@Positive @UITest
Scenario: Buy Sauce Labs Bolt T-shirt
	When I enter the username "standard_user" and password "secret_sauce" and hit the login button
	Then I should be logged successfully on the virtual store
	And I assert the price for the Sauce Labs Bolt T-shirt is "$15.99"
	When I add the Sauce Labs Bolt T-shirt to the basket
	And I go to checkout and enter the user details
	And I assert the total price is "$17.27"
	Then I finish the order and verify the message "Thank you for your order!"