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
    public ExpenseManager Deserialize()
    {
        string jsonContent=File.ReadAllText(@"json");
        ExpenseManager expenseManager = JsonConvert.DeserializeObject<ExpenseManager>(jsonContent);
        return expenseManager;
    }
    public void Serialize(ExpenseManager expenseManager)
    {
        string json = JsonConvert.SerializeObject(expenseManager, Formatting.Indented);
    }
}