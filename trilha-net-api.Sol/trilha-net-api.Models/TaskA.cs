using Microsoft.VisualBasic;

namespace trilha_net_api.Models
{
    public class TaskA
    {
        #region Propriedades
            public int Id { get; set; }
            private string _title;
            public string Title 
            { 
                get {
                    if (string.IsNullOrWhiteSpace(_title))
                    {
                        throw new Exception("Title cannot be empty or contain only spaces.");
                    }
                    return _title.ToUpper();
                } 
                set{ _title = value; }
            }
            public string Description { get; set; }
            private DateTime _dueDate;
            public DateTime DueDate
            { 
                get => TimeZoneInfo.ConvertTimeFromUtc(_dueDate, GetSaoPauloTimeZone());
                set => _dueDate = TimeZoneInfo.ConvertTimeToUtc(value, GetSaoPauloTimeZone());
            }
            public EnumStatusTask Status { get; set; }
        #endregion

        #region Contrutor
            public TaskA() { }
            public TaskA(int id, string title, string description, DateTime dueDate, EnumStatusTask status)
            {
                Id = id;
                Title = title;
                Description = description;
                DueDate = dueDate;
                Status = status;
            }

            public override string ToString()
            {
                return $"Id: {Id}, Title: {Title}, Description: {Description}, DueDate: {DueDate.ToShortDateString()}, Status: {Status}";
            }
        #endregion

        #region Metodos Auxiliares
            private TimeZoneInfo GetSaoPauloTimeZone()
            {
                return TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            }
        #endregion
    }
}
