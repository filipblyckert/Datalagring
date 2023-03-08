using _01_EFC.Services;

var menu = new MenuService();
while (true)

{
    Console.Clear();
    Console.WriteLine("1. skapa en ny kontakt");
    Console.WriteLine("2. visa alla kontakter");
    Console.WriteLine("3. visa en specifik kontakt");
    Console.WriteLine("4. radera en specifik kontakt");
    Console.WriteLine("5. skapa ett ärende");
    Console.Write("välj ett av följande alternativ (1-5):");

    switch (Console.ReadLine())
    {
        case "1":
            Console.Clear();
            await menu.CreateNewContactAsync();

            break;

        case "2":
            Console.Clear();
            await menu.ListAllContactsAsync();
            break;
        case "3":
            Console.Clear();
            await menu.ListSpecificContactAsync();
            break;

        case "4":
            Console.Clear();
            await menu.DeleteSpecificContactAsync();
            break;
    }

    Console.WriteLine("\ntryck på valfri knapp för att fortsätta...");
    Console.ReadKey();
}