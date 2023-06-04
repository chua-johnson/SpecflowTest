@UpdateUser-PUT
Feature: Update User API - PUT
    As a user
    I want to update user information
    So that I can keep my profile up to date

Scenario: 1. Update user with valid data
    Given the user information is valid
    When I send a PUT request to "https://reqres.in/api/users/2" with the following body:
        """
        {
            "name": "John Doe",
            "job": "Software Engineer"
        }
        """
    Then the response status code should be 200
    And the response body should contain the updated user information


Scenario: 2. Update user with invalid data (negative test)
    Given the user information is invalid
    When I send a PUT request to "https://reqres.in/api/users/2" with the following body that has invalid data:
        """
        {
            "name": "",
            "job": "Software Engineer"
        }
        """
    Then it should return response status code of 400
    And the response body should contain an error message

Scenario: 3. Update user with invalid schema (negative test)
    When I send a PUT request to "https://reqres.in/api/users/2" with the following body that has invalid schema:
        """
        {
            "name_x": "John",
            "job": "Software Engineer"
        }
        """
    Then it should return an invalid response status code of 404
    