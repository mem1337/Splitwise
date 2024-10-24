using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Splitwise;

public class ExpenseManager
{
    public List<User> UserList;
    public List<Expense> ExpenseList;
    public int Id;
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
    public int GetId()
    {
        return Id;
    }
    public void UpdateUsers(List<User> userList)
    {
        UserList = userList;
    }
    public void UpdateExpenses(List<Expense> expenseList)
    {
        ExpenseList = expenseList;
    }
    public void UpdateId(int id)
    {
        Id = id;
    }
}