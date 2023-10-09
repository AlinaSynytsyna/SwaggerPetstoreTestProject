Feature: 2. Store Endpoints Tests

In order to be sure that API is working
As a operational manager of this API
I want to test Store endpoints

Scenario: 2.1. When the user sends request to add new order on existing pet to the store, then the Success status code is returned
	Given the user sends request to add a new pet with the following parameters
	| Id   | CategoryId | CategoryName | Name | PhotoUrls   | TagsId | TagName     | Status    |
	| 2222 | 1          | Dog          | Zima | example.com | 52     | Small breed | available |
	When the user sends request to add a new order with the following parameters
	| Id | PetId | Quantity | ShipDate                 | Status | Complete |
	| 9  | 2222  | 1        | 2023-10-06T00:00:00.000Z | placed | false    |
	Then the response with 'OK' status code is returned
		And the response contains the following information about the order
		| Id | PetId | Quantity | ShipDate                 | Status | Complete |
		| 9  | 2222  | 1        | 2023-10-06T00:00:00.000Z | placed | false    |

Scenario: 2.2. When the user sends request to get data about the order by ID, then the Success status code and the data about the order are returned
	Given the user sends request to add a new pet with the following parameters
	| Id   | CategoryId | CategoryName | Name | PhotoUrls   | TagsId | TagName     | Status    |
	| 2222 | 1          | Dog          | Zima | example.com | 52     | Small breed | available |
		And the user sends request to add a new order with the following parameters
		| Id   | PetId | Quantity | ShipDate                 | Status | Complete |
		| 3333 | 2222  | 1        | 2023-10-06T00:00:00.000Z | placed | false    |
	When the user sends request to get information about the order with ID 3333
	Then the response with 'OK' status code is returned
		And the response contains the following information about the order
		| Id   | PetId | Quantity | ShipDate                 | Status | Complete |
		| 3333 | 2222  | 1        | 2023-10-06T00:00:00.000Z | placed | false    |

Scenario: 2.3. When the user sends request to delete data about the order by ID, then the Success status code is returned
	Given the user sends request to add a new pet with the following parameters
	| Id   | CategoryId | CategoryName | Name | PhotoUrls   | TagsId | TagName     | Status    |
	| 2222 | 1          | Dog          | Zima | example.com | 52     | Small breed | available |
		And the user sends request to add a new order with the following parameters
		| Id   | PetId | Quantity | ShipDate                 | Status | Complete |
		| 3333 | 2222  | 1        | 2023-10-06T00:00:00.000Z | placed | false    |
	When the user sends request to delete information about the order with ID 3333
	Then the response with 'OK' status code is returned

Scenario: 2.4. When the user sends request to get data about the order by ID that doesn't exist, then the Not Found status code is returned
	Given the user sends request to add a new pet with the following parameters
	| Id   | CategoryId | CategoryName | Name | PhotoUrls   | TagsId | TagName     | Status    |
	| 2222 | 1          | Dog          | Zima | example.com | 52     | Small breed | available |
		And the user sends request to add a new order with the following parameters
		| Id   | PetId | Quantity | ShipDate                 | Status | Complete |
		| 3333 | 2222  | 1        | 2023-10-06T00:00:00.000Z | placed | false    |
	When the user sends request to get information about the order with ID 4444
	Then the response with 'NotFound' status code is returned
		And the message contains the following information
		| Code | Type  | Message         |
		| 1    | error | Order not found |

Scenario: 2.5. When the user sends request to delete data about the order by ID that doesn't exist, then the Not Found status code is returned
	Given the user sends request to add a new pet with the following parameters
	| Id   | CategoryId | CategoryName | Name | PhotoUrls   | TagsId | TagName     | Status    |
	| 2222 | 1          | Dog          | Zima | example.com | 52     | Small breed | available |
		And the user sends request to add a new order with the following parameters
		| Id   | PetId | Quantity | ShipDate                 | Status | Complete |
		| 3333 | 2222  | 1        | 2023-10-06T00:00:00.000Z | placed | false    |
	When the user sends request to delete information about the order with ID 4444
	Then the response with 'NotFound' status code is returned