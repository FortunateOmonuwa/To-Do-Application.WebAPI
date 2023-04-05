using ToDoApplication.WebAPI.Model;

namespace ToDoApplication.WebAPI.Contract
{
    public interface ITo_Do_Contract
    {
        Task<bool> AddNewTaskAsync(To_Do_Item item);
        Task<bool> UpdateTask(To_Do_Item item, int itemId);
        Task<bool> DeleteTask(int itemId);
        Task<To_Do_Item> GetTaskById(int itemId);
        Task<ICollection<To_Do_Item>> GetAllTaskOrderByDateTime();
    }
}
