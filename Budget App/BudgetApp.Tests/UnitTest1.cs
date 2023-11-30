using Budget_App;

namespace BudgetApp.Tests;

public class UnitTest1
{
    [Fact]
    public void AddExpense_IncreasesExpenseCount()
    {
        ExpenseLogic expense = new ExpenseLogic();
        int initialCount = expense.GetExpenses().Count;

        expense.AddExpense();

        Assert.Equal(initialCount + 1, expense.GetExpenses().Count);
    }

    [Fact]
    public void ViewExpense_ReturnsExpenseList()
    {
        ExpenseLogic expense = new ExpenseLogic();

        var expenses = expense.GetExpenses();

        Assert.NotNull(expenses);
        Assert.IsType<List<Expense>>(expenses);
    }

    [Fact]
    public void RemoveExpense_ReducesExpenseCount()
    {
        ExpenseLogic expense = new ExpenseLogic();
        expense.AddExpense();
        int initialCount = expense.GetExpenses().Count;

        expense.RemoveExpenses();

        Assert.Equal(initialCount - 1, expense.GetExpenses().Count);
    }
}
