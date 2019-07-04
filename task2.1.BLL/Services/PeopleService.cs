namespace task2.BLL.Services
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using task2.BLL.DTO;
    using task2.BLL.Infrastructure;
    using task2.BLL.Interfaces;
    using task2.DAL.Entities;
    using task2.DAL.Intefaces;

    public class PeopleService : IPeopleService
    {
        private IUnitOfWork database;
        private bool disposed = false;

        public PeopleService(IUnitOfWork uow)
        {
            this.database = uow;
        }

        public void AddPeople(PeopleDTO peopleDto)
        {
            if (string.IsNullOrEmpty(peopleDto.FirstName))
            {
                throw new ValidationException("имя пустое", "Firstname");
            }

            if (string.IsNullOrEmpty(peopleDto.LastName))
            {
                throw new ValidationException("фамилия пустая", "Lastname");
            }

            if (string.IsNullOrEmpty(peopleDto.SecondName))
            {
                throw new ValidationException("отчество пустое", "Secondname");
            }

            if (string.IsNullOrEmpty(peopleDto.Phone))
            {
                throw new ValidationException("телефон пустой", "Phone");
            }

            if (peopleDto.DateBirthday == null)
            {
                throw new ValidationException("дата рождения не задана", "DateBirthday");
            }

            if (string.IsNullOrEmpty(peopleDto.Email))
            {
                throw new ValidationException("Email пустой", "Email");
            }

            People people = new People
            {
                FirstName = peopleDto.FirstName,
                LastName = peopleDto.LastName,
                SecondName = peopleDto.SecondName,
                DateBirthday = peopleDto.DateBirthday,
                Email = peopleDto.Email,
                Phone = peopleDto.Phone
            };

            this.database.Peoples.Create(people);
            this.database.Save();
        }

        public IEnumerable<PeopleDTO> GetPeoples()
        {
            // Применяем автомаппер для проекции одной коллекции на другую.
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<People, PeopleDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<People>, List<PeopleDTO>>(database.Peoples.GetAll());
        }

        public PeopleDTO GetPeople(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлено id человека", "");
            }

            var people = this.database.Peoples.Get(id.Value);

            if (people == null)
            {
                throw new ValidationException("Человек не найден", "");
            }

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
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                this.database.Dispose();
                if (disposing)
                {
                    GC.SuppressFinalize(this);
                }

                this.disposed = true;
            }
        }
    }
}
