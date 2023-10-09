Feature: 3. User Endpoints Tests

In order to be sure that API is working
As a operational manager of this API
I want to test User endpoints

Scenario: 3.1. When the user sends request to add a list of users, then the Success status code and the message about successfull operation are returned
	When the user sends request to add users with the following parameters
	| Id   | Username   | FirstName | LastName | Email             | Password    | Phone        | UserStatus |
	| 4444 | SampleMan1 | Sample    | Man      | sample1@email.com | SampleMan1! | +79200000001 | 0          |
	| 5555 | SampleMan2 | John      | Doe      | sample2@email.com | SampleMan2! | +79200000002 | 0          |
	Then the response with 'OK' status code is returned
		And the message contains the following information
		| Code | Type    | Message |
		| 200  | unknown | ok      |

Scenario: 3.2. When the user sends request to get data about the user by username, then the Success status code and the data about the user are returned
	Given the user sends request to add users with the following parameters
	| Id   | Username   | FirstName | LastName | Email             | Password    | Phone        | UserStatus |
	| 5555 | SampleMan1 | Sample    | Man      | sample1@email.com | SampleMan1! | +79200000001 | 0          |
	When the user sends request to get information about the user with username 'SampleMan1'
	Then the response with 'OK' status code is returned
		And the response contains the following information about the user
		| Id   | Username   | FirstName | LastName | Email             | Password    | Phone        | UserStatus |
		| 5555 | SampleMan1 | Sample    | Man      | sample1@email.com | SampleMan1! | +79200000001 | 0          |

Scenario: 3.3. When the user sends request to delete data about the user by username, then the Success status code is returned
	Given the user sends request to add users with the following parameters
	| Id   | Username   | FirstName | LastName | Email             | Password    | Phone        | UserStatus |
	| 5555 | SampleMan1 | Sample    | Man      | sample1@email.com | SampleMan1! | +79200000001 | 0          |
	When the user sends request to delete information about the user with username 'SampleMan1'
	Then the response with 'OK' status code is returned

Scenario: 3.4. When the user sends request to get data about the user by username that doesn't exist, then the Not Found status code is returned
	Given the user sends request to add users with the following parameters
	| Id   | Username   | FirstName | LastName | Email             | Password    | Phone        | UserStatus |
	| 5555 | SampleMan1 | Sample    | Man      | sample1@email.com | SampleMan1! | +79200000001 | 0          |
	When the user sends request to get information about the user with username 'SampleMan2'
	Then the response with 'NotFound' status code is returned
		And the message contains the following information
		| Code | Type  | Message        |
		| 1    | error | User not found |

Scenario: 3.5. When the user sends request to delete data about the user by username that doesn't exist, then the Not Found status code is returned
	Given the user sends request to add users with the following parameters
	| Id   | Username   | FirstName | LastName | Email             | Password    | Phone        | UserStatus |
	| 5555 | SampleMan1 | Sample    | Man      | sample1@email.com | SampleMan1! | +79200000001 | 0          |
	When the user sends request to delete information about the user with username 'SampleMan2'
	Then the response with 'NotFound' status code is returned