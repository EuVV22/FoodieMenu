# FoodieMenu

FoodieMenu is a web application that helps customers find new food, it does so by displaying offering from different restaurants so the focus is more on the food that on the establishment.
To incentivise restaurants to add their food, the web app also creates a more interactive way for the restaurants to display their different menus and has a way to position the restaurant agains competitors.

# Installation:
Clone the repository github.com/EuVV22/FoodieMenu

# Usage
Set the FoodieMenu.Web solution as the startup project and run the program.
The program has a web base UI that lets you decide what type of customer are you and each has a dashboard presenting all the possible options.

# Credits
This code was created as a final capstone project for the software development pathway for CODE:YOU, thanks to all the Staff and my mentors Jhon and Neil.

# Contact
You can reach me at my email: ejvv22@gmail.com

# Features 

  | Feature        | Description                           |
  |----------------|---------------------------------------|
  | Have 2 or more tables (entities) in your application that are related and have a function return data from both entities.  In entity framework, this is equivalent to a join     | Entity Category has a many to many relationship with items, the loading process of both can be seen in the RestaurantRepository class inside the FoodieMenu.Data solution |
  | Create 3 or more unit tests for your application | Check the FoodieMenu.Test to see the MSTest application |
  | Implement a regular expression (regex) to validate or ensure a field is always stored and displayed in the correct format      | Regex was use to validate the input from the user in AddMenu.razor.cs              |
  | Make your application an API. | With the FoodieMenu.WebAPI solution you could also use the API             |
  
