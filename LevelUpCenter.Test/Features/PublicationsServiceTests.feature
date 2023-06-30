Feature: PublicationsServiceTests
As a User
I want to add new Publications in my account
In order to interact with the gaming comunity.
	Background:
		Given the Endpoint https://localhost:44396/api/v1/publications is available
	@publication-adding
	Scenario: Add Publication with unique Title
		When a Post Request is sent
		  | Title  | Description          | UrlImage | UserId |
		  | Sample | A Sample Publication |        a | 1      |
		Then A Response is received with Status 200
		And a Publication Resource is included in Response Body
		  | Id | Title  | Description          | UrlImage | UserId |
		  | 1  | Sample | A Sample Publication |        a | 1      |
    
	@publication-adding
	Scenario: Add Publication with existing Title
		Given A Publication is already stored
		  | Id | Title  | Description       | UrlImage | UserId |
		  | 1  | New | A new Publication |        a | 1      |
		When a Post Request is sent
		  | Title  | Description       | UrlImage | UserId |
		  | New | A new Publication |        a | 1      |
		Then A Response is received with Status 400
		And An Error Message is returned with value "Title already exist."
