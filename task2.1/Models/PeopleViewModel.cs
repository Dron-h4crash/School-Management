using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace task2.Models
{
    public class PeopleViewModel
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