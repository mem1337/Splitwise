namespace Splitwise;

public class ExpenseManager
{
    public List<User> UserList;
    public List<Expense> ExpenseList;
    public int Id;
    public string? Result;

    public ExpenseManager(List<User> userList, List<Expense> expenseList, int id = 0)
    {
        UserList = userList ?? new List<User>();
        ExpenseList = expenseList ?? new List<Expense>();
        Id = id;
    }
    public void AddUser(string name)
    {
        Id++;
        User user = new User(name,Id);
        UserList.Add(user);
    }
    public void AddExpense(string expenseName, float expenseCost, Dictionary<string,float> whoOwes, string whoPaid)
    {
        Expense expense = new Expense(expenseName, expenseCost, whoOwes, whoPaid);
        ExpenseList.Add(expense);
    }
    public string GetDebtSummaries()
    {
        Result = "";
        foreach (var expense in ExpenseList)
        {
            Result+=$"{expense.ToString()}\n";
        }
        return Result;
    }
    public string GetUserNames()
    {
        Result = "";
        foreach (var user in UserList)
        {
            Result+=$"{user.Name} ";
        }
        return Result;
    }
    public User GetSpecificUser(int id)
    {
        return UserList[id];
    }
    public int GetUserCount()
    {
        return UserList.Count;
    }
}