using Exercice02.Models;
using Exercice02.Repositories;
using System.Linq.Expressions;

namespace Exercice02.Data
{
    public class FakeTodoDb : IRepository<Todo>
    {
        private List<Todo> _tasks;
        private int _lastIndex = 0;

        public FakeTodoDb()
        {
            _tasks = new List<Todo>()
            {
                new Todo(){ Id = ++_lastIndex, Name = "rangement", Description = "ranger le salon"},
                new Todo(){ Id = ++_lastIndex, Name = "promenade", Description = "promener loukie"},
            };
        }

        public List<Todo> GetAll()
        {
            return _tasks;
        }

        public Todo? GetById(int id)
        {
            return _tasks.FirstOrDefault(task => task.Id == id);
        }
        
        public bool Add(Todo task)
        {
            //task.Id = ++_lastIndex;
            _tasks.Add(task);
            return true;
        }

        public bool Delete(int id)
        {
            var task = GetById(id);
            if (task == null)
                return false;
            _tasks.Remove(task);
            return true;
        }

        public bool Update(Todo entity)
        {
            throw new NotImplementedException();
        }
        public Todo? Get(Expression<Func<Todo, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        public List<Todo> GetAll(Expression<Func<Todo, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
