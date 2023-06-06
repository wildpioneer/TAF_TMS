Feature: Problems 

  @GUI
  Scenario: Using different defs classes
    Given new browser is opened
    * a login page is opened
    * the user "atrostyanko@gmail.com" with password "Qwertyu_1" logged in
    Then settings page is opened