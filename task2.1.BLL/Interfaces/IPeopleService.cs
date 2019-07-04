namespace task2.BLL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using task2.BLL.DTO;

    public interface IPeopleService : IDisposable
    {
        void AddPeople(PeopleDTO orderDto);

        PeopleDTO GetPeople(int? id);

        IEnumerable<PeopleDTO> GetPeoples();
    }
}
