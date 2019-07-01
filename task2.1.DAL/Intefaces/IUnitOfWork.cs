using System;
using task2.DAL.Entities;

namespace task2.DAL.Intefaces
{
        public interface IUnitOfWork : IDisposable
        {
            IRepository<People> Peoples { get; }
            void Save();
        }
}
