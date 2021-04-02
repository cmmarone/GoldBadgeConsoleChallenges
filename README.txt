GOLD BADGE CONSOLE CHALLENGES

Student Developer: Collin Marone, April 2021


These console applications were built for fulfillment of the Software Development Gold Badge at Eleven Fifty Academy. There are 5 menu-based programs in all, each designed for different imagined user, each with different deliverables in terms of funtionality.  Below are the essential points taken from each challenge prompt around which each program was built.

-----------------------

Challenge 1: Cafe

Build a new menu app for the manager of Komodo Cafe. They want to be able to create and delete menu items, and view a list of all items on the cafe's menu.

Each menu item has:
-Meal number
-Meal name
-Meal description
-A list of ingredients
-Price
 
Deliverables:
-Display the current menu
-User can add and remove items from the menu

Bonus functionality (extra features I added):
-User can edit any information on items already in the menu

-----------------------

Challenge 2: Claims

Build an app for a Komodo Insurance agent to track claims.

Data to track for each claim:
-Claim ID number
-Type of claim: Car, Home, Theft
-Description of the claim
-Dollar amount of the claim
-Date of the claim incident
-Date the claim was made
-Whether or not the claim is valid (only claims made within 30 days of the incident are valid)


Deliverables:
-User can view all unprocessed claims
-User can remove claims they have processed
-User can enter new claims to be processed
-Claims are sorted in the order in which they were added

Bonus functionality (extra features I added):
-The program generates a random Claim ID number for each new claim

-----------------------

Challenge 3: Badges

Build an app for Komodo Insurance security staff to manage employee badge (keycard) information.

Each employee badge:
-Has an ID number
-Has a list of doors that badge can open

Deliverables:
-User can create a new badge
-User can edit door access for any badge, including removing access to all doors
-User can view a list of all badges and their corresponding door access

-----------------------

Challenge 4: Company Outings

Komodo accountants need a list of all company outings, the cost of all outings combined, and the cost of all types of outings combined.

Data to track for each outing:
-Outing Type: Golf, Bowling, Amusement Park, Concert
-Number of people that attended
-Date of the outing
-Total cost per person for the outing
-Total cost for the outing
 
Deliverables:
-Display a list of all outings with combined cost
-Display outing costs by type
-User can add outings

Bonus functionality (extra features I added):
-Whether viewing a list of all outings, or a list of outing types, user has the option of viewing only the current year's outings, or the complete history of outings.

-----------------------

Challenge 5: Greeting

Komodo Insurance is going to email everyone in the world and needs an app to determine what kind of message to send each recipient based on their relationship to Komodo Insurance.

Each recipient of an email is one of the following:
-A current Komodo Insurance client
-A past Komodo Insurance client
-Has never been a client of Komodo Insurance

Deliverables:
-User can view a list of all recipients in alphabetical order by last name then first name
-User can add a recipient to the list
-User can remove a recipient from the list
-User can edit a recipient in the list

Bonus functionality (extra features I added):
-User can find and view an individual recipient by entering their name in a search






------------------------------------------------------------------------------------------------------------------------


IMPORTANT: To ensure tables display properly, expand or maximize the console window.

In each of the 5 programs, the display tables were formatted based on mock-ups in which I filled the table with intentionally long data cells to account for appropriate spacing of user-created data. The data cells in all tables in all five programs are generated from a static table method that aligns text data to the left, and aligns numeric data to the right, and formats either information type based on the column width I pre-determined in the mockups.


Mockup Tables:

Challenge 1: Cafe

    8                         42                        7
 ___________________________________________________________
| Number |                   Name                   | Price |
|--------|------------------------------------------|-------|
|      1 | Duck l'Orange                            | ##.## |
|      2 | Chicken a la King                        | ##.## |
|      3 | Fettuccine Alfredo                       | ##.## |
|      4 | The-Most-Bestest-Foods-In-Your-Mouth     | ##.## |
|-----------------------------------------------------------|


Challenge 2: Claims

      12         8                           43                          14                 18               15
 ___________________________________________________________________________________________________________________
|  Claim ID  |  Type  |                Description                |    Amount    | Date of Incident | Date of Claim |
|------------|--------|-------------------------------------------|--------------|------------------|---------------|
| ########## | Theft  | Marble collection burglary                | #,###,###.## |         ##-##-## |      ##-##-## |
|-------------------------------------------------------------------------------------------------------------------|


Challenge 3: Badges

     12                                   65
 ______________________________________________________________________________
|  Badge ID  |                           Door Access                           |
|------------|-----------------------------------------------------------------|
|      ##### | A1, A2, A3, A4, A5, A6, A7, A8, A9, A10                         | 
|      ##### | C4                                                              |
|------------------------------------------------------------------------------|


Challenge 4: Outings

by-type table

          16         7           16
 _________________________________________
|   Event Type   | Count |    YTD Cost    |
|----------------|-------|----------------|
|      Golf      |     4 |       6,046.18 |
|     Bowling    |     2 |         281.10 |
| Amusement Park |     0 |           0.00 |
|     Concert    |     1 |   1,000,000.00 |
|-----------------------------------------|


outings table

      10          (16)           11             17                 16
 __________________________________________________________________________
|   Date   |   Event Type   | Attendees | Cost Per Person |   Total Cost   |
|----------|----------------|-----------|-----------------|----------------|
| 11-03-19 | Golf           |         6 |        x,xxx.xx |       6,046.18 |
|  7-13-19 | Bowling        |         2 |          xxx.xx |         281.10 |
|  7-11-19 | Amusement Park |         4 |                 |       1,231.09 |
|  4-24-19 | Concert        |        11 |                 |   x,xxx,xxx.xx |
|--------------------------------------------------------------------------|


Challenge 5: Greeting

        16                 19              12                                             79
 _________________________________________________________________________________________________________________________________
|   First Name   |     Last Name     |    Type    |                                 Email Message                                 |
|----------------|-------------------|------------|-------------------------------------------------------------------------------|
| Rutherford     | Featherbottomsly  | Potential  | We currently have the lowest rates on Helicopter Insurance!                   |
| Chris          | Bacon             | Past       | It's been a long time since we've heard from you, we want you back.           |
|Thumbelina      | Vanlandingham     | Current    | Thank you for your work with us. We appreciate your loyalty. Here's a coupon. |
|---------------------------------------------------------------------------------------------------------------------------------|


