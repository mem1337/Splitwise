namespace Splitwise;

public class ExpenseManager
{
    public List<User> UserList;
    public List<Expense> ExpenseList;
    public ExpenseManager(List<User> userList, List<Expense> expenseList)
    {
        UserList = userList;
        ExpenseList = expenseList;
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