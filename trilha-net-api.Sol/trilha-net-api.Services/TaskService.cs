
using trilha_net_api.Models;
using trilha_net_api.Data;


namespace trilha_net_api.Services
{
    public class TaskService : ITaskService
    {
        #region Propriedades
            private TaskA _task;
            private OrganizerContext _organizerContext;
        #endregion

        #region Contrutores
        public TaskService(OrganizerContext organizerContext)
            {
                this._organizerContext = organizerContext;
           
            }
        #endregion

        #region ListaTodos
            public List<TaskA> GetAll()
            {
                return _organizerContext.Tasks.ToList();
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
                this._organizerContext.Tasks.Add(this._task);
                this._organizerContext.SaveChanges();
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

                    _organizerContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        #endregion

        #region Deletar
            public bool Delete(int id)
            {
                this._task = GetTaskById(id);
                if (this._task != null)
                {
                    _organizerContext.Remove(this._task);
                    _organizerContext.SaveChanges();
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
                return this._organizerContext.Tasks.FirstOrDefault(t => t.Id == id);
            }
            private TaskA CreateTask(int id, string title, string description, DateTime dueDate, EnumStatusTask status)
            {

                var task = new TaskA
                {
                    Title = title,
                    Description = description,
                    DueDate = dueDate,
                    Status = status
                };

                return task;
            }
        #endregion
    }
}
