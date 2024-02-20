namespace BLL.Dtos
{
    public class ToDoItemDto 
    {
        public ToDoItemDto()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool Status { get; set; } = false;
    }
}
