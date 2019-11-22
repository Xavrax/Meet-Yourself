using System;
using UnityEngine;

namespace Enemies
{
    public interface IEnemy
    {
        float Health { get; set; }
        float Speed { get; set; }
        float Damage { get; set; }
        float ShotSpeed { get; set; }

        void AtackAction();
        void MoveAction();
    }
}