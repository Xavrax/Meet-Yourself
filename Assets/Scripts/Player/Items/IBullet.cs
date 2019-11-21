namespace Player.Items
{
    public interface IBullet
    {
        float HurtValue { get; set; }
        float ExistanceTime { get; set; }
        bool Pircing { get; set; }
    }
}