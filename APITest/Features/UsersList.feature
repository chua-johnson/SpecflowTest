@AllUsers
Feature: Users Retrieval
    As a user
    I want to retrieve user details
    So that I can use the data in my application

    Scenario: Retrieve users successfully
        Given I have a valid API endpoint 
        When I send a GET request to "/users?page=1"
        Then the response status code should be 200
        And the response should contain user details

    Scenario: Retrieve users with an invalid API endpoint
        Given I have an invalid API endpoint 
        When I send an invalid request to "/invalid/users?page=1"
        Then the response status code should be invalid 404
