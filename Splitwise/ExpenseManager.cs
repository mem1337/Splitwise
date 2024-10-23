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
    public void Deserialize(ExpenseManager expenseManager)
    {
        string jsonContent=File.ReadAllText(@"json");
        expenseManager = JsonConvert.DeserializeObject<ExpenseManager>(jsonContent);
    }
    public void Serialize(ExpenseManager expenseManager)
    {
        string json = JsonConvert.SerializeObject(expenseManager, Formatting.Indented);
    }
}