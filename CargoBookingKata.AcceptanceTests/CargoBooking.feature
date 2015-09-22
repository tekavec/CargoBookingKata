Feature: Cargo Bookings
Background: Cargo and Vessel exist.

@BookCargo
Scenario: Cargos must be added to Vessels in order to be transported. Vessel should accept cargos if there is capacity.
	Given a cargo size is 550 cubic feet
	And a vessel capacity is 9800 cubic feet
	When the application try to book the cargo on vessel
	Then the cargo gets the booking number 1
	And the vessel capacity is 9250 cubic feet.

@RejectCargo
Scenario: Cargos must be rejected if the Vessel does not have enough capacity.
	Given a cargo size is 550 cubic feet
	And a vessel capacity is 120 cubic feet
	When the application try to book the cargo on vessel
	Then the cargo is rejected.