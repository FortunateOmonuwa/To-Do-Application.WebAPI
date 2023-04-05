using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApplication.WebAPI.Contract;
using ToDoApplication.WebAPI.DTO;
using ToDoApplication.WebAPI.Model;

namespace ToDoApplication.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly ITo_Do_Contract _toDo;
        private readonly IMapper _mapper;
        public ToDoController(ITo_Do_Contract toDo, IMapper mapper)
        {
            _toDo = toDo;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddTask([FromBody] ToDoCreateDTO task)
        {
            try
            {
                var toDo = _mapper.Map<To_Do_Item>(task);
                if(toDo == null) 
                {
                    return BadRequest("An error occured.Please try again");
                }
                else
                {
                    await _toDo.AddNewTaskAsync(toDo);
                    var getToDo = _mapper.Map<ToDoGetDTO>(toDo);
                    return CreatedAtAction(nameof(GetTaskById), new { taskId = toDo.Id }, getToDo);
                }
              
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{taskId}")]
        public async Task<IActionResult> GetTaskById(int taskId)
        {
            try
            {
                var task = await _toDo.GetTaskById(taskId);
                if(task == null)
                {
                    return BadRequest("An error occured.Please try again");
                }
                else
                {
                    var mapTask = _mapper.Map<ToDoGetDTO>(task);
                    return Ok(mapTask);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("/GetAllTasksByDateTime")]
        public async Task<IActionResult> GetAllTaskByDateTime()
        {
            try
            {
                var tasks = await _toDo.GetAllTaskOrderByDateTime();
                var mapTasks = _mapper.Map<List<ToDoGetDTO>>(tasks);
                return Ok(mapTasks);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{taskId}")]
        public async Task<IActionResult> UpdateTask([FromBody] ToDoCreateDTO updateTask, int taskId)
        {
            try
            {
                var task = await _toDo.GetTaskById(taskId);
                if(task == null)
                {
                    return BadRequest("An error occured.Please try again");
                }
                else
                {
                    var update = _mapper.Map<To_Do_Item>(updateTask);
                    update.Id = taskId;
                    await _toDo.UpdateTask(update, taskId);

                    var mapUdate = _mapper.Map<ToDoGetDTO>(update);
                    return Ok(mapUdate);
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{taskId}")]
        public async Task<IActionResult> DeleteTask(int taskId)
        {
            try
            {
                var task = await _toDo.GetTaskById(taskId);
                if (task == null)
                {
                    return BadRequest("An error occured.Please try aga in");
                }
                else
                {
                    await _toDo.DeleteTask(taskId);
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
