Feature: Checkout
	As a young man
	I want to get my favorit traveling
	So that I can pay for it and get ticket

@Checkout
Scenario: buy ticket successfully
	Given There is a favorit traveling
	| from | to | price |
	| a    | b  | 200   |
	When user books and pays $"200"
	| firstname | lastname | amount |
	| Arthur   | Chang     | 200    |
	Then display "order ticket successfully"
