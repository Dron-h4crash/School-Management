using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task2.DAL.EF;
using task2.DAL.Entities;
using task2.DAL.Intefaces;

namespace task2.DAL.Repositories
{
    public class PeopleRepository : IRepository<People>
    {
        private PeopleContext db;

        public PeopleRepository(PeopleContext context)
        {
            this.db = context;
        }

        public IEnumerable<People> GetAll()
        {
            return db.Peoples;
        }

        public People Get(int id)
        {
            return db.Peoples.Find(id);
        }

        public void Create(People people)
        {
            db.Peoples.Add(people);
        }

        public void Update(People people)
        {
            db.Entry(people).State = EntityState.Modified;
        }

        public IEnumerable<People> Find(Func<People, Boolean> predicate)
        {
            return db.Peoples.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            People people = db.Peoples.Find(id);
            if (people != null)
                db.Peoples.Remove(people);
        }
    }
}
