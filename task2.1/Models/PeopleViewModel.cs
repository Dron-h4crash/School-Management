using System;
using System.ComponentModel;

namespace task2.Models
{
    public class PeopleViewModel
    {
        public int Id { get; set; }
        [DisplayName("Имя")]
        public string FirstName { get; set; }

        [DisplayName("Фамилия")]
        public string LastName { get; set; }

        [DisplayName("Отчество")]
        public string SecondName { get; set; }

        [DisplayName("Дата рождения")]
        public DateTime DateBirthday { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Телефон")]
        public string Phone { get; set; }
    }
}