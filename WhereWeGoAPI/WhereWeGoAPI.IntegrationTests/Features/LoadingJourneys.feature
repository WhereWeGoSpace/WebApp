Feature: LoadingJourneys
	As a young man
	I want computer advice to travel
	So that They can see the result

@LoadingJourneys
Scenario: show random result successfully
	Given There are a hot traveling result
	| from      | to      |
	| Berlin    | Munchen |
	| Frankfurt | Paris   |
	When user click bar
	Then show one random result