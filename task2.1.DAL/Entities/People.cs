namespace task2.DAL.Entities
{
    using System;

    public class People
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string SecondName { get; set; }

        public DateTime DateBirthday { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
