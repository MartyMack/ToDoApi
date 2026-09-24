using Microsoft.EntityFrameworkCore;
using ToDoApi.Data;
using ToDoApi.Dtos;
using ToDoApi.Models;

namespace ToDoApi.Services;

public class TodoService
{
    private readonly AppDbContext _context;

    public TodoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Todo>> GetAllAsync()
    {
        return await _context.Todos.ToListAsync();
    }

    public async Task<Todo?> GetByIdAsync(int id)
    {
        return await _context.Todos.FindAsync(id);
    }

    public async Task<Todo> CreateAsync(CreateTodoDto dto)
    {
        var todo = new Todo
        {
            Title = dto.Title,
            Description = dto.Description,
            DueDate = dto.DueDate.HasValue ? DateTime.SpecifyKind(dto.DueDate.Value, DateTimeKind.Utc) : null,
            IsCompleted = false
        };

        _context.Todos.Add(todo);
        await _context.SaveChangesAsync();

        return todo;
    }

    public async Task<bool> UpdateAsync(int id, UpdateTodoDto dto)
    {
        var todo = await _context.Todos.FindAsync(id);

        if (todo == null)
        {
            return false;
        }

        todo.Title = dto.Title;
        todo.Description = dto.Description;
        todo.IsCompleted = dto.IsCompleted;
        todo.DueDate = dto.DueDate.HasValue
    ? DateTime.SpecifyKind(dto.DueDate.Value, DateTimeKind.Utc)
    : null;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var todo = await _context.Todos.FindAsync(id);

        if (todo == null)
        {
            return false;
        }
        _context.Todos.Remove(todo);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> ToggleCompleteAsync(int id)
    {
        var todo = await _context.Todos.FindAsync(id);

        if (todo == null)
        {
            return false;
        }

        todo.IsCompleted = !todo.IsCompleted;

        await _context.SaveChangesAsync();

        return true;
    }
}