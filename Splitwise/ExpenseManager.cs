using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
    public void UpdateLists()
    {
        var json = File.ReadAllText("json");
        var expenseManager = JsonConvert.DeserializeObject<ExpenseManager>(json);
        UserList = expenseManager.UserList;
        ExpenseList = expenseManager.ExpenseList;
    }
}