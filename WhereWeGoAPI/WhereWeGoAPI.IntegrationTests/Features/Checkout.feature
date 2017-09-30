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
	And user fill up the credit card info
	| number       | exp_month | exp_year | cvv |
	| 221233223333 | 12        | 2017     | 182 |
	Then booking is ok
