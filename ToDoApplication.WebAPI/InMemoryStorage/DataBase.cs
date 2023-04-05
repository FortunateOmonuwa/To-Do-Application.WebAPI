using ToDoApplication.WebAPI.Model;

namespace ToDoApplication.WebAPI.InMemoryStorage
{
    public class DataBase
    {
        public  DataBase()
        {
            ToDoList = Tasks();
        }

        public ICollection<To_Do_Item> ToDoList { get; set; }

        private static ICollection<To_Do_Item> Tasks()
        {
            return new List<To_Do_Item>()
            {
                new To_Do_Item()
                {
                    Id = 1,
                    Title = "Create ToDo Application",
                    Description = "Assessment for O2 Hero Tech Consulting Internship",
                },
                new To_Do_Item()
                {
                    Id = 2,
                    Title = "2nd task",
                    Description = "Lorem Ipsum",
                    DateCreated = DateTime.Now,
                },
                new To_Do_Item()
                {
                    Id = 3,
                    Title = "Another",
                    Description = "New Task",
                    DateCreated = DateTime.Now,
                }
            };
        }
    }
}
