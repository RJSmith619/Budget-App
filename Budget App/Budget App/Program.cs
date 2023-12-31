﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget_App;


BudgetDatabase.InitializeDatabase();

ExpenseLogic logic = new ExpenseLogic();

Console.WriteLine("----------");
Console.WriteLine("BUDGET APP");
Console.WriteLine("----------");
Console.WriteLine("Press '1' to add an expense");
Console.WriteLine("Press '2' to view expenses");
Console.WriteLine("Press '3' to remove an expense");
Console.WriteLine("Type 'exit' to quit");

string menuAction = Console.ReadLine();

while(menuAction.ToLower() != "exit")
{
    if(menuAction == "1")
    {
        Expense expense = new Expense();
        logic.AddExpense();
    }
    else if(menuAction == "2")
    {
        logic.ViewExpenses();
    }
    else if(menuAction == "3")
    {
        logic.RemoveExpenses();
    }

    Console.WriteLine("Press '1' to add an expense");
    Console.WriteLine("Press '2' to view expenses");
    Console.WriteLine("Press '3' to remove an expense");
    Console.WriteLine("Type 'exit' to quit");
    menuAction = Console.ReadLine();
}