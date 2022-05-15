using System.Text.RegularExpressions;

Dictionary<string, double> menuItems = new Dictionary<string, double>();
menuItems.Add("Grapes", 4.99);
menuItems.Add("Oreos", 3.75);
menuItems.Add("Pizza", 6.99);
menuItems.Add("Frozen Burrito", 1.00);
menuItems.Add("Macaroni & Cheese", 1.25);
menuItems.Add("Cereal", 2.99);
menuItems.Add("Bread", 1.49);
menuItems.Add("Graham Crackers", 2.25);
menuItems.Add("Ice Cream", 3.00);
menuItems.Add("Chips", 3.50);

Dictionary<string, double> usersItems = new Dictionary<string, double>();
bool runningProgram = true;

Console.WriteLine("Welcome to the Shopping List Program!");
PauseAndClearScreen();

while (runningProgram)
{
    Console.WriteLine("Here are all of the menu items available: ");
    Console.WriteLine();
    PrintAllMenuItems(menuItems);
    Console.WriteLine();
    Console.WriteLine("Let's start adding items to your shopping list!");
    Console.WriteLine("Enter the name of an item to add.");
    Console.Write("Your Item Selection: ");
    string userSelection = Console.ReadLine();
    CheckForListItem(userSelection, menuItems, usersItems);
    Console.WriteLine();
    PrintAllUserItems(usersItems);
    PauseAndClearScreen();
    runningProgram = WannaRestart();
}
Console.WriteLine("Thank you for using the Shopping List Program!");
Console.WriteLine("Goodbye...");

static void PauseAndClearScreen()
{
    Console.WriteLine();
    Console.WriteLine("Press Enter to Continue.");
    Console.ReadLine();
    Console.Clear();
}
static void PrintAllMenuItems(Dictionary<string, double> menuItems)
{
    int counter = 0;
    foreach (var item in menuItems)
    {
        if (counter % 2 == 0)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(String.Format("{0,1}{1,17}{2,6}{3,1}", "", item.Key, "$", string.Format("{0:0.00}", item.Value)));
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(String.Format("{0,1}{1,17}{2,6}{3,1}", "", item.Key, "$", string.Format("{0:0.00}", item.Value)));
            Console.ResetColor();
        }
        counter++;
    }
}

static bool WannaRestart()
{
    bool askingUser = true;
    while (askingUser)
    {
        Console.WriteLine("Would you like to run this program again?");
        Console.WriteLine("Enter 'Yes' or 'No' below");
        Console.Write("Your Choice: ");
        string userChoice = Console.ReadLine();
        string yesInput = "[Yy][Ee][Ss]";
        string noInput = "[Nn][Oo]";
        if(Regex.IsMatch(userChoice, yesInput))
        {
            PauseAndClearScreen();
            return true;
        }
        else if(Regex.IsMatch(userChoice, noInput))
        {
            PauseAndClearScreen();
            return false;
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Sorry, I didnt understand that response. Let's try again.");
            Console.WriteLine();
        }
    }
    return false;
}

static void CheckForListItem(string userSelection, Dictionary<string, double> menuItems, Dictionary<string, double> usersItems)
{
    foreach (var item in menuItems)
    {
        if (Regex.IsMatch(userSelection, item.Key, RegexOptions.IgnoreCase))
        {
            usersItems.Add(item.Key,item.Value);
        }
    }
}

static void PrintAllUserItems(Dictionary<string, double> usersItems)
{
    Console.WriteLine("Your list current contains the following items: ");
    foreach (var item in usersItems)
    {
        Console.WriteLine(String.Format("{0,1}{1,17}{2,6}{3,1}", "", item.Key, "$", string.Format("{0:0.00}", item.Value)));
    }
    Console.WriteLine();
    Console.WriteLine($"The total of your shopping list is {string.Format("{0:0.00}", usersItems.Sum(x => x.Value))}");
}