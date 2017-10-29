using System;

namespace Assignment2.TodoItemExceptions
{
    public class DuplicateTodoItemException : Exception
    {
        public DuplicateTodoItemException(string message) : base(message)
        {
            /* nothing here... */
        }
    }
}
