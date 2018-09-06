namespace DAL
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }

        public User User { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
