using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment2;

namespace Assignment3
{
    [TestClass]
    public class TodoItemTestUnit
    {
        [TestMethod]
        public void TestTodoItemEquality()
        {
            TodoItem todo1 = new TodoItem("Do some sh*t.");
            TodoItem todo1alt = todo1;
            TodoItem todo2 = new TodoItem("Do some other sh*t.");

            // Comparing with overriden Equals method test
            Assert.IsTrue(todo1.Equals(todo1alt));
            Assert.IsFalse(todo1.Equals(todo2));

            // Comparing with hash codes test
            Assert.IsTrue(todo1.GetHashCode() == todo1alt.GetHashCode());
            Assert.IsFalse(todo1.GetHashCode() == todo2.GetHashCode());

            // Comparing with overriden == operator test
            Assert.IsTrue(todo1 == todo1alt);
            Assert.IsFalse(todo1 == todo2);

            // Comparing with overriden != operator test
            Assert.IsFalse(todo1 != todo1alt);
            Assert.IsTrue(todo1 != todo2);
        }

        [TestMethod]
        public void TestTodoItemMarkAsCompleted()
        {
            TodoItem todo = new TodoItem("Go to FER and try not to kill myself.");

            // Test MarkAsComplete function
            Assert.IsNull(todo.DateCompleted);
            Assert.IsTrue(todo.MarkAsCompleted());
            Assert.IsNotNull(todo.DateCompleted);
            Assert.IsFalse(todo.MarkAsCompleted());
        }

        public void TestTodoItemToString()
        {
            string todoText = "What doth life?";
            TodoItem todo = new TodoItem(todoText);

            // Test ToString function
            Assert.AreEqual(todo.ToString(), todoText);
        }
    }
}
