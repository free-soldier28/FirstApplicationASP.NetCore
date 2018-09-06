namespace DAL
{
    public class Permission : BaseEntity
    {
        public string Name { get; set; }

        public Role Role { get; set; }
    }
}
