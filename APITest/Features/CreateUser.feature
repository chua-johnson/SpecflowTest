@CreateUser
Feature: Create User
  As a user
  I want to be able to create and retrieve user details
  So that I can manage user information

  Scenario: Create a user (Positive)
    Given I have a valid user payload
    When I send a POST request to "/api/users"
    Then the response status code should be 201
    And the response body should contain the user ID

  #Scenario: Retrieve user details
  #  Given a user with ID exists
  #  When I send a GET request to "/api/users/{id}"
  #  Then the response status code should be 200
  #  And the response body should contain the user details

  Scenario: Create a user (Negative)
    Given I have an invalid user payload
    When I call a POST request to "/api/users"
    Then the invalid response status code should be 201
 
  #Scenario: Invalid user ID
  #  Given a user with ID does not exist
  #  When I send a GET request to "/api/users/{id}"
  #  Then the response status code should be 404
