using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour
{
    public GameObject wall;
    public GameObject doors;

    public uint Level { get; set; }

    private GameObject[] _rooms;
    // Start is called before the first frame update
    void Start()
    {
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
        var currentRoom = Resources.Load($"{Global.Paths.Rooms1}StartingRoom_{Level}") as GameObject;
        for (var i = 0; i < rooms; i++)
        {
            //currentRoom.GetComponent();
        }
    }
}
