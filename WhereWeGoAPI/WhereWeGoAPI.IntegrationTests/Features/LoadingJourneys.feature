Feature: LoadingJourneys
	As a young man
	I want computer advice to travel
	So that They can see the result

@LoadingJourneys
Scenario: show random result successfully
	Given There are a hot traveling result
	| from      | from_code | to      | to_code |
	| Berlin    |      ST_E0203JK4     | Munchen | ST_EMYR64OX        |
	| Frankfurt |   ST_LYKXO1K1        | Paris   |    ST_DQM28J3P     |
	When user click bar
	Then show one random result