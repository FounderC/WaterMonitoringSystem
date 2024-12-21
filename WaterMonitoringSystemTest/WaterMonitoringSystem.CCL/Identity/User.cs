namespace WaterMonitoringSystem.CCL.Identity
{
    public abstract class User
    {
        public int UserId { get; }
        public string Name { get; }
        protected string UserType { get; }

        protected User(int userId, string name, string userType)
        {
            UserId = userId;
            Name = name;
            UserType = userType;
        }
    }
}