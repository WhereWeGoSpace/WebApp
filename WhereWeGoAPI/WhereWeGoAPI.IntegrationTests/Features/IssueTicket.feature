Feature: IssueTicket
	As a young man
	When I pay for a ticket
	So that I can get the ticket

@IssueTicket
Scenario: get ticket successfully
	Given I have paid for favorit traveling
	When I download
	Then I get a PDF of ticket




