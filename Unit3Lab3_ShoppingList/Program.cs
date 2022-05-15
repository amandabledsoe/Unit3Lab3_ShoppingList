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
    Console.WriteLine("Now, let's start adding items to your shopping list!");
    Console.WriteLine("Enter the name of a menu item to add. Enter a blank line to stop adding entries to your shopping list at anytime.");
    bool addingItems = true;
    while (addingItems)
    {
        Console.Write("Your Item Selection: ");
        string userSelection = Console.ReadLine();
        if (!String.IsNullOrEmpty(userSelection))
        {
            CheckForListItem(userSelection, menuItems, usersItems);
        }
        else
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("All Items have been added to your shopping list!");
            Console.ResetColor();
            addingItems = false;
        }
    }
    Console.WriteLine();
    PrintAllUserItems(usersItems);
    PauseAndClearScreen();
    bool needToClear = WannaRestart();
    if (needToClear)
    {
        usersItems.Clear();
    }
    runningProgram = needToClear;
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
            Console.ForegroundColor = ConsoleColor.DarkBlue;
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
        Console.WriteLine("Would you like to add items to a new shopping list?");
        Console.WriteLine("Enter 'Yes' to start a new shopping list or 'No' to end the program.");
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
    bool isInUserList = false;
    bool isInMenuItems = true;
    int fixedCount = usersItems.Count;
    foreach (var item in usersItems)
    {
        if (Regex.IsMatch(userSelection, item.Key, RegexOptions.IgnoreCase))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("It looks like we already have this on the list!");
            Console.ResetColor();
            isInUserList = true;
            break;
        }
    }
    if (!isInUserList)
    {
        foreach (var thing in menuItems)
        {
            if (Regex.IsMatch(userSelection, thing.Key, RegexOptions.IgnoreCase))
            {
                usersItems.Add(thing.Key, thing.Value);
            }
        }
        if (fixedCount == usersItems.Count)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("It looks like we dont have an item by that name on our menu. Let's try again.");
            Console.ResetColor();
        }
    }
    if (!isInMenuItems)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("It looks like we dont have an item by that name on our menu. Let's try again.");
        Console.ResetColor();
    }
}
static void PrintAllUserItems(Dictionary<string, double> usersItems)
{
    Console.WriteLine("Your shopping list contains the following items: ");
    Console.WriteLine();
    foreach (var item in usersItems)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(String.Format("{0,1}{1,17}{2,6}{3,1}", "", item.Key, "$", string.Format("{0:0.00}", item.Value)));
    }
    Console.ResetColor();
    Console.WriteLine();
    Console.Write($"The total of your shopping list is $");
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.Write($"{ string.Format("{0:0.00}", usersItems.Sum(x => x.Value))}");
    Console.ResetColor();
    Console.Write(".");
    Console.WriteLine();}