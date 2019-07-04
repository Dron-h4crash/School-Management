namespace task2.BLL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using task2._1.BLL.Util;
    using task2.BLL.DTO;

    public interface IPeopleService : IDisposable
    {
        void AddPeople(PeopleDTO orderDto);

        PeopleDTO GetPeople(int? id);
        //Task<PeopleDTO> GetPeople();
        IEnumerable<PeopleDTO> GetPeoples();
        //Task<IEnumerable<PeopleDTO>> GetPeoples();

        void DelPeople(int id);

        void EditPeople(PeopleDTO orderDto);

        Events tevent { get; set; }

    }
}
