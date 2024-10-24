using System;
using System.ComponentModel;
using System.Text.Json.Serialization.Metadata;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Splitwise;

class Program
{
    public static void Main(String[] args)
    {
        int id = 0;
        int decision;

        float cost;
        float money;

        string name;
        string expenseName;

        List<User> users = new List<User>();
        List<Expense> expenses = new List<Expense>();
        /*string jsonContent=File.ReadAllText(@"json");
        ExpenseManager expenseManager = JsonConvert.DeserializeObject<ExpenseManager>(jsonContent);
        users = expenseManager.GetUsers();
        expenses = expenseManager.GetExpenses();*/

        while(true)
        {
            Dictionary<string, float> whoOwes = new Dictionary<string, float>();

            Console.WriteLine("Press (1) to add a user, (2) to add an expense, (3) to show the debt.");
            decision = Convert.ToInt32(Console.ReadLine());
            switch(decision)
            {
                case 1:
                    id++;
                    Console.WriteLine("What is the name of the user?");
                    name = Console.ReadLine();
                    User user = new User(name,id);
                    users.Add(user);
                    break;

                case 2:
                    Console.WriteLine("What is the name of the expense?");
                    expenseName = Console.ReadLine();

                    Console.WriteLine("What is the cost of the expense?");
                    cost = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Who is paying for the expense?");
                    for(int i = 0; i < users.Count; i++)
                    {
                        Console.Write($"{users[i].Id}. {users[i].Name} ");
                    }
                    decision = Convert.ToInt32(Console.ReadLine())-1;
                    Console.WriteLine($"{users[decision].Name} is paying!");

                    float tempMoney = 0;
                    for (int i = 0; i < users.Count; i++)
                    {
                        if(users[i].Name!=users[decision].Name)
                        {
                            Console.WriteLine($"How much does {users[i].Name} owe?");
                            money = Convert.ToInt32(Console.ReadLine());

                            if (money >= cost-tempMoney)
                            {
                                whoOwes.Add(users[i].Name,(cost-tempMoney));
                                break;
                            }
                            if (money < cost-tempMoney)
                            {
                                tempMoney+=money;
                                whoOwes.Add(users[i].Name,money);
                            }
                        }
                    }

                    Expense expense = new Expense(expenseName,cost,whoOwes,users[decision].Name);
                    expenses.Add(expense);
                    
                    ExpenseManager expenseManager = new ExpenseManager(users,expenses);
                    expenseManager.UpdateUsers(users);
                    expenseManager.UpdateExpenses(expenses);
                    File.WriteAllText(@"json", expenseManager);



                    break;
                case 3:
                    using (StreamReader file = File.OpenText(@"json"))
                    using (JsonTextReader reader = new JsonTextReader(file))
                    {
                        JObject output = (JObject)JToken.ReadFrom(reader);
                        ExpenseManager deserializedExpenseManager = JsonConvert.DeserializeObject<ExpenseManager>(output.ToString());
                        Console.WriteLine(deserializedExpenseManager.ToString());
                    }
                    /*
                    for(int i = 0; i<expenses.Count; i++)
                    {
                        Console.WriteLine(expenses[i].ToString());
                    }*/
                    break;
            }
        }
    }
}