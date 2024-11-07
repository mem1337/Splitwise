namespace Splitwise;
public class Expense
{
    public int Id { get; set; }
    public string ExpenseName { get; }
    public float ExpenseCost { get; }
    public Dictionary<string, float> WhoOwes { get; }
    public string WhoPaid { get; set; }

    public Expense(int id, string expenseName, float expenseCost, Dictionary<string,float> whoOwes, string whoPaid)
    {
        Id = id;
        ExpenseName = expenseName;
        ExpenseCost = expenseCost;
        WhoOwes = whoOwes;
        WhoPaid = whoPaid;
    }

    public override string ToString()
    {
        string result = $"{Id}. {WhoPaid} paid {ExpenseCost} in total for {ExpenseName}.";
        foreach (KeyValuePair<string, float> a in WhoOwes)
        {
            result+=$"\n - {a.Key} owes {a.Value}.";
        }
        return result;
    }
}