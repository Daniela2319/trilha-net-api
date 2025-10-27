using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trilha_net_api.Models;

namespace trilha_net_api.Services
{
    public interface ITaskService
    {
        int Register(string title, string description, DateTime dueDate, EnumStatusTask status);
        bool Update(int id, string title, string description, DateTime dueDate, EnumStatusTask status);
        bool Delete(int id);
        TaskA GetById(int id);
        List<TaskA> GetAll();

    }
}
