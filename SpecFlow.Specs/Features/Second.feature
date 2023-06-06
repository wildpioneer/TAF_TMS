Feature: Параметризированные тесты

    Scenario: Параметризация степов
        Given browser is opened
        * the login page is opened
        When user "atrostyanko@gmail.com" with password "Qwertyu_1" logged in
        Then title is "All Projects - TestRail"
        And project id is 123

    Scenario Outline: Параметризация при помощи таблицы значений
        Given browser is opened
        * the login page is opened
        When user "<username>" with password "<password>" logged in
        Then title is "All Projects - TestRail"
        And project id is <age>

        Examples:
          | username              | password  | age |
          | atrostyanko@gmail.com | Qwertyu_1 | 19  |
          | atrostyanko@gmail.com | Qwertyu_1 | 32  |