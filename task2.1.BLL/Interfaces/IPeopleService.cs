using System.Collections.Generic;
using task2.BLL.DTO;

namespace task2.BLL.Interfaces
{
    public interface IPeopleService
    {
        void AddPeople(PeopleDTO orderDto);
        PeopleDTO GetPeople(int? id);
        IEnumerable<PeopleDTO> GetPeoples();
        void Dispose();
    }
}
