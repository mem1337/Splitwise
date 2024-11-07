namespace Splitwise;

public class ExpenseManager
{
    public List<User> UserList;
    public List<Expense> ExpenseList;
    public int Id;
    public int ExpenseId;
    public string? Result;

    public ExpenseManager(List<User> userList, List<Expense> expenseList, int id = 0, int expenseId = 0)
    {
        UserList = userList ?? new List<User>();
        ExpenseList = expenseList ?? new List<Expense>();
        Id = id;
        ExpenseId = expenseId;
    }
    public void AddUser(string name)
    {
        Id++;
        User user = new User(name,Id);
        UserList.Add(user);
    }
    public void AddExpense(string expenseName, float expenseCost, Dictionary<string,float> whoOwes, string whoPaid)
    {
        ExpenseId++;
        Expense expense = new Expense(ExpenseId, expenseName, expenseCost, whoOwes, whoPaid);
        ExpenseList.Add(expense);
    }
    public void RemoveExpense(int id)
    {
        for (int i = 0; i < ExpenseList.Count; i++)
        {
            if (id == ExpenseList[i].Id)
            {
                ExpenseList.RemoveAt(i);
                ExpenseId--;
            }
        }
    }
    public string GetDebtSummaries()
    {
        Result = null;
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
            Result+=$"{user.Id}. {user.Name} ";
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
    public void RemoveUser(int id)
    {
        UserList.RemoveAt(id);
        Id--;
    }
}