using BLL.Dtos;
using BLL.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.Annotations;

namespace ToDo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemController : ControllerBase
    {
        private readonly IToDoItemService _service;
        private readonly IValidator<ToDoItemDto> _validator;
        public ToDoItemController(IToDoItemService service, IValidator<ToDoItemDto> validator)
        {
            _service = service;
            _validator = validator;
        }

        /// <summary>
        /// Retrieve all tasks 
        /// </summary>
        /// <param name="title">Title of the task for searching (not required)</param>
        /// <returns>All tasks or specific task</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ToDoItemDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation("GetAllTasks")]
        public async Task<IActionResult> GetAllItemsAsync([FromQuery] string? title)
        {
            try
            {
                var result = await _service.GetAllTodoItems();
                
                if (!string.IsNullOrEmpty(title))
                {
                    result = result.Where(p => p.Title.Contains(title));
                }

                if (result == null)
                {
                    return NotFound("There aren't tasks.");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Retrieve a concrete task by id
        /// </summary>
        /// <param name="id">Id of the task</param>
        /// <returns>One task</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ToDoItemDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation("GetTaskById")]
        public async Task<IActionResult> GetTodoItemById(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest("Invalid id format.");
                }

                var result = await _service.GetTodoItemById(id);

                if (result == null)
                {
                    return NotFound("There isn't any task with this id.");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Adds a new task to the database
        /// </summary>
        /// <returns>The added task</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ToDoItemDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Consumes("application/json")]
        [SwaggerOperation("CreateTask")]
        public async Task<IActionResult> CreateTodoItem([FromBody] ToDoItemDto todoItem)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(todoItem);

                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
                }

                if (todoItem == null)
                {
                    return BadRequest("Task is null");
                }

                todoItem.Id = Guid.NewGuid();
                var checkTodoItem = await _service.GetByTitle(todoItem.Title);

                if (checkTodoItem != null && checkTodoItem.Status == false)
                {
                    return BadRequest("The task with this title is already exist and doesn't complete");
                };

                var todoItemToCreate = await _service.CreateTodoItem(todoItem);

                if (todoItemToCreate == null)
                {
                    ModelState.AddModelError("", "Task is already exist.");
                    return StatusCode(422, ModelState);
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                return Created("", todoItemToCreate);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Updates an existing task in the database
        /// </summary>
        /// <returns>True, if update was successfull, or False, if not</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Consumes("application/json")]
        [SwaggerOperation("UpdateTask")]
        public async Task<IActionResult> UpdateTodoItem([FromBody] ToDoItemDto todoItem)
        {
            if (todoItem == null)
            {
                return BadRequest("Task is null");
            }

            var validationResult = await _validator.ValidateAsync(todoItem);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var response = await _service.UpdateTodoItem(todoItem);

            if (response == true)
            {
                return Ok($"The task {todoItem.Id} was updated successfully");
            }

            return StatusCode(StatusCodes.Status500InternalServerError, "The task wasn't successfully created");
        }

        /// <summary>
        /// Delete a concrete task from the database 
        /// </summary>
        /// <param name="id">Id of the task</param>
        /// <returns>True, if delete was successfull, or False, if not</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [Consumes("application/json")]
        [SwaggerOperation("DeleteTask")]

        public async Task<IActionResult> DeleteTodoItem(Guid id)
        {
            try
            {
                var result = await _service.DeleteTodoItemById(id);

                if (result == false)
                {
                    return NotFound("The task isn't exist");
                }

                return Ok($"The task {id} was deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
