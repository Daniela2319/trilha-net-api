using System.Runtime.ConstrainedExecution;
using trilha_net_api.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace trilha_net_api.Services
{
    public class TaskService : ITaskService
    {
        private List<TaskA> _tasks;
        private TaskA _task;


        #region Deletar
        public bool Delete(int id)
        {
            this._task = GetTaskById(id);
            if (this._task != null)
            {
                _tasks.Remove(this._task);
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region ListaTodos
        public List<TaskA> GetAll()
        {
            return _tasks;
        }
        #endregion

        #region ListaPorId
        public TaskA GetById(int id)
        {
            this._task = GetTaskById(id);
            return this._task;
        }
        #endregion

        #region Cadastrar
        public int Register(string title, string description, DateTime dueDate, EnumStatusTask status)
        {
            this._task = CreateTask(0, title, description, dueDate, status);
            this._tasks.Add(this._task);
            return this._task.Id;
        }
        #endregion

        #region Editar
        public bool Update(int id, string title, string description, DateTime dueDate, EnumStatusTask status)
        {
            this._task = this.GetTaskById(id);
            if (this._task != null)
            {
                CreateTask(0, title, description, dueDate, status);
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Auxiliary Methods
        private TaskA GetTaskById(int id)
        {
            return this._tasks.FirstOrDefault(t => t.Id == id);
        }
        private TaskA CreateTask(int id, string title, string description, DateTime dueDate, EnumStatusTask status)
        {
            this._task.Id = id;
            this._task.Title = title;
            this._task.Description = description;
            this._task.DueDate = dueDate;
            this._task.Status = status;
            
            return this._task;
        }
        #endregion
    }
}
