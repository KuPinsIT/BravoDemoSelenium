@CompanySearch
Feature: CompanySearch
Simple search company

Link to a feature: [CompanySearch](CaculatorSelenium.Specs/Features/CompanySearch.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**


Scenario Outline: In Company search page search by keyword
	Given the keyword is <Keyword>
	When the keyword is added
	Then the company search results name should contains <Expected result>

Examples:
	| Keyword			| Expected result |
	| test api 160622	| test api 160622 |
	| IT Company		| IT Company	  |