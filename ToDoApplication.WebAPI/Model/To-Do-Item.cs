using System.ComponentModel.DataAnnotations;

namespace ToDoApplication.WebAPI.Model
{
    public class To_Do_Item
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime? DueDate { get; set; }
    }
}
