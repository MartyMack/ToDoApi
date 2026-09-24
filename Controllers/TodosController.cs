using Microsoft.AspNetCore.Mvc;
using ToDoApi.Dtos;
using ToDoApi.Models;
using ToDoApi.Services;

namespace ToDoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodosController : ControllerBase
{
    private readonly TodoService _service;

    public TodosController(TodoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Todo>>> GetTodos()
    {
        return await _service.GetAllAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Todo>> GetTodo(int id)
    {
        var todo = await _service.GetByIdAsync(id);

        if (todo == null)
            return NotFound();

        return todo;
    }

    [HttpPost]
    public async Task<ActionResult<Todo>> CreateTodo(CreateTodoDto dto)
    {
        var todo = await _service.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetTodo),
            new { id = todo.Id },
            todo);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTodo(
        int id,
        UpdateTodoDto dto)
    {
        var updated = await _service.UpdateAsync(id, dto);

        if (!updated)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodo(int id)
    {
        var deleted = await _service.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }

    [HttpPatch("{id}/complete")]
    public async Task<IActionResult> ToggleComplete(int id)
    {
        var updated = await _service.ToggleCompleteAsync(id);

        if (!updated)
            return NotFound();

        return NoContent();
    }
}