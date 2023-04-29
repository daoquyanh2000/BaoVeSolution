namespace BaoVeSolution.WebApplication.DB
{
    public class StoreInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<BaoVeContext>
    {
        protected override void Seed(BaoVeContext context)
        {
            /*            var users = new List<User>
                        {
                            new User{Id=1,Email="abc@gmail.com",FullName="tkadmin",UserName="tkadmin",Password="123456",CreatedDate=DateTime.Now,Status = UserStatus.SecondValue }
                        };
                        foreach (User user in users)
                        {
                            context.Users.Add(user);
                        }
                        context.SaveChanges();*/
        }
    }
}