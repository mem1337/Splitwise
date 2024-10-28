using System;
using Newtonsoft.Json;

namespace Splitwise;

class Program
{
    public static void Main(String[] args)
    {
        int decision;
        float cost;
        float money;
        string expenseName;

        var json = File.ReadAllText(@"json");
        var expenseManager = JsonConvert.DeserializeObject<ExpenseManager>(json);

        while(true)
        {
            Console.Clear();
            Dictionary<string, float> whoOwes = new Dictionary<string, float>();

            Console.WriteLine("Press (1) to add a user, (2) to add an expense, (3) to show the debt, (4) to list the users.");
            decision = Convert.ToInt32(Console.ReadLine());
            switch(decision)
            {
                case 1:
                    Console.WriteLine("What is the name of the user?");
                    expenseManager.AddUser(Console.ReadLine());
                    break;
                case 2:
                    Console.WriteLine("What is the name of the expense?");
                    expenseName = Console.ReadLine();

                    Console.WriteLine("What is the cost of the expense?");
                    cost = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Who is paying for the expense?");
                    for(int i = 0; i < expenseManager.GetUserCount(); i++)
                    {
                        Console.Write($"{expenseManager.GetSpecificUser(i).Id}. {expenseManager.GetSpecificUser(i).Name} ");
                    }
                    decision = Convert.ToInt32(Console.ReadLine())-1;
                    Console.WriteLine($"{expenseManager.GetSpecificUser(decision).Name} is paying!");

                    float tempMoney = 0;
                    for (int i = 0; i < expenseManager.GetUserCount(); i++)
                    {
                        if(expenseManager.GetSpecificUser(i).Name!=expenseManager.GetSpecificUser(decision).Name)
                        {
                            Console.WriteLine($"How much does {expenseManager.GetSpecificUser(i).Name} owe?");
                            money = Convert.ToInt32(Console.ReadLine());

                            if (money >= cost-tempMoney)
                            {
                                whoOwes.Add(expenseManager.GetSpecificUser(i).Name,(cost-tempMoney));
                                break;
                            }
                            if (money < cost-tempMoney)
                            {
                                tempMoney+=money;
                                whoOwes.Add(expenseManager.GetSpecificUser(i).Name,money);
                            }
                        }
                    }
                    expenseManager.AddExpense(expenseName,cost,whoOwes,expenseManager.GetSpecificUser(decision).Name);
                    File.WriteAllText(@"json", JsonConvert.SerializeObject(expenseManager));
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine(expenseManager.GetDebtSummaries());
                    Console.ReadKey();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine(expenseManager.GetUserNames());
                    Console.ReadKey();
                    break;
            }
        }
    }
}