namespace Splitwise;
public class Expense
{
    public string ExpenseName { get; set; }
    public float ExpenseCost { get; set; }
    public Dictionary<User, float> WhoOwes { get; set; }
    public string WhoPaid { get; set; }

    public Expense(string expenseName, float expenseCost, Dictionary<User,float> whoOwes, string whoPaid)
    {
        ExpenseName = expenseName;
        ExpenseCost = expenseCost;
        WhoOwes = whoOwes;
        WhoPaid = whoPaid;
    }

    public override string ToString()
    {
        string result = $"{WhoPaid} paid {ExpenseCost} in total for {ExpenseName}.";
        foreach (KeyValuePair<User, float> a in WhoOwes)
        {
            result+=$"\n - {a.Key.Name} owes {a.Value}.";
        }
        return result;
    }
}