using System;
//using System.Data.SQLite;
using Microsoft.Data.Sqlite;
using Budget_App;


public class ExpenseLogic
{
    private static string connectionString = @"Data Source=BudgetApp.db";


    public void AddExpense()
    {
        using (var connection = new SqliteConnection(connectionString))
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
            using (var insertCommand = new SqliteCommand(insertQuery, connection))
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
        {
            var expenses = GetExpenses();

            Console.WriteLine("Id\tDescription\tAmount\tDue Date");
            foreach (var expense in expenses)
            {
                Console.WriteLine($"{expense.Id}\t{expense.Description}\t{expense.ExpenseAmount}\t{expense.DueDate.ToShortDateString()}");
            }
        }
    }


    public List<Expense> GetExpenses()
    {
        List<Expense> expenses = new List<Expense>();

        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            string selectQuery = "SELECT * FROM Expenses";
            using (var selectCommand = new SqliteCommand(selectQuery, connection))
            {
                using (var reader = selectCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        expenses.Add(new Expense
                        {
                            Id = Convert.ToInt32(reader["ExpenseId"]),
                            Description = Convert.ToString(reader["Description"]),
                            ExpenseAmount = Convert.ToDecimal(reader["Amount"]),
                            DueDate = Convert.ToDateTime(reader["DueDate"])
                        });
                    }
                }
            }
        }

        return expenses;
    }


    public void RemoveExpenses()
    {
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            Console.WriteLine("Enter the Id of the expense you want to remove: ");
            int expenseId = Convert.ToInt32(Console.ReadLine());

            string deleteQuery = "DELETE FROM Expenses WHERE ExpenseId = @ExpenseId";
            using (var deleteCommand = new SqliteCommand(deleteQuery, connection))
            {
                deleteCommand.Parameters.AddWithValue("@ExpenseId", expenseId);

                deleteCommand.ExecuteNonQuery();
                Console.WriteLine("Expense removed successfully!");
            }
        }
    }
}