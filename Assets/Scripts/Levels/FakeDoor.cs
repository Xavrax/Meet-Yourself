using UnityEngine;

namespace Levels
{
    public class FakeDoor : IDoor
    {
        public Object RoomBehind { get; set; }
        public bool IsPosibleToPass { get; set; }

        public FakeDoor()
        {
            RoomBehind = null;
            IsPosibleToPass = false;
        }
        
        public void Open()
        {
            // do nothing
        }
    }
}