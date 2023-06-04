@SingleUser
Feature: Single User Retrieval
  In order to manage users
  As a user
  I want to be able to interact with the user API

  Scenario: Get User By ID (Positive)
    Given I sent a valid userid "https://reqres.in/api/users/2"
    Then the response status code should be 200
    And the response should contain the user details

  Scenario: Get User By Invalid ID (Negative)
    Given I sent an invalid userid "https://reqres.in/api/users/999"
    Then the response status code should return an invalid code 404
