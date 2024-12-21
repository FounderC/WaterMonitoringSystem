namespace WaterMonitoringSystem.CCL.Identity;

public class Operator : User
{
    public Operator(int userId, string name)
        : base(userId, name, nameof(Operator))
    {
    }
}