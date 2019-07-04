namespace task2.BLL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using task2.BLL.DTO;

    public interface IPeopleService : IDisposable
    {
        void AddPeople(PeopleDTO orderDto);

        PeopleDTO GetPeople(int? id);
        //Task<PeopleDTO> GetPeople();
        IEnumerable<PeopleDTO> GetPeoples();
        //Task<IEnumerable<PeopleDTO>> GetPeoples();
    }
}
