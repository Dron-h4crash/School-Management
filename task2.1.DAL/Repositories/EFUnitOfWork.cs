using System;
using task2.DAL.EF;
using task2.DAL.Entities;
using task2.DAL.Intefaces;

namespace task2.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private PeopleContext db;
        private PeopleRepository peopleRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new PeopleContext(connectionString);
        }

        public IRepository<People> Peoples
        {
            get
            {
                if (peopleRepository == null)
                    peopleRepository = new PeopleRepository(db);
                return peopleRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
