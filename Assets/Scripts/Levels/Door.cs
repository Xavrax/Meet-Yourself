using UnityEngine;

namespace Levels
{
    public class Door : IDoor
    {
        public Object RoomBehind { get; set; }
        public bool IsPosibleToPass { get; set; }
        public void Open()
        {
            throw new System.NotImplementedException();
        }
    }
}