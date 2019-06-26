using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
