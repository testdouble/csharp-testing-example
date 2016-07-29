Feature: Todo Lists

	Background:
		Given I am on the todo page

	Scenario: Creating a todo
		When I type the todo "Do Things!"
		Then todo list item 1 has text "Do Things!"