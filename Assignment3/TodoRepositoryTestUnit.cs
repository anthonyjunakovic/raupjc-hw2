using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment2;
using Assignment2.TodoItemExceptions;
using GenericList;  // GenericList klasa i IGenericList sucelje iz prve domace zadace

namespace Assignment3
{
    [TestClass]
    public class TodoRepositoryTestUnit
    {
        [TestMethod]
        public void TestTodoRepositoryAdd()
        {
            TodoRepository todoRepo = new TodoRepository();
            TodoItem todo = new TodoItem("Prepare for the finals without crying.");

            // Test adding items to the repository (must return the added item)
            Assert.AreEqual(todoRepo.Add(todo), todo);
            // Now the item count should be 1
            Assert.AreEqual(todoRepo.GetAll().Count, 1);
            // If existing item is added, throw DuplicateTodoItemException
            Assert.ThrowsException<DuplicateTodoItemException>(() => todoRepo.Add(todo));
        }

        [TestMethod]
        public void TestTodoRepositoryGet()
        {
            IGenericList<TodoItem> todoList = new GenericList<TodoItem>();
            TodoItem todo = new TodoItem("Ran out of ideas for names, I guess.");
            todoList.Add(todo);
            TodoRepository todoRepo1 = new TodoRepository();
            TodoRepository todoRepo2 = new TodoRepository(todoList);

            // Repo should return null when it doesn't contain a GUID
            Assert.IsNull(todoRepo1.Get(todo.Id));
            // Otherwise it should return an item
            Assert.AreEqual(todoRepo2.Get(todo.Id), todo);
        }

        [TestMethod]
        public void TestTodoRepositoryGetActive()
        {
            TodoItem todo1 = new TodoItem("Some text 1");
            TodoItem todo2 = new TodoItem("Some text 2");
            TodoItem todo3compl = new TodoItem("Some text 3");
            todo3compl.MarkAsCompleted();
            TodoItem todo4compl = new TodoItem("Some text 4");
            todo4compl.MarkAsCompleted();

            IGenericList<TodoItem> todoList = new GenericList<TodoItem>();
            todoList.Add(todo1);
            todoList.Add(todo2);
            todoList.Add(todo3compl);
            todoList.Add(todo4compl);

            TodoRepository todoRepo = new TodoRepository(todoList);

            // Test for active TodoItems
            List<TodoItem> activeList = todoRepo.GetActive();
            // There must be exactly two active items
            Assert.AreEqual(activeList.Count, 2);
            // Those two items must be todo1 and todo2
            Assert.IsTrue(
                ((activeList[0] == todo1) && (activeList[1] == todo2)) || ((activeList[0] == todo2) && (activeList[1] == todo1))
            );
        }

        [TestMethod]
        public void TestTodoRepositoryGetAll()
        {
            TodoItem todo1 = new TodoItem("Some text 1");
            TodoItem todo2compl = new TodoItem("Some text 2");
            todo2compl.MarkAsCompleted();

            IGenericList<TodoItem> todoList = new GenericList<TodoItem>();
            todoList.Add(todo1);
            todoList.Add(todo2compl);

            TodoRepository todoRepo = new TodoRepository(todoList);

            // Test for all TodoItems
            List<TodoItem> activeList = todoRepo.GetAll();
            // There must be exactly two items (because we only added two)
            Assert.AreEqual(activeList.Count, 2);
            // Those two items must be todo1 and todo2compl
            Assert.IsTrue(
                ((activeList[0] == todo1) && (activeList[1] == todo2compl)) || ((activeList[0] == todo2compl) && (activeList[1] == todo1))
            );
        }

        [TestMethod]
        public void TestTodoRepositoryGetCompleted()
        {
            TodoItem todo1 = new TodoItem("Some text 1");
            TodoItem todo2 = new TodoItem("Some text 2");
            TodoItem todo3compl = new TodoItem("Some text 3");
            todo3compl.MarkAsCompleted();
            TodoItem todo4compl = new TodoItem("Some text 4");
            todo4compl.MarkAsCompleted();

            IGenericList<TodoItem> todoList = new GenericList<TodoItem>();
            todoList.Add(todo1);
            todoList.Add(todo2);
            todoList.Add(todo3compl);
            todoList.Add(todo4compl);

            TodoRepository todoRepo = new TodoRepository(todoList);

            // Test for completed TodoItems
            List<TodoItem> activeList = todoRepo.GetCompleted();
            // There must be exactly two completed items
            Assert.AreEqual(activeList.Count, 2);
            // Those two items must be todo3compl and todo4compl
            Assert.IsTrue(
                ((activeList[0] == todo3compl) && (activeList[1] == todo4compl)) || ((activeList[0] == todo4compl) && (activeList[1] == todo3compl))
            );
        }

