
Create an application to manage rentals in our Rental agency. 

The agency rents two types of products: cars and apartments. The rent price is calculated in dollars. 

For this application, we are going to need classes for the rental entities. 

  Class Car having the following properties:
  
      Id
      Model
      HorsePowers
      Color
  Class Apartment having the following properties: 
  
      Id
      Address
      SquareMeters
      NumberOfRooms
  Class CarRent having the following properties:
  
      Id
      LesseeName
      NumberOfDays
      PricePerDay
      Car (of type Car)
      EntryDate
  Class ApartmentRent having the following properties:
  
      Id
      LesseeName
      NumberOfDays
      PricePerDay
      Apartment (of type Apartment)
      EntryDate
      
Both ApartmentRent and CarRent classes should have methods FullPrice() which will return the PricePerDay * NumberOfDays.
If the Apartment is bigger than 100 square meters the price should be lowered by 5%. 
If the Car horsepower is greater than 140 we need to add $20 to the full price. 
Both ApartmentRent and CarRent should have method Print() which will print “[EntryDate] : [LeeseeName] – NumberOfDays x PricePerDay = FullPrice()”

  Class Agency having the following properties:
  
      Name
      CarRents
      ApartmentRents
      CarsForRent
      ApartmentsForRent
      
Create a menu in the console and implement logic that will allow the user to do the following actions.

    Create a new Rent. Ask the user what would like to rent (Car or Apartment). Present to user car or apartment list available for rent based on the user choice.From the choice create new Rent and add it to the list in Agency Rent list. 
    View all rents 
    View all car rents 
    View all apartment rents
    View rent revenue
    View revenue from car rents
    View revenue from apartment rents
    Get car rents for cars above 140 horsepowers
    Get car rents for apartments above 100 square meters 
    View rent by Id
    Remove rent by id
    View all cars and apartments available for rent
    Add a car for rent 
    Add an apartment for rent


NOTE: The agency can not rent the same car or apartment twice. 
