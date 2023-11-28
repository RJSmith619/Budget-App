using System;
using System.Data.SQLite;
using System.IO;

public static class BudgetDatabase
{
	private static string connectionString = @"Data Source=..\..\..\Files\BudgetApp.db;Version=3";

	public static void InitializeDatabase()
	{
		if (!File.Exists(@"..\..\..\Files\BudgetApp.db"))
		{
			SQLiteConnection.CreateFile(@"..\..\..\Files\BudgetApp.db");

			using (var connection = new SQLiteConnection(connectionString))
			{
				connection.Open();

				//Create tables for the data
				string createExpensesTableQuery = @"
					CREATE TABLE IF NOT EXISTS Expenses (
						ExpenseID INTEGER PRIMARY KEY AUTOINCREMENT,
						Description NVARCHAR NOT NULL,
						Amount DECIMAL NOT NULL,
						DueDate DATE NOT NULL
					);";

				using (var command = new SQLiteCommand(connection))
				{
					command.CommandText = createExpensesTableQuery;
					command.ExecuteNonQuery();
				}
			}
		}
	}

}

