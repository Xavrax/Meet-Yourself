using UnityEngine;

namespace Levels
{
    public class FloorGeneratorTester : MonoBehaviour
    {
        public FloorGenerator mapGenerator;
        public uint level = 1;
        void Start()
        {
            mapGenerator.Level = level;
            mapGenerator.Genarate();
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}