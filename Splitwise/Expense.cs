namespace Splitwise;
public class Expense
{
    public string ExpenseName { get; set; }
    public float ExpenseCost { get; set; }
    public Dictionary<string, float> WhoOwes { get; set; }
    public string WhoPaid { get; set; }

    public Expense(string expenseName, float expenseCost, Dictionary<string,float> whoOwes, string whoPaid)
    {
        ExpenseName = expenseName;
        ExpenseCost = expenseCost;
        WhoOwes = whoOwes;
        WhoPaid = whoPaid;
    }

    public override string ToString()
    {
        string result = $"{WhoPaid} paid {ExpenseCost} in total for {ExpenseName}.";
        foreach (KeyValuePair<string, float> a in WhoOwes)
        {
            result+=$"\n - {a.Key} owes {a.Value}.";
        }
        return result;
    }
}