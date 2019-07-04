namespace task2._1.DAL.EF
{
    using System.Data.Entity;
    using task2.DAL.EF;

    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<PeopleContext>
    {
        protected override void Seed(PeopleContext db)
        {
        }
    }
}
