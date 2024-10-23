using Newtonsoft.Json;
namespace Splitwise;

public class ExpenseManager
{
    List<Expense> ExpenseList { get; set; }
    List<User> UserList { get; set; }
    public ExpenseManager(List<Expense> expenseList, List<User> userList)
    {
        ExpenseList = expenseList;
        UserList = userList;
    }
}