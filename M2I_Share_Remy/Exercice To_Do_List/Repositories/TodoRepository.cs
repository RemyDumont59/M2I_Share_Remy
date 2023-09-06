using Exercice02.Data;
using Exercice02.Models;
using System.Linq.Expressions;

namespace Exercice02.Repositories
{
    public class TodoRepository : IRepository<Todo>
    {
        private ApplicationDbContext _dbContext;

        public TodoRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Create
        public bool Add(Todo entity)
        {
            var newTodo = _dbContext.Todo.Add(entity);
            _dbContext.SaveChanges();
            return newTodo.Entity.Id > 0;
        }

        // Read
        public Todo? GetById(int id)
        {
            return _dbContext.Todo.Find(id);
        }
        public List<Todo> GetAll()
        {
            return _dbContext.Todo.ToList();
        }
        public Todo? Get(Expression<Func<Todo, bool>> predicate)
        {
            return _dbContext.Todo.FirstOrDefault(predicate);
        }
        public List<Todo> GetAll(Expression<Func<Todo, bool>> predicate)
        {
            return _dbContext.Todo.Where(predicate).ToList();
        }

        // Update
        public bool Update(Todo entity)
        {
            var todo = GetById(entity.Id);
            if (todo == null)
                return false;

            if (todo.Name != entity.Name)
                todo.Name = entity.Name;

            if (todo.Description != entity.Description)
                todo.Description = entity.Description;
            
            if (todo.Checked != entity.Checked)
                todo.Checked = entity.Checked;

            return _dbContext.SaveChanges() > 0;
        }

        // Delete
        public bool Delete(int id)
        {
            var todo = GetById(id);
            if (todo == null)
                return false;
            _dbContext.Todo.Remove(todo);
            return _dbContext.SaveChanges() > 0;
        }
    }
}
