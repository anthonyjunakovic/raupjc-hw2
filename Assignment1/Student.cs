namespace Assignment1
{
    public class Student
    {
        public string Name { get; set; }
        public string Jmbag { get; set; }
        public Gender Gender { get; set; }

        public Student(string name, string jmbag)
        {
            Name = name;
            Jmbag = jmbag;
        }

        public override bool Equals(object obj)
        {
            if (obj is Student)
            {
                Student student = (Student)obj;
                return (this.Jmbag == student.Jmbag);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Jmbag.GetHashCode();
        }

        public override string ToString()
        {
            return Name;
        }

        public static bool operator ==(Student student1, Student student2)
        {
            return student1.Equals(student2);
        }

        public static bool operator !=(Student student1, Student student2)
        {
            return !student1.Equals(student2);
        }
    }

    public enum Gender
    {
        Male,
        Female
    }
}