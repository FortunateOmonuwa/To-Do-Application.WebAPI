using ToDoApplication.WebAPI.Contract;
using ToDoApplication.WebAPI.InMemoryStorage;
using ToDoApplication.WebAPI.Model;

namespace ToDoApplication.WebAPI.Repository
{
    public class To_Do_Repository : ITo_Do_Contract
    {
        private readonly DataBase _dataBase;
        public To_Do_Repository(DataBase dataBase)
        {
            _dataBase = dataBase;
        }
        public async Task<bool> AddNewTaskAsync(To_Do_Item item)
        {
            try
            {
                if (item != null && item.Id == null)
                {
                    _dataBase.ToDoList.Add(item);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteTask(int itemId)
        {
            try
            {
                var task = _dataBase.ToDoList.FirstOrDefault(i => i.Id == itemId);
                if(task != null)
                {
                    _dataBase.ToDoList.Remove(task);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ICollection<To_Do_Item>> GetAllTaskOrderByDateTime()
        {
            try
            {
                var task = _dataBase.ToDoList.ToList().OrderBy(o => o.DateCreated);
                return task.ToList();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }  
        }

        public async Task<To_Do_Item> GetTaskById(int itemId)
        {
            try
            {
                var task = _dataBase.ToDoList.FirstOrDefault(i => i.Id == itemId);
                if (task != null)
                {
                    return task;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateTask(To_Do_Item item, int itemId)
        {
            var task = GetTaskById(itemId);
            if(task != null )
            {
                _dataBase.ToDoList.Add(item);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
