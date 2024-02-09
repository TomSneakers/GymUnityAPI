using System.Reflection;
using DbUp;

var connectionString =
    args.FirstOrDefault()
    ?? "Host=localhost;Port=6432;Database=postgres;Username=postgres;Password=postgres";

var upgrader = DeployChanges.To
                            .PostgresqlDatabase(connectionString)
                            .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                            .LogToConsole()
                            .Build();

var result = upgrader.PerformUpgrade();

if (!result.Successful)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(result.Error);
    Console.ResetColor();
#if DEBUG
    Console.ReadLine();
#endif
    return -1;
}

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Success!");
Console.ResetColor();
return 0;