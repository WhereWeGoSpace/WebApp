Feature: Checkout
	As a young man
	I want to get my favorit traveling
	So that I can pay for it and get ticket

@Checkout
Scenario: buy ticket successfully
	Given There is a favorit traveling
	| from_code | to_code | 
	| ST_EZVVG1X5    | ST_D8NNN9ZK  |
	When user books
	And user pays
	Then booking is ok
