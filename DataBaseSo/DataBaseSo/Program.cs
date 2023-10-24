using System;

namespace DataBaseSO
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: KeyValueClient <databaseFilePath> <command> [args]");
                return;
            }

            string databaseFilePath = args[0];
            var database = new KeyValueDatabase(databaseFilePath);

            if (args.Length < 2)
            {
                Console.WriteLine("Invalid command. Use '--insert', '--remove', '--update', or '--search'.");
                return;
            }

            string command = args[1];

            switch (command)
            {
                case "--insert":
                    if (args.Length < 4)
                    {
                        Console.WriteLine("Usage: insert <key> <value>");
                        return;
                    }
                    int key = int.Parse(args[2]);
                    string value = args[3];
                    database.Insert(key, value);
                    Console.WriteLine("inserted");
                    break;

                case "--remove":
                    if (args.Length < 3)
                    {
                        Console.WriteLine("Usage: remove <key>");
                        return;
                    }
                    key = int.Parse(args[2]);
                    database.Remove(key);
                    Console.WriteLine("removed");
                    break;

                case "--update":
                    if (args.Length < 4)
                    {
                        Console.WriteLine("Usage: update <key> <new-value>");
                        return;
                    }
                    key = int.Parse(args[2]);
                    string newValue = args[3];
                    database.Update(key, newValue);
                    Console.WriteLine("updated");
                    break;

                case "--search":
                    if (args.Length < 3)
                    {
                        Console.WriteLine("Usage: search <key>");
                        return;
                    }
                    key = int.Parse(args[2]);
                    string result = database.Search(key);
                    Console.WriteLine(result);
                    break;

                default:
                    Console.WriteLine("Invalid command. Use 'insert', 'remove', 'update', or 'search'.");
                    break;
            }
        }
    }
}