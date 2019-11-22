namespace Enemies
{
    public interface IEnemy
    {
        float Health { get; set; }
        float Speed { get; set; }
        float Damage { get; set; }
    }
}