using BaoVeSolution.WebApplication.DB.Base;

namespace BaoVeSolution.WebApplication.DB.Entities
{
    public class User : BaseEntities
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}