using System;
namespace Splitwise;

class Program
{
    public static void Main(String[] args)
    {
        //Variables
        int id = 0;
        int decision;

        float cost;
        float money;

        string name;
        string expenseName;

        //Users and expenses
        List<User> users = new List<User>();
        List<Expense> expenses = new List<Expense>();

        //Main loop
        while(true)
        {
            //Defining dictionary over and over so it resets
            Dictionary<User, float> whoOwes = new Dictionary<User, float>();

            Console.WriteLine("Press (1) to add a user, (2) to add an expense, (3) to show the debt.");
            decision = Convert.ToInt32(Console.ReadLine());
            switch(decision)
            {
                //Add a user
                case 1:
                    id++;
                    Console.WriteLine("What is the name of the user?");
                    name = Console.ReadLine();
                    User user = new User(name,id);
                    users.Add(user);
                    break;

                //Add an expense
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

                    //Loop to get money and calculate how much does everybody owe
                    float tempMoney = 0;
                    for (int i = 0; i < users.Count; i++)
                    {
                        if(users[i].Name!=users[decision].Name)
                        {
                            Console.WriteLine($"How much does {users[i].Name} owe?");
                            money = Convert.ToInt32(Console.ReadLine());

                            if (money < cost-tempMoney)
                            {
                                tempMoney+=money;
                                Console.WriteLine(tempMoney);
                                whoOwes.Add(users[i],money);
                            }
                            if (money > cost-tempMoney)
                            {
                                whoOwes.Add(users[i],(cost-tempMoney));
                                break;
                            }
                        }
                    }

                    //Add an expense
                    Expense expense = new Expense(expenseName,cost,whoOwes,users[decision].Name);
                    expenses.Add(expense);
                    break;

                //List expenses and debts
                case 3:
                    for(int i = 0; i<expenses.Count; i++)
                    {
                        Console.WriteLine(expenses[i].ToString());
                    }
                    break;
            }
        }
    }
}