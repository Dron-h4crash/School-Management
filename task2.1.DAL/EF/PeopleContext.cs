namespace task2.DAL.EF
{
    using System.Data.Entity;
    using task2._1.DAL.EF;
    using task2.DAL.Entities;

    public class PeopleContext : DbContext
    {
        static PeopleContext()
        {
            Database.SetInitializer<PeopleContext>(new StoreDbInitializer());
        }

        public PeopleContext() 
            : base("name=DefaultConnection")
        {
        }

        public PeopleContext(string connectionString)
            : base(connectionString)
        {
        }

        public DbSet<People> Peoples
        {
            get; set;
        }
    }
}