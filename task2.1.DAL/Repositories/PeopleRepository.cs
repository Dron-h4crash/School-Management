namespace task2.DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using task2.DAL.EF;
    using task2.DAL.Entities;
    using task2.DAL.Intefaces;

    public class PeopleRepository : IRepository<People>
    {
        private PeopleContext db;

        public PeopleRepository(PeopleContext context)
        {
            this.db = context;
        }

        public IEnumerable<People> GetAll()
        {
            return this.db.Peoples;
        }

        public People Get(int id)
        {
            return this.db.Peoples.Find(id);
        }

        public void Create(People people)
        {
            this.db.Peoples.Add(people);
        }

        public void Update(People people)
        {
            this.db.Entry(people).State = EntityState.Modified;
        }

        public IEnumerable<People> Find(Func<People, bool> predicate)
        {
            return this.db.Peoples.Where(predicate).ToArray();
        }

        public void Delete(int id)
        {
            People people = this.db.Peoples.Find(id);
            if (people != null)
            {
                this.db.Peoples.Remove(people);
            }
        }
    }
}
