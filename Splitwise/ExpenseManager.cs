namespace Splitwise;

public class ExpenseManager
{
    public List<Expense> ExpenseList { get; set; }
    public List<User> UserList { get; set; }
    public ExpenseManager(List<Expense> expenseList, List<User> userList)
    {
        ExpenseList = expenseList;
        UserList = userList;
    }
    public List<User> GetUsers()
    {
        return UserList;
    }
    public List<Expense> GetExpenses()
    {
        return ExpenseList;
    }
    public void UpdateUsers(List<User> userList)
    {
        UserList = userList;
    }
    public void UpdateExpenses(List<Expense> expenseList)
    {
        ExpenseList = expenseList;
    }
}