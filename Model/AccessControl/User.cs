namespace Entity.AccessControl
{
    public class User : BaseEntityClass
    {
        public User()
        {
            Personal = new Personal();
        }
        public int PersonalId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public virtual Personal Personal { get; set; }
    }
}
