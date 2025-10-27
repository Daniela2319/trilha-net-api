
using trilha_net_api.Models;

TaskA task = new TaskA();
task.Id = 1;
task.Title = "Complete the project";
task.Description = "Finish the project by the end of the month.";
task.DueDate = new DateTime(2025, 7, 24, 14, 30, 0);
task.Status = EnumStatusTask.Pending;


Console.WriteLine(task);
