Applicant Tracker System.

** System Arhitecture **

i. 3- tier architecture was used 
ii. Clean arhitecture was used.
iii. Generic repository model was used.
iv. in memory database was used as advised from the requirement.
v. Aurelia JS framework was used for thr front end.

** Design Decision **
i. Repository design pattern was used 
ii. Unit of work patter was used to manage all the Repository connection to db.
iii. Generic exception handling
iv.Central logging system from middleware using Serilog
iv. swagger was used for API documentation


** project lising ******
The system is designed to use the 3 tier architecture web ,domain and data and a test project for unit test.

**Application details **
The web project houses the web api and the domain houses the validation and business logic while the data handles the repository.

** Client app in aurelia ***
The client app sit in the web app project.
In the client app - boostrap UI is used and the for the validation.
aurelia dialog box is used to dix the dialog box issue.

** unit Testing **
i. xUnit test was used.
ii. Test server was created to test the controller APIs 

*** System Flow  **
The entry point to the system is to go into client-app directory in the web project and do au run --open  | au run --watch
The API flow start from Controller of the web project and then flow to the domain and the data.
The data layer write the in momery db using entity framework core.
A simple API url to access the swagger service  : http://localhost:37797/swagger/index.html

** Challenges **
I could not complete the UI part as I encounter some issues, I could not easily resolve on the UI as I am new to the too JS framework.
However if I have a little more time, I would have been able to complete the UI and fix the primary requirement of the system.
