using UnityEngine;

namespace Player.Items
{
    public interface IBullet
    {
        string ShooterTag { get; set; }
        float HurtValue { get; set; }
        float ExistanceTime { get; set; }
        bool Pircing { get; set; }
    }
}