using UnityEngine;

namespace Levels
{
    public interface IDoor
    {
        Object RoomBehind { get; set; }
        bool IsPosibleToPass { get; set; }
        void Open();
    }
}