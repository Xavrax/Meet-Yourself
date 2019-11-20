using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
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
        _floor = new List<GameObject>();
        _rng = seed == 0 ? new Random() : new Random(seed);
        Level = 1;
        _rooms = Directory
            .GetFiles(Global.Paths.Rooms1)
            .Where(name => !name.EndsWith(".meta"))
            .ToArray();
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
            AssetDatabase.LoadAssetAtPath<GameObject>($"{Global.Paths.Rooms1}StartingRoom_{Level}.prefab"),
            new Vector3(0, 0, 0),
            Quaternion.identity,
            transform
        );
        
        _floor.Add(currentRoom);

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
                var go = (child as Transform)?.gameObject;

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
                    .OrderBy(d => _rng.Next())
                    .FirstOrDefault();

            if (door == null)
            {
                Debug.LogError("Doors not found!");
                return;
            }
                
            door.SetActive(false);
            
            Instantiate(
                AssetDatabase.LoadAssetAtPath<GameObject>($"{Global.Paths.SceneNodes}Door.prefab"),
                door.transform.position,
                door.transform.rotation,
                door.transform.parent
            );
            
            Destroy(door);

            var room = Instantiate(
                AssetDatabase.LoadAssetAtPath<GameObject>(
                    _rooms
                        .OrderBy(r => _rng.Next())
                        .First()),
                door.transform.position,
                door.transform.rotation,
                transform
            );

            if (room == null)
            {
                Debug.LogError("Cannon initialize next room!");
                return;
            }
            
            _floor.Add(room);
            currentRoom = room;

        }
    }
    
    private Random _rng;
    private string[] _rooms;
    private List<GameObject> _floor;
}
