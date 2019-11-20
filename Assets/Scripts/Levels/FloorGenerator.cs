using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class FloorGenerator : MonoBehaviour
{
    public GameObject wall;
    public GameObject doors;
    public int seed = 0; 
    public uint Level { get; set; }
    
    // Start is called before the first frame update
    void Start()
    {
        _rng = seed == 0 ? new Random() : new Random(seed);
        Level = 1;
        _rooms = Resources.LoadAll(Global.Paths.Rooms1) as GameObject[];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Genarate()
    {
        // todo: remove magic values
        var rooms = Level * 10;
        var roomIndex = 0;
        
        var currentRoom = Instantiate(
            Resources.Load($"{Global.Paths.Rooms1}StartingRoom_{Level}"),
            new Vector3(0, 0, 0),
            Quaternion.identity, 
            transform
        ) as GameObject;

        if (currentRoom == null)
        {
            Debug.LogError("Cannot instantiate starting room!");
            return;
        }
        
        for (var i = 0; i < rooms; i++)
        {
            var doors = new List<GameObject>();
            
            foreach (var child in currentRoom.transform.Find("Doors"))
            {
                var go = child as GameObject;
                
                if (go == null)
                {
                    continue;
                }
                
                if (go.name.Contains("DoorSlot"))
                {
                    doors.Add(go);                    
                }
            }

            if (doors.Count == 0)
            {
                if (roomIndex == 0)
                {
                    Genarate();
                    return;
                }
                
                currentRoom = _floor[--roomIndex];
                continue;
            }

            var door = doors
                    .Where(d => d.name.Contains())
                    .OrderBy(d => _rng.Next())
                    .FirstOrDefault();
                
            door.SetActive(false);
            Instantiate(
                _rooms
                    .OrderBy(r => _rng.Next())
                    .First(),
                door.transform.position,
                door.transform.rotation,
                transform
            );
            


        }
    }
    
    private Random _rng;
    private GameObject[] _rooms;
    private List<GameObject> _floor;
}
