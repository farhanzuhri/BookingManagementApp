namespace API.Models
{
    public class AccountRole : Date
    {
        public Guid Guid { get; set; }
        public Guid AccountGuid { get; set; }
        public Guid RoleGuid { get; set; }
       
    }
}
