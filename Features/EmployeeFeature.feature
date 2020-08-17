Feature: EmployeeFeature

Scenario: Register an Employee in the Portal
	Given I have log-in
	And I'm in the "Employees" page
	When I click the create button
	Then I should be able to see the Employee in the portal list