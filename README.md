This my solution for Unit 3: Lab 3 "Shopping List" in the 2022 C# .NET After-Hours Boot Camp at Grand Circus.

# SHOPPING LIST
### Objectives:
Generic Collections, Data Processing

### Task: 
Make a shopping list application which uses collections to store your items. (You will be using two collections, one for the menu and one for the shopping list.)

### What will the application do?
- Display at least 8 item names and prices.
- Ask the user to enter an item name
- If that item exists, display that item and price and add that item and its price to the user’s order.
- If that item doesn’t exist, display an error and re-prompt the user.  (Display the menu again if you’d like.)
- After adding one to their order, ask if they want to add another. If so, repeat.  (User can enter an item more than once; we’re not keeping track of quantity at this point.)
- When they’re done adding items, display a list of all items ordered with prices in columns.
- Display the sum price of the items ordered.

### Build Specifications/Grading Points
- Application uses a Dictionary<string, decimal> to keep track of the menu of items.  You can code it with literals. (2 points for instantiation & initialization)
- Use a List<string> for the shopping list and store the name of the items the customer ordered.
- Application takes item name input and:
- Responds if that item doesn’t exist (1 point)
- Adds its name and price to the relevant List if it does (1 point)
- Application asks user if they want to quit or continue, and loops appropriately (1 point)
- Application displays list of items with their prices (2 points)
- Application displays the correct total predict for the list (1 point)
- To determine the sum: Loop through the shopping list’s List collection, obtain the name, and look up the name’s price in the Menu Dictionary.

### Extended Challenges:
- Implement a menu system so the user can enter just a letter or number for the item.
- Display the most and least expensive item ordered.
- Display the items ordered in order of price.


### Console Preview:
```
Welcome to Chirpus Market!

Item            Price
==============================
apple           $0.99
banana          $0.59
cauliflower     $1.59
dragonfruit     $2.19
Elderberry      $1.79
figs            $2.09
grapefruit      $1.99
honeydew        $3.49

What item would you like to order? apple
Adding apple to cart at $0.99

Would you like to order anything else (y/n)? y

{menu redisplays}

What item would you like to order? watermelon
Sorry, we don't have those.  Please try again.

{menu redisplays}

What item would you like to order? dragonfruit
Adding dragonfruit to cart at $2.19

Would you like to order anything else (y/n)? y

{menu redisplays}

What item would you like to order? honeydew
Adding honeydew to cart at $3.49

Would you like to order anything else (y/n)? y

{menu redisplays}

What item would you like to order? figs
Adding figs to cart at $2.09

Would you like to order anything else (y/n)? n

Thanks for your order!
Here's what you got:
apple           $0.99
dragonfruit     $2.19
honeydew        $3.49
figs            $2.09
Average price per item in order was 2.19
```
