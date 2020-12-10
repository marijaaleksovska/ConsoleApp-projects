Parking management system
Create an application to manage car parking. The parking has a limited number of parking spots, each labelled with a number. 
Price for parking per hour is 30 den. There is also a prepaid ticket option with price 1500 den per month.

The user can: 

  1.Park
  
    Show available spots to choose from 
    Ask if the user wants to use a prepaid ticket or park by the hour
      Case prepaid 
      
        Insert prepaid  ticket Id and car registration plate
        If ticket info correct allow to park and set the spot as not available
        Check if the ticket is still applicable for the period (example: the ticket is valid until the end of January and user is trying to park in February)
        
      Case by the hour
      
        Ask for car registration plate
 
 2.Leave parking
  
    Ask the user for the car registration plate number (based on the number set the parking spot as available)
    If the user is parked with hourly pay, calculate the number of hours and show the price to the user.
    If the user is parked with prepaid, just print the number of hours the user has been parked

  3.Buy prepaid ticket

    Aks the user for car registration number (can not have two prepaid tickets with same registration number)
    Ask for a number of months 
    Calculate the price and show it to the user

Can not have multiple prepaid tickets with the same registration number in the same period. 

Can not have multiple cars parked with the same registration numbers.

Each prepaid ticket has validTo date which specifies until when the ticket is valid

NOTE: I use text files as databases in which JSON objects can be written and deleted

