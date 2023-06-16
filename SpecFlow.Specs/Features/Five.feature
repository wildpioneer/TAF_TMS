Feature: Parallel Testing Thread 1

    @GUI
    Scenario: Using different defs classes 3
        Given new browser is opened
        * a login page is opened
        * the user "atrostyanko@gmail.com" with password "Qwertyu_1" logged in
        Then settings page is opened

    @GUI
    Scenario: Using different defs classes 4
        Given new browser is opened
        * a login page is opened
        * the user "atrostyanko@gmail.com" with password "Qwertyu_1" logged in
        Then settings page is opened