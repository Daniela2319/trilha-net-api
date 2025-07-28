
using trilha_net_api.Models;

TaskA task = new TaskA(1, "Learn C#", "Study the basics of C# programming language.", DateTime.Now.AddDays(7), EnumStatusTask.Pending);
Console.WriteLine(task);
