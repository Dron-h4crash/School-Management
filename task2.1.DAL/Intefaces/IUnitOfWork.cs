namespace task2.DAL.Intefaces
{
    using System;
    using task2.DAL.Entities;

    public interface IUnitOfWork : IDisposable
        {
            IRepository<People> Peoples { get; }

            void Save();
        }
}
