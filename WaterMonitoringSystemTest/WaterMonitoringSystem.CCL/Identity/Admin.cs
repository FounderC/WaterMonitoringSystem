﻿namespace WaterMonitoringSystem.CCL.Identity
{
    public class Admin : User
    {
        public Admin(int userId, string name)
            : base(userId, name, nameof(Admin))
        {
        }
    }
}