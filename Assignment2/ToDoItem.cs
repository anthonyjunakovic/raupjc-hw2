using System;

namespace Assignment2
{
    public class TodoItem
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        // Shorter syntax for single line getters in C#6
        // public bool IsCompleted = > DateCompleted . HasValue ;
        public bool IsCompleted
        {
            get
            {
                return DateCompleted.HasValue;
            }
        }
        public DateTime? DateCompleted { get; set; }
        public DateTime DateCreated { get; set; }

        public TodoItem(string text)
        {
            // Generates new unique identifier
            Id = Guid.NewGuid();
            // DateTime .Now returns local time , it wont always be what you expect
            // (depending where the server is).
            // We want to use universal (UTC ) time which we can easily convert to
            // local when needed.
            // ( usually done in browser on the client side )
            DateCreated = DateTime.UtcNow;
            Text = text;
        }

        public bool MarkAsCompleted()
        {
            if (!IsCompleted)
            {
                DateCompleted = DateTime.Now;
                return true;
            }
            return false;
        }

        public override bool Equals(object obj)
        {
            if (obj is TodoItem)
            {
                TodoItem item = (TodoItem)obj;
                return (item.Id == this.Id);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return Text;
        }

        public static bool operator ==(TodoItem item1, TodoItem item2)
        {
            if (item1 is null)
            {
                return (item2 is null);
            }
            return item1.Equals(item2);
        }

        public static bool operator !=(TodoItem item1, TodoItem item2)
        {
            if (item1 is null)
            {
                return (!(item2 is null));
            }
            return !item1.Equals(item2);
        }
    }
}
