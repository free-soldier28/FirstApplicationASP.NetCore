namespace DAL
{
    public class Permission : BaseEntity
    {
        public string Name { get; set; }

        public User User { get; set; }
    }
}
