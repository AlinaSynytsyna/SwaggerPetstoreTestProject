Feature: 1. Pet endpoints tests

In order to be sure that API is working
As a operational manager of this API
I want to test Pet endpoints

Scenario: 1.1. When the user sends request to add new pet to the store, then the Success status code is returned
	When the user sends request to add a new pet with the following parameters
	| Id   | CategoryId | CategoryName | Name | PhotoUrls   | TagsId | TagName     | Status    |
	| 2222 | 1          | Dog          | Zima | example.com | 52     | Small breed | available |
	Then the response with 'OK' status code is returned
		And the response contains the following information about the pet
		| Id   | CategoryId | CategoryName | Name | PhotoUrls   | TagsId | TagName     | Status    |
		| 2222 | 1          | Dog          | Zima | example.com | 52     | Small breed | available |

Scenario: 1.2. When the user sends request to get data about the pet by ID, then the Success status code and the data about the pet are returned
	Given the user sends request to add a new pet with the following parameters
	| Id   | CategoryId | CategoryName | Name | PhotoUrls   | TagsId | TagName     | Status    |
	| 2222 | 1          | Dog          | Zima | example.com | 52     | Small breed | available |
	When the user sends request to get information about the pet with ID 2222
	Then the response with 'OK' status code is returned
		And the response contains the following information about the pet
		| Id   | CategoryId | CategoryName | Name | PhotoUrls   | TagsId | TagName     | Status    |
		| 2222 | 1          | Dog          | Zima | example.com | 52     | Small breed | available |

Scenario: 1.3. When the user sends request to delete data about the pet by ID, then the Success status code is returned
	Given the user sends request to add a new pet with the following parameters
	| Id   | CategoryId | CategoryName | Name | PhotoUrls   | TagsId | TagName     | Status    |
	| 2222 | 1          | Dog          | Zima | example.com | 52     | Small breed | available |
	When the user sends request to delete information about the pet with ID 2222
	Then the response with 'OK' status code is returned

Scenario: 1.4. When the user sends request to get data about the pet by ID that doesn't exist, then the Not Found status code is returned
	Given the user sends request to add a new pet with the following parameters
	| Id   | CategoryId | CategoryName | Name | PhotoUrls   | TagsId | TagName     | Status    |
	| 2222 | 1          | Dog          | Zima | example.com | 52     | Small breed | available |
	When the user sends request to get information about the pet with ID 3333
	Then the response with 'NotFound' status code is returned
		And the message contains the following information
		| Code | Type  | Message       |
		| 1    | error | Pet not found |

Scenario: 1.5. When the user sends request to delete data about the pet by ID that doesn't exist, then the Not Found status code is returned
	Given the user sends request to add a new pet with the following parameters
	| Id   | CategoryId | CategoryName | Name | PhotoUrls   | TagsId | TagName     | Status    |
	| 2222 | 1          | Dog          | Zima | example.com | 52     | Small breed | available |
	When the user sends request to delete information about the pet with ID 3333
	Then the response with 'NotFound' status code is returned