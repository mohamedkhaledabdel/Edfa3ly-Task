# Edfa3ly-Task
Edfa3yly Technical Task for the interview

# Problem and solution

A task should be implemented that can price a cart of products, accept multiple products, combine offers, and display a total detailed bill in different currencies (based on user selection).

1- Implemnetd only the back-end 
2- Employed SOLID principles and mainly two design patterns repository design pattern and dependency injections

The program can handle some special offers, which affect the pricing.
Available offers:

Shoes are on 10% off.
Buy two t-shirts and get a jacket half its price.

The 3 main folders in the project are DAL which repersents data access layer, Models, and Controller

* Data Access Layer
Only considered with data manipulation/creation in database. The DAL contains repositories and their interfaces
* Models
Employed the entity framework code-first which is ORM framework for ASP.net. EF is used to create models that repersents the DB tables, then migrations are created
in order to create DB tables.
* Controller
Created REST API controllers which is only respobsible ofr the consumpiton of REST APIs.
i.e localhost:xxxxx/api/prdoucts
is the route for viewing the products

i.e localhost:xxxxx/api/carts
is the route for viewing the cart items

i.e localhost:xxxxx/api/carts/detailedBill
is the route for viewing the detailedBill

For applying the discounts a PUT request should be perfromed using postman for instance
localhost:xxxxx/api/discounts/apply



# Features that should be added if have more time
* Hosting the app on azure
* Create front-end using react.js and host it
* Creating unit tests
* Currency conversion mechanism instead of hardcoded (i.e Enum)
* Add a business layer to seperate business logic from APIs/Controllers in order to make them more loosely coupled
* Add better and more organized comments
* Add error handling and logging
