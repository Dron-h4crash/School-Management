using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task2.BLL.DTO;
using task2.BLL.Infrastructure;
using task2.BLL.Interfaces;
using task2.DAL.Entities;
using task2.DAL.Intefaces;

namespace task2.BLL.Services
{
    public class PeopleService : IPeopleService
    {
        IUnitOfWork Database { get; set; }

        public PeopleService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void AddPeople(PeopleDTO peopleDto)
        {

            //TODO: валидация 
            People people = new People
            {
                FirstName = peopleDto.FirstName,
                LastName = peopleDto.LastName,
                SecondName = peopleDto.SecondName,
                DateBirthday = peopleDto.DateBirthday,
                Email = peopleDto.Email,
                Phone = peopleDto.Phone
            };
            Database.Peoples.Create(people);
            Database.Save();
        }

        public IEnumerable<PeopleDTO> GetPeoples()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<People, PeopleDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<People>, List<PeopleDTO>>(Database.Peoples.GetAll());
        }

        public PeopleDTO GetPeople(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id человека", "");
            var people = Database.Peoples.Get(id.Value);
            if (people == null)
                throw new ValidationException("Человек не найден", "");

            return new PeopleDTO
            {
                Id = people.Id,
                FirstName = people.FirstName,
                LastName = people.LastName,
                SecondName = people.SecondName,
                Email = people.Email,
                Phone = people.Phone,
                DateBirthday = people.DateBirthday
            };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
