Feature: IssueTicket
	As a young man
	When I pay for a ticket
	So that I can get the ticket

@IssueTicket
Scenario: get ticket successfully
	Given I have paid for favorit traveling
	When I download
	Then I get a PDF of ticket

@IssueTicket
Scenario Outline:  ticket is expired
	Given I have paid for favorit traveling
	And paid time is "<paidTime>" 
	When I download on "<downloadTime>"
	Then display error message "time out"
	Examples: 
	| paidTime   | downloadTime |
	| 2017-09-10 | 2017-09-30   |




