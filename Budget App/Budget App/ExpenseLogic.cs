using System;
using System.Data.SQLite;
using Budget_App;


public class ExpenseLogic
{
    static void AddExpense(SQLiteConnection connection)
    {
        Expense expense = new Expense();

        Console.Write("Enter Description: ");
        expense.Description = Console.ReadLine();

        Console.Write("Enter Expense Amount: ");
        expense.ExpenseAmount = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Enter Due Date (YYYY-MM-DD): ");
        expense.DueDate = DateTime.Parse(Console.ReadLine());

        string insertQuery = "INSERT INTO Expenses (Description, Amount, DueDate) VALUES (@Description, @Amount, @DueDate)";
        using (var insertCommand = new SQLiteCommand(insertQuery, connection))
        {
            connection.Open();
            {
                insertCommand.Parameters.AddWithValue("@Description", expense.Description);
                insertCommand.Parameters.AddWithValue("@Amount", expense.ExpenseAmount);
                insertCommand.Parameters.AddWithValue("@DueDate", expense.DueDate);

                insertCommand.ExecuteNonQuery();
                Console.WriteLine("Expense added successfully!");
            }
        }
    }


    static void ViewExpenses(SQLiteConnection connection)
    {

    }
}