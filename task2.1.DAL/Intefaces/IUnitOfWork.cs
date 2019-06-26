using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task2.DAL.Entities;

namespace task2.DAL.Intefaces
{
        public interface IUnitOfWork : IDisposable
        {
            IRepository<People> Peoples { get; }
            void Save();
        }
}
