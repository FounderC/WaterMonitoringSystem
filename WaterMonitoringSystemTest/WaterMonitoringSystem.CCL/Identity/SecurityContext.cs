namespace WaterMonitoringSystem.CCL.Identity
{
    public static class SecurityContext
    {
        private static User _currentUser;

        public static User GetUser() => _currentUser;

        public static void SetUser(User user) => _currentUser = user;
    }
}