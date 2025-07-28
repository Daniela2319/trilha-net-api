namespace trilha_net_api.Models
{
    public class TaskA
    {
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
        public DateTime DueDate { get; set; }
        public EnumStatusTask Status { get; set; }

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
    }
}
