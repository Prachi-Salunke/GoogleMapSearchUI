Feature: Google map Search functionality feature

Search for the locations using google maps with different locations to test its usefulness.

@GoogleMapUITest

  Scenario Outline: Search for a valid address
    Given I am on the Google Maps page
    When I search for "<address>" on map
    Then The application should locate "<address>" on map

  
  Examples:
      | address                                      |
      | 1600 Amphitheatre Parkway, Mountain View, CA |



Scenario Outline: Search for a invalid address
    Given I am on the Google Maps page
    When I search for "<address>" on map
    Then an appropriate message should be displayed

    Examples:
      | address     |
      | $%^&@dfGH12 |



  Scenario Outline: Search in different languages
    Given I am on the Google Maps page with language "<language>"
    When I search for "<address>" on map
    Then The application should locate "<address>" on map
    And the page should be displayed in "<language>"

    Examples:
      | address                   | language |
      | Tour Eiffel, Paris, France| fr-IN    | 


   Scenario Outline: Get directions between two addresses
    Given I am on the Google Maps page
    When I get directions from "<from>" to "<to>"
    Then the directions should be displayed correctly

    Examples:
      | from                                        | to                                  |
      | Pune                                        | Mumbai                              | 


Scenario Outline: Searching for an address with a common typo.
    Given I am on the Google Maps page
    When I search for "<address>" on map
    Then The application should correctly locate "<addressoutput>" on map

  
  Examples:
      | address                    | addressoutput               |
      | Eiffel Twer, Paris, France | Eiffel Tower                |



Scenario Outline: Search for a invalid coordinates on google map
    Given I am on the Google Maps page
    When I enter invalid "<coordinates >" on map
   Then an appropriate message should be displayed

    Examples:
      | coordinates     |
      |  999,999        |
