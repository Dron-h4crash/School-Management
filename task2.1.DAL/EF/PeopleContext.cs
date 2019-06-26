using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task2.DAL.Entities;

namespace task2.DAL.EF
{
    public class PeopleContext : DbContext
    {
        public DbSet<People> Peoples { get; set; }

        static PeopleContext()
        {
            Database.SetInitializer<PeopleContext>(new StoreDbInitializer());
        }
        public PeopleContext(string connectionString)
            : base(connectionString)
        {
        }
    }

    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<PeopleContext>
    {
        protected override void Seed(PeopleContext db)
        {
            db.Peoples.Add(new People { FirstName = "Bob", LastName = "Bob", SecondName = "Bob", DateBirthday = new DateTime(2000, 01, 01), Email = "bob@bob.bob", Phone = "12345678" });
            db.Peoples.Add(new People { FirstName = "Ted", LastName = "Ted", SecondName = "Ted", DateBirthday = new DateTime(2000, 01, 01), Email = "ted@ted.ted", Phone = "87654321" });
            db.SaveChanges();
        }
    }
}