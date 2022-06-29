@BravoLogin
Feature: BravoLogin
Simple calculator for adding **two** numbers

Link to a feature: [BravoLogin](BravoLoginSelenium.Specs/Features/BravoLogin.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**


Scenario Outline: In BravoLogin check validation message of user name and password
	Given the user name is <User name>
	And the password is <Password>
	When the user name and password are added
	Then the user name validation message should be <Expected result>

Examples:
	| User name | Password | Expected result |
	|             | 12345678             | The User name field is required.              |

Scenario Outline: In BravoLogin page login by right user name and password
	Given the user name is <User name>
	And the password is <Password>
	When the user name and password are added
	Then the display company name should be <Expected result>

Examples:
	| User name | Password | Expected result |
	| thuanpham            | 12345678             | Upheads AS               |