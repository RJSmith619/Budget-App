using System;
using System.Data.SQLite;
using Budget_App;


public class ExpenseLogic
{
    private static string connectionString = @"Data Source=..\..\..\Files\BudgetApp.db;Version=3";


    public void AddExpense()
    {
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

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
                insertCommand.Parameters.AddWithValue("@Description", expense.Description);
                insertCommand.Parameters.AddWithValue("@Amount", expense.ExpenseAmount);
                insertCommand.Parameters.AddWithValue("@DueDate", expense.DueDate);

                insertCommand.ExecuteNonQuery();
                Console.WriteLine("Expense added successfully!");
            }
        }
    }


    public void ViewExpenses()
    {
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

            string selectQuery = "SELECT * FROM Expenses";
            using (var selectCommand = new SQLiteCommand(selectQuery, connection))
            {
                using (var reader = selectCommand.ExecuteReader())
                {
                    Console.WriteLine("Id\tDescription\tAmount\tDue Date");
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Id"]}\t{reader["Description"]}\t{reader["Amount"]}\t{reader["DueDate"]}");
                    }
                }
            }
        }
    }


    public void RemoveExpenses()
    {
        //using (var connection = new SQLiteConnection(connectionString))
        //{
        //    connection.Open();

         
        //}
    }
}