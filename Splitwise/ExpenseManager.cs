using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Splitwise;

public class ExpenseManager
{
    public List<User> UserList;
    public List<Expense> ExpenseList;
    public ExpenseManager()
    {
        using (StreamReader file = File.OpenText(@"json"))
        using (JsonTextReader reader = new JsonTextReader(file))
        {
            JObject output = (JObject)JToken.ReadFrom(reader);
            ExpenseManager deserializedExpenseManager = JsonConvert.DeserializeObject<ExpenseManager>(output.ToString());
            UserList = deserializedExpenseManager.UserList;
            ExpenseList = deserializedExpenseManager.ExpenseList;
        }
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