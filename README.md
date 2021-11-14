# ASP.NET Core Project - Car Renting System version 2.0

1). Create a car renting system
Prepare your project architecture for a car renting system and implement user authentication allowing administrator role.

2). Become a dealer
This route should be available for all registered users. Each user should be able to add car after. Each added car should be shown on the /cars/all route.

3). Add /cars/add route
This route should be available only for dealers. It should display a form with which a car can be added to the system. Choose what properties each car should have but make sure you save at least an image, model and price per day for every data entry.

4). Add /cars/all route
This route should be available for users who already are dealers. It should display all available cars for rent. Keep in mind that currently rented cars should not be displayed here. Add searching by a property (no case-sensitive) of your choice and paging as additional functionality for this route.

5). Add /users/me route
This route should be available only for registered users. It should show for the currently logged in user all his/her rent history in a table.

6). Add /cars/edit/:id route
This route should be available only for administrators. It should allow the user to edit the car with the provided Id.

7). Sky is the limit
Add functionality to the system as you see fit – you may add statistics, image uploads, nice design, etc. :)
