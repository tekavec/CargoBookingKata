Feature: Cargo Bookings
	Cargos are booked to Vessels in order to be transported. 
	Each booking much have a booking confirmation number.
	Vessel should not accept cargos if there is no capacity.

Background: 
	Given CargoBookings exist

@BookCargo
Scenario:  Vessel should accept cargos only if there is capacity.
	Given a cargo size is 550 cubic feets
	And a vessel capacity is 9800 cubic feets
	When the application tries to book the cargo on vessel
	Then a new booking is created with the confirmation number 1
	And the cargo is added to the vessel
	And the vessel new capacity is 9250 cubic feets.

@RejectCargo
Scenario: Cargos should be rejected if the Vessel does not have enough capacity.
	Given a cargo size is 550 cubic feets
	And a vessel capacity is 120 cubic feets
	When the application tries to book the cargo on vessel
	Then the booking for the cargo on the vessel is rejected.