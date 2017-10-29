using System;
using System.Collections.Generic;
using System.Linq;
using Assignment2.TodoItemExceptions;
using Assignment3; // Ovo je ustvari namespace assemblija iz prve zadace (retrospektivno gledano, mogao sam ga bolje nazvati)
                   // (ukljucuje se GenericList i IGenericList tipovi)

namespace Assignment2
{
    /// <summary >
    /// Class that encapsulates all the logic for accessing TodoTtems .
    /// </ summary >
    public class TodoRepository : ITodoRepository
    {
        /// <summary >
        /// Repository does not fetch todoItems from the actual database ,
        /// it uses in memory storage for this excersise .
        /// </ summary >
        private readonly IGenericList<TodoItem> _inMemoryTodoDatabase;
        public TodoRepository(IGenericList<TodoItem> initialDbState = null)
        {
            if (initialDbState != null)
            {
                _inMemoryTodoDatabase = initialDbState;
            }
            else
            {
                _inMemoryTodoDatabase = new GenericList<TodoItem>();
            }
            // Shorter way to write this in C# using ?? operator :
            // x ?? y = > if x is not null , expression returns x. Else it will
            // return y.
            // _inMemoryTodoDatabase = initialDbState ?? new List < TodoItem >();
        }

        public TodoItem Add(TodoItem todoItem)
        {
            if (_inMemoryTodoDatabase.Contains(todoItem))
            {
                throw new DuplicateTodoItemException($"duplicate id: {todoItem.Id}");
            }
            _inMemoryTodoDatabase.Add(todoItem);
            return todoItem;
        }

        public TodoItem Get(Guid todoId)
        {
            IEnumerable<TodoItem> result = _inMemoryTodoDatabase.Where(i => i.Id == todoId);
            if (result.Count() == 0)
            {
                return null;
            }
            return result.First();
        }

        public List<TodoItem> GetActive()
        {
            return _inMemoryTodoDatabase.Where(i => !i.IsCompleted).ToList();
        }

        public List<TodoItem> GetAll()
        {
            return _inMemoryTodoDatabase.OrderByDescending(i => i.DateCreated).ToList();
        }

        public List<TodoItem> GetCompleted()
        {
            return _inMemoryTodoDatabase.Where(i => i.IsCompleted).ToList();
        }

        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
        {
            return _inMemoryTodoDatabase.Where(filterFunction).ToList();
        }

        public bool MarkAsCompleted(Guid todoId)
        {
            TodoItem i = Get(todoId);
            if (i == null)
            {
                return false;
            }
            i.MarkAsCompleted();
            return true;
        }

        public bool Remove(Guid todoId)
        {
            TodoItem i = Get(todoId);
            if (i == null)
            {
                return false;
            }
            _inMemoryTodoDatabase.Remove(i);
            return true;
        }

        public TodoItem Update(TodoItem todoItem)
        {
            TodoItem i = Get(todoItem.Id);
            if (i == null)
            {
                _inMemoryTodoDatabase.Add(todoItem);
                return todoItem;
            }
            _inMemoryTodoDatabase.Remove(i);
            i = todoItem;
            _inMemoryTodoDatabase.Add(i);
            return i;
        }
    }
}
