namespace task2.DAL.Repositories
{
    using System;
    using task2.DAL.EF;
    using task2.DAL.Entities;
    using task2.DAL.Intefaces;

    public class EFUnitOfWork : IUnitOfWork
    {
        private PeopleContext db;
        private PeopleRepository peopleRepository;
        private bool disposed = false;

        public EFUnitOfWork(string connectionString)
        {
            this.db = new PeopleContext(connectionString);
        }

        ~EFUnitOfWork()
        {
            this.Dispose(false);
        }

        public IRepository<People> Peoples
        {
            get
            {
                if (this.peopleRepository == null)
                {
                    this.peopleRepository = new PeopleRepository(this.db);
                }

                return this.peopleRepository;
            }
        }

        public void Save()
        {
            this.db.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                this.db.Dispose();
                if (disposing)
                {
                    GC.SuppressFinalize(this);
                }

                this.disposed = true;
            }
        }

    }
}
