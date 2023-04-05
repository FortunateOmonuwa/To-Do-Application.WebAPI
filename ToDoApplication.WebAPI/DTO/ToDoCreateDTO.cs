using System.ComponentModel.DataAnnotations;

namespace ToDoApplication.WebAPI.DTO
{
    public class ToDoCreateDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? DueDate { get; set; }
    }
}