        [TestMethod]
        public void TestTodoRepositoryGetFiltered()
        {
            TodoItem todo1 = new TodoItem("URGENT: Some text 1");
            TodoItem todo2 = new TodoItem("Some text 2");
            TodoItem todo3 = new TodoItem("URGENT: Some text 3");

            IGenericList<TodoItem> todoList = new GenericList<TodoItem>();
            todoList.Add(todo1);
            todoList.Add(todo2);
            todoList.Add(todo3);

            TodoRepository todoRepo = new TodoRepository(todoList);

            // Test for TodoItems that are URGENT
            List<TodoItem> activeList = todoRepo.GetFiltered((i) => (i.Text.StartsWith("URGENT")));
            // There must be exactly two URGENT items
            Assert.AreEqual(activeList.Count, 2);
            // Those two items must be todo1 and todo3
            Assert.IsTrue(
                ((activeList[0] == todo1) && (activeList[1] == todo3)) || ((activeList[0] == todo3) && (activeList[1] == todo1))
            );
        }

        [TestMethod]
        public void TestTodoRepositoryMarkAsCompleted()
        {
            TodoItem todo1 = new TodoItem("Some text 1");
            TodoItem todo2 = new TodoItem("Some text 2");
            TodoItem todo3 = new TodoItem("Some text 3");
            TodoItem todo4 = new TodoItem("Some text 4"); // not in the repo

            IGenericList<TodoItem> todoList = new GenericList<TodoItem>();
            todoList.Add(todo1);
            todoList.Add(todo2);
            todoList.Add(todo3);

            TodoRepository todoRepo = new TodoRepository(todoList);

            // Mark todo2 as complete
            Assert.IsTrue(todoRepo.MarkAsCompleted(todo2.Id));
            // Shouldn't be able to mark todo2 as complete if it is already complete
            Assert.IsFalse(todoRepo.MarkAsCompleted(todo2.Id));
            // Mark todo4 (which is not in the repo) - should return false
            Assert.IsFalse(todoRepo.MarkAsCompleted(todo4.Id));
        }

        [TestMethod]
        public void TestTodoRepositoryRemove()
        {
            TodoItem todo1 = new TodoItem("Some text 1");
            TodoItem todo2 = new TodoItem("Some text 2");
            TodoItem todo3 = new TodoItem("Some text 3");
            TodoItem todo4 = new TodoItem("Some text 4"); // not in the repo

            IGenericList<TodoItem> todoList = new GenericList<TodoItem>();
            todoList.Add(todo1);
            todoList.Add(todo2);
            todoList.Add(todo3);

            TodoRepository todoRepo = new TodoRepository(todoList);

            // Remove todo3 - should return true
            Assert.IsTrue(todoRepo.Remove(todo3.Id));
            // Mark todo4 (which is not in the repo) - should return false
            Assert.IsFalse(todoRepo.Remove(todo4.Id));
            // Now the item count should be 2
            Assert.AreEqual(todoRepo.GetAll().Count, 2);
        }

        [TestMethod]
        public void TestTodoRepositoryUpdate()
        {
            TodoItem todo1 = new TodoItem("Some text 1");
            TodoItem todo2 = new TodoItem("Some text 2");
            TodoItem todo3 = new TodoItem("Some text 3");
            TodoItem todo4 = new TodoItem("Some text 4"); // not in the repo

            IGenericList<TodoItem> todoList = new GenericList<TodoItem>();
            todoList.Add(todo1);
            todoList.Add(todo2);
            todoList.Add(todo3);

            TodoRepository todoRepo = new TodoRepository(todoList);

            // Update todo3 - should return todo3
            TodoItem todo3updated = new TodoItem("Some text 3 updated");
            todo3updated.Id = todo3.Id;
            Assert.AreEqual(todoRepo.Update(todo3updated), todo3updated);
            // Now the todo3 item's text should be equal to todo3updated item's text
            Assert.AreEqual(todoRepo.Get(todo3.Id).Text, todo3updated.Text);
            // Update todo4 (which is not in the repo) - should add it and return 4
            Assert.AreEqual(todoRepo.Update(todo4), todo4);
            // New item count should be 4
            Assert.AreEqual(todoRepo.GetAll().Count, 4);
        }
    }
}
