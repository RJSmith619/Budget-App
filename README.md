# Budget-App

###NOTE!!####
The code is completed but currently I am having database connection issues. This app is being developed using Visual Studio for Mac (New to me) so I'm looking into which dll files, packages, etc I need to get it working. In the meantime if possible please just review the actual written code.
#############

Budget App is a console application (hopefully to be a form application in a later time) that will allow users to track monthly expenses. It is being developed using the C# coding language and will utilize a SQLite database.  The user will be able to see a description of the expense, the expense amount, and the due date. The user will also have the ability to add, view, and delete expenses (Planning to add an 'update' feature in the future).

# How to Use

When starting the app you are prompted with 4 options. You can either Add, View, or Remove an expense with the fourth option allowing you to exit the program.  When choosing to Add an expense you will be asked to provide the description of the expense as well as the amount and due date. You will then be prompted again with the 4 menu options. If you choose to View expenses a list of all expenses should be returned.  Finally, when choosing to Remove an expense you will be prompted to choose the Id of the expense you want to remove. 

# Features

Create a dictionary or list, populate it with several values, retrieve at least one value, and use it in your program.
A list of expenses is created when the ViewExpenses method is called to retrieve a full list of all available expenses to return.

Query your database using a raw SQL query, not EF
The AddExpense, GetExpenses, and RemoveExpense methods utilize SQL to perform their relative actions to the database.

Create 3 or more unit tests for your application
A Test project was created to test the methods of the 3 actions a user can take (Add, View, Remove).
